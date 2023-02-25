using ClassLibraryEntity;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Syncfusion.Blazor;
namespace ClassLibraryDAL
{
    public class VendorDAL
    {
        public static void SaveAndUpdateVendorServices(string venid, string services)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SaveVenderServices", con);
            cmd.Parameters.AddWithValue("@ven_id", venid);
            cmd.Parameters.AddWithValue("@services", services);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static List<VendorEntity> FindVendorByAreaCategoryStartingPrice(string CityID,string AreaId, string CategoryID, string StartingPrice)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SPu_GetFilteredVendorByAreaAndCategory", con);
            cmd.Parameters.AddWithValue("@cityid", int.Parse(CityID));
            cmd.Parameters.AddWithValue("@areaid", int.Parse(AreaId));
            cmd.Parameters.AddWithValue("@categoryid", int.Parse(CategoryID));
            cmd.Parameters.AddWithValue("@startingprice",int.Parse(StartingPrice));
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<VendorEntity> VendorList = new List<VendorEntity>();
            while (sdr.Read())
            {
                VendorEntity ven = new VendorEntity();
                ven.businessname = sdr["businessname"].ToString();
                ven.City = sdr["cityname"].ToString();
                ven.area = sdr["area"].ToString();
                ven.startingPrice= sdr["startingPrice"].ToString();
                ven.ven_id = sdr["ven_id"].ToString();

                VendorList.Add(ven);

            }
            con.Close();
            return VendorList;
            

        }
        public static List<VenderServicesEntity> GetVendorServices(string id)
        {
            List<VenderServicesEntity> ServicesList = new List<VenderServicesEntity>();
            SqlConnection con = DBHelper.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("Sp_GetVenderServicesById", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                VenderServicesEntity ven = new VenderServicesEntity();
                ven.services = sdr["venderservices"].ToString();
                ServicesList.Add(ven);
            }
            con.Close();
            return ServicesList;
        }
        public static List<PackagesEntity> GetPackagesId(string pid)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SPv_GetPackagesById", con);
            cmd.Parameters.AddWithValue("@id", pid);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            List<PackagesEntity> packagelist = new List<PackagesEntity>();
            while (sdr.Read())
            {
                PackagesEntity pe = new PackagesEntity();
                pe.PakageTitle = sdr["PakageTitle"].ToString();
                pe.id = sdr["id"].ToString();
                pe.price = sdr["price"].ToString();
                pe.pakageType = sdr["pakageType"].ToString();
                pe.PakageDetails = sdr["PakageDetails"].ToString();

                packagelist.Add(pe);

            }
            con.Close();
            return packagelist;
        }
        public static List<VendorEntity> GetAllVendors()
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetAllVendors", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader sdr = cmd.ExecuteReader();
            List<VendorEntity> VendorList = new List<VendorEntity>();
            while (sdr.Read())
            {
                VendorEntity ve = new VendorEntity();
                ve.ven_id = sdr["ven_id"].ToString();
                ve.businessname = sdr["businessname"].ToString();
                ve.ownername = sdr["ownername"].ToString();
                ve.phoneno = sdr["phoneno"].ToString();
                ve.email = sdr["email"].ToString();
                ve.City = sdr["cityname"].ToString();
                ve.Cat_Id = sdr["categoryname"].ToString();

                ve.status = sdr["status"].ToString();
                                 
                VendorList.Add(ve);
            }
            con.Close();
            return VendorList;
        }

        public static List<VendorEntity> GetAllVendorsByCityID(int cityid)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SPu_GetAllVendorByAreaAndCategory", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cityid", cityid);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<VendorEntity> VendorList = new List<VendorEntity>();
            while (sdr.Read())
            {
                VendorEntity ve = new VendorEntity();
                ve.ven_id = sdr["ven_id"].ToString();
                ve.businessname = sdr["businessname"].ToString();              
                ve.City = sdr["cityname"].ToString();
                ve.area = sdr["area"].ToString();
                ve.startingPrice = sdr["startingPrice"].ToString();
                VendorList.Add(ve);
            }
            con.Close();
            return VendorList;
        }
        public static VendorEntity GetVendorById_V(string id)
        {
            VendorEntity ven = new VendorEntity();
            SqlConnection con = DBHelper.GetConnection();
            con.Open();

            SqlCommand cmd = new SqlCommand("SPv_GetVendorById", con);
            cmd.Parameters.AddWithValue("@v", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                ven.id = sdr["id"].ToString();
                ven.ven_id = sdr["ven_id"].ToString();
                ven.businessname = sdr["businessname"].ToString();
                ven.ownername = sdr["ownername"].ToString();
                ven.address = sdr["address"].ToString();
                ven.phoneno = sdr["phoneno"].ToString();
                ven.weburl = sdr["weburl"].ToString();
                ven.email = sdr["email"].ToString();
                ven.landline = sdr["landline"].ToString();
                ven.description = sdr["description"].ToString();
                ven.holiday = sdr["holiday"].ToString();
                ven.City = sdr["cityname"].ToString();
                ven.area = sdr["area"].ToString();
                ven.Cat_Id = sdr["categoryname"].ToString();
                ven.imageurl = sdr["imageurl"].ToString();
                ven.thumnail = sdr["thumnail"].ToString();
                ven.icon = sdr["icon"].ToString();
                ven.regdate = sdr["regdate"].ToString();
                ven.password = sdr["password"].ToString();
                ven.startingPrice = sdr["startingPrice"].ToString();
                ven.pricetype = sdr["ptid"].ToString();
                ven.status = sdr["status"].ToString();
                ven.repid = sdr["repid"].ToString();
            }
            con.Close();
            return ven;
        }
        public static List<VendorEntity> GetFilteredVendor(string cid, string cat, string s)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_GetFilteredVendors", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cityid", int.Parse(cid));
            cmd.Parameters.AddWithValue("@categoryid", int.Parse(cat));
            cmd.Parameters.AddWithValue("@status", s);
            SqlDataReader sdr = cmd.ExecuteReader();
            List<VendorEntity> VendorList = new List<VendorEntity>();
            while (sdr.Read())
            {
                VendorEntity ve = new VendorEntity();
                ve.ven_id = sdr["ven_id"].ToString();
                ve.businessname = sdr["businessname"].ToString();
                ve.ownername = sdr["ownername"].ToString();
                ve.phoneno = sdr["phoneno"].ToString();
                ve.email = sdr["email"].ToString();
                ve.City = sdr["cityname"].ToString();
                ve.Cat_Id = sdr["categoryname"].ToString();
               
               
                ve.status = sdr["status"].ToString();

                VendorList.Add(ve);
            }
            con.Close();
            return VendorList;
        }
        public static void DeleteVendor(string id)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_DeleteVendor", con);
            cmd.Parameters.AddWithValue("@ven_id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void ChangeStatus(string id, int status)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SP_ChangeStatus", con);
            cmd.Parameters.AddWithValue("@ven_id", id);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void UpdateProfile(VendorEntity ve)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SPv_UpdateProfile", con);
            cmd.Parameters.AddWithValue("@ven_id", ve.ven_id);
            cmd.Parameters.AddWithValue("@businessname", ve.businessname);
            cmd.Parameters.AddWithValue("@ownername", ve.ownername);
            cmd.Parameters.AddWithValue("@address", ve.address);
            cmd.Parameters.AddWithValue("@phoneno", ve.phoneno);
            cmd.Parameters.AddWithValue("@weburl", ve.weburl);
            cmd.Parameters.AddWithValue("@email", ve.email);
            cmd.Parameters.AddWithValue("@landline", ve.landline);
            cmd.Parameters.AddWithValue("@description", ve.description);
            cmd.Parameters.AddWithValue("@holiday", ve.holiday);
            cmd.Parameters.AddWithValue("@City", int.Parse(ve.City));
            cmd.Parameters.AddWithValue("@area", int.Parse(ve.area));
            cmd.Parameters.AddWithValue("@imageurl", ve.imageurl);
            cmd.Parameters.AddWithValue("@thumnail", ve.thumnail);
            cmd.Parameters.AddWithValue("@icon", ve.icon);
            cmd.Parameters.AddWithValue("@password", ve.password);
            cmd.Parameters.AddWithValue("@startingPrice", int.Parse(ve.startingPrice));
            cmd.Parameters.AddWithValue("@pricetype", int.Parse(ve.pricetype));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public static void UpdateContact(VendorEntity ve)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SPv_UpdateContact", con);
            cmd.Parameters.AddWithValue("@ven_id", ve.ven_id);
            cmd.Parameters.AddWithValue("@phoneno", ve.phoneno);
            cmd.Parameters.AddWithValue("@weburl", ve.weburl);
            cmd.Parameters.AddWithValue("@landline", ve.landline);
            cmd.Parameters.AddWithValue("@description", ve.description);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public static void UpdatePrice(VendorEntity ve)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SPv_UpdatePrice", con);
            cmd.Parameters.AddWithValue("@ven_id", ve.ven_id);
            cmd.Parameters.AddWithValue("@startingPrice", int.Parse(ve.startingPrice));
            cmd.Parameters.AddWithValue("@pricetype", int.Parse(ve.pricetype));
            cmd.Parameters.AddWithValue("@holiday", ve.holiday);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public static void UpdateAddress(VendorEntity ve)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SPv_UpdateAddress", con);
            cmd.Parameters.AddWithValue("@ven_id", ve.ven_id);
            cmd.Parameters.AddWithValue("@address", ve.address);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public static void UpdatePass(VendorEntity ve)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("SPv_UpdatePass", con);
            cmd.Parameters.AddWithValue("@ven_id", ve.ven_id);
            cmd.Parameters.AddWithValue("@password", ve.password);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public static void DeletePackage(string pid)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_DeletePackage", con);
            cmd.Parameters.AddWithValue("@id", pid);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public static void SavePackage(PackagesEntity pe)
        {
            SqlConnection con = DBHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_SavePackages", con);
            cmd.Parameters.AddWithValue("@PakageTitle", pe.PakageTitle);
            cmd.Parameters.AddWithValue("@PakageDetails", pe.PakageDetails);
            cmd.Parameters.AddWithValue("@price", int.Parse(pe.price));
            cmd.Parameters.AddWithValue("@ven_id", pe.ven_id);
            cmd.Parameters.AddWithValue("@pricetype", pe.pakageType);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
