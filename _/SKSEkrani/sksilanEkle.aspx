<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="sksilanEkle.aspx.cs" Inherits="SKSEkrani_sksilanEkle" %>
<%@ Register src="../userControl/ilanEkle.ascx" tagname="ilanEkle" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:ilanEkle ID="ilanEkle" runat="server" />
</asp:Content>

