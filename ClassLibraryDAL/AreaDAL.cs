using ClassLibraryEntity;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibraryDAL
{
    public class AreaDAL
    {
        public static List<AreaEntity> GetArea(int cid)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetCityAreas", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cityid", cid);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<AreaEntity> AreaList = new List<AreaEntity>();
            while (sdr.Read())
            {
                AreaEntity area = new AreaEntity();
                area.areaid = sdr["areaid"].ToString();
                area.area = sdr["area"].ToString();
                area.cityid = sdr["cityid"].ToString();
                AreaList.Add(area);
            }

            con.Close();
            return AreaList;
        }
        public static AreaEntity GetAreaById(string cid, string aid)
        {
            AreaEntity area = new AreaEntity();
            SqlConnection con = DBHelper.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("SP_GetCityAreaById", con);
            cmd.Parameters.AddWithValue("@cityid", cid);
            cmd.Parameters.AddWithValue("@areaid", aid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                area.areaid = sdr["areaid"].ToString();
                area.area = sdr["area"].ToString();
                area.cityid = sdr["cityid"].ToString();
            }
            con.Close();
            return area;


        }
        public static void UpdateArea(AreaEntity ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_UpdateCityArea", con);
            cmd.Parameters.AddWithValue("@areaid",int.Parse(ee.areaid));
            cmd.Parameters.AddWithValue("@area", ee.area);
            cmd.Parameters.AddWithValue("@cityid",int.Parse(ee.cityid));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void SaveArea(AreaEntity ee)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_SaveCityArea", con);
            cmd.Parameters.AddWithValue("@area", ee.area);
            cmd.Parameters.AddWithValue("@cityid",int.Parse(ee.cityid));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static void DeleteArea(string Id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DeleteCityArea", con);
            cmd.Parameters.AddWithValue("@areaid", Id);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

