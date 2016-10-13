using IICPSES;
using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IICPSES_1.ControlPanel.Lecturers.Manage
{
    public partial class ProgramSubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDownList_Lecturer();
                BindDropDownList_School();
            }
        }

        private void BindDropDownList_School()
        {
            string sql = "select Id, Name, Code, Concat(Code, ' - ', Name) as Display from [dbo].[School]";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    ddlSchool.DataSource = cmd.ExecuteReader();
                    ddlSchool.DataTextField = "Display";
                    ddlSchool.DataValueField = "Id";

                    ddlSchool.DataBind();
                }
            }
        }

        private void BindDropDownList_Program(int schoolId)
        {
            string sql = "select p.Id, p.Name, p.Code, Concat(p.Code, ' - ', p.Name) as Display from [dbo].[School] s inner join [dbo].[Program] p on s.Id = p.SchoolId where p.SchoolID=@id";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", schoolId);

                    ddlProgram.DataSource = cmd.ExecuteReader();
                    ddlProgram.DataTextField = "Display";
                    ddlProgram.DataValueField = "Id";

                    ddlProgram.DataBind();
                }
            }


        }

        private void BindDropDownList_Lecturer()
        {
            string sql = "select * from [dbo].[Lecturer]";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    ddlLecturer.DataSource = cmd.ExecuteReader();
                    ddlLecturer.DataTextField = "Name";
                    ddlLecturer.DataValueField = "Id";

                    ddlLecturer.DataBind();
                }
            }
        }

        private void BindCheckBoxList_Subject(int programId)
        {
            string sql = "select s.Id, s.Name, s.Code, Concat(Code, ' - ', Name) as Display from [dbo].[Subject] s inner join [dbo].[ProgramSubject] ps on ps.SubjectId = s.Id where ps.ProgramId = @pid";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", programId);

                    cblSubjects.DataSource = cmd.ExecuteReader();
                    cblSubjects.DataTextField = "Display";
                    cblSubjects.DataValueField = "Id";

                    cblSubjects.DataBind();
                }
            }
        }

        protected void btnAssociate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlLecturer.SelectedValue) || string.IsNullOrEmpty(ddlProgram.SelectedValue) || string.IsNullOrEmpty(ddlSchool.SelectedValue) || cblSubjects.SelectedItem == null)
            {
                lblSchoolLecturerProgramSubject_Status.CssClass = "text-danger";
                lblSchoolLecturerProgramSubject_Status.Text = "Please select all options before start associating.";
            }
            else
            {
                int schoolLecturerId = Lecturer.GetSchoolLecturerId(Convert.ToInt32(ddlLecturer.SelectedValue), Convert.ToInt32(ddlSchool.SelectedValue));
                var programSubjectIdList = new List<int>();

                foreach (ListItem li in cblSubjects.Items)
                {
                    if (li.Selected)
                    {
                        programSubjectIdList.Add(Lecturer.GetProgramSubjectId(Convert.ToInt32(li.Value), Convert.ToInt32(ddlProgram.SelectedValue)));
                    }
                }

                bool SLIDValid = schoolLecturerId != -1 ? true : false;
                bool PSIDValid = true;
                foreach (ListItem li in cblSubjects.Items)
                {
                    if (li.Value == "-1")
                    {
                        PSIDValid = false;
                        break;
                    }
                }

                if(SLIDValid && PSIDValid)
                {
                    // add entry to table DB
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
                    lblSchoolLecturerProgramSubject_Status.Text = "OK.";
                }
                else
                {
                    lblSchoolLecturerProgramSubject_Status.CssClass = "text-danger";
                    lblSchoolLecturerProgramSubject_Status.Text = "Error associating.";
                }
                
            }

        }

        protected void ddlLecturer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindDropDownList_Program(int.Parse(ddl.SelectedValue));
        }

        protected void ddlProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindCheckBoxList_Subject(int.Parse(ddl.SelectedValue));
        }

        protected void ddlProgram_DataBound(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindCheckBoxList_Subject(int.Parse(ddl.SelectedValue));
        }

        protected void ddlSchool_DataBound(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindDropDownList_Program(int.Parse(ddl.SelectedValue));
        }
    }

}