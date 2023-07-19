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
    public partial class Transpot : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iTranspot = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region Edit
                iTranspot = Convert.ToInt32(Request.QueryString.Get("id"));

                if (iTranspot != 0)
                {

                    DataSet transpotid = new DataSet();
                    transpotid = dbObj.SelectTranspot_byId(iTranspot);
                    ViewState["vstrans"] = iTranspot;

                    if (transpotid.Tables[0].Rows.Count > 0)
                    {
                        txtTranspot.Text = transpotid.Tables[0].Rows[0]["transpot"].ToString();
                        btnSubmit.Text = "Update";
                    }
                }
                #endregion
                #region Load transpot
                DataSet dsTranspot = new DataSet();
                dsTranspot = dbObj.SelectTranspot();
                if (dsTranspot.Tables[0].Rows.Count > 0)
                {
                    gridtranspot.DataSource = dsTranspot.Tables[0];
                    gridtranspot.DataBind();
                }
                #endregion
            }
            string username = Request.QueryString["username"];
        }

        private void BindTranspotGrid()
        {
            DataSet transpotid = new DataSet();
            transpotid = dbObj.SelectTranspot();
            if (transpotid.Tables[0].Rows.Count > 0)
            {
                gridtranspot.DataSource = transpotid.Tables[0];
                gridtranspot.DataBind();
            }
        }
        protected void gvTranspot_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void gvTranspot_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtTranspot.Text == "")
            {
                string script = "alert('Please Enter Transport')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                if (btnSubmit.Text == "Submit")
                {
                    int isucess = 0;
                    isucess = dbObj.InsertTranspot(txtTranspot.Text);
                    //Response.Redirect("../Accountsbootstrap/viewbranch.aspx");
                    string script = "alert('Data Saved')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                    Response.Redirect("Transpot.aspx");
                }
                #region Edit
                else if (btnSubmit.Text == "Update")
                {

                    int isucess = 0;
                    isucess = dbObj.UpdateTranspot(Convert.ToInt32(ViewState["vstrans"].ToString()), txtTranspot.Text);
                    string script = "alert('Data Updated')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                    Response.Redirect("Transpot.aspx");
                }
                #endregion
            }
        }
        protected void gridtranspot_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Edit

            if (e.CommandName == "edit")
            {
                Response.Redirect("Transpot.aspx?Event=Edit&id=" + e.CommandArgument.ToString());

            }
            else if (e.CommandName == "Del")
            {
                int iDesignationId = Convert.ToInt32(e.CommandArgument);
                dbObj.DeleteTranspot(iDesignationId);
                BindTranspotGrid();
            }
            #endregion
        }
    }
}