<%@ Page Title="" Language="C#" MasterPageFile="~/komisyon/komisyonPage.master" AutoEventWireup="true" CodeFile="SoruGuncelle.aspx.cs" Inherits="komisyon_SoruGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container">
<div class="col-m-12 row margin-bottom-20">
  <div class="col-md-12"><font face="calibra" color="black" size="4"> <asp:Label ID="lblSoruSayisiHesapla" runat="server" Text="Mulakat sorularını oluşturma zorunluluğu yoktur. Uygun görmeniz halinde en fazla 4 soru oluşturulabilir."></asp:Label></font>
</div></div> 
<div class="margin-bottom-10 row col-md-12" id="sorularıBelirle1" runat="server">
    <div class="col-md-3"><asp:Label ID="lblSoru1" runat="server" Text="1.Soru"></asp:Label></div>
   <div class="col-md-7"> <asp:TextBox ID="txtSoru1" runat="server" CssClass="form-control"></asp:TextBox></div> 
</div>
    <div class="margin-bottom-10 row col-md-12" runat="server" id="sorularıBelirle2">
   <div class="col-md-3"> <asp:Label ID="lblSoru2" runat="server" Text="2.Soru"></asp:Label></div>
    <div class="col-md-7"><asp:TextBox ID="txtSoru2" runat="server" CssClass="form-control"></asp:TextBox></div>

    </div>
    <div  class="margin-bottom-10 row col-md-12" runat="server" id="sorularıBelirle3">
   <div class="col-md-3"> <asp:Label ID="lblSoru3" runat="server" Text="3.Soru"></asp:Label></div>
    <div class="col-md-7"><asp:TextBox ID="txtSoru3" runat="server" CssClass="form-control"></asp:TextBox></div>

    </div>
    <div class="margin-bottom-10 row col-md-12" runat="server" id="sorularıBelirle4">
    <div class="col-md-3"> <asp:Label ID="lblSoru4" runat="server" Text="4.Soru"></asp:Label></div>
    <div class="col-md-7"> <asp:TextBox ID="txtSoru4" runat="server" CssClass="form-control"></asp:TextBox></div>

    </div>
    <hr />
    
  <div class="col-md-12 row">
  <div class="col-md-3">
   <a href="../komisyon/Default.aspx" class="btn red col-md-12">İPTAL GERİ</a>
         </div>
   <div class="col-md-3">
   <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="btn blue col-md-12" onclick="btnKaydet_Click" />
  
   </div>     
       
</div>
    </div>
    
</asp:Content>

