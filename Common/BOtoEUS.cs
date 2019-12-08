using system123
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BOtoEUS
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader SqlRd;
        OleDbDataReader AccessRd;
        SqlDataAdapter dataAdapter;
        OleDbDataAdapter oleDbDataAdapter;

        string AccessConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);
        string SqlConString = DBConnectionString.Getconnectionstring(Database.SQLDBConnection);

        public void Main()
        {
            GetMasterData();
        }

        private void GetMasterData()
        {
            GetAirlineMaster();
            GetFlightMaster();
            GetLocationMaster();
            GetProductMaster();
            GetRefuellerMaster();
            GetTankMaster();
            GetUserMaster();
            GetEquipmentMaster();
            GetSupplierMaster();
            GetAirCraftRegNoMaster();
            GetFlightSchedule();
            GetFuelBatchDetails();
            GetConfigDetails();
        }

        // All Master Data functions
        private void GetAirlineMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT  invoice_no, airline_name, bill_to, ship_to, flight_id, arriving_from, proceeding_to, aircraft_reg_no, aircraft_type, turbo_prop, duty_paid, bonded, payment_type, equipment_no, qty, meter_start, meter_end, fuel_start, fuel_end, density, temprature, batch_no, bay_no, hydrant_pit_no, Ready_to_fuel, final_clearance, carnetcard_no, issuedby, exp_date, auth_no, auth_date, cash_memo_no, cash_memo_dt, refueller_id, operator, operation, offloading_rcpt, comments, received_by, shift, shift_processed, shift_processed_by, business_day, trans_date, rollover_shift, rollover_day, customer_name, dip_start, dip_end, above40T, flight_type FROM transactions WHERE export_flag = 'N'", SqlConString);
                //dataAdapter = new SqlDataAdapter("SELECT * FROM COM.tblLocationMasters", SqlConString);

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Table1");

                //Delete the Airline Master data before inserting new data into Access DB
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("DELETE FROM airline_master", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                while (dataSet.Tables.Count > 0)
                {
                    con = DBConnectionString.OpenConnection(AccessConString);
                    //cmd = new OleDbCommand("SELECT loc_code, airline_code, airline_name, bill_to, ship_to, sold_to, bill_to_name, ship_to_name, airline_flag, tmstamp FROM airline_master WHERE airline_code='" + dataSet.Tables[0].Rows[0][1].ToString() + "' AND airline_name='" + dataSet.Tables[0].Rows[0][2].ToString() + "'", con);
                    //cmd.CommandType = CommandType.Text;
                    //AccessRd = cmd.ExecuteReader();

                    if (true)
                    {
                        //This loop fills the database with all information
                        foreach (DataTable table in dataSet.Tables)
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                if (row[8].ToString() == "" || row[8].ToString().ToUpper() == "I")
                                {
                                    row.ItemArray[8] = "D";
                                }

                                String commandText = "INSERT INTO airline_master VALUES (";

                                foreach (var item in row.ItemArray)
                                {
                                    commandText += "'" + item.ToString() + "',";
                                }

                                commandText = commandText.Remove(commandText.Length - 1);
                                commandText += ")";

                                con = DBConnectionString.OpenConnection(AccessConString);
                                cmd = new OleDbCommand(commandText, con);
                                cmd.CommandType = CommandType.Text;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void GetFlightMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT flight_id, airline_code, supplier_code, arriving_from, proceeding_to, aircraft_type, estimated_time_arrival, estimated_time_departure, type, turbo_prop, frequency, tmstamp, approach_time, estimated_qty, from_date, to_date, bill_to, ship_to FROM Flight_Master", SqlConString);

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Table1");

                //Delete the Flight_Master data before inserting new data into Access DB
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("DELETE FROM Flight_Master", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                while (dataSet.Tables.Count > 0)
                {
                    con = DBConnectionString.OpenConnection(AccessConString);
                    cmd = new OleDbCommand("SELECT flight_id, airline_code, supplier_code, arriving_from, proceeding_to, aircraft_type, estimated_time_arrival, estimated_time_departure, type, turbo_prop, frequency, tmstamp, approach_time, estimated_qty, frmdate, todate, bill_to, ship_to FROM Flight_Master WHERE flight_id='" + dataSet.Tables[0].Rows[0][0].ToString() + "'", con);
                    cmd.CommandType = CommandType.Text;
                    AccessRd = cmd.ExecuteReader();

                    //This loop fills the database with all information
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            String commandText = "INSERT INTO Flight_Master VALUES (";

                            foreach (var item in row.ItemArray)
                            {
                                commandText += "'" + item.ToString() + "',";
                            }

                            commandText = commandText.Remove(commandText.Length - 1);
                            commandText += ")";

                            con = DBConnectionString.OpenConnection(AccessConString);
                            cmd = new OleDbCommand(commandText, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void GetLocationMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT loc_code, loc_name, sap_code, iata_code, loc_address1, loc_address2, city_code, postal_code, tmstamp FROM location_master", SqlConString);

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Table1");

                //Delete the Flight_Master data before inserting new data into Access DB
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("DELETE FROM location_master", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                while (dataSet.Tables.Count > 0)
                {
                    con = DBConnectionString.OpenConnection(AccessConString);
                    cmd = new OleDbCommand("SELECT loc_code, loc_name, sap_code, iata_code, loc_address1, loc_address2, city_code, postal_code, tmstamp FROM location_master", con);
                    cmd.CommandType = CommandType.Text;
                    AccessRd = cmd.ExecuteReader();

                    //This loop fills the database with all information
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            String commandText = "INSERT INTO location_master VALUES (";

                            foreach (var item in row.ItemArray)
                            {
                                commandText += "'" + item.ToString() + "',";
                            }

                            commandText = commandText.Remove(commandText.Length - 1);
                            commandText += ")";

                            con = DBConnectionString.OpenConnection(AccessConString);
                            cmd = new OleDbCommand(commandText, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void GetProductMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT product_code, product_desc, product_remark, tmstamp FROM product_master", SqlConString);

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Table1");

                //Delete the Flight_Master data before inserting new data into Access DB
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("DELETE FROM product_master", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                while (dataSet.Tables.Count > 0)
                {
                    con = DBConnectionString.OpenConnection(AccessConString);
                    cmd = new OleDbCommand("SELECT product_code, product_desc, product_remark, tmstamp FROM product_master", con);
                    cmd.CommandType = CommandType.Text;
                    AccessRd = cmd.ExecuteReader();

                    //This loop fills the database with all information
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            String commandText = "INSERT INTO product_master VALUES (";

                            foreach (var item in row.ItemArray)
                            {
                                commandText += "'" + item.ToString() + "',";
                            }

                            commandText = commandText.Remove(commandText.Length - 1);
                            commandText += ")";

                            con = DBConnectionString.OpenConnection(AccessConString);
                            cmd = new OleDbCommand(commandText, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void GetRefuellerMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT refueller_id , vehicle_no, chasis_no, engine_no, product_code, fuel_qty, fuel_capacity, flowmtr_id, tmstamp FROM refueller_master", SqlConString);

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Table1");

                //Delete the Flight_Master data before inserting new data into Access DB
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("DELETE FROM refueller_master", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                while (dataSet.Tables.Count > 0)
                {
                    con = DBConnectionString.OpenConnection(AccessConString);
                    cmd = new OleDbCommand("SELECT refueller_id , vehicle_no, chasis_no, engine_no, product_code, fuel_qty, fuel_capacity, flowmtr_id, tmstamp FROM refueller_master WHERE refueller_id='" + dataSet.Tables[0].Rows[0][0].ToString() + "'", con);
                    cmd.CommandType = CommandType.Text;
                    AccessRd = cmd.ExecuteReader();

                    //This loop fills the database with all information
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            String commandText = "INSERT INTO refueller_master VALUES (";

                            foreach (var item in row.ItemArray)
                            {
                                commandText += "'" + item.ToString() + "',";
                            }

                            commandText = commandText.Remove(commandText.Length - 1);
                            commandText += ")";

                            con = DBConnectionString.OpenConnection(AccessConString);
                            cmd = new OleDbCommand(commandText, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void GetTankMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT tank_no, tank_desc, product_code , fuel_qty, tank_density, tank_temp, tank_capacity, tmstamp FROM tank_master", SqlConString);

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Table1");

                //Delete the Flight_Master data before inserting new data into Access DB
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("DELETE FROM tank_master", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                while (dataSet.Tables.Count > 0)
                {
                    con = DBConnectionString.OpenConnection(AccessConString);
                    cmd = new OleDbCommand("SELECT tank_no, tank_desc, product_code, fuel_qty, tank_density, tank_temp, tank_capacity, tmstamp  from tank_master where tank_no = '" + dataSet.Tables[0].Rows[0][0] + "'", con);
                    cmd.CommandType = CommandType.Text;
                    AccessRd = cmd.ExecuteReader();

                    //This loop fills the database with all information
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            String commandText = "INSERT INTO tank_master VALUES (";

                            foreach (var item in row.ItemArray)
                            {
                                commandText += "'" + item.ToString() + "',";
                            }

                            commandText = commandText.Remove(commandText.Length - 1);
                            commandText += ")";

                            con = DBConnectionString.OpenConnection(AccessConString);
                            cmd = new OleDbCommand(commandText, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void GetUserMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT loginName, fullName, password, user_level, address1, address2, address3, address4, res_phone_no, mob_phone_no, emergency_contact, remarks1, remarks2, tmstamp FROM user_master WHERE remarks1='Y'", SqlConString);

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Table1");

                //Delete the Flight_Master data before inserting new data into Access DB
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("DELETE FROM user_master", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                while (dataSet.Tables.Count > 0)
                {
                    con = DBConnectionString.OpenConnection(AccessConString);
                    cmd = new OleDbCommand("SELECT loginName, fullName, password, user_level, address1, address2, address3, address4, res_phone_no, mob_phone_no, emergency_contact, remarks1, remarks2, tmstamp FROM user_master WHERE loginName='" + dataSet.Tables[0].Rows[0][0] + "'", con);
                    cmd.CommandType = CommandType.Text;
                    AccessRd = cmd.ExecuteReader();

                    //This loop fills the database with all information
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            String commandText = "INSERT INTO user_master VALUES (";

                            foreach (var item in row.ItemArray)
                            {
                                commandText += "'" + item.ToString() + "',";
                            }

                            commandText = commandText.Remove(commandText.Length - 1);
                            commandText += ")";

                            con = DBConnectionString.OpenConnection(AccessConString);
                            cmd = new OleDbCommand(commandText, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void GetEquipmentMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT equipment_id, equipment_desc, vehicle_no, chasis_no, engine_no, fuel_capacity, flowmtr_vendor, flowmtr_id, tmstamp FROM equipment_master", SqlConString);

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Table1");

                //Delete the Flight_Master data before inserting new data into Access DB
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("DELETE FROM equipment_master", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                while (dataSet.Tables.Count > 0)
                {
                    con = DBConnectionString.OpenConnection(AccessConString);
                    cmd = new OleDbCommand("SELECT equipment_id, equipment_desc, vehicle_no, chasis_no, engine_no, fuel_capacity, flowmtr_vendor, flowmtr_id, tmpstamp FROM equipment_master WHERE equipment_id='" + dataSet.Tables[0].Rows[0][0] + "'", con);
                    cmd.CommandType = CommandType.Text;
                    AccessRd = cmd.ExecuteReader();

                    //This loop fills the database with all information
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            String commandText = "INSERT INTO equipment_master VALUES (";

                            foreach (var item in row.ItemArray)
                            {
                                commandText += "'" + item.ToString() + "',";
                            }

                            commandText = commandText.Remove(commandText.Length - 1);
                            commandText += ")";

                            con = DBConnectionString.OpenConnection(AccessConString);
                            cmd = new OleDbCommand(commandText, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void GetSupplierMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT supplier_code, supplier_name FROM supplier_master", SqlConString);

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Table1");

                //Delete the Flight_Master data before inserting new data into Access DB
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("DELETE FROM supplier_master", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                while (dataSet.Tables.Count > 0)
                {
                    con = DBConnectionString.OpenConnection(AccessConString);
                    cmd = new OleDbCommand("SELECT supplier_code, supplier_name FROM supplier_master WHERE supplier_code='" + dataSet.Tables[0].Rows[0][0] + "'", con);
                    cmd.CommandType = CommandType.Text;
                    AccessRd = cmd.ExecuteReader();

                    //This loop fills the database with all information
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            String commandText = "INSERT INTO supplier_master VALUES (";

                            foreach (var item in row.ItemArray)
                            {
                                commandText += "'" + item.ToString() + "',";
                            }

                            commandText = commandText.Remove(commandText.Length - 1);
                            commandText += ")";

                            con = DBConnectionString.OpenConnection(AccessConString);
                            cmd = new OleDbCommand(commandText, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void GetAirCraftRegNoMaster()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT airline_code, aircraft_reg_no, turbo_indicator, aircraft_type, registration_country, registration_date, wide_body, off_take_weight, airline_name FROM airline_regno_master", SqlConString);

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Table1");

                //Delete the Flight_Master data before inserting new data into Access DB
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("DELETE FROM airline_regno_master", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                while (dataSet.Tables.Count > 0)
                {
                    con = DBConnectionString.OpenConnection(AccessConString);
                    cmd = new OleDbCommand("SELECT airline_code, aircraft_reg_no, turbo_prop, aircraft_type, registration_country, registration_date, wide_body, off_take_weight, airline_name FROM airline_regno_master WHERE airline_code='" + dataSet.Tables[0].Rows[0][0] + "'AND aircraft_reg_no ='" + dataSet.Tables[0].Rows[0][1] + "'", con);
                    cmd.CommandType = CommandType.Text;
                    AccessRd = cmd.ExecuteReader();

                    //This loop fills the database with all information
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            if (row[7].ToString() == "72")
                            {
                                row.ItemArray[7] = "Y";
                            }
                            else
                            {
                                row.ItemArray[7] = "N";
                            }

                            String commandText = "INSERT INTO airline_regno_master VALUES (";

                            foreach (var item in row.ItemArray)
                            {
                                commandText += "'" + item.ToString() + "',";
                            }

                            commandText = commandText.Remove(commandText.Length - 1);
                            commandText += ")";

                            con = DBConnectionString.OpenConnection(AccessConString);
                            cmd = new OleDbCommand(commandText, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void GetFlightSchedule()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT loc_code, supplier_code, airline_code, airline_name, flight_id, flight_type, product_type, turbo_flag, bill_to, ship_to, aircraft_type, flight_origin, arriving_from, proceed_to, final_destination, destination_country, estimated_qty, uom, ETA, ETD, approach_time, convert(datetime,from_date), convert(datetime,to_date), frequency, sch_type, convert(datetime,created_on) FROM flight_schedule_new WHERE to_date >= getdate()", SqlConString);

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Table1");

                //Delete the Flight_Master data before inserting new data into Access DB
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("DELETE FROM flight_schedule_new", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                while (dataSet.Tables.Count > 0)
                {
                    con = DBConnectionString.OpenConnection(AccessConString);
                    cmd = new OleDbCommand("SELECT loc_code, supplier_code, airline_code, airline_name, flight_id, flight_type, product_type, turbo_flag, bill_to, ship_to, aircraft_type, flight_origin, arriving_from, proceed_to, final_destination, destination_country, estimated_qty, uom, ETA, ETD, approach_time, from_date, to_date, frequency, sch_type, created_on FROM flight_schedule_new WHERE supplier_code='" + dataSet.Tables[0].Rows[0][1] + "' AND airline_code ='" + dataSet.Tables[0].Rows[0][2] + "' and flight_id='" + dataSet.Tables[0].Rows[0][4] + "'", con);
                    cmd.CommandType = CommandType.Text;
                    AccessRd = cmd.ExecuteReader();

                    //This loop fills the database with all information
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            String commandText = "INSERT INTO flight_schedule_new VALUES (";

                            foreach (var item in row.ItemArray)
                            {
                                commandText += "'" + item.ToString() + "',";
                            }

                            commandText = commandText.Remove(commandText.Length - 1);
                            commandText += ")";

                            con = DBConnectionString.OpenConnection(AccessConString);
                            cmd = new OleDbCommand(commandText, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void GetFuelBatchDetails()
        {
            try
            {
                //dataAdapter = new SqlDataAdapter("SELECT storage_id, density, temp, fuel_batch_no, trans_date FROM density_ref_table WHERE storage_id ='" + FrmLogin.refueller + "'", SqlConString);
                dataAdapter = new SqlDataAdapter("SELECT storage_id, density, temp, fuel_batch_no, trans_date FROM density_ref_table WHERE storage_id ='" + 1234 + "'", SqlConString);

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Table1");

                //Delete the Flight_Master data before inserting new data into Access DB
                con = DBConnectionString.OpenConnection(AccessConString);
                cmd = new OleDbCommand("DELETE FROM density_ref_table", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                while (dataSet.Tables.Count > 0)
                {
                    con = DBConnectionString.OpenConnection(AccessConString);
                    cmd = new OleDbCommand("SELECT storage_id, density, temp, fuel_batch_no, trans_date FROM density_ref_table WHERE storage_id='" + dataSet.Tables[0].Rows[0][0] + "'", con);
                    cmd.CommandType = CommandType.Text;
                    AccessRd = cmd.ExecuteReader();

                    //This loop fills the database with all information
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            if (row[3].ToString().Length > 96 || row[8].ToString().ToUpper() == "I")
                            {
                                //row.ItemArray[3] = row[3].ToString().PadRight(row[3].ToString().Length,96);
                            }

                            String commandText = "INSERT INTO density_ref_table VALUES (";

                            foreach (var item in row.ItemArray)
                            {
                                commandText += "'" + item.ToString() + "',";
                            }

                            commandText = commandText.Remove(commandText.Length - 1);
                            commandText += ")";

                            con = DBConnectionString.OpenConnection(AccessConString);
                            cmd = new OleDbCommand(commandText, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        private void GetConfigDetails()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT fids_Conf,(SELECT  max(sno) FROM itp_shift_master) FROM configuration", SqlConString);

                //Fills the data set with data from the SQL database
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Table1");

                ////Delete the Flight_Master data before inserting new data into Access DB
                //con = DBConnectionString.OpenConnection(AccessConString);
                //cmd = new OleDbCommand("DELETE FROM flight_schedule_new", con);
                //cmd.CommandType = CommandType.Text;
                //cmd.ExecuteNonQuery();

                while (dataSet.Tables.Count > 0)
                {
                    con = DBConnectionString.OpenConnection(AccessConString);
                    cmd = new OleDbCommand("SELECT remark3, remark4 FROM Configuration", con);
                    cmd.CommandType = CommandType.Text;
                    AccessRd = cmd.ExecuteReader();

                    //This loop fills the database with all information
                    foreach (DataTable table in dataSet.Tables)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            if (row[0].ToString().Trim() ==  "")
                            {
                                row.ItemArray[0] = "N";
                            }
                            if (row[1].ToString().Trim() == "" || row[1].ToString().Trim() == "0")
                            {
                                row.ItemArray[1] = "1";
                            }

                            String commandText = "INSERT INTO Configuration VALUES (";

                            foreach (var item in row.ItemArray)
                            {
                                commandText += "'" + item.ToString() + "',";
                            }

                            commandText = commandText.Remove(commandText.Length - 1);
                            commandText += ")";

                            con = DBConnectionString.OpenConnection(AccessConString);
                            cmd = new OleDbCommand(commandText, con);
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
    }
}
