using E_shopping_portal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace E_shopping_portal.Repository
{
    public class AdminRepository
    {
        SqlConnection connection = new SqlConnection();
        public void ConnectDb()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["getconnection"].ToString();
            connection = new SqlConnection(connectionString);
        }

        public bool AddNewAdmin(AdminAddNewAdminModel model)
        {
            ConnectDb();
            try
            {
                SqlCommand command = new SqlCommand("spi_NewAdmin", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", model.Name);
                command.Parameters.AddWithValue("@Username", model.Username);
                command.Parameters.AddWithValue("@Password", model.Password);
                command.Parameters.AddWithValue("@UserType", 1);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { connection.Close(); }
        }
        public List<HomeSignupModel> ViewUserList()
        {
            ConnectDb();
            List<HomeSignupModel> list = new List<HomeSignupModel>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM tbl_CustomerRegistration WHERE UserType = '0'", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow datarow in table.Rows)
                {
                    list.Add(

                        new HomeSignupModel
                        {
                            Id = Convert.ToInt32(datarow["CustomerID"]),
                            FirstName = Convert.ToString(datarow["CustomerFirstName"]),
                            LastName = Convert.ToString(datarow["CustomerLastName"]),
                            DateOfBirth = Convert.ToDateTime(datarow["CustomerDateOfBirth"]),
                            Gender = Convert.ToString(datarow["CustomerGender"]),
                            PhoneNumber = Convert.ToString(datarow["CustomerPhoneNumber"]),
                            EmailAddress = Convert.ToString(datarow["CustomerEmailAddress"]),
                            Address = Convert.ToString(datarow["CustomerAddress"]),
                            State = Convert.ToString(datarow["CustomerState"]),
                            City = Convert.ToString(datarow["CustomerCity"]),
                            Username = Convert.ToString(datarow["CustomerUsername"]),



                        }
                    );
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally { connection.Close(); }
        }
    }
}