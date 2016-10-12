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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the Control is located in the master page, so need to find control in Master
            var hyperlink = Master.FindControl("lnkCP_Lecturers") as HyperLink;
            // find its parent - the <li> control
            HtmlControl hc = hyperlink.Parent as HtmlControl;
            // set the class as active for <li>
            hc.Attributes.Add("class", "active");

            if(!IsPostBack)
            {
                BindGridView_Lecturers();
            }
            
        }

        private void BindGridView_Lecturers()
        {
            gvLecturers.DataSource = Lecturer.GetAllLecturers();
            gvLecturers.DataBind();
        }

        protected void gvLecturers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                var gv = sender as GridView;

                var edit = e.Row.FindControl("hlLecturer_Edit") as HyperLink;
                edit.NavigateUrl = "Edit.aspx?id=" + gv.DataKeys[e.Row.RowIndex]["Id"];

                var delete = e.Row.FindControl("hLLecturer_Delete") as HyperLink;
                delete.NavigateUrl = "Delete.aspx?id=" + gv.DataKeys[e.Row.RowIndex]["Id"];
            }
        }
    }
}