<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SifreDegis.ascx.cs" Inherits="userControl_SifreDegis" %>
<div class="container col-md-offset-3">
    <div class="row">
    <div class="col-md-3">Yeni Şifreniz</div>
    <div class="col-md-3">
    <asp:TextBox ID="txtSifre" runat="server" CssClass="btn btn-default" MaxLength="8" TextMode="Password"></asp:TextBox>
    </div>
    </div>
    <div class="row" style="margin-top:3px">
    <div class="col-md-3">Tekrar Yeni Şifreniz</div>
    <div class="col-md-3">
    <asp:TextBox ID="txtSifreTekrar" runat="server"  MaxLength="8" CssClass="btn btn-default" 
        TextMode="Password"></asp:TextBox>
        </div>
        </div>
        <div class="row">
        <div class="col-md-3"></div>
    
    <div class="col-md-3" style="margin-top:3px">
    <asp:Button ID="btnKaydet" runat="server" onclick="btnKaydet_Click" 
        Text="Kaydet" CssClass="btn btn-primary" />
    </div></div>

   <center>
    <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#000066"></asp:Label>
    </center>
</div>

