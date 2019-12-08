using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text;
using Common;
using PosApplication.Interfaces;

namespace DataAccessLayer
{
    public class ImportData : IImportData
    {
        #region Declaration

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader SqlRd;
        OleDbDataReader AccessRd;
        SqlDataAdapter dataAdapter;
        OleDbDataAdapter oleDbDataAdapter;
        OleDbTransaction transaction;

        string AccessConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);
        string SqlConString = DBConnectionString.Getconnectionstring(Database.SQLDBConnection);

        DataTable dtGetDataFromSql = new DataTable("MasterData");
        bool _IsImported = false;
        StringBuilder alertMessage = new StringBuilder();

        #endregion

        #region Import Master Data
        public string ImportMasterTables(List<string> lstTableNames)
        {
            try
            {
                //if (GetConfData())
                if (true)
                {
                    foreach (var item in lstTableNames)
                    {
                        if (item.Contains("AirlineMaster"))
                        {
                            GetAirlineMaster();
                        }
                        else if (item.Contains("Flight_schedule"))
                        {
                            GetFlightSchedule();
                        }
                        else if (item.Contains("Location_Master"))
                        {
                            GetLocationMaster();
                        }
                        else if (item.Contains("Product_master"))
                        {
                            GetProductMaster();
                        }
                        else if (item.Contains("Refuller_Master"))
                        {
                            GetRefuellerMaster();
                        }
                        else if (item.Contains("Tank_Master"))
                        {
                            GetTankMaster();
                        }
                        else if (item.Contains("UserMaster"))
                        {
                            GetUserMaster();
                        }
                        else if (item.Contains("Equipment Master"))
                        {
                            GetEquipmentMaster();
                        }
                        else if (item.Contains("Supplier_Master"))
                        {
                            GetSupplierMaster();
                        }
                        else if (item.Contains("FuelBatch_Details"))
                        {
                            GetFuelBatchDetails();
                        }
                        else if (item.Contains("Airline_regno_master"))
                        {
                            GetAirCraftRegNoMaster();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }

            return alertMessage.ToString();
        }
        #endregion        

        #region Get Configuration Data
        private bool GetConfData()
        {
            string errorMessage = string.Empty;
            string refueller = string.Empty;
            string IP = string.Empty;

            try
            {
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("select * from Configuration", con);
                cmd.CommandType = CommandType.Text;
                AccessRd = cmd.ExecuteReader();

                if (AccessRd.HasRows)
                {
                    if (AccessRd[0].ToString() == "false")
                    {
                        refueller = AccessRd[0].ToString();
                        IP = AccessRd[1].ToString();

                        return true;
                    }
                }
                else
                {
                    errorMessage = "No Refueller is Available. Please update Configuration Details";
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }

            return false;
        }

        #endregion

        //#region Get Master Data From SQL
        //private void GetMasterDataFromSQL(string tableName)
        //{
        //    try
        //    {
        //        //Get SqlDataAdapetr for supplied table from SQL Database
        //        dataAdapter = GetSqlDataAdapter(tableName);

        //        //Fills the data from the SQL database
        //        dataAdapter.Fill(dtGetDataFromSql);

        //        if (dtGetDataFromSql.Rows.Count > 0)
        //        {
        //            //Delete the existing Master data before inserting new data into Access DB
        //            con = DBConnectionString.OpenConnection(AccessConString);
        //            transaction = con.BeginTransaction();
        //            cmd = new OleDbCommand("DELETE FROM " + tableName + "", con);
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Transaction = transaction;
        //            cmd.ExecuteNonQuery();
        //            transaction.Commit();

        //            if (dtGetDataFromSql.Rows.Count > 0)
        //            {
        //                foreach (DataRow row in dtGetDataFromSql.Rows)
        //                {
        //                    String commandText = "INSERT INTO " + tableName + " VALUES (";

        //                    foreach (var item in row.ItemArray)
        //                    {
        //                        commandText += "'" + item.ToString() + "',";
        //                    }

        //                    commandText = commandText.Remove(commandText.Length - 1);
        //                    commandText += ")";

        //                    con = DBConnectionString.OpenConnection(AccessConString);
        //                    cmd = new OleDbCommand(commandText, con);
        //                    cmd.CommandType = CommandType.Text;
        //                    cmd.ExecuteNonQuery();
        //                    transaction.Commit();
        //                }

        //                alertMessage.AppendLine(tableName + ": Data Imported \n");
        //            }
        //        }
        //        else
        //        {
        //            alertMessage.AppendLine(tableName + ": No Data found from SQL Database \n");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        transaction.Rollback();
        //        
        //        Logging.ErrorLog(ex);
        //    }
        //}
        //#endregion

        #region Get All Master Data
        private void GetAirlineMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT loc_code, airline_code, airline_name, bill_to, ship_to, sold_to, bill_to_name, ship_to_name, airline_flag, tmstamp FROM POS.airlinemaster UNION SELECT loc_code, airline_code, airline_name, bill_to, ship_to, sold_to, bill_to_name, ship_to_name, airline_flag, tmstamp FROM POS.airlinemaster WHERE NOT airline_code IS NULL ORDER BY airline_code", SqlConString);

                //Fills the data set with data from the SQL database
                dataAdapter.Fill(dtGetDataFromSql);

                if (dtGetDataFromSql.Rows.Count > 0)
                {
                    //Delete the Airline Master data before inserting new data into Access DB
                    con = DBConnectionString.OpenConnection(AccessConString);
                    transaction = con.BeginTransaction();
                    cmd = new OleDbCommand("DELETE FROM airline_master", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    con.Close();

                    foreach (DataRow row in dtGetDataFromSql.Rows)
                    {
                        if (string.IsNullOrEmpty(row["ship_to_name"].ToString()) || row["ship_to_name"].ToString().ToUpper() != "I")
                        {
                            row["ship_to_name"] = "D";
                        }

                        con = DBConnectionString.OpenConnection(AccessConString);
                        transaction = con.BeginTransaction();
                        cmd = new OleDbCommand("INSERT INTO airline_master (loc_code, airline_code, airline_name, bill_to, ship_to, sold_to, bill_to_name, ship_to_name, airline_flag, tmstamp) VALUES(@loc_code, @airline_code, @airline_name, @bill_to, @ship_to, @sold_to, @bill_to_name, @ship_to_name, @airline_flag, @tmstamp)", con);

                        cmd.Parameters.AddWithValue("@loc_code", row["loc_code"].ToString());
                        cmd.Parameters.AddWithValue("@airline_code", row["airline_code"].ToString());
                        cmd.Parameters.AddWithValue("@airline_name", row["airline_name"].ToString());
                        cmd.Parameters.AddWithValue("@bill_to", row["bill_to"].ToString());
                        cmd.Parameters.AddWithValue("@ship_to", row["ship_to"].ToString());
                        cmd.Parameters.AddWithValue("@sold_to", row["sold_to"].ToString());
                        cmd.Parameters.AddWithValue("@bill_to_name", row["bill_to_name"].ToString());
                        cmd.Parameters.AddWithValue("@ship_to_name", row["ship_to_name"].ToString());
                        cmd.Parameters.AddWithValue("@airline_flag", row["airline_flag"].ToString());
                        cmd.Parameters.AddWithValue("@tmstamp", row["tmstamp"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        con.Close();
                    }

                    alertMessage.AppendFormat(Constants.ImportSuccessful, "Airline Master");
                }
                else
                {
                    alertMessage.AppendFormat(Constants.SqlNoDataFound, "Airline Master");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
                con.Close();
                transaction.Rollback();                
            }
        }
        private void GetFlightMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT flight_id, airline_code, supplier_code, arriving_from, proceeding_to, aircraft_type, estimated_time_arrival, estimated_time_departure, type, turbo_prop, frequency, tmstamp, approach_time, estimated_qty, from_date, to_date, bill_to, ship_to FROM POS.Flight_schedule", SqlConString);

                //Fills the data set with data from the SQL database
                dataAdapter.Fill(dtGetDataFromSql);

                if (dtGetDataFromSql.Rows.Count > 0)
                {
                    //Delete the Flight_Master data before inserting new data into Access DB
                    con = DBConnectionString.OpenConnection(AccessConString);
                    transaction = con.BeginTransaction();
                    cmd = new OleDbCommand("DELETE FROM Flight_Master", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    con.Close();

                    foreach (DataRow row in dtGetDataFromSql.Rows)
                    {
                        con = DBConnectionString.OpenConnection(AccessConString);
                        transaction = con.BeginTransaction();
                        cmd = new OleDbCommand("INSERT INTO Flight_Master (flight_id, airline_code, supplier_code, arriving_from, proceeding_to, aircraft_type, estimated_time_arrival, estimated_time_departure, type, turbo_prop, frequency, tmstamp, approach_time, estimated_qty, frmdate, todate, bill_to, ship_to) VALUES(@flight_id, @airline_code, @supplier_code, @arriving_from, @proceeding_to, @aircraft_type, @estimated_time_arrival, @estimated_time_departure, @type, @turbo_prop, @frequency, @tmstamp, @approach_time, @estimated_qty, @frmdate, @todate, @bill_to, @ship_to)", con);

                        cmd.Parameters.AddWithValue("@flight_id", row["flight_id"].ToString());
                        cmd.Parameters.AddWithValue("@airline_code", row["airline_code"].ToString());
                        cmd.Parameters.AddWithValue("@supplier_code", row["supplier_code"].ToString());
                        cmd.Parameters.AddWithValue("@arriving_from", row["arriving_from"].ToString());
                        cmd.Parameters.AddWithValue("@proceeding_to", row["proceeding_to"].ToString());
                        cmd.Parameters.AddWithValue("@aircraft_type", row["aircraft_type"].ToString());
                        cmd.Parameters.AddWithValue("@estimated_time_arrival", row["estimated_time_arrival"].ToString());
                        cmd.Parameters.AddWithValue("@estimated_time_departure", row["estimated_time_departure"].ToString());
                        cmd.Parameters.AddWithValue("@type", row["type"].ToString());
                        cmd.Parameters.AddWithValue("@turbo_prop", row["turbo_prop"].ToString());
                        cmd.Parameters.AddWithValue("@frequency", row["frequency"].ToString());
                        cmd.Parameters.AddWithValue("@tmstamp", row["tmstamp"].ToString());
                        cmd.Parameters.AddWithValue("@approach_time", row["approach_time"].ToString());
                        cmd.Parameters.AddWithValue("@estimated_qty", row["estimated_qty"].ToString() == string.Empty ? 0 : Convert.ToDecimal(row["estimated_qty"]));
                        cmd.Parameters.AddWithValue("@frmdate", row["frmdate"].ToString());
                        cmd.Parameters.AddWithValue("@todate", row["todate"].ToString());
                        cmd.Parameters.AddWithValue("@bill_to", row["bill_to"].ToString());
                        cmd.Parameters.AddWithValue("@ship_to", row["ship_to"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        con.Close();
                    }
                    alertMessage.AppendFormat(Constants.ImportSuccessful, "Flight Master");
                }
                else
                {
                    alertMessage.AppendFormat(Constants.SqlNoDataFound, "Flight Master");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
                con.Close();
                transaction.Rollback();                
            }
        }
        private void GetLocationMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT loc_code, loc_name, sap_code, iata_code, loc_address1, loc_address2, city_code, postal_code, tmstamp FROM POS.Location_Master", SqlConString);

                //Fills the data set with data from the SQL database
                dataAdapter.Fill(dtGetDataFromSql);

                if (dtGetDataFromSql.Rows.Count > 0)
                {
                    //Delete the Flight_Master data before inserting new data into Access DB
                    con = DBConnectionString.OpenConnection(AccessConString);
                    transaction = con.BeginTransaction();
                    cmd = new OleDbCommand("DELETE FROM location_master", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    con.Close();

                    foreach (DataRow row in dtGetDataFromSql.Rows)
                    {
                        con = DBConnectionString.OpenConnection(AccessConString);
                        transaction = con.BeginTransaction();
                        cmd = new OleDbCommand("INSERT INTO location_master (loc_code, loc_name, sap_code, iata_code, loc_address1, loc_address2, city_code, postal_code, tmstamp) VALUES(@loc_code, @loc_name, @sap_code, @iata_code, @loc_address1, @loc_address2, @city_code, @postal_code, @tmstamp)", con);

                        cmd.Parameters.AddWithValue("@loc_code", row["loc_code"].ToString());
                        cmd.Parameters.AddWithValue("@loc_name", row["loc_name"].ToString());
                        cmd.Parameters.AddWithValue("@sap_code", row["sap_code"].ToString());
                        cmd.Parameters.AddWithValue("@iata_code", row["iata_code"].ToString());
                        cmd.Parameters.AddWithValue("@loc_address1", row["loc_address1"].ToString());
                        cmd.Parameters.AddWithValue("@loc_address2", row["loc_address2"].ToString());
                        cmd.Parameters.AddWithValue("@city_code", row["city_code"].ToString());
                        cmd.Parameters.AddWithValue("@postal_code", row["postal_code"].ToString());
                        cmd.Parameters.AddWithValue("@tmstamp", row["tmstamp"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        con.Close();
                    }
                    alertMessage.AppendFormat(Constants.ImportSuccessful, "Location Master");
                }
                else
                {
                    alertMessage.AppendFormat(Constants.SqlNoDataFound, "Location Master");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
                con.Close();
                transaction.Rollback();
            }
        }
        private void GetProductMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT product_code, product_desc, product_remark, tmstamp FROM POS.product_master", SqlConString);

                //Fills the data set with data from the SQL database
                dataAdapter.Fill(dtGetDataFromSql);

                if (dtGetDataFromSql.Rows.Count > 0)
                {
                    //Delete the Flight_Master data before inserting new data into Access DB
                    con = DBConnectionString.OpenConnection(AccessConString);
                    transaction = con.BeginTransaction();
                    cmd = new OleDbCommand("DELETE FROM product_master", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    con.Close();

                    foreach (DataRow row in dtGetDataFromSql.Rows)
                    {
                        con = DBConnectionString.OpenConnection(AccessConString);
                        transaction = con.BeginTransaction();
                        cmd = new OleDbCommand("INSERT INTO product_master (product_code, product_desc, product_remark, tmstamp) VALUES(@product_code, @product_desc, @product_remark, @tmstamp)", con);

                        cmd.Parameters.AddWithValue("@product_code", row["product_code"].ToString());
                        cmd.Parameters.AddWithValue("@product_desc", row["product_desc"].ToString());
                        cmd.Parameters.AddWithValue("@product_remark", row["product_remark"].ToString());
                        cmd.Parameters.AddWithValue("@tmstamp", row["tmstamp"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        con.Close();
                    }
                    alertMessage.AppendFormat(Constants.ImportSuccessful, "Product Master");
                }
                else
                {
                    alertMessage.AppendFormat(Constants.SqlNoDataFound, "Product Master");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
                con.Close();
                transaction.Rollback();
            }
        }
        private void GetRefuellerMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT refueller_id , vehicle_no, chasis_no, engine_no, product_code, fuel_qty, fuel_capacity, flowmtr_id, tmstamp FROM POS.refuller_master", SqlConString);

                //Fills the data set with data from the SQL database
                dataAdapter.Fill(dtGetDataFromSql);

                if (dtGetDataFromSql.Rows.Count > 0)
                {
                    //Delete the Flight_Master data before inserting new data into Access DB
                    con = DBConnectionString.OpenConnection(AccessConString);
                    transaction = con.BeginTransaction();
                    cmd = new OleDbCommand("DELETE FROM refueller_master", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    con.Close();

                    foreach (DataRow row in dtGetDataFromSql.Rows)
                    {
                        con = DBConnectionString.OpenConnection(AccessConString);
                        transaction = con.BeginTransaction();
                        cmd = new OleDbCommand("INSERT INTO refueller_master (refueller_id , vehicle_no, chasis_no, engine_no, product_code, fuel_qty, fuel_capacity, flowmtr_id, tmstamp) VALUES(@refueller_id, @vehicle_no, @chasis_no, @engine_no, @product_code, @fuel_qty, @fuel_capacity, @flowmtr_id, @tmstamp)", con);

                        cmd.Parameters.AddWithValue("@refueller_id", row["refueller_id"].ToString());
                        cmd.Parameters.AddWithValue("@vehicle_no", row["vehicle_no"].ToString());
                        cmd.Parameters.AddWithValue("@chasis_no", row["chasis_no"].ToString());
                        cmd.Parameters.AddWithValue("@engine_no", row["engine_no"].ToString());
                        cmd.Parameters.AddWithValue("@product_code", row["product_code"].ToString());
                        cmd.Parameters.AddWithValue("@fuel_qty", row["fuel_qty"].ToString() == string.Empty ? 0 : Convert.ToDecimal(row["fuel_qty"]));
                        cmd.Parameters.AddWithValue("@fuel_capacity", row["fuel_capacity"].ToString() == string.Empty ? 0 : Convert.ToDecimal(row["fuel_capacity"]));
                        cmd.Parameters.AddWithValue("@flowmtr_id", row["flowmtr_id"].ToString());
                        cmd.Parameters.AddWithValue("@tmstamp", row["tmstamp"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        con.Close();
                    }
                    alertMessage.AppendFormat(Constants.ImportSuccessful, "Refuller Master");
                }
                else
                {
                    alertMessage.AppendFormat(Constants.SqlNoDataFound, "Refuller Master");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
                con.Close();
                transaction.Rollback();
            }
        }
        private void GetTankMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT tank_no, tank_desc, product_code , fuel_qty, tank_density, tank_temp, tank_capacity, tmstamp FROM POS.tank_master", SqlConString);

                //Fills the data set with data from the SQL database
                dataAdapter.Fill(dtGetDataFromSql);

                if (dtGetDataFromSql.Rows.Count > 0)
                {
                    //Delete the Flight_Master data before inserting new data into Access DB
                    con = DBConnectionString.OpenConnection(AccessConString);
                    transaction = con.BeginTransaction();
                    cmd = new OleDbCommand("DELETE FROM tank_master", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    con.Close();

                    foreach (DataRow row in dtGetDataFromSql.Rows)
                    {
                        con = DBConnectionString.OpenConnection(AccessConString);
                        transaction = con.BeginTransaction();
                        cmd = new OleDbCommand("INSERT INTO tank_master (tank_no, tank_desc, product_code , fuel_qty, tank_density, tank_temp, tank_capacity, tmstamp) VALUES(@tank_no, @tank_desc, @product_code , @fuel_qty, @tank_density, @tank_temp, @tank_capacity, @tmstamp)", con);

                        cmd.Parameters.AddWithValue("@tank_no", row["tank_no"].ToString());
                        cmd.Parameters.AddWithValue("@tank_desc", row["tank_desc"].ToString());
                        cmd.Parameters.AddWithValue("@product_code ", row["product_code"].ToString());
                        cmd.Parameters.AddWithValue("@fuel_qty", row["fuel_qty"].ToString() == string.Empty ? 0 : Convert.ToDecimal(row["fuel_qty"]));
                        cmd.Parameters.AddWithValue("@tank_density", row["tank_density"].ToString() == string.Empty ? 0 : Convert.ToDecimal(row["tank_density"]));
                        cmd.Parameters.AddWithValue("@tank_temp", row["tank_temp"].ToString() == string.Empty ? 0 : Convert.ToDecimal(row["tank_temp"]));
                        cmd.Parameters.AddWithValue("@tank_capacity", row["tank_capacity"].ToString() == string.Empty ? 0 : Convert.ToDecimal(row["tank_capacity"]));
                        cmd.Parameters.AddWithValue("@tmstamp", row["tmstamp"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        con.Close();
                    }
                    alertMessage.AppendFormat(Constants.ImportSuccessful, "Tank Master");
                }
                else
                {
                    alertMessage.AppendFormat(Constants.SqlNoDataFound, "Tank Master");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
                con.Close();
                transaction.Rollback();
            }
        }
        private void GetUserMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT loginName, fullName, password, user_level, address1, address2, address3, address4, res_phone_no, mob_phone_no, emergency_contact, remarks1, remarks2, tmstamp FROM POS.user_master WHERE remarks1='Y'", SqlConString);

                //Fills the data set with data from the SQL database
                dataAdapter.Fill(dtGetDataFromSql);

                if (dtGetDataFromSql.Rows.Count > 0)
                {
                    //Delete the Flight_Master data before inserting new data into Access DB
                    con = DBConnectionString.OpenConnection(AccessConString);
                    transaction = con.BeginTransaction();
                    cmd = new OleDbCommand("DELETE FROM user_master", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    con.Close();

                    foreach (DataRow row in dtGetDataFromSql.Rows)
                    {
                        con = DBConnectionString.OpenConnection(AccessConString);
                        transaction = con.BeginTransaction();
                        cmd = new OleDbCommand("INSERT INTO user_master (loginName, fullName, password, user_level, address1, address2, address3, address4, res_phone_no, mob_phone_no, emergency_contact, remarks1, remarks2, tmstamp) VALUES(@loginName, @fullName, @password, @user_level, @address1, @address2, @address3, @address4, @res_phone_no, @mob_phone_no, @emergency_contact, @remarks1, @remarks2, @tmstamp)", con);

                        cmd.Parameters.AddWithValue("@loginName", row["loginName"].ToString());
                        cmd.Parameters.AddWithValue("@fullName", row["fullName"].ToString());
                        cmd.Parameters.AddWithValue("@password", row["password"].ToString());
                        cmd.Parameters.AddWithValue("@user_level", row["user_level"].ToString() == string.Empty ? 0 : Convert.ToInt32(row["user_level"]));
                        cmd.Parameters.AddWithValue("@address1", row["address1"].ToString());
                        cmd.Parameters.AddWithValue("@address2", row["address2"].ToString());
                        cmd.Parameters.AddWithValue("@address3", row["address3"].ToString());
                        cmd.Parameters.AddWithValue("@address4", row["address4"].ToString());
                        cmd.Parameters.AddWithValue("@res_phone_no", row["res_phone_no"].ToString());
                        cmd.Parameters.AddWithValue("@mob_phone_no", row["mob_phone_no"].ToString());
                        cmd.Parameters.AddWithValue("@emergency_contact", row["emergency_contact"].ToString());
                        cmd.Parameters.AddWithValue("@remarks1", row["remarks1"].ToString());
                        cmd.Parameters.AddWithValue("@remarks2", row["remarks2"].ToString());
                        cmd.Parameters.AddWithValue("@tmstamp", row["tmstamp"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        con.Close();
                    }
                    alertMessage.AppendFormat(Constants.ImportSuccessful, "User Master");
                }
                else
                {
                    alertMessage.AppendFormat(Constants.SqlNoDataFound, "User Master");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
                con.Close();
                transaction.Rollback();
            }
        }
        private void GetEquipmentMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT equipment_id, equipment_desc, vehicle_no, chasis_no, engine_no, fuel_capacity, flowmtr_vendor, flowmtr_id, tmstamp FROM POS.equipment_master", SqlConString);

                //Fills the data set with data from the SQL database
                dataAdapter.Fill(dtGetDataFromSql);

                if (dtGetDataFromSql.Rows.Count > 0)
                {
                    //Delete the Flight_Master data before inserting new data into Access DB
                    con = DBConnectionString.OpenConnection(AccessConString);
                    transaction = con.BeginTransaction();
                    cmd = new OleDbCommand("DELETE FROM equipment_master", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    con.Close();

                    foreach (DataRow row in dtGetDataFromSql.Rows)
                    {
                        con = DBConnectionString.OpenConnection(AccessConString);
                        transaction = con.BeginTransaction();
                        cmd = new OleDbCommand("INSERT INTO equipment_master (equipment_id, equipment_desc, vehicle_no, chasis_no, engine_no, fuel_capacity, flowmtr_vendor, flowmtr_id, tmpstamp) VALUES(@equipment_id, @equipment_desc, @vehicle_no, @chasis_no, @engine_no, @fuel_capacity, @flowmtr_vendor, @flowmtr_id, @tmpstamp)", con);

                        cmd.Parameters.AddWithValue("@equipment_id", row["equipment_id"].ToString());
                        cmd.Parameters.AddWithValue("@equipment_desc", row["equipment_desc"].ToString());
                        cmd.Parameters.AddWithValue("@vehicle_no", row["vehicle_no"].ToString());
                        cmd.Parameters.AddWithValue("@chasis_no", row["chasis_no"].ToString());
                        cmd.Parameters.AddWithValue("@engine_no", row["engine_no"].ToString());
                        cmd.Parameters.AddWithValue("@fuel_capacity", row["fuel_capacity"].ToString() == string.Empty ? 0 : Convert.ToInt64(row["fuel_capacity"]));
                        cmd.Parameters.AddWithValue("@flowmtr_vendor", row["flowmtr_vendor"].ToString());
                        cmd.Parameters.AddWithValue("@flowmtr_id", row["flowmtr_id"].ToString());
                        cmd.Parameters.AddWithValue("@tmpstamp", row["tmpstamp"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        con.Close();
                    }
                    alertMessage.AppendFormat(Constants.ImportSuccessful, "Equipment Master");
                }
                else
                {
                    alertMessage.AppendFormat(Constants.SqlNoDataFound, "Equipment Master");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
                con.Close();
                transaction.Rollback();
            }
        }
        private void GetSupplierMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT supplier_code, supplier_name FROM supplier_master", SqlConString);

                //Fills the data set with data FROM POS. the SQL database
                dataAdapter.Fill(dtGetDataFromSql);

                if (dtGetDataFromSql.Rows.Count > 0)
                {
                    //Delete the Flight_Master data before inserting new data into Access DB
                    con = DBConnectionString.OpenConnection(AccessConString);
                    transaction = con.BeginTransaction();
                    cmd = new OleDbCommand("DELETE FROM supplier_master", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    con.Close();

                    foreach (DataRow row in dtGetDataFromSql.Rows)
                    {
                        con = DBConnectionString.OpenConnection(AccessConString);
                        transaction = con.BeginTransaction();
                        cmd = new OleDbCommand("INSERT INTO supplier_master (supplier_code, supplier_name) VALUES(@supplier_code, @supplier_name)", con);

                        cmd.Parameters.AddWithValue("@supplier_code", row["supplier_code"].ToString());
                        cmd.Parameters.AddWithValue("@supplier_name", row["supplier_name"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        con.Close();
                    }
                    alertMessage.AppendFormat(Constants.ImportSuccessful, "Supplier Master");
                }
                else
                {
                    alertMessage.AppendFormat(Constants.SqlNoDataFound, "Supplier Master");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
                con.Close();
                transaction.Rollback();
            }
        }
        private void GetAirCraftRegNoMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT airline_code, aircraft_reg_no, turbo_indicator, aircraft_type, registration_country, registration_date, wide_body, off_take_weight, airline_name FROM POS.airline_regno_master", SqlConString);

                //Fills the data set with data FROM POS.POS. the SQL database
                dataAdapter.Fill(dtGetDataFromSql);

                if (dtGetDataFromSql.Rows.Count > 0)
                {
                    //Delete the Flight_Master data before inserting new data into Access DB
                    con = DBConnectionString.OpenConnection(AccessConString);
                    transaction = con.BeginTransaction();
                    cmd = new OleDbCommand("DELETE FROM airline_regno_master", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    con.Close();

                    foreach (DataRow row in dtGetDataFromSql.Rows)
                    {
                        con = DBConnectionString.OpenConnection(AccessConString);
                        transaction = con.BeginTransaction();
                        cmd = new OleDbCommand("INSERT INTO airline_regno_master (airline_code, aircraft_reg_no, turbo_prop, aircraft_type, registration_country, registration_date, wide_body, off_take_weight, airline_name) VALUES(@airline_code, @aircraft_reg_no, @turbo_prop, @aircraft_type, @registration_country, @registration_date, @wide_body, @off_take_weight, @airline_name)", con);

                        cmd.Parameters.AddWithValue("@airline_code", row["airline_code"].ToString());
                        cmd.Parameters.AddWithValue("@aircraft_reg_no", row["aircraft_reg_no"].ToString());
                        cmd.Parameters.AddWithValue("@turbo_prop", row["turbo_prop"].ToString());
                        cmd.Parameters.AddWithValue("@aircraft_type", row["aircraft_type"].ToString());
                        cmd.Parameters.AddWithValue("@registration_country", row["registration_country"].ToString());
                        cmd.Parameters.AddWithValue("@registration_date", row["registration_date"].ToString());
                        cmd.Parameters.AddWithValue("@wide_body", row["wide_body"].ToString());
                        cmd.Parameters.AddWithValue("@off_take_weight", row["off_take_weight"].ToString());
                        cmd.Parameters.AddWithValue("@airline_name", row["airline_name"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        con.Close();
                    }
                    alertMessage.AppendFormat(Constants.ImportSuccessful, "Airline RegNo Master");
                }
                else
                {
                    alertMessage.AppendFormat(Constants.SqlNoDataFound, "Airline RegNo Master");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
                con.Close();
                transaction.Rollback();
            }
        }
        private void GetFlightSchedule()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT loc_code, supplier_code, airline_code, airline_name, flight_id, flight_type, product_type, turbo_flag, bill_to, ship_to, aircraft_type, flight_origin, arriving_from, proceed_to, final_destination, destination_country, estimated_qty, uom, ETA, ETD, approach_time, convert(datetime,from_date), convert(datetime,to_date), frequency, sch_type, convert(datetime,created_on) FROM POS.flight_schedule WHERE to_date >= getdate()", SqlConString);

                //Fills the data set with data FROM POS.the SQL database
                dataAdapter.Fill(dtGetDataFromSql);

                if (dtGetDataFromSql.Rows.Count > 0)
                {
                    //Delete the Flight_Master data before inserting new data into Access DB
                    con = DBConnectionString.OpenConnection(AccessConString);
                    transaction = con.BeginTransaction();
                    cmd = new OleDbCommand("DELETE FROM flight_schedule_new", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    con.Close();

                    foreach (DataRow row in dtGetDataFromSql.Rows)
                    {
                        con = DBConnectionString.OpenConnection(AccessConString);
                        transaction = con.BeginTransaction();
                        cmd = new OleDbCommand("INSERT INTO flight_schedule_new (loc_code, supplier_code, airline_code, airline_name, flight_id, flight_type, product_type, turbo_flag, bill_to, ship_to, aircraft_type, flight_origin, arriving_from, proceed_to, final_destination, destination_country, estimated_qty, uom, ETA, ETD, approach_time, from_date, to_date, frequency, sch_type, created_on) VALUES(@loc_code, @supplier_code, @airline_code, @airline_name, @flight_id, @flight_type, @product_type, @turbo_flag, @bill_to, @ship_to, @aircraft_type, @flight_origin, @arriving_from, @proceed_to, @final_destination, @destination_country, @estimated_qty, @uom, @ETA, @ETD, @approach_time, @from_date, @to_date, @frequency, @sch_type, @created_on)", con);

                        cmd.Parameters.AddWithValue("@loc_code", row["loc_code"].ToString());
                        cmd.Parameters.AddWithValue("@supplier_code", row["supplier_code"].ToString());
                        cmd.Parameters.AddWithValue("@airline_code", row["airline_code"].ToString());
                        cmd.Parameters.AddWithValue("@airline_name", row["airline_name"].ToString());
                        cmd.Parameters.AddWithValue("@flight_id", row["flight_id"].ToString());
                        cmd.Parameters.AddWithValue("@flight_type", row["flight_type"].ToString());
                        cmd.Parameters.AddWithValue("@product_type", row["product_type"].ToString());
                        cmd.Parameters.AddWithValue("@turbo_flag", row["turbo_flag"].ToString());
                        cmd.Parameters.AddWithValue("@bill_to", row["bill_to"].ToString());
                        cmd.Parameters.AddWithValue("@ship_to", row["ship_to"].ToString());
                        cmd.Parameters.AddWithValue("@aircraft_type", row["aircraft_type"].ToString());
                        cmd.Parameters.AddWithValue("@flight_origin", row["flight_origin"].ToString());
                        cmd.Parameters.AddWithValue("@arriving_from", row["arriving_from"].ToString());
                        cmd.Parameters.AddWithValue("@proceed_to", row["proceed_to"].ToString());
                        cmd.Parameters.AddWithValue("@final_destination", row["final_destination"].ToString());
                        cmd.Parameters.AddWithValue("@destination_country", row["destination_country"].ToString());
                        cmd.Parameters.AddWithValue("@estimated_qty", row["estimated_qty"].ToString() == string.Empty ? 0 : Convert.ToDecimal(row["estimated_qty"]));
                        cmd.Parameters.AddWithValue("@uom", row["uom"].ToString());
                        cmd.Parameters.AddWithValue("@ETA", row["ETA"].ToString());
                        cmd.Parameters.AddWithValue("@ETD", row["ETD"].ToString());
                        cmd.Parameters.AddWithValue("@approach_time", row["approach_time"].ToString());
                        cmd.Parameters.AddWithValue("@from_date", row["from_date"].ToString());
                        cmd.Parameters.AddWithValue("@to_date", row["to_date"].ToString());
                        cmd.Parameters.AddWithValue("@frequency", row["frequency"].ToString());
                        cmd.Parameters.AddWithValue("@sch_type", row["sch_type"].ToString());
                        cmd.Parameters.AddWithValue("@created_on", row["created_on"].ToString());

                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        con.Close();
                    }
                    alertMessage.AppendFormat(Constants.ImportSuccessful, "Flight Schedule Master");
                }
                else
                {
                    alertMessage.AppendFormat(Constants.SqlNoDataFound, "Flight Schedule Master");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
                con.Close();
                transaction.Rollback();
            }
        }
        private void GetFuelBatchDetails()
        {
            try
            {
                //dataAdapter = new SqlDataAdapter("SELECT storage_id, density, temp, fuel_batch_no, trans_date FROM POS.density_ref_table WHERE storage_id ='" + FrmLogin.refueller + "'", SqlConString);
                dataAdapter = new SqlDataAdapter("SELECT storage_id, density, temp, fuel_batch_no, trans_date FROM POS.density_ref_table WHERE storage_id ='" + 1234 + "'", SqlConString);

                //Fills the data set with data FROM POS.the SQL database
                dataAdapter.Fill(dtGetDataFromSql);

                if (dtGetDataFromSql.Rows.Count > 0)
                {
                    //Delete the Flight_Master data before inserting new data into Access DB
                    con = DBConnectionString.OpenConnection(AccessConString);
                    transaction = con.BeginTransaction();
                    cmd = new OleDbCommand("DELETE FROM density_ref_table", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    con.Close();

                    foreach (DataRow row in dtGetDataFromSql.Rows)
                    {
                        if (row["fuel_batch_no"].ToString().Length > 96)
                        {
                            row["fuel_batch_no"] = row["fuel_batch_no"].ToString().Substring(row["fuel_batch_no"].ToString().Length - 96, 96);
                        }

                        con = DBConnectionString.OpenConnection(AccessConString);
                        transaction = con.BeginTransaction();
                        cmd = new OleDbCommand("INSERT INTO density_ref_table (storage_id, density, temp, fuel_batch_no, trans_date) VALUES(@storage_id, @density, @temp, @fuel_batch_no, @trans_date)", con);

                        cmd.Parameters.AddWithValue("@storage_id", row["storage_id"].ToString());
                        cmd.Parameters.AddWithValue("@density", row["density"].ToString() == string.Empty ? 0 : Convert.ToDecimal(row["density"]));
                        cmd.Parameters.AddWithValue("@temp", row["temp"].ToString() == string.Empty ? 0 : Convert.ToDecimal(row["temp"]));
                        cmd.Parameters.AddWithValue("@fuel_batch_no", row["fuel_batch_no"].ToString());
                        cmd.Parameters.AddWithValue("@trans_date", row["trans_date"].ToString());
                       
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                        con.Close();
                    }
                    alertMessage.AppendFormat(Constants.ImportSuccessful, "Density Ref Master");
                }
                else
                {
                    alertMessage.AppendFormat(Constants.SqlNoDataFound, "Density Ref Master");
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
                con.Close();
                transaction.Rollback();
            }
        }

        #endregion

        //#region Get SqlDatatAdapter for Supplied Table        
        //private SqlDataAdapter GetSqlDataAdapter(string tableName)
        //{
        //    try
        //    {
        //        if (tableName.Contains("AirlineMaster"))
        //        {
        //            dataAdapter = new SqlDataAdapter("SELECT  invoice_no, airline_name, bill_to, ship_to, flight_id, arriving_from, proceeding_to, aircraft_reg_no, aircraft_type, turbo_prop, duty_paid, bonded, payment_type, equipment_no, qty, meter_start, meter_end, fuel_start, fuel_end, density, temprature, batch_no, bay_no, hydrant_pit_no, Ready_to_fuel, final_clearance, carnetcard_no, issuedby, exp_date, auth_no, auth_date, cash_memo_no, cash_memo_dt, refueller_id, operator, operation, offloading_rcpt, comments, received_by, shift, shift_processed, shift_processed_by, business_day, trans_date, rollover_shift, rollover_day, customer_name, dip_start, dip_end, above40T, flight_type FROM POS." + tableName + " WHERE export_flag = 'N'", SqlConString);
        //        }
        //        else if (tableName.Contains("Flight_schedule"))
        //        {
        //            dataAdapter = new SqlDataAdapter("SELECT flight_id, airline_code, supplier_code, arriving_from, proceeding_to, aircraft_type, estimated_time_arrival, estimated_time_departure, type, turbo_prop, frequency, tmstamp, approach_time, estimated_qty, from_date, to_date, bill_to, ship_to FROM POS." + tableName, SqlConString);
        //        }
        //        else if (tableName.Contains("Location_Master"))
        //        {
        //            dataAdapter = new SqlDataAdapter("SELECT loc_code, loc_name, sap_code, iata_code, loc_address1, loc_address2, city_code, postal_code, tmstamp FROM COM." + tableName, SqlConString);
        //        }
        //        else if (tableName.Contains("Product_master"))
        //        {
        //            dataAdapter = new SqlDataAdapter("SELECT product_code, product_desc, product_remark, tmstamp FROM POS." + tableName, SqlConString);
        //        }
        //        else if (tableName.Contains("Refuller_Master"))
        //        {
        //            dataAdapter = new SqlDataAdapter("SELECT refueller_id , vehicle_no, chasis_no, engine_no, product_code, fuel_qty, fuel_capacity, flowmtr_id, tmstamp FROM POS." + tableName, SqlConString);
        //        }
        //        else if (tableName.Contains("Tank_Master"))
        //        {
        //            dataAdapter = new SqlDataAdapter("SELECT tank_no, tank_desc, product_code , fuel_qty, tank_density, tank_temp, tank_capacity, tmstamp FROM POS." + tableName, SqlConString);
        //        }
        //        else if (tableName.Contains("UserMaster"))
        //        {
        //            dataAdapter = new SqlDataAdapter("SELECT loginName, fullName, password, user_level, address1, address2, address3, address4, res_phone_no, mob_phone_no, emergency_contact, remarks1, remarks2, tmstamp FROM POS." + tableName + " WHERE remarks1='Y'", SqlConString);
        //        }
        //        else if (tableName.Contains("Equipment Master"))
        //        {
        //            dataAdapter = new SqlDataAdapter("SELECT equipment_id, equipment_desc, vehicle_no, chasis_no, engine_no, fuel_capacity, flowmtr_vendor, flowmtr_id, tmstamp FROM POS." + tableName, SqlConString);
        //        }
        //        else if (tableName.Contains("Supplier_Master"))
        //        {
        //            dataAdapter = new SqlDataAdapter("SELECT supplier_code, supplier_name FROM POS." + tableName, SqlConString);
        //        }
        //        else if (tableName.Contains("FuelBatch_Details"))
        //        {
        //            dataAdapter = new SqlDataAdapter("SELECT airline_code, aircraft_reg_no, turbo_indicator, aircraft_type, registration_country, registration_date, wide_body, off_take_weight, airline_name FROM POS." + tableName, SqlConString);
        //        }
        //        else if (tableName.Contains("Airline_regno_master"))
        //        {
        //            dataAdapter = new SqlDataAdapter("SELECT storage_id, density, temp, fuel_batch_no, trans_date FROM POS." + tableName + " WHERE storage_id ='" + 1234 + "'", SqlConString);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logging.ErrorLog(ex);
        //    }

        //    return dataAdapter;
        //}
        //#endregion

        #region Get Master Table list

        public DataTable GetMasterTables()
        {
            List<string> lstTable = new List<string>();
            DataTable dtGetMsterTables = new DataTable("MasterTables");

            try
            {
                dataAdapter = new SqlDataAdapter("SELECT TableName, AliasName FROM POS.tblMasterTables", SqlConString);
                dataAdapter.Fill(dtGetMsterTables);
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }

            return dtGetMsterTables;
        }

        #endregion
    }
}
