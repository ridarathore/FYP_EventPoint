using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ClassLibraryEntity;

namespace ClassLibraryDAL
{
    public class PriceTypeDAL
    {
        public static List<PriceTypeEntity> GetPriceType()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetPriceType", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<PriceTypeEntity> PriceTypeList = new List<PriceTypeEntity>();
            while (sdr.Read())
            {
                PriceTypeEntity price = new PriceTypeEntity();
                price.ptid = sdr["ptid"].ToString();
                price.title = sdr["title"].ToString();
                PriceTypeList.Add(price);
            }

            con.Close();
            return PriceTypeList;
        }

        public static PriceTypeEntity GetPriceById(string pid)
        {
            PriceTypeEntity price = new PriceTypeEntity();
            SqlConnection con = DBHelper.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("SP_GetPriceTypeById", con);
            cmd.Parameters.AddWithValue("@id", pid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                price.title = sdr["title"].ToString();
                price.ptid = sdr["ptid"].ToString();
            }
            con.Close();
            return price;


        }

        public static void UpdatePriceType(PriceTypeEntity pt)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdatePriceType", con);
            cmd.Parameters.AddWithValue("@ptid", int.Parse(pt.ptid));
            cmd.Parameters.AddWithValue("@title", pt.title);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void SavePriceType(PriceTypeEntity pt)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SavePriceType", con);
            cmd.Parameters.AddWithValue("@title", pt.title);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void DeletePriceType(string pid)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DeletePriceType", con);
            cmd.Parameters.AddWithValue("@ptid", pid);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
