<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="TumBirimPuantajlari.aspx.cs" Inherits="SKSEkrani_TumBirimPuantajlari" %>

<%@ Register src="../userControl/OgrYoklama.ascx" tagname="OgrYoklama" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:OgrYoklama ID="OgrYoklama1" runat="server" />
</asp:Content>

