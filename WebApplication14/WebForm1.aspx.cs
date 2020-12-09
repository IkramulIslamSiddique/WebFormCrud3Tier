using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvDisplay.Visible = false;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text == "Submit")
                {
                    InsertData();
                }
                else if (btnSubmit.Text == "Update")
                {
                    int Id = int.Parse(gvDisplay.Rows[gvDisplay.SelectedIndex].Cells[0].Text);
                    UpdateData(Id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateData(int Id)
        {
            EmployeeSchema.Class1 objSchema = new EmployeeSchema.Class1();
            objSchema.Name = txtName.Text;
            objSchema.Address = txtAddress.Text;
            objSchema.Age = Convert.ToInt32(txtAge.Text);
            EmployeeBAL.Class1 objBAL = new EmployeeBAL.Class1();
            int result = objBAL.Update(objSchema, Id);
            if (result > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Updated Successfully')", true);
            }
            btnSubmit.Text = "Submit";
            BindGrid();
            Clear();
        }
        public void InsertData()
        {
            EmployeeSchema.Class1 objSchema = new EmployeeSchema.Class1();
            objSchema.Name = txtName.Text;
            objSchema.Address = txtAddress.Text;
            objSchema.Age = Convert.ToInt32(txtAge.Text);
            EmployeeBAL.Class1 objBAL = new EmployeeBAL.Class1();
            int result = objBAL.Insert(objSchema);
            if (result > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Saved Successfully')", true);
            }
            BindGrid();
            Clear();
        }
        private void Clear()
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtAddress.Text = "";
        }
        private void BindGrid()
        {
            try
            {
                EmployeeBAL.Class1 objBal = new EmployeeBAL.Class1();
                gvDisplay.Columns[0].Visible = true;
                gvDisplay.DataSource = objBal.BindGrid();
                gvDisplay.DataBind();
                gvDisplay.Columns[0].Visible = false;
                gvDisplay.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gvDisplay_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                EmployeeBAL.Class1 objBAL = new EmployeeBAL.Class1();
                int Id = int.Parse(gvDisplay.Rows[e.NewSelectedIndex].Cells[0].Text);
                dt = new DataTable();
                dt = objBAL.GetById(Id);
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtAge.Text = dt.Rows[0]["Age"].ToString();
                    btnSubmit.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gvDisplay_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Delete"))
            {
                int Id = int.Parse(e.CommandArgument.ToString());
                DeleteRecord(Id);
            }
        }
        private void DeleteRecord(int Id)
        {
            try
            {
                EmployeeBAL.Class1 objBAL = new EmployeeBAL.Class1();
                int Result = objBAL.Delete(Id);
                if (Result > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Data Deleted Successfully')", true);
                }
                BindGrid();
                Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gvDisplay_RowDeleting(object sender, GridViewDeleteEventArgs e) { }
        protected void gvDisplay_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDisplay.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}