using System;
using System.Data.SqlClient;
using System.Data;

namespace ADOdotNETeg
{
    internal class Program
    {
        public static SqlConnection? connection;
        public static SqlCommand? command;

        private static void DisConnectedSelect()
        {
            connection = setConnection();
            command = new SqlCommand("select * from Employee", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            foreach(DataRow dr in dt.Rows)
            {
                foreach(var item in dr.ItemArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }

        private static void SelectData()
        {
            connection = setConnection();
            command = new SqlCommand("select * from Employee");
            // command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Connection = connection;
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                for(int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write(dr[i] + " ");
                }
                Console.WriteLine();
            }
        }

        private static SqlConnection setConnection()
        {
            connection = new SqlConnection("Data Source=.;Initial Catalog=eurofins;Integrated Security=true");
            connection.Open();
            return connection;
        }

        private static void InsertData()
        {
            Console.WriteLine("Enter below details to insert data into the table worker: ");
            Console.Write("Worker id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("First Name: ");
            string? firstname = Console.ReadLine();
            Console.Write("Last Name: ");
            string? lastname = Console.ReadLine();
            Console.Write("Salary: ");
            int salary = Convert.ToInt32(Console.ReadLine());
            DateTime joiningdate = DateTime.Now;
            Console.Write("Department: ");
            string? department = Console.ReadLine();
            connection = setConnection();
            command = new SqlCommand("insert into worker values(@worker_id, @first_name, @last_name, @salary, @joining_date, @department)");
            command.Connection = connection;
            command.Parameters.AddWithValue("@worker_id", id);
            command.Parameters.AddWithValue("@first_name", firstname);
            command.Parameters.AddWithValue("@last_name", lastname);
            command.Parameters.AddWithValue("@salary", salary);
            command.Parameters.AddWithValue("@joining_date", joiningdate);
            command.Parameters.AddWithValue("@department", department);
            int changeCount = command.ExecuteNonQuery();
            Console.WriteLine(changeCount + " number of Row(s) affected.");
        }

        private static void UpdateWorkerSalary()
        {
            connection = setConnection();
            command = new SqlCommand("update worker set salary = 35000 where worker_id > 3");
            command.Connection = connection;
            int changeCount = command.ExecuteNonQuery();
            Console.WriteLine(changeCount + " number of Row(s) affected.");
        }

        private static void DeleteData()
        {
            connection = setConnection();
            command = new SqlCommand("delete from Employee where eid = 3");
            command.Connection = connection;
            int changeCount = command.ExecuteNonQuery();
            Console.WriteLine(changeCount + " number of Row(s) affected.");
        }

        static void main(string[] args)
        {
            // InsertData();
            // UpdateWorkerSalary();
            //DeleteData();
            //SelectData();
            DisConnectedSelect();
        }
    }
}