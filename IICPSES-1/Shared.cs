using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace IICPSES
{
    public class Shared
    {
        /// <summary>
        ///     Gets the connection string used to connect to the SQL Server database
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["IICPSES"].ConnectionString;
        }
    }
}