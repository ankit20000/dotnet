using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class EUStoBO
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader rd;
        //recordset
        
        string ConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);

        public void ExportFuelTransactionData()
        {
            int cnt = 0;
            int i = 0;

            List<string> StrFiles = new List<string>();

            con = DBConnectionString.OpenConnection(ConString);
            cmd = new OleDbCommand("SELECT loc_code, airline_code, airline_name, bill_to, ship_to, sold_to, bill_to_name, ship_to_name, airline_flag, tmstamp FROM supplier_airline_master UNION SELECT loc_code, airline_code, airline_name, bill_to, ship_to, sold_to, bill_to_name, ship_to_name, airline_flag, tmstamp FROM airline_master WHERE NOT airline_code IS NULL ORDER BY airline_code", con);
            cmd.CommandType = CommandType.Text;
            rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                cnt = rd.FieldCount;

                while (rd.Read())
                {
                    con = DBConnectionString.OpenConnection(ConString);
                    cmd = new OleDbCommand("SELECT loc_code, airline_code, airline_name, bill_to, ship_to, sold_to, bill_to_name, ship_to_name, airline_flag, tmstamp FROM airline_master WHERE airline_code='" + rd[1].ToString() + "' AND airline_name='" + rd[2].ToString() + "'", con);
                    cmd.CommandType = CommandType.Text;
                    rd = cmd.ExecuteReader();

                    if (rd.HasRows)
                    {
                        while (i < cnt)
                        {
                            //       rd.
                            if (i == 17 || i == 18 || i == 24 || i == 25)
                            {
                                //rd[i] = Functions.convert_into_num(Left(db.rst.Fields(I).value, 2), Mid(db.rst.Fields(I).value, 3, 2), Right(db.rst.Fields(I).value, 2))
                            }
                            else if (i == 42 || i == 43)
                            {
                                //boDB.rst.Fields(I) = Format(db.rst.Fields(I), "yyyy/MM/dd")
                            }
                            else if (i == 49)
                            {
                                if (rd[i].ToString() == "Y")
                                { }
                                //boDB.rst.Fields(I) = "71"  ' Off_take_weight
                                else
                                { }
                                // boDB.rst.Fields(I) = "72"  ' Off_take_weight
                            }
                            else
                            { }
                            //boDB.rst.Fields(I) = db.rst.Fields(I)
                            i = i + 1;
                        }
                    }
                    rd.Close();
                }
                //db.esql = "SELECT  invoice_no, airline_name, bill_to, ship_to, flight_id, arriving_from, proceeding_to, aircraft_reg_no, aircraft_type, turbo_prop, duty_paid, bonded, payment_type, equipment_no, qty, meter_start, meter_end, fuel_start, fuel_end, density, temprature, batch_no, bay_no, hydrant_pit_no, Ready_to_fuel, final_clearance, carnetcard_no, issuedby, exp_date, auth_no, auth_date, cash_memo_no, cash_memo_dt, refueller_id, operator, operation, offloading_rcpt, comments, received_by, shift, shift_processed, shift_processed_by, business_day, trans_date, rollover_shift, rollover_day, customer_name, dip_start, dip_end, above40T, flight_type FROM transactions WHERE export_flag = 'N' "
                //db.rst.Open db.esql, db.Conn, adOpenDynamic, adLockOptimistic
            }
        }
    }
}
