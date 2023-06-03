using E_shopping_portal.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace E_shopping_portal.Repository
{
    public class E_shoppingPortalHomeRepository
    {
        private SqlConnection con;
        private string connectionstring;


        private void ConnectDb()
        {
            try
            {
                connectionstring = ConfigurationManager.ConnectionStrings["getconnection"].ToString();
                con = new SqlConnection(connectionstring);
            }
            catch { }
        }
        public bool SigninUser(HomeSiginModel signin)
        {

            ConnectDb();
            SqlCommand command = new SqlCommand("sps_SigninUser", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CustomerUsername", signin.Username);
            command.Parameters.AddWithValue("@CustomerPassword", signin.Password);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable datatable = new DataTable();
            dataAdapter.Fill(datatable);
            if (datatable.Rows.Count > 0)
            {
                if (datatable.Rows[0].Field<int>("UserType") == 0)
                {
                    return true;
                }
                else if (datatable.Rows[0].Field<int>("UserType") == 1)
                {
                    return false;
                }
            }
            return false;
        }


        [HttpPost]
        public bool SignupUser(HomeSignupModel signup)
        {

            ConnectDb();
            SqlCommand command = new SqlCommand("spi_CustomerRegistration", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@CustomerFirstName", signup.FirstName);
            command.Parameters.AddWithValue("@CustomerLastName", signup.LastName);
            command.Parameters.AddWithValue("@CustomerDateOfBirth", signup.DateOfBirth);
            command.Parameters.AddWithValue("@CustomerGender", signup.Gender);
            command.Parameters.AddWithValue("@CustomerPhoneNumber", signup.PhoneNumber);
            command.Parameters.AddWithValue("@CustomerEmailAddress", signup.EmailAddress);
            command.Parameters.AddWithValue("@CustomerAddress", signup.Address);
            command.Parameters.AddWithValue("@CustomerState", signup.State);
            command.Parameters.AddWithValue("@CustomerCity", signup.City);
            command.Parameters.AddWithValue("@CustomerUsername", signup.Username);
            command.Parameters.AddWithValue("@CustomerPassword", signup.Password);
            command.Parameters.AddWithValue("@UserType", 0);
            con.Open();

            try
            {
                int i = command.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally { con.Close(); }
        }
    }
}