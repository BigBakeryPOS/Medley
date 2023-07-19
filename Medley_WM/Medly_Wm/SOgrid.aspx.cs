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
    public partial class SalesOrderoverview : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iSoid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Load Po
                DataSet dsPO = new DataSet();
                dsPO = dbObj.Select_SoGrid();
                if (dsPO.Tables[0].Rows.Count > 0)
                {
                    gvSo.DataSource = dsPO.Tables[0];
                    gvSo.DataBind();
                }
                #endregion
            }
        } 
        private void BindSo()
        {
            DataSet dsPO = new DataSet();
            dsPO = dbObj.Select_SoGrid();
            if (dsPO.Tables[0].Rows.Count > 0)
            {
                gvSo.DataSource = dsPO.Tables[0];
                gvSo.DataBind();
            }
        }
        protected void gvSo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataSet ds = new DataSet();
            if (e.CommandName == "edit")
            {
                Response.Redirect("CreateSO.aspx?Event=Edit&Soid=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "Del")
            {
                int iSoid = Convert.ToInt32(e.CommandArgument);
                dbObj.deleteSoGrid(iSoid);
                BindSo();
            }
            else if (e.CommandName == "Print")
            {
                int iSoid = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("SOPrint.aspx?Soid=" + iSoid);
            }

        }

        protected void gvSo_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                GridView gv = (GridView)e.Row.FindControl("productgrid");
                //  GridView gvPO = (GridView)sender;
                string ab = gvSo.DataKeys[e.Row.RowIndex].Value.ToString();
                if (gvSo.DataKeys[e.Row.RowIndex].Value.ToString() != "")
                {

                    string a = gvSo.DataKeys[e.Row.RowIndex].Values[0].ToString();
                    //int iPoid = Convert.ToInt32(e.Row.Cells[1].va.Text);
                    DataSet dspsoproduct = new DataSet();

                    dspsoproduct = dbObj.Select_SOProduct(Convert.ToInt32(a));
                    if (dspsoproduct.Tables[0].Rows.Count > 0)
                    {
                        gv.Visible = true;
                        gv.DataSource = dspsoproduct.Tables[0];
                        gv.DataBind();
                    }
                    //int iPoid = Convert.ToInt32(e.Row.Cells[1].Text);
                }

            }

            if (e.Row.RowType == DataControlRowType.DataRow && gvSo.EditIndex == -1)
            {

                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnedit");
                ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                LinkButton btndel = (LinkButton)e.Row.FindControl("btndel");
                ImageButton imgDel = (ImageButton)e.Row.FindControl("imgDel");

                DataRowView drv = (DataRowView)e.Row.DataItem;
                string Status = Convert.ToString(drv["Status"]);


                if (Status.Trim() == "Approved")
                {
                    btnEdit.Enabled = false;
                    imgEdit.Enabled = false;

                    btndel.Enabled = false;
                    imgDel.Enabled = false;
                    //  imgEdit.ImageUrl = "~/Images/edit_disabled.jpg"; // Optional: Replace with a disabled image
                }
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            DataSet dsreport = new DataSet();
            dsreport = dbObj.SOdatesearch(Convert.ToDateTime(txtFromdate.Text).Date, Convert.ToDateTime(txtTodate.Text).Date);
            if (dsreport.Tables[0].Rows.Count > 0)
            {
                gvSo.DataSource = dsreport.Tables[0];
                gvSo.DataBind();
            }
        }
    }
}