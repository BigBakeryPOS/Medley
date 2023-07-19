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
    public partial class CreateSO : System.Web.UI.Page
    {
        BSClass dbObj = new BSClass();
        int iSoid = 0;
        int iProductID = 0;int Empid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            table.Visible = true;
            if (!IsPostBack)
            {
                #region Clear Temp Table
                int iDelete = dbObj.ClearTempSO();
                #endregion

                txtSOdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtSOdate.Enabled = false;
                #region GetMAxSO
                DataSet dsPO = dbObj.GetMaxSO();
                if (dsPO.Tables[0].Rows.Count > 0 && dsPO.Tables[0].Rows != null)
                {
                    txtSOnumber.Text = Convert.ToString(dsPO.Tables[0].Rows[0]["Soid"].ToString());

                }
                else
                {

                    txtSOnumber.Text = "1";
                }
                #endregion
                DataSet ds = dbObj.getProductname();
                ddlProductname.DataSource = ds;
                ddlProductname.DataTextField = "Productname";
                ddlProductname.DataValueField = "ProductId";
                ddlProductname.DataBind();
                ddlProductname.Items.Insert(0, "Productname");
                #region LoadGrid CreatePO
                DataSet dscreatpo = new DataSet();
                dscreatpo = dbObj.Select_CreateSO();
                if (dscreatpo.Tables[0].Rows.Count > 0)
                {
                    grvCreateSo.DataSource = dscreatpo.Tables[0];
                    grvCreateSo.DataBind();
                }
                #endregion
            }
            if (!IsPostBack)
            {
                #region create so grid 
                iSoid = Convert.ToInt32(Request.QueryString.Get("Soid"));
                if (iSoid != 0)
                {
                    iProductID = Convert.ToInt32(Request.QueryString.Get("iProductID"));
                    if (Request.Cookies["userInfo"]["EmployeeID"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                    {
                        Empid = Convert.ToInt32(Request.Cookies["userInfo"]["EmployeeID"]);
                    }
                    DataSet dsSoid = new DataSet();
                    dsSoid = dbObj.selectSO_bySOid(iSoid);
                    ViewState["vsSoid"] = iSoid;
                    if (dsSoid.Tables[0].Rows.Count > 0)
                    {
                        txtLicenseno.Text = dsSoid.Tables[0].Rows[0]["Licenseno"].ToString();
                        txtProductname.Text = dsSoid.Tables[0].Rows[0]["Productname"].ToString();
                        txtDosageform.Text = dsSoid.Tables[0].Rows[0]["Dosageform"].ToString();
                        txtStrength.Text = dsSoid.Tables[0].Rows[0]["Strength"].ToString();
                        //txtPacktype.Text = dsSoid.Tables[0].Rows[0]["Packtype"].ToString();
                        //txtPacksize.Text = dsSoid.Tables[0].Rows[0]["Packsize"].ToString();
                        txtSoqty.Text = dsSoid.Tables[0].Rows[0]["SoQty"].ToString();
                        txtPriceperpack.Text = dsSoid.Tables[0].Rows[0]["Priceperpack"].ToString();
                        txtVAT.Text = dsSoid.Tables[0].Rows[0]["VAT"].ToString();
                        txttotalamt.Text = dsSoid.Tables[0].Rows[0]["Totalamount"].ToString();
                        btnSubmit.Text = "Update";
                    }
                }
                #endregion dropdown
                if (!IsPostBack)
                {
                    DataSet ds = dbObj.getSuppliername();
                    ddlSuppliername.DataSource = ds;
                    ddlSuppliername.DataTextField = "ContactName";
                    ddlSuppliername.DataValueField = "SupplierID";
                    ddlSuppliername.DataBind();
                    ddlSuppliername.Items.Insert(0, "Select Customer");
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
                    #region Edit
                    iSoid = Convert.ToInt32(Request.QueryString.Get("Soid"));
                    if (iSoid != 0)
                    {
                    btnSubmit.Text = "Update";
                    //   table.Visible = false;
                    gvsoupdate.Visible = true;
                        #region update grid
                        DataSet dsupdateso = new DataSet();
                        dsupdateso = dbObj.Select_UpdateSo(iSoid);
                        ViewState["vsSo"] = iSoid;
                        if (dsupdateso.Tables[0].Rows.Count > 0)
                        {
                            updatesogv.DataSource = dsupdateso.Tables[0];
                            updatesogv.DataBind();
                        }
                        #endregion
                        DataSet dsSoid = new DataSet();
                        dsSoid = dbObj.selectSO_bySoid(iSoid);
                        ViewState["vsPo"] = iSoid;
                        if (dsSoid.Tables[0].Rows.Count > 0)
                        {
                            int ApproverId = Convert.ToInt32(dsSoid.Tables[0].Rows[0]["ApproverId"].ToString());
                            if (ApproverId == Empid)
                            {
                                ddlStatus.Enabled = true;
                            }
                            txtSOnumber.Text = Convert.ToInt32(Request.QueryString.Get("Soid")).ToString();
                            DataSet dssocreate = new DataSet();
                            dssocreate = dbObj.Select_CreateSo(iSoid);
                            ViewState["vsPo"] = iSoid;
                            if (dssocreate.Tables[0].Rows.Count > 0)
                            {
                                #region Dropdown supliername
                                DataSet ds = dbObj.getSuppliername();
                                ddlSuppliername.DataSource = ds;
                                ddlSuppliername.DataTextField = "ContactName";
                                ddlSuppliername.DataValueField = "SupplierID";
                                ddlSuppliername.DataBind();
                                ddlSuppliername.Items.Insert(0, "Select SupplierName");
                                #endregion
                                ddlSuppliername.Text = dssocreate.Tables[0].Rows[0]["SupplierId"].ToString();
                                txtSOdate.Text = ((DateTime)dssocreate.Tables[0].Rows[0]["SOdatetime"]).ToString("yyyy-MM-dd");
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
                                ddlSelectapprover.Text = dssocreate.Tables[0].Rows[0]["ApproverId"].ToString();
                                txtTotalSOamount.Text = dssocreate.Tables[0].Rows[0]["Amount"].ToString();
                                ddlStatus.Text = dssocreate.Tables[0].Rows[0]["Status"].ToString();
                            btnAddrows.Visible=false;
                            }
                        }
                        #endregion

                        //if (iSoid != 0)
                        //{
                        //    gvsoupdate.Visible = true;
                        //    #region update grid
                        //    DataSet dsupdateso = new DataSet();
                        //    dsupdateso = dbObj.Select_UpdateSo(iSoid);
                        //    ViewState["vsSo"] = iSoid;
                        //    if (dsupdateso.Tables[0].Rows.Count > 0)
                        //    {
                        //        updatesogv.DataSource = dsupdateso.Tables[0];
                        //        updatesogv.DataBind();
                        //    }
                        //    #endregion
                        //}
                    }
                
            }
        }
        private void BindSo()
        {
            DataSet dsSO = new DataSet();
            dsSO = dbObj.Select_CreateSO();
            if (dsSO.Tables[0].Rows.Count > 0)
            {
                grvCreateSo.DataSource = dsSO.Tables[0];
                grvCreateSo.DataBind();
            }
        }
        protected void btnAddrows_Click(object sender, EventArgs e)
        {
            int isucess = 0;
            isucess = dbObj.InsertSoProducts(Convert.ToInt32(ddlProductname.Text), txtLicenseno.Text, txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtSoqty.Text, txtPriceperpack.Text,txtVAT.Text, txttotalamt.Text);
           // isucess = dbObj.InsertSoProducts(Convert.ToInt32(ddlProductname.Text), txtLicenseno.Text, txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPacktype.Text, txtPacksize.Text, txtSoqty.Text, txtPriceperpack.Text,txtVAT.Text, txttotalamt.Text);
            string script = "alert('Row added')";
            ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            DataSet dscreatso = new DataSet();
            dscreatso = dbObj.Select_CreateSO();
            if (dscreatso.Tables[0].Rows.Count > 0)
            {
                grvCreateSo.DataSource = dscreatso.Tables[0];
                grvCreateSo.DataBind();
                double totalSoAmount = 0; 
                for (int i = 0; i < dscreatso.Tables[0].Rows.Count; i++)
                {
                    double productAmount = Convert.ToDouble(dscreatso.Tables[0].Rows[i]["Totalamount"].ToString());
                    totalSoAmount += productAmount;
                }
                txtTotalSOamount.Text = Convert.ToString(totalSoAmount);
                txtLicenseno.Text = "";
                txtProductname.Text = "";
                txtDosageform.Text = "";
                txtStrength.Text = "";
               // txtPacktype.Text = "";
               // txtPacksize.Text = "";
                txtSoqty.Text = "";
                txtVAT.Text = "";
                txttotalamt.Text = "";
            }
        }
        protected void ddlProductname_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsProdId = new DataSet();
            dsProdId = dbObj.selectProduct_byProductId(Convert.ToInt32(ddlProductname.SelectedValue));
            ViewState["vsPrdct"] = iProductID;
            if (dsProdId.Tables[0].Rows.Count > 0)
            {
                txtLicenseno.Text = dsProdId.Tables[0].Rows[0]["Licenseno"].ToString();
                txtProductname.Text = dsProdId.Tables[0].Rows[0]["Productname"].ToString();
                txtDosageform.Text = dsProdId.Tables[0].Rows[0]["Dosageform"].ToString();
                txtStrength.Text = dsProdId.Tables[0].Rows[0]["Strength"].ToString();
               // txtPacktype.Text = dsProdId.Tables[0].Rows[0]["Packtype"].ToString();
               // txtPacksize.Text = dsProdId.Tables[0].Rows[0]["Packsize"].ToString();
                txtPriceperpack.Text = dsProdId.Tables[0].Rows[0]["Priceperpack"].ToString();
                //txtPacktype.Text = dsProdId.Tables[0].Rows[0]["Currency"].ToString();
                //ddlProductanufacture.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productmanufacture"].ToString();
                //ddlproductmanufacturecountry.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productmanufacturecountry"].ToString();
                //txtProductCode.Text = dsProdId.Tables[0].Rows[0]["Productcode"].ToString();
                //txtGTINBarcode.Text = dsProdId.Tables[0].Rows[0]["ProductGTINbarcode"].ToString();
                //ddlProductapprovalauthority.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productaprovalauthority"].ToString();
                //ddlProductapprovalstatus.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Productaprovalstatus"].ToString();
                //txtTax.Text = dsProdId.Tables[0].Rows[0]["Tax"].ToString();
                //ddlTaxationtype.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Taxationtype"].ToString();
                ////imgProductphoto.FileContent = dsDesgnId.Tables[0].Rows[0]["Productphoto"].ToString();
                //ddlSelectapprover.SelectedItem.Text = dsProdId.Tables[0].Rows[0]["Selectaproval"].ToString();
                //btnSubmit.Text = "Update";
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txttotalamt.Text != "")
            {
                string script = "alert('Click Plus Button')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {
                if (ddlSuppliername.SelectedValue == "Select Customer")
                {
                    string script = "alert('Select Customer')";
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
                        int isucess = 0;
                        isucess = dbObj.InsertSoDetails(ddlSuppliername.SelectedValue, DateTime.Parse(txtSOdate.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, txtTotalSOamount.Text);
                        #region GetMAxPO
                        DataSet dsSO = dbObj.GetMaxSO_only();
                        int iSOMax = Convert.ToInt32(dsSO.Tables[0].Rows[0]["Soid"].ToString());
                        #endregion
                        #region Insert_TransPO
                        DataSet dsTempSO = dbObj.Select_CreateSO();
                        if (dsTempSO.Tables[0].Rows.Count > 0)
                        {
                            int count = dsTempSO.Tables[0].Rows.Count;
                            for (int i = 0; i < count; i++)
                            {
                                string productname = dsTempSO.Tables[0].Rows[i]["Productid"].ToString();
                                string Licenseno = dsTempSO.Tables[0].Rows[i]["Licenseno"].ToString();
                                string Productname = dsTempSO.Tables[0].Rows[i]["Productname"].ToString();
                                string Dosageform = dsTempSO.Tables[0].Rows[i]["Dosageform"].ToString();
                                string Strength = dsTempSO.Tables[0].Rows[i]["Strength"].ToString();
                                string Packtype = dsTempSO.Tables[0].Rows[i]["Packtype"].ToString();
                                string Packsize = dsTempSO.Tables[0].Rows[i]["Packsize"].ToString();
                                string Packqty = dsTempSO.Tables[0].Rows[i]["SoQty"].ToString();
                                string Priceperpack = dsTempSO.Tables[0].Rows[i]["Priceperpack"].ToString();
                                string VAT = dsTempSO.Tables[0].Rows[i]["VAT"].ToString();
                                string Totalamount = dsTempSO.Tables[0].Rows[i]["Totalamount"].ToString();
                                int iSuccess1 = dbObj.InsertTransSo(iSOMax, Convert.ToInt32(productname), Licenseno, Productname, Dosageform, Strength, Packtype, Packsize, Packqty, Priceperpack, VAT, Totalamount);
                            }
                        }
                        #endregion
                        #region Clear Temp Table
                        int iDelete = dbObj.ClearTempSO();
                        #endregion
                        string script = "alert('Row added')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                        Response.Redirect("SOgrid.aspx");
                    }
                    else if (btnSubmit.Text == "Update")
                    {
                        int isucess = 0;
                        isucess = dbObj.UpdateCreateSo(Convert.ToInt32(ViewState["vsSo"]), ddlSuppliername.SelectedValue, DateTime.Parse(txtSOdate.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, txtTotalSOamount.Text);
                        string script = "alert('Data Updated')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                        Response.Redirect("SOGrid.aspx");
                    }
                }
            }
        }
        protected void grvCreateSo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Edit
            //if (e.CommandName == "editt")
            //{
            //    Response.Redirect("CreatePO.aspx?Event=Edit&Poid=" + e.CommandArgument.ToString());
            //}
            if (e.CommandName == "Del")
            {
                int iSoid = Convert.ToInt32(e.CommandArgument);
                dbObj.deleteSO(iSoid);
                BindSo();
                Response.Redirect("CreateSO.aspx");
            }
            #endregion
        }
        protected void txtSoqty_TextChanged(object sender, EventArgs e)
        {
            DataSet dsProduct = new DataSet();
            dsProduct = dbObj.selectProduct_byProductId(Convert.ToInt32(ddlProductname.SelectedValue));
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                //txtPriceperpack.Text = dsProduct.Tables[0].Rows[0]["Priceperpack"].ToString();
                int poqty = 0;
                int.TryParse(txtSoqty.Text, out poqty);

                DataSet dsProductqty = new DataSet();
                dsProductqty = dbObj.selectProduct_qty(Convert.ToInt32(ddlProductname.SelectedValue));
                if (poqty <= Convert.ToInt32(dsProductqty.Tables[0].Rows[0]["productqty"].ToString()))
                {
                    int pricePerPack = 0;
                    int.TryParse(txtPriceperpack.Text, out pricePerPack);
                    int totalamount = poqty * pricePerPack;
                    txttotalamt.Text = totalamount.ToString();
                }
                else
                {
                    int pricePerPack = 0;
                    int.TryParse(txtPriceperpack.Text, out pricePerPack);
                    int totalamount = poqty * pricePerPack;
                    txttotalamt.Text = totalamount.ToString();
                    //  string script = "alert('Given  Qty not available in werehouse')";
                    // ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                }
                    
            }
        }

        protected void txtVAT_TextChanged(object sender, EventArgs e)
        {
            string ttlamount = txttotalamt.Text;
            int vatamnt = (int.Parse(txttotalamt.Text) * int.Parse(txtVAT.Text)) / 100;
            int vatcal = int.Parse(ttlamount) + vatamnt;
            txttotalamt.Text = vatcal.ToString();
        }
    }
}