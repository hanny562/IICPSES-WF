using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindDropDownList_School();
            }

        }


        /// <summary>
        ///     Bind School DDL
        /// </summary>
        private void BindDropDownList_School()
        {
            string sql = "select Id, Name, Code, Concat(Code, ' - ', Name) as Display from [dbo].[School]";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    ddlSurveySchool.DataSource = cmd.ExecuteReader();
                    ddlSurveySchool.DataTextField = "Display";
                    ddlSurveySchool.DataValueField = "Id";

                    ddlSurveySchool.DataBind();
                }
            }
        }

        /// <summary>
        ///     Bind Program DDL based on School ID
        /// </summary>
        /// <param name="schoolId"></param>
        private void BindDropDownList_Program(int schoolId)
        {
            string sql = "select Id, Name, Code, Concat(Code, ' - ', Name) as Display from [dbo].[Program] where SchoolID=@sid";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@sid", schoolId);

                    ddlSurveyProgram.DataSource = cmd.ExecuteReader();
                    ddlSurveyProgram.DataTextField = "Display";
                    ddlSurveyProgram.DataValueField = "Id";

                    ddlSurveyProgram.DataBind();
                }
            }
        }

        private void BindDropDownList_Subject(int programId)
        {
            string sql = "select s.Id, s.Code, s.Name, Concat(s.Code, ' - ', s.Name) as Display from [dbo].[ProgramSubject] ps inner join [dbo].[Subject] s on ps.SubjectId = s.Id where ProgramId = @pid";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", programId);

                    ddlSurveySubject.DataSource = cmd.ExecuteReader();
                    ddlSurveySubject.DataTextField = "Display";
                    ddlSurveySubject.DataValueField = "Id";

                    ddlSurveySubject.DataBind();

                }
            }
        }

        private void BindDropDownList_Lecturer(int programId, int subjectId)
        {

            int programSubjectId = -1;
            string sqlSelectProgramSubject = "select Id from [dbo].[ProgramSubject] where ProgramId=@pid and SubjectId=@sid";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sqlSelectProgramSubject, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", programId);
                    cmd.Parameters.AddWithValue("@sid", subjectId);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            programSubjectId = Convert.ToInt32(rdr[0].ToString());
                        }
                    }
                }
            }

            string sqlSelectLecturerName = "select l.Id, l.Name from [dbo].[SchoolLecturerProgramSubject] slps inner join [dbo].[SchoolLecturer] sl on sl.Id = slps.SchoolLecturerId inner join [dbo].[Lecturer] l on l.Id = sl.LecturerId where slps.ProgramSubjectId = @psid";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sqlSelectLecturerName, conn))
                {
                    cmd.Parameters.AddWithValue("@psid", programSubjectId);

                    ddlSurveyLecturer.DataSource = cmd.ExecuteReader();
                    ddlSurveyLecturer.DataTextField = "Name";
                    ddlSurveyLecturer.DataValueField = "Id";

                    ddlSurveyLecturer.DataBind();
                }
            }



        }

        private void BindDropDownList_Semester()
        {
            string sql = "select * from [dbo].[Semester]";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    ddlSurveySemester.DataSource = cmd.ExecuteReader();
                    ddlSurveySemester.DataTextField = "Name";
                    ddlSurveySemester.DataValueField = "Id";
                    ddlSurveySemester.DataBind();
                }
            }
        }



        protected void ddlSurveyProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindDropDownList_Subject(Convert.ToInt32(ddl.SelectedValue));
        }


        protected void btnSurveyNext_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlSurveyProgram.SelectedValue) || string.IsNullOrEmpty(ddlSurveySemester.SelectedValue) || string.IsNullOrEmpty(ddlSurveySubject.SelectedValue))
            {
                lblSurvey_Status.CssClass = "text-danger";
                lblSurvey_Status.Text = "Please select all options before continue.";
            }
            else
            {
                int programId = Convert.ToInt32(ddlSurveyProgram.SelectedValue);
                int semesterId = Convert.ToInt32(ddlSurveySemester.SelectedValue);
                int subjectId = Convert.ToInt32(ddlSurveySubject.SelectedValue);

                int programSubjectId = -1;
                int semesterSubjectId = -1;

                // get the programSubjectId based on programId and subjectId - must make sure it is valid!
                programSubjectId = GetProgramSubjectId(subjectId, programId);

                // get the semesterSubjectId based on semesterId, programSubjectId, and 

                if (programSubjectId == -1)
                {

                }
                else
                {

                }
            }
        }

        protected void ddlSurveySchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindDropDownList_Program(Convert.ToInt32(ddl.SelectedValue));
        }

        protected void ddlSurveySchool_DataBound(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindDropDownList_Program(Convert.ToInt32(ddl.SelectedValue));
        }

        protected void ddlSurveySubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindDropDownList_Subject(Convert.ToInt32(ddl.SelectedValue));
        }

        protected void ddlSurveySubject_DataBound(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindDropDownList_Subject(Convert.ToInt32(ddl.SelectedValue));
        }

        protected void ddlSurveyProgram_DataBound(object sender, EventArgs e)
        {
            var ddl = sender as DropDownList;
            BindDropDownList_Subject(Convert.ToInt32(ddl.SelectedValue));
        }

        protected void ddlSurveyLecturer_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDropDownList_Semester();
        }

        protected void ddlSurveyLecturer_DataBound(object sender, EventArgs e)
        {
            BindDropDownList_Semester();
        }

        private int GetProgramSubjectId(int subjectId, int programId)
        {
            string sql = "select Id from [dbo].[ProgramSubject] where SubjectID=@sid and ProgramID=@pid";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@sid", subjectId);
                    cmd.Parameters.AddWithValue("@pid", programId);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            return Convert.ToInt32(rdr[0].ToString());
                        }
                    }
                }
            }
            return -1;
        }

        private int GetSchoolLecturerId(int schoolId, int lecturerId)
        {
            string sql = "select Id from [dbo].[SchoolLecturer] where SchoolId=@sid and LecturerId=@lid";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@sid", schoolId);
                    cmd.Parameters.AddWithValue("@lid", lecturerId);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            return Convert.ToInt32(rdr[0].ToString());
                        }
                    }
                }
            }
            return -1;
        }

    }

}