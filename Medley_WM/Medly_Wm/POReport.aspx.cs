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
    public partial class POReport : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iPoid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindPo();
            }
        }

        private void BindPo()
        {
            DataSet dsPOR = new DataSet();
            dsPOR = dbObj.POReport();
            if (dsPOR.Tables[0].Rows.Count > 0)
            {
                PoReport.DataSource = dsPOR.Tables[0];
                PoReport.DataBind();
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {

            DataSet dsreport = new DataSet();
            dsreport = dbObj.Podatesearch(Convert.ToDateTime(txtFromdate.Text).Date, Convert.ToDateTime(txtTodate.Text).Date);
            if (dsreport.Tables[0].Rows.Count > 0)
            {
                PoReport.DataSource = dsreport.Tables[0];
                PoReport.DataBind();
            }

        }
    }
}