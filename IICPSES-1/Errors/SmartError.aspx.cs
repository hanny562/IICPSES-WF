using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IICPSES.Errors
{
    public partial class SmartError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string err = string.Empty;
            string title = string.Empty;
            string description = string.Empty;

            if (Request.QueryString["err"] != null)
            {
                err = Request.QueryString["err"];                
            }

            switch (err)
            {
                case "403":
                    title = "403 Not Found";
                    description = "The page or resource specified was not authorized to be viewed.";
                    break;
                case "404":
                    title = "404 Not Found";
                    description = "The page or resource specified was not found.";
                    break;
                default:
                    title = "Unknown error";
                    description = "Please check and try again. If this issue persists, please contact the system administrator.";
                    break;
            }
        }
    }
}