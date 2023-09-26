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

        public static void insert_contact()
        {
            string query = "insert into Adress_Book_Table values('pavan','kumar','3-9-8 lm compound','Kurnool','Andhra Pradesh',518543,8341595950,'pavankumar@gmail.com') ";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("data inserted successfully");
            Console.WriteLine("--------------------------");
            connection.Close();
        }

        public static void update_contact()
        {
            string query = "update Adress_Book_Table set City='Hyderabad' where First_name='pavan'";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("data updated successfully");
            Console.WriteLine("-------------------------");
            connection.Close();
        }

        public static void delete_contact()
        {
            string query = "delete from Adress_Book_Table where First_name='pavan'";
            SqlCommand cmd=new SqlCommand(query, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            Console.WriteLine("deleted row succesfully");
            Console.WriteLine("-----------------------");
            connection.Close();
        }

        public static void retrieve_data()
        {
           using(connection)
            {
                PersonDetails person=new PersonDetails();
                string query = "select * from Adress_Book_Table where city='Kurnool'";
                SqlCommand cmd=new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader=cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    Console.WriteLine("------data------");
                    while(reader.Read())
                    {
                        person.id = Convert.ToInt16(reader["id"]);
                        person.first_name = Convert.ToString(reader["First_Name"]);
                        person.last_name = Convert.ToString(reader["Last_Name"]);
                        person.address = Convert.ToString(reader["Address"]);
                        person.city = Convert.ToString(reader["City"]);
                        person.state = Convert.ToString(reader["State"]);
                        person.zip =Convert.ToInt64(reader["Zip"]);
                        person.phone_number =Convert.ToInt64(reader["Phone"]);
                        person.email_id = Convert.ToString(reader["Email"]);
                        Console.WriteLine("----------------------------------------);
                        Console.WriteLine(person.id);
                        Console.WriteLine(person.first_name);
                        Console.WriteLine(person.last_name);
                        Console.WriteLine(person.address);
                        Console.WriteLine(person.city);
                        Console.WriteLine(person.state);
                        Console.WriteLine(person.zip);
                        Console.WriteLine(person.phone_number);
                        Console.WriteLine(person.email_id);
                    }
                }
                connection.Close();
            }

        }
    }

}
