using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEntity;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibraryDAL
{
    public class ServicesDAL
    {
        public static List<ServiceEntity> GetServices(int catid)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetServices", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cat_Id", catid);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ServiceEntity> ServicesList = new List<ServiceEntity>();
            while (sdr.Read())
            {
                ServiceEntity ser = new ServiceEntity();
                ser.Ser_id = sdr["Ser_id"].ToString();
                ser.Services = sdr["Services"].ToString();
                ser.Cat_Id = sdr["Cat_Id"].ToString();
                ServicesList.Add(ser);
            }

            con.Close();
            return ServicesList;
        }

        public static ServiceEntity GetServiceById(string cid, string sid)
        {
            ServiceEntity ser = new ServiceEntity();
            SqlConnection con = DBHelper.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("SP_GetCategoryById", con);
            cmd.Parameters.AddWithValue("@Cat_Id", cid);
            cmd.Parameters.AddWithValue("@Ser_id", sid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                ser.Ser_id = sdr["Ser_id"].ToString();
                ser.Services = sdr["Services"].ToString();
                ser.Cat_Id = sdr["Cat_Id"].ToString();
            }
            con.Close();
            return ser;


        }

        public static VenderServicesEntity GetServiceByVendorId(string venid)
        {
            VenderServicesEntity venderServices= new VenderServicesEntity();    
           
            SqlConnection con = DBHelper.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("Spu_GetServicesByVendorId", con);
            cmd.Parameters.AddWithValue("@venid", venid);
        
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                venderServices.services = sdr["services"].ToString();
                
            }
            con.Close();

            return venderServices;


        }
        public static void UpdateService(ServiceEntity se)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateService", con);
            cmd.Parameters.AddWithValue("@Ser_id", int.Parse(se.Ser_id));
            cmd.Parameters.AddWithValue("@Services", se.Services);
            cmd.Parameters.AddWithValue("@Cat_Id", int.Parse(se.Cat_Id));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void SaveArea(ServiceEntity se)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveServices", con);
            cmd.Parameters.AddWithValue("@Services", se.Services);
            cmd.Parameters.AddWithValue("@Cat_Id", int.Parse(se.Cat_Id));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void DeleteService(string Id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_DeleteService", con);
            cmd.Parameters.AddWithValue("@Ser_id", Id);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
