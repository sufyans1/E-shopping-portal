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

        /// <summary>
        /// To establish connection with database
        /// </summary>
        private void ConnectDb()
        {
            try
            {
                connectionstring = ConfigurationManager.ConnectionStrings["getconnection"].ToString();
                con = new SqlConnection(connectionstring);
            }
            catch { }
        }



        private bool UserIsExist()
        {
            ConnectDb();
            HomeSignupModel model = new HomeSignupModel();
            string querry = "SELECT * FROM tbl_CustomerRegistration WHERE CustomerUsername = '" + model.Username + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(querry, con);

            con.Open();
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            if (datatable.Rows.Count > 0)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }

        }
        /// <summary>
        /// To perform sign in operation for the user
        /// </summary>
        /// <param name="signin"></param>
        /// <returns>
        /// Returns usertype as integer  
        /// </returns>
        public int SigninUser(HomeSiginModel signin)
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
                    return 0;
                }
                else if (datatable.Rows[0].Field<int>("UserType") == 1)
                {
                    return 1;
                }
            }
            return 3;
        }

        /// <summary>
        /// TO perform signup operations for the  new user
        /// </summary>
        /// <param name="signup"></param>
        /// <returns>
        /// Return true if the operation is succesful False if any error occurs or the username is already exist
        /// </returns>
        [HttpPost]
        public bool SignupUser(HomeSignupModel signup)
        {
            if (UserIsExist())
            {
                return false;
            }
            else if (!UserIsExist()) { }
            {
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
                    command.ExecuteNonQuery();
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
}