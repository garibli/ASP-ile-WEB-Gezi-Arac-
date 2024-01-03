<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="CalismaYerleri.aspx.cs" Inherits="SKSEkrani_CalismaYerleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

  <link href="../CSS/alanlar2.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .style2
        {
            color: #000066;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row">

<div class="col-md-3">Çalıştığı Okulu</div>



<div class="col-md-5">
    <asp:DropDownList ID="ddlBirimler" runat="server" CssClass="form-control"
        AutoPostBack="True" onselectedindexchanged="ddlBirimler_SelectedIndexChanged">
    </asp:DropDownList>
    </div>
    </div>
    <div class="row">
       <div class="col-md-3">Okuduğu Okulu</div>
    <div class="col-md-5">
    <asp:DropDownList ID="ddlOkuduguOkul" runat="server" CssClass="form-control"
        AutoPostBack="True" 
            onselectedindexchanged="ddlOkuduguOkul_SelectedIndexChanged">
    </asp:DropDownList>
    </div>
    <br />
    <br />
    
    </div>
    <div class="row">
    <div class="col-md-3">Öğrenciler</div>
<div class="col-md-5">
    <asp:DropDownList ID="ddlOgr" runat="server" CssClass="form-control"
        AutoPostBack="True" onselectedindexchanged="ddlOgr_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    
 
    
    <span class="row"><strong>*Enson Güncel SGK Bildirimini Silmeyiniz. Asıl 
    çıkış işlemleri SGK çıkış sayfasından yapılmaktadır.</strong></span></div>
<div class="container" >




        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateSelectButton="True" CssClass="table "  Caption="Çalışma Yerleri." 
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

