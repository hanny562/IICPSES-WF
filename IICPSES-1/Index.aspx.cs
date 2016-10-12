using IICPSES.Role;
using System;
using System.Collections.Generic;
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
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                const string sql3 = "select ps.Id, p.Code as ProgramCode from [dbo].[ProgramSubject] ps inner join [dbo].[Program] p on ps.ProgramId = p.Id";
                using (var cmd3 = new SqlCommand(sql3, conn))
                {
                    ddlSurveyProgram.DataSource = cmd3.ExecuteReader();
                    ddlSurveyProgram.DataTextField = "ProgramCode";
                    ddlSurveyProgram.DataValueField = "Id";
                    ddlSurveyProgram.DataBind();
                }
                ddlSurveyProgram.Items.Insert(0, new ListItem("Please Select Program", "0"));

                const string sql = "select ps.Id, s.Code as SubjectCode from [dbo].[ProgramSubject] ps inner join [dbo].[Subject] s on ps.SubjectId = s.Id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    ddlSurveySubject.DataSource = cmd.ExecuteReader();
                    ddlSurveySubject.DataTextField = "SubjectCode";
                    ddlSurveySubject.DataValueField = "Id";
                    ddlSurveySubject.DataBind();
                }
                ddlSurveySubject.Items.Insert(0, new ListItem("Plesae Select Sbuject", "0"));

                //const string sql2 = "select ps.Id, se.Name as SemesterCode from [dbo].[ProgramSubject] ps inner join [dbo].[Semester] se on ps.SemesterId = se.Id";
                //using (var cmd2 = new SqlCommand(sql2, conn))
                //{
                //    ddlSurveySemester.DataSource = cmd2.ExecuteReader();
                //    ddlSurveySemester.DataTextField = "SemesterCode";
                //    ddlSurveySemester.DataValueField = "Id";
                //    ddlSurveySemester.DataBind();
                //}
                //ddlSurveySemester.Items.Insert(0, new ListItem("Plesae Select Semester", "0"));
            }

        }
    }
}