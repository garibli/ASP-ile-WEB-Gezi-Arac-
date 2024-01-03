<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="BirimSil.aspx.cs" Inherits="SKSEkrani_SilmeIslemleri_BirimSil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style2 {
            width: 100%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container ">
    * Silinen birimin tüm alt bolumleride silinecekdir!!<asp:GridView ID="GridViewBirimler" runat="server" CellPadding="4" 
    ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" 
    Caption="Silincek Birimi Seçiniz" CssClass="table "
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

