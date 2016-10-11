using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Programs
{
    public partial class create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the Control is located in the master page, so need to find control in Master
            var hyperlink = Master.FindControl("lnkCP_Programs") as HyperLink;
            // find its parent - the <li> control
            HtmlControl hc = hyperlink.Parent as HtmlControl;
            // set the class as active for <li>
            hc.Attributes.Add("class", "active");

            BindDropDownList_School();
        }

        private void BindDropDownList_School()
        {
            using (var conn = new SqlConnection(Shared.GetConnectionString()))
            {
                conn.Open();

                string sql = "select Id, Name, Code, Concat (Code, ' - ', Name) as Display from [dbo].[School]";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    ddlSchools.DataSource = cmd.ExecuteReader();
                    ddlSchools.DataValueField = "Id";
                    ddlSchools.DataTextField = "Display";
                    ddlSchools.DataBind();
                }
            }
        }

        protected void btnCreateProgram_Click(object sender, EventArgs e)
        {
            if(!(string.IsNullOrWhiteSpace(txtProgramCode.Text) && string.IsNullOrWhiteSpace(txtProgramName.Text) && string.IsNullOrWhiteSpace(ddlSchools.SelectedValue)))
            {
                try
                {
                    // int.Parse is used instead of Convert.ToInt32 to prevent exception being thrown
                    Program.AddProgram(txtProgramName.Text, txtProgramCode.Text, Convert.ToInt32(ddlSchools.SelectedValue));
                    lblStatus_CreateProgram.Text = "Program added successfully!";
                }
                catch (Exception ex)
                {
                    lblStatus_CreateProgram.Text = ex.ToString();
                }
            }
            else
            {
                
            }
        }
    }
}