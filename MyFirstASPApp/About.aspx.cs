using MyFirstASPApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstASPApp
{
    public partial class About : Page
    {
        // Instance of your data access layer
        StudentDAL studentDAL = new StudentDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        // Bind data from the Students table to the GridView
        private void LoadData()
        {
            DataTable dt = studentDAL.GetAllStudents();
            IdGridVIew.DataSource = dt;
            IdGridVIew.DataBind();
        }

        // Insert a new student record
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                DateTime dob = DateTime.Parse(txtDOB.Text.Trim());
                string stream = txtStream.Text.Trim();

                studentDAL.InsertStudent(name, dob, stream);
                lblMessage.Text = "Record inserted successfully.";

                // Clear the insert fields
                txtName.Text = "";
                txtDOB.Text = "";
                txtStream.Text = "";

                // Reload the data
                LoadData();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error inserting record: " + ex.Message;
            }
        }

        // Put the GridView row into edit mode
        protected void IdGridVIew_RowEditing(object sender, GridViewEditEventArgs e)
        {
            IdGridVIew.EditIndex = e.NewEditIndex;
            LoadData();
        }

        // Cancel editing mode
        protected void IdGridVIew_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            IdGridVIew.EditIndex = -1;
            LoadData();
        }

        // Update the selected student record
        protected void IdGridVIew_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(IdGridVIew.DataKeys[e.RowIndex].Value);
                GridViewRow row = IdGridVIew.Rows[e.RowIndex];

                // Retrieve the updated values from the editing controls (TextBoxes)
                string name = ((TextBox)row.Cells[1].Controls[0]).Text.Trim();
                string dobStr = ((TextBox)row.Cells[2].Controls[0]).Text.Trim();
                string stream = ((TextBox)row.Cells[3].Controls[0]).Text.Trim();
                DateTime dob = DateTime.Parse(dobStr);

                studentDAL.UpdateStudent(id, name, dob, stream);

                IdGridVIew.EditIndex = -1;
                LoadData();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error updating record: " + ex.Message;
            }
        }

        // Delete the selected student record
        protected void IdGridVIew_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(IdGridVIew.DataKeys[e.RowIndex].Value);
                studentDAL.DeleteStudent(id);
                LoadData();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error deleting record: " + ex.Message;
            }
        }
    }
}


    
