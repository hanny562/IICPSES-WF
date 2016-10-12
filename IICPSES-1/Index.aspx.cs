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
            
            if(!IsPostBack)
            {
                BindDropDownList_Program();
            }

        }

        private void BindDropDownList_Program()
        {
            const string sql = "select Id, Name, Code, Concat(Code, ' - ', Name) as Display from [dbo].[Program]";
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    ddlSurveyProgram.DataSource = cmd.ExecuteReader();
                    ddlSurveyProgram.DataTextField = "Display";
                    ddlSurveyProgram.DataValueField = "Id";

                    ddlSurveyProgram.DataBind();
                }
            }
        }

        private DataSet BindDropDownList_Subject(int id)
        {
            string programId = ddlSurveyProgram.SelectedValue;
            string sql = "select s.Id, Concat(s.Code, ' - ', s.Name) as Display from [dbo].[Subject] s inner join [dbo].[ProgramSubject] ps on s.Id = ps.SubjectId where ps.ProgramId = @pid";

            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@pid", id);

                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();

                    da.Fill(ds);

                    return ds;
                }
            }
        }

        private DataSet BindDropDownList_Semester()
        {
            string sql = "select * from [dbo].[Semester]";

            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                using (var cmd = new SqlCommand(sql, conn))
                {
                    var da = new SqlDataAdapter(cmd);
                    var ds = new DataSet();

                    da.Fill(ds);

                    return ds;
                }
            }
        }

        protected void ddlSurveyProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            // bind the Subject DDL based on ProgramID selected
            var ddl = sender as DropDownList;
            ddlSurveySubject.DataSource = BindDropDownList_Subject(Convert.ToInt32(ddl.SelectedValue));
            ddlSurveySubject.DataTextField = "Display";
            ddlSurveySubject.DataValueField = "Id";
            ddlSurveySubject.DataBind();

            ddlSurveySemester.DataSource = BindDropDownList_Semester();
            ddlSurveySemester.DataTextField = "Name";
            ddlSurveySemester.DataValueField = "Id";
            ddlSurveySemester.DataBind();
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

        protected void btnSurveyNext_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ddlSurveyProgram.SelectedValue) || string.IsNullOrEmpty(ddlSurveySemester.SelectedValue) || string.IsNullOrEmpty(ddlSurveySubject.SelectedValue))
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
    }
    
}