<%@ Page Title="" Language="C#" MasterPageFile="~/anaTasarim.master" AutoEventWireup="true" CodeFile="ogrKaydi.aspx.cs" Inherits="ogrKaydi" %>


<%@ Register src="userControl/ogrKaydi.ascx" tagname="ogrKaydi" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:ogrKaydi ID="ogrKaydi1" runat="server" />
    </asp:Content>

