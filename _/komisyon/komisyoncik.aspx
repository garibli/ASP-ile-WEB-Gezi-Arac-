<%@ Page Title="" Language="C#" MasterPageFile="~/komisyon/komisyonPage.master" AutoEventWireup="true" CodeFile="komisyoncik.aspx.cs" Inherits="komisyon_komisyoncik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<font size="3">  <asp:Label ID="lbl" runat="server" Text="Komisyon üyeliğinden çıkmak istiyorsanız aşağıdaki butona tıklayınız"></asp:Label></font>   <br /><br />
<asp:Button ID="komisyoncik" runat="server" Text="KOMİSYON UYE CIKIŞI" 
        CssClass="btn btn-default" onclick="komisyoncik_Click" /></asp:Content>

