<%@ Page Title="" Language="C#" MasterPageFile="~/anaTasarim.master" AutoEventWireup="true" CodeFile="KisitliYetki.aspx.cs" Inherits="KisitliYetki" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    Sisteme giriş için yetki şifreniz :
    <asp:TextBox ID="txtSifre" runat="server" TextMode="Password" Width="196px"></asp:TextBox>
            
            <asp:Button ID="btnGonder" runat="server" Height="20px" Text="Gönder" Width="80px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" OnClick="btnGonder_Click" />
            
            </p>
<p>
    <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
</p>
</asp:Content>

