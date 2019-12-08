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
    public class FuelTransactionConcrete : IFuelTransaction
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader rd;
        DataSet ds;
        OleDbDataAdapter adp;
        string ConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);
        
        public DataSet GetAirlineRegMaster(string airlinecode)
        {
            con = DBConnectionString.OpenConnection(ConString);
            ds = new DataSet();
            OleDbTransaction transaction = con.BeginTransaction();
            cmd = new OleDbCommand();
            try
            {               
                cmd.CommandText = "select airline_code, aircraft_reg_no, turbo_prop, off_take_weight, wide_body, aircraft_type from airline_regno_master where airline_code = @airlinecode order by aircraft_reg_no";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;
                cmd.Parameters.AddWithValue("@airlinecode", airlinecode);
                adp = new OleDbDataAdapter(cmd);
                adp.Fill(ds, "airline_regno_master");
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

        public FlightScheduleNew GetFlightScheduleNewInfo(string FlightNo)
        {
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            FlightScheduleNew objflightScheduleNew = null;
            try
            {
                cmd.CommandText = "SELECT distinct airline_name, bill_to, ship_to from flight_schedule_new where from_date <= @currentdate And to_date >= @currentdate And flight_id = @flight_id";
                cmd.Parameters.AddWithValue("@currentdate", DateTime.Now.ToString("dd/MM/yyyy"));
                cmd.Parameters.AddWithValue("@flight_id", FlightNo);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if(rd.HasRows)
                {
                    while(rd.Read())
                    {
                        objflightScheduleNew = new FlightScheduleNew();
                        objflightScheduleNew.bill_to = rd["bill_to"].ToString();
                        objflightScheduleNew.ship_to = rd["ship_to"].ToString();
                    }
                }
                rd.Close();
            }
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            finally
            {                
                DBConnectionString.CloseConnection(ConString);
            }
            return objflightScheduleNew;
        }

        public void UpdateConfigurationInfo(string invseries)
        {
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "UPDATE Configuration set inv_series='" + invseries + "'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            finally
            {                
                DBConnectionString.CloseConnection(ConString);
            }
        }

        public void updateFlightProcessedStatus(string FlightNo)
        {            
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            OleDbTransaction transaction = con.BeginTransaction();
            try
            {
                cmd.CommandText = "SELECT * FROM Flight_processed where flight_id='" + FlightNo + "'";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;
                var flightid= cmd.ExecuteScalar();
                if (!string.IsNullOrEmpty(flightid.ToString()))
                {
                    cmd = new OleDbCommand();
                    cmd.CommandText = "UPDATE Flight_processed set processed='F' where fligh_id= '" + FlightNo + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                Logging.ErrorLog(ex);
            }
            finally
            {                
                DBConnectionString.CloseConnection(ConString);
            }
        }

        public FlightMaster GetFlightMasterInfo(string FlightNo)
        {
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            FlightMaster objFlightMaster = null;
            try
            {
                cmd.CommandText = "SELECT aircraft_type,bonded,duty_paid,turbo_prop,arriving_from,proceeding_to,supplier_code FROM flight_schedule WHERE flight_id=@flight_id";
                cmd.Parameters.AddWithValue("@flight_id", FlightNo);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        objFlightMaster = new FlightMaster();
                        objFlightMaster.aircraft_type = rd["aircraft_type"].ToString();
                        objFlightMaster.bonded = rd["bonded"].ToString();
                        objFlightMaster.duty_paid = rd["duty_paid"].ToString();
                        objFlightMaster.turbo_prop = rd["turbo_prop"].ToString();
                        objFlightMaster.arriving_from = rd["arriving_from"].ToString();
                        objFlightMaster.proceeding_to = rd["proceeding_to"].ToString();
                        objFlightMaster.supplier_code = rd["supplier_code"].ToString();                        
                    }
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            finally
            {
                DBConnectionString.CloseConnection(ConString);
            }
            return objFlightMaster;
        }

        public FlightSchedule GetFlightScheduleInfo(string FlightNo)
        {
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            FlightSchedule objFlightSchedule = null;
            try
            {
                cmd.CommandText = "SELECT aircraft_type,bonded,duty_paid,turbo_prop,arriving_from,proceeding_to,supplier_code FROM flight_master WHERE flight_id = @flight_id";
                cmd.Parameters.AddWithValue("@flight_id", FlightNo);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        objFlightSchedule = new FlightSchedule();
                        objFlightSchedule.aircraft_type = rd["aircraft_type"].ToString();
                        objFlightSchedule.bonded = rd["bonded"].ToString();
                        objFlightSchedule.duty_paid = rd["duty_paid"].ToString();
                        objFlightSchedule.turbo_prop = rd["turbo_prop"].ToString();
                        objFlightSchedule.arriving_from = rd["arriving_from"].ToString();
                        objFlightSchedule.proceeding_to = rd["proceeding_to"].ToString();
                        objFlightSchedule.supplier_code = rd["supplier_code"].ToString();
                    }
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            finally
            {
                DBConnectionString.CloseConnection(ConString);
            }
            return objFlightSchedule;
        }

        private void DatasetHeaderNameChanges(ref DataSet ds)
        {
            ds.Tables[0].Columns[0].ColumnName = "Airline Code";
            ds.Tables[0].Columns[1].ColumnName = "Reg No";
            ds.Tables[0].Columns[2].ColumnName = "Turbo Prop";
            ds.Tables[0].Columns[3].ColumnName = "40T Indicator"; ;
            ds.Tables[0].Columns[4].ColumnName = "Wide Body Indicator";
            ds.Tables[0].Columns[5].ColumnName = "Aircraft Type";
        }

        public Dictionary<string,string> GetAirlineCodeList(string AirlineCode)
        {
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            Dictionary<string, string> dict = null;
            try
            {
                cmd.CommandText = "SELECT flight_id,airline_code FROM  Flight_Master  where  airline_code = @airline_code";
                cmd.Parameters.AddWithValue("@airline_code", AirlineCode);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    dict = new Dictionary<string, string>();
                    while (rd.Read())
                    {                       
                        dict.Add(rd["airline_code"].ToString(),rd["flight_id"].ToString());
                    }
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            finally
            {
                DBConnectionString.CloseConnection(ConString);
            }
            return dict;
        }

        public bool CheckTurboOptions(string registrationNo, string airlineCode, bool turboflag)
        {
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            bool flag = false;
            try
            {
                cmd.CommandText = "select * from airline_regno_master where aircraft_reg_no =@aircraft_reg_no and airline_code =@airline_code";
                cmd.Parameters.AddWithValue("@aircraft_reg_no", registrationNo);
                cmd.Parameters.AddWithValue("@airline_code", airlineCode);
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        if ((rd[2].ToString() == "Y" && turboflag == true) || (rd[2].ToString() == "N" && turboflag == false))
                            flag = true;
                        else
                            flag=false;
                    }
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            finally
            {
                DBConnectionString.CloseConnection(ConString);
            }
            return flag;
        }

        public AirlineMaster GetAirlineMasterInfo(string airlineCode, string airlineName, string airlineFlag)
        {           
            AirlineMaster objAirlineMaster = null;
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "SELECT bill_to, ship_to FROM airline_master where airline_flag='" + airlineFlag +"' and airline_code ='" + airlineCode + "' and airline_name='" + airlineName + "'";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;                
                rd = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rd.HasRows)
                {                    
                    while (rd.Read())
                    {
                        objAirlineMaster = new AirlineMaster();                        
                        objAirlineMaster.bill_to = rd["bill_to"].ToString();
                        objAirlineMaster.ship_to = rd["ship_to"].ToString();                                              
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return objAirlineMaster;
        }

        public int SaveTransaction(Transactions transactions)
        {
            int res=0;
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            try
            {
                cmd = new OleDbCommand("INSERT INTO transactions (invoice_no,airline_name,bill_to,ship_to,flight_id,arriving_from,proceeding_to,aircraft_reg_no,aircraft_type,turbo_prop," +
                    "duty_paid,bonded,fuel_start,fuel_end,bay_no,hydrant_pit_no,Ready_to_fuel,final_clearance,refueller_id,operator,operation,shift,business_day," +
                    "trans_date,customer_name,above40T,flight_type) values (@invoice_no,@airline_name,@bill_to,@ship_to,@flight_id,@arriving_from,@proceeding_to,@aircraft_reg_no,@aircraft_type,@turbo_prop," +
                    "@duty_paid,@bonded,@fuel_start,@fuel_end,@bay_no,@hydrant_pit_no,@Ready_to_fuel,@final_clearance,@refueller_id,@operator,@operation,@shift,@business_day," +
                    "@trans_date,@customer_name,@above40T,@flight_type)");
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@invoice_no", transactions.invoice_no);
                cmd.Parameters.AddWithValue("@airline_name", transactions.airline_name);
                cmd.Parameters.AddWithValue("@bill_to", transactions.bill_to);
                cmd.Parameters.AddWithValue("@ship_to", transactions.ship_to);
                cmd.Parameters.AddWithValue("@flight_id", transactions.flight_id);
                cmd.Parameters.AddWithValue("@arriving_from", transactions.arriving_from);
                cmd.Parameters.AddWithValue("@proceeding_to", transactions.proceeding_to);
                cmd.Parameters.AddWithValue("@aircraft_reg_no", transactions.aircraft_reg_no);
                cmd.Parameters.AddWithValue("@aircraft_type", transactions.aircraft_type);
                cmd.Parameters.AddWithValue("@turbo_prop", transactions.turbo_prop);
                cmd.Parameters.AddWithValue("@duty_paid", transactions.duty_paid);
                cmd.Parameters.AddWithValue("@bonded", transactions.bonded);
                cmd.Parameters.AddWithValue("@fuel_start", transactions.fuel_start);
                cmd.Parameters.AddWithValue("@fuel_end", transactions.fuel_end);
                cmd.Parameters.AddWithValue("@bay_no", transactions.bay_no);
                cmd.Parameters.AddWithValue("@hydrant_pit_no", transactions.hydrant_pit_no);
                cmd.Parameters.AddWithValue("@Ready_to_fuel", transactions.Ready_to_fuel);
                cmd.Parameters.AddWithValue("@final_clearance", transactions.final_clearance);
                cmd.Parameters.AddWithValue("@refueller_id", transactions.refueller_id);
                cmd.Parameters.AddWithValue("@operator", transactions.operators);
                cmd.Parameters.AddWithValue("@operation", transactions.operation);
                cmd.Parameters.AddWithValue("@shift", transactions.flight_id);
                cmd.Parameters.AddWithValue("@business_day", transactions.business_day);
                cmd.Parameters.AddWithValue("@trans_date", transactions.trans_date);
                cmd.Parameters.AddWithValue("@customer_name", transactions.customer_name);
                cmd.Parameters.AddWithValue("@above40T", transactions.above40T);
                cmd.Parameters.AddWithValue("@flight_type", transactions.flight_type);
                res=cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return res;
        }
    }
}
