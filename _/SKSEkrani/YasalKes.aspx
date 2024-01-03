<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="YasalKes.aspx.cs" Inherits="SKSEkrani_YasalKes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/alanlar2.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
<div class="row">
<div class="col-md-3">Çalıştığı Birim</div>
<div class="col-md-5">
    <asp:DropDownList ID="ddlBirimler" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlBirimler_SelectedIndexChanged" CssClass="btn btn-default dropdown-toogle col-md-12">
    </asp:DropDownList>
    </div>
</div>
<div class="row">
<div class="col-md-3">Çalışan</div>
<div class="col-md-5">
    <asp:DropDownList ID="ddlCalisan" runat="server" 
        onselectedindexchanged="ddlCalisan_SelectedIndexChanged" CssClass="col-md-12 btn btn-default dropdown-toogle ">
    </asp:DropDownList>
    </div>
</div>
<%--<div class="conteMin">
<div class="textBox">Yansıtılcak Maaş Dönemi</div>
<div class="textBox">
    AY
    <asp:DropDownList ID="ddlMaasDonemiAY" runat="server" 
        onselectedindexchanged="ddlCalisan_SelectedIndexChanged" Width="61px">
        <asp:ListItem Selected="True">1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
    </asp:DropDownList>
    &nbsp;YIL
    <asp:DropDownList ID="ddlMaasDonemiYIL" runat="server" 
        onselectedindexchanged="ddlCalisan_SelectedIndexChanged" Width="61px">
        <asp:ListItem Selected="True">2014</asp:ListItem>
        <asp:ListItem>2015</asp:ListItem>
    </asp:DropDownList>
    </div>
</div>--%>
<%--<div class="conteMin">
<div class="textBox">Yasal Kesinti</div>
<div class="textBox">
    <asp:TextBox ID="txtYasalKes" runat="server" Width="150px"></asp:TextBox>
    </div>
</div>--%>
<div class="row">
<div class="col-md-3">Yasal Kesinti Orani*</div>
<div class="col-md-5">
    <asp:TextBox ID="txtOrani" runat="server" CssClass="form-control"></asp:TextBox>
   </div>
</div>
<div class="row col-md-offset-3 margin-bottom-10 margin-top-10"><strong>
    *Ondalıklı sayıların arasına virgül ( , ) koyunuz.</strong></div>
<div class="row">
<div class="col-md-3"></div>
<div class="col-md-5"> 
        <asp:Button ID="btnGir" runat="server" Text="Girin" CssClass="btn blue col-md-12" OnClick="btnGir_Click" />
           </div>
           
</div>
<div class="row">

    <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>

</div>

<div class="col-md-12 margin-top-20 center-block">

   

    <asp:GridView ID="GridViewBirimler" runat="server" CellPadding="4" CssClass="table"
    ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" 
    Caption="Silincek Kesintiyi Seçiniz" 
    OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>

   

</div>

</div>
</asp:Content>

