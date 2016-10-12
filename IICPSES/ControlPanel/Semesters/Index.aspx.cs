using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Semesters
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the Control is located in the master page, so need to find control in Master
            var hyperlink = Master.FindControl("lnkCP_Semesters") as HyperLink;
            // find its parent - the <li> control
            HtmlControl hc = hyperlink.Parent as HtmlControl;
            // set the class as active for <li>
            hc.Attributes.Add("class", "active");

            if(!IsPostBack)
            {
                BindGridView_Semester();
                BindGridView_SemesterSubjects();
            }
        }

        private void BindGridView_Semester()
        {
            gvSemesters.DataSource = Semester.GetAllSemesters();
            gvSemesters.DataBind();
        }

        private void BindGridView_SemesterSubjects()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select ss.Id, s.Name as SemesterName, p.Code as ProgramCode, p.Name as ProgramName, su.Code as SubjectCode, su.Name as SubjectName, sc.Code as SchoolCode, sc.Name as SchoolName, le.Name as LecturerName from [dbo].[SemesterSubject] ss " +
                        "inner join[dbo].[Semester] s on ss.SemesterId = s.Id " +
                        "inner join[dbo].[ProgramSubject] ps on ss.ProgramSubjectId = ps.Id " +
                        "inner join[dbo].[Program] p on p.Id = ps.ProgramId " +
                        "inner join[dbo].[Subject] su on su.Id = ps.SubjectId " +
                        "inner join[dbo].[SchoolLecturer] sl on ss.LecturerId = sl.Id " +
                        "inner join[dbo].[School] sc on sc.Id = sl.SchoolId " +
                        "inner join[dbo].[Lecturer] le on le.Id = sl.LecturerId";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    gvSemesterSubjects.DataSource = cmd.ExecuteReader();
                    gvSemesterSubjects.DataBind();
                }
            }
        }
    }
}