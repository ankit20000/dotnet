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
using PosApplication.Interfaces;

namespace DataAccessLayer
{
    public class LoginConcrete:ILogin
    {        
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader rd;
        ConfigurationInfo configurationinfo = null;        
        string ConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);
        public List<object> LoadShiftInfo()
        {
            List<object> lstShift = null;
            try
            {
                lstShift = new List<object>();
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
                Logging.ErrorLog(ex);
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
                Logging.ErrorLog(ex);
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
                Logging.ErrorLog(ex);
            }
            return UserExist;
        }

        public string CheckRefuller()
        {
            string refueller_id = string.Empty;
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("select refueller_id from configuration", con);
                cmd.CommandType = CommandType.Text;
                object result = cmd.ExecuteScalar();
                refueller_id = (result == DBNull.Value) ? null : result.ToString();          
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return refueller_id;
        }
        public string CheckLocation()
        {
            string loc_id = string.Empty;
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand("select loc_code from location_master", con);
                cmd.CommandType = CommandType.Text;
                object result = cmd.ExecuteScalar();               
                loc_id = (result == DBNull.Value) ? null : result.ToString();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return loc_id;
        }                
    }
}
