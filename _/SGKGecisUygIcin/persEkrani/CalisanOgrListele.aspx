<%@ Page Title="" Language="C#" MasterPageFile="~/persEkrani/PersMaster.master" AutoEventWireup="true" CodeFile="CalisanOgrListele.aspx.cs" Inherits="persEkrani_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../assets/bootstrap-3.3.2-dist/css/bootstrap.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <div style="margin-left:-95px">
    <asp:GridView ID="GridView1" CssClass="table table-hover"  
        runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" 
        BorderStyle="None" BorderWidth="1px">
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    
    </div>

</asp:Content>

