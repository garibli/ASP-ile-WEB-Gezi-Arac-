<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="SGKGiris.aspx.cs" Inherits="SKSEkrani_SGKGiris" %>

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
  
  <div class="container">
     <div class="row margin-bottom-25"> 
           <div class="col-md-3">Birim Seçin</div>        
           <div class="col-md-5">    
               <asp:DropDownList ID="ddlBirimler" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlBirimler_SelectedIndexChanged" AutoPostBack="True">
               </asp:DropDownList>
           </div>

       </div>
       <div class="row margin-right-10 margin-bottom-20 col-md-offset-3"><strong class="col-md-6">* ÖNCE SGK ya giriş tarihini seçiniz.<br />
         </strong>
         <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
     </div>
    <div class="row margin-bottom-20">
    <div class="col-md-3"></div>
    <div class="col-md-5">
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnSelectionChanged="Calendar1_SelectionChanged">
    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
    <NextPrevStyle VerticalAlign="Bottom" />
    <OtherMonthDayStyle ForeColor="#808080" />
    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
    <SelectorStyle BackColor="#CCCCCC" />
    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
    <WeekendDayStyle BackColor="#FFFFCC" />
    </asp:Calendar>
    </div>

    </div>
     
    <div class="row">
        <asp:GridView ID="GridView1" runat="server" CssClass="table" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" Caption="SGK girişi yapılcak çalışanı seçiniz." OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" CssClass="table "  />
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
</div>
</asp:Content>

