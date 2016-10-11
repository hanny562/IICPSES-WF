using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IICPSES.Role
{
    public class Subject
    {
        /// <summary>
        ///     Adds the subject into the database.
        /// </summary>
        /// <param name="name">Subject name</param>
        /// <param name="code">Subject code</param>
        public static void AddSubject(string name, string code)
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "insert into [dbo].[Subject] values (@n, @c, @da)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@c", code);
                    cmd.Parameters.AddWithValue("@da", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        ///     Gets all subject records from the database.
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAllSubjects()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select * from [dbo].[Subject]";
                using (var cmd = new SqlCommand(sql, conn))
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