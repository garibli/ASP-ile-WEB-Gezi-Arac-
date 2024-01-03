<%@ Page Title="" Language="C#" MasterPageFile="~/persEkrani/PersMaster.master" AutoEventWireup="true" CodeFile="komisyonSec.aspx.cs" Inherits="persEkrani_komisyonSec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 800px;
        }
        .auto-style3 {
            width: 367px;
            height: 42px;
        }
        .auto-style4 {
            width: 236px;
            height: 42px;
        }
        .auto-style5 {
            width: 125px;
            height: 42px;
        }
        .auto-style6 {
            height: 42px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblKomisyon" runat="server" Text=""></asp:Label>
    <asp:DataList ID="ddlKomisyonSec" runat="server" CellPadding="4" ForeColor="#333333" OnItemCommand="ddlKomisyonSec_ItemCommand">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle  Font-Bold="True" ForeColor="Black" />
        <HeaderTemplate>
         <div class="panel-heading" style="font-size:20px">KOMİSYON EKLE</div>
            <div class="panel panel-info">
            <table class="table">
                <tr>
                    <td class="auto-style5">Ad</td>
                    <td class="auto-style4">Soyad</td>
                    <td class="auto-style3">Mail</td>
                    <td class="auto-style6">Komisyon Sec</td>
                </tr>
            </table>
        </HeaderTemplate>
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            <table class="table">
                <tr>
                    <td class="auto-style5"><%#Eval("Ad") %></td>
                    <td class="auto-style4"><%#Eval("Soyad") %></td>
                    <td class="auto-style3"><%#Eval("Mail") %></td>
                    <td class="auto-style6">
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="komisyonSec"> <img src="../img/aktif.png"  style="width:20px;height:20px"/></asp:LinkButton>
                      </td>
                </tr>
            </table>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>
</asp:Content>

