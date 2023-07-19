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
    public partial class GoodsPickGrid : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

            }
        }

        protected void txtdate_TextChanged(object sender, EventArgs e)
        {

            #region Load Po
            DataSet dsPick = new DataSet();
            dsPick = dbObj.Select_Pickingdetails(Convert.ToDateTime(txtdate.Text));
            //string pickid= dsPick.Tables[0].Rows[0]["id"].ToString();
            //string SoId= dsPick.Tables[0].Rows[0]["SoId"].ToString();
            if (dsPick.Tables[0].Rows.Count > 0)
            {
                gvpick.DataSource = dsPick.Tables[0];
                gvpick.DataBind();
            }
            #endregion
        }

        protected void gvpick_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gv = (GridView)e.Row.FindControl("sopickgrid");
                //  GridView gvPO = (GridView)sender;
                string ab = gvpick.DataKeys[e.Row.RowIndex].Value.ToString();
                if (gvpick.DataKeys[e.Row.RowIndex].Value.ToString() != "")
                {

                    string a = gvpick.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    //int iPoid = Convert.ToInt32(e.Row.Cells[1].va.Text);
                    DataSet dssodetails = new DataSet();
                    dssodetails = dbObj.Select_Sodetails(Convert.ToInt32(a));
                    if (dssodetails.Tables[0].Rows.Count > 0)
                    {
                        gv.Visible = true;
                        gv.DataSource = dssodetails.Tables[0];
                        gv.DataBind();
                    }
                }
                }
        }

        protected void gvpick_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Response.Redirect("PickingList.aspx?Event=Edit&Pickid=" + e.CommandArgument.ToString());
            }
        }
    }
}