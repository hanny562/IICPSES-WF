using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Surveys.Questions
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

        protected void btnCreateSurveyQuestion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuestionDescription.Text) || string.IsNullOrWhiteSpace(txtQuestionTitle.Text) || string.IsNullOrWhiteSpace(ddlQuestionType.SelectedValue))
            {

            }
            else
            {
                try
                {
                    Role.Surveys.AddSurveyQuestion(txtQuestionTitle.Text, txtQuestionDescription.Text, Convert.ToInt32(ddlQuestionType.SelectedValue));
                    lblQuestion_Status.Text = "Question has been added successfully!";
                }
                catch (Exception ex)
                {
                    lblQuestion_Status.Text = ex.ToString();
                }

            }
        }
    }
}