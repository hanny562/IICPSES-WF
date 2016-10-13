using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Programs
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the Control is located in the master page, so need to find control in Master
            var hyperlink = Master.FindControl("lnkCP_Programs") as HyperLink;
            // find its parent - the <li> control
            HtmlControl hc = hyperlink.Parent as HtmlControl;
            // set the class as active for <li>
            hc.Attributes.Add("class", "active");

            if (!IsPostBack)
            {
                BindGridView_Programs();
                BindGridView_ProgramSubjects();
            }
        }

        private void BindGridView_Programs()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select p.Id, p.Name, p.Code as ProgramCode, s.Code as SchoolCode, p.DateAdded from [dbo].[Program] p inner join [dbo].[School] s on p.SchoolId = s.Id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    gvPrograms.DataSource = cmd.ExecuteReader();
                    gvPrograms.DataBind();
                }
            }
        }

        private void BindGridView_ProgramSubjects()
        {
            gvProgramSubjects.DataSource = Program.GetAllProgramSubjects();
            gvProgramSubjects.DataBind();
        }
    }
}