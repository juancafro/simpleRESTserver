using SimpleRESTServer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SimpleRESTServer.DAL
{
    
    public class PersonRepository : IPersonRepository
    {
        private string connectionstr = @"Data Source =.\; 
                        Initial Catalog = Employee; 
                        Persist Security Info=True;
                        User ID =user; 
                        Password=123456";

        public int Add(Person p)
        {
            using (SqlConnection dbcontext = new SqlConnection(connectionstr))
            {
                try
                {
                    string sql = "Insert into dbo.Person(Name,Lastname,PayRate,StartDate,EndDate) OUTPUT INSERTED.ID VALUES(@param1,@param2,@param3,@param4,@param5)";
                    SqlCommand cmd = new SqlCommand(sql, dbcontext);
                    cmd.Parameters.AddWithValue("@param1", p.Name);
                    cmd.Parameters.AddWithValue("@param2", p.LastName);
                    cmd.Parameters.AddWithValue("@param3", p.PayRate);
                    cmd.Parameters.AddWithValue("@param4", p.StartDate);
                    cmd.Parameters.AddWithValue("@param5", p.EndDate);
                    dbcontext.Open();
                    int a = (int)cmd.ExecuteScalar();
                    Console.WriteLine(a);
                    return a;
                }
                catch (Exception ex) {
                    return 404;

                }

            }
        }

        public Person get(int id)
        {
            using (SqlConnection dbcontext = new SqlConnection(connectionstr)) {
                string sql = "select * from dbo.Person where Id = @id";
                SqlCommand cmd = new SqlCommand(sql, dbcontext);
                cmd.Parameters.AddWithValue("@id", id);
                Person p = new Person();
                try
                {
                    dbcontext.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                        p.Id = (int)reader[0];
                        p.Name =(string)reader[1];
                        p.LastName = (string)reader[2];
                        p.PayRate = (float)reader[3];
                        p.StartDate = (DateTime)reader[4];
                        p.EndDate = (DateTime)reader[5];
                        dbcontext.Close();
                 
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                return p;
            }
        }

        public IEnumerable<Person> ListAll()
        {
            List<Person> list;

            using (SqlConnection dbcontext = new SqlConnection(connectionstr)) {
                string sql = "select * from dbo.person";
                SqlCommand cmd = new SqlCommand(sql, dbcontext);
                dbcontext.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = new List<Person>();
                try {
                    while (reader.Read())
                    {
                        IDataRecord row = (IDataRecord)reader;
                        Person person = new Person();
                        person.Id = (int)row[0];
                        person.Name = (string)row[1];
                        person.LastName = (string)row[2];
                        person.PayRate = (float)row[3];
                        person.StartDate = (DateTime)row[4];
                        person.EndDate = (DateTime)row[5];
                        list.Add(person);
                        return (IEnumerable<Person>)list; 
                    }
                    reader.Close();
                } catch (SqlException ex) {
                    throw;
                }

                return (IEnumerable<Person>)list;

            }
        }

        public void Remove(int id)
        {

        }

        public bool Update(Person p)
        {
            throw new NotImplementedException();
        }
    }
}