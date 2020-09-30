using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AdoHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            new Program().CreateDatabase(connectionString);
            Console.ReadLine();
        }
        public void CreateDatabase(string connectionString)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection(connectionString);
                // writing sql query  
                SqlCommand cm = new SqlCommand("CREATE DATABASE Homework", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Database created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
                Console.ReadLine();
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
            CreateTable(connectionString);
        }
        public void CreateTable(string connectionString)
        {
            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=DESKTOP-PC58OEL\\SQLEXPRESS02; database=Homework; integrated security=SSPI");
                // writing sql query  
                SqlCommand cm = new SqlCommand("CREATE TABLE users(id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, email VARCHAR(50) NOT NULL, password VARCHAR(50))", con);  
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Table created Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong." + e);
                Console.ReadLine();
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }
    }
}
