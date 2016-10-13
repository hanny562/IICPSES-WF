using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Surveys
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the Control is located in the master page, so need to find control in Master
            var hyperlink = Master.FindControl("lnkCP_Surveys") as HyperLink;
            // find its parent - the <li> control
            HtmlControl hc = hyperlink.Parent as HtmlControl;
            // set the class as active for <li>
            hc.Attributes.Add("class", "active");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            {
                if (!string.IsNullOrWhiteSpace(txtQuestion.Text))
                {
                    try
                    {
                        //Role.Surveys.AddSurveyQuestion(txtQuestion.Text);

                        lblStatus_CreateQuestion.CssClass = "bg-success";
                        lblStatus_CreateQuestion.Text = "Question was added successfully!";
                    }
                    catch (Exception ex)
                    {
                        lblStatus_CreateQuestion.CssClass = "bg-danger";
                        lblStatus_CreateQuestion.Text = "Question was not added! Error: " + ex.Message;
                    }

                }
                else
                {
                    lblStatus_CreateQuestion.CssClass = "bg-danger";
                    lblStatus_CreateQuestion.Text = "Question was not added!";
                }
            }

        }
    }
}