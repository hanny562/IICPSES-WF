using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IICPSES.Role
{
    public class Semester
    {
        
        /// <summary>
        ///     Add semester info into database.
        /// </summary>
        /// <param name="name">Semester name</param>
        /// <param name="month">Semester month</param>
        /// <param name="year">Semester year</param>
        public static void AddSemester(string name, int month, int year)
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "insert into [dbo].[Semester] values (@n, @m, @y, @da)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@m", month);
                    cmd.Parameters.AddWithValue("@y", year);
                    cmd.Parameters.AddWithValue("@da", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        ///     Gets all semester records from the database.
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAllSemesters()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select * from [dbo].[Semester]";
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
        ///     Creates an association entry of semester, program subject, and lecturer
        /// </summary>
        /// <param name="semesterId"></param>
        /// <param name="programSubjectId"></param>
        /// <param name="lecturerId"></param>
        public static void AssociateSemesterSubject(int semesterId, int programSubjectId, int lecturerId)
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "insert into [dbo].[SemesterSubject] values (@sid, @psid, @lid)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@sid", semesterId);
                    cmd.Parameters.AddWithValue("@psid", programSubjectId);
                    cmd.Parameters.AddWithValue("@lid", lecturerId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}