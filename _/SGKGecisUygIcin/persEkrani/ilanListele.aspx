<%@ Page Title="" Language="C#" MasterPageFile="~/persEkrani/PersMaster.master" AutoEventWireup="true" CodeFile="ilanListele.aspx.cs" Inherits="persEkrani_ilanListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style type="text/css">
        .auto-style5 {
            max-width: 50px;
            min-width:50px;
        }
        .auto-style7 {
           max-width: 140px;
           min-width:140px;
        }
        .auto-style9 {
            max-width: 100px;
            min-width:100px;

        }
        .auto-style10 {
           max-width: 210px;
           min-width:210px;
        }
        .auto-style11 {
           max-width: 70px;
           min-width:70px;
        }
        .auto-style12 {
           max-width: 70px;
           min-width:70px;
        }
        .style1
        {
            width: 578px;
        }
        .style2
        {
            width: 13px;
        }
        .style3
        {
            width: 594px;
        }
        .style4
        {
            width: 18px;
        }
        .style5
        {
            width: 719px;
        }
        .style7
        {
            width: 101px;
        }
        .style8
        {
            width: 64px;
        }
        .style9
        {
            width: 129px;
        }
        .style10
        {
            width: 139px;
        }
        .style11
        {
            width: 165px;
        }
        .style12
        {
            width: 120px;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<div class="container">
    <div class="col-md-12">
        
      
        <asp:DataList ID="DlListe" runat="server" CellPadding="4"  CssClass="table"
             onitemcommand="DlListe_ItemCommand" ForeColor="#333333">
            <AlternatingItemStyle  BackColor="White" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle  Font-Bold="True" ForeColor="White" BackColor="#507CD1" />
            <HeaderTemplate>
           
         
                <table  class="col-md-12" >
                    <tr>
               
                        <td class="col-md-3 ">İDR/AKADE Birim adı</td>
                        <td class="col-md-2 "> Alt Bir./Böl. Adı(varsa)</td>
                        <td class="col-md-2 ">Çalişma Şekli</td>
                        <td class="col-md-3 ">İşin Özel Niteliği</td>
                        <td class="col-md-1 ">Kontenjan</td>
                        <td class="col-md-1 ">A4 Çıktı</td>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemStyle BackColor="#EFF3FB" />
            <ItemTemplate>
                <table  class="col-md-12" >
                    <tr>
                        <td class="col-md-3 "><%#Eval("BirimAdi") %></td>
                        <td class="col-md-2 "><%#Eval("altBolum") %></td>
                        <td class="col-md-2 "><%#Eval("calismaSekli") %></td>
                        <td class="col-md-3 "><%#Eval("isMetni")%></td>
                        <td class="col-md-1 "><%#Eval("kontenjan") %></td>
                        <td class="col-md-1 "><asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="DokumanDok" runat="server" Text="Çıktı al" CssClass="btn btn-default"></asp:LinkButton></td>
                    </tr>
                </table>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
    </div>
 </div>
</asp:Content>

