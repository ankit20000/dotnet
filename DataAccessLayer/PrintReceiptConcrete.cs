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
using System.Windows.Forms;

namespace DataAccessLayer
{
    public class PrintReceiptConcrete : IPrintReceipt
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader rd, rd1, rd2;
        DataSet ds;
        OleDbDataAdapter adp;
        string ConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);

        string str = "", word = "";
        public void PrintCirculationLC(StockTransfer stockTransfer)
        {
            str = string.Empty;
            PrinterLC("     Reliance Industries Ltd.    ");
            PrinterLC("     CIRCULATION TEST RECEIPT    ");
            PrinterLC("=================================");
            PrinterLC(" ");
            str = "Sr.No :" + stockTransfer.bill_no;
            PrinterLC(str);
            str = "DATE :" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            PrinterLC(str);
            PrinterLC(" ");
            str = "Reason   :" + stockTransfer.comments;
            PrinterLC(str);
            PrinterLC(" ");
            str = "EQUIPMENT ID.        : " + stockTransfer.equipment_no;
            PrinterLC(str);
            str = "FUEL START TIME:" + stockTransfer.MeterStartTime;
            PrinterLC(str);
            str = "FUEL END TIME  :" + stockTransfer.MeterEndTime;
            PrinterLC(str);
            str = "METER START  READING :" + stockTransfer.meter_start;
            PrinterLC(str);
            str = "METER END READING    :" + stockTransfer.meter_end;
            PrinterLC(str);
            str = "DIFFERENCE           :" + stockTransfer.Qty;
            PrinterLC(str);
            PrinterLC(" ");
            PrinterLC("=================================");
            str = "TOTAL QTY CIR. IN LTRS :" + stockTransfer.Qty;
            PrinterLC(str);
            PrinterLC("=================================");
            PrinterLC(" ");
            PrinterLC("DELIVERED BY-       RECEIVED BY-");
            str = "   (" + stockTransfer.source + ")" + "              (" + stockTransfer.source + ")";
            PrinterLC(str);
            PrinterLC(" ");
            PrinterLC(" ");
            PrinterLC("SIGNATURE            SIGNATURE");
            string OperatorName = GetOperatorName(stockTransfer.operators);
            str = "(" + OperatorName + ")               (" + OperatorName + ")";
            PrinterLC(str);
            PrinterLC("_________________________________");
        }

        public void PrintCirculationISOIL(StockTransfer stockTransfer)
        {
            str = string.Empty;
            PrinterLC("     Reliance Industries Ltd.    ");
            PrinterLC("     CIRCULATION TEST RECEIPT    ");
            PrinterLC("=================================");
            PrinterLC(" ");
            str = "Sr.No :" + stockTransfer.bill_no;
            PrinterLC(str);
            str = "DATE :" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            PrinterLC(str);
            PrinterLC(" ");
            str = "Reason   :" + stockTransfer.comments;
            PrinterLC(str);
            PrinterLC(" ");
            str = "EQUIPMENT ID.        : " + stockTransfer.equipment_no;
            PrinterLC(str);
            str = "FUEL START TIME:" + stockTransfer.MeterStartTime;
            PrinterLC(str);
            str = "FUEL END TIME  :" + stockTransfer.MeterEndTime;
            PrinterLC(str);
            str = "METER START  READING :" + stockTransfer.meter_start;
            PrinterLC(str);
            str = "METER END READING    :" + stockTransfer.meter_end;
            PrinterLC(str);
            str = "DIFFERENCE           :" + stockTransfer.Qty;
            PrinterLC(str);
            PrinterLC(" ");
            PrinterLC("=================================");
            str = "TOTAL QTY CIR. IN LTRS :" + stockTransfer.Qty;
            PrinterLC(str);
            PrinterLC("=================================");
            PrinterLC(" ");
            PrinterLC("DELIVERED BY-       RECEIVED BY-");
            str = "   (" + stockTransfer.source + ")" + "              (" + stockTransfer.source + ")";
            PrinterLC(str);
            PrinterLC(" ");
            PrinterLC(" ");
            PrinterLC("SIGNATURE            SIGNATURE");
            string OperatorName = GetOperatorName(stockTransfer.operators);
            str = "(" + OperatorName + ")               (" + OperatorName + ")";
            PrinterLC(str);
            PrinterLC("_________________________________");
        }
        public void PrintStockTransferLC(StockTransfer stockTransfer)
        {
            str = string.Empty;
            PrinterLC("     Reliance Industries Ltd.    ");
            PrinterLC("     STOCK TRANSFER RECEIPT    ");
            if (GlobalVariable.StockTransferType == Constants.RefuellerToRefueller)
            {
                PrinterLC("    ( REFUELLER to REFUELLER )   ");
            }
            else if (GlobalVariable.StockTransferType == Constants.RefuellerToTank)
            {
                PrinterLC("      ( REFUELLER to TANK )    ");
            }
            PrinterLC("=================================");
            PrinterLC(" ");
            str = "Sr.No :" + stockTransfer.bill_no;
            PrinterLC(str);
            str = "DATE :" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            PrinterLC(str);
            PrinterLC(" ");
            if (GlobalVariable.StockTransferType == Constants.RefuellerToRefueller)
            {
                str = "DESTINATION REFUELLER :" + stockTransfer.destination;
            }
            else if (GlobalVariable.StockTransferType == Constants.RefuellerToTank)
            {
                str = "DESTINATION TANK      :" + stockTransfer.destination;
            }
            PrinterLC(str);
            str = "QTY TRANSFERED   :" + stockTransfer.Qty;
            PrinterLC(str);
            str = "DENSITY          :" + stockTransfer.density;
            PrinterLC(str);
            str = "TEMPERATURE      :" + stockTransfer.temperature;
            PrinterLC(str);
            str = "FUEL BATCH NO    :" + stockTransfer.fuel_batch_no;
            PrinterLC(str);
            PrinterLC(" ");
            str = "EQUIPMENT ID.        : " + stockTransfer.source;
            PrinterLC(str);
            str = "METER ID.            : " + stockTransfer.equipment_no;
            PrinterLC(str);
            str = "FUEL START TIME:" + stockTransfer.MeterStartTime;
            PrinterLC(str);
            str = "FUEL END TIME  :" + stockTransfer.MeterEndTime;
            PrinterLC(str);
            str = "METER START  READING :" + stockTransfer.meter_start;
            PrinterLC(str);
            str = "METER END READING    :" + stockTransfer.meter_end;
            PrinterLC(str);
            str = "DIFFERENCE           :" + stockTransfer.Qty;
            PrinterLC(str);
            PrinterLC(" ");
            PrinterLC("=================================");
            str = "   TOTAL TR. QTY IN LTRS :" + stockTransfer.Qty;
            PrinterLC(str);
            PrinterLC("=================================");
            PrinterLC(" ");
            PrinterLC("DELIVERED BY-       RECEIVED BY-");
            str = "   (" + stockTransfer.source + ")             (" + stockTransfer.destination + ")";
            PrinterLC(str);
            PrinterLC(" ");
            PrinterLC(" ");
            PrinterLC("SIGNATURE            SIGNATURE");
            string OperatorName = GetOperatorName(stockTransfer.operators);
            str = "(" + OperatorName + ")";
            PrinterLC(str);
            PrinterLC("_________________________________");
        }

        public void PrintStockTransferISOIL(StockTransfer stockTransfer)
        {
            str = string.Empty;
            PrinterLC("     Reliance Industries Ltd.    ");
            PrinterLC("     STOCK TRANSFER RECEIPT    ");
            if (GlobalVariable.StockTransferType == Constants.RefuellerToRefueller)
            {
                PrinterLC("    ( REFUELLER to REFUELLER )   ");
            }
            else if (GlobalVariable.StockTransferType == Constants.RefuellerToTank)
            {
                PrinterLC("      ( REFUELLER to TANK )    ");
            }
            PrinterLC("=================================");
            PrinterLC(" ");
            str = "Sr.No :" + stockTransfer.bill_no;
            PrinterLC(str);
            str = "DATE :" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            PrinterLC(str);
            PrinterLC(" ");
            if (GlobalVariable.StockTransferType == Constants.RefuellerToRefueller)
            {
                str = "DESTINATION REFUELLER :" + stockTransfer.destination;
            }
            else if (GlobalVariable.StockTransferType == Constants.RefuellerToTank)
            {
                str = "DESTINATION TANK      :" + stockTransfer.destination;
            }
            PrinterLC(str);
            str = "QTY TRANSFERED   :" + stockTransfer.Qty;
            PrinterLC(str);
            str = "DENSITY          :" + stockTransfer.density;
            PrinterLC(str);
            str = "TEMPERATURE      :" + stockTransfer.temperature;
            PrinterLC(str);
            str = "FUEL BATCH NO    :" + stockTransfer.fuel_batch_no;
            PrinterLC(str);
            PrinterLC(" ");
            str = "EQUIPMENT ID.        : " + stockTransfer.source;
            PrinterLC(str);
            str = "METER ID.            : " + stockTransfer.equipment_no;
            PrinterLC(str);
            str = "FUEL START TIME:" + stockTransfer.MeterStartTime;
            PrinterLC(str);
            str = "FUEL END TIME  :" + stockTransfer.MeterEndTime;
            PrinterLC(str);
            str = "METER START  READING :" + stockTransfer.meter_start;
            PrinterLC(str);
            str = "METER END READING    :" + stockTransfer.meter_end;
            PrinterLC(str);
            str = "DIFFERENCE           :" + stockTransfer.Qty;
            PrinterLC(str);
            PrinterLC(" ");
            PrinterLC("=================================");
            str = "   TOTAL TR. QTY IN LTRS :" + stockTransfer.Qty;
            PrinterLC(str);
            PrinterLC("=================================");
            PrinterLC(" ");
            PrinterLC("DELIVERED BY-       RECEIVED BY-");
            str = "   (" + stockTransfer.source + ")             (" + stockTransfer.destination + ")";
            PrinterLC(str);
            PrinterLC(" ");
            PrinterLC(" ");
            PrinterLC("SIGNATURE            SIGNATURE");
            string OperatorName = GetOperatorName(stockTransfer.operators);
            str = "(" + OperatorName + ")";
            PrinterLC(str);
            PrinterLC("_________________________________");
        }

        private string GetOperatorName(string operators)
        {
            string opername = string.Empty;
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("SELECT fullname FROM user_master WHERE loginName= @loginName", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@loginName", operators);
                rd = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (rd.HasRows)
                {
                    if (rd.Read())
                    {
                        opername = rd["fullname"].ToString();
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
            return opername;
        }

        public void PrintOutLC(Transactions transactions)
        {
            try
            {
                word = word + " ^";
                word = word + " ^";
                word = word + " ^";
                word = word + " ^";
                word = word + " ^";
                word = word + " ^";
                word = word + " ^";
                PrinterLC("");
                PrinterLC("");
                str = transactions.invoice_no;
                PrinterLC(str);
                word = word + " ^";
                word = word + " " + str + " ";
                str = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                PrinterLC(str);
                word = word + " ^";
                word = word + " " + str + " ";

                if (transactions.airline_name.Length > 32)
                    str = transactions.airline_name.Substring(0, 31);
                else
                    str = transactions.airline_name;
                PrinterLC(str);
                word = word + " ^";
                word = word + " " + str + " ";
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        public void PrintOutISOIL(Transactions transactions)
        {

        }

        public void PrintReportLC(string invoiceno)
        {
            string supp_code, str1,loccode="";
            try
            {
                PrinterLC("");
                PrinterLC("");
                PrinterLC("");
                PrinterLC("");
                PrinterLC(invoiceno);
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("SELECT * FROM transactions WHERE invoice_no=@invoice_no", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@invoice_no", invoiceno);
                rd = cmd.ExecuteReader(CommandBehavior.SingleRow);
                while (rd.Read())
                {
                    str = string.IsNullOrEmpty(rd[43].ToString()) ? " " : rd[43].ToString();                     // Transaction Date
                    PrinterLC(str);

                    str = (rd[1].ToString().Length > 32) ? rd[1].ToString().Substring(0, 32) : rd[1].ToString(); // Customer Name  
                    PrinterLC(str);

                    if (rd[35].ToString().ToUpper() == "DE-FUELLING")                                            // BILL TO
                        str = "DEFUELLING";
                    else
                    {
                        supp_code = string.IsNullOrEmpty(rd[46].ToString()) ? "RIL" : rd[46].ToString();
                        if (supp_code == "RIL")
                        {
                            str = (rd[1].ToString().Length > 32) ? rd[1].ToString().Substring(0, 32) : rd[1].ToString();  //Airline Name
                        }
                        else
                        {
                            cmd = new OleDbCommand("SELECT distinct supplier_name FROM supplier_master WHERE supplier_code = '" + supp_code + "'", con);
                            cmd.CommandType = CommandType.Text;
                            object SuppName = cmd.ExecuteScalar();
                            if (string.IsNullOrEmpty(SuppName.ToString()))
                            {
                                str = (supp_code.Length > 32) ? supp_code.Substring(0, 32) : supp_code;
                            }
                            else
                            {
                                str = (SuppName.ToString().Length > 32) ? SuppName.ToString().Substring(0, 32) : SuppName.ToString();
                            }
                        }
                    }
                    PrinterLC(str);
                    cmd = new OleDbCommand("select * from location_master", con);
                    cmd.CommandType = CommandType.Text;
                    rd1 = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (rd1.HasRows)
                    {
                        if (rd1.Read())
                        {
                            loccode= rd[0].ToString();
                            str = rd[1].ToString();                                         // Location Name / Airfield
                            PrinterLC(str);
                        }
                    }
                    else
                    {                        
                        MessageBox.Show("No Location details available ..... Please update Location Details");
                        PrinterLC(" ");
                    }
                    rd1.Close();

                    cmd = new OleDbCommand("select * from Configuration", con);
                    cmd.CommandType = CommandType.Text;
                    rd2 = cmd.ExecuteReader();
                    if (rd2.HasRows)
                    {
                        while (rd2.Read())
                        {
                            str = rd2[4].ToString();                                        // DGCA Approval Code
                            PrinterLC(str);
                            str = rd2[5].ToString();                                        // IATA CODE
                            PrinterLC(str);
                        }
                    }
                    else
                    {                       
                        MessageBox.Show("Site Configuration details not available ..... Please configure");
                        PrinterLC(" ");
                        PrinterLC(" ");
                    }
                    rd2.Close();
                    if (string.IsNullOrEmpty(loccode))
                    {
                        MessageBox.Show("Location code not available ..... Please update Location Details");
                        PrinterLC(" ");
                    }
                    else                                                                     // Location Code
                        PrinterLC(loccode);
                    
                    str = string.IsNullOrEmpty(rd[4].ToString()) ? " " : rd[4].ToString();    // Flight No. #
                    PrinterLC(str);
                    str = string.IsNullOrEmpty(rd[7].ToString()) ? " " : rd[7].ToString();    // AIRCRAFT REG.No
                    PrinterLC(str);
                    str = string.IsNullOrEmpty(rd[5].ToString()) ? " " : rd[5].ToString();    // ARRIVED FROM
                    PrinterLC(str);
                    str = string.IsNullOrEmpty(rd[6].ToString()) ? " " : rd[6].ToString();    // PROCEEDING TO
                    PrinterLC(str);

                    if (string.IsNullOrEmpty(rd[36].ToString()))                              // OFF LOADING RECEIPT (Defuelling)    
                        PrinterLC("NO UPLIFT");
                    else if (rd[36].ToString() == "Y")
                        PrinterLC("YES");
                    else
                        PrinterLC("NO");

                    str = rd[8].ToString();                                                  // AIRCRAFT TYPE & TURBO PROP
                    if (rd[9].ToString() == "Y")                                             
                        str = str + "                 " + "YES";
                    else if (rd[9].ToString() == "N")
                        str = str + "                 " + "NO";
                    PrinterLC(str);

                    if (string.IsNullOrEmpty(rd[22].ToString()))                            // BAY NO & HYDRANT PIT NO
                        str = " ";
                    else
                        str = rd[22].ToString();
                    if (string.IsNullOrEmpty(rd[23].ToString()))                              
                        str = str + "                         ";
                    else
                        str = str + "                         " + rd[23].ToString();
                    PrinterLC(str);

                    str = rd[10].ToString() == "Y" ? "YES" : "NO";                        // DUTY PAID & BONDED
                    if (rd[11].ToString() == "Y")                                            
                        str = str + "                   " + "YES";
                    else
                        str = str + "                   " + "NO";
                    PrinterLC(str);

                    PrinterLC(" ");                                                      // Cash Details                           
                    PrinterLC(" ");
                    PrinterLC(" ");
                    PrinterLC(" ");
                    PrinterLC(" ");
                    PrinterLC(" ");
                    PrinterLC(" ");

                    str1 = rd[43].ToString();                                            // READY TO FUEL
                    if (string.IsNullOrEmpty(rd[24].ToString()))
                        PrinterLC(" ");
                    else
                    {
                        str = rd[24].ToString().Substring(0, 2) + ":" + rd[24].ToString().Substring(2, 2) + ":" + rd[24].ToString().Substring(4, 2);
                        str = str1 + " " + str;
                        PrinterLC(str);
                    }

                    if (string.IsNullOrEmpty(rd[17].ToString()))                        // FUEL START TIME 
                        PrinterLC(" ");
                    else
                    {
                        str = rd[17].ToString().Substring(0, 2) + ":" + rd[17].ToString().Substring(2, 2) + ":" + rd[17].ToString().Substring(4, 2);
                        str = str1 + " " + str;
                        PrinterLC(str);
                    }

                    if (string.IsNullOrEmpty(rd[18].ToString()))                        // FUEL END TIME 
                        PrinterLC(" ");
                    else
                    {
                        str = rd[18].ToString().Substring(0, 2) + ":" + rd[18].ToString().Substring(2, 2) + ":" + rd[18].ToString().Substring(4, 2);
                        str = str1 + " " + str;
                        PrinterLC(str);
                    }

                    if (string.IsNullOrEmpty(rd[25].ToString()))                        // FINAL CLEARANCE 
                        PrinterLC(" ");
                    else
                    {
                        str = rd[25].ToString().Substring(0, 2) + ":" + rd[25].ToString().Substring(2, 2) + ":" + rd[25].ToString().Substring(4, 2);
                        str = str1 + " " + str;
                        PrinterLC(str);
                    }

                    PrinterLC(" ");                    
                                           
                    str= string.IsNullOrEmpty(rd[33].ToString()) ? " " : rd[33].ToString();  // REFUELLER ID.                              
                    PrinterLC(str);

                    str = string.IsNullOrEmpty(rd[13].ToString()) ? " " : rd[13].ToString();  // METER ID.                              
                    PrinterLC(str);
                    
                    PrinterLC(" ");
                    if (rd[35].ToString().ToUpper() == "DE-FUELLING")
                    {
                        str = "     /DIP     " + rd[48].ToString();                    // Closing dip reading  
                        PrinterLC(str);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(rd[16].ToString()))                   // CLOSING METER READING
                            PrinterLC(" ");
                        else
                        {
                            str = "               " + rd[16].ToString();
                            PrinterLC(str);
                        }
                    }
                    PrinterLC(" ");

                    if (rd[35].ToString().ToUpper() == "DE-FUELLING")
                    {
                        str = "     /DIP     " + rd[47].ToString();                     // Openning METER READING
                        PrinterLC(str);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(rd[15].ToString()))                    
                            PrinterLC(" ");
                        else
                        {
                            str = "               " + rd[15].ToString();
                            PrinterLC(str);
                        }
                    }
                    PrinterLC(" ");
                    
                    if (string.IsNullOrEmpty(rd[14].ToString()))                        // DIFFERENCE
                        PrinterLC(" ");
                    else
                    {
                        str = "               " + rd[14].ToString();
                        PrinterLC(str);
                    }
                    PrinterLC(" ");

                    if (string.IsNullOrEmpty(rd[14].ToString()))                        // TOTAL DELIVERY IN LITRES
                        PrinterLC(" ");
                    else
                    {
                        str = "               " + rd[14].ToString();
                        PrinterLC(str);
                    }

                    if (rd[35].ToString() == "DE-FUELLING")                            // BATCH NUMBER 
                    {
                        PrinterLC("DEFUELLED");
                        PrinterLC(" ");
                        PrinterLC(" ");
                        PrinterLC(" ");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(rd[21].ToString()))
                        {
                            PrinterLC(" ");
                            PrinterLC(" ");
                            PrinterLC(" ");
                            PrinterLC(" ");
                        }
                        else
                        {
                            if(rd[21].ToString().Length>32)
                            {
                                if(rd[21].ToString().Length > 64)
                                {
                                    str = rd[21].ToString().Substring(0, 32);
                                    PrinterLC(str);
                                    str = rd[21].ToString().Substring(32,32);
                                    PrinterLC(str);
                                    str = rd[21].ToString().Substring(64, rd[21].ToString().Length);
                                    PrinterLC(str);
                                    PrinterLC(" ");
                                }
                                else
                                {
                                    str = rd[21].ToString().Substring(0, 32);
                                    PrinterLC(str);
                                    str = rd[21].ToString().Substring(32, rd[21].ToString().Length);
                                    PrinterLC(str);
                                    PrinterLC(" ");
                                    PrinterLC(" ");
                                }
                            }
                            else
                            {
                                PrinterLC(rd[21].ToString().Trim());
                                PrinterLC(" ");
                                PrinterLC(" ");
                                PrinterLC(" ");
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(rd[19].ToString()))                                // Density and Temperature  
                        str = " ";
                    else
                        str = rd[19].ToString();
                    if (string.IsNullOrEmpty(rd[20].ToString()))
                        str = str + "                      ";
                    else
                        str = str + "                      " + rd[20].ToString();
                    PrinterLC(str);

                    PrinterLC(" ");
                    PrinterLC(" ");
                    PrinterLC(" ");

                    str = GetOperatorName(rd[34].ToString());                             // operator name
                    if (str.Length > 10)
                        str = str.Substring(0, 10);
                    PrinterLC(" ");
                    PrinterLC(str);
                    PrinterLC(" ");
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        /// <summary>
        /// This method is used to print the input string
        /// </summary>
        /// <param name="str">Input string for printing</param>
        public void PrinterLC(string str)
        {
            byte devStatus = 0, result;
            long prnlen = 0;
            int LF = 13, CR = 10;
            byte[] prnText = new byte[LCMeterLibrary.MAX_PRN_BUFFER];
            try
            {
                LCRStatus status = new LCRStatus();
                status.DeliveryCode = 0;
                status.DeliveryStatus = 0;
                status.PrinterStatus = 0;

                str = str + (char)LF + (char)CR;
                prnlen = str.Length;
                if (prnlen <= LCMeterLibrary.MAX_PRN_BUFFER)
                {
                    prnText = Encoding.ASCII.GetBytes(str);
                    do
                    {
                        result = LCMeterLibrary.LCP02MustGetStatus(Constants.device, ref status, ref devStatus, Constants.delaypointer, Constants.delaypointer);
                    }
                    while (result == 0 && status.PrinterStatus != 0);
                    if (result == 0)
                    {
                        result = LCMeterLibrary.LCP02MustPrint(Constants.device, prnText, prnlen, Constants.delaypointer, Constants.delaypointer);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }

        public DataSet GetTransactionsInfo()
        {
            ds = new DataSet();
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand();
                cmd.CommandText = "SELECT invoice_no, airline_name, flight_id, business_day, shift " +
                    "FROM transactions order by invoice_no desc, business_day desc;";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                adp = new OleDbDataAdapter(cmd);
                adp.Fill(ds, "transactions");
                DatasetHeaderNameChanges(ref ds);
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            finally
            {
                DBConnectionString.CloseConnection(ConString);
            }
            return ds;
        }
        private void DatasetHeaderNameChanges(ref DataSet ds)
        {
            ds.Tables[0].Columns[0].ColumnName = "ADR NO";
            ds.Tables[0].Columns[1].ColumnName = "AIRLINE NAME";
            ds.Tables[0].Columns[2].ColumnName = "FLIGHT #";
            ds.Tables[0].Columns[3].ColumnName = "BUSINESS DAY"; ;
            ds.Tables[0].Columns[4].ColumnName = "SHIFT";
        }
    }
}
