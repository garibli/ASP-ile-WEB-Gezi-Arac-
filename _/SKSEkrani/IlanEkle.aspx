<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="IlanEkle.aspx.cs" Inherits="SKSEkrani_IlanEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container">
<div class="row">
     
       <asp:Label ID="LblHata" runat="server"></asp:Label>

</div>

<div class="col-md-12">
    <div class="row margin-bottom-5">
        <div class="col-md-3">Çalışma Şekli</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlCalismaSekli" runat="server" CssClass="col-md-12 btn btn-default dropdown-toogle" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        </div>
     <div class="row margin-bottom-5">
        <div class="col-md-3">İş Tanımı (Kısaca)</div>
        <div class="col-md-5"><asp:TextBox ID="txtBaslik" runat="server" MaxLength="50"  CssClass="form-control"
                 ></asp:TextBox></div>
     </div>
     <div class="row margin-bottom-5">
        <div class="col-md-3">İşin Niteliği</div>
        <div class="col-md-5"><asp:TextBox ID="txtAciklama" runat="server"  CssClass="form-control"
                 TextMode="MultiLine"></asp:TextBox></div>
   
     </div>
    <div class="row margin-bottom-5">
        <div class="col-md-3">Çalıştırılacak Birim</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlIlgiliBirim" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12" AutoPostBack="True" OnSelectedIndexChanged="ddlIlgiliBirim_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
       
     </div>
    <div class="row margin-bottom-5">
        <div class="col-md-3">Çalıştırılacak Bölüm</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlIlgiliBolum" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12">
            </asp:DropDownList>
        </div>
       
     </div>


     <div class="row margin-bottom-5">
        <div class="col-md-3">Kontenjan</div>
        <div class="col-md-5">
            <asp:TextBox ID="txtKontenjan" runat="server" MaxLength="50" 
                CssClass="form-control"></asp:TextBox></div>
        
     </div>
      <div class="row margin-bottom-5">
        <div class="col-md-3">Program Adı</div>
        
        <div class="col-md-5" >
            <asp:DropDownList ID="ddlProgramAdi" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12">
            <asp:ListItem Value="0">Seciniz</asp:ListItem>
            <asp:ListItem Value="1">Doktora</asp:ListItem>
            <asp:ListItem Value="2">YuksekLisans</asp:ListItem>
            <asp:ListItem Value="3">Lisans</asp:ListItem>
            <asp:ListItem Value="4">ÖnLisans</asp:ListItem>
            <asp:ListItem Value="5">FarkEtmez</asp:ListItem>

            </asp:DropDownList>
         </div>
     </div>
      <div class="row margin-bottom-5">
          <div class="col-md-3">Ogleden Once Calışılacak Günler</div>
          <asp:CheckBox ID="chkBoxPazartesiOO" runat="server" Text="Pazartesi" />
          &nbsp;&nbsp;
          <asp:CheckBox ID="chkBoxSaliOO" runat="server" Text="Salı" />
          &nbsp;&nbsp;
          <asp:CheckBox ID="chkBoxCarsambaOO" runat="server" Text="Çarşamba" />
          &nbsp;&nbsp;
          <asp:CheckBox ID="chkBoxPersembeOO" runat="server" Text="Perşembe" />
          &nbsp;&nbsp;
          <asp:CheckBox ID="chkBoxCumaOO" runat="server" Text="Cuma" />

     </div>
     <div class="row margin-bottom-5">
          <div class="col-md-3">Ogleden Sonra Calışılacak Günler</div>
          <asp:CheckBox ID="chkBoxPazartesiOS" runat="server" Text="Pazartesi" />
          &nbsp;&nbsp;
          <asp:CheckBox ID="chkBoxSaliOS" runat="server" Text="Salı" />
          &nbsp;&nbsp;
          <asp:CheckBox ID="chkBoxCarsambaOS" runat="server" Text="Çarşamba" />
          &nbsp;&nbsp;
          <asp:CheckBox ID="chkBoxPersembeOS" runat="server" Text="Perşembe" />
          &nbsp;&nbsp;
          <asp:CheckBox ID="chkBoxCumaOS" runat="server" Text="Cuma" />

     </div>

      
     <div class="row margin-bottom-5">
        <div class="col-md-3">İlan Bitiş Süresi</div>
        <div class="col-md-5">
            <asp:TextBox ID="txtTarih" runat="server" CssClass="form-control"></asp:TextBox>
         </div>
        
     </div>
     <div class="row margin-bottom-5">
        <div class="col-md-3"></div>
        <div class="col-md-5">
            
            <asp:Button ID="btnGonder" runat="server" Text="Ekle" CssClass="col-md-5 btn btn-default" OnClick="btnGonder_Click" />
            
            </div> 
       
         
     </div>
     <div class="row"> <div class="col-md-3"></div>
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
 </div>
 

   </div>

</asp:Content>

