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
    public class PackagesDal
    {
        public static List<PackagesEntity> GetPackagesById(string venid)
        {
          List<PackagesEntity> packagesEntity= new List<PackagesEntity>();    
         
            SqlConnection con = DBHelper.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("Sp_GetVenderPackagesById", con);
            cmd.Parameters.AddWithValue("@id", venid);           
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                PackagesEntity pe=new PackagesEntity();
                pe.PakageTitle = sdr["PakageTitle"].ToString();

               pe.PakageDetails= sdr["PakageDetails"].ToString();
               pe.price = sdr["price"].ToString();
               pe.pakageType = sdr["pakageType"].ToString();
                packagesEntity.Add(pe);
            }
            con.Close();
            return packagesEntity;


        }

    }
}
