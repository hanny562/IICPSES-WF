﻿using IICPSES.Role;
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