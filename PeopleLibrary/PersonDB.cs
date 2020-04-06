using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PeopleLibrary
{
    public class PersonDB
    {
        string _connectionstring;

        public PersonDB(string ConnectionString)
        {
            _connectionstring = ConnectionString;
        }
        public List<Person> GetAll()
        {
            SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"Select * From Person";
            List<Person> people = new List<Person>();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Person p = new Person
                {
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"],
                    Id = (int)reader["Id"]

                };
                people.Add(p);
            }

            conn.Close();
            conn.Dispose();
            return people;
        }
        public void AddPerson(Person person)
        {
            SqlConnection conn = new SqlConnection(_connectionstring);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"Insert into Person(FirstName, LastName, Age) Values(@FirstName, @LastName, @Age)";
            cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
            cmd.Parameters.AddWithValue("@LastName", person.LastName);
            cmd.Parameters.AddWithValue("@Age", person.Age);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
    }
}
