using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.UserManagement;

namespace ChatApp.DatabaseManagement
{
    class DBHandler
    {
        public string ConString { get; } = "Server=ZBC-E-RO-23234\\SQLEXPRESS01;Database=ChatApp;Trusted_Connection=True;";
        string query;

        public void AddUser(User user)
        {
            query = "Insert into Users (userId, firstName, lastName, username, password, email, country) Values (@userId, @firstName, @lastName, @username, @password, @email, @country)";
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@userId", user.UserId);
                cmd.Parameters.AddWithValue("@firstName", user.Name);
                cmd.Parameters.AddWithValue("@lastName", user.LastName);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@country", user.Country);
                cmd.ExecuteNonQuery();
            }
        }

        public int GetLastUserId()
        {
            query = "SELECT TOP 1 * FROM Users ORDER BY colId DESC";
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                    return 1;
                else
                    return (int)dt.Rows[0]["userId"];
            }
        }

        public bool DoesUsernameExist(string username)
        {
            query = $"SELECT username FROM Users WHERE username = '{username}'";
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                    return false;
                return true;
            }
        }

        public bool SearchLoginMatch(string username, string password)
        {
            query = $"SELECT username, password FROM Users WHERE username = '{username}' AND password = '{password}'";
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                    return false;
                return true;
            }
        }
    }
}
