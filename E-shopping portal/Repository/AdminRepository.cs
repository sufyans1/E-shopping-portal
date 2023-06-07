using E_shopping_portal.Models;
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
    }
}