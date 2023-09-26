using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOassignmnet
{
    internal class AdressBookOperations
    {
        public static void create_database()
        {
           
           SqlConnection connection = new SqlConnection("data source=(localDB)\\MSSQLLocalDB; initial catalog=master; integrated security=true");
            string query = "create database Address_Book_Service";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("db creted successfully");
            Console.WriteLine("-------------------------");
            connection.Close();
        }

        
    }
}
