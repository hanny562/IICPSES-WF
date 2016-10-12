using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Programs.Manage
{
    public partial class Subject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the Control is located in the master page, so need to find control in Master
            var hyperlink = Master.FindControl("lnkCP_ProgramSubject") as HyperLink;
            // find its parent - the <li> control
            HtmlControl hc = hyperlink.Parent as HtmlControl;
            // set the class as active for <li>
            hc.Attributes.Add("class", "active");

            if(!IsPostBack)
            {
                BindDropDownList_Programs();
                BindCheckBoxList_Subject();
            }
        }

        private void BindDropDownList_Programs()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select Id, Name, Code, Concat(Code, ' - ', Name) as Display from [dbo].[Program]";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    ddlProgram.DataSource = cmd.ExecuteReader();
                    ddlProgram.DataTextField = "Display";
                    ddlProgram.DataValueField = "Id";

                    ddlProgram.DataBind();
                    
                }
            }
        }

        private void BindCheckBoxList_Subject()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select Id, Name, Code, Concat(Code, ' - ', Name) as Display from [dbo].[Subject]";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cblSubjects.DataSource = cmd.ExecuteReader();
                    cblSubjects.DataTextField = "Display";
                    cblSubjects.DataValueField = "Id";

                    cblSubjects.DataBind();
                }
            }
        }

        protected void btnAssociateProgramSubjects_Click(object sender, EventArgs e)
        {
            if(!(string.IsNullOrWhiteSpace(ddlProgram.SelectedValue) || string.IsNullOrWhiteSpace(cblSubjects.SelectedValue)))
            {
                foreach(ListItem li in cblSubjects.Items)
                {
                    if(li.Selected)
                    {
                        Program.AssociateProgramSubject(Convert.ToInt32(ddlProgram.SelectedValue), Convert.ToInt32(li.Value));
                    }
                }

                lblProgramSubject_Status.Text = "Selected subject(s) have been associated with program " + ddlProgram.SelectedItem.Text;
            }
            else
            {
                lblProgramSubject_Status.Text = "Association failed! Please select at least one subject to begin association.";
            }
        }
    }
}