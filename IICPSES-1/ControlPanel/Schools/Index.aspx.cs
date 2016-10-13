using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Schools
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the Control is located in the master page, so need to find control in Master
            var hyperlink = Master.FindControl("lnkCP_Schools") as HyperLink;
            // find its parent - the <li> control
            HtmlControl hc = hyperlink.Parent as HtmlControl;
            // set the class as active for <li>
            hc.Attributes.Add("class", "active");

            if(!IsPostBack)
            {
                BindGridView_Schools();
                BindGridView_SchoolLecturers();
            }
        }

        private void BindGridView_Schools()
        {
            gvSchools.DataSource = School.GetAllSchools();
            gvSchools.DataBind();
        }

        private void BindGridView_SchoolLecturers()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select sl.Id, s.Name as SchoolName, s.Code as SchoolCode, l.Name as LecturerName from [dbo].[SchoolLecturer] sl inner join [dbo].[School] s on sl.SchoolId = s.Id inner join [dbo].[Lecturer] l on sl.LecturerId = l.Id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    gvSchoolLecturers.DataSource = cmd.ExecuteReader();
                    gvSchoolLecturers.DataBind();
                }
            }
        }
    }
}