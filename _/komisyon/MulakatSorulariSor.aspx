<%@ Page Title="" Language="C#" MasterPageFile="~/komisyon/komisyonPage.master" AutoEventWireup="true" CodeFile="MulakatSorulariSor.aspx.cs" Inherits="komisyon_MulakatSorulariSor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container margin-bottom-40 row col-md-12">
    <asp:Label ID="lblAdSoyad" runat="server" Text="" Font-Size="Larger"></asp:Label><br />
    <asp:Label ID="lblBirim" runat="server" Text="" Font-Size="Larger"></asp:Label><br />
    <font size="2">Mulakat Puanı:</font><asp:Label ID="lblEklenecekPuan" runat="server" Text="0" Font-Size="Large"></asp:Label><br />
    <asp:Label ID="lblBirimPuan" runat="server" Text="" Visible="false"></asp:Label>
</div>

<div class="container col-md-12">
<div id="mulakatSoru1" runat="server" visible="false" class="col-md-12 row margin-bottom-10">
    <div class="col-md-3"><asp:Label ID="lblMSoru1" runat="server" Text=""   Font-Size="Larger"></asp:Label></div>
    <div class="col-md-6"><asp:DropDownList ID="ddlSoruCevap1" runat="server" CssClass="form-control col-md-3"
        onselectedindexchanged="ddlSoruCevap1_SelectedIndexChanged" AutoPostBack="true">
    <asp:ListItem Value="0" Selected="True">seciniz</asp:ListItem>
    <asp:ListItem Value="1">Yetersiz</asp:ListItem>
    <asp:ListItem Value="2">Az Yeterli</asp:ListItem>
    <asp:ListItem Value="3">Orta Yeterli</asp:ListItem>
    <asp:ListItem Value="4">Yeterli</asp:ListItem>
    <asp:ListItem Value="5">Çok Yeterli</asp:ListItem>
    </asp:DropDownList></div>
    </div>
    <div id="mulakatSoru2"  runat="server" visible="false"  class="row col-md-12 margin-bottom-10">
    <div class="col-md-3"><asp:Label ID="lblMsoru2" runat="server" Text="" Font-Size="Larger"></asp:Label></div>
    <div class="col-md-6">
      <asp:DropDownList ID="ddlSoruCevap2" runat="server"  class="form-control " 
            AutoPostBack="true" onselectedindexchanged="ddlSoruCevap2_SelectedIndexChanged">
    <asp:ListItem Value="0" Selected="True">seciniz</asp:ListItem>
    <asp:ListItem Value="1">Yetersiz</asp:ListItem>
    <asp:ListItem Value="2">Az Yeterli</asp:ListItem>
    <asp:ListItem Value="3">Orta Yeterli</asp:ListItem>
    <asp:ListItem Value="4">Yeterli</asp:ListItem>
    <asp:ListItem Value="5">Çok Yeterli</asp:ListItem>
    </asp:DropDownList></div>
    </div>
    <div id="mulakatSoru3"  runat="server" visible="false" class="col-md-12 row margin-bottom-10">
    <div class="col-md-3"><asp:Label ID="lblMsoru3" runat="server" Text=""  Font-Size="Larger"></asp:Label></div>
     <div class="col-md-6"> <asp:DropDownList ID="ddlSoruCevap3" runat="server"  class="form-control col-md-3"
            AutoPostBack="true" onselectedindexchanged="ddlSoruCevap3_SelectedIndexChanged">
    <asp:ListItem Value="0" Selected="True">seciniz</asp:ListItem>
    <asp:ListItem Value="1">Yetersiz</asp:ListItem>
    <asp:ListItem Value="2">Az Yeterli</asp:ListItem>
    <asp:ListItem Value="3">Orta Yeterli</asp:ListItem>
    <asp:ListItem Value="4">Yeterli</asp:ListItem>
    <asp:ListItem Value="5">Çok Yeterli</asp:ListItem>
    </asp:DropDownList>
    </div></div>
    <div id="mulakatSoru4"  runat="server" visible="false" class="col-md-12 row margin-bottom-10">
    <div class="col-md-6"> <div class="col-md-3"><asp:Label ID="lblMsoru4" runat="server" Text=""   Font-Size="Larger"></asp:Label></div>
      <asp:DropDownList ID="ddlSoruCevap5" runat="server" class="form-control col-md-3"
            AutoPostBack="true" 
            onselectedindexchanged="ddlSoruCevap5_SelectedIndexChanged"  >
    <asp:ListItem Value="0" Selected="True">seciniz</asp:ListItem>
    <asp:ListItem Value="1">Yetersiz</asp:ListItem>
    <asp:ListItem Value="2">Az Yeterli</asp:ListItem>
    <asp:ListItem Value="3">Orta Yeterli</asp:ListItem>
    <asp:ListItem Value="4">Yeterli</asp:ListItem>
    <asp:ListItem Value="5">Çok Yeterli</asp:ListItem>
    </asp:DropDownList></div>
    </div>
    <div><br />
    <div class="row col-md-12">
    <div class="col-md-3"></div>
    <div class="col-md-5">
    <asp:Button ID="btnPuanVer" runat="server" Text="Puan Ver" 
        CssClass="btn blue " onclick="btnPuanVer_Click" />
        </div></div></div>
  </div>
</asp:Content>

