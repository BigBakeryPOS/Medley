using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Medly_Wm
{
    public partial class SupplierGridpage : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iSupplierID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //DataSet dsSuplier1 = new DataSet();
                //dsSuplier1 = dbObj.Select_Suplier();
                //for (int i = 0; i < dsSuplier1.Tables[0].Rows.Count; i++)
                   
                //{
                //    Label1.Text = "";
                //        DateTime validTill =(DateTime) dsSuplier1.Tables[0].Rows[i]["ValidTill"];
                //        DateTime Tommorow = DateTime.Now.Date.AddDays(+1);
                //    DateTime today = DateTime.Now.Date;
                //    if (validTill <= today)
                //        {
                //            lblvalidtill.Text ="The Expried date Is : "+ validTill.ToString("yyyy-MM-dd");
                //        string script = "alert('The expired date is: " + validTill.ToString("yyyy-MM-dd") + "')";
                //        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                 
                //        }
                    
                //}

                if (iSupplierID != 0)
                { 

                    DataSet dsEmplyId = new DataSet();
                    dsEmplyId = dbObj.selectsuplier_bysuplierid(iSupplierID);
                    ViewState["vssupl"] = iSupplierID;


                }
                #region Load Suplier
                DataSet dsSuplier = new DataSet();
                dsSuplier = dbObj.Select_Suplier();
                if (dsSuplier.Tables[0].Rows.Count > 0)
                {
                    gvSuplier.DataSource = dsSuplier.Tables[0];
                    gvSuplier.DataBind();
                }
               
            }

        }   
        #endregion
        protected void gvSuplier_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataSet ds = new DataSet();
            if (e.CommandName == "edit")
            {
                Response.Redirect("SupplierMaster.aspx?Event=Edit&Supid=" + e.CommandArgument.ToString());

            }
            else if (e.CommandName == "Del")
            {
                int iSupplierID = Convert.ToInt32(e.CommandArgument);
                dbObj.deleteSuplier(iSupplierID);
                BindSupplierGrid();
            }

        }
        private void BindSupplierGrid()
        {
            DataSet dsSuplier = new DataSet();
            dsSuplier = dbObj.Select_Suplier();
            if (dsSuplier.Tables[0].Rows.Count > 0)
            {
                gvSuplier.DataSource = dsSuplier.Tables[0];
                gvSuplier.DataBind();
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow && gvSuplier.EditIndex == -1)
            {

                LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnedit");
                ImageButton imgEdit = (ImageButton)e.Row.FindControl("imgEdit");

                LinkButton btndel = (LinkButton)e.Row.FindControl("btndel");
                ImageButton imgDel = (ImageButton)e.Row.FindControl("imgDel");

                DataRowView drv = (DataRowView)e.Row.DataItem;
                string Status = Convert.ToString(drv["Status"]);


                if (Status == "Approved")
                {
                    btnEdit.Enabled = false;
                    imgEdit.Enabled = false;

                    btndel.Enabled = false;
                    imgDel.Enabled = false;
                    //  imgEdit.ImageUrl = "~/Images/edit_disabled.jpg"; // Optional: Replace with a disabled image
                }
            }

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    DateTime today = DateTime.Now.Date;
            //    if (Convert.ToDateTime(e.Row.Cells[5].Text) <= today)
            //    {

            //        e.Row.Font.Bold = true;
            //        e.Row.BackColor = System.Drawing.Color.LightBlue;

            //    }

            //}
        }
        //protected void gvSuplier_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    DataSet dsSuplier = new DataSet();
        //    dsSuplier = dbObj.Select_Suplier();
        //    if (dsSuplier.Tables[0].Rows.Count > 0)
        //    {
        //        lblvalidtill.Text = ((DateTime)dsSuplier.Tables[0].Rows[0]["ValidTill"]).ToString("yyyy-MM-dd");
        //    }
        //}
    }
}