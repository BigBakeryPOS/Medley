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
    public partial class PickingList : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iPickid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            iPickid = Convert.ToInt32(Request.QueryString.Get("Pickid"));
             if (iPickid != 0)
                {
                    DataSet dspickdetail = new DataSet();
                    dspickdetail = dbObj.Select_Pickvalues(Convert.ToInt32(iPickid));
                    if (dspickdetail != null)
                    {
                        lblDatepick.Text =Convert.ToDateTime(dspickdetail.Tables[0].Rows[0]["PickupDate"]).ToString("yyyy/MM/dd");
                        lblCustname.Text = dspickdetail.Tables[0].Rows[0]["CompanyName"].ToString();
                        lblPickedby.Text = dspickdetail.Tables[0].Rows[0]["ContactName"].ToString();
                        lblproducts.Text = dspickdetail.Tables[0].Rows[0]["Productname"].ToString();
                        lblqty.Text = dspickdetail.Tables[0].Rows[0]["TotalQty"].ToString();
                        lblDateprinted.Text = Convert.ToDateTime(dspickdetail.Tables[0].Rows[0]["PickupDate"]).ToString("yyyy/MM/dd");
                        lblexpirydate.Text = Convert.ToDateTime(dspickdetail.Tables[0].Rows[0]["Validtill"]).ToString("yyyy/MM/dd");
                    }
                }
        }
    }
}