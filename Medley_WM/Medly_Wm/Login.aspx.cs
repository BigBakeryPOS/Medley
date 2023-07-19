using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class Login : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        HttpCookie checkadmin = new HttpCookie("checkadmin");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Session["Username"] = txtUsername.Text;
            HttpCookie userInfo = new HttpCookie("userInfo");

            Response.Cookies["UserName"].Value = txtUsername.Text.Trim();
            //iUserid = Convert.ToInt32(Request.QueryString.Get("UserId"));
            DataSet dslogin = new DataSet();
            dslogin = dbObj.SelectLogin(Convert.ToString(txtUsername.Text), Convert.ToString(txtPassword.Text));
            
            if (dslogin.Tables[0].Rows.Count > 0)
            {
                int iEmployeeid = Convert.ToInt32(dslogin.Tables[0].Rows[0]["EmployeeID"].ToString());
                ViewState["EmployeeID"] = iEmployeeid;
                DataSet dsName = dbObj.selectEmployee_byEmployeeId(iEmployeeid);
                userInfo["Empname"]= dsName.Tables[0].Rows[0]["EmployeeName"].ToString();
                userInfo["EmployeeId"] = dslogin.Tables[0].Rows[0]["EmployeeId"].ToString();
                userInfo["UserName"] = dslogin.Tables[0].Rows[0]["UserName"].ToString();
                userInfo["SidebarPage"] = "sidebar.ascx"; // Replace "sidebar.aspx" with the actual page you want to pass
                Response.Cookies.Add(userInfo);
                Response.Redirect("Designation.aspx?Event=Login&EmployeeID=" + iEmployeeid + "username="+ Convert.ToString(txtUsername.Text));
                
            }
            else
            {
               
                Errormessage.Text = "Incorrect Username Or Password ";
            }
        }
    } 
}