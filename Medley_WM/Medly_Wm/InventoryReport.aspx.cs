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
    public partial class InventoryReport : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPo();


            }
        }
            private void BindPo()
        {
            DataSet dsPO = new DataSet();
            dsPO = dbObj.Select_Inventory();
            if (dsPO.Tables[0].Rows.Count > 0)
            {
                inventoryreport.DataSource = dsPO.Tables[0];
                inventoryreport.DataBind();
            }
        }
        //protected void gvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        DateTime today = DateTime.Now.Date;
        //        if (Convert.ToDateTime(e.Row.Cells[3].Text) <= today)
        //        {

        //            e.Row.Font.Bold = true;
        //            e.Row.BackColor = System.Drawing.Color.LightBlue;

        //        }

        //    }
        //}

        protected void inventoryreport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               int minqty = 10;
               int available=Convert.ToInt32(e.Row.Cells[2].Text);
                int minimum = Convert.ToInt32(e.Row.Cells[3].Text);
                if(available<minimum)
               // if (int.TryParse(e.Row.Cells[2].Text, out int cellValue) && cellValue <= minqty)
                {

                    e.Row.Font.Bold = true;
                    e.Row.BackColor = System.Drawing.Color.LightBlue;

                }

            }
        }
    }
}