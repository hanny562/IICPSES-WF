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

        public static void AddSchool(string name, string code)
        {

        }
    }
}