using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Medly_Wm
{
    public partial class Employee : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iEmpid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Edit
                iEmpid = Convert.ToInt32(Request.QueryString.Get("Empid"));

                if (iEmpid != 0)
                {

                    DataSet dsDesgnId = new DataSet();
                    dsDesgnId = dbObj.Select_Employeeedid(iEmpid);
                    ViewState["vsEmp"] = iEmpid;

                    if (dsDesgnId.Tables[0].Rows.Count > 0)
                    {
                        txtEmployeeid.Text = dsDesgnId.Tables[0].Rows[0]["EmployeeID"].ToString();
                        txtEmployeename.Text = dsDesgnId.Tables[0].Rows[0]["EmployeeName"].ToString();
                        txtDob.Text = ((DateTime)dsDesgnId.Tables[0].Rows[0]["DateofBirth"]).ToString("yyyy-MM-dd");
                        txtDoj.Text = ((DateTime)dsDesgnId.Tables[0].Rows[0]["DateofJoining"]).ToString("yyyy-MM-dd");
                        #region Dropdown Designation
                        DataSet dsDesignation1 = new DataSet();
                        dsDesignation1 = dbObj.SelectDesignation();
                        if (dsDesignation1.Tables[0].Rows.Count > 0)
                        {
                            ddlDesignation.DataSource = dsDesignation1;
                            ddlDesignation.DataTextField = "Designation";
                            ddlDesignation.DataValueField = "Designationid";
                            ddlDesignation.DataBind();
                            ddlDesignation.Items.Insert(0, "Select Designation");
                        }
                        #endregion
                        ddlDesignation.SelectedValue= dsDesgnId.Tables[0].Rows[0]["Designation"].ToString();
                        rbgender.Text= dsDesgnId.Tables[0].Rows[0]["Gender"].ToString();
                        txtEmail.Text = dsDesgnId.Tables[0].Rows[0]["Email"].ToString();
                        txtPhonenumber.Text = dsDesgnId.Tables[0].Rows[0]["PhoneNumber"].ToString();
                        txtAddress.Text = dsDesgnId.Tables[0].Rows[0]["Address"].ToString();
                        txtUsername.Text = dsDesgnId.Tables[0].Rows[0]["Username"].ToString();
                        txtPassword.TextMode = TextBoxMode.SingleLine;
                        txtPassword.Text = dsDesgnId.Tables[0].Rows[0]["Password"].ToString();

                        btnSubmit.Text = "Update";
                    }
                }
                #endregion
                #region Dropdown Designation
                DataSet dsDesignation = new DataSet();
                dsDesignation = dbObj.SelectDesignation();
                if (dsDesignation.Tables[0].Rows.Count > 0)
                {
                    ddlDesignation.DataSource = dsDesignation;
                    ddlDesignation.DataTextField = "Designation";
                    ddlDesignation.DataValueField = "Designationid";
                    ddlDesignation.DataBind();
                    ddlDesignation.Items.Insert(0, "Select Designation");
                }
                #endregion
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        { if (ddlDesignation.SelectedValue == "Select Designation")
            {
                string script = "alert('Select Designation')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                if (btnSubmit.Text == "Submit")
                {
                    int isucess = 0;
                    int isucces1 = 0;
                    isucess = dbObj.Insert_Employee(txtEmployeename.Text, Convert.ToDateTime(txtDob.Text), Convert.ToDateTime(txtDoj.Text), rbgender.Text, ddlDesignation.SelectedValue, txtEmail.Text, txtPhonenumber.Text, txtAddress.Text);
                    isucces1 = dbObj.Insert_Login(txtUsername.Text, txtPassword.Text);
                    //Response.Redirect("../Accountsbootstrap/viewbranch.aspx");
                    string script = "alert('Data Saved')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    Response.Redirect("EmployeeGridpage.aspx");
                }
                else if (btnSubmit.Text == "Update")
                {
                    int isucess = 0;
                    int isucces1 = 0;
                    isucess = dbObj.UpdateEmployee(Convert.ToInt32(ViewState["vsEmp"].ToString()), txtEmployeename.Text, Convert.ToDateTime(txtDob.Text), Convert.ToDateTime(txtDoj.Text), rbgender.Text, ddlDesignation.SelectedValue, txtEmail.Text, txtPhonenumber.Text, txtAddress.Text);
                    isucces1 = dbObj.Update_Login(txtUsername.Text, txtPassword.Text, Convert.ToInt32(ViewState["vsEmp"]));
                    string script = "alert('Data Updated')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                    Response.Redirect("EmployeeGridpage.aspx");
                }
            }
        }
    }
}