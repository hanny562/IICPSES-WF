using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Report
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void BindDropDownList_Programs()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))

            {
                conn.Open();

                const string sql3 = "select ps.Id, p.Code as ProgramCode from [dbo].[ProgramSubject] ps inner join [dbo].[Program] p on ps.ProgramId = p.Id";
                using (var cmd3 = new SqlCommand(sql3, conn))
                {
                    ddlLecturerReport.DataSource = cmd3.ExecuteReader();
                    ddlLecturerReport.DataTextField = "ProgramCode";
                    ddlLecturerReport.DataValueField = "Id";
                    ddlLecturerReport.DataBind();
                }

                const string sql = "select ps.Id, l.Name as LecturerName from [dbo].[ProgramSubject] ps inner join [dbo].[Lecturer] l on ps.LecturerID = l.Id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    ddlLecturerReport.DataSource = cmd.ExecuteReader();
                    ddlLecturerReport.DataTextField = "LecturerName";
                    ddlLecturerReport.DataValueField = "Id";
                    ddlLecturerReport.DataBind();
                }

                const string sql2 = "select ps.Id, s.Code as SubjectCode from [dbo].[ProgramSubject] ps inner join [dbo].[Subject] s on ps.SubjectId = s.Id";
                using (var cmd2 = new SqlCommand(sql2, conn))
                {
                    ddlSubjectReport.DataSource = cmd2.ExecuteReader();
                    ddlSubjectReport.DataTextField = "DisplaySubject";
                    ddlSubjectReport.DataValueField = "Id";

                    ddlSubjectReport.DataBind();

                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChartReport.aspx");
        }
    }
}