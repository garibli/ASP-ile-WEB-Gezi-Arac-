<%@ Page Language="C#" AutoEventWireup="true" CodeFile="developersPage.aspx.cs" Inherits="developersPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Kısmi Zamanlı Çalısan Sistemi</title>
       <link href="assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet">
  <link href="assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Global styles END --> 
   
  <!-- Page level plugin styles START -->
  <link href="assets/global/plugins/fancybox/source/jquery.fancybox.css" rel="stylesheet">
  <!-- Page leel plugin styles END -->

  <!-- Theme styles START -->
  <link href="assets/global/css/components.css" rel="stylesheet">
  <link href="assets/global/css/plugins.css" rel="stylesheet">
  <link href="assets/frontend/layout/css/style.css" rel="stylesheet">
  <link href="assets/frontend/layout/css/style-responsive.css" rel="stylesheet">
  <link href="assets/frontend/layout/css/themes/red.css" rel="stylesheet">
  <link href="assets/frontend/layout/css/custom.css" rel="stylesheet">
  </head>
<body>
    <form id="form1" runat="server">
    
    <div class="container">
    <div id="sayfa1" runat="server" class="col-md-offset-4">
        <div class="margin-top-20 col-md-4" >
            <asp:TextBox ID="txtSifre" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnGir" runat="server" Text="GİR"  CssClass="btn btn-primary" 
                onclick="btnGir_Click"/>
        </div>
    </div>
    <div id="sayfa2" runat="server">
    <div class="container margin-top-20 margin-bottom-10" style="color:Blue"><div class="col-md-6" style="font-size:larger"><strong class="col-md-offset-2"> İŞLER </strong></div><div class="col-md-6" style="font-size:larger"><strong class="col-md-offset-6">ALINAN İŞLER </strong></div></div>
    <div class="container">
    <div class="col-md-6">
        <asp:DataList ID="dtListAtanmamis" runat="server" 
            onitemcommand="dtListAtanmamis_ItemCommand">
         <ItemTemplate>
            <div class="col-md-11" >
            <div class="tab-content">
						<div id="tab_1" class="tab-pane active">
							<div id="accordion1" class="panel-group">
								<div class="panel panel-success" style="width:450px">
									<div class="panel-heading" >
										<h4 class="panel-title">
										<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href='#<%#Eval("id") %>a'>
										<strong ><%#Eval("isBaslik")%></strong> </a>
										</h4>
									</div>
									<div id="<%#Eval("id") %>a" class="panel-collapse collapse">
										<div class="panel-body">
											<%#Eval("isIcerik")%>
                                            <br />
                                            <br />
                                            <table class="margin-top-10">
                                            <tr>
                                            <td class="col-md-1"><%#Eval("tarih")%></td>
                                            <td class="col-md-1"><%#Eval("isAcillik")%></td>
                                            <td class="col-md-1"><%#Eval("kontrol")%></td>
                                            
                                            </tr>
                                            <tr>
                                            
                                            </tr>
                                            <tr>
                                              <td>
                                              <br />
                                              <br />
                                              <asp:LinkButton ID="lnkIsAta" runat="server" CssClass="btn btn-default" CommandArgument='<%#Eval("id") %>'>İŞİ AL</asp:LinkButton> </td>
                                            </tr>
                                            </table>
                                            
										</div>
									</div>
								</div>
								
							</div>
						</div>
						
								
						
								
								
							</div>
						</div>
            </ItemTemplate>
        </asp:DataList>
        </div>
        
    <div class="col-md-6">
        <asp:DataList ID="dtlistAtananIsler" runat="server" 
            onitemcommand="dtlistAtananIsler_ItemCommand">
         <ItemTemplate>
            <div class="col-md-11" >
            <div class="tab-content">
						<div id="tab_1" class="tab-pane active">
							<div id="accordion1" class="panel-group">
								<div class="panel panel-success" style="width:450px">
									<div class="panel-heading" >
										<h4 class="panel-title">
										<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href='#<%#Eval("id") %>'>
										<strong ><%#Eval("isBaslik")%></strong> </a>
										</h4>
									</div>
									<div id="<%#Eval("id") %>" class="panel-collapse collapse">
										<div class="panel-body">
											<%#Eval("isIcerik")%>
                                            <br />
                                            <br />
                                            <table class="margin-top-10">
                                            <tr>
                                            <td class="col-md-1"><%#Eval("tarih")%></td>
                                            <td class="col-md-1"><%#Eval("isAcillik")%></td>
                                            <td class="col-md-1"><%#Eval("kontrol")%></td>
                                            
                                            </tr>
                                            <tr>
                                            
                                            </tr>
                                            <tr>
                                              <td>
                                              <br />
                                              <br />
                                              <asp:LinkButton ID="lnkIsKaldir" runat="server" CssClass="btn btn-default" CommandArgument='<%#Eval("id") %>'>İPTAL ET</asp:LinkButton> </td>
                                            </tr>
                                            </table>
                                            
										</div>
									</div>
								</div>
								
							</div>
						</div>
						
								
						
								
								
							</div>
						</div>
            </ItemTemplate>
        </asp:DataList>
        
    </div>
    </div>

  



















    </div>
       <script src="assets/global/plugins/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>      
    <script src="assets/frontend/layout/scripts/back-to-top.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->

    <!-- BEGIN PAGE LEVEL JAVASCRIPTS (REQUIRED ONLY FOR CURRENT PAGE) -->
    <script src="assets/global/plugins/fancybox/source/jquery.fancybox.pack.js" type="text/javascript"></script><!-- pop up -->
    <script src="assets/global/plugins/carousel-owl-carousel/owl-carousel/owl.carousel.min.js" type="text/javascript"></script><!-- slider for products -->
        <!-- BEGIN RevolutionSlider -->
  
    <script src="assets/global/plugins/slider-revolution-slider/rs-plugin/js/jquery.themepunch.plugins.min.js" type="text/javascript"></script>
    <script src="assets/global/plugins/slider-revolution-slider/rs-plugin/js/jquery.themepunch.revolution.min.js" type="text/javascript"></script> 
    <script src="assets/global/plugins/slider-revolution-slider/rs-plugin/js/jquery.themepunch.tools.min.js" type="text/javascript"></script> 
    <script src="assets/frontend/pages/scripts/revo-slider-init.js" type="text/javascript"></script>
    <!-- END RevoutionSlider -->

    <script src="assets/frontend/layout/scripts/layout.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            Layout.init();
            Layout.initOWL();
            RevosliderInit.initRevoSlider();
            Layout.initTwitter();
            //Layout.initFixHeaderWithPreHeader(); /* Switch On Header Fixing (only if you have pre-header) */
            //Layout.initNavScrolling(); 
        });
    </script>
    </form>
</body>
</html>
