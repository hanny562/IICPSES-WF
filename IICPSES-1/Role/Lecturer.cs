using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IICPSES.Role
{
    public class Lecturer
    {
        /// <summary>
        ///     Adds the lecturer
        /// </summary>
        /// <param name="name"></param>
        public static void AddLecturer(string name)
        {
            // Creates a SqlConnection object to connect to SQL Server
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                // opens the connection
                conn.Open();

                // defines the SQL query to insert name into table
                string sql = "insert into [dbo].[Lecturer] values (@name, @dt)";

                // creates the SqlCommand object to establish connection and execute query
                using (var cmd = new SqlCommand(sql, conn))
                {
                    // pass the name value as parameter - to avoid SQL injection
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@dt", DateTime.Now);

                    // finally, execute the query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EditLecturer(int id, string name)
        {
            string sql = "update [dbo].[Lecturer] set Name=@name where Id=@id";

            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteLecturer(int id)
        {
            string sql = "delete from [dbo].[Lecturer] where Id=@id";

            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static string GetLecturerName(int id)
        {
            string sql = "select Name from [dbo].[Lecturer] where Id=@id";
            string name = string.Empty;

            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if(rdr.Read())
                        {
                            name = rdr[0].ToString();
                        }
                    }
                }
            }

            return name;
        }

        public static DataSet GetAllLecturers()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand("select * from [dbo].Lecturer", conn))
                {
                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();

                    da.Fill(ds);

                    return ds;
                }
            }
        }
    }
}