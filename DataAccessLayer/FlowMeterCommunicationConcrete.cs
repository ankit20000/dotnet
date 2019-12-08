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
    public class FlowMeterCommunicationConcrete : IFlowMeterCommunication
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader rd;       
        string ConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);       

        public List<string> GetInvoiceList()
        {
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            List<string> lstInvoiceList = null;
            try
            {
                cmd.CommandText = "SELECT invoice_no FROM transactions";                
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    lstInvoiceList = new List<string>();
                    while (rd.Read())
                    {
                        lstInvoiceList.Add(rd["invoice_no"].ToString());
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
            return lstInvoiceList;
        }
        public DensityReference GetDensityReference(string refullerId)
        {
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            DensityReference objdensityReference = null;
            try
            {
                cmd.CommandText = "SELECT storage_id,density,temp,fuel_batch_no FROM density_ref_table WHERE storage_id = @storage_id";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@storage_id", refullerId);
                rd = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rd.HasRows)
                {                    
                    while (rd.Read())
                    {
                        decimal den,tmp;
                        objdensityReference = new DensityReference();
                        objdensityReference.storage_id = rd["storage_id"].ToString();
                        objdensityReference.density = decimal.TryParse(rd["density"].ToString(), out den) ? den : 0.0M;
                        objdensityReference.temp = decimal.TryParse(rd["tmp"].ToString(), out tmp) ? tmp : 0.0M;                        
                        objdensityReference.fuel_batch_no = rd["fuel_batch_no"].ToString();
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
            return objdensityReference;
        }
        public int SaveTransaction(Transactions transactions)
        {
            int res = 0;
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            try
            {
                cmd = new OleDbCommand("INSERT INTO transactions (invoice_no,airline_name,bill_to,ship_to,flight_id,arriving_from,proceeding_to,aircraft_reg_no,aircraft_type,turbo_prop," +
                    "duty_paid,bonded,equipement_no,qty,meter_start,meter_end,fuel_start,fuel_end,density,temprature,batch_no,bay_no,hydrant_pit_no,Ready_to_fuel,final_clearance,refueller_id," +
                    "operator,operation,offloading_rcpt,shift,business_day,trans_date,customer_name,above40T,flight_type)" +
                    " values (@invoice_no,@airline_name,@bill_to,@ship_to,@flight_id,@arriving_from,@proceeding_to,@aircraft_reg_no,@aircraft_type,@turbo_prop," +
                    "@duty_paid,@bonded,@equipement_no,@qty,@meter_start,@meter_end,@fuel_start,@fuel_end,@density,@temprature,@batch_no,@bay_no,@hydrant_pit_no,@Ready_to_fuel," +
                    "@final_clearance,@refueller_id,@operator,@operation,@offloading_rcpt,@shift,@business_day,@trans_date,@customer_name,@above40T,@flight_type)");
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
                cmd.Parameters.AddWithValue("@equipement_no", transactions.equipment_no);
                cmd.Parameters.AddWithValue("@qty", transactions.qty);
                cmd.Parameters.AddWithValue("@meter_start", transactions.meter_start);
                cmd.Parameters.AddWithValue("@meter_end", transactions.meter_end);
                cmd.Parameters.AddWithValue("@fuel_start", transactions.fuel_start);
                cmd.Parameters.AddWithValue("@fuel_end", transactions.fuel_end);
                cmd.Parameters.AddWithValue("@density", transactions.density);
                cmd.Parameters.AddWithValue("@temprature", transactions.temprature);
                cmd.Parameters.AddWithValue("@batch_no", transactions.batch_no);
                cmd.Parameters.AddWithValue("@bay_no", transactions.bay_no);
                cmd.Parameters.AddWithValue("@hydrant_pit_no", transactions.hydrant_pit_no);
                cmd.Parameters.AddWithValue("@Ready_to_fuel", transactions.Ready_to_fuel);
                cmd.Parameters.AddWithValue("@final_clearance", transactions.final_clearance);
                cmd.Parameters.AddWithValue("@refueller_id", transactions.refueller_id);
                cmd.Parameters.AddWithValue("@operator", transactions.operators);
                cmd.Parameters.AddWithValue("@operation", transactions.operation);
                cmd.Parameters.AddWithValue("@offloading_rcpt", transactions.offloading_rcpt);
                cmd.Parameters.AddWithValue("@shift", transactions.flight_id);
                cmd.Parameters.AddWithValue("@business_day", transactions.business_day);
                cmd.Parameters.AddWithValue("@trans_date", transactions.trans_date);
                cmd.Parameters.AddWithValue("@customer_name", transactions.customer_name);
                cmd.Parameters.AddWithValue("@above40T", transactions.above40T);
                cmd.Parameters.AddWithValue("@flight_type", transactions.flight_type);
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return res;
        }

        public void updateFlightProcessedStatus(string FlightNo)
        {
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            OleDbTransaction transaction = con.BeginTransaction();
            try
            {
                cmd.CommandText = "SELECT * FROM Flight_processed where flight_id='" + FlightNo + "' and processed_date= '"+ GlobalVariable.BusinessDay +"'";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;
                var flightid = cmd.ExecuteScalar();
                if (!string.IsNullOrEmpty(flightid.ToString()))
                {
                    cmd = new OleDbCommand();
                    cmd.CommandText = "UPDATE Flight_processed set processed='Y' where fligh_id= '" + FlightNo + "' and processed_date= '" + GlobalVariable.BusinessDay + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
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
        }
        public void UpdateConfigurationInfo(string invseries,string meterend)
        {
            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand();
            try
            {
                cmd.CommandText = "UPDATE Configuration set inv_series='" + invseries + "',meter_end='"+ meterend + "'";
                cmd.CommandType = CommandType.Text;               
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            finally
            {
                DBConnectionString.CloseConnection(ConString);
            }
        }
    }
}
