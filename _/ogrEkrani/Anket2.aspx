<%@ Page Title="" Language="C#" MasterPageFile="~/ogrEkrani/OgrMaster.master" AutoEventWireup="true" CodeFile="Anket2.aspx.cs" Inherits="ogrEkrani_Anket2" %>

<%@ Register src="../userControl/Anket2.ascx" tagname="Anket2" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Anket2 ID="Anket21" runat="server" />
</asp:Content>

