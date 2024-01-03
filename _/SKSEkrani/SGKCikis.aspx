<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="SGKCikis.aspx.cs" Inherits="SKSEkrani_IstenCikar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row container"> 
           <div class="col-md-4">Birim Seçin<br /><br /><br />
           <strong>
         * ÖNCE SGK ya bildirilen çıkış tarihini seçiniz.<br />
         * Seçmezseniz günün tarihi baz alınır.<br /></strong></div>        
           <div class="col-md-4">    
               <asp:DropDownList ID="ddlBirimler" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlBirimler_SelectedIndexChanged" AutoPostBack="True">
               </asp:DropDownList>
           </div>

           <div class="col-md-4">
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

       </div>
       <div class="row container col-md-offset-3">
         <br />
         
         <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    </div>
    <div class="row">
    <div class="col-md-12">
    <div class="portlet box yellow-crusta">
    <div class="portlet-title">
    <div class="caption">SGK Çıkışı Yapılacak Kişi</div>
    </div>
     <div class="portlet-body form">
    <div class="form-body" style="height:50px">
    <div class="form-group">
     <div class="col-md-offset-2 col-md-4" style="font-size:larger;color:#293955">
         <asp:Label ID="lblOgrNo" runat="server" Font-Bold="True" ></asp:Label>
&nbsp;<asp:Label ID="lblAdSoyad" runat="server" Font-Bold="True"></asp:Label>
    &nbsp;
         <asp:Label ID="lblSGKID" runat="server" Font-Bold="True"></asp:Label>
&nbsp;
         <asp:Label ID="lblOgrID" runat="server" Font-Bold="True"></asp:Label>
&nbsp;
         <asp:Label ID="lblCalYerID" runat="server" Font-Bold="True"></asp:Label>
    </div>
       <div class="col-md-3" style="font-size:larger;color:Red">
           <asp:Label ID="lblTarih" runat="server" Font-Bold="True"></asp:Label>
    </div>
    
       <div class="col-md-2" >
           <asp:Button ID="btnOlustur" runat="server"  Text="Gönder" CssClass="btn btn-default " OnClick="btnOlustur_Click"  />
    </div>
    </div>
    </div>
</div>
</div>
</div>
</div>

    <div class="container">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" CssClass="table" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" Caption="SGK çıkışı yapılcak çalışanı seçiniz." OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
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

