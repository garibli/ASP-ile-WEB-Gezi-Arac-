<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="SGKCikisNull.aspx.cs" Inherits="SKSEkrani_SGKCikisNull" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../CSS/Alan1.css" rel="stylesheet" />
<style type="text/css">
    .auto-style2 {
        width: 800px;
        height: auto;
        float: left;
        color: #000066;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="conttainer col-md-12"> 
           <div class="col-md-3">Birim Seçin</div>        
           <div class="col-md-3">    
               <asp:DropDownList ID="ddlBirimler" runat="server" CssClass="dropdown dropdown btn btn-default col-md-12" OnSelectedIndexChanged="ddlBirimler_SelectedIndexChanged" AutoPostBack="True">
               </asp:DropDownList>
           </div>

           <br />
           <br />
           <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#000066"></asp:Label>

       </div>

       <div class="container " style="height:auto;margin-top:45px">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateSelectButton="True" 
            Caption="SGK çıkışı silinecek çalışanı seçiniz."  CssClass="table"
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

