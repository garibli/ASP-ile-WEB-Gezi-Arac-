
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PersOgrYoklama.ascx.cs" Inherits="userControl_OgrYoklama" %>

   <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet">
  <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Global styles END --> 
   
  <!-- Page level plugin styles START -->
  <link href="../assets/global/plugins/fancybox/source/jquery.fancybox.css" rel="stylesheet">
  <!-- Page level plugin styles END -->

  <!-- Theme styles START -->
  <link href="../assets/global/css/components.css" rel="stylesheet">
  <link href="../assets/global/css/plugins.css" rel="stylesheet">
  <link href="../assets/frontend/layout/css/style.css" rel="stylesheet">
  <link href="../assets/frontend/layout/css/style-responsive.css" rel="stylesheet">
  <link href="../assets/frontend/layout/css/themes/red.css" rel="stylesheet">
  <link href="../assets/frontend/layout/css/custom.css" rel="stylesheet">
<script src="../JScript/jquery-1.9.1.js"></script>
<script type="text/javascript">

    $(document).ready(function () {
        $("#Hidden1").hide();
        $("#Hidden2").hide();

        $("#Detay").click(function () {
            $(".altKutu").slideToggle(200);
            return false;
        });

        var topluGoster = $("#topluPuantaj").val();
        var kisiSecerek = $("#kisiSecerekPuantaj").val();
        
            if (topluGoster == 0) {
                $("#toplupuantajHide").hide();
            }
            if (topluGoster == 1) {
                $("#toplupuantajHide").show();
            }
       
            if (kisiSecerek == 0) {
                $("#kisiSecerekPuantajHide").hide();
            }
            if (kisiSecerek == 1) {
                $("#kisiSecerekPuantajHide").show();
            }
    });
  

</script>

<div class="col-md-12" >
    <div class="col-md-offset-0 col-md-4" id="topluSecerek">
    <asp:Button ID="btnTopluPuantaj" runat="server" 
    CssClass="btn blue" Text=" 1-TOPLU PUANTAJ OLUŞTURMA" 
    onclick="btnTopluPuantaj_Click" />
    </div>
    <div class="col-md-offset-1 col-md-4" id="KisiSecerek">
    <asp:Button ID="btnKisiSecerek" runat="server" class="btn btn-info col-md-12 "  
                    Text="2-KİSİ SEÇEREK PUANTAJ OLUŞTURMA" onclick="btnKisiSecerek_Click" />
     </div>
</div>
 
   
<div id="toplupuantajHide" >
<hr  class="col-md-12"/>
    <div class="container">
          <div class="col-md-12" style="color:Gray;font-size:large;">TOPLU PUANTAJ</div>
    </div>
<hr  class="col-md-12"/>
        <div class="container  col-md-12 margin-top-10" style="margin-top:10px;font-size:medium;margin-bottom:10px">
            
            <div class="row col-md-12" style="margin-top:2px">
                 <div class="col-md-3">
                     <strong>İLGİLİ BİRİM</strong>
                     </div>
                 <div class="col-md-5">
                    <asp:DropDownList ID="ddlIlgiliBirim" runat="server" Height="30px" 
                         AutoPostBack="True" CssClass="btn btn-default dropdown-toggle col-md-12"
                        onselectedindexchanged="ddlIlgiliBirim_SelectedIndexChanged">
                    </asp:DropDownList>
                    </div>
                      <div class="col-md-4"></div>
                </div>
      
    
            <div class="row col-md-12" style="margin-top:2px">
            <div class=" col-md-3">
                <strong>İLGİLİ BÖLÜM</strong> 
                </div>
       
                <div class="col-md-5">
                    <asp:DropDownList ID="ddlIlgiliBolum" runat="server" Height="30px"  AutoPostBack="True"
                     CssClass="btn btn-default dropdown-toggle col-md-12" OnSelectedIndexChanged="ddlIlgiliBolum_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                 <strong>  </strong>
                 </div>
             </div>

             <div class="row col-md-12" style="margin-top:2px">
                <div class=" col-md-3"><strong> PUANTAJ GİRİLECEK AY</strong></div>
                <div class="col-md-5">
                    <asp:DropDownList ID="ddlHizliPAy" runat="server" Height="30px" 
                        AutoPostBack="False" 
                        OnSelectedIndexChanged="ddlIlgiliBolum_SelectedIndexChanged" CssClass="btn btn-default dropdown-toggle col-md-12"
                        Enabled="False">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                 </div>
             </div>
             </div>
    
    
     <div class="container" style="margin-top:15px;font-size:medium">
        <div class="row col-md-12" style="margin-top:15px">
             <div class="col-md-6" style="color:blue">
             <strong style="font-size:smaller">Biriminizde  kısmi zamanlı çalışan  öğrencilerin çoğu veya tamamı ay içerinde haftalık 15 saati tam olarak çalışmış ise  yandaki butonu tıklayınız</strong></div>
                    <div id="col-md-6">
                         <asp:Button ID="btnTumuTopluGir" runat="server"  Text="Toplu Gir"   
                         CssClass="btn btn-primary col-md-2" Font-Bold="True" OnClick="btnTumuTopluGir_Click"  />
                   </div>
              </div>
         </div>
      
        <div class="container" style="font-size:medium">
             <div class="row col-md-12">
                 <asp:Label ID="lblTumCalisan" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
              </div>
        </div>
        
    
    


    <asp:Label ID="lblAciklama" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
       
   <%-- <div style="margin-top:5px;border:1px groove;width:430px;height:55px;"></div>--%>
   
    
  </div>
                
       

    
   
  
  <div id="kisiSecerekPuantajHide">
  <hr  class="col-md-12"/>
    <div class="container">
          <div class="col-md-12" style="color:Gray;font-size:large;">KİŞİ SEÇEREK PUANTAJ</div>
    </div>
<hr  class="col-md-12"/>
     <div class="container">
        <div class="row margin-bottom-10">
            <div class="col-md-12" style="font-size:13px;color:Red">
               * Aşağıda Öğrenciyi seçerek ay içindeki çalışma saatlerini <u><strong>toplu olarak girebilir</strong></u> ,<u><strong>toplu olarak silebilirsiniz</strong></u> veya<u><strong> gün gün aşağıdaki kutulardan manuel olarak</strong></u> saatleri belirleyebilirsiniz.
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-3" style="font-size:medium">
                     <strong>Çalışan Öğrenciyi Seç</strong>
                </div>
            
        
        <div  class="col-md-4" runat="server">
            <asp:DropDownList ID="ddlCalisanlar" runat="server" CssClass="btn btn-default dropdown-toggle col-md-12 left" 
               AutoPostBack="true"  onselectedindexchanged="ddlCalisanlar_SelectedIndexChanged" >
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
             <div class="col-md-4">
                 <asp:Button ID="btnKisiTopluGir" runat="server"  Text="Toplu Puantaj Gir"    CssClass="btn btn-primary"   Font-Bold="True" OnClick="btnKisiTopluGir_Click" />
            </div>
            <div  class="col-md-2">
            </div>
             <div class="col-md-4" >
                     <asp:Button ID="btnSil" runat="server"  Text="Toplu Puantaj Sil"  CssClass=" btn btn-warning"
                      Font-Bold="True" OnClick="btnSil_Click" />
            </div>
        </div>
         <div class="col-md-1" >
                 <asp:Label ID="lblCalisan" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
       </div>
         <div class="col-md-1">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </div>
        </div>
     </div>  
     </div>
    
       
    
       
  
   <div class="container">
          <div class="row">
             <div class="col-md-6 col-md-offset-1" style="visibility:hidden;width:5px;height:5px">
     
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#999999" 
             CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
             ForeColor="Black" Height="180px" Width="200px" 
             OnSelectionChanged="Calendar1_SelectionChanged" EnableTheming="True" 
             ShowNextPrevMonth="False">
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

    <div id="Hidden1" class="container" style="margin-top:30px;margin-bottom:30px;visibility:hidden;height:2px" >
        <div class="row">
        <strong style="color: #000066">Gün Gün 
        Puantaj Girin/Düzenleyin</strong>
        </div>
        <div class="row">
          <strong>Günlük Çalışılan Saat:</strong>
          </div>
            <div class="row">
            <div class="col-md-1">
        <asp:DropDownList ID="ddlCalisanSaat" runat="server"  CssClass="btn btn-default dropdown-toggle col-md-12">
            <asp:ListItem>0</asp:ListItem>
            <asp:ListItem>0,5</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>1,5</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>2,5</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>3,5</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>4,5</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>5,5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>6,5</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>7,5</asp:ListItem>
        </asp:DropDownList>
        </div>
        <div class="col-md-2">
        <asp:Button ID="btnGir" runat="server"  Text="Gir" CssClass="btn btn-success col-md-4" Font-Bold="True" OnClick="btnGir_Click" />
        </div>
        </div>
    </div>
    <!-- gizlenen bölüm------------------------------------------------------------------ -->
    <div id="Hidden2" style="margin-top:5px;width:785px; height:2px; border-top:1px groove #000066;visibility:hidden">
 <div class="conteDataView"  style="width:300px;margin-top:5px;" >
       <asp:GridView ID="GridViewCalisanlar" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridViewCalisanlar_SelectedIndexChanged" BorderStyle="Dashed" BorderWidth="1px">
           <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Wrap="True" />
           <Columns>
               <asp:ButtonField ButtonType="Button" CommandName="Select" ShowHeader="True" Text="Seçin" />
           </Columns>
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
    <div style="margin-left:5px;margin-top:0px; float:left; width:480px;height:auto;visibility:hidden">
          <div style="float:left;height:auto; width:260px;margin-bottom:5px;margin-top:-26px;border-left:1px groove #000066;visibility:hidden">
            <asp:DropDownList ID="ddlAy" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAy_SelectedIndexChanged" Visible="False">
                <asp:ListItem Selected="True" Value="0">Ay Seçiniz</asp:ListItem>
                <asp:ListItem Value="1">Ocak</asp:ListItem>
                <asp:ListItem Value="2">Şubat</asp:ListItem>
                <asp:ListItem Value="3">Mart</asp:ListItem>
                <asp:ListItem Value="4">Nisan</asp:ListItem>
                <asp:ListItem Value="5">Mayıs</asp:ListItem>
                <asp:ListItem Value="6">Haziran</asp:ListItem>
                <asp:ListItem Value="7">Temmuz</asp:ListItem>
                <asp:ListItem Value="8">Ağustos</asp:ListItem>
                <asp:ListItem Value="9">Eylül</asp:ListItem>
                <asp:ListItem Value="10">Ekim</asp:ListItem>
                <asp:ListItem Value="11">Kasım</asp:ListItem>
                <asp:ListItem Value="12">Aralık</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlYılSec" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYılSec_SelectedIndexChanged" Visible="False">
                <asp:ListItem Selected="True" Value="0">Yıl Seçiniz</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div style="margin-top:4px; width:300px;height:auto;float:left;visibility:hidden">
        <asp:GridView ID="GridViewTarih" runat="server" BackColor="White" 
                BorderColor="#CCCCCC" BorderStyle="Groove" BorderWidth="1px" CellPadding="4" 
                ForeColor="Black" GridLines="Horizontal" CellSpacing="2" 
                HorizontalAlign="Justify" Visible="false" 
                onselectedindexchanged="GridViewTarih_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#999999" ForeColor="White" />
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
             
            </div>
       
    </div>
        </div>

  
  <!-- gizlenen bölge sonu --------------------------------------------->

<%-------------------------------DETAY PUANTAJ--------------------------%>


<div class="container" >
<div class="row col-md-12 col-md-offset-4">
    İlgili Tarih :
    <asp:Label ID="lblDetayTarih" runat="server" Font-Bold="True" 
        ForeColor="#000066"></asp:Label>
</div>
    <asp:Label ID="lblDetayHata" runat="server" Font-Bold="True" CssClass="col-md-12"
        ForeColor="#CC0000"></asp:Label>


    
    <asp:Label ID="lblDetayHata0" runat="server" Font-Bold="True" CssClass="col-md-12"
        ForeColor="#CC0000"></asp:Label>


   
    <asp:Label ID="lblDetayHata1" runat="server" Font-Bold="True" CssClass="col-md-12"
        ForeColor="#CC0000"></asp:Label>


   
    <asp:Label ID="lblDetayBilgi" runat="server" Font-Bold="True" CssClass="col-md-12"
        ForeColor="#CC0000"></asp:Label>
     </div>
  
    <div class="container" style="margin-top:15px">
        <div class="row col-md-12" style="font-size:15px">
             <strong>Yalnızca tam sayı değerleri giriniz. Gönder dedikten sonra 
                tekrardan aşağıdan kontrölünü yapınız.</strong></div>
        </div>
   

<div class="container">

<div class="row col-md-12">
<div class="col-md-1">1</div>
<div class="col-md-1">2</div>
<div class="col-md-1">3</div>
<div class="col-md-1">4</div>
<div class="col-md-1">5</div>
<div class="col-md-1">6</div>
<div class="col-md-1">7</div>
<div class="col-md-1">8</div>
<div class="col-md-1">9</div>
<div class="col-md-1">10</div>
 </div>
<div class="row col-md-12">
<div class="col-md-1"><asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" CssClass="col-md-10" ontextchanged="TextBox1_TextChanged" ></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox2" runat="server" AutoPostBack="true" CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox3" runat="server" AutoPostBack="true" CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox4" runat="server" 
        CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged" ></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox5" runat="server" AutoPostBack="true" CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox6" runat="server" AutoPostBack="true" CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox7" runat="server" AutoPostBack="true" CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox8" runat="server" AutoPostBack="true" CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox9" runat="server" AutoPostBack="true" CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox10" runat="server" AutoPostBack="true" CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
</div>

<div class="row col-md-12 margin-top-20">
<div class="col-md-1">11</div>
<div class="col-md-1">12</div>
<div class="col-md-1">13</div>
<div class="col-md-1">14</div>
<div class="col-md-1">15</div>
<div class="col-md-1">16</div>
<div class="col-md-1">17</div>
<div class="col-md-1">18</div>
<div class="col-md-1">19</div>
<div class="col-md-1">20</div>
</div>
<div class="row col-md-12">
<div class="col-md-1"><asp:TextBox ID="TextBox11" runat="server" AutoPostBack="true"  CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox12" runat="server" AutoPostBack="true"  CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox13" runat="server" AutoPostBack="true"  CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox14" runat="server" AutoPostBack="true"  CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox15" runat="server" AutoPostBack="true"  CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox16" runat="server" AutoPostBack="true"  CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox17" runat="server" AutoPostBack="true"  CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox18" runat="server" AutoPostBack="true"  CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox19" runat="server" AutoPostBack="true"  CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox20" runat="server" AutoPostBack="true"  CssClass="col-md-10"  ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
</div>

<div class="row col-md-12 margin-top-20">
<div class="col-md-1">21</div>
<div class="col-md-1">22</div>
<div class="col-md-1">23</div>
<div class="col-md-1">24</div>
<div class="col-md-1">25</div>
<div class="col-md-1">26</div>
<div class="col-md-1">27</div>
<div class="col-md-1">28</div>
<div class="col-md-1">29</div>
<div class="col-md-1">30</div>
<div class="col-md-1">31</div>
</div>
<div class="row col-md-12">
<div class="col-md-1"><asp:TextBox ID="TextBox21" runat="server" AutoPostBack="true"  CssClass="col-md-10" ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox22" runat="server" AutoPostBack="true"  CssClass="col-md-10" ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox23" runat="server" AutoPostBack="true"  CssClass="col-md-10" ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox24" runat="server" AutoPostBack="true"  CssClass="col-md-10" ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox25" runat="server" AutoPostBack="true"  CssClass="col-md-10" ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox26" runat="server" AutoPostBack="true"  CssClass="col-md-10" ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox27" runat="server" AutoPostBack="true"  CssClass="col-md-10" ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox28" runat="server" AutoPostBack="true"  CssClass="col-md-10" ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox29" runat="server" AutoPostBack="true"  CssClass="col-md-10" ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox30" runat="server" AutoPostBack="true"  CssClass="col-md-10" ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
<div class="col-md-1"><asp:TextBox ID="TextBox31" runat="server" AutoPostBack="true"  CssClass="col-md-10" ontextchanged="TextBox1_TextChanged"></asp:TextBox></div>
</div>
    
    <div class="row col-md-12 col-md-offset-0" style="margin-top:10px;margin-bottom:25px">
      <div class="btn btn-default col-md-2 ">Toplam Puantaj:
        <asp:Label ID="lblToplamPuantajYaz" runat="server" Text=""></asp:Label>
    </div>
    <div class="col-md-2">
        <asp:Button ID="Button1" runat="server" Text="KAYDET" CssClass="btn btn-success col-md-12"
            onclick="Button1_Click" />
       </div>     
    <div class="col-md-8 margin-top-10" style="font-size:larger"><strong>"Toplam Puantaj"</strong> Bilgi Amaçlıdır. Kaydetmek için Kaydet Butonuna Basınız.
    </div>
          
    </div>
    
</div>
</div>
<div style="visibility:hidden"><input id="topluPuantaj" type="button" value="<%:Session["kontroltoplu"]%>" />
</div>
<div  style="visibility:hidden"><input id="kisiSecerekPuantaj" type="button" value="<%:Session["kontrolkisiSecerek"]%>" />
</div>
<%-------------------------------DETAY PUANTAJ Sonu--------------------------%>


