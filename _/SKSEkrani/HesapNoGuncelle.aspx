<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="HesapNoGuncelle.aspx.cs" Inherits="SKSEkrani_HesapNoGuncelle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container">
    <div class="row"><div class="col-md-2">
        Öğrenci No :</div>
        <div class="col-md-4">
        <asp:TextBox ID="txtOgrNo" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
   <div class="row"><div class="col-md-2">
        Adı Soyadı :</div>
        <div class="col-md-4">
        <asp:TextBox ID="txtAdSoyad" runat="server" CssClass="form-control"></asp:TextBox>
    </div></div>
    <div class="row"><div class="col-md-2">
        IBAN No :</div><div class="col-md-4">
        <asp:TextBox ID="txtHesapNo" runat="server" CssClass="form-control" MaxLength="26"></asp:TextBox>
    </div></div>
    
    <div class="row">
    <div class="col-md-2"></div><div class="col-md-5">
        <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" CssClass="btn btn-default"
            onclick="btnGuncelle_Click"  />
   </div>
   </div>
    <div class="row">
    <div class="col-md-12">
        <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
        </div>
    </div>
   <div class="row margin-bottom-20 margin-top-20">
   <div class="col-md-2">
    Okuduğu Okula Göre Listele</div>
    <div class="col-md-4">
    <asp:DropDownList ID="ddlBirim" runat="server" AutoPostBack="True" CssClass="col-md-12 btn btn-default dropdown-toggle" 
        onselectedindexchanged="ddlBirim_SelectedIndexChanged" >
    </asp:DropDownList>
    </div>
    </div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" CssClass="table " 
        ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" 
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

    <p>
        &nbsp;</p>
</div>
</asp:Content>

