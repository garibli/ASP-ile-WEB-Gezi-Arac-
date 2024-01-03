<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="BilgiGuncelle.aspx.cs" Inherits="SKSEkrani_BilgiGuncelle" %>

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
        Çalışanlar İçin Yapılacak&nbsp; Güncelleme İşlemeni Seçiniz</div>

<asp:Button ID="btnGSSGuncelle" runat="server" Height="20px" Text="GSS Güncelle" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnGSSGuncelle_Click"  />
    &nbsp;<asp:Button ID="btnHesapNo" runat="server" Height="20px" Text="Hesap No Güncelle" 
    Width="125px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnHesapNo_Click"  />
    &nbsp;
   
<asp:Button ID="btnCalisanGuncelle" runat="server" Height="20px" Text="Çalışan Güncelle" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnCalisanGuncelle_Click"  />
   </div>
   <div class="conteMin">
    <div style="margin-bottom:5px"> 
       Diğerleri İçin Yapılacak&nbsp; Güncelleme İşlemeni Seçiniz</div>
      
<asp:Button ID="btnBirimGuncelle" runat="server" Height="20px" Text="Birim Güncelle" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnBirimGuncelle_Click"  />
   
   
   
<asp:Button ID="btnAltBolumGuncelleme" runat="server" Height="20px" Text="Bölüm Güncelle" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnAltBolumGuncelleme_Click"  />
   
   
   
<asp:Button ID="btnSGKGirisGuncelle" runat="server" Height="20px" Text="SGK Giriş Güncelle" 
    Width="130px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnSGKGirisGuncelle_Click"  />
   
   
   
<asp:Button ID="btnSGKCikisGuncelle" runat="server" Height="20px" Text="SGK Çıkış Güncelle" 
    Width="130px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnSGKCikisGuncelle_Click"  />
   
   
   
<asp:Button ID="btnSGKCikisGuncelle0" runat="server" Height="20px" Text="SGK Çıkış Sil" 
    Width="130px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnSGKCikisGuncelle0_Click"  />
   
   
   
   </div>
</div>


</asp:Content>

