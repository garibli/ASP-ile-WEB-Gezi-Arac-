<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ilanEkle.ascx.cs" Inherits="userControl_ilanEkle" %>
<script src="../JScript/jquery-1.9.1.js"></script>

<script type="text/javascript">
   
    
</script>
<style>
     .conteMain{
         height:565px;
         width:650px;
         float:left;
     }
    .conteMin {
        height:34px;
        width:650px;
        margin-top:5px;
              
    }
    .conteMinAciklama {
        height:140px;
        width:465px;
        margin-top:1px;      
    }
     .Aciklama{
       
        height:20px;
        width:229px;
        float:left;
       
    }
     .textBox{
        height:20px;
        width:218px;
        float:left;
    }
  
    .uyari{
        height:20px;
        width:160px;
        float:left;
        
    }
    .gonderBtn{
        float:right;
        height:20px;
        width:80px;
    }
    .aciklama2{
        height:135px;
        width:218px;
        
        float:left;
        }
   
</style>

<div style="margin-top:60px">
         <p style="font-size:25px;color:#F46D09"><strong>İLAN GİRİŞİ</strong></p>
         <p style="font-size:25px;color:#ea0b3b">
       <asp:Label ID="LblHata" runat="server"></asp:Label>
</p>
</div>

<div class="conte">
    <div class="conteMin">
        <div class="Aciklama">Çalışma Şekli</div>
        <div class="textBox">
        <div class="dropdown">
            <asp:DropDownList ID="ddlCalismaSekli" runat="server" Width="210px" CssClass="btn btn-default dropdown-toggle" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList></div>
        </div>
        </div>
     <div class="conteMin">
        <div class="Aciklama">İş Tanımı (Kısaca)</div>
        <div class="textBox">
        <div class="dropdown">
        <asp:TextBox ID="txtBaslik" runat="server" MaxLength="50" CssClass="btn btn-default dropdown-toggle"
                Width="210px"></asp:TextBox></div></div>
     </div>
     <div class="conteMinAciklama">
        <div class="Aciklama">İşin Niteliği</div>
        <div class="aciklama2"><asp:TextBox ID="txtAciklama" runat="server" Height="135px"  CssClass="btn btn-default"
                Width="208px" TextMode="MultiLine"></asp:TextBox></div>
   
     </div>
    <div class="conteMin">
        <div class="Aciklama">Çalıştırılacak Birim</div>
        <div class="textBox">
        <div class ="dropdown">
            <asp:DropDownList ID="ddlIlgiliBirim" runat="server"  Width="210px" AutoPostBack="True" OnSelectedIndexChanged="ddlIlgiliBirim_SelectedIndexChanged" CssClass="btn btn-default dropdown-toggle">
            </asp:DropDownList>
        </div>
       </div>
     </div>
    <div class="conteMin">
        <div class="Aciklama">Çalıştırılacak Bölüm</div>
        <div class="textBox">
         <div class ="dropdown">
            <asp:DropDownList ID="ddlIlgiliBolum" runat="server"  Width="210px"  CssClass="btn btn-default dropdown-toggle" >
            </asp:DropDownList>
        </div>
       </div>
     </div>


     <div class="conteMin">
        <div class="Aciklama">Kontenjan</div>
        <div class="textBox">
            <asp:TextBox ID="txtKontenjan" runat="server" MaxLength="50" CssClass="btn btn-default"
                 Width="210px"></asp:TextBox></div>
        
     </div>
      <div class="conteMin">
        <div class="Aciklama">Program Adı</div>
        
        <div class="uyari" style="width:10px;">
        <div class="dropdown">
            <asp:DropDownList ID="ddlProgramAdi" runat="server" Width="209px" CssClass="btn btn-default">
            <asp:ListItem Value="0">Seciniz</asp:ListItem>
            <asp:ListItem Value="1">Doktora</asp:ListItem>
            <asp:ListItem Value="2">YuksekLisans</asp:ListItem>
            <asp:ListItem Value="3">Lisans</asp:ListItem>
            <asp:ListItem Value="4">ÖnLisans</asp:ListItem>
            <asp:ListItem Value="5">FarkEtmez</asp:ListItem>

            </asp:DropDownList>
         </div>
         </div>
     </div>
      <div class="conteMin">
          <div class="Aciklama">Ogleden Once Calışılacak Günler</div>
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
     <div class="conteMin">
          <div class="Aciklama">Ogleden Sonra Calışılacak Günler</div>
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

      
     <div class="conteMin">
        <div class="Aciklama">İlan Bitiş Süresi</div>
        <div class="textBox"><div class="tkvm" >
            <asp:TextBox ID="txtTarih" runat="server"  Width="210px"  CssClass="btn btn-default" Enabled="false"></asp:TextBox>
         </div></div>
        
     </div>
     <div class="conteMin">
        <div class="Aciklama"></div>
        <div class="textBox">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
            
            <asp:Button ID="btnGonder" runat="server" Height="30px" Text="Ekle" Width="80px" BorderColor="#000066" BorderStyle="Solid" ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" CssClass="btn btn-primary" OnClick="btnGonder_Click" />
            
            </div> 
       
         
     </div>
     <div class="tkvm" style="width:463px;height:180px; align-content:center;"> 
          <div class="TarihNesnesi" style="margin-left:35%;">
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
 
