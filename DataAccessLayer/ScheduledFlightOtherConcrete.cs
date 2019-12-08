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
    public class ScheduledFlightOtherConcrete : IScheduledFlightOther
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
                strquery = "SELECT a.airline_code, a.flight_id,a.estimated_time_arrival, a.approach_time,a.estimated_time_departure, a.arriving_from, a.proceeding_to,a.bill_to,b.operator";
                strquery = strquery + " FROM flight_master a, flight_processed b WHERE a.flight_id = b.flight_id AND b.processed = '" + "N" + "' AND b.processed_date = @processeddate AND NOT b.operator = @operator";
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
            GlobalVariable.BusinessDay = DateTime.Now.ToShortDateString();
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
                strquery = "SELECT c.airline_code, c.flight_id, c.bill_to, c.supplier_code, c.estimated_time_arrival, c.estimated_time_departure, c.arriving_from, c.proceeding_to FROM flight_reschedule c, flight_processed b";
                strquery = strquery + " WHERE c.flight_id= b.flight_id AND c.frmdate = @dates AND c.todate = @dates AND b.processed_date= @dates AND b.operator <> @operator AND b.processed='" + "N" + "'";
                strquery = strquery + " UNION SELECT a.airline_code, a.flight_id, a.bill_to, a.supplier_code, a.estimated_time_arrival, a.estimated_time_departure, a.arriving_from, a.proceeding_to FROM flight_schedule a, flight_processed b";
                strquery = strquery + " WHERE a.flight_id=b.flight_id AND b.processed_date= @dates AND b.operator <> @operator AND b.processed='" + "N" + "'";
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
            OleDbDataReader rd1, rd2;
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
                dataTable.Columns.Add("OPERATOR");
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

                        cmd = new OleDbCommand("SELECT operator FROM flight_processed WHERE flight_id='" + rd.GetString(1) + "' AND processed_date= @dates", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        cmd.Parameters.AddWithValue("@dates", DateTime.Now.ToString("dd/MM/yyyy"));
                        rd2 = cmd.ExecuteReader(CommandBehavior.SingleRow);
                        if (rd2.HasRows)
                        {
                            while (rd2.Read())
                            {
                                row[8] = !string.IsNullOrEmpty(rd2[0].ToString()) ? rd2[0].ToString() : string.Empty;
                            }
                            rd2.Close();
                        }
                        row[9] = "Scheduled";
                        row[10] = "On Time";
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
    }
}
