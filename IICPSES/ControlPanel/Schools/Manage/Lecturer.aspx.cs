using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Schools.Manage
{
    public partial class Lecturer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the Control is located in the master page, so need to find control in Master
            var hyperlink = Master.FindControl("lnkCP_SchoolLecturer") as HyperLink;
            // find its parent - the <li> control
            HtmlControl hc = hyperlink.Parent as HtmlControl;
            // set the class as active for <li>
            hc.Attributes.Add("class", "active");

            if(!IsPostBack)
            {
                BindDropDownList_School();
                BindCheckBoxList_Lecturers();
            }

        }

        private void BindDropDownList_School()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select Id, Name, Code, Concat(Code, ' - ', Name) as Display from [dbo].[School]";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    ddlSchool.DataSource = cmd.ExecuteReader();
                    ddlSchool.DataTextField = "Display";
                    ddlSchool.DataValueField = "Id";

                    ddlSchool.DataBind();
                }
            }
        }

        private void BindCheckBoxList_Lecturers()
        {
            cblLecturers.DataSource = Role.Lecturer.GetAllLecturers();
            cblLecturers.DataTextField = "Name";
            cblLecturers.DataValueField = "Id";
            cblLecturers.DataBind();
        }

        protected void btnAssociateSchoolLecturers_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(ddlSchool.SelectedValue) || cblLecturers.SelectedItem == null)
            {
                lblSchoolLecturer_Status.Text = "has empty";
            }
            else
            {
                foreach(ListItem li in cblLecturers.Items)
                {
                    if(li.Selected)
                    {
                        School.AssociateSchoolLecturer(Convert.ToInt32(ddlSchool.SelectedValue), Convert.ToInt32(li.Value));
                    }
                }

                lblSchoolLecturer_Status.Text = "Selected lecturer(s) have been associated to school " + ddlSchool.SelectedItem.Text;
            }
        }
    }
}