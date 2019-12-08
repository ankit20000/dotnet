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
    public class FuelEntryParameterConcrete : IFuelEntryParameter
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader rd;        
        string ConString = DBConnectionString.Getconnectionstring(Database.AccessDBConnection);

        public DensityReference GetDensityReference(string refullerid)
        {
            DensityReference ObjDensityReference = null;
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand();
                cmd.CommandText = "select storage_id,density,temp,fuel_batch_no from density_ref_table where storage_id=@refullerid";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@refullerid", refullerid);
                rd = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if(rd.HasRows)
                {
                    while(rd.Read())
                    {
                        ObjDensityReference = new DensityReference();
                        ObjDensityReference.storage_id = rd["storage_id"].ToString();
                        ObjDensityReference.density=Convert.ToDecimal(rd["density"]);
                        ObjDensityReference.temp= Convert.ToDecimal(rd["temp"]);
                        ObjDensityReference.fuel_batch_no = rd["fuel_batch_no"].ToString();
                    }
                }
                rd.Close();
            }
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return ObjDensityReference;
        }

        public DensityReference GetDensityReference()
        {
            DensityReference ObjDensityReference = null;
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand();
                cmd.CommandText = "select top 1 storage_id,density,temp,fuel_batch_no from density_ref_table where storage_id like 'T%'";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        ObjDensityReference = new DensityReference();
                        ObjDensityReference.storage_id= rd["storage_id"].ToString();
                        ObjDensityReference.density = Convert.ToDecimal(rd["density"]);
                        ObjDensityReference.temp = Convert.ToDecimal(rd["temp"]);
                        ObjDensityReference.fuel_batch_no = rd["fuel_batch_no"].ToString();
                    }
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return ObjDensityReference;
        }

        public int UpdateDensityReference(decimal density, decimal temperature, string fuelbatchno, string refullerid)
        {
            int resval = 0;
            try
            {
                con = DBConnectionString.OpenConnection(ConString);
                cmd = new OleDbCommand();
                cmd.CommandText = "update density_ref_table set density=@density,temp=@temp,fuel_batch_no=@fuel_batch_no where storage_id=@refullerid";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@density", density);
                cmd.Parameters.AddWithValue("@temp", temperature);
                cmd.Parameters.AddWithValue("@fuel_batch_no", fuelbatchno);
                cmd.Parameters.AddWithValue("@refullerid", refullerid);
                cmd.CommandType = CommandType.Text;
                resval=cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Logging.ErrorLog(ex);
            }
            return resval;
        }
    }
}
