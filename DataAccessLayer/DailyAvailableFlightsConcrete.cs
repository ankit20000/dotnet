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
    public class DailyAvailableFlightsConcrete : IDailyAvailableFlights
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader rd;
        DataSet ds;
        OleDbDataAdapter adp;
        string ConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);

        public DataSet GetFlightMastersData()
        {
            con = DBConnectionString.OpenConnection(ConString);
            ds = new DataSet();
            OleDbTransaction transaction = con.BeginTransaction();
            cmd = new OleDbCommand();
            try
            {
                cmd = new OleDbCommand("DELETE FROM flight_schedule_new WHERE to_date < @todate ", con);
                cmd.Parameters.AddWithValue("@todate", DateTime.Now.ToString("yyyy/MM/dd"));
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand();
                cmd.CommandText = "SELECT airline_code, flight_id, estimated_time_arrival, approach_time, estimated_time_departure, arriving_from, proceeding_to, bill_to FROM flight_master ORDER BY airline_code, estimated_time_arrival";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;
                adp = new OleDbDataAdapter(cmd);
                adp.Fill(ds, "flight_master");
                DatasetHeaderNameChanges(ref ds);
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
            return ds;
        }

        public DataSet GetFlightScheduleNews(int day)
        {
            con = DBConnectionString.OpenConnection(ConString);
            ds = new DataSet();            
            OleDbTransaction transaction = con.BeginTransaction();
            try
            {
                cmd = new OleDbCommand("DELETE FROM flight_schedule_new WHERE to_date < @todate ", con);
                cmd.Parameters.AddWithValue("@todate", DateTime.Now.ToString("yyyy/MM/dd"));
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                cmd = new OleDbCommand();
                cmd.CommandText = "SELECT airline_name, flight_id, flight_type, supplier_code, eta, etd, arriving_from, proceed_to, aircraft_type FROM flight_schedule_new " +
                    " WHERE from_date<=@dates AND to_date >=@dates AND (frequency LIKE '8' OR frequency LIKE '" + day + "%'" + " OR frequency LIKE '%" + day + "%'" + " OR frequency LIKE '%" + day + "' OR frequency LIKE ''" + ") order by eta";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;
                cmd.Parameters.AddWithValue("@dates", DateTime.Now.ToString("yyyy/MM/dd"));
                adp = new OleDbDataAdapter(cmd);                
                adp.Fill(ds, "flight_schedule_new");                
                DatasetHeaderNameChanges(ref ds);
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
            return ds;
        }
        public FlightScheduleNew GetFlightScheduleNew(string flightNo)
        {
            FlightScheduleNew objFlightScheduleNew = null;
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "SELECT DISTINCT airline_code, bill_to, ship_to, product_type FROM flight_schedule_new WHERE from_date <= @todaydate AND to_date >= @todaydate AND flight_id = @flight_id";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@todaydate", DateTime.Now.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@flight_id", flightNo);
                rd = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        objFlightScheduleNew = new FlightScheduleNew();
                        objFlightScheduleNew.airline_code = rd["airline_code"].ToString();
                        objFlightScheduleNew.bill_to = rd["bill_to"].ToString();
                        objFlightScheduleNew.ship_to = rd["ship_to"].ToString();
                        objFlightScheduleNew.product_type = rd.GetString(3).ToString();
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return objFlightScheduleNew;
        }

        private void DatasetHeaderNameChanges(ref DataSet ds)
        {            
            ds.Tables[0].Columns[0].ColumnName = "AIRLINE NAME";
            ds.Tables[0].Columns[1].ColumnName = "FLIGHT #";
            ds.Tables[0].Columns[2].ColumnName = "FLIGHT TYPE";
            ds.Tables[0].Columns[3].ColumnName = "SUPPLIER"; ;
            ds.Tables[0].Columns[4].ColumnName = "ETA";
            ds.Tables[0].Columns[5].ColumnName = "ETD";
            ds.Tables[0].Columns[6].ColumnName = "ORIGIN";
            ds.Tables[0].Columns[7].ColumnName = "DESTINATION";
            ds.Tables[0].Columns[8].ColumnName = "AIRCRAFT TYPE";            
        }
    }
}
