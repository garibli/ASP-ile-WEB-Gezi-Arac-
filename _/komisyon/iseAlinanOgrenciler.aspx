<%@ Page Title="" Language="C#" MasterPageFile="~/komisyon/komisyonPage.master" AutoEventWireup="true" CodeFile="iseAlinanOgrenciler.aspx.cs" Inherits="komisyon_iseAlinanOgrenciler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 1000px;
        }
        .styleAd
        {
            width:100px;
            font-size:small;
            }
            
        .styleSoyad
        {
            width:100px;
            font-size:small;
            }
            
        .styleBirim
        {
            width:150px;
            font-size:small;
            }
        .styleBolum
        {
            width:150px;
            font-size:small;
            }
        .styleCalistigiBirim
        {
            width:150px;
            font-size:small;
        }
        .styleCalismaSekli
        {
            width:150px;
            font-size:small;
            }
       .styleAktifPasif
        {
            width:100px;
            font-size:small;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList ID="ddlIseAlinanOgrenciler" runat="server" CssClass="table"
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
        CellPadding="2" ForeColor="Black">
        <AlternatingItemStyle BackColor="PaleGoldenrod" />
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <HeaderTemplate>
            <table class="style1">
                <tr>
                    <td class="styleAd">
                        Adı</td>
                    <td class="styleSoyad">
                        Soyadı</td>
                    <td class="styleBirim">
                        Birim</td>
                    <td class="styleBolum">
                        Bölüm</td>
                    <td class="styleCalistigiBirim">
                        Çalıştığı Birim</td>
                    <td class="styleCalismaSekli">
                        Calışma Şekli</td>
                        <td class="styleAktifPasif">
                        SGK Girisi</td>
                </tr>
            </table>
        </HeaderTemplate>
        <ItemTemplate>
            <table class="style1">
                <tr>
                    <td class="styleAd"> <%#Eval("ad") %></td>
                    <td class="styleSoyad"> <%#Eval("soyad") %></td>
                    <td class="styleBirim"> <%#Eval("birim") %></td>
                    <td class="styleBolum"> <%#Eval("bolum") %></td>
                    <td class="styleCalistigiBirim"> <%#Eval("calisacagiBirim") %></td>
                    <td class="styleCalismaSekli"> <%#Eval("calismaSekli") %></td>
                     <td class="styleAktifPasif"><%#Eval("sgkKontrol") %></td>
                </tr>
            </table>
        </ItemTemplate>
        <SelectedItemStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
    </asp:DataList>
</asp:Content>

