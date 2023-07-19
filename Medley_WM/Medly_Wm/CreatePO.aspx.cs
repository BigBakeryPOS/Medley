using BusinessLayer;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medly_Wm
{
    public partial class CreatePO : System.Web.UI.Page
    {
        public string connnectionString;

        BSClass dbObj = new BSClass();
        int iPoid = 0;
        int iProductID = 0; int Empid = 0;
        //int iProductID = Convert.ToInt32(Request.QueryString.Get("iProductID"));
        protected void Page_Load(object sender, EventArgs e)
        {
            tble.Visible = true;
            if (!IsPostBack)
            {
               
                #region Clear Temp Table
                int iDelete = dbObj.ClearTempPO();
                #endregion

                #region GetMAxPO
                DataSet dsPO = dbObj.GetMaxPO();
              
                if (dsPO.Tables[0].Rows.Count > 0 && dsPO.Tables[0].Rows != null)
                {
                    txtPonumber.Text = Convert.ToString(dsPO.Tables[0].Rows[0]["Poid"].ToString());

                }
                else
                {

                    txtPonumber.Text = "1";
                }
                #endregion

                iProductID = Convert.ToInt32(Request.QueryString.Get("iProductID"));
                if (Request.Cookies["userInfo"]["EmployeeID"] != null && Request.Cookies["userInfo"]["Empname"] != null)
                {
                    Empid = Convert.ToInt32(Request.Cookies["userInfo"]["EmployeeID"]);


                }

                txtPodate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txtPodate.Enabled = false;
                #region create po grid 
                iPoid = Convert.ToInt32(Request.QueryString.Get("Poid"));

                if (iPoid != 0)
                {

                    DataSet dsPoid = new DataSet();
                    dsPoid = dbObj.selectPO_byPOid(iPoid);
                    ViewState["vsPoid"] = iPoid;

                    if (dsPoid.Tables[0].Rows.Count > 0)
                    {
                       // txtLicenseno.Text = dsPoid.Tables[0].Rows[0]["Licenseno"].ToString();
                        txtProductname.Text = dsPoid.Tables[0].Rows[0]["Productname"].ToString();
                        txtDosageform.Text = dsPoid.Tables[0].Rows[0]["Dosageform"].ToString();
                        txtStrength.Text = dsPoid.Tables[0].Rows[0]["Strength"].ToString();
                        //txtPacktype.Text = dsPoid.Tables[0].Rows[0]["Packtype"].ToString();
                        //txtPacksize.Text = dsPoid.Tables[0].Rows[0]["Packsize"].ToString();
                        txtPoqty.Text = dsPoid.Tables[0].Rows[0]["PoQty"].ToString();
                        txtPriceperpack.Text = dsPoid.Tables[0].Rows[0]["Priceperpack"].ToString();
                        txtproductamt.Text = dsPoid.Tables[0].Rows[0]["Productamt"].ToString();
                        btnSubmit.Text = "Update";
                    }
                }
                #endregion
           
                DataSet ds = dbObj.getSuppliername();
                ddlSuppliername.DataSource = ds;

                ddlSuppliername.DataTextField = "CompanyName";
                ddlSuppliername.DataValueField = "SupplierID";
                ddlSuppliername.DataBind();
                ddlSuppliername.Items.Insert(0, "Select CompanyName");

           
                DataSet ds1 = dbObj.getProductnamepo();
                ddlProductname.DataSource = ds1;

                ddlProductname.DataTextField = "Productname";
                ddlProductname.DataValueField = "ProductID";
                ddlProductname.DataBind();
                ddlProductname.Items.Insert(0, "Productname");

                #region LoadGrid CreatePO

                DataSet dscreatpo = new DataSet();
                dscreatpo = dbObj.Select_CreatePO();
                if (dscreatpo.Tables[0].Rows.Count > 0)
                {
                    grvCreatePo.DataSource = dscreatpo.Tables[0];
                    grvCreatePo.DataBind();
                }
                #endregion



                #region product details


                #endregion

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
            if (!IsPostBack)
            {
                if (iPoid != 0)
                {
                    #region Edit
                    iPoid = Convert.ToInt32(Request.QueryString.Get("Poid"));

                    if (iPoid != 0)
                    {
                        btnSubmit.Text = "Update";
                        //tble.Visible = false;
                        updategv.Visible = true;
                        #region update grid
                        DataSet dsupdatepo = new DataSet();
                        dsupdatepo = dbObj.Select_UpdatePo(iPoid);
                        ViewState["vsPo"] = iPoid;
                        if (dsupdatepo.Tables[0].Rows.Count > 0)
                        {
                            updategrid.DataSource = dsupdatepo.Tables[0];
                            updategrid.DataBind();
                        


                        #region edit povalues
                        int count = dsupdatepo.Tables[0].Rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            string productname = dsupdatepo.Tables[0].Rows[i]["Productid"].ToString();
                            string Licenseno = dsupdatepo.Tables[0].Rows[i]["Licenseno"].ToString();
                            string Productname = dsupdatepo.Tables[0].Rows[i]["Productname"].ToString();
                            string Dosageform = dsupdatepo.Tables[0].Rows[i]["Dosageform"].ToString();
                            string Strength = dsupdatepo.Tables[0].Rows[i]["Strength"].ToString();
                            //string Packtype = dsTempPO.Tables[0].Rows[i]["Packtype"].ToString();
                            //string Packsize = dsTempPO.Tables[0].Rows[i]["Packsize"].ToString();
                            string Packqty = dsupdatepo.Tables[0].Rows[i]["PoQty"].ToString();
                            string Priceperpack = dsupdatepo.Tables[0].Rows[i]["Priceperpack"].ToString();
                            string Productamnt = dsupdatepo.Tables[0].Rows[i]["Productamt"].ToString();
                            //int iSuccess1 = dbObj.InsertTransPOProducts(iPOMax, Convert.ToInt32(productname), Licenseno, Productname, Dosageform, Strength, Packqty, Priceperpack, Productamnt);
                        }
                            #endregion
                        }
                        #endregion

                        DataSet dsPoid = new DataSet();
                        dsPoid = dbObj.selectPO_byPoid(iPoid);
                        ViewState["vsPo"] = iPoid;

                        if (dsPoid.Tables[0].Rows.Count > 0)
                        {
                            int ApproverId = Convert.ToInt32(dsPoid.Tables[0].Rows[0]["ApproverId"].ToString());
                            if (ApproverId == Empid)
                            {
                                ddlStatus.Enabled = true;
                            }
                            txtPonumber.Text = Convert.ToInt32(Request.QueryString.Get("Poid")).ToString();
                            DataSet dspocreate = new DataSet();
                            dspocreate = dbObj.Select_CreatePo(iPoid);
                            ViewState["vsPo"] = iPoid;

                            if (dspocreate.Tables[0].Rows.Count > 0)
                            {
                                #region Dropdown supliername
                                DataSet ds2 = dbObj.getSuppliername();
                                ddlSuppliername.DataSource = ds2;

                                ddlSuppliername.DataTextField = "CompanyName";
                                ddlSuppliername.DataValueField = "SupplierID";
                                ddlSuppliername.DataBind();
                                ddlSuppliername.Items.Insert(0, "Select SupplierName");
                                #endregion
                                ddlSuppliername.Text = dspocreate.Tables[0].Rows[0]["SupplierId"].ToString();
                                txtPodate.Text = ((DateTime)dspocreate.Tables[0].Rows[0]["Podatetime"]).ToString("yyyy-MM-dd");
                                #region Dropdown Approver
                                DataSet dsApprovar1 = new DataSet();
                                dsApprovar1 = dbObj.Select_Employeename();
                                if (dsApprovar1.Tables[0].Rows.Count > 0)
                                {
                                    ddlSelectapprover.DataSource = dsApprovar1;
                                    ddlSelectapprover.DataTextField = "EmployeeName";
                                    ddlSelectapprover.DataValueField = "EmployeeID";
                                    ddlSelectapprover.DataBind();
                                    ddlSelectapprover.Items.Insert(0, "Select Approver");
                                }
                                #endregion
                                ddlSelectapprover.Text = dspocreate.Tables[0].Rows[0]["ApproverId"].ToString();
                                txtTotalpoamount.Text = dspocreate.Tables[0].Rows[0]["Amount"].ToString();
                                ddlStatus.Text = dspocreate.Tables[0].Rows[0]["Status"].ToString();
                                btnAddrows.Visible=false;
                            }
                        }
                    }
                }
                #endregion
            }


        }


        protected void btnAddrows_Click(object sender, EventArgs e)
        {
            int isucess = 0;
            isucess = dbObj.InsertProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPoqty.Text, txtPriceperpack.Text, txtproductamt.Text);
            //isucess = dbObj.InsertProducts(Convert.ToInt32(ddlProductname.Text), txtProductname.Text, txtDosageform.Text, txtStrength.Text, txtPacktype.Text, txtPacksize.Text, txtPoqty.Text, txtPriceperpack.Text, txtproductamt.Text);
            string script = "alert('Row added')";
            ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            DataSet dscreatpo = new DataSet();
            dscreatpo = dbObj.Select_CreatePO();
            if (dscreatpo.Tables[0].Rows.Count > 0)
            {
                grvCreatePo.DataSource = dscreatpo.Tables[0];
                grvCreatePo.DataBind();
                double totalPoAmount = 0;

                for (int i = 0; i < dscreatpo.Tables[0].Rows.Count; i++)
                {
                    double productAmount = Convert.ToDouble(dscreatpo.Tables[0].Rows[i]["productamt"].ToString());
                    totalPoAmount += productAmount;
                }
                txtTotalpoamount.Text = Convert.ToString(totalPoAmount);
                // Clearing the textboxes
               // txtLicenseno.Text = "";
                txtProductname.Text = "";
                txtDosageform.Text = "";
                txtStrength.Text = "";
                //txtPacktype.Text = "";
                //txtPacksize.Text = "";
                txtPoqty.Text = "";
                txtPriceperpack.Text = "";
                txtproductamt.Text = "";
            }
           




        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtproductamt.Text != "")
            {
                string script = "alert('Click Plus Button')";
                ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
            }
            else
            {

                if (ddlSuppliername.SelectedValue == "Select CompanyName")
                {
                    string script = "alert('Select CompanyName')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
                else if (ddlSelectapprover.SelectedValue == "Select Approver")
                {
                    string script = "alert('Select Approver')";
                    ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                }
                else
                {


                    if (btnSubmit.Text == "Submit")
                    {
                        int isucess = 0;

                        isucess = dbObj.InsertDetails(ddlSuppliername.SelectedValue, DateTime.Parse(txtPodate.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, txtTotalpoamount.Text);

                        #region GetMAxPO
                        DataSet dsPO = dbObj.GetMaxPO_only();
                        int iPOMax = Convert.ToInt32(dsPO.Tables[0].Rows[0]["Poid"].ToString());
                        #endregion

                        #region Insert_TransPO
                        DataSet dsTempPO = dbObj.Select_CreatePO();
                        if (dsTempPO.Tables[0].Rows.Count > 0)
                        {
                            int count = dsTempPO.Tables[0].Rows.Count;
                            for (int i = 0; i < count; i++)
                            {
                                string productname = dsTempPO.Tables[0].Rows[i]["Productid"].ToString();
                                string Licenseno = dsTempPO.Tables[0].Rows[i]["Licenseno"].ToString();
                                string Productname = dsTempPO.Tables[0].Rows[i]["Productname"].ToString();
                                string Dosageform = dsTempPO.Tables[0].Rows[i]["Dosageform"].ToString();
                                string Strength = dsTempPO.Tables[0].Rows[i]["Strength"].ToString();
                                //string Packtype = dsTempPO.Tables[0].Rows[i]["Packtype"].ToString();
                                //string Packsize = dsTempPO.Tables[0].Rows[i]["Packsize"].ToString();
                                string Packqty = dsTempPO.Tables[0].Rows[i]["PoQty"].ToString();
                                string Priceperpack = dsTempPO.Tables[0].Rows[i]["Priceperpack"].ToString();
                                string Productamnt = dsTempPO.Tables[0].Rows[i]["Productamt"].ToString();
                                int iSuccess1 = dbObj.InsertTransPOProducts(iPOMax, Convert.ToInt32(productname), Licenseno, Productname, Dosageform, Strength, Packqty, Priceperpack, Productamnt);
                            }
                        }
                        #endregion
                        #region Clear Temp Table
                        int iDelete = dbObj.ClearTempPO();
                        #endregion

                        string script = "alert('Row added')";
                        ClientScript.RegisterStartupScript(this.GetType(), "SaveMessage", script, true);
                        Response.Redirect("POGrid.aspx");

                    }
                    else if (btnSubmit.Text == "Update")
                    {
                        int isucess = 0;
                        isucess = dbObj.UpdateCreatePo(Convert.ToInt32(ViewState["vsPo"]), ddlSuppliername.SelectedValue, DateTime.Parse(txtPodate.Text), Convert.ToInt32(ddlSelectapprover.SelectedValue), ddlStatus.SelectedItem.Text, txtTotalpoamount.Text);
                        string script = "alert('Data Updated')";
                        ClientScript.RegisterStartupScript(this.GetType(), "UpdateMessage", script, true);
                        Response.Redirect("POGrid.aspx");
                    }
                }
            }
        }

        protected void ddlProductname_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsProdId = new DataSet();
            dsProdId = dbObj.selectProduct_byProductId(Convert.ToInt32(ddlProductname.SelectedValue));
            ViewState["vsPrdct"] = iProductID;

            if (dsProdId.Tables[0].Rows.Count > 0)
            {
                //txtLicenseno.Text = dsProdId.Tables[0].Rows[0]["Licenseno"].ToString();
                txtProductname.Text = dsProdId.Tables[0].Rows[0]["Productname"].ToString();
                txtDosageform.Text = dsProdId.Tables[0].Rows[0]["Dosageform"].ToString();
                txtStrength.Text = dsProdId.Tables[0].Rows[0]["Strength"].ToString();
                //txtPacktype.Text = dsProdId.Tables[0].Rows[0]["Packtype"].ToString();
                //txtPacksize.Text = dsProdId.Tables[0].Rows[0]["Packsize"].ToString();
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
        private void BindPo()
        {
            DataSet dsPO = new DataSet();
            dsPO = dbObj.Select_CreatePO();
            if (dsPO.Tables[0].Rows.Count > 0)
            {
                grvCreatePo.DataSource = dsPO.Tables[0];
                grvCreatePo.DataBind();
            }
            else
            {
                grvCreatePo.DataSource = null;
                grvCreatePo.DataBind();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void grvCreatePo_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            #region Edit
            if (e.CommandName == "editt")
            {
                Response.Redirect("CreatePO.aspx?Event=Edit&Poid=" + e.CommandArgument.ToString());
            }

            if (e.CommandName == "Del")
            {
                int iPoid = Convert.ToInt32(e.CommandArgument);
                dbObj.deletePO(iPoid);
                BindPo();
            }
            #endregion

        }

        protected void txtPoqty_TextChanged(object sender, EventArgs e)
        {
            DataSet dsProduct = new DataSet();
            dsProduct = dbObj.selectProduct_byProductId(Convert.ToInt32(ddlProductname.SelectedValue));
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                int poqty = 0;
                int.TryParse(txtPoqty.Text, out poqty);
                // Calculate the Total Batches
                int priceperpack = 0;
                int.TryParse(txtPriceperpack.Text, out priceperpack);
                int totalamount = poqty * priceperpack;
                // Set the value of the Total Batches TextBox
                txtproductamt.Text = totalamount.ToString();
            }
        }

        protected void txtPoeditqty_TextChanged(object sender, EventArgs e)
        {
            DataSet dsProduct = new DataSet();
            dsProduct = dbObj.selectProduct_byProductId(Convert.ToInt32(ddlProductname.SelectedValue));
            if (dsProduct.Tables[0].Rows.Count > 0)
            {
                int poqty = 0;
                int.TryParse(txtPoqty.Text, out poqty);
                // Calculate the Total Batches
                int priceperpack = 0;
                int.TryParse(txtPriceperpack.Text, out priceperpack);
                int totalamount = poqty * priceperpack;
                // Set the value of the Total Batches TextBox
                txtproductamt.Text = totalamount.ToString();
            }
        }

        //protected void txtproductamt_TextChanged(object sender, EventArgs e)
        //{
        //    // Retrieve the values from the textboxes
        //    decimal poQty = 0;
        //    decimal pricePerPack = 0;

        //    if (decimal.TryParse(txtPoqty.Text, out poQty) && decimal.TryParse(txtPriceperpack.Text, out pricePerPack))
        //    {
        //        // Perform the calculation
        //        decimal productAmount = poQty * pricePerPack;

        //        // Display the calculated product amount
        //        txtproductamt.Text = productAmount.ToString();
        //    }
        //    else
        //    {
        //        txtproductamt.Text = string.Empty; // Clear the textbox if the inputs are invalid
        //    }
        //}
    }
}