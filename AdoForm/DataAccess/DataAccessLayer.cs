using AdoForm.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AdoForm.Security;
using System;

namespace AdoForm.DataAccess
{
    public class DataAccessLayer
    {

        string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        // Gets all users in database
        public List<User> GetAllUsers()
        {
            List<User> userList = null;
            DataSet ds = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    // Insert query  
                    string query = "SELECT * FROM users";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        // opening connection  
                        con.Open();
                        SqlDataAdapter dap = new SqlDataAdapter();
                        dap.SelectCommand = cmd;
                        ds = new DataSet();
                        dap.Fill(ds);
                        userList = new List<User>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            User userObj = new User();
                            userObj.Email = ds.Tables[0].Rows[i]["email"].ToString();
                            userObj.Password = ds.Tables[0].Rows[i]["password"].ToString();
                            userList.Add(userObj);
                        }
                        return userList;
                    }
                }
            }
            catch
            {
                return userList;
            }

        }

        // Inserts a user
        public string InsertUser(User userObj)
        {
            string result = "";
            SecurityHandler secHandler = new SecurityHandler();
            string userPassword = secHandler.HashPassword(userObj.Password);
            bool taken = EmailIsTaken(userObj.Email);
            if (!taken)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(_connectionString))
                    {
                        // Insert query  
                        string query = "INSERT INTO users(email,password) VALUES(@email, @password)";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            // opening connection  
                            con.Open();
                            // Passing parameter values  
                            cmd.Parameters.AddWithValue("@email", userObj.Email);
                            cmd.Parameters.AddWithValue("@password", userPassword);

                            // Executing insert query  
                            result = cmd.ExecuteNonQuery() >= 1 ? "success" : "failure";
                        }
                    }

                }
                catch
                {
                    return result = "";
                }
            }
            else
            {
                result = "email address is taken";
            }
            return result;

        }

        public bool EmailIsTaken(string email)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    // Insert query  
                    string query = "SELECT * FROM users " +
                                   "WHERE email = @email";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        // opening connection  
                        con.Open();
                        // Passing parameter values  
                        cmd.Parameters.AddWithValue("@email", email);

                        // Executing insert query  
                        object result = (string)cmd.ExecuteScalar();
                        // Handle null being returned. This is not the best way to do it
                        if(result != null || (string)result != "null")
                        {
                             return false;
                        }
                    }
                }
                return true;

            }
            catch
            {
                // An error should be thrown but this will do for now
                return true;
            }
        }
        // Other crud methods would go here
    }
}