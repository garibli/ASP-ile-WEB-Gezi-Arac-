<%@ Page Title="" Language="C#" MasterPageFile="~/ogrEkrani/OgrMaster.master" AutoEventWireup="true" CodeFile="Anket3.aspx.cs" Inherits="ogrEkrani_Anket3" %>

<%@ Register src="../userControl/Anket3.ascx" tagname="Anket3" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:Anket3 ID="Anket31" runat="server" />
</asp:Content>

