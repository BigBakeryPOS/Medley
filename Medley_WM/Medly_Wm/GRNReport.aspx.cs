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
    public partial class GRNReport : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindGRNreport();
            }
        }
        private void BindGRNreport()
        {
            DataSet dsPO = new DataSet();
            dsPO = dbObj.GRNreport();
            if (dsPO.Tables[0].Rows.Count > 0)
            {
                grnreport.DataSource = dsPO.Tables[0];
                grnreport.DataBind();
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {

            DataSet dsreport = new DataSet();
            dsreport = dbObj.GRNdatesearch(Convert.ToDateTime(txtFromdate.Text).Date, Convert.ToDateTime(txtTodate.Text).Date);
            if (dsreport.Tables[0].Rows.Count > 0)
            {
                grnreport.DataSource = dsreport.Tables[0];
                grnreport.DataBind();
            }

        }
    }
}