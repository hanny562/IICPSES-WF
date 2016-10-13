using IICPSES.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IICPSES_1.ControlPanel.Lecturers
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int lecturerId = Convert.ToInt32(Request.QueryString["id"]);
                    string lecturerName = string.Empty;

                    try
                    {
                        txtName.Text = Lecturer.GetLecturerName(lecturerId);
                        hfLecturerId.Value = lecturerId.ToString();
                    }
                    catch (Exception ex)
                    {
                        lblStatus_EditLecturer.Text = ex.ToString();
                    }
                }
                else
                {
                    lblStatus_EditLecturer.Text = hfLecturerId.Value;
                }
            }
            
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(hfLecturerId.Value) || hfLecturerId.Value == "0")
            {
                lblStatus_EditLecturer.Text = "Lecturer information was not correctly supplied. Check if you have entered the name properly.";
            }
            else
            {
                int lecturerId = Convert.ToInt32(hfLecturerId.Value);

                try
                {
                    Lecturer.EditLecturer(lecturerId, txtName.Text);
                    lblStatus_EditLecturer.Text = "Lecturer information has been updated successfully.";
                }
                catch (Exception ex)
                {
                    lblStatus_EditLecturer.Text = ex.ToString();
                }
            }
        }
    }
}