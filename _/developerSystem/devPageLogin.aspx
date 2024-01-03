<%@ Page Language="C#" AutoEventWireup="true" CodeFile="devPageLogin.aspx.cs" Inherits="devPageLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css"/>
<link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
<link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css"/>
<link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css"/>
<link href="../assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css"/>
<link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css"/>
<!-- END GLOBAL MANDATORY STYLES -->
<!-- BEGIN PAGE LEVEL STYLES -->
<link href="../assets/admin/pages/css/lock.css" rel="stylesheet" type="text/css"/>
<!-- END PAGE LEVEL STYLES -->
<!-- BEGIN THEME STYLES -->
<link href="../assets/global/css/components.css" rel="stylesheet" type="text/css"/>
<link href="../assets/global/css/plugins.css" rel="stylesheet" type="text/css"/>
<link href="../assets/admin/layout/css/layout.css" rel="stylesheet" type="text/css"/>
<link id="style_color" href="../assets/admin/layout/css/themes/default.css" rel="stylesheet" type="text/css"/>
<link href="../assets/admin/layout/css/custom.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="page-lock">
	
   	<div class="page-body">
		<img class="page-lock-img" src="../assets/frontend/onepage/img/portfolio/6.jpg" alt="">
		<div class="page-lock-info">
			<h1>DEVELOPER</h1>
			<span class="email">
			WORK </span>
			<span class="locked">
			ENTER </span>
            <br />
            <br />
				<div class="input-group input-medium">

					<asp:TextBox ID="txtSifre" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" ></asp:TextBox>
					<span class="input-group-btn">
                        <asp:LinkButton ID="lnkButton" runat="server" CssClass="btn blue icn-only" 
                        onclick="lnkButton_Click"><i class="m-icon-swapright m-icon-white"></i></asp:LinkButton>
					
					</span>
				</div>
				<!-- /input-group -->
				<div class="relogin">
					
				</div>
		</div>
	</div>
    </div>
    </form>
    

</body>
</html>
