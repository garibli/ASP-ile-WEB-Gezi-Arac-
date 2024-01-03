<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="SGKGecmisi.aspx.cs" Inherits="SKSEkrani_SGKGecmisi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/alanlar2.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="container">
<div class="row margin-bottom-10">
<div class="col-md-3">Çalıştığı Okulu</div>
<div class="col-md-5">
    <asp:DropDownList ID="ddlBirimler" runat="server" CssClass="form-control"
        AutoPostBack="True" onselectedindexchanged="ddlBirimler_SelectedIndexChanged">
    </asp:DropDownList>
    </div>
    </div>
    <div class="row margin-bottom-10">
    <div class="col-md-3">Öğrenciler</div>
<div class="col-md-5">
    <asp:DropDownList ID="ddlOgr" runat="server" CssClass="form-control"
        AutoPostBack="True" onselectedindexchanged="ddlOgr_SelectedIndexChanged">
    </asp:DropDownList>
    </div>
    </div>
<div>

        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateSelectButton="True" Caption="SGK Girişleri" CssClass="table " 
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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




</div>

</asp:Content>

