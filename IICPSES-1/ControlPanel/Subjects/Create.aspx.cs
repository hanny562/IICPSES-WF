using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Subjects
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the Control is located in the master page, so need to find control in Master
            var hyperlink = Master.FindControl("lnkCP_Subjects") as HyperLink;
            // find its parent - the <li> control
            HtmlControl hc = hyperlink.Parent as HtmlControl;
            // set the class as active for <li>
            hc.Attributes.Add("class", "active");
        }

        protected void btnCreateSubject_Click(object sender, EventArgs e)
        {
            if(!(string.IsNullOrWhiteSpace(txtSubjectCode.Text) && string.IsNullOrWhiteSpace(txtSubjectName.Text)))
            {
                try
                {
                    Subject.AddSubject(txtSubjectName.Text, txtSubjectCode.Text);
                    lblStatus_CreateSubject.Text = "Subject successfully created!";
                }
                catch(Exception ex)
                {
                    lblStatus_CreateSubject.Text = ex.ToString();
                }
            }
        }
    }
}