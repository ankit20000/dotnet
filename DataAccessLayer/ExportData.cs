using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Common;
using PosApplication.Interfaces;

namespace DataAccessLayer
{
    public class ExportData : IExportData
    {
        #region Declaration

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader SqlRd;
        OleDbDataReader AccessRd;
        SqlDataAdapter dataAdapter;
        OleDbDataAdapter oleDbDataAdapter;
        OleDbTransaction transaction;
        DataTable _dtGetData = new DataTable();

        string AccessConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);
        string SqlConString = DBConnectionString.Getconnectionstring(Database.SQLDBConnection);

        #endregion

        #region GetExportFuelTransactionData

        public DataTable GetExportFuelTransactionData()
        {
            DataTable dtGetData = new DataTable();

            try
            {
                con = DBConnectionString.OpenConnection(AccessConString);
                transaction = con.BeginTransaction();
                cmd = new OleDbCommand("SELECT  invoice_no, airline_name, bill_to, ship_to, flight_id, arriving_from, proceeding_to, aircraft_reg_no, aircraft_type, turbo_prop, duty_paid, bonded, payment_type, equipment_no, qty, meter_start, meter_end, fuel_start, fuel_end, density, temprature, batch_no, bay_no, hydrant_pit_no, Ready_to_fuel, final_clearance, carnetcard_no, issuedby, exp_date, auth_no, auth_date, cash_memo_no, cash_memo_dt, refueller_id, operator, operation, offloading_rcpt, comments, received_by, shift, shift_processed, shift_processed_by, business_day, trans_date, rollover_shift, rollover_day, customer_name, dip_start, dip_end, above40T, flight_type FROM transactions WHERE export_flag = 'N'", con);
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;
                oleDbDataAdapter = new OleDbDataAdapter(cmd);
                oleDbDataAdapter.Fill(dtGetData);

                AccessRd = cmd.ExecuteReader();
                transaction.Commit();

                if (dtGetData.Rows.Count > 0)
                {
                    while (AccessRd.Read())
                    {
                        //con = DBConnectionString.OpenConnection(SqlConString);
                        //cmd = new OleDbCommand("SELECT invoice_no, airline_name, bill_to, ship_to, flight_id, arriving_from, proceeding_to, aircraft_reg_no, aircraft_type, turbo_prop, duty_paid, bonded, payment_type, equipment_no, qty, meter_start, meter_end, fuel_start, fuel_end, density, temprature, batch_no, bay_no, hydrant_pit_no, Ready_to_fuel, final_clearance, carnetcard_no, issuedby, exp_date, auth_no, auth_date, cash_memo_no, cash_memo_dt, refueller_id, operator, operation, offloading_rcpt, comments, received_by, shift, shift_processed, shift_processed_by, business_day, trans_date, rollover_shift, rollover_day, customer_name, dip_start, dip_end, remark4, remark5 FROM transactions WHERE  invoice_no='" + AccessRd[0].ToString() + "'", con);
                        //cmd.CommandType = CommandType.Text;
                        //SqlRd = cmd.ExecuteReader();


                        con = DBConnectionString.OpenConnection(SqlConString);
                        cmd = new OleDbCommand("INSERT INTO transaction (invoice_no, airline_name, bill_to, ship_to, flight_id, arriving_from, proceeding_to, aircraft_reg_no, aircraft_type, turbo_prop, duty_paid, bonded, payment_type, equipment_no, qty, meter_start, meter_end, fuel_start, fuel_end, density, temprature, batch_no, bay_no, hydrant_pit_no, Ready_to_fuel, final_clearance, carnetcard_no, issuedby, exp_date, auth_no, auth_date, cash_memo_no, cash_memo_dt, refueller_id, operator, operation, offloading_rcpt, comments, received_by, shift, shift_processed, shift_processed_by, business_day, trans_date, rollover_shift, rollover_day, customer_name, dip_start, dip_end, remark4, remark5) VALUES(@invoice_no, @airline_name, @bill_to, @ship_to, @flight_id, @arriving_from, @proceeding_to, @aircraft_reg_no, @aircraft_type, @turbo_prop, @duty_paid, @bonded, @payment_type, @equipment_no, @qty, @meter_start, @meter_end, @fuel_start, @fuel_end, @density, @temprature, @batch_no, @bay_no, @hydrant_pit_no, @Ready_to_fuel, @final_clearance, @carnetcard_no, @issuedby, @exp_date, @auth_no, @auth_date, @cash_memo_no, @cash_memo_dt, @refueller_id, @operator, @operation, @offloading_rcpt, @comments, @received_by, @shift, @shift_processed, @shift_processed_by, @business_day, @trans_date, @rollover_shift, @rollover_day, @customer_name, @dip_start, @dip_end, @remark4, @remark5)", con);

                        cmd.Parameters.AddWithValue("@invoice_no", AccessRd["invoice_no"].ToString());
                        cmd.Parameters.AddWithValue("@airline_name", AccessRd["airline_name"].ToString());
                        cmd.Parameters.AddWithValue("@bill_to", AccessRd["bill_to"].ToString());
                        cmd.Parameters.AddWithValue("@ship_to", AccessRd["ship_to"].ToString());
                        cmd.Parameters.AddWithValue("@flight_id", AccessRd["flight_id"].ToString());
                        cmd.Parameters.AddWithValue("@arriving_from", AccessRd["arriving_from"].ToString());
                        cmd.Parameters.AddWithValue("@proceeding_to", AccessRd["proceeding_to"].ToString());
                        cmd.Parameters.AddWithValue("@aircraft_reg_no", AccessRd["aircraft_reg_no"].ToString());
                        cmd.Parameters.AddWithValue("@aircraft_type", AccessRd["aircraft_type"].ToString());
                        cmd.Parameters.AddWithValue("@turbo_prop", AccessRd["turbo_prop"].ToString());
                        cmd.Parameters.AddWithValue("@duty_paid", AccessRd["duty_paid"].ToString());
                        cmd.Parameters.AddWithValue("@bonded", AccessRd["bonded"].ToString());
                        cmd.Parameters.AddWithValue("@payment_type", AccessRd["payment_type"].ToString());
                        cmd.Parameters.AddWithValue("@equipment_no", AccessRd["equipment_no"].ToString());
                        cmd.Parameters.AddWithValue("@qty", AccessRd["qty"].ToString());
                        cmd.Parameters.AddWithValue("@meter_start", AccessRd["meter_start"].ToString());
                        cmd.Parameters.AddWithValue("@meter_end", AccessRd["meter_end"].ToString());
                        cmd.Parameters.AddWithValue("@fuel_start", AccessRd["fuel_start"].ToString());
                        cmd.Parameters.AddWithValue("@fuel_end", AccessRd["fuel_end"].ToString());
                        cmd.Parameters.AddWithValue("@density", AccessRd["density"].ToString());
                        cmd.Parameters.AddWithValue("@temprature", AccessRd["temprature"].ToString());
                        cmd.Parameters.AddWithValue("@batch_no", AccessRd["batch_no"].ToString());
                        cmd.Parameters.AddWithValue("@bay_no", AccessRd["bay_no"].ToString());
                        cmd.Parameters.AddWithValue("@hydrant_pit_no", AccessRd["hydrant_pit_no"].ToString());
                        cmd.Parameters.AddWithValue("@Ready_to_fuel", AccessRd["Ready_to_fuel"].ToString());
                        cmd.Parameters.AddWithValue("@final_clearance", AccessRd["final_clearance"].ToString());
                        cmd.Parameters.AddWithValue("@carnetcard_no", AccessRd["carnetcard_no"].ToString());
                        cmd.Parameters.AddWithValue("@issuedby", AccessRd["issuedby"].ToString());
                        cmd.Parameters.AddWithValue("@exp_date", AccessRd["exp_date"].ToString());
                        cmd.Parameters.AddWithValue("@auth_no", AccessRd["auth_no"].ToString());
                        cmd.Parameters.AddWithValue("@auth_date", AccessRd["auth_date"].ToString());
                        cmd.Parameters.AddWithValue("@cash_memo_no", AccessRd["cash_memo_no"].ToString());
                        cmd.Parameters.AddWithValue("@cash_memo_dt", AccessRd["cash_memo_dt"].ToString());
                        cmd.Parameters.AddWithValue("@refueller_id", AccessRd["refueller_id"].ToString());
                        cmd.Parameters.AddWithValue("@operator", AccessRd["operator"].ToString());
                        cmd.Parameters.AddWithValue("@operation", AccessRd["operation"].ToString());
                        cmd.Parameters.AddWithValue("@offloading_rcpt", AccessRd["offloading_rcpt"].ToString());
                        cmd.Parameters.AddWithValue("@comments", AccessRd["comments"].ToString());
                        cmd.Parameters.AddWithValue("@received_by", AccessRd["received_by"].ToString());
                        cmd.Parameters.AddWithValue("@shift", AccessRd["shift"].ToString());
                        cmd.Parameters.AddWithValue("@shift_processed", AccessRd["shift_processed"].ToString());
                        cmd.Parameters.AddWithValue("@shift_processed_by", AccessRd["shift_processed_by"].ToString());
                        cmd.Parameters.AddWithValue("@business_day", AccessRd["business_day"].ToString());
                        cmd.Parameters.AddWithValue("@trans_date", AccessRd["trans_date"].ToString());
                        cmd.Parameters.AddWithValue("@rollover_shift", AccessRd["rollover_shift"].ToString());
                        cmd.Parameters.AddWithValue("@rollover_day", AccessRd["rollover_day"].ToString());
                        cmd.Parameters.AddWithValue("@customer_name", AccessRd["customer_name"].ToString());
                        cmd.Parameters.AddWithValue("@dip_start", AccessRd["dip_start"].ToString());
                        cmd.Parameters.AddWithValue("@dip_end", AccessRd["dip_end"].ToString());
                        cmd.Parameters.AddWithValue("@remark4", AccessRd["remark4"].ToString());
                        cmd.Parameters.AddWithValue("@remark5", AccessRd["remark5"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                        //if (SqlRd.HasRows)
                        //{
                        //    while (SqlRd.Read())
                        //    {
                        con = DBConnectionString.OpenConnection(SqlConString);
                        cmd = new OleDbCommand("UPDATE transactions SET export_flag = 'Y'  WHERE  invoice_no='" + AccessRd[0].ToString() + "'", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        //    }
                        //}
                        SqlRd.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Logging.ErrorLog(ex);
            }

            return dtGetData;
        }

        #endregion

        #region GetExportStockTransferData

        public void GetExportStockTransferData()
        {
            try
            {
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("SELECT bill_no, trans_date, trans_time,  tran_type, source, destination, density, temperature, fuel_batch_no, meter_start, meter_end, Qty, operator, shift, business_day, comments FROM StockTransfer WHERE export_flag = 'N'", con);
                cmd.CommandType = CommandType.Text;
                AccessRd = cmd.ExecuteReader();

                if (AccessRd.HasRows)
                {
                    while (AccessRd.Read())
                    {
                        con = DBConnectionString.OpenConnection(SqlConString);
                        cmd = new OleDbCommand("SELECT bill_no, trans_date, trans_time,  tran_type, source, destination, density, temperature, batch_no, meter_start, meter_end, Qty, operator, shift, business_day, comments FROM StockTransfer WHERE  bill_no='" + AccessRd[0].ToString() + "'", con);
                        cmd.CommandType = CommandType.Text;
                        SqlRd = cmd.ExecuteReader();


                        con = DBConnectionString.OpenConnection(SqlConString);
                        cmd = new OleDbCommand("INSERT INTO StockTransfer (bill_no, trans_date, trans_time,  tran_type, source, destination, density, temperature, batch_no, meter_start, meter_end, Qty, operator, shift, business_day, comments) VALUES(@bill_no, @trans_date, @trans_time, @ tran_type, @source, @destination, @density, @temperature, @batch_no, @meter_start, @meter_end, @Qty, @operator, @shift, @business_day, @comments)", con);

                        cmd.Parameters.AddWithValue("@bill_no", AccessRd["bill_no"].ToString());
                        cmd.Parameters.AddWithValue("@trans_date", AccessRd["trans_date"].ToString());
                        cmd.Parameters.AddWithValue("@trans_time", AccessRd["trans_time"].ToString());
                        cmd.Parameters.AddWithValue("@tran_type", AccessRd["tran_type"].ToString());
                        cmd.Parameters.AddWithValue("@source", AccessRd["source"].ToString());
                        cmd.Parameters.AddWithValue("@destination", AccessRd["destination"].ToString());
                        cmd.Parameters.AddWithValue("@density", AccessRd["density"].ToString());
                        cmd.Parameters.AddWithValue("@temperature", AccessRd["temperature"].ToString());
                        cmd.Parameters.AddWithValue("@batch_no", AccessRd["batch_no"].ToString());
                        cmd.Parameters.AddWithValue("@meter_start", AccessRd["meter_start"].ToString());
                        cmd.Parameters.AddWithValue("@meter_end", AccessRd["meter_end"].ToString());
                        cmd.Parameters.AddWithValue("@Qty", AccessRd["Qty"].ToString());
                        cmd.Parameters.AddWithValue("@operator", AccessRd["operator"].ToString());
                        cmd.Parameters.AddWithValue("@shift", AccessRd["shift"].ToString());
                        cmd.Parameters.AddWithValue("@business_day", AccessRd["business_day"].ToString());
                        cmd.Parameters.AddWithValue("@comments", AccessRd["comments"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                        //if (SqlRd.HasRows)
                        //{
                        //    while (SqlRd.Read())
                        //    {
                        con = DBConnectionString.OpenConnection(SqlConString);
                        cmd = new OleDbCommand("UPDATE StockTransfer SET export_flag = 'Y' WHERE  bill_no='" + AccessRd[0].ToString() + "'", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        //    }
                        //}
                        SqlRd.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        #endregion

        #region GetFormLoadData

        public DataTable GetFormLoadData()
        {
            try
            {
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("SELECT invoice_no, flight_id, business_day, shift, qty FROM transactions WHERE export_flag='N' UNION SELECT bill_no, 'CT/ST', business_day, shift, qty FROM stocktransfer WHERE export_flag='N' ORDER BY business_day DESC, shift", con);
                cmd.CommandType = CommandType.Text;
                oleDbDataAdapter = new OleDbDataAdapter(cmd);
                oleDbDataAdapter.Fill(_dtGetData);

                //BuildDataTable();

            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }

            return _dtGetData;
        }

        #endregion

        #region GetDataByDate

        public DataTable GetDataByDate(string dateTime)
        {
            try
            {
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("SELECT invoice_no, flight_id, business_day, shift, qty FROM transactions WHERE business_day ='" + dateTime + "' UNION SELECT bill_no, 'CT/ST', business_day, shift, qty FROM stocktransfer WHERE business_day = '" + dateTime + "' ORDER BY shift", con);
                cmd.CommandType = CommandType.Text;
                oleDbDataAdapter = new OleDbDataAdapter(cmd);
                oleDbDataAdapter.Fill(_dtGetData);
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }

            return _dtGetData;
        }

        #endregion        
    }
}
