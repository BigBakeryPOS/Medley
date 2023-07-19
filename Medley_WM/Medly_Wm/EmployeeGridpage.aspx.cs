using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Medly_Wm
{
    public partial class EmployeeGridpage : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iEmployeeId = 0;
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
              

                if (iEmployeeId != 0)
                {

                    DataSet dsEmplyId = new DataSet();
                    dsEmplyId = dbObj.SelectDesignation_byId(iEmployeeId);
                    ViewState["vsEmply"] = iEmployeeId;

                   
                }
                #region Load Employee
                DataSet dsEmployee = new DataSet();
                dsEmployee = dbObj.Select_Employee();
                if (dsEmployee.Tables[0].Rows.Count > 0)
                {
                    gvEmployee.DataSource = dsEmployee.Tables[0];
                    gvEmployee.DataBind();
                }
                #endregion
               

            }

        }

        protected void gvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          
            DataSet ds = new DataSet();
          

            if (e.CommandName == "edit")
            {
                Response.Redirect("Employee.aspx?Event=Edit&Empid=" + e.CommandArgument.ToString());

            }
            else if (e.CommandName == "Del")
            {
                int iEmployeeId = Convert.ToInt32(e.CommandArgument);
                dbObj.DeleteEmployee(iEmployeeId);
                BindEmployeeGrid();
            }
        }
        private void BindEmployeeGrid()
            {
                DataSet dsEmployee = dbObj.Select_Employee();
                if (dsEmployee.Tables[0].Rows.Count > 0)
                {
                    gvEmployee.DataSource = dsEmployee.Tables[0];
                    gvEmployee.DataBind();
                }
            }
       
    }
}
