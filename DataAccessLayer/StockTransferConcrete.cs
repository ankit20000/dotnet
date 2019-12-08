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
    public class StockTransferConcrete : IStockTransfer
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader rd;
        string ConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);

        public List<object> GetRefuellerMaster(string refuellerId)
        {
            List<object> lstRefullers = null;
            try
            {                
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand();
                cmd.CommandText = "select refueller_id from refueller_master where not Refueller_id=@Refuller_id";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Refuller_id", refuellerId);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if(rd.HasRows)
                {
                    lstRefullers = new List<object>();
                    while (rd.Read())
                    {
                        lstRefullers.Add(rd["refueller_id"].ToString());
                    }
                }
                rd.Close();
            }
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return lstRefullers;
        }
        public List<object> GetTankMaster()
        {
            List<object> lstTankno = null;
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("select Tank_no from Tank_Master",con);                             
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    lstTankno = new List<object>();
                    while (rd.Read())
                    {
                        lstTankno.Add(rd["Tank_no"].ToString());
                    }
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return lstTankno;
        }

        public int SaveStockTransfer(StockTransfer stockTransfer)
        {
            int retval = 0;
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand();
                cmd.CommandText = "INSERT INTO StockTransfer (bill_no,trans_date,trans_time,tran_type,source,destination,Qty,temperature,density,fuel_batch_no," +
                    "equipment_no,meter_start,meter_end,operators,shift,business_day,tmStamp) values (@bill_no,@trans_date,@trans_time,@tran_type,@source,@destination," +
                    "@Qty,@temperature,@density,@fuel_batch_no,@equipment_no,@meter_start,@meter_end,@operators,@shift,@business_day,@tmStamp)";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@bill_no", stockTransfer.bill_no);
                cmd.Parameters.AddWithValue("@trans_date", stockTransfer.trans_date);
                cmd.Parameters.AddWithValue("@trans_time", stockTransfer.trans_time);
                cmd.Parameters.AddWithValue("@tran_type", stockTransfer.tran_type);
                cmd.Parameters.AddWithValue("@source", stockTransfer.source);
                cmd.Parameters.AddWithValue("@destination", stockTransfer.destination);
                cmd.Parameters.AddWithValue("@Qty", stockTransfer.Qty);
                cmd.Parameters.AddWithValue("@temperature", stockTransfer.temperature);
                cmd.Parameters.AddWithValue("@density", stockTransfer.density);
                cmd.Parameters.AddWithValue("@fuel_batch_no", stockTransfer.fuel_batch_no);
                cmd.Parameters.AddWithValue("@equipment_no", stockTransfer.equipment_no);
                cmd.Parameters.AddWithValue("@meter_start", stockTransfer.meter_start);
                cmd.Parameters.AddWithValue("@meter_end", stockTransfer.meter_end);
                cmd.Parameters.AddWithValue("@operators", stockTransfer.operators);
                cmd.Parameters.AddWithValue("@shift", stockTransfer.shift);
                cmd.Parameters.AddWithValue("@business_day", stockTransfer.business_day);           
                cmd.Parameters.AddWithValue("@tmStamp", stockTransfer.tmStamp);
                retval = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return retval;
        }
    }
}
