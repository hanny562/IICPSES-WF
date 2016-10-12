using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Lecturers
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the Control is located in the master page, so need to find control in Master
            var hyperlink = Master.FindControl("lnkCP_Lecturers") as HyperLink;
            // find its parent - the <li> control
            HtmlControl hc = hyperlink.Parent as HtmlControl;
            // set the class as active for <li>
            hc.Attributes.Add("class", "active");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtName.Text))
            {
                try
                {
                    Lecturer.AddLecturer(txtName.Text);

                    lblStatus_CreateLecturer.CssClass = "bg-success";
                    lblStatus_CreateLecturer.Text = "Lecturer was added successfully!";
                }
                catch(Exception ex)
                {
                    lblStatus_CreateLecturer.CssClass = "bg-danger";
                    lblStatus_CreateLecturer.Text = "Lecturer was not added! Error: " + ex.Message;
                }
                
            }
            else
            {
                lblStatus_CreateLecturer.CssClass = "bg-danger";
                lblStatus_CreateLecturer.Text = "Lecturer was not added!";
            }
        }

            
    }
}