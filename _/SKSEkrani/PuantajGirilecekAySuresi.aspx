<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="PuantajGirilecekAySuresi.aspx.cs" Inherits="SKSEkrani_PuantajGirilecekAySuresi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
    <div class="col-md-5">
    AYIN BAŞINDAN İTİBAREN KAÇ GÜN SÜREYLE PUANTAJ GİRİLSİN ?<br />
    </div>
    <div class="col-md-4">
    <asp:TextBox ID="txtGunSayisi" runat="server" CssClass="form-control" AutoPostBack="True"></asp:TextBox>
    </div>
    <div class="col-md-3">
        <asp:Button ID="btnGir" runat="server" Text="Girin" 
    CssClass="btn btn-default"
    OnClick="btnGir_Click"  />
    </div>    
    <br />
    <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
     </div>   
</asp:Content>

