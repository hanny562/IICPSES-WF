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
                BindDropDownList_ProgramSubject();
                BindDropDownList_Lecturer();
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

        private void BindDropDownList_ProgramSubject()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select ps.Id, p.Code as ProgramCode, s.Code as SubjectCode, Concat(p.Code, ' - ', s.Code) as Display from [dbo].[ProgramSubject] ps inner join [dbo].[Subject] s on ps.SubjectId = s.Id inner join [dbo].[Program] p on ps.ProgramId = p.Id";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    ddlProgramSubject.DataSource = cmd.ExecuteReader();

                    ddlProgramSubject.DataTextField = "Display";
                    ddlProgramSubject.DataValueField = "Id";

                    ddlProgramSubject.DataBind();
                }
            }
        }

        private void BindDropDownList_Lecturer()
        {
            ddlLecturer.DataSource = Role.Lecturer.GetAllLecturers();
            ddlLecturer.DataTextField = "Name";
            ddlLecturer.DataValueField = "Id";
            ddlLecturer.DataBind();
        }

        protected void btnCreateSemesterSubject_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(ddlSemester.SelectedValue) || string.IsNullOrWhiteSpace(ddlProgramSubject.SelectedValue) || string.IsNullOrWhiteSpace(ddlLecturer.SelectedValue))
            {
                lblSemesterSubject_Status.Text = "has empty";
            }
            else
            {
                Semester.AssociateSemesterSubject(Convert.ToInt32(ddlSemester.SelectedValue), Convert.ToInt32(ddlProgramSubject.SelectedValue), Convert.ToInt32(ddlLecturer.SelectedValue));
                lblSemesterSubject_Status.Text = "Semester subject association has been created successfully.";
            }
        }
    }
}