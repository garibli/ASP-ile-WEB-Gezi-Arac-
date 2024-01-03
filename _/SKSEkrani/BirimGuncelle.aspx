<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="BirimGuncelle.aspx.cs" Inherits="SKSEkrani_BirimGuncelle" %>

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
    <div class="row margin-bottom-5">
    <div class="col-md-3">
        Birim ID</div>
    <div class="col-md-5">
    
        <asp:TextBox ID="txtBirimID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
    
    </div>
    </div>
    <div class="row margin-bottom-5">
    <div class="col-md-3">
    
        Birim Adı</div>

    <div class="col-md-5">
    
    <asp:TextBox ID="txtBirimAdi" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
    
    </div>
    </div>
    <div class="row margin-bottom-5">
<div class="col-md-3">
    
    Birim Turu</div>

<div class="col-md-5">
    
            <asp:DropDownList ID="ddlBirimTuru" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="0">Öğrencisi Olmayan</asp:ListItem>
                <asp:ListItem Value="5">Meslek Yüksekokulu</asp:ListItem>
                <asp:ListItem Value="1">Fakülte</asp:ListItem>
                <asp:ListItem Value="2">Enstitüsü Sayısal </asp:ListItem>
                <asp:ListItem Value="3">Enstitüsü Sözel</asp:ListItem>
                <asp:ListItem Value="4">Enstitüsü Sağlık </asp:ListItem>
                <asp:ListItem Value="6">Yuksekokul </asp:ListItem>
            </asp:DropDownList>
    </div>
    </div>
    <div class="row margin-bottom-5">
    <div class="col-md-3"></div>
    <div class="col-md-5">
    
        <asp:Button ID="btnGuncelle" runat="server" CssClass="btn btn-default" Text="Güncelle"  OnClick="btnGuncelle_Click"  />
    
    </div>
    </div>

    <div class="row"> 
        <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    </div>
    
    <div class="margin-top-20">
    <div class="col-md-offset-3 row" style="font-size:larger;color:##2D3E50">Güncellenecek Birimi Seçiniz</div>
    <asp:DataList ID="dtListBirimTablo" runat="server" CssClass="container col-md-9" 
            onitemcommand="dtListBirimTablo_ItemCommand">
        <HeaderTemplate>
            <table class="list-group-item active">
                <tr>
                    <td class="col-md-1">
                        SEÇ</td>
                    <td class="col-md-1">
                        ID</td>
                    <td class="col-md-4">
                        BİRİM ADI</td>
                    <td class="col-md-1">
                        BİRİM TÜRÜ</td>
                    <td class="col-md-2">
                        BİRİM KONTENJAN</td>
                </tr>
            </table>
        </HeaderTemplate>
        <ItemTemplate>
            <table class="list-group-item">
                <tr>
                    <td class="col-md-1">
                        <asp:LinkButton ID="lnkBirimSec" runat="server" CssClass="btn btn-default" CommandArgument='<%#Eval("id") %>'>SEÇ</asp:LinkButton> </td>
                    <td class="col-md-1">
                         <%#Eval("id")%></td>
                    <td class="col-md-4">
                         <%#Eval("adi")%></td>
                    <td class="col-md-1">
                         <%#Eval("BirimTuru")%></td>
                    <td class="col-md-2">
                         <%#Eval("UstKontenjan")%></td>
                </tr>
            </table>
        </ItemTemplate>
   
    </asp:DataList>
    </div>
    </div>
</asp:Content>

