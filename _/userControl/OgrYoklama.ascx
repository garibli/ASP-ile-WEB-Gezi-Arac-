<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ogrYoklama.ascx.cs" Inherits="userControl_OgrYoklama" %>
<script src="../JScript/jquery-1.9.1.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        // $(".altKutu").hide();
        $("#Detay").click(function () {

            $(".altKutu").slideToggle(200);
            return false;
        });


    });
</script>
<style>
    .conte {
        width:800px;
        height:170px;
        margin-top:70px;
        
    }
    .conteMin {
        height:20px;
        width:772px;
        margin-top:5px;      
    }
    .conteDataView{
        height:auto;
        width:380px;
        margin-top:10px;  
        float:left;
    }
     .Aciklama{
       
        height:21px;
        width:150px;
        float:left;
       
    }
     .textBox{
        height:20px;
        width:266px;
        float:left;
    }
     
    .uyari {
        height: 20px;
        width: 160px;
        float: left;
    }
     .calander{
         width:200px;
         height:180px;
         float:left;
         margin-top:5px;
     }
     
    .auto-style1 {
        color: #000066;
    }
     
    .style2
    {
        color: #000066;
        text-align: center;
    }
     
</style>
<div class="conte">
    <div class="conteMin">
        <div class="Aciklama">İlgili Birim</div>
        <div class="textBox">
            <asp:DropDownList ID="ddlIlgiliBirim" runat="server" Height="20px" 
                Width="250px" AutoPostBack="True" 
                onselectedindexchanged="ddlIlgiliBirim_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="uyari">
            
         </div>
     </div>
    <div class="conteMin">
        <div class="Aciklama">İlgili Bölüm</div>
        <div class="textBox">
            <asp:DropDownList ID="ddlIlgiliBolum" runat="server" Height="20px" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddlIlgiliBolum_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="uyari">
            
            *Varsa alt birim seçiniz</div>
     </div>
     <div class="conteMin">
         Toplu Puantaj Girilecek Ayı Aşağıdaki Takvimden İşaretleyiniz! İşaretlenmezse 
         mevcut ay baz alınacaktır.</div>  
     <div class="conteMin" style="margin-bottom:10px;margin-top:10px">
        
         <div class="Aciklama" style="width:458px; margin-right:5px;margin-left:5px; color:blue"><strong>Puantajın toplu olarak hazırlanması için yandaki butona tıklayınız**</strong></div>
         <div class="textBox" style="width:70px;margin-right:5px; height:25px;">
            <div id="deneme">
        <asp:Button ID="btnTumuTopluGir" runat="server" Height="20px" Text="Gir" Width="70px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" OnClick="btnTumuTopluGir_Click"  />
         </div></div>

        <div class="Aciklama" style="margin-left:25px;width:200px;">
        <asp:Label ID="lblTumCalisan" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
         </div>
          </div>
          <div class="conteMin">
    <div class="textBox" style="width:770px">*Tüm iş günleri otomatik 3 saat olarak girilcektir.
     İstenirse daha sonra elle düzeltmeler aşağıdaki takvimden yapılabilir.</div>
     </div>
    
    <div class="conteMin" style="margin-bottom:75px;">
        <div class="textBox" style="width:770px">**Bölüm seçiliyse bölümde çalışan personel, bölüm seçili değil ise birimde
            çalışan personeller için geçerli olucaktır.
        </div>
       
    </div>
    
</div>

   
       
   <%-- <div style="margin-top:5px;border:1px groove;width:430px;height:55px;"></div>--%>
   
    
  <div class="textBox" style="margin-bottom:15px;margin-left:5px; float:none ; width:450px">
        <asp:Label ID="lblAciklama" runat="server" Font-Bold="True" ForeColor="Red" ></asp:Label>
    </div><hr />
    <h3 class="style2">DETAYLI PUANTAJ</h3>
    <hr />
    <div class="altKutu" style="margin-top:25px">
    <div class="conteMin" style="height:auto">
        
         <div class="conteMin">
             <div class="Aciklama" style="width:360px;margin-right:5px;margin-left:5px;">
                 <span class="auto-style1"><strong>Seçili çalışanın seçili ayını otamatik doldurun</strong></span>*</div>
        <div class="textBox" style="width:65px;margin-right:5px;">
        <asp:Button ID="btnKisiTopluGir" runat="server" Height="20px" Text="Gir" Width="70px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" OnClick="btnKisiTopluGir_Click" />
         </div>
        <div class="Aciklama" style="margin-left:25px;width:200px;">
        <asp:Label ID="lblCalisan" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
          </div>

    </div>

     <div class="conteMin" style="margin-bottom:15px">
        <div class="Aciklama"><strong>&nbsp;Çalışan Seç</strong></div>
        <div class="textBox">
            <asp:DropDownList ID="ddlCalisanlar" runat="server" Height="20px" Width="250px" 
                AutoPostBack="True" onselectedindexchanged="ddlCalisanlar_SelectedIndexChanged">
            </asp:DropDownList>
        </div>

     </div>  

     <div class="conteMin">
             <div class="Aciklama" style="width:360px;margin-right:5px;margin-left:5px;">
                 <span class="auto-style1"><strong>Seçili çalışanın seçili ayını sil</strong></span></div>
        <div class="textBox" style="width:65px;margin-right:5px;">
        <asp:Button ID="btnSil" runat="server" Height="20px" Text="Yoklama Sil" 
                Width="105px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
                ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" OnClick="btnSil_Click" />
         </div>
        <div class="Aciklama" style="margin-left:25px;width:200px;">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
          </div>

    </div>
       
  
   <div style="height:185px;width:772px">
     <div class="calander">
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
    <div class="textBox" style="margin-top:30px;margin-left:5px;" >
        <strong style="color: #000066">Gün Gün 
        Puantaj Girin/Düzenleyin</strong></div>
    <div class="textBox" style="margin-top:30px;margin-left:5px;" ></div>
    <div class="textBox" style="margin-top:5px;margin-left:5px;" ><strong>Günlük Çalışılan Saat:</strong></div>
    <div class="textBox" style="margin-top:5px;margin-left:5px;"></div>
    <div class="textBox" style="margin-top:5px;margin-left:5px;">
        <asp:DropDownList ID="ddlCalisanSaat" runat="server" Height="20px" Width="50px">
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
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnGir" runat="server" Height="20px" Text="Gir" Width="50px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" OnClick="btnGir_Click" />
    </div>
    <div class="textBox" style="margin-top:5px;margin-left:5px;"></div>
  
</div>
    <div style="width:780px;margin-top:5px;height:20px;border-top:1px groove #000066;vertical-align:central;">Liste</div>
    <div style="margin-top:5px;width:785px; height:217px; border-top:1px groove #000066;">
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
    <div style="margin-left:5px;margin-top:0px; float:left; width:480px;height:auto">
          <div style="float:left;height:auto; width:260px;margin-bottom:5px;margin-top:-26px;border-left:1px groove #000066;">
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

        <div style="margin-top:4px; width:300px;height:auto;float:left;">
        <asp:GridView ID="GridViewTarih" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Groove" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" CellSpacing="2" HorizontalAlign="Justify">
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
</div>

        </div>



<%-------------------------------DETAY PUANTAJ--------------------------%>


<div class="conte">


    İlgili Tarih :


    <asp:Label ID="lblDetayTarih" runat="server" Font-Bold="True" 
        ForeColor="#000066"></asp:Label>


    <br />
    <asp:Label ID="lblDetayHata" runat="server" Font-Bold="True" 
        ForeColor="#CC0000"></asp:Label>


    <br />
    <asp:Label ID="lblDetayHata0" runat="server" Font-Bold="True" 
        ForeColor="#CC0000"></asp:Label>


    <br />
    <asp:Label ID="lblDetayHata1" runat="server" Font-Bold="True" 
        ForeColor="#CC0000"></asp:Label>


    <br />
    <asp:Label ID="lblDetayBilgi" runat="server" Font-Bold="True" 
        ForeColor="#CC0000"></asp:Label>


    <br />
    <strong>Ondalıklı Sayıların arasına virgül ( , ) koyunuz. Gönder dedikten sonra 
    tekrardan aşağıdan kontrölünü yapınız.</strong></div>


<div class"conte">
<div class="conteMin">1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 6&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    7&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 8&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    9&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 10</div>
<div class="conteMin">
<asp:TextBox ID="TextBox1" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox2" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox3" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox4" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox5" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox6" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox7" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox8" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox9" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox10" runat="server" Width="23px"></asp:TextBox>

    </div>

<div class="conteMin">11&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 12&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    13&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 14&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    15&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 16&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    17&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 18&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    19&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 20</div>
<div class="conteMin">
<asp:TextBox ID="TextBox11" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox12" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox13" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox14" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox15" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox16" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox17" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox18" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox19" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox20" runat="server" Width="23px"></asp:TextBox>

    </div>

<div class="conteMin">21&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 22&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    23&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 24&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    25&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 26&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    27&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 28&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    29&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 30&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    31</div>
<div class="conteMin">
<asp:TextBox ID="TextBox21" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox22" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox23" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox24" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox25" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox26" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox27" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox28" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox29" runat="server" Width="23px"></asp:TextBox>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox30" runat="server" Width="23px"></asp:TextBox>

    &nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="TextBox31" runat="server" Width="23px"></asp:TextBox>

    &nbsp;</div>
    <div class="conteMin">
    
    
        <asp:Button ID="Button1" runat="server" Text="GÖNDER" Width="85px" 
            onclick="Button1_Click" />
    
    
    </div>
</div>

<%-------------------------------DETAY PUANTAJ Sonu--------------------------%>


