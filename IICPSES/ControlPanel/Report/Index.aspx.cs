using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Report
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void BindDropDownList_Programs()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select Id, Name, Code, Concat(Code, ' - ', Name) as Display from [dbo].[Program]";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    //ddlProgram.DataSource = cmd.ExecuteReader();
                    //ddlProgram.DataTextField = "Display";
                    //ddlProgram.DataValueField = "Id";

                    //ddlProgram.DataBind();

                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChartReport.aspx");
        }
    }
}