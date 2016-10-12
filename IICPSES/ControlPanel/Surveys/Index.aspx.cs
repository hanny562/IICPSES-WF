using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IICPSES.ControlPanel.Surveys
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the Control is located in the master page, so need to find control in Master
            var hyperlink = Master.FindControl("lnkCP_Surveys") as HyperLink;
            // find its parent - the <li> control
            HtmlControl hc = hyperlink.Parent as HtmlControl;
            // set the class as active for <li>
            hc.Attributes.Add("class", "active");

            if (!IsPostBack)
            {
                BindGridView_SurveyQuestions();
            }
        }
        private void BindGridView_SurveyQuestions()
        {
            gvSurveyQuestions.DataSource = Role.Surveys.GetAllQuestion();
            gvSurveyQuestions.RowDataBound += GvSurveyQuestions_RowDataBound;
            gvSurveyQuestions.DataBind();
        }

        // RowDataBound event that controls what happens when each row is bound to the gridview
        // Purpose: to change Type to user-readability (e.g. 1 - Plain Text, 2 - Number, 3 - True/False)
        private void GvSurveyQuestions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var questionType = e.Row.Cells[3].Text;

                switch (questionType)
                {
                    case "1":
                        e.Row.Cells[3].Text = "Plain Text";
                        break;
                    case "2":
                        e.Row.Cells[3].Text = "Number";
                        break;
                    case "3":
                        e.Row.Cells[3].Text = "True/False";
                        break;
                }
            }
        }
    }
}