<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="SKSCalisanPuantaj.aspx.cs" Inherits="SKSEkrani_SKSCalisanPuantaj" %>

<%@ Register src="../userControl/PersOgrYoklama.ascx" tagname="PersOgrYoklama" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:PersOgrYoklama ID="PersOgrYoklama1" runat="server" />
</asp:Content>

