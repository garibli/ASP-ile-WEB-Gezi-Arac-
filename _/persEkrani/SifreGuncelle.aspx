<%@ Page Title="" Language="C#" MasterPageFile="~/persEkrani/PersMaster.master" AutoEventWireup="true" CodeFile="SifreGuncelle.aspx.cs" Inherits="persEkrani_SifreGuncelle" %>

<%@ Register src="../userControl/SifreDegis.ascx" tagname="SifreDegis" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:SifreDegis ID="SifreDegis1" runat="server" />
</asp:Content>

