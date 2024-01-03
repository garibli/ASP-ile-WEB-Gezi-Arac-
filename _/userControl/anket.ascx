<%@ Control Language="C#" AutoEventWireup="true" CodeFile="anket.ascx.cs" Inherits="userControl_anket" %>

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
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl11" runat="server" >
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
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl12" runat="server" >
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
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl13" runat="server" >
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
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6"  ID="ddl14" runat="server">
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
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6"  ID="ddl15" runat="server">
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
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6"  ID="ddl16" runat="server">
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
        <asp:DropDownList  CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl17" runat="server">
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
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl18" runat="server">
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
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6"  ID="ddl19" runat="server">
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
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl110" runat="server">
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
            
            <asp:Button ID="btnDevam" runat="server"  Text="Devam Et" CssClass="btn btn-primary"
            
             OnClick="btnDevam_Click" />
            
            </div>
     </div>
      <div style="margin-top:5px">
     <div class="Aciklama">
        </div>
    <div class ="aciklama1">
    </div>
         </div>
</div>