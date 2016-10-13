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

            if (!IsPostBack)
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

                string sql = "select sch.Code as SchoolCode, sch.Name as SchoolName, lec.Name as LecturerName, prg.Code as ProgramCode, prg.Name as ProgramName, sub.Code as SubjectCode, sub.Name as SubjectName from [dbo].[SemesterSubject] ss " +
                            "inner join[dbo].[SchoolLecturerProgramSubject] slps on ss.SchoolLecturerProgramSubjectId = slps.Id " +
                            "inner join[dbo].[SchoolLecturer] sl on slps.SchoolLecturerId = sl.Id " +
                            "inner join[dbo].[ProgramSubject] ps on slps.ProgramSubjectId = ps.Id " +
                            "inner join[dbo].[School] sch on sch.Id = sl.SchoolId " +
                            "inner join[dbo].[Lecturer] lec on lec.Id = sl.LecturerId " +
                            "inner join[dbo].[Program] prg on prg.Id = ps.ProgramId " +
                            "inner join[dbo].[Subject] sub on sub.Id = ps.SubjectId ";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    gvSemesterSubjects.DataSource = cmd.ExecuteReader();
                    gvSemesterSubjects.DataBind();
                }
            }
        }
    }
}