using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BusinessEntityLayer;
using System.Configuration;
using Common;
using System.Data.OleDb;

namespace DataAccessLayer
{
    public class LoginData
    {        
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader rd;
        ConfigurationInfo configurationinfo = null;        
        string ConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);
        public List<int> LoadShiftInfo()
        {
            List<int> lstShift = null;
            try
            {
                lstShift = new List<int>();
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("select remark4 from configuration", con);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if(rd.HasRows)
                {
                    while(rd.Read())
                    {
                        lstShift.Add(Convert.ToInt16(rd[0]));
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;                
            }
            finally
            {               
                DBConnectionString.CloseConnection(ConString);
            }
            return lstShift;
        }
        public ConfigurationInfo GetConfigurationInfo()
        {
            configurationinfo = new ConfigurationInfo();
            try
            {                
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("select * from configuration", con);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        configurationinfo.refuller_id = rd[0].ToString();
                        configurationinfo.bo_ip= rd[1].ToString();
                        configurationinfo.inv_series = rd[2].ToString();
                        configurationinfo.remark1 = rd[4].ToString();
                        configurationinfo.remark2 = rd[5].ToString();
                        configurationinfo.remark5 = rd[8].ToString();
                        configurationinfo.oth_series = rd[9].ToString();
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {                
                DBConnectionString.CloseConnection(ConString);
            }
            return configurationinfo;
        }
        public bool GetUserInfo(string username, string password)
        {
            bool UserExist = false;
             try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("select loginName from user_master where loginName=@loginame and password=@password", con);                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@loginame", username);
                cmd.Parameters.AddWithValue("@password", password);
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                    UserExist = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserExist;
        }

        public bool CheckRefuller()
        {
            bool flag = false;            
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("select refueller_id from configuration", con);
                cmd.CommandType = CommandType.Text;
                object result = cmd.ExecuteScalar();
                result = (result == DBNull.Value) ? null : result;                
                if (!string.IsNullOrEmpty(result.ToString()))                
                    flag = true;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return flag;
        }
        public int CheckLocation()
        {            
            int loc_id = 0;
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("select loc_code from location_master", con);
                cmd.CommandType = CommandType.Text;
                object result = cmd.ExecuteScalar();
                result = (result == DBNull.Value) ? null : result;
                loc_id = Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return loc_id;
        }
        public List<string> LoadRefuller()
        {
            List<string> lstRefuller = new List<string>();
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("select refueller_id from refueller_master", con);
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lstRefuller.Add(rd[0].ToString());
                    }
                    rd.Close();
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstRefuller;
        }

        public void SaveConfigInfo(ConfigurationInfo configurationInfo)
        {            
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("INSERT INTO configuration (refueller_id,bo_ip,remark1,remark2,remark5,oth_series) VALUES('"+ configurationInfo.refuller_id+"','"+ configurationInfo.bo_ip+"','" 
                    +configurationinfo.remark1+"','"+ configurationInfo.remark2+"','"+ configurationInfo.remark5+"','"+ configurationInfo.oth_series+"')", con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateConfigInfo(ConfigurationInfo configurationInfo)
        {            
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("Update configuration set refueller_id='" + configurationInfo.refuller_id + "',bo_ip='" + configurationInfo.bo_ip + "',inv_series='" + configurationInfo.inv_series + "', remark1='"+
                    configurationInfo.remark1 + "',remark2='"+ configurationInfo.remark2 + "',remark5='"+ configurationInfo.remark5 + "',oth_series='" + configurationInfo.oth_series + "'",con);                   
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
