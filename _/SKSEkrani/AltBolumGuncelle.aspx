<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="AltBolumGuncelle.aspx.cs" Inherits="SKSEkrani_AltBolumGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="container">
    <div class="row">
    <div class="col-md-3">Birime Göre Listele</div>
    <div class="col-md-5">
    <asp:DropDownList ID="ddlBirim" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlBolum_SelectedIndexChanged" CssClass="btn btn-default dropdown-toogle col-md-12">
    </asp:DropDownList>
    </div>
    </div>
 <div class="row"> 
 <hr />
 </div>
 <div class="row">
  <div class="col-md-3">Birim ID</div>
    <div class="col-md-5">
        <asp:TextBox ID="txtBirimID" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
    </div>
    </div>
    <div class="row">
    <div class="col-md-3"> Alt  Birim Adı</div>
    <div class="col-md-5">-
    <asp:TextBox ID="txtBirimAdi" runat="server" CssClass="form-control" AutoPostBack="True" 
        MaxLength="50"></asp:TextBox>
    </div>
    </div>
    <div class="row">
<div class="col-md-3">
    
    Öğrenim Türu</div>

<div class="col-md-5">
    
            <asp:DropDownList ID="ddlOgrenimTuru" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="0">Öğrencisi Olmayan</asp:ListItem>
                <asp:ListItem Value="1">Ön Lisans</asp:ListItem>
                <asp:ListItem Value="2">Lisans</asp:ListItem>
                <asp:ListItem Value="3">Yüksek Lisans</asp:ListItem>
                <asp:ListItem Value="4">Doktora</asp:ListItem>
            </asp:DropDownList>
    

    </div>
    </div>
    <div class="row">
     <div class="col-md-3">
         Bölüm Türü</div>
    <div class="col-md-5">
            <asp:DropDownList ID="ddlBolumTuru" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="0">Öğrencisi Olmayan</asp:ListItem>
                <asp:ListItem Value="1">Sayısal</asp:ListItem>
                <asp:ListItem Value="2">Sözel</asp:ListItem>
                <asp:ListItem Value="3">Tıp</asp:ListItem>
                <asp:ListItem Value="4">Genel</asp:ListItem>
            </asp:DropDownList>
    
        </div>
    </div>
    <div class="row">
    <div class="col-md-3"></div>
    <div class="col-md-5">
    
        <asp:Button ID="btnGuncelle" runat="server" CssClass="btn btn-default" Text="Güncelle" 
            OnClick="btnGuncelle_Click"  />
    
    </div>
    </div>
    <div class="row"> 
        <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    </div>
    </div>
    <div class="container">
    <asp:GridView ID="GridViewBirimler" runat="server" CellPadding="4" CssClass="table"
    ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" 
    Caption="Güncellenecek Birimi Seçiniz" 
    OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    </div>
    


</asp:Content>

