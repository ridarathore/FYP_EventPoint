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
    public class CategoryDAL
    {
        public static List<ServiceEntity> GetSevices(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetServices", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cat_Id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<ServiceEntity> categorieslist = new List<ServiceEntity>();
            while (sdr.Read())
            {
                ServiceEntity es = new ServiceEntity();

                es.Ser_id = sdr["Ser_id"].ToString();
                es.Services = sdr["Services"].ToString();
                es.Cat_Id = sdr["Cat_Id"].ToString();
                categorieslist.Add(es);
            }
            con.Close();
            return categorieslist;
        }
        public static void DeleteService(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_DeleteService", con);
            cmd.Parameters.AddWithValue("@Ser_id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static ServiceEntity GetServicesById(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GetServicesById", con);
            cmd.Parameters.AddWithValue("@Ser_Id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            ServiceEntity ec = new ServiceEntity();
            while (sdr.Read())
            {
                ec.Ser_id = sdr["Ser_id"].ToString();
                ec.Services = sdr["Services"].ToString();
                ec.Cat_Id = sdr["Cat_Id"].ToString();
            }
            con.Close();
            return ec;
        }
        public static ServiceEntity GetCategoryId(string venid)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Spv_GetCategoryId", con);
            cmd.Parameters.AddWithValue("@ven_id", venid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            ServiceEntity ec = new ServiceEntity();
            while (sdr.Read())
            {
                //ec.Ser_id = sdr["Ser_id"].ToString();
                //ec.Services = sdr["Services"].ToString();
                ec.Cat_Id = sdr["Cat_Id"].ToString();
            }
            con.Close();
            return ec;
        }
        public static void SaveService(ServiceEntity es)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveServices", con);
            cmd.Parameters.AddWithValue("@Cat_Id", es.Cat_Id);
            cmd.Parameters.AddWithValue("@ServiceName", es.Services);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void UpdateService(ServiceEntity es)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateService", con);
            cmd.Parameters.AddWithValue("@Ser_id", es.Ser_id);
            cmd.Parameters.AddWithValue("@servicename", es.Services);
            cmd.Parameters.AddWithValue("@categoryid", es.Cat_Id);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public static List<CategoryEntity> GetCategories()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCategories", con);
            cmd.CommandType = CommandType.StoredProcedure;


            SqlDataReader sdr = cmd.ExecuteReader();
            List<CategoryEntity> categorieslist = new List<CategoryEntity>();
            while (sdr.Read())
            {
                CategoryEntity ct = new CategoryEntity();
                ct.categoryid = sdr["categoryid"].ToString();
                ct.categoryname = sdr["categoryname"].ToString();

                categorieslist.Add(ct);

            }
            con.Close();
            return categorieslist;
        }
        public static void DeleteCategory(int categoryids)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DeleteCategory", con);
            cmd.Parameters.AddWithValue("@categoryid", categoryids);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateCategory(CategoryEntity ec)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateCategory", con);
            cmd.Parameters.AddWithValue("@categoryid", ec.categoryid);
            cmd.Parameters.AddWithValue("@categoryname", ec.categoryname);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public static CategoryEntity GetCategoryById(int id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCategoryById", con);
            cmd.Parameters.AddWithValue("@categoryid", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            CategoryEntity ec = new CategoryEntity();
            while (sdr.Read())
            {
                ec.categoryid = sdr["categoryid"].ToString();
                ec.categoryname = sdr["categoryname"].ToString();


            }
            con.Close();
            return ec;
        }


        public static void SaveCategories(CategoryEntity ec)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveCategory", con);
            cmd.Parameters.AddWithValue("@CatName", ec.categoryname);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}
