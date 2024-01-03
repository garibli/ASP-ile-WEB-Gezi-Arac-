<%@ Page Title="" Language="C#" MasterPageFile="~/komisyon/komisyonPage.master" AutoEventWireup="true" CodeFile="OgrenciBasvuru.aspx.cs" Inherits="komisyon_OgrenciBasvuru" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 900px;
        }
        .style2
        {
            width: 120px;
        }
        .style3
        {
            width: 150px;
        }
        .style4
        {
            width: 200px;
        }
        .style6
        {
            width: 70px;
        }
        .style7
        {
            width: 100px
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
 <asp:DataList ID="ddlistOGrBasvuruBilgileri" runat="server" CellPadding="4" onitemcommand="DataList1_ItemCommand" CssClass="table"
    ForeColor="#333333" >
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderTemplate>
            <table class="style1">
                <tr>
                    <td class="style2">
                        AD</td>
                    <td class="style3">
                        SOYAD</td>
                    <td class="style4">
                        BIRIM
                    </td>
                    <td class="style6">
                        PUAN</td>
                    <td class="style6">
                        PUAN2</td>
                    <td class="style6">
                        PUAN3</td>
                    <td class="style7">
                        PROGRAM ADI</td>
                    <td>
                        Bilgileri Gör /İşe Al</td>
                </tr>
            </table>
        </HeaderTemplate>
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            <table class="style1">
                <tr>
                    <td class="style2">
                     <%#Eval("ad") %> </td>
                    <td class="style3">
                     <%#Eval("soyad") %> </td>
                    <td class="style4">
                     <%#Eval("birim")%>  
                    </td>
                    <td class="style6">
                     <%#Eval("puan") %> </td>
                          <td class="style6">
                     <%#Eval("puan2") %> </td>
                          <td class="style6">
                     <%#Eval("puan3") %> </td>
                    <td class="style7">
                     <%#Eval("programAdi")%>   </td>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="bilgiGoster"  value="1" ><img src="../img/ilanaktif.png" / style="height:24px;width:24px"></asp:LinkButton> </td>
                </tr>
            </table>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>


<div id="ogrBilgiMenu" runat="server">

    <div class="container row col-md-12 margin-bottom-30">
    <div class="col-md-6">
    <asp:Button ID="btnMulakat" runat="server" Text="MULAKAT SORULARINA GİT" 
        onclick="btnMulakat_Click"  CssClass="btn green"/>
        </div>
        </div>
<hr />


    
    <div class="container"><div class="row"><div class="col-md-12" style="font-size:large"><center><strong>Öğrenci Başvuru Bilgileri</strong></center></div></div></div>
  
  <div class="container"><div class="row"><div class="col-md-12" style="margin-top:5px;margin-bottom:5px;color:Red"><center><strong style="font-size:large">1/3</strong></center></div></div></div>
  
  <div class="container"><div class="row"><div class="col-md-12"><center>(İDARİ BİRİMLERDE "GEÇİCİ İNSAN KAYNAĞI OLARAK ÇALIŞMAK İÇİN AŞAĞIDAKİ BİLGİLERİ DOLDURUN) </div></div></div> 

    <div class="container"><div class="row"><div class="col-md-12"><center><strong>A) KISMİ ZAMANLI ÇALIŞACAK ÖĞRENCİLERİN GENEL BİLGİLERİ</strong></center></div></div></div>										
    <br />
    <div class="container col-md-offset-2">
    <div class="row" style="margin-top:3px">
    <div class="col-md-6" style="font-size:medium">
    Yüksek Öğrenimi süresince kalacağı yer :</div>
    <div class ="col-md-6 ">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl11" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seciniz</asp:ListItem>
            <asp:ListItem Value="1">Kendi Evi</asp:ListItem>
            <asp:ListItem Value="2">Akraba Yanı (Kirasız)</asp:ListItem>
            <asp:ListItem Value="3">Kiralık Ev, Otel</asp:ListItem>
            <asp:ListItem Value="4">Özel Yurt</asp:ListItem>
            <asp:ListItem Value="5">Devlet Yurdu</asp:ListItem>
        </asp:DropDownList>
    </div>
    </div>
     <div class="row" style="margin-top:3px">
     <div class="col-md-6" style="font-size:medium">
         Ailede <span class="style2"><strong>kişi başına</strong></span> düşen gelir miktarı (Kişi Sayısı/Toplam Gelir) :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl12" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">1.500 TL&#39;nin üzerinde</asp:ListItem>
            <asp:ListItem Value="2">1.000 - 1.500 TL arası</asp:ListItem>
            <asp:ListItem Value="3">750 - 999 TL arası</asp:ListItem>
            <asp:ListItem Value="4">500 - 749 TL arası</asp:ListItem>
            <asp:ListItem Value="5">500 TL&#39; den az</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div class="row" style="margin-top:3px">
     <div class="col-md-6" style="font-size:medium">
         Ailede ilköğretim ve lisede okuyan çocuk sayısı :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl13" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">1 Çocuk</asp:ListItem>
            <asp:ListItem Value="2">2 Çocuk</asp:ListItem>
            <asp:ListItem Value="3">3 Çocuk</asp:ListItem>
            <asp:ListItem Value="4">4 Çocuk</asp:ListItem>
            <asp:ListItem Value="5">5 Çocuktan fazla</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div class="row" style="margin-top:3px">
     <div class="col-md-6" style="font-size:medium">
         Ailede yüksek öğrenimde okuyan çocuk sayısı :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6"  ID="ddl14" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">1 Çocuk (Kendisi)</asp:ListItem>
            <asp:ListItem Value="2">2 Çocuk</asp:ListItem>
            <asp:ListItem Value="3">3 Çocuk</asp:ListItem>
            <asp:ListItem Value="4">4 Çocuk</asp:ListItem>
            <asp:ListItem Value="5">5 Çocuktan fazla</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div class="row" style="margin-top:3px">
     <div class="col-md-6" style="font-size:medium">
         Anne ve Babanın Medeni durumu :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6"  ID="ddl15" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Anne ve Baba sağ ve birlikte</asp:ListItem>
            <asp:ListItem Value="2">Anne ve Baba sağ ve ayrı yaşıyor</asp:ListItem>
            <asp:ListItem Value="3">Anne sağ baba ölü</asp:ListItem>
            <asp:ListItem Value="4">Anne ölü baba sağ</asp:ListItem>
            <asp:ListItem Value="5">Anne ve Baba ölü</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div class="row" style="margin-top:3px">
     <div class="col-md-6" style="font-size:medium">
         Anne ve Baba İş (SGK) durumu :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6"  ID="ddl16" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Anne ve Baba çalışıyor</asp:ListItem>
            <asp:ListItem Value="2">Anne veya babadan biri çalışıyor</asp:ListItem>
            <asp:ListItem Value="3">AAnne ve Baba emekli</asp:ListItem>
            <asp:ListItem Value="4">Anne veya Babadan biri emekli</asp:ListItem>
            <asp:ListItem Value="5">Anne ve Baba çalışmıyor</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
       <div class="row" style="margin-top:3px">
     <div class="col-md-6" style="font-size:medium">
         Ailede özel bakıma muhtaç ( hasta veya engelli ) kişi :</div>
    <div class ="col-md-6">
        <asp:DropDownList  CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl17" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Yok</asp:ListItem>
            <asp:ListItem Value="2">Kardeşlerden biri</asp:ListItem>
            <asp:ListItem Value="3">Anne bakıma muhtaç</asp:ListItem>
            <asp:ListItem Value="4">Baba bakıma muhtaç</asp:ListItem>
            <asp:ListItem Value="5">Birden fazla kişi var</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
  
     <div class="row" style="margin-top:3px">
     <div class="col-md-6" style="font-size:medium">
         Burs veya Kredi alıyor mu? :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl18" runat="server" Enabled="false" >
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Birden fazla yerden alıyor.</asp:ListItem>
            <asp:ListItem Value="2">KYK veya Özel Burs alıyor</asp:ListItem>
            <asp:ListItem Value="3">Hiç Burs/Kredi almıyor</asp:ListItem>
            <asp:ListItem Value="4">Kredi almıyor</asp:ListItem>
            <asp:ListItem Value="5">Kredi alıyor.</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div class="row" style="margin-top:3px">
     <div class="col-md-6" style="font-size:medium">
         YGS Puanı (Sadece 1. sınıf öğrencileri için yüzdelik dilime göre) :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6"  ID="ddl19" runat="server" Enabled="false" >
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">% 35 ve üzeri</asp:ListItem>
            <asp:ListItem Value="2">% 25-34 arası</asp:ListItem>
            <asp:ListItem Value="3">% 16-24 arası</asp:ListItem>
            <asp:ListItem Value="4">% 5-15 arası</asp:ListItem>
            <asp:ListItem Value="5">% 1-4 arası</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div class="row" style="margin-top:3px">
     <div class="col-md-6" style="font-size:medium">
         Ders Notu Ortalaması-Transkript (2. ve sonraki sınıflar için) :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl110" runat="server" Enabled="false" >
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">2,00-2,40 arası</asp:ListItem>
            <asp:ListItem Value="2">2,41-2,80 arası</asp:ListItem>
            <asp:ListItem Value="3">2,81-3,20 arası</asp:ListItem>
            <asp:ListItem Value="4">3,21-3,60 arası</asp:ListItem>
            <asp:ListItem Value="5">3,61-4,00 arası</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
      
     <%--<div style="float:left;width:700px;margin-top:10px"><strong>B) MESLEKİ DENEYİM VE SERTİFİKA BİLGİLERİ  (Kanıtlayıcı Belgeler Forma Eklenecektir).											
</strong></div>
      <div style="margin-top:5px">
     <div class="Aciklama">
         Mesleki (İş) deneyimi var mı? (Referansınız varsa ekleyiniz)
 :</div>
    <div class ="aciklama1">
        <asp:DropDownList CssClass="CssDropDownList" ID="ddl21" runat="server">
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Yok</asp:ListItem>
            <asp:ListItem Value="2">1 Yıllık</asp:ListItem>
            <asp:ListItem Value="3">2 Yıllık
</asp:ListItem>
            <asp:ListItem Value="4">3 Yıllık
</asp:ListItem>
            <asp:ListItem Value="5">4 Yıl ve üzerinde
</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div style="margin-top:5px">
     <div class="Aciklama">
         Daha önce çalıştığınız işyeri/iş dalı sayısı
 :</div>
    <div class ="aciklama1">
        <asp:DropDownList CssClass="CssDropDownList" ID="ddl22" runat="server">
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Yok</asp:ListItem>
            <asp:ListItem Value="2">1 Yerde çalıştım</asp:ListItem>
            <asp:ListItem Value="3">2 Yerde çalıştım</asp:ListItem>
            <asp:ListItem Value="4">3 Yerde çalıştım</asp:ListItem>
            <asp:ListItem Value="5">4'ten fazla yerde çalıştım</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div style="margin-top:5px">
     <div class="Aciklama">
         Bilgisayar Ofis Programları Tecrübesi ve Kullanım Düzeyi :</div>
    <div class ="aciklama1">
        <asp:DropDownList CssClass="CssDropDownList" ID="ddl23" runat="server">
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Yok</asp:ListItem>
            <asp:ListItem Value="2">Düşük düzeyde
</asp:ListItem>
            <asp:ListItem Value="3">Orta Düzeyde
</asp:ListItem>
            <asp:ListItem Value="4">İyi Düzeyde
</asp:ListItem>
            <asp:ListItem Value="5">Çok İyi Düzeyde
</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div style="margin-top:5px">
     <div class="Aciklama">
        Bilgisayar teknolojisi konusunda bilgi ve becerisi (Sertifika) var mı?
 :</div>
    <div class ="aciklama1">
        <asp:DropDownList CssClass="CssDropDownList" ID="ddl24" runat="server">
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Yok
</asp:ListItem>
            <asp:ListItem Value="2">Programcı
</asp:ListItem>
            <asp:ListItem Value="3">Yazılımcı
</asp:ListItem>
            <asp:ListItem Value="4">Donanım ve Teknik Servis
</asp:ListItem>
            <asp:ListItem Value="5">Yazılım-Donanım, Onarım (Teknik Servis)
</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div style="margin-top:5px">
     <div class="Aciklama">
        Mali İşler ve Muhasebe alanındaki bilgi seviyesi
 :</div>
    <div class ="aciklama1">
        <asp:DropDownList CssClass="CssDropDownList" ID="ddl25" runat="server">
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Yok</asp:ListItem>
            <asp:ListItem Value="2">Düşük düzeyde
</asp:ListItem>
            <asp:ListItem Value="3">Orta Düzeyde
</asp:ListItem>
            <asp:ListItem Value="4">İyi Düzeyde
</asp:ListItem>
            <asp:ListItem Value="5">Çok İyi Düzeyde
</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div style="margin-top:5px">
     <div class="Aciklama">
         Arşivleme ve Kütüphanecilik alanındaki bilgi seviyesi
 :</div>
    <div class ="aciklama1">
        <asp:DropDownList CssClass="CssDropDownList" ID="ddl26" runat="server">
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Yok</asp:ListItem>
            <asp:ListItem Value="2">Düşük düzeyde
</asp:ListItem>
            <asp:ListItem Value="3">Orta Düzeyde
</asp:ListItem>
            <asp:ListItem Value="4">İyi Düzeyde
</asp:ListItem>
            <asp:ListItem Value="5">Çok İyi Düzeyde
</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>--%>
     <div class="container">
     <div class="Aciklama"></div>
     <div class="col-md-offset-6" style="margin-top:3px">
            
           
            
            </div>
     </div>
      <div style="margin-top:5px">
     <div class="Aciklama">
        </div>
    <div class ="aciklama1">
    </div>
         </div>
</div>
<div class="container"> <div class="row"><div class="col-md-12"><center>(AKADEMİK BİRİMLERDE ÖĞRENCİ ASİSTAN OLARAK ÇALIŞMAK İÇİN AŞAĞIDAKİ BİLGİLERİ DOLDURUN)</center></div></div></div>

   <div class="container"><div class="row"><div class="col-md-12"><center><strong>A) ÖĞRENCİ ASİSTANLARIN GENEL BİLGİLERİ  (Sadece 4. Sınıf Lisans Öğrencileri ile Yüksek Lisans Veya Doktora Öğrencileri Başvurabilir)</strong></center></div></div></div>
  <br />
  <div class="container col-md-offset-2" >
   <div class="row" style="margin-top:3px">
    <div class="col-md-6" style="font-size:medium" >
    Not Ortalaması-Transkript ( * Lütfen dip notu okuyunuz ) : </div>
  
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl21" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seciniz</asp:ListItem>
            <asp:ListItem Value="2">2,50-2,75 arası
            </asp:ListItem>
            <asp:ListItem Value="4">2,76-3,00 arası
            </asp:ListItem>
            <asp:ListItem Value="6">3,01-3,25 arası
            </asp:ListItem>
            <asp:ListItem Value="8">3,26-3,50 arası
            </asp:ListItem>
            <asp:ListItem Value="10">3,51 ve üzeri
            </asp:ListItem>
        </asp:DropDownList>
         </div></div>

     <div class="row" style="margin-top:3px">
     <div class="col-md-6" style="font-size:medium">
        ALES Puanı (varsa):</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl22" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="2">50-60 Arası</asp:ListItem>
            <asp:ListItem Value="4">61-70 Arası
            </asp:ListItem>
            <asp:ListItem Value="6">71-80 Arası
            </asp:ListItem>
            <asp:ListItem Value="8">81-90 Arası
            </asp:ListItem>
            <asp:ListItem Value="10">91-100 Arası
            </asp:ListItem>
        </asp:DropDownList>
    </div></div>

    <div class="row" style="margin-top:3px">
     <div class="col-md-6" style="font-size:medium">
         Ulusal yayın sayısı (Yayın listesini form ekinde veriniz)
 :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl23" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="2">1 Adet
            </asp:ListItem>
            <asp:ListItem Value="4">2 Adet</asp:ListItem>
            <asp:ListItem Value="6">3 Adet</asp:ListItem>
            <asp:ListItem Value="8">4 Adet</asp:ListItem>
            <asp:ListItem Value="10">5 ve daha fazlası</asp:ListItem>
        </asp:DropDownList>
    </div></div>

    <div class="row" style="margin-top:3px">
     <div class ="col-md-6" style="font-size:medium">
         Uluslararası yayın sayısı (Yayın listesini form ekinde veriniz):</div>
    <div class ="col-md-6">
        <asp:DropDownList  CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl24" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="2">1 Adet
            </asp:ListItem>
            <asp:ListItem Value="4">2 Adet</asp:ListItem>
            <asp:ListItem Value="6">3 Adet</asp:ListItem>
            <asp:ListItem Value="8">4 Adet</asp:ListItem>
            <asp:ListItem Value="10">5 ve daha fazlası</asp:ListItem>
        </asp:DropDownList>
    </div> </div>

    <div class="row" style="margin-top:3px">
     <div class ="col-md-6" style="font-size:medium">
         Yabancı Dil bilgi seviyesi (ÜDS/YDS/TOEFL/IELST v.b. Puanı)
 :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl25" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="2">60-75 arası
            </asp:ListItem>
            <asp:ListItem Value="4">76-80 arası
            </asp:ListItem>
            <asp:ListItem Value="6">81-85 arası
            </asp:ListItem>
            <asp:ListItem Value="8">86-90 arası
            </asp:ListItem>
            <asp:ListItem Value="10">91-100 arası
            </asp:ListItem>
        </asp:DropDownList>
    </div> </div>
    
   
      
     <%--<div style="float:left;width:700px;margin-top:10px"><strong>B) MESLEKİ DENEYİM VE SERTİFİKA BİLGİLERİ  (Kanıtlayıcı Belgeler Forma Eklenecektir).											
									
</strong></div>
      <div style="margin-top:5px">
     <div class="Aciklama">
         Daha önce çalıştığınız işyeri/iş dalı sayısı

 :</div>
    <div class ="aciklama1">
        <asp:DropDownList CssClass="CssDropDownList" ID="ddl21" runat="server">
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="2">Yok</asp:ListItem>
            <asp:ListItem Value="4">1 Yıllık</asp:ListItem>
            <asp:ListItem Value="6">2 Yıllık
</asp:ListItem>
            <asp:ListItem Value="8">3 Yıllık
</asp:ListItem>
            <asp:ListItem Value="10">4 Yıl ve üzerinde
</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
   
    <div style="margin-top:5px">
     <div class="Aciklama">
         Bilgisayar Ofis Programları Tecrübesi ve Kullanım Düzeyi :</div>
    <div class ="aciklama1">
        <asp:DropDownList CssClass="CssDropDownList" ID="ddl23" runat="server">
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="2">Yok</asp:ListItem>
            <asp:ListItem Value="4">Düşük düzeyde
</asp:ListItem>
            <asp:ListItem Value="6">Orta Düzeyde
</asp:ListItem>
            <asp:ListItem Value="8">İyi Düzeyde
</asp:ListItem>
            <asp:ListItem Value="10">Çok İyi Düzeyde
</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div style="margin-top:5px">
     <div class="Aciklama">
        Bilgisayar teknolojisi konusunda bilgi ve becerisi (Sertifika) var mı?
 :</div>
    <div class ="aciklama1">
        <asp:DropDownList CssClass="CssDropDownList" ID="ddl24" runat="server">
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="2">Yok</asp:ListItem>
            <asp:ListItem Value="4">Düşük düzeyde
</asp:ListItem>
            <asp:ListItem Value="6">Orta Düzeyde
</asp:ListItem>
            <asp:ListItem Value="8">İyi Düzeyde
</asp:ListItem>
            <asp:ListItem Value="10">Çok İyi Düzeyde
</asp:ListItem>
        </asp:DropDownList>
    </div>

    
         </div>--%>
          <div class="row" style="margin-top:3px">
     <div class="col-md-6" style="font-size:medium">
        
             <strong style="font-style: italic">Engelli , Şehit Yakını , SHÇEK , Sportif Başarılı* Öğrenci İseniz Seçiniz
            :<br />
             *(Hakem,Milli Sporcu vb.)</strong>
             <br />
              </div>
            <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl26" runat="server" Enabled="false" >
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Evet</asp:ListItem>
            <asp:ListItem Value="0">Hayır</asp:ListItem>
        </asp:DropDownList>
    </div>   </div>

    <div class="row">
    <div class ="col-md-10 " style="margin-top:25px" style="margin-top:3px;font-size:medium" Enabled="false" >
            
        <strong>Başvuru bilgilerimin doğru olduğunu beyan ediyorum. Yanlış ve yanıltıcı 
        beyanlardan dolayı hertürlü hukuki, idari, cezai, müeyidelerin uygulanmasını 
        kabul ediyorum.</strong></div></div>

   <div class="row">
     <div class="col-md-offset-6">
            
            
            </div>
            </div>
    
     <div class="row" style="margin-top:3px">
     <div class="col-md-8">(*) a) 4. Sınıftaki Lisans Öğrencileri 3. Sınıf Ders Notu Ortalamasını, 		

</div>
     <div class="Aciklama1">
            
            </div>
     </div>
     <div class="row">
     <div class="col-md-8">&nbsp;&nbsp;&nbsp b) Yüksek Lisans öğrencileri Lisans Mezuniyet Ortalamasını, 		
</div>
     <div class="Aciklama1">
            
            </div>
     </div>
      <div class="row">
     <div class="col-md-8">&nbsp;&nbsp;&nbsp c) Doktora Öğrencileri Yüksek Lisans Mezuniyet Ortalamasını, Yazacaklardır. 		
</div>
     <div class="Aciklama1">
            
            </div>
     </div>
     <div class="row">
     <div class="col-md-8">
        </div>
    <div class ="aciklama1">
    </div>
         </div>
</div>
<div class="container">
 <div class="row" ><div class="col-md-12" style="font-size:large"><center><strong>
        Öğrenci Başvuru Bilgileri</strong></center></div></div>

 <div class ="col-md-12" style="font-size:large"><center> <strong style="margin-top:5px;margin-bottom:5px;color:Red">
       3/3</strong></center></div>

        <div class="col-md-12"><center><strong>İlgili alanları seçiniz.																						
</strong></center></div>
      </div>
      
   <div class="container col-md-offset-2">
   
    <div class="row" style="margin-top:3px" >
    <div class="col-md-6" style="font-size:medium" >
    Engelli ise konusu ve derecesi 
        :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl31" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seciniz</asp:ListItem>
            <asp:ListItem Value="1">% 40-44 Engelli</asp:ListItem>
            <asp:ListItem Value="2">%  45-49 Engelli</asp:ListItem>
            <asp:ListItem Value="3">% 50-54 Engelli</asp:ListItem>
            <asp:ListItem Value="4">% 55-59 Engelli</asp:ListItem>
            <asp:ListItem Value="5">% 60 ve üzeri engelli</asp:ListItem>
        </asp:DropDownList>
    </div>
        </div>
     <div class ="row" style="margin-top:3px">
     <div class ="col-md-6" style="font-size:medium" >
        Şehit Yakını ise durumu 

 :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6"  ID="ddl32" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Kardeşi şehit</asp:ListItem>
            <asp:ListItem Value="2">Çocuğu şehit</asp:ListItem>
            <asp:ListItem Value="3">Annesi şehit</asp:ListItem>
            <asp:ListItem Value="4">Babası şehit</asp:ListItem>
            <asp:ListItem Value="5">Anne ve Babası şehit</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <%--<div style="margin-top:5px">
     <div class="Aciklama">
         Ulusal yayın sayısı (Yayın listesini form ekinde veriniz)
 :</div>
    <div class ="aciklama1">
        <asp:DropDownList CssClass="CssDropDownList" ID="ddl13" runat="server" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="2">1 Adet
</asp:ListItem>
            <asp:ListItem Value="4">2 Adet</asp:ListItem>
            <asp:ListItem Value="6">3 Adet</asp:ListItem>
            <asp:ListItem Value="8">4 Adet</asp:ListItem>
            <asp:ListItem Value="10">5 ve daha fazlası</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>--%>
    <div class ="row" style="margin-top:3px">
     <div class ="col-md-6" style="font-size:medium" >
         SHÇEK'dan gelen öğrenci ise durum bilgisi

 :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6"  ID="ddl33" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Anne baba sağ ve birlikte</asp:ListItem>
            <asp:ListItem Value="2">Anne baba ayrı</asp:ListItem>
            <asp:ListItem Value="3">Anne ölü baba sağ</asp:ListItem>
            <asp:ListItem Value="4">Anne sağ baba ölü</asp:ListItem>
            <asp:ListItem Value="5">Anne ve Baba ölü</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div class ="row" style="margin-top:3px">
     <div class ="col-md-6" style="font-size:medium" >
         Sportif başarı veya Özel Yetenek durumu

 :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl34" runat="server" Enabled="false" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Hakem</asp:ListItem>
            <asp:ListItem Value="2">Sertifikalı Çalıştırıcı</asp:ListItem>
            <asp:ListItem Value="3">Eğitmen</asp:ListItem>
            <asp:ListItem Value="4">Antrenör</asp:ListItem>
            <asp:ListItem Value="5">Milli sporcu</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    
    <div class="container">
     <div class ="row" style="margin-top:3px">
     <div class="col-md-offset-6">
            
          
            
            </div>
     </div>
     </div>
     
</div>
</div>
</asp:Content>



