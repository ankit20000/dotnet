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
    public class ConfigurationConcrete : IConfiguration
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader rd;        
        string ConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);

        public List<object> LoadRefuller()
        {
            List<object> lstRefuller = null;
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("select refueller_id from refueller_master", con);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    lstRefuller = new List<object>();
                    while (rd.Read())
                    {
                        lstRefuller.Add(rd[0].ToString());
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return lstRefuller;
        }
        public void SaveConfigInfo(ConfigurationInfo configurationInfo)
        {
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("INSERT INTO configuration (refueller_id,bo_ip,remark1,remark2,remark5,oth_series) VALUES(@refueller_id,@bo_ip,@remark1,@remark2,@remark5,@oth_series)", con);
                cmd.Parameters.AddWithValue("@refueller_id", configurationInfo.refuller_id);
                cmd.Parameters.AddWithValue("@bo_ip", configurationInfo.bo_ip);
                cmd.Parameters.AddWithValue("@remark1", configurationInfo.remark1);
                cmd.Parameters.AddWithValue("@remark2", configurationInfo.remark2);
                cmd.Parameters.AddWithValue("@remark5", configurationInfo.remark5);
                cmd.Parameters.AddWithValue("@oth_series", configurationInfo.oth_series);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
        public void UpdateConfigInfo(ConfigurationInfo configurationInfo)
        {
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("Update configuration set refueller_id=@refueller_id,bo_ip=@bo_ip,inv_series=@inv_series, remark1=@remark1,remark2=@remark2,remark5=@remark5,oth_series=@oth_series", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@refueller_id", configurationInfo.refuller_id);
                cmd.Parameters.AddWithValue("@bo_ip", configurationInfo.bo_ip);
                cmd.Parameters.AddWithValue("@inv_series", configurationInfo.inv_series);
                cmd.Parameters.AddWithValue("@remark1", configurationInfo.remark1);
                cmd.Parameters.AddWithValue("@remark2", configurationInfo.remark2);
                cmd.Parameters.AddWithValue("@remark5", configurationInfo.remark5);
                cmd.Parameters.AddWithValue("@oth_series", configurationInfo.oth_series);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
        }
    }
}
