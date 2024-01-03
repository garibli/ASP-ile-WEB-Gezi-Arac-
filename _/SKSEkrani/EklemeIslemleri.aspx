<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="EklemeIslemleri.aspx.cs" Inherits="SKSEkrani_Ekleme_İşlemleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        İşlem yapılcak birimi seçiniz.</p>
    <p>
    <asp:Button ID="btnPersEkle" runat="server" Height="20px" Text="Personel Ekle/Sil" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
            onclick="btnPersEkle_Click"  /> &nbsp;<asp:Button ID="btnBirimEkle" 
            runat="server" Height="20px" Text="Birim Ekle" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
            onclick="btnBirimEkle_Click"  /> &nbsp;<asp:Button ID="btnBolumEkle" 
            runat="server" Height="20px" Text="Bölüm Ekle" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
            onclick="btnBolumEkle_Click"  /> 
    </p>
</asp:Content>

