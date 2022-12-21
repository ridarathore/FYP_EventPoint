using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryEntity;
using ClassLibraryDAL;
using System.Data.SqlClient;
using System.Data;

namespace ClassLibraryDAL
{
    public class CityDAL
    {
        public static List<CityEntity> GetCities()
        {
            SqlConnection con = ClassLibraryDAL.DBHelper.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("SP_GetCities",con);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<CityEntity> CityList = new List<CityEntity>();
            while (sdr.Read())
            {
                CityEntity city = new CityEntity();
                city.cityid = sdr["cityid"].ToString();
                city.cityname = sdr["cityname"].ToString();
                city.url = sdr["imageurl"].ToString();

                CityList.Add(city);
            }

            con.Close();
            return CityList;
        }

        public static CityEntity GetCityById(string Id)
        {
            CityEntity city = new CityEntity();
            SqlConnection con = DBHelper.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("SP_GetCityById", con);
            cmd.Parameters.AddWithValue("@cityid", Id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                city.cityid = sdr["cityid"].ToString();
                city.cityname = sdr["cityname"].ToString();
            }
            con.Close();
            return city;


        }

        public static void UpdateCity(CityEntity cc)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateCity", con);
            cmd.Parameters.AddWithValue("@cityid", cc.cityid);
            cmd.Parameters.AddWithValue("@cityname", cc.cityname);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void AddNewCity(CityEntity cc)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveCities", con);
                cmd.Parameters.AddWithValue("@cityname", cc.cityname);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
        public static void DeleteCity(string Id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DeleteCity", con);
            cmd.Parameters.AddWithValue("@cityid", Id);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
    
}