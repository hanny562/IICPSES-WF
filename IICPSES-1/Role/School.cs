using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IICPSES.Role
{
    public class School
    {
        /// <summary>
        ///     Get all school records from database.
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAllSchools()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select * from [dbo].[School]";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();

                    da.Fill(ds);

                    return ds;
                }
            }
        }

        /// <summary>
        ///     Adds the school into the database.
        /// </summary>
        /// <param name="name">School name</param>
        /// <param name="code">School code</param>
        public static void AddSchool(string name, string code)
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "insert into [dbo].[School] values (@n, @c, @da)";
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
        ///     Associate the lecturer with selected school
        /// </summary>
        /// <param name="schoolId">School ID</param>
        /// <param name="lecturerId">Lecturer ID</param>
        public static void AssociateSchoolLecturer(int schoolId, int lecturerId)
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "insert into [dbo].[SchoolLecturer] values (@lid, @sid)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@lid", lecturerId);
                    cmd.Parameters.AddWithValue("@sid", schoolId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}