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
    public class CirculationTestConcrete : ICirculationTest
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader rd;
        
        string ConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);
        public int SaveStockTransfer(StockTransfer stockTransfer)
        {
            int retval = 0;
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand();
                cmd.CommandText = "INSERT INTO StockTransfer (bill_no,trans_date,trans_time,tran_type,source,destination,Qty,equipment_no,meter_start,meter_end,operators," +
                                 "shift,business_day,comments,nozzle_calib,circulation,tmStamp) values (@bill_no,@trans_date,@trans_time,@tran_type,@source,@destination," +
                                 "@Qty,@equipment_no,@meter_start,@meter_end,@operators,@shift,@business_day,@comments,@nozzle_calib,@circulation,@tmStamp)";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@bill_no", stockTransfer.bill_no);
                cmd.Parameters.AddWithValue("@trans_date", stockTransfer.trans_date);
                cmd.Parameters.AddWithValue("@trans_time", stockTransfer.trans_time);
                cmd.Parameters.AddWithValue("@tran_type", stockTransfer.tran_type);
                cmd.Parameters.AddWithValue("@source", stockTransfer.source);
                cmd.Parameters.AddWithValue("@destination", stockTransfer.destination);
                cmd.Parameters.AddWithValue("@Qty", stockTransfer.Qty);
                cmd.Parameters.AddWithValue("@equipment_no", stockTransfer.equipment_no);
                cmd.Parameters.AddWithValue("@meter_start", stockTransfer.meter_start);
                cmd.Parameters.AddWithValue("@meter_end", stockTransfer.meter_end);
                cmd.Parameters.AddWithValue("@operators", stockTransfer.operators);
                cmd.Parameters.AddWithValue("@shift", stockTransfer.shift);
                cmd.Parameters.AddWithValue("@business_day", stockTransfer.business_day);
                cmd.Parameters.AddWithValue("@comments", stockTransfer.comments);
                cmd.Parameters.AddWithValue("@nozzle_calib", stockTransfer.nozzle_calib);
                cmd.Parameters.AddWithValue("@circulation", stockTransfer.circulation);
                cmd.Parameters.AddWithValue("@tmStamp", stockTransfer.tmStamp);
                retval=cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return retval;
        }

        public void UpdateConfigurationDetails(string otherSeries, string endReading)
        {
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand();
                cmd.CommandText = "UPDATE Configuration SET oth_series=@oth_series,meter_end=@meter_end";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@oth_series", otherSeries);
                cmd.Parameters.AddWithValue("@meter_end", endReading);
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
    }
}
