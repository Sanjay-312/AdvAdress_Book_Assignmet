using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOassignmnet
{
    public class AdressBookOperations
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
        public static SqlConnection connection = new SqlConnection("data source=(localDB)\\MSSQLLocalDB; initial catalog=Address_Book_Service; integrated security=true");


        public static void create_table()
        {
            string query = "create table Adress_Book_Table(Id int primary key identity(1,1),First_Name varchar(20),Last_Name varchar(20),Address varchar(100),City varchar(30),State varchar(30),Zip bigint,Phone bigint, Email varchar(100))";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            Console.WriteLine("table created successfully");
            Console.WriteLine("------------------------");
            connection.Close();

        }
    }
    


}
