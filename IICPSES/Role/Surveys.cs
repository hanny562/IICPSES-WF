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
        ///     Adds the Question
        /// </summary>
        /// <param question="question"></param>
        /// <param name="question"></param>
        public static void AddSurveyQuestion(string question)
        {
            // Creates a SqlConnection object to connect to SQL Server
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                // opens the connection
                conn.Open();

                // defines the SQL query to insert name into table
                string sql = "insert into [dbo].[Question] values (@question, @dt)";

                // creates the SqlCommand object to establish connection and execute query
                using (var cmd = new SqlCommand(sql, conn))
                {
                    // pass the name value as parameter - to avoid SQL injection
                    cmd.Parameters.AddWithValue("@question", question);
                    cmd.Parameters.AddWithValue("@dt", DateTime.Now);

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