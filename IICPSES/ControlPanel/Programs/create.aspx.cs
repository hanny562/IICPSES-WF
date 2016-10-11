using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Programs
{
    public partial class create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncreate_Click(object sender, EventArgs eventArgs)
        {
            Response.Redirect("create.aspx");
        }
    }
}