<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="Listele.aspx.cs" Inherits="SKSEkrani_Listele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p>
        Listelenmek istenen bölümü seçiniz.</p>
    <p>
    <asp:Button ID="btnPersListele" runat="server" Height="20px" Text="Personel Listele" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
            onclick="btnPersListele_Click"  /> &nbsp;
<asp:Button ID="btnOgrListele" runat="server" Height="20px" Text="Öğrenci Listele" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
            onclick="btnOgrListele_Click"  />
    &nbsp;<asp:Button ID="btnBirimListele" runat="server" Height="20px" Text="Birim Listele" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
            onclick="btnBirimListele_Click"  />
    &nbsp;<asp:Button ID="btnBolumListele" runat="server" Height="20px" Text="Bölüm Listele" 
    Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
    ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
            onclick="btnBolumListele_Click"  />
   
    </p>

</asp:Content>

