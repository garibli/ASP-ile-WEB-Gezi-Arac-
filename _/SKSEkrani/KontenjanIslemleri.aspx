<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="KontenjanIslemleri.aspx.cs" Inherits="SKSEkrani_KontenjanIslemleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>

.conte
{
    width:600px;
    height:auto;
    margin-left:15px
}

.conteMin
{
    width:600px;
    height:150px
}




</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="conte">
    <div class="conteMin">
    <div style="margin-bottom:5px">  
        Yapılcak İşlemi Seçiniz.</div>

<asp:Button ID="btnBirimKonteGuncelle" runat="server" Height="20px" Text="Birim Kontenjanı" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnBirimKonteGuncelle_Click"  />
    &nbsp;
   
<asp:Button ID="btnBolumKonte" runat="server" Height="20px" Text="Bölüm Kontenjanı" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnBolumKonte_Click"  />
   </div>
</div>

</asp:Content>

