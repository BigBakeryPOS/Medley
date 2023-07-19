<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PickingList.aspx.cs" Inherits="Medly_Wm.PickingList" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/Header.ascx" %>
<%@ Register TagPrefix="usc1" TagName="Sidebar" Src="~/Sidebar.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Picking List</title>
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
    </style>
</head>
<body class="page-header-fixed page-sidebar-closed-hide-logo page-container-bg-solid page-md">
    <usc1:Sidebar ID="h1" runat="server" />
    <div class="page-container">
        <usc:Header ID="Header" runat="server" />
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
                <div class="portlet light">
                <form id="form2" runat="server">                   
                        <div class="row">
                            <div class="col-lg-4">
                                <b><asp:Label Text="Reference:" runat="server" /></b>
                                <asp:Label Text="F002-WAR-001- 04" ID="lblrefno" runat="server" />
                                <br />
                                <div style="padding-top:15px">
                                     <asp:Label Text="T002 -GEN-001-07"  runat="server" />
                                </div>
                               
                            </div>
                            <div class="col-lg-4" style="text-align:center">
                               <b> <asp:Label Text="FORM" runat="server" /></b>
                                <br />
                                <div style="padding-top:30px"> 
                                    <b> <asp:Label Text="PICKING LIST" runat="server" /></b>
                                </div>
                                
                            </div>
                            <div class="col-lg-4">
                                <div style="text-align:center">
                                     <asp:Image ID="Image1" runat="server" ImageUrl="logo.jpg" style="width:150px;height:50px" />
                                </div>
                                <div  style="text-align:center">
                                     <h4><b><asp:Label Text="MEDLEY PHARMA LTD" runat="server" /></b></h4>
                                    <asp:Label Text="Unit 2A, Olympic Way,Sefton Business Park,Bootle, Merseyside, L30 1RD VAT: 203004975" runat="server" />
                                </div>
                            </div>
                        </div>
                    <div class="row" style="padding-top:5px">
                        <div class="col-lg-3">
                            <b><asp:Label Text="Company Registration: " runat="server" /></b><asp:Label Text=": 0919662" ID="lblcompanyreg" runat="server" />
                        </div>
                         <div class="col-lg-6">
                        <b><asp:Label Text="Registered Office: " runat="server" /></b><asp:Label Text="Unit 2A, Olympic Way, Sefton Business Park, Aintree, Liverpool, L30 1RD" ID="lblregofc" runat="server" />
                        </div>
                         <div class="col-lg-3" style="text-align:right">
                              <b><asp:Label Text="VAT :" runat="server" /></b><asp:Label Text="203 0049 75" ID="lblvat" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="list-group">
                                <div style="padding-top:20px"> 
                                <table class="table table-bordered">
                                    <tr>
                                        <td>
                                         <b><asp:Label Text="PICKING LIST" runat="server" /></b>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblpicklist" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                                    </div>
                                
                                <div style="padding-top:20px">
                                <table class="table table-bordered" >
                                    <tr>
                                        <td> <b><asp:Label Text="Customer Name" runat="server" /></b></td>
                                        <td><asp:Label ID="lblCustname" runat="server" /></td>
                                        </tr>
                                    <tr>
                                        <td> <b><asp:Label Text="Delivery Address" runat="server" /></b></td>
                                        <td><asp:Label ID="lblDeladdress" runat="server" /></td>
                                    </tr>
                                </table>
                                    </div>
                                <div style="padding-top:20px">
                                    <table class="table table-bordered">
                                        <tr>
                                            <td><b><asp:Label Text="DATE PICKED:" runat="server" /></b></td>
                                            <td><asp:Label ID="lblDatepick" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                               <b> <asp:Label Text="PICKED BY: " runat="server" /></b></td>
                                            <td>
                                                <asp:Label ID="lblPickedby" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                               <b> <asp:Label Text="SIGNATURE:" runat="server" /></b></td>
                                            <td>
                                                <asp:Label ID="lblDignature" runat="server" /></td>
                                        </tr>
                                         <tr>
                                            <td>
                                               <b> <asp:Label Text="DELIVERY DATE: " runat="server" /></b></td>
                                            <td>
                                                <asp:Label ID="lblDeliverydate" runat="server" /></td>
                                        </tr>
                                         <tr>
                                            <td>
                                               <b> <asp:Label Text="BOOKING REF:" runat="server" /></b></td>
                                            <td>
                                                <asp:Label ID="lblBookref" runat="server" /></td>
                                        </tr>
                                    </table>
                                    </div>
                                <div style="padding-top:20px">
                                    <table class="table table-bordered">
                                        <tr>
                                            <td>
                                              <b> <asp:Label Text="APPROVED BY:" runat="server" /></b>
                                            </td>
                                             <td><asp:Label ID="LabelblApproved" runat="server" /></td>
                                        </tr>                                     
                                    </table>
                                    </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="list-group">
                                <div style="padding-top:20px">
                                    <table class="table table-bordered">
                                        <tr>
                                            <td>
                                                <b> <asp:Label Text="DATE PRINTED: " runat="server" /></b>
                                            </td>
                                             <td><asp:Label ID="lblDateprinted" runat="server" /></td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="padding-top:20px">
                                    <table class="table table-bordered">
                                        <tr>
                                            <td>
                                                <b> <asp:Label Text="ORDER REF:" runat="server" /></b>
                                            </td>
                                             <td><asp:Label ID="lblOrderref" runat="server" /></td>
                                        </tr>
                                    </table>
                                </div>
                                 <div style="padding-top:20px">
                                    <table class="table table-bordered">
                                        <tr>
                                            <td>
                                                <b> <asp:Label Text="COLLECTION ADDRESS: " runat="server" /></b>
                                            </td>
                                             <td><asp:Label ID="lblcolectiondeladd" runat="server" /></td>
                                        </tr>
                                    </table>
                                </div>
                                 <div style="padding-top:20px">
                                    <table class="table table-bordered">
                                        <tr>
                                            <td>
                                                <b> <asp:Label Text="COURIER:" runat="server" /></b>
                                            </td>
                                             <td><asp:Label ID="lblCourier" runat="server" /></td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <b> <asp:Label Text="DRIVERS SIGNATURE:" runat="server" /></b>
                                            </td>
                                             <td><asp:Label ID="lblDriversigna" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b> <asp:Label Text="VEHICLE REG:" runat="server" /></b>
                                            </td>
                                             <td><asp:Label ID="lblVehiclereg" runat="server" /></td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <b> <asp:Label Text="WAYBILL/TRACKING NO:" runat="server" /></b>
                                            </td>
                                             <td><asp:Label ID="lblTrackno" runat="server" /></td>
                                        </tr>
                                         <tr>
                                            <td>
                                                <b> <asp:Label Text="CONSIGNMENT WEIGHT:" runat="server" /></b>
                                            </td>
                                             <td><asp:Label ID="lblConsignmentweight" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b> <asp:Label Text="TOTAL NO. PALLETS: " runat="server" /></b>
                                            </td>
                                             <td><asp:Label ID="lbltotalnopallets" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b> <asp:Label Text="TOTAL NO. BOXES:" runat="server" /></b>
                                            </td>
                                             <td><asp:Label ID="lblTotalnobox" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b> <asp:Label Text="Date of Dispatch :" runat="server" /></b>
                                            </td>
                                             <td><asp:Label ID="Dtaeofdispatch" runat="server" /></td>
                                        </tr>
                                    </table>
                                </div>
                                </div>
                            </div>
                    </div>
                    <div style="padding-top:20px;">
                        <div class="row">
                            <table class="table table-bordered">
                                <tr>
                                    <th>PRODUCT</th>
                                    <th>QTY</th>
                                    <th>BATCH(ES)</th>
                                    <th>EXP. DATE</th>
                                    <th>FULL BOXES X NO. OF PACKS</th>
                                    <th>PART BOXES X NO. OF PACKS</th>
                                    </tr>
                                <tr>
                                    <td><asp:Label ID="lblproducts"  runat="server" /></td>
                                    <td><asp:Label  runat="server" ID="lblqty" /></td>
                                    <td><asp:Label  runat="server" /></td>
                                    <td><asp:Label  runat="server" ID="lblexpirydate" /></td>
                                    <td><asp:Label  runat="server" /></td>
                                    <td><asp:Label  runat="server" /></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </form>
                </div>
            </div>
        </div>

    </div>
</body>
</html>
