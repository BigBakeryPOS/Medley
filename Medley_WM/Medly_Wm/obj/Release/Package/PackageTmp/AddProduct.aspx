<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Medly_Wm.AddProduct" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="Preview page of Metronic Admin Theme #2 for statistics, charts, recent events and reports"
        name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"
        rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <link href="../assets/global/plugins/bootstrap-daterangepicker/daterangepicker.min.css"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/morris/morris.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/fullcalendar/fullcalendar.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="../assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <link href="../assets/layouts/layout2/css/layout.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/layouts/layout2/css/custom.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
    <meta charset="utf-8" />
    <title>Product Master</title>
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="Preview page of Metronic Admin Theme #2 for bootstrap inputs, input groups, custom checkboxes and radio controls and more" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN THEME GLOBAL STYLES -->
    <link href="assets/global/css/components-md.min.css" rel="stylesheet" id="style_components" type="text/css" />
    <link href="assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <link href="assets/layouts/layout2/css/layout.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/layouts/layout2/css/themes/blue.min.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="assets/layouts/layout2/css/custom.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />



    <style type="text/css">
        /* body {
            font-size: 16px;
            font-family:'Maiandra GD';
        }
        label{
            font-family:'Franklin Gothic';
            font-size: 16px;
        }

        .auto-style1 {
            font-size: 14px;
            line-height: 1.42857;
            color: #555;
            display: block;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: none !important;
            -webkit-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
            outline-width: 0;
            outline-style: none;
            outline-color: invert;
            border: 1px solid #c2cad8;
            padding: 6px 12px;
            background-color: #fff;
            background-image: none;
        }

        .row {
            padding: 8px;
        }

        td {
           text-align:left
        }
        .auto-style2 {
            left: 1px;
            top: -1px;
        }
        .auto-style3 {
            float: right;
            width: 248px;
        }*/
    </style>



</head>

<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">

    <usc1:Sidebar ID="h1" runat="server" />
    <div class="page-container">

        <usc:Header ID="Header" runat="server" />
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">

                <form id="form1" runat="server">
                    <div>
                        <div class="row">
                            <div class="col-lg-12">
                                <!-- BEGIN SAMPLE FORM PORTLET-->
                                <div class="portlet light ">
                                    <div class="portlet-title">
                                        <div class="caption font-red-sunglo">
                                            <i class="icon-settings font-red-sunglo"></i>
                                            <span class="caption-subject bold uppercase">Add Product</span>
                                        </div>
                                        <div class="actions">
                                            <%-- <div class="btn-group">
                                                <a class="btn btn-sm red dropdown-toggle" href="" data-toggle="dropdown">Home
                                                </a>
                                            </div>--%>
                                            <div class="btn-group">
                                                <%--<a class="btn btn-sm green dropdown-toggle" href="" data-toggle="dropdown">--%>
                                                <%--<i class="fa fa-angle-down"></i>--%>
                                                </a>
                                                <%-- <ul class="dropdown-menu pull-right">
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="fa fa-pencil"></i>Edit </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="fa fa-trash-o"></i>Delete </a>
                                                    </li>
                                                    <li>
                                                        <a href="javascript:;">
                                                            <i class="fa fa-ban"></i>Ban </a>
                                                    </li>
                                                    <li class="divider"></li>
                                                    <li>
                                                        <a href="javascript:;">Make admin </a>
                                                    </li>
                                                </ul>--%>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-body">

                                        <div class="col-lg-12">
                                            <div class="col-lg-6">

                                                      <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                Product Code
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtProductCode" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-square-left">
                                                                    <i class="fa fa-user"></i>
                                                                </span>
                                                                <asp:TextBox ID="txtProductCode" runat="server" CssClass="form-control" placeholder="Enter Product Code" />
                                                            </div>
                                                        </div>

                                                    </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>Inintial addition date
                                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtInitialadditiondate" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-calendar"></i>
                                                            </span>
                                                            <asp:TextBox runat="server" type="date" ID="txtInitialadditiondate" CssClass="form-control" placeholder=" Selet Date" TextMode="Date" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>
                                                            Product Name
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtProductname" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtProductname" placeholder=" Enter Product Name " />

                                                        </div>
                                                    </div>


                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">

                                                        <label>
                                                            License No.
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtLicenseno" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>
                                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtLicenseno" placeholder="Enter License Name" />

                                                        </div>
                                                        <%-- <label style="float: right">0 to 20 Characters</label>--%>
                                                    </div>
                                                </div>

                                              <%--  <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>
                                                            Valid Till
                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtvalidtill" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-calendar"></i>
                                                            </span>
                                                            <asp:TextBox ID="txtvalidtill" TextMode="Date" runat="server" CssClass="form-control" />
                                                        </div>
                                                    </div>
                                                </div>--%>


                                                <div class="col-lg-6">

                                                    <label>Dosage Form</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-plus-square"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ControlToValidate="ddlDosageform" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                        <asp:DropDownList ID="ddlDosageform" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="Tablet" />
                                                            <asp:ListItem Text="Capsule" />
                                                            <asp:ListItem Text="Gel" />
                                                            <asp:ListItem Text="Drops" />
                                                            <asp:ListItem Text="Solution" />
                                                            <asp:ListItem Text="Suspension" />
                                                            <asp:ListItem Text="Caplet" />
                                                            <asp:ListItem Text="Effervescent Tablets" />

                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                                <%--       <div class="col-lg-4">

                                                    <label>
                                                        Pack Type</label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-refresh"></i>
                                                        </span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ControlToValidate="ddlPacktype" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        <asp:DropDownList ID="ddlPacktype" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="Ltrs" />
                                                            <asp:ListItem Text="Grms" />
                                                            <asp:ListItem Text="Mls" />

                                                        </asp:DropDownList>
                                                    </div>

                                                </div>--%>

                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label>
                                                            Pack Size
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtPacksize" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </label>

                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-bar-chart"></i>
                                                            </span>
                                                            <asp:TextBox ID="txtPacksize" runat="server" CssClass="form-control" placeholder="Enter Size"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>



                                                <div></div>
                                                <%--                                               <div class="col-lg-4">
                                                    <label>
                                                        Pack Price<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ControlToValidate="txtPriceperpack" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-usd"></i>
                                                        </span>
                                                        <asp:TextBox runat="server" ID="txtPriceperpack" CssClass="form-control" placeholder="Enter Price" />
                                                    </div>

                                                </div>--%>
                                               
                                                <%--    <div class="col-lg-6">

                                                    <label>
                                                        Currency<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ControlToValidate="ddlCurrency" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-dollar"></i>
                                                        </span>
                                                        <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="GBP"></asp:ListItem>
                                                            <asp:ListItem Text="INR"></asp:ListItem>
                                                            <asp:ListItem Text="USD"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>--%>
                                               

                                                <div class="col-lg-12">
                                                </div>
                                            </div>
                                            <div class="">
                                                <div class="col-lg-6">
                                                     <div class="col-lg-6">

                                                    <label>
                                                        Strength
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtStrength" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-adjust"></i>
                                                        </span>
                                                        <asp:TextBox ID="txtStrength" runat="server" CssClass="form-control" placeholder=" Enter Strength"></asp:TextBox>
                                                    </div>

                                                </div>
                                                       <div class="col-lg-6">
                                                            <div class="form-group">
                                                        <label>Taxation Type</label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-fa fa-bitcoin"></i>
                                                            </span>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="*" ControlToValidate="ddlTaxationtype" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                            <asp:DropDownList ID="ddlTaxationtype" runat="server" CssClass="form-control">
                                                                <asp:ListItem Value="">Select</asp:ListItem>
                                                                <asp:ListItem Text="Cash" />
                                                                <asp:ListItem Text="Cheque" />
                                                            </asp:DropDownList>
                                                        </div>
                                                                </div>
                                                    </div>
                                                     <div class="col-lg-6">
                                                         <div class="form-group">
                                                    <label>
                                                        Product Manufacturer
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-industry"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="ddlProductanufacture" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                        <asp:DropDownList ID="ddlProductanufacture" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="Medley" />
                                                            <asp:ListItem Text="Wholesale" />
                                                            <asp:ListItem Text="Others" />
                                                        </asp:DropDownList>
                                                    </div>
                                                             </div>
                                                </div>
                                                                                                         <div class="col-lg-6">
                                                         <div class="form-group">
                                                    <label>
                                                        Product Category
                                                    </label>
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-industry"></i>
                                                        </span>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ControlToValidate="ddlProductanufacture" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                        <asp:DropDownList ID="ddlproductcatogory" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="POM" />
                                                            <asp:ListItem Text="FOOD SUPLEMENT" />
                                                            <asp:ListItem Text="P" />
                                                            <asp:ListItem Text="GSL" />
                                                            <asp:ListItem Text="NA" />
                                                        </asp:DropDownList>

                                                    </div>
                                                             </div>
                                                </div>
                                                  

                                             <%--       <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>Product Manufacture Country</label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-square-left">
                                                                    <i class="fa fa-globe"></i>
                                                                </span>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="*" ControlToValidate="ddlproductmanufacturecountry" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                <asp:DropDownList ID="ddlproductmanufacturecountry" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                                    <asp:ListItem Text="India" />
                                                                    <asp:ListItem Text="USA" />
                                                                    <asp:ListItem Text="England" />
                                                                    <asp:ListItem Text="UAE" />
                                                                </asp:DropDownList>

                                                            </div>
                                                        </div>
                                                    </div>--%>

                                                    <%--<div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                Product Code
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtProductCode" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-square-left">
                                                                    <i class="fa fa-user"></i>
                                                                </span>
                                                                <asp:TextBox ID="txtProductCode" runat="server" CssClass="form-control" placeholder="Enter Product Code" />
                                                            </div>
                                                        </div>

                                                    </div>--%>
                                                    <div class="col-lg-6">
                                                        <div class="form-group">
                                                        <label>
                                                            GTIN Barcode
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtGTINBarcode" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </label>
                                                        <div class="input-group">
                                                            <span class="input-group-addon input-square-left">
                                                                <i class="fa fa-user"></i>
                                                            </span>
                                                            <asp:TextBox ID="txtGTINBarcode" runat="server" CssClass="form-control" placeholder="Enter Bracode Code" />
                                                        </div>
                                                            </div>
                                                    </div>


                                                 <%--   <div class="col-lg-12">
                                                        <div class="form-group">


                                                            <label>
                                                                Product Approval Authority<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="*" ControlToValidate="ddlProductapprovalauthority" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-square-left">

                                                                    <i class="fa fa-line-chart"></i>
                                                                </span>
                                                                <asp:DropDownList ID="ddlProductapprovalauthority" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                                    <asp:ListItem Text="Manager" />
                                                                    <asp:ListItem Text="Client" />
                                                                    <asp:ListItem Text="Superviser" />
                                                                </asp:DropDownList>

                                                            </div>
                                                        </div>
                                                    </div>--%>
                                                   <%-- <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                Product Approval Status<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="*" ControlToValidate="ddlProductapprovalstatus" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-square-left">
                                                                    <i class="fa fa-check-square-o"></i>
                                                                </span>
                                                                <asp:DropDownList ID="ddlProductapprovalstatus" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Value="">Select</asp:ListItem>
                                                                    <asp:ListItem Text="Yes" />
                                                                    <asp:ListItem Text="No" />
                                                                </asp:DropDownList>

                                                            </div>
                                                        </div>
                                                    </div>--%>
                                                  <%--  <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>
                                                                Tax%<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="*" ControlToValidate="txtTax" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-square-left">
                                                                    <i class="fa fa-user"></i>
                                                                </span>
                                                                <asp:TextBox ID="txtTax" runat="server" CssClass="form-control" placeholder="Enter Tax" />
                                                            </div>
                                                        </div>
                                                    </div>--%>                                                 
                                                   <%--<div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>Product Photo</label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-square-left">
                                                                    <i class="fa fa-photo"></i>
                                                                </span>
                                                                <asp:FileUpload ID="imgProductphoto" runat="server" CssClass="form-control" placeholder="Max Size 2MB" />
                                                            </div>
                                                        </div>
                                                    </div>--%>
                                                       <div class="col-lg-6">
                                                        <div class="form-group">
                                                            <label>Minimum Stock Qty
                                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Validation" runat="server" ErrorMessage="*" ControlToValidate="txtminimumqty" ForeColor="Red"></asp:RequiredFieldValidator>
                                                            </label>
                                                            <div class="input-group">
                                                                <span class="input-group-addon input-square-left">
                                                                    <i class="fa fa-size"></i>
                                                                </span>
                                                                <asp:TextBox ID="txtminimumqty" runat="server" CssClass="form-control" placeholder="Product Quanity" />
                                                                <%-- <asp:TextBox ID="txtProductphoto" runat="server" CssClass="form-control" placeholder="Max Size 2MB"></asp:TextBox>--%>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <%-- <div class="col-lg-6">

                                                            <div style="padding: 30px">
                                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                                            </div>
                                                        </div>--%>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="col-lg-6">

                                                    <label>Select Approver </label>
                                                     <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="ddlselectapprover"
                                                ValidationGroup="Validation" Text="*" ErrorMessage="Please Enter Contact Number" Style="color: Red" />
                                                    <div class="input-group">
                                                        <span class="input-group-addon input-square-left">
                                                            <i class="fa fa-fa fa-bitcoin"></i>
                                                        </span>
                                                        <asp:DropDownList ID="ddlSelectapprover" runat="server" CssClass="form-control" placeholder="Select">
                                                            <asp:ListItem Value="">Select</asp:ListItem>
                                                            <asp:ListItem Text="Manager"></asp:ListItem>
                                                            <asp:ListItem Text="Client"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                                <div class="col-lg-6">
                                                    <label>Select Status </label>
                                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" placeholder="Select" Enabled="false">
                                                        <asp:ListItem Value="">Select</asp:ListItem>
                                                        <asp:ListItem Text="Draft" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Approved"></asp:ListItem>
                                                        <asp:ListItem Text="Rejected"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <br />
                                            <br />
                                        </div>
                                        <div class="col-lg-12">
                                            <center>
                                                <div class="form-group">
                                                    <div class="col-lg-12" style="padding-top: 20px">

                                                        <%--  <asp:Button ID="btsclear" Text="Clear" runat="server" CssClass="btn default" PostBackUrl="~/AddProduct.aspx"  />--%>
                                                        <asp:Button ID="btnSubmit" Text="Submit" ValidationGroup="Validation" runat="server" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                                                        <asp:Button ID="btncancel" Text="Cancel" runat="server" CssClass="btn btn-danger" PostBackUrl="~/ProductGridpage.aspx" />



                                                    </div>
                                                </div>
                                            </center>
                                        </div>
                                        <div class="row">
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                </form>
            </div>
        </div>
    </div>

    <!-- BEGIN CORE PLUGINS -->
    <%--<script src="assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN THEME GLOBAL SCRIPTS -->
    <script src="assets/global/scripts/app.min.js" type="text/javascript"></script>
    <!-- END THEME GLOBAL SCRIPTS -->
    <!-- BEGIN THEME LAYOUT SCRIPTS -->
    <script src="assets/layouts/layout2/scripts/layout.min.js" type="text/javascript"></script>
    <script src="assets/layouts/layout2/scripts/demo.min.js" type="text/javascript"></script>
    <script src="assets/layouts/global/scripts/quick-sidebar.min.js" type="text/javascript"></script>
    <script src="assets/layouts/global/scripts/quick-nav.min.js" type="text/javascript"></script>
    <!-- END THEME LAYOUT SCRIPTS -->
    <script>
        $(document).ready(function () {
            $('#clickmewow').click(function () {
                $('#radio1003').attr('checked', 'checked');
            });
        })
    </script>--%>
</body>
</html>

