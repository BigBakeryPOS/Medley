using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Medly_Wm
{
    public partial class GoodsReceipts : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iWarehouseId = 0;
        int iPoid; int iProId; string sName; string Total;
        int iProductID = 0; int Empid = 0;
        int iGRId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {  
          
            if (!IsPostBack)
            {
                iPoid = Convert.ToInt32(Request.QueryString.Get("Poid"));
                iProId = Convert.ToInt32(Request.QueryString.Get("Productid"));
                sName = (Request.QueryString.Get("name"));
                Total = (Request.QueryString.Get("Total"));
                DataSet ds = dbObj.select_Po1();
                ddlPOnumber.DataSource = ds;

                ddlPOnumber.DataTextField = "Poid";
                ddlPOnumber.DataValueField = "Poid";
                ddlPOnumber.DataBind();
                ddlPOnumber.Items.Insert(0, "Select Poid");
                if (iPoid != 0)
                {

                    DataSet dsgr = new DataSet();
                    dsgr = dbObj.selecttranspoby_poid(iPoid);
                    ViewState["vspoid"] = iPoid;

                    if (dsgr.Tables[0].Rows.Count > 0)
                    {
                        #region Poid
                        DataSet ds1 = dbObj.select_Po1();//select_Po();
                        ddlPOnumber.DataSource = ds1;
                        ddlPOnumber.DataTextField = "Poid";
                        ddlPOnumber.DataValueField = "Poid";
                        ddlPOnumber.DataBind();
                        ddlPOnumber.Items.Insert(0, "Select Poid");
                        #endregion

                        ddlPOnumber.Text = dsgr.Tables[0].Rows[0]["Poid"].ToString();
                        #region productid
                        DataSet dsProdId = new DataSet();
                        dsProdId = dbObj.select_TranspoProductid();
                        ddlProductid.DataSource = dsProdId;
                        ddlProductid.DataTextField = "Productname";
                        ddlProductid.DataValueField = "Productid";
                        ddlProductid.DataBind();
                        ddlProductid.Items.Insert(0, "Select Productid");
                        #endregion
                        ddlProductid.Text = dsgr.Tables[0].Rows[0]["ProductId"].ToString();
                        //txtLicenceNo.Text = dsgr.Tables[0].Rows[0]["LicenseNo"].ToString();
                        //txtLicenseno.Text = dsProdId.Tables[0].Rows[0]["Licenseno"].ToString();
                        txtDosageform.Text = dsgr.Tables[0].Rows[0]["Dosageform"].ToString();
                        txtStrength.Text = dsgr.Tables[0].Rows[0]["Strength"].ToString();
                        //txtPacktype.Text = dsgr.Tables[0].Rows[0]["Packtype"].ToString();
                       // txtPacksize.Text = dsgr.Tables[0].Rows[0]["Packsize"].ToString();
                        txtOrderqty.Text = dsgr.Tables[0].Rows[0]["PoQty"].ToString();
                        txtOrderAmount.Text = dsgr.Tables[0].Rows[0]["Productamt"].ToString();
                        //txtBatch.Text = dsgr.Tables[0].Rows[0]["Batchnumber"].ToString();
                        txtRecdQty.Text = Total;
                        #region Dropdown Approver
                        DataSet dsApprovar1 = new DataSet();
                        dsApprovar1 = dbObj.Select_Employeename();
                        if (dsApprovar1.Tables[0].Rows.Count > 0)
                        {
                            ddlSelectapprover.DataSource = dsApprovar1;
                            ddlSelectapprover.DataTextField = "EmployeeName";
                            ddlSelectapprover.DataValueField = "EmployeeID";
                            ddlSelectapprover.DataBind();
                        }
                        #endregion
                        //ddlSelectapprover.SelectedValue = dsgr.Tables[0].Rows[0]["ApproverId"].ToString();
                       // ddlStatus.SelectedItem.Text = dsgr.Tables[0].Rows[0]["Status"].ToString();
                    }
                }



                #region Edit
                iProductID = Convert.ToInt32(Request.QueryString.Get("iProductID"));
                if (Request.Cookies["userInfo"]["EmployeeID"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Empid = Convert.ToInt32(Request.Cookies["userInfo"]["EmployeeID"]);


                }
                DataSet dsGR = dbObj.GetMax_GR();
                if (dsGR.Tables[0].Rows.Count > 0)
                {
                    if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                    {
                        int Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());
                        txtGRNnumber.Text = Convert.ToString(Id + 1);
                    }
                    else
                    {
                        txtGRNnumber.Text = "1";

                    }
                }
                else
                {
                    txtGRNnumber.Text = "1";
                }
                iGRId = Convert.ToInt32(Request.QueryString.Get("GRId"));
                if (iGRId != 0)
                {

                    DataSet dsgr = new DataSet();
                    dsgr = dbObj.selectGR_byGRId(iGRId);
                    ViewState["vsGR"] = iGRId;

                    if (dsgr.Tables[0].Rows.Count > 0)
                    {
                        int ApproverId = Convert.ToInt32(dsgr.Tables[0].Rows[0]["ApproverId"].ToString());
                        if (ApproverId == Empid)
                        {
                            ddlStatus.Enabled = true;
                        }

                        #region Poid
                        DataSet ds1 = dbObj.select_Po();
                        ddlPOnumber.DataSource = ds1;
                        ddlPOnumber.DataTextField = "Poid";
                        ddlPOnumber.DataValueField = "Poid";
                        ddlPOnumber.DataBind();
                        ddlPOnumber.Items.Insert(0, "Select Poid");
                        #endregion
                        txtGRNnumber.Text= dsgr.Tables[0].Rows[0]["GRId"].ToString();
                        ddlPOnumber.Enabled = false;
                        ddlPOnumber.Text = dsgr.Tables[0].Rows[0]["Poid"].ToString();
                        #region productid
                        DataSet dsProdId = new DataSet();
                        dsProdId = dbObj.select_TranspoProductid();
                        ddlProductid.DataSource = dsProdId;
                        ddlProductid.DataTextField = "Productname";
                        ddlProductid.DataValueField = "Productid";
                        ddlProductid.DataBind();
                        ddlProductid.Items.Insert(0, "Select Productid");
                        #endregion
                        ddlProductid.Text = dsgr.Tables[0].Rows[0]["ProductId"].ToString();
                        ddlProductid.Enabled = false;
                       // txtLicenceNo.Text = dsgr.Tables[0].Rows[0]["License"].ToString();
                        //txtLicenseno.Text = dsProdId.Tables[0].Rows[0]["Licenseno"].ToString();
                        txtDosageform.Text = dsgr.Tables[0].Rows[0]["Dosage"].ToString();
                        txtStrength.Text = dsgr.Tables[0].Rows[0]["Strength"].ToString();
                        //txtPacktype.Text = dsgr.Tables[0].Rows[0]["Packtype"].ToString();
                        //txtPacksize.Text = dsgr.Tables[0].Rows[0]["Packsize"].ToString();
                        txtOrderqty.Text = dsgr.Tables[0].Rows[0]["OrderQty"].ToString();
                        txtOrderAmount.Text = dsgr.Tables[0].Rows[0]["OrderAmt"].ToString();
                        txtBatch.Text = dsgr.Tables[0].Rows[0]["Batchnumber"].ToString();
                        txtRecdQty.Text = dsgr.Tables[0].Rows[0]["ReceivedQty"].ToString();
                        //txtpalletsrefno.Text = ((DateTime)dsgr.Tables[0].Rows[0][""]).ToString("yyyy-MM-dd");
                        txtExpDate.Text = ((DateTime)dsgr.Tables[0].Rows[0]["ExpiryDate"]).ToString("yyyy-MM-dd");
                        txtPallets.Text = dsgr.Tables[0].Rows[0]["PalletsQty"].ToString();
                        //txtpalletsrefno.Text= dsgr.Tables[0].Rows[0]["PalletsRefNo"].ToString();
                        ddlbatchstatus.SelectedItem.Text = dsgr.Tables[0].Rows[0]["BatchStatus"].ToString();
                        #region Dropdown Approver
                        DataSet dsApprovar1 = new DataSet();
                        dsApprovar1 = dbObj.Select_Employeename();
                        if (dsApprovar1.Tables[0].Rows.Count > 0)
                        {
                            ddlSelectapprover.DataSource = dsApprovar1;
                            ddlSelectapprover.DataTextField = "EmployeeName";
                            ddlSelectapprover.DataValueField = "EmployeeID";
                            ddlSelectapprover.DataBind();
                        }
                        #endregion
                        ddlSelectapprover.SelectedValue= dsgr.Tables[0].Rows[0]["ApproverId"].ToString();
                        ddlStatus.SelectedItem.Text = dsgr.Tables[0].Rows[0]["Status"].ToString();
                        btnSubmit.Text = "Update";
                    }
                }
                #endregion


                


            




                DataSet dsUnits1 = new DataSet();
                dsUnits1 = dbObj.Select_Units1();
                if (dsUnits1.Tables[0].Rows.Count > 0)
                {
                    ddUnits1.DataSource = dsUnits1.Tables[0];
                    ddUnits1.DataBind();
                }
                //DataSet dsUnits2 = new DataSet();
                //dsUnits2 = dbObj.Select_Units2();
                //if (dsUnits2.Tables[0].Rows.Count > 0)
                //{
                //    ddUnits2.DataSource = dsUnits2.Tables[0];
                //    ddUnits2.DataBind();
                //}
                //DataSet dsUnits3 = new DataSet();
                //dsUnits3 = dbObj.Select_Units3();
                //if (dsUnits3.Tables[0].Rows.Count > 0)
                //{
                //    ddUnits3.DataSource = dsUnits3.Tables[0];
                //    ddUnits3.DataBind();
                //}
                //DataSet dsUnits4 = new DataSet();
                //dsUnits4 = dbObj.Select_Units4();
                //if (dsUnits4.Tables[0].Rows.Count > 0)
                //{
                //    ddUnits4.DataSource = dsUnits4.Tables[0];
                //    ddUnits4.DataBind();
                //}

                DataSet dswarehouse = dbObj.Select_Warehouse();
                if (dswarehouse.Tables[0].Rows.Count > 0)
                {
                    ddlwarehouse.DataSource = dswarehouse;
                    ddlwarehouse.DataTextField = "WarehouseName";
                    ddlwarehouse.DataValueField = "WarehouseID";
                    ddlwarehouse.DataBind();
                }
                //#region Load warehouse
                //DataSet dswarehouseid = new DataSet();
                //dswarehouseid = dbObj.select_byWarehouseId(iWarehouseId);
                //if (dswarehouseid.Tables[0].Rows.Count > 0)
                //{
                //    gvWarehouse.DataSource = dswarehouseid.Tables[0];
                //    gvWarehouse.DataBind();
                //}
                //#endregion
                #region Dropdown Approver
                DataSet dsApprovar = new DataSet();
                dsApprovar = dbObj.Select_Employeename();
                if (dsApprovar.Tables[0].Rows.Count > 0)
                {
                    ddlSelectapprover.DataSource = dsApprovar;
                    ddlSelectapprover.DataTextField = "EmployeeName";
                    ddlSelectapprover.DataValueField = "EmployeeID";
                    ddlSelectapprover.DataBind();
                    ddlSelectapprover.Items.Insert(0, "Select Approver");
                }
                #endregion

            }

        }
        protected void ddRoomListSecond_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            int count = ddUnits1.Items.Count;
            //foreach (DataListItem dl in ddRoomListALL.Items)
            // for (int i = 0; i < count; i++)
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Button btn = (Button)e.Item.FindControl("btns1");

                if (btn.CommandName == "0")
                {
                    btn.BackColor = System.Drawing.Color.Gray;
                    btn.ForeColor = System.Drawing.Color.White;
                }
                else if (btn.CommandName == "1")
                {
                    btn.BackColor = System.Drawing.Color.Green;
                    btn.ForeColor = System.Drawing.Color.White;

                    //btn.Enabled = false;
                }
                //else if (btn.CommandName == "3")
                //{
                //    btn.BackColor = System.Drawing.Color.Green;
                //    btn.ForeColor = System.Drawing.Color.White;

                //    //btn.Enabled = false;
                //}
                //else
                //{
                //    btn.BackColor = System.Drawing.Color.Yellow;
                //    btn.ForeColor = System.Drawing.Color.White;

                //    //btn.Enabled = false;
                //}

            }
        }
        protected void btnClick(object sender, EventArgs e)
        {

            //    Button cat = (sender as Button);
            //

            //    if (cat.BackColor == System.Drawing.Color.Blue)
            //    {
            //        ScriptManager.RegisterStartupScript(upan, upan.GetType(), "myFunctions", "myFunctions();", true);
            //        Button roomNo = (sender as Button);
            //string testRoomNo = Convert.ToString(roomNo.Text);
            ////string result = testRoomNo.Substring(0, testRoomNo.IndexOf("-"));
            //string result = testRoomNo;
            //DataSet ds = Rmc.UnCleanedRoomsToCleanedRooms(result);
            //Response.Redirect("Reception.aspx");
            //    };

            Button Btn = (sender as Button);
            Session["UnitId"] = Btn.CommandArgument.ToString();
            DataSet dsUnit = dbObj.Select_UnitsCheck(Convert.ToInt32(Session["UnitId"].ToString()));
            if (dsUnit.Tables[0].Rows.Count > 0)
            {
                lblFloor.Text = dsUnit.Tables[0].Rows[0]["Floor"].ToString();
                lblUnit.Text = dsUnit.Tables[0].Rows[0]["Unitname"].ToString();
            }

        }

        protected void ddlPOnumber_SelectedIndexChanged(object sender, EventArgs e)
        {


            DataSet ds1 = dbObj.select_TranspoProduct(Convert.ToInt32(ddlPOnumber.SelectedValue));
            ddlProductid.DataSource = ds1;

            ddlProductid.DataTextField = "Productname";
            ddlProductid.DataValueField = "Productid";
            ddlProductid.DataBind();
            ddlProductid.Items.Insert(0, "Select Productd");

        }

        protected void ddlProductid_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsProdId = new DataSet();
            dsProdId = dbObj.select_TranspoProductvalues(Convert.ToInt32(ddlProductid.SelectedValue), Convert.ToInt32(ddlPOnumber.SelectedValue));
            ViewState["vsPrdct"] = iPoid;

            if (dsProdId.Tables[0].Rows.Count > 0)
            {
              
                //txtLicenceNo.Text = dsProdId.Tables[0].Rows[0]["LicenseNo"].ToString();
                txtDosageform.Text = dsProdId.Tables[0].Rows[0]["Dosageform"].ToString();
                txtStrength.Text = dsProdId.Tables[0].Rows[0]["Strength"].ToString();
                //txtPacktype.Text = dsProdId.Tables[0].Rows[0]["Packtype"].ToString();
                //txtPacksize.Text = dsProdId.Tables[0].Rows[0]["Packsize"].ToString();
                txtOrderqty.Text = dsProdId.Tables[0].Rows[0]["PoQty"].ToString();
                txtOrderAmount.Text = dsProdId.Tables[0].Rows[0]["Productamt"].ToString();

            }
        }

        protected void txtPallets_TextChanged(object sender, EventArgs e)
        {
            List.Visible = true;
            DataSet dsUnits1 = new DataSet();
            dsUnits1 = dbObj.Select_Units_Green_Number(Convert.ToInt32(txtPallets.Text));
            if (dsUnits1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < Convert.ToInt32(txtPallets.Text); i++)
                {
                    if (i == 0)
                    {

                        lbl0.Visible = true;
                        txt0.Visible = true;
                        txtpr0.Visible = true;
                        //txtpr0.Text = txtpalletsrefno.Text;
                        lbl0.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                        lbl1.Visible = false;
                        txt1.Visible = false;
                        txtpr1.Visible = false;

                        lbl2.Visible = false;
                        txt2.Visible = false;
                        txtpr2.Visible = false;

                        lbl3.Visible = false;
                        txt3.Visible = false;
                        txtpr3.Visible = false;

                        lbl4.Visible = false;
                        txt4.Visible = false;
                        txtpr4.Visible = false;

                        lbl5.Visible = false;
                        txt5.Visible = false;
                        txtpr5.Visible = false;

                        lbl6.Visible = false;
                        txt6.Visible = false;
                        txtpr6.Visible = false;

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;

                    }
                    else if (i == 1)
                    {

                        lbl1.Visible = true;
                        txt1.Visible = true;
                        txtpr1.Visible = true;
                        //txtpr1.Text = txtpalletsrefno.Text;
                        lbl1.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                        lbl2.Visible = false;
                        txt2.Visible = false;
                        txtpr2.Visible = false;

                        lbl3.Visible = false;
                        txt3.Visible = false;
                        txtpr3.Visible = false;

                        lbl4.Visible = false;
                        txt4.Visible = false;
                        txtpr4.Visible = false;

                        lbl5.Visible = false;
                        txt5.Visible = false;
                        txtpr5.Visible = false;

                        lbl6.Visible = false;
                        txt6.Visible = false;
                        txtpr6.Visible = false;

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;
                    }
                    else if (i == 2)
                    {

                        lbl2.Visible = true;
                        txt2.Visible = true;
                        txtpr2.Visible = true;
                        //txtpr2.Text = txtpalletsrefno.Text;
                        lbl2.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                        lbl3.Visible = false;
                        txt3.Visible = false;
                        txtpr3.Visible = false;

                        lbl4.Visible = false;
                        txt4.Visible = false;
                        txtpr4.Visible = false;

                        lbl5.Visible = false;
                        txt5.Visible = false;
                        txtpr5.Visible = false;

                        lbl6.Visible = false;
                        txt6.Visible = false;
                        txtpr6.Visible = false;

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;
                    }
                    else if (i == 3)
                    {

                        lbl3.Visible = true;
                        txt3.Visible = true;
                        txtpr3.Visible = true;
                        //.Text = txtpalletsrefno.Text;
                        lbl3.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                        lbl4.Visible = false;
                        txt4.Visible = false;
                        txtpr4.Visible = false;

                        lbl5.Visible = false;
                        txt5.Visible = false;
                        txtpr5.Visible = false;

                        lbl6.Visible = false;
                        txt6.Visible = false;
                        txtpr6.Visible = false;

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;
                    }
                    else if (i == 4)
                    {

                        lbl4.Visible = true;
                        txt4.Visible = true;
                        txtpr4.Visible = true;
                       // txtpr4.Text = txtpalletsrefno.Text;
                        lbl4.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                        lbl5.Visible = false;
                        txt5.Visible = false;
                        txtpr5.Visible = false;

                        lbl6.Visible = false;
                        txt6.Visible = false;
                        txtpr6.Visible = false;

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;

                    }
                    else if (i == 5)
                    {

                        lbl5.Visible = true;
                        txt5.Visible = true;
                        txtpr5.Visible = true;
                        //txtpr5.Text = txtpalletsrefno.Text;
                        lbl5.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                        lbl6.Visible = false;
                        txt6.Visible = false;
                        txtpr6.Visible = false;

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;

                    }
                    else if (i == 6)
                    {

                        lbl6.Visible = true;
                        txt6.Visible = true;
                        txtpr6.Visible = true;
                        //txtpr6.Text = txtpalletsrefno.Text;
                        lbl6.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                        lbl7.Visible = false;
                        txt7.Visible = false;
                        txtpr7.Visible = false;

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;
                    }
                    else if (i == 7)
                    {

                        lbl7.Visible = true;
                        txt7.Visible = true;
                        txtpr7.Visible = true;
                        //txtpr7.Text = txtpalletsrefno.Text;
                        lbl7.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                        lbl8.Visible = false;
                        txt8.Visible = false;
                        txtpr8.Visible = false;

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;

                    }
                    else if (i == 8)
                    {

                        lbl8.Visible = true;
                        txt8.Visible = true;
                        txtpr8.Visible = true;
                        //txtpr8.Text = txtpalletsrefno.Text;
                        lbl8.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();

                        lbl9.Visible = false;
                        txt9.Visible = false;
                        txtpr9.Visible = false;
                    }
                    else 
                    {

                        lbl9.Visible = true;
                        txt9.Visible = true;
                        txtpr9.Visible = true;
                        //txtpr9.Text = txtpalletsrefno.Text;
                        lbl9.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
                    }
                   
                }
            } 
            //DataSet dsUnits1 = new DataSet();
            //dsUnits1 = dbObj.Select_Units_Green_Number(Convert.ToInt32(txtPallets.Text));
            //if (dsUnits1.Tables[0].Rows.Count > 0)
            //{
             

            //    int numPallets;
            //    if (int.TryParse(txtPallets.Text, out numPallets))
            //    {
            //        Clear the container before adding new textboxes
            //        txtdisplay.Controls.Clear();

            //        for (int i = 0; i < numPallets; i++)
            //        {
            //            TextBox textbox = new TextBox();
            //            Label label = new Label();
            //            label.CssClass = "form-control";
            //            label.Text = "Label " + (i + 1);
            //            label.Text = dsUnits1.Tables[0].Rows[i]["Unitname"].ToString();
            //            label.ID = "lbl" + i;
            //            textbox.CssClass = "form-control";
            //            textbox.ID = "txt" + i;
            //            txtdisplay.Controls.Add(textbox);
            //            lbldisplay.Controls.Add(label);

            //        }

            //    }
            //}
        }

        protected void btnCalSubmit_Click(object sender, EventArgs e)
        {
            if (txtExpDate.Text == "")
            {
                string script = "alert('Select Expiry Date')";
                ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
            }
            else
            {
                int qty0 = Convert.ToInt32(txt0.Text); int qty1 = Convert.ToInt32(txt1.Text); int qty2 = Convert.ToInt32(txt2.Text);
                int qty3 = Convert.ToInt32(txt3.Text); int qty4 = Convert.ToInt32(txt4.Text); int qty5 = Convert.ToInt32(txt5.Text);
                int qty6 = Convert.ToInt32(txt6.Text); int qty7 = Convert.ToInt32(txt7.Text); int qty8 = Convert.ToInt32(txt8.Text);
                int qty9 = Convert.ToInt32(txt9.Text);
                int totalqty = qty0 + qty1 + qty2 + qty3 + qty4 + qty5 + qty6 + qty7 + qty8 + qty9;
                if (Convert.ToInt32(txtRecdQty.Text) == totalqty)
                {
                    for (int i = 0; i < Convert.ToInt32(txtPallets.Text); i++)
                    {
                        if (lbl0.Visible == true)
                        {
                            int Id = 0;
                            DataSet dsGR = dbObj.GetMax_TransGR();
                            if (dsGR.Tables[0].Rows.Count > 0)
                            {
                                if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                {
                                    Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                }
                                else
                                {
                                    Id = 1;

                                }
                            }
                            else
                            {
                                Id = 1;
                            }

                            int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl0.Text, Convert.ToInt32(txt0.Text), txtpr0.Text,ddlbatchstatus.SelectedItem.Text);
                            DataSet dsTrace = dbObj.GetMax_Traceid();
                            int TraceId = +1;
                            if (dsTrace.Tables[0].Rows.Count > 0)
                            {
                                if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                {
                                    TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                    TraceId = TraceId + 1;

                                }
                                else
                                {
                                    TraceId = 1;

                                }
                            }
                            else
                            {
                                TraceId = 1;
                            }
                            int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl0.Text, Convert.ToInt32(txt0.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr0.Text);
                            int iUpdate = dbObj.UpdateUnitQty(Id, lbl0.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt0.Text), ddlbatchstatus.SelectedItem.Text, txtpr0.Text);
                            lbl0.Visible = false; txt0.Visible = false; txtpr0.Visible = false;

                        }
                        else if (lbl1.Visible == true)
                        {
                            int Id = 0;
                            DataSet dsGR = dbObj.GetMax_TransGR();
                            if (dsGR.Tables[0].Rows.Count > 0)
                            {
                                if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                {
                                    Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                }
                                else
                                {
                                    Id = 1;

                                }
                            }
                            else
                            {
                                Id = 1;
                            }


                            int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl1.Text, Convert.ToInt32(txt1.Text), txtpr1.Text, ddlbatchstatus.SelectedItem.Text);
                            DataSet dsTrace = dbObj.GetMax_Traceid();
                            int TraceId;
                            if (dsTrace.Tables[0].Rows.Count > 0)
                            {
                                if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                {
                                    TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                    TraceId = TraceId + 1;
                                }
                                else
                                {
                                    TraceId = 1;

                                }
                            }
                            else
                            {
                                TraceId = 1;
                            }
                            int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl1.Text, Convert.ToInt32(txt1.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr1.Text);
                            int iUpdate = dbObj.UpdateUnitQty(Id, lbl1.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt1.Text), ddlbatchstatus.SelectedItem.Text, txtpr1.Text);
                            lbl1.Visible = false; txt1.Visible = false; txtpr1.Visible = false;
                        }
                        else if (lbl2.Visible == true)
                        {
                            int Id = 0;
                            DataSet dsGR = dbObj.GetMax_TransGR();
                            if (dsGR.Tables[0].Rows.Count > 0)
                            {
                                if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                {
                                    Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                }
                                else
                                {
                                    Id = 1;

                                }
                            }
                            else
                            {
                                Id = 1;
                            }

                            int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl2.Text, Convert.ToInt32(txt2.Text), txtpr2.Text, ddlbatchstatus.SelectedItem.Text);
                            DataSet dsTrace = dbObj.GetMax_Traceid();
                            int TraceId;
                            if (dsTrace.Tables[0].Rows.Count > 0)
                            {
                                if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                {
                                    TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                    TraceId = TraceId + 1;
                                }
                                else
                                {
                                    TraceId = 1;

                                }
                            }
                            else
                            {
                                TraceId = 1;
                            }
                            int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl2.Text, Convert.ToInt32(txt2.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr2.Text);
                            int iUpdate = dbObj.UpdateUnitQty(Id, lbl2.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt2.Text), ddlbatchstatus.SelectedItem.Text, txtpr2.Text);
                            lbl2.Visible = false; txt2.Visible = false; txtpr2.Visible = false;
                        }
                        else if (lbl3.Visible == true)
                        {
                            int Id = 0;
                            DataSet dsGR = dbObj.GetMax_TransGR();
                            if (dsGR.Tables[0].Rows.Count > 0)
                            {
                                if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                {
                                    Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                }
                                else
                                {
                                    Id = 1;

                                }
                            }
                            else
                            {
                                Id = 1;
                            }

                            int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl3.Text, Convert.ToInt32(txt3.Text), txtpr3.Text, ddlbatchstatus.SelectedItem.Text);
                            DataSet dsTrace = dbObj.GetMax_Traceid();
                            int TraceId;
                            if (dsTrace.Tables[0].Rows.Count > 0)
                            {
                                if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                {
                                    TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                    TraceId = TraceId + 1;
                                }
                                else
                                {
                                    TraceId = 1;

                                }
                            }
                            else
                            {
                                TraceId = 1;
                            }
                            int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl3.Text, Convert.ToInt32(txt3.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr3.Text);
                            int iUpdate = dbObj.UpdateUnitQty(Id, lbl3.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt3.Text), ddlbatchstatus.SelectedItem.Text, txtpr3.Text);
                            lbl3.Visible = false; txt3.Visible = false; txtpr3.Visible = false;
                        }
                        else if (lbl4.Visible == true)
                        {
                            int Id = 0;
                            DataSet dsGR = dbObj.GetMax_TransGR();
                            if (dsGR.Tables[0].Rows.Count > 0)
                            {
                                if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                {
                                    Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                }
                                else
                                {
                                    Id = 1;

                                }
                            }
                            else
                            {
                                Id = 1;
                            }


                            int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl4.Text, Convert.ToInt32(txt4.Text), txtpr4.Text, ddlbatchstatus.SelectedItem.Text);
                            DataSet dsTrace = dbObj.GetMax_Traceid();
                            int TraceId;
                            if (dsTrace.Tables[0].Rows.Count > 0)
                            {
                                if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                {
                                    TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                    TraceId = TraceId + 1;
                                }
                                else
                                {
                                    TraceId = 1;

                                }
                            }
                            else
                            {
                                TraceId = 1;
                            }
                            int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl4.Text, Convert.ToInt32(txt4.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr4.Text);
                            int iUpdate = dbObj.UpdateUnitQty(Id, lbl4.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt4.Text), ddlbatchstatus.SelectedItem.Text, txtpr4.Text);
                            lbl4.Visible = false; txt4.Visible = false; txtpr4.Visible = false;
                        }
                        else if (lbl5.Visible == true)
                        {
                            int Id = 0;
                            DataSet dsGR = dbObj.GetMax_TransGR();
                            if (dsGR.Tables[0].Rows.Count > 0)
                            {
                                if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                {
                                    Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                }
                                else
                                {
                                    Id = 1;

                                }
                            }
                            else
                            {
                                Id = 1;
                            }

                            int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl5.Text, Convert.ToInt32(txt5.Text), txtpr5.Text, ddlbatchstatus.SelectedItem.Text);
                            DataSet dsTrace = dbObj.GetMax_Traceid();
                            int TraceId;
                            if (dsTrace.Tables[0].Rows.Count > 0)
                            {
                                if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                {
                                    TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                    TraceId = TraceId + 1;
                                }
                                else
                                {
                                    TraceId = 1;

                                }
                            }
                            else
                            {
                                TraceId = 1;
                            }
                            int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl5.Text, Convert.ToInt32(txt5.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr5.Text);
                            int iUpdate = dbObj.UpdateUnitQty(Id, lbl5.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt5.Text), ddlbatchstatus.SelectedItem.Text, txtpr5.Text);
                            lbl5.Visible = false; txt5.Visible = false; txtpr5.Visible = false;
                        }
                        else if (lbl6.Visible == true)
                        {
                            int Id = 0;
                            DataSet dsGR = dbObj.GetMax_TransGR();
                            if (dsGR.Tables[0].Rows.Count > 0)
                            {
                                if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                {
                                    Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                }
                                else
                                {
                                    Id = 1;

                                }
                            }
                            else
                            {
                                Id = 1;
                            }

                            int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl6.Text, Convert.ToInt32(txt6.Text), txtpr6.Text, ddlbatchstatus.SelectedItem.Text);
                            DataSet dsTrace = dbObj.GetMax_Traceid();
                            int TraceId;
                            if (dsTrace.Tables[0].Rows.Count > 0)
                            {
                                if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                {
                                    TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                    TraceId = TraceId + 1;
                                }
                                else
                                {
                                    TraceId = 1;

                                }
                            }
                            else
                            {
                                TraceId = 1;
                            }
                            int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl6.Text, Convert.ToInt32(txt6.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr6.Text);
                            int iUpdate = dbObj.UpdateUnitQty(Id, lbl6.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt6.Text), ddlbatchstatus.SelectedItem.Text, txtpr6.Text);
                            lbl6.Visible = false; txt6.Visible = false; txtpr6.Visible = false;
                        }
                        else if (lbl7.Visible == true)
                        {
                            int Id = 0;
                            DataSet dsGR = dbObj.GetMax_TransGR();
                            if (dsGR.Tables[0].Rows.Count > 0)
                            {
                                if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                {
                                    Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                }
                                else
                                {
                                    Id = 1;

                                }
                            }
                            else
                            {
                                Id = 1;
                            }

                            int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl7.Text, Convert.ToInt32(txt7.Text), txtpr7.Text, ddlbatchstatus.SelectedItem.Text);
                            DataSet dsTrace = dbObj.GetMax_Traceid();
                            int TraceId;
                            if (dsTrace.Tables[0].Rows.Count > 0)
                            {
                                if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                {
                                    TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                    TraceId = TraceId + 1;
                                }
                                else
                                {
                                    TraceId = 1;

                                }
                            }
                            else
                            {
                                TraceId = 1;
                            }
                            int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl7.Text, Convert.ToInt32(txt7.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr7.Text);
                            int iUpdate = dbObj.UpdateUnitQty(Id, lbl7.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt7.Text), ddlbatchstatus.SelectedItem.Text, txtpr7.Text);
                            lbl7.Visible = false; txt7.Visible = false; txtpr7.Visible = false;

                        }
                        else if (lbl8.Visible == true)
                        {
                            int Id = 0;
                            DataSet dsGR = dbObj.GetMax_TransGR();
                            if (dsGR.Tables[0].Rows.Count > 0)
                            {
                                if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                {
                                    Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                }
                                else
                                {
                                    Id = 1;

                                }
                            }
                            else
                            {
                                Id = 1;
                            }

                            int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl8.Text, Convert.ToInt32(txt8.Text), txtpr8.Text,ddlbatchstatus.SelectedItem.Text);
                            DataSet dsTrace = dbObj.GetMax_Traceid();
                            int TraceId;
                            if (dsTrace.Tables[0].Rows.Count > 0)
                            {
                                if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                {
                                    TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                    TraceId = TraceId + 1;
                                }
                                else
                                {
                                    TraceId = 1;

                                }
                            }
                            else
                            {
                                TraceId = 1;
                            }
                            int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl8.Text, Convert.ToInt32(txt8.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr8.Text);
                            int iUpdate = dbObj.UpdateUnitQty(Id, lbl8.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt8.Text), ddlbatchstatus.SelectedItem.Text, txtpr8.Text);
                            lbl8.Visible = false; txt8.Visible = false; txtpr8.Visible = false;
                        }
                        else
                        {
                            int Id = 0;
                            DataSet dsGR = dbObj.GetMax_TransGR();
                            if (dsGR.Tables[0].Rows.Count > 0)
                            {
                                if (dsGR.Tables[0].Rows[0]["Id"].ToString() != null && dsGR.Tables[0].Rows[0]["Id"].ToString() != "")
                                {
                                    Id = Convert.ToInt32(dsGR.Tables[0].Rows[0]["Id"].ToString());

                                }
                                else
                                {
                                    Id = 1;

                                }
                            }
                            else
                            {
                                Id = 1;
                            }

                            int iSuccess = dbObj.InsertTransGR(Convert.ToInt32(txtGRNnumber.Text), lbl9.Text, Convert.ToInt32(txt9.Text), txtpr9.Text,ddlbatchstatus.SelectedItem.Text);
                            DataSet dsTrace = dbObj.GetMax_Traceid();
                            int TraceId;
                            if (dsTrace.Tables[0].Rows.Count > 0)
                            {
                                if (dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != null && dsTrace.Tables[0].Rows[0]["TraceId"].ToString() != "")
                                {
                                    TraceId = Convert.ToInt32(dsTrace.Tables[0].Rows[0]["TraceId"].ToString());
                                    TraceId = TraceId + 1;
                                }
                                else
                                {
                                    TraceId = 1;

                                }
                            }
                            else
                            {
                                TraceId = 1;
                            }
                            int iSuccess1 = dbObj.InsertTransetraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), lbl9.Text, Convert.ToInt32(txt9.Text), ddlStatus.SelectedItem.Text, Convert.ToInt32(txtGRNnumber.Text), TraceId, txtpr9.Text);
                            int iUpdate = dbObj.UpdateUnitQty(Id, lbl9.Text, Convert.ToInt32(ddlProductid.SelectedValue), txtBatch.Text, txtExpDate.Text, Convert.ToInt32(txt9.Text), ddlbatchstatus.SelectedItem.Text, txtpr9.Text);
                            lbl9.Visible = false; txt9.Visible = false; txtpr9.Visible = false;
                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Unable to Process, Quantity Mismatch!');", true);
                }
                DataSet dsUnits1 = new DataSet();
                dsUnits1 = dbObj.Select_Units1();
                if (dsUnits1.Tables[0].Rows.Count > 0)
                {
                    ddUnits1.DataSource = dsUnits1.Tables[0];
                    ddUnits1.DataBind();
                }
                btnCalSubmit.Visible = false;
            }
        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (btnCalSubmit.Visible == true)
            {
                string script = "alert('Please Click The check&submit button')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                if (txtExpDate.Text == "")
                {
                    string script = "alert('Select Expiry Date')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                }
                else if (txtBatch.Text == "")
                {
                    string script = "alert('Enter Batch Number')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                }
                else if (ddlSelectapprover.SelectedValue == "Select Approver")
                {
                    string script = "alert('Select Approver')";
                    ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                }
                else
                {
                    if (btnSubmit.Text == "Submit")
                    {
                        DateTime date = DateTime.Now;
                        int iSuccess = dbObj.InsertGR(Convert.ToInt32(ddlPOnumber.SelectedValue), Convert.ToInt32(ddlProductid.SelectedValue), txtDosageform.Text, txtStrength.Text, Convert.ToInt32(txtOrderqty.Text), Convert.ToDouble(txtOrderAmount.Text), txtBatch.Text, Convert.ToInt32(txtRecdQty.Text), txtExpDate.Text, Convert.ToInt32(txtPallets.Text), Convert.ToString(ddlbatchstatus.SelectedItem.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, date);
                        int iSuccess1 = dbObj.UpdatePO_GoodReceipt(Convert.ToInt32(ddlPOnumber.SelectedValue), Convert.ToInt32(ddlProductid.SelectedValue));
                        int iSuccess2 = dbObj.InsertTraceablity(Convert.ToInt32(ddlPOnumber.SelectedValue), Convert.ToInt32(ddlProductid.SelectedValue), Convert.ToInt32(txtGRNnumber.Text), txtBatch.Text, Convert.ToInt32(ddlSelectapprover.SelectedValue));
                        // int iSuccess1 = dbObj.InsertGRandUnits(Convert.ToInt32(ddlProductid.SelectedValue),txtBatch.Text,txtExpDate.Text, Convert.ToInt32(txtRecdQty.Text));

                        Response.Redirect("GoodReceiptGrid.aspx");
                    }
                    else if (btnSubmit.Text == "Update")
                    {

                        int iSuccess = dbObj.UpdateGR(Convert.ToInt32(ViewState["vsGR"]), Convert.ToInt32(ddlPOnumber.SelectedValue), Convert.ToInt32(ddlProductid.SelectedValue), txtDosageform.Text, txtStrength.Text, Convert.ToInt32(txtOrderqty.Text), Convert.ToDouble(txtOrderAmount.Text), txtBatch.Text, Convert.ToInt32(txtRecdQty.Text), txtExpDate.Text, Convert.ToInt32(txtPallets.Text), Convert.ToString(ddlbatchstatus.SelectedItem.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text);
                        int iSuccess2 = dbObj.UpdatetblTrancetraceablity(Convert.ToInt32(ViewState["vsGR"]), ddlStatus.SelectedItem.Text);
                        string script = "alert('Data Updated')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                        Response.Redirect("GoodReceiptGrid.aspx");
                    }
                }
            }
       }
    }
   
}