﻿using System;
using System.Collections.Generic;
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
        }

        private void BindDropDownList_School()
        {
            ddlSchools.DataSource = 
        }

        protected void btnCreateProgram_Click(object sender, EventArgs e)
        {
            if(!(string.IsNullOrWhiteSpace(txtProgramCode.Text) || string.IsNullOrWhiteSpace(txtProgramName.Text)))
            {

            }
            else
            {

            }
        }
    }
}