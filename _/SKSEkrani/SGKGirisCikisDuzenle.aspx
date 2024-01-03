<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="SGKGirisCikisDuzenle.aspx.cs" Inherits="SKSEkrani_SGKGirisCikisDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/alanlar2.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="conteMin">

<div class="textBox" style="width:160px">
    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
        BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
        Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="100px" 
        style="margin-right: 0px" Width="159px" 
        onselectionchanged="Calendar1_SelectionChanged">
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


<div class="textBox" style="margin-top:50px">SGK Giriş Tarihi</div>
<div class="textBox" style="margin-top:50px"></div>
<div class="textBox" style="margin-top:0px">


    <asp:TextBox ID="txtSGKGiris" runat="server" Width="255px"></asp:TextBox>


</div>

</div>


</asp:Content>

