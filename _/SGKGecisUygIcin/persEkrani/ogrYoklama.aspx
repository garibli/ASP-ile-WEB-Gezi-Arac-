<%@ Page Title="" Language="C#" MasterPageFile="~/persEkrani/PersMaster.master" AutoEventWireup="true" CodeFile="ogrYoklama.aspx.cs" Inherits="persEkrani_ogrGirisYoklama" %>

<%@ Register Src="~/userControl/OgrYoklama.ascx" TagPrefix="uc1" TagName="OgrYoklama" %>


<%@ Register src="../userControl/PersOgrYoklama.ascx" tagname="PersOgrYoklama" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <div>
        <uc2:PersOgrYoklama ID="PersOgrYoklama1" runat="server" />
    </div>
   
    
</asp:Content>

