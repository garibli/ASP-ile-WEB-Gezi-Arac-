<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="kontenjanTalepGir.aspx.cs" Inherits="SKSEkrani_kontenjanTalepGir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container">
    <div class="col-md-12">
    <div class="row"><div class="col-md-1">AKADEMİK:</div><asp:Label ID="lblAkademik" runat="server" Text="Label"></asp:Label></div>
    <div class="row"><div class="col-md-1">İDARİ:</div><asp:Label ID="lblIdari" runat="server" Text="Label"></asp:Label></div>
    <div class="row margin-bottom-25"><div class="col-md-1">TOPLAM:</div><asp:Label ID="lblToplam" runat="server" Text="Label"></asp:Label></div>
    <div class="row">
        <asp:DataList ID="dtLstKontenjanTalep" runat="server" CssClass="table" 
            BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Horizontal" Font-Size="Small"
            onitemcommand="dtLstKontenjanTalep_ItemCommand">
            <AlternatingItemStyle BackColor="#F7F7F7" />
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderTemplate>
                <table class="nav-justified">
                    <tr>
                        <td class="col-md-3">
                            BİRİM</td>
                        <td class="col-md-2">
                            BÖLÜM</td>
                        <td class="col-md-1">
                            AKADEMİK</td>
                        <td class="col-md-1">
                            İDARİ</td>
                        <td class="col-md-1">
                            TARİH
                        </td>
                        <td class="col-md-1">
                            GİR</td>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <ItemTemplate>
                <table class="nav-justified">
                    <tr>
                        <td class="col-md-3">
                           <%#Eval("birim") %> </td>
                        <td class="col-md-2">
                            <%#Eval("bolum") %></td>
                        <td class="col-md-1">
                            <%#Eval("akademik") %></td>
                        <td class="col-md-1">
                            <%#Eval("idari") %></td>
                        <td class="col-md-1">
                            <%#Eval("tarih") %>
                        </td>
                        <td class="col-md-1">
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("id")%>'>KABUL</asp:LinkButton>
                            </td>
                    </tr>
                </table>
            </ItemTemplate>

            <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />

        </asp:DataList>
    </div>
    </div>
</div>
</asp:Content>

