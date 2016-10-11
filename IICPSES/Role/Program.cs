using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IICPSES.Role
{
    public class Program
    {
        /// <summary>
        ///     Add program into database.
        /// </summary>
        /// <param name="name">Program name</param>
        /// <param name="code">Program code</param>
        /// <param name="schoolId">School ID</param>
        public static void AddProgram(string name, string code, int schoolId)
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "insert into [dbo].[Program] values (@n, @c, @sid, @da)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@c", code);
                    cmd.Parameters.AddWithValue("@sid", schoolId);
                    cmd.Parameters.AddWithValue("@da", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        ///     Gets all program records from database.
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAllPrograms()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select * from [dbo].[Program]";
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