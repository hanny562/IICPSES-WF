using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace IICPSES.Role
{
    public class Surveys
    {
        /// <summary>
        ///     Adds the survey question into database
        /// </summary>
        /// <param name="title">Question title</param>
        /// <param name="description">Question description</param>
        /// <param name="type">Question type</param>
        public static void AddSurveyQuestion(string title, string description, int type)
        {
            // Creates a SqlConnection object to connect to SQL Server
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                // opens the connection
                conn.Open();

                // defines the SQL query to insert name into table
                string sql = "insert into [dbo].[Question] values (@title, @desc, @type)";

                // creates the SqlCommand object to establish connection and execute query
                using (var cmd = new SqlCommand(sql, conn))
                {
                    // pass the name value as parameter - to avoid SQL injection
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@type", type);

                    // finally, execute the query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet GetAllQuestion()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand("select * from [dbo].Question", conn))
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