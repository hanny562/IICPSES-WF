using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Semesters.Manage
{
    public partial class Subject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the Control is located in the master page, so need to find control in Master
            var hyperlink = Master.FindControl("lnkCP_SemesterSubject") as HyperLink;
            // find its parent - the <li> control
            HtmlControl hc = hyperlink.Parent as HtmlControl;
            // set the class as active for <li>
            hc.Attributes.Add("class", "active");

            if (!IsPostBack)
            {
                BindDropDownList_Semester();
                BindDropDownList_SchoolLecturer();
            }
        }

        private void BindDropDownList_Semester()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select * from [dbo].[Semester]";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    ddlSemester.DataSource = cmd.ExecuteReader();
                    ddlSemester.DataTextField = "Name";
                    ddlSemester.DataValueField = "Id";

                    ddlSemester.DataBind();
                }
            }
        }


        private void BindDropDownList_SchoolLecturer()
        {
            string sql = "select sl.Id, s.Code, l.Name, Concat(s.Code, ' - ', l.Name) as Display from [dbo].[SchoolLecturer] sl inner join [dbo].[School] s on sl.SchoolId=s.Id inner join [dbo].[Lecturer] l on sl.LecturerId = l.Id";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    ddlSchoolLecturers.DataSource = cmd.ExecuteReader();
                    ddlSchoolLecturers.DataTextField = "Display";
                    ddlSchoolLecturers.DataValueField = "Id";
                    ddlSchoolLecturers.DataBind();
                }
            }
        }

        private void BindDropDownList_ProgramSubjects(int schoolLecturerId)
        {
            string sql = "select ps.Id, p.Code, s.Code, Concat(p.Code, ' - ', s.Code) as Display from [dbo].[ProgramSubject] ps inner join [dbo].[Program] p on ps.ProgramId = p.Id inner join [dbo].[Subject] s on ps.SubjectId = s.Id where ps.Id = @id";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", schoolLecturerId);

                    ddlProgramSubject.DataSource = cmd.ExecuteReader();
                    ddlProgramSubject.DataTextField = "Display";
                    ddlProgramSubject.DataValueField = "Id";
                    ddlProgramSubject.DataBind();
                }
            }
        }

        protected void btnCreateSemesterSubject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlProgramSubject.SelectedValue) || string.IsNullOrEmpty(ddlSchoolLecturers.SelectedValue) || string.IsNullOrEmpty(ddlSemester.SelectedValue))
            {
                lblSemesterSubject_Status.CssClass = "text-danger";
                lblSemesterSubject_Status.Text = "Please select all options before begin associating.";

            }
            else
            {
                int schoolLecturerProgramSubjectId = -1;

                // gets the SchoolLecturerProgramSubject ID
                string sql = "select Id from [dbo].[SchoolLecturerProgramSubject] where SchoolLecturerID=@slid and ProgramSubjectID=@psid";
                using (var conn = new SqlConnection(Shared.GetConnectionString()))
                {
                    conn.Open();

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@slid", ddlSchoolLecturers.SelectedValue);
                        cmd.Parameters.AddWithValue("@psid", ddlProgramSubject.SelectedValue);

                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                schoolLecturerProgramSubjectId = Convert.ToInt32(rdr[0].ToString());
                            }
                        }
                    }
                }

                if (schoolLecturerProgramSubjectId == -1)
                {
                    lblSemesterSubject_Status.CssClass = "text-danger";
                    lblSemesterSubject_Status.Text = "Error associating.";
                }
                else
                {
                    // insert entry into SemesterSubject table
                    sql = "insert into [dbo].[SemesterSubject] values (@sid, @slpsid)";
                    using (var conn = new SqlConnection(Shared.GetConnectionString()))
                    {
                        conn.Open();

                        using (var cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@sid", Convert.ToInt32(ddlSemester.SelectedValue));
                            cmd.Parameters.AddWithValue("@slpsid", schoolLecturerProgramSubjectId);

                            cmd.ExecuteNonQuery();
                        }
                    }


                    lblSemesterSubject_Status.CssClass = "text-success";
                    lblSemesterSubject_Status.Text = "OK.";
                }
            }

        }

        protected void ddlSchoolLecturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindDropDownList_ProgramSubjects(Convert.ToInt32(ddl.SelectedValue));
        }

        protected void ddlSchoolLecturers_DataBound(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindDropDownList_ProgramSubjects(Convert.ToInt32(ddl.SelectedValue));
        }
    }
}