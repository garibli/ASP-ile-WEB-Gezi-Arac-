<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="SGKCikisGuncelle.aspx.cs" Inherits="SKSEkrani_SGKCikisGuncelle" %>

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
<div class="conteMin"> 
           <div class="Aciklama">Birim Seçin</div>        
           <div class="textBox">    
               <asp:DropDownList ID="ddlBirimler" runat="server" Height="20px" Width="239px" OnSelectedIndexChanged="ddlBirimler_SelectedIndexChanged" AutoPostBack="True">
               </asp:DropDownList>
           </div>

       </div>
    <div class="conte" style="margin-top:15px;width:250px">
<asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" 
            CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
            ForeColor="Black" Height="180px" Width="200px" 
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
     <div class="auto-style2" style="margin-top:15px;width:450px"><strong>* ÖNCE SGK ya giriş tarihini seçiniz.<br />
         </strong>
         <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
     </div>

     <div class="conteMin" style="width:450px">
         <asp:Label ID="lblOgrNo" runat="server" Font-Bold="True"></asp:Label>
&nbsp;<asp:Label ID="lblAdSoyad" runat="server" Font-Bold="True"></asp:Label>
    &nbsp;
         <asp:Label ID="lblSGKID" runat="server" Font-Bold="True"></asp:Label>
&nbsp;
         <asp:Label ID="lblOgrID" runat="server" Font-Bold="True"></asp:Label>
&nbsp;
         <asp:Label ID="lblCalYerID" runat="server" Font-Bold="True"></asp:Label>
    </div>
       <div class="conteMin" style="width:400px">
           <asp:Label ID="lblTarih" runat="server" Font-Bold="True"></asp:Label>
    </div>
       <div class="conteMin" style="width:400px">
           <asp:Button ID="btnOlustur" runat="server" Height="20px" Text="Gönder" Width="117px" 
               BackColor="White" BorderColor="#000066" BorderStyle="Solid" ForeColor="#1E002F" 
               BorderWidth="1px" Font-Bold="True" OnClick="btnOlustur_Click"  />
    </div>



    <div class="conteMin" style="height:auto;margin-top:15px">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None" AutoGenerateSelectButton="True" 
            Caption="SGK çıkışı güncellenecek çalışanı seçiniz." 
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

