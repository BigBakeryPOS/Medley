<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashbord.aspx.cs" Inherits="Medly_Wm.Dashbord" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Dashbord</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
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
    <link href="../assets/global/css/components-md.min.css" rel="stylesheet" id="style_components"
        type="text/css" />
    <link href="../assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME GLOBAL STYLES -->
    <!-- BEGIN THEME LAYOUT STYLES -->
    <link href="../assets/layouts/layout2/css/layout.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/layouts/layout2/css/themes/blue.min.css" rel="stylesheet" type="text/css"
        id="style_color" />
    <link href="../assets/layouts/layout2/css/custom.min.css" rel="stylesheet" type="text/css" />
    <!-- END THEME LAYOUT STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
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

    <style>
        /*.col-lg-12 {
                padding: 10px;
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
                <form id="form2" runat="server">
                    <div class="row">
                    <div class="col-lg-12">
                        <div class="portlet light" style="height:600px">
                                <div>
                                    <h1 style="font-family: 'Times New Roman', Times, serif; height: 50px; text-align: center">DashBord</h1>
                                </div>
                            <div class="portlet light ">
                                <div class="form-body">
                                    <div class="first" style="background-color: lightblue;">
                                        <div class="col-lg-4">
                                            <h3><b>Supplier </b>
                                            </h3>
                                            <div class="col-lg-6">
                                                    Total Suppliers
                                                </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" CssClass="align-content-lg-end" ID="lblTotalsuppliers" runat="server" />
                                            </div>

                                            <div class="col-lg-6">
                                                Qualified Suppliers
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lblQualifiedsuppliers" runat="server" />
                                            </div>
                                            <div class="col-lg-6">
                                                Non Qualified Suppliers
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lblNqsuppliers" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <h3><b>Warehouse </b>
                                            </h3>
                                            <div class="col-lg-6">
                                                Total Units
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lblTotalunits" runat="server" />
                                            </div>
                                            <div class="col-lg-6">
                                                Occupied Units
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lblOccupiedunits" runat="server" />
                                            </div>
                                            <div class="col-lg-6">
                                                Available Units
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lblAvailableuniuts" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <h3><b>Stocks </b>
                                            </h3>
                                            <div class="col-lg-6">
                                                Total Quantity
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lblTotalqty" runat="server" />
                                            </div>
                                            <div class="col-lg-6">
                                                Sample Quantiy
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lblSampleqty" runat="server" />
                                            </div>
                                            <div class="col-lg-6">
                                                Quarantine
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lblquarantinebatch" runat="server" />
                                            </div>
                                            <div class="col-lg-6">
                                                Released
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lblReleasedbatch" runat="server" />
                                            </div>

                                            <div class="col-lg-6">
                                                Rejected
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lblRejectedbatch" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="Second">
                                        <div class="col-lg-4">
                                            <h3><b>Purchase Order </b>
                                            </h3>
                                            <div class="col-lg-6">
                                                Total Purchase
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lblTotalPO" runat="server" />
                                            </div>
                                            <div class="col-lg-6">
                                                Closed Purchase
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lblClosedPO" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-8">
                                            <h3><b>Sales Order </b>
                                            </h3>
                                             <div class="col-lg-3">
                                                  <label></label>
                                                 <asp:DropDownList runat="server" ID="txtpo" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtpo_TextChanged">
                                                     <asp:ListItem Text="Select" Value="" />
                                                     <asp:ListItem Text="Today" />
                                                     <asp:ListItem Text="Yesterday" />
                                                     <asp:ListItem Text="TotalPo" />
                                                 </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-4">
                                                <label>From Date</label>
                                                <asp:TextBox runat="server" ID="txtfromate" TextMode="Date" CssClass="form-control"/>
                                            </div>
                                            <div class="col-lg-4">
                                                <label>To Date</label>
                                                <asp:TextBox runat="server" ID="txttodate" TextMode="Date" CssClass="form-control" />  
                                            </div>
                                            <div class="col-lg-1">
                                                <label></label>
                                                <asp:Button Text="Check" ID="check" CssClass="btn btn-success" OnClick="check_Click" runat="server" /> 
                                            </div>
                                          <div class="col-lg-6">
                                                Total PO
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lblTotalSo" runat="server" />
                                            </div>
                                             <div class="col-lg-6">
                                                Total PO Amount
                                            </div>
                                            <div class="col-lg-6">
                                                <asp:Label Text="text" ID="lbltotalamount" runat="server" />
                                            </div>
                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </div>
                </div>
                </form>
            </div>
            </div>
        </div>
</body>
</html>
