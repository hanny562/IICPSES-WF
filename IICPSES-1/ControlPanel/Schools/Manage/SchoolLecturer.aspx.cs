using IICPSES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IICPSES_1.ControlPanel.Schools.Manage
{
    public partial class SchoolLecturer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList_SchoolLecturer();
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

        private void BindCheckBoxList_ProgramSubjects(int schoolLecturerId)
        {
            string sql = "select ps.Id, p.Code, s.Code, Concat(p.Code, ' - ', s.Code) as Display from [dbo].[ProgramSubject] ps inner join [dbo].[Program] p on ps.ProgramId = p.Id inner join [dbo].[Subject] s on ps.SubjectId = s.Id where ps.Id = @id";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", schoolLecturerId);

                    cblProgramSubjects.DataSource = cmd.ExecuteReader();
                    cblProgramSubjects.DataTextField = "Display";
                    cblProgramSubjects.DataValueField = "Id";
                    cblProgramSubjects.DataBind();
                }
            }
        }

        protected void ddlSchoolLecturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindCheckBoxList_ProgramSubjects(Convert.ToInt32(ddl.SelectedValue));
        }

        protected void ddlSchoolLecturers_DataBound(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindCheckBoxList_ProgramSubjects(Convert.ToInt32(ddl.SelectedValue));
        }

        protected void btnAssociate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlSchoolLecturers.SelectedValue) || cblProgramSubjects.SelectedItem == null)
            {
                lblSchoolLecturerProgramSubject_Status.CssClass = "text-danger";
                lblSchoolLecturerProgramSubject_Status.Text = "Unable to associate. Please ensure all options are selected.";
            }
            else
            {
                int schoolLecturerId = Convert.ToInt32(ddlSchoolLecturers.SelectedValue);
                var programSubjectIdList = new List<int>();

                // add selected CheckBoxList items
                foreach (ListItem li in cblProgramSubjects.Items)
                {
                    if (li.Selected)
                    {
                        programSubjectIdList.Add(Convert.ToInt32(li.Value));
                    }
                }

                // insert values into table
                string sql = "insert into [dbo].[SchoolLecturerProgramSubject] values (@slid, @psid)";
                using (var conn = new SqlConnection(Shared.GetConnectionString()))
                {
                    conn.Open();

                    foreach (var i in programSubjectIdList)
                    {
                        using (var cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@slid", schoolLecturerId);
                            cmd.Parameters.AddWithValue("@psid", i);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                lblSchoolLecturerProgramSubject_Status.CssClass = "text-success";
                lblSchoolLecturerProgramSubject_Status.Text = "OK";
            }
        }
    }
}