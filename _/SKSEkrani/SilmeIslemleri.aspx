<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="SilmeIslemleri.aspx.cs" Inherits="SKSEkrani_SilmeIslemleri_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    Silme işlemi yapılcak bolumu seçiniz
<br />
<asp:Button ID="btnBirimSil" runat="server" Height="20px" Text="Birim Sil" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnBirimSil_Click"  />
        &nbsp;<asp:Button ID="btnAltBirimSil" runat="server" Height="20px" 
    Text="Alt Birim Sil" Width="117px" BackColor="White" BorderColor="#000066" 
    BorderStyle="Solid" ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnAltBirimSil_Click"  />
        &nbsp;<asp:Button ID="btnCalisanSil" runat="server" Height="20px" 
    Text="Calisan Sil" Width="117px" BackColor="White" BorderColor="#000066" 
    BorderStyle="Solid" ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnCalisanSil_Click"  />
&nbsp;<asp:Button ID="btnPersSil" runat="server" Height="20px" 
    Text="Personel Sil" Width="117px" BackColor="White" BorderColor="#000066" 
    BorderStyle="Solid" ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnPersSil_Click"  />
&nbsp;<asp:Button ID="btnPersSil0" runat="server" Height="20px" 
    Text="SGK Geçmişi" Width="117px" BackColor="White" BorderColor="#000066" 
    BorderStyle="Solid" ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnPersSil0_Click"  />
&nbsp;<asp:Button ID="btnPersSil1" runat="server" Height="20px" 
    Text="Çalışma Yerleri Geçmişi" Width="150px" BackColor="White" BorderColor="#000066" 
    BorderStyle="Solid" ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
    OnClick="btnPersSil1_Click"  />
&nbsp;
</asp:Content>

