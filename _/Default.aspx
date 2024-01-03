<%@ Page Title="" Language="C#" MasterPageFile="~/anaTasarim.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="userControl/Login.ascx" tagname="Login" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Login ID="Login1" runat="server" />
</asp:Content>

