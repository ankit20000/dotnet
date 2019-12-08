using BusinessEntityLayer;
using Common;
using PosApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ScheduledFlightSelfConcrete : IScheduledFlightsSelf
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader rd;     
        string strquery = "";

        string ConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);
        public DataTable GetFlightScheduleData(string LoginUser)
        {            
            con = DBConnectionString.OpenConnection(ConString);
            DataTable dataTable = null;
            LoginUser = LoginUser ?? "";
            OleDbTransaction transaction = con.BeginTransaction();
            cmd = new OleDbCommand();            
            try
            {
                cmd = new OleDbCommand("delete from flight_reschedule where todate < @todate ", con);
                cmd.Parameters.AddWithValue("@todate", string.Format(GlobalVariable.BusinessDay, "dd/MM/yyyy"));
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand();                
                strquery = "SELECT a.airline_code, a.flight_id,a.estimated_time_arrival, a.approach_time,a.estimated_time_departure, a.arriving_from, a.proceeding_to,a.bill_to";
                strquery = strquery + " FROM flight_master a, flight_processed b WHERE a.flight_id = b.flight_id and b.processed = '" + "N" + "' AND b.processed_date = @processeddate AND b.operator = @operator";
                strquery = strquery + " ORDER BY a.airline_code, a.estimated_time_arrival";
                cmd.CommandText = strquery;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@processeddate", DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@operator", LoginUser);
                cmd.Transaction = transaction;
                rd = cmd.ExecuteReader();
                dataTable = CreateDataTable(rd, transaction,con);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Logging.ErrorLog(ex);
            }
            finally
            {                
                DBConnectionString.CloseConnection(ConString);
            }
            return dataTable;
        }

        public DataTable GetFlightRescheduleData(string LoginUser)
        {            
            con = DBConnectionString.OpenConnection(ConString);
            DataTable dataTable = null;
            OleDbTransaction transaction = con.BeginTransaction();
            cmd = new OleDbCommand();
            LoginUser = LoginUser ?? "";
            GlobalVariable.BusinessDay = DateTime.Now.ToShortDateString();
            try
            {
                cmd = new OleDbCommand("delete from flight_reschedule where todate < @todate ", con);
                cmd.Parameters.AddWithValue("@todate", string.Format(GlobalVariable.BusinessDay, "dd/MM/yyyy"));
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand();                
                strquery = "SELECT c.airline_code, c.flight_id, c.bill_to, c.supplier_code, c.estimated_time_arrival, c.estimated_time_departure, c.arriving_from, c.proceeding_to FROM flight_reschedule c, flight_processed b";
                strquery = strquery + " WHERE c.flight_id=b.flight_id AND c.frmdate = @dates AND c.todate = @dates AND b.processed_date= @dates AND b.operator = @operator AND b.processed='" + "N" + "'";                
                strquery = strquery + " UNION SELECT a.airline_code, a.flight_id, a.bill_to, a.supplier_code, a.estimated_time_arrival, a.estimated_time_departure, a.arriving_from, a.proceeding_to FROM flight_schedule a, flight_processed b";
                strquery = strquery + " WHERE a.flight_id=b.flight_id AND b.processed_date= @dates AND b.operator = @operator AND b.processed='" + "N" + "'";
                strquery = strquery + " AND a.flight_id NOT IN (SELECT c.flight_id FROM flight_reschedule c WHERE c.frmdate=@dates AND c.todate=@dates)";
                cmd.CommandText = strquery;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@dates", DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@operator", LoginUser);
                cmd.Transaction = transaction;
                rd = cmd.ExecuteReader();
                dataTable = CreateDataTable(rd, transaction,con);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Logging.ErrorLog(ex);
            }
            finally
            {                
                DBConnectionString.CloseConnection(ConString);
            }
            return dataTable;
        }

        private DataTable CreateDataTable(OleDbDataReader rd, OleDbTransaction transaction,OleDbConnection con)
        {
            DataTable dataTable = null;
            OleDbDataReader rd1;
            try
            {
                dataTable = new DataTable();
                dataTable.Columns.Add("AIRLINE NAME");
                dataTable.Columns.Add("FLIGHT #");
                dataTable.Columns.Add("FLIGHT TYPE");
                dataTable.Columns.Add("SUPPLIER");
                dataTable.Columns.Add("ETA");
                dataTable.Columns.Add("ETD");
                dataTable.Columns.Add("ORIGIN");
                dataTable.Columns.Add("DESTINATION");
                dataTable.Columns.Add("SCHEDULE STATUS");
                dataTable.Columns.Add("REMARK");
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        DataRow row = dataTable.NewRow();
                        cmd = new OleDbCommand("SELECT airline_name, airline_flag FROM airline_master WHERE airline_code='" + rd.GetString(0) + "' and bill_to='" + rd.GetString(2) + "'", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        rd1 = cmd.ExecuteReader(CommandBehavior.SingleRow);
                        if (rd1.HasRows)
                        {
                            while (rd1.Read())
                            {
                                row[0] = rd1[0].ToString();
                                row[2] = (rd1[1].ToString() == "D") ? "DOMESTIC" : "INTERNATIONAL";
                            }
                            rd1.Close();
                        }
                        else
                            row[0] = rd[0].ToString();

                        row[1] = !string.IsNullOrEmpty(rd[1].ToString()) ? rd[1].ToString() : string.Empty;

                        row[3] = !string.IsNullOrEmpty(rd[3].ToString()) ? rd[3].ToString() : string.Empty;

                        row[4] = !string.IsNullOrEmpty(rd[4].ToString()) ? rd[4].ToString() : string.Empty;

                        row[5] = !string.IsNullOrEmpty(rd[5].ToString()) ? rd[5].ToString() : string.Empty;

                        row[6] = !string.IsNullOrEmpty(rd[6].ToString()) ? rd[6].ToString() : string.Empty;

                        row[7] = !string.IsNullOrEmpty(rd[7].ToString()) ? rd[7].ToString() : string.Empty;

                        row[8] = "Scheduled";
                        row[9] = "On Time";
                        dataTable.Rows.Add(row);
                    }
                    rd.Close();
                }
            }
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }            
            return dataTable;
        }

        public List<AirlineMaster> GetAirlineMasterData(string airlinename)
        {
            List<AirlineMaster> lstAirlineMasters = null;
            AirlineMaster objAirlineMaster = null;
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "select airline_code,bill_to, ship_to, bill_to_name, ship_to_name,airline_flag from airline_master where airline_name= @airlinename";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@airlinename", airlinename);
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    lstAirlineMasters = new List<AirlineMaster>();
                    while (rd.Read())
                    {
                        objAirlineMaster = new AirlineMaster();
                        objAirlineMaster.airline_code = rd["airline_code"].ToString();
                        objAirlineMaster.bill_to = rd["bill_to"].ToString();
                        objAirlineMaster.ship_to = rd["ship_to"].ToString();
                        objAirlineMaster.bill_to_name = rd["bill_to_name"].ToString();
                        objAirlineMaster.ship_to_name = rd["ship_to_name"].ToString();
                        objAirlineMaster.airline_flag = rd["airline_flag"].ToString();
                        lstAirlineMasters.Add(objAirlineMaster);
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return lstAirlineMasters;
        }

        public List<string> GetFlightScheduleData(string FlightNo, string BillTo, string supplier, string AirlineFlag)
        {
            List<string> lstflightschedule = null;
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "select aircraft_type, turbo_prop from flight_schedule where flight_id= @flight_id and bill_to = @bill_to and supplier_code = @supplier_code and airline_flag=@airline_flag";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@flight_id", FlightNo);
                cmd.Parameters.AddWithValue("@bill_to", BillTo);
                cmd.Parameters.AddWithValue("@supplier_code", supplier);
                cmd.Parameters.AddWithValue("@airline_flag", AirlineFlag);
                rd = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lstflightschedule = new List<string>();
                        lstflightschedule.Add(rd.GetString(0));
                        lstflightschedule.Add(rd.GetString(1));
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return lstflightschedule;
        }
    }
}
