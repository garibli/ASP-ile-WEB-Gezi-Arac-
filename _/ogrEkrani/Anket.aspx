<%@ Page Title="" Language="C#" MasterPageFile="~/ogrEkrani/OgrMaster.master" AutoEventWireup="true" CodeFile="Anket.aspx.cs" Inherits="ogrEkrani_Anket" %>

<%@ Register src="../userControl/anket.ascx" tagname="anket" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:anket ID="anket1" runat="server" />
</asp:Content>

