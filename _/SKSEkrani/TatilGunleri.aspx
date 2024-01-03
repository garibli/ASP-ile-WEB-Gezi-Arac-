<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="TatilGunleri.aspx.cs" Inherits="SKSEkrani_TatilGunleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .conte {
        width:800px;
        height:auto;
        float:left;
    }
    </style>
     <link href="../CSS/Alan1.css" rel="stylesheet" />




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container margin-top-20 col-md-4">
<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" 
             CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
             ForeColor="Black" Height="180px" Width="200px">
    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
    <NextPrevStyle VerticalAlign="Bottom" />
    <OtherMonthDayStyle ForeColor="#808080" />
    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
    <SelectorStyle BackColor="#CCCCCC" />
    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
    <WeekendDayStyle BackColor="#FFFFCC" />
</asp:Calendar>


         <div class="row container col-md-12 margin-top-20">
        <asp:Button ID="btnGir" runat="server" CssClass="btn btn-default col-md-4" Text="Girin"
             Font-Bold="True" OnClick="btnGir_Click"  />
             </div>

    </div>

    <div class="container col-md-6" >
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" CssClass="table"
            GridLines="None" AutoGenerateSelectButton="True" 
            Caption="Silinecek Günü Seçerek Silebilirsiniz." 
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
            BorderStyle="Solid" BorderWidth="2px">
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

