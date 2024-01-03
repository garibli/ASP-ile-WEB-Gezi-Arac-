<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ilanCikti.aspx.cs" Inherits="persEkrani_ilanCikti" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
         .auto-style5 {
            max-width: 50px;
            min-width:50px;
        }
        .auto-style7 {
           max-width: 140px;
           min-width:140px;
        }
        .auto-style9 {
            max-width: 100px;
            min-width:100px;

        }
        .auto-style10 {
           max-width: 210px;
           min-width:210px;
        }
        .auto-style11 {
           max-width: 70px;
           min-width:70px;
        }
        .auto-style12 {
           max-width: 70px;
           min-width:70px;
        }
        .style1
        {
            width: 578px;
        }
        .style2
        {
            width: 13px;
        }
        .style3
        {
            width: 594px;
            margin-bottom:15px;
        }
        .style4
        {
            width: 18px;
        }
        .style5
        {
            width: 719px;
        }
        .style7
        {
            width: 170px;
        }
        .style8
        {
            width: 30px;
        }
        .style9
        {
            width: 90px;
        }
        .style10
        {
            width: 140px;
        }
        .style11
        {
            width: 130px;
        }
        .style12
        {
            width: 80px;
        }
    </style>
</head>
<body style="font-size:smaller">
    <form id="form1" runat="server">
    <div><center>
        <p style="text-align:center">SAÜ REKTÖRLÜĞÜ</p>
     <p style="text-align:center">KISMİ ZAMANLI ÖĞRENCİ ÇALIŞTIRMA</p>
     <p style="text-align:center">DUYURUSU</p>
    
     <p style="width: 753px">Yükseköğrenim Kurumlarında Kısmi Zamanlı Öğrenci Çalıştırılabilmesine  İlişkin Usul ve Esaslar çerçevesinde <br />aşağıda detaylı bilgileri yer alan haftada 15 saati geçmemek üzere ve bir saatlik çalışma brüt ücreti : Doktora öğrencisi<br /> için <asp:Label ID="lblDoktoraPara" runat="server" Text=""></asp:Label>-TL, Yüksek Lisans öğrencisi için <asp:Label ID="lblYukseklisansPara" runat="server" Text="Label"></asp:Label>-TL, Lisans öğrencisi için <asp:Label ID="lisansPara" runat="server" Text="Label"></asp:Label>-TL ve Ön Lisans öğrencisi için  <asp:Label ID="lblOnLisansPara" runat="server" Text="Label"></asp:Label>-TL <br />
     olmak üzere toplam  (<asp:Label ID="lblKontenjanSayisi" runat="server" Text=""></asp:Label>)  öğrenci çalıştırılacaktır.</p>
    <p>ÖĞRENCİNİN ÇALŞTIRILACAĞI:</p>
    <table border="1" style="width:700px">
        <tr>
            <td class="style6">Eğitim-Öğretim Dönemi</td>
            <td class="style2">:</td>
            <td class="style1"><asp:Label ID="lblEğitimÖğretimDönemi" runat="server" Text=""></asp:Label> </td>
        </tr>
        <tr>
            <td class="style6">Okul/Fak/Birim Adı</td>
            <td class="style2">:</td>
            <td class="style1"><asp:Label ID="lblBirimAdiGetir" runat="server" Text=""></asp:Label> </td>
        </tr>
        <tr>
            <td class="style6">Başvuru Yeri</td>
            <td class="style2">:</td>
            <td class="style1"><asp:Label ID="lblBasvuruYeri" runat="server" Text=""></asp:Label> </td>
        </tr>
        <tr>
            <td class="style6">Son Başvuru Tarihi</td>
            <td class="style2">:</td>
            <td class="style1"><asp:Label ID="lblSonBasvuruTarihi" runat="server" Text=""></asp:Label> </td>
        </tr>
    </table>
    <br />
    <table border="1" style="width:700px">
    <tr>
    <td class="style3" colspan="2"><strong>A-Kısmi Zamanlı Olarak Çalıştırılacak Öğrencilerde Aranan Genel (Ortak) Nitelikler</strong></td>
    </tr>
    <tr>
    <td class="style4">1</td>
    <td class="style5">Türkiye Cumhuriyeti vatandaşı olmak</td>
    </tr>
    <tr>
    <td class="style4">2</td>
    <td class="style5">Kayıt dondurmamış olmak</td>
    </tr>
    <tr>
    <td class="style4">3</td>
    <td class="style5">Disiplin cezası almamış olmak</td>
    </tr>
    <tr>
    <td class="style4">4</td>
    <td class="style5">Azami öğrencilik süresini doldurmamış olmak</td>
    </tr>
    <tr>
    <td class="style4">5</td>
    <td class="style5">Ölüm aylığı ve nafaka dışında, asgari ücret düzeyinde bir gelire sahip olmamak</td>
    </tr>
    <tr>
    <td>6</td>
    <td class="style5">İşin niteliğine uygun bilgi ve beceriye sahip olmak (alınan sertifika ile veya komisyonca mülakat ile ölçülür).</td>
    </tr>
    <tr>
    <td>7</td>
    <td class="style5">Tezsiz yüksek lisans öğrencileri, Yabancı Uyruklu veya Özel öğrenciler kısmi zamanlı olarak çalıştırılamaz.</td>
    </tr>
    <tr style="margin-bottom:10px">
    <td colspan="2"><strong>B-Kısmi Zamanlı Olarak Çalıştırılacak Öğrencilerde Aranan Özel Nitelikler</strong></td>
    </tr>
    
    <tr>
    <td>1</td>
    <td class="style5">Ön lisans ve lisans öğrencilerinin not ortalamasının en az "2,00" olması, </td>
    </tr>
    <tr>
    <td>2</td>
    <td class="style5">Lisans üstü ve doktora öğrencilerinin not ortalamasının en az "2,50" olması </td>
    </tr>
     <tr>
    <td>3</td>
    <td class="style5">Birinci yarıyıl öğrencilerinde (YGS ve ALES) yüzdelik giriş puanlarına göre değerlendirme yapılır.</td>
    </tr>
     <tr>
    <td>4</td>
    <td class="style5">Lisans üstü öğrencilerinin "Yabancı Dil" seviyesi ile ulusal ya da uluslararası yayın sayısı öncelikli tercih nedeni olarak değerlendirilir. </td>
    </tr>
    </table>
    <br />
    <table border="1" style="width:700px;">
    <tr>
    <td class="style10" rowspan="2"> Birim / Bölüm / Servis Ad</td>
    <td class="style7" rowspan="2">İşin Tanımı </td>
     <td class="style7" rowspan="2">İşin Niteliği</td>
    <td class="style9" rowspan="2"> Program Adı </td>
    <td class="style8" rowspan="2"> Sayı</td>
    <td class="style12" rowspan="2">Çalışma Günleri</td>
    <td class="style11" colspan="2">Çalışma Saatleri</td>
    </tr>
    <tr>
    <td style="width:70px">Ö.Önce</td>
    <td style="width:70px">Ö.Önce</td>
    </tr>
    <tr>
    <td rowspan="5"><asp:Label ID="lblBolumAdi" runat="server" Text=""></asp:Label></td>
    <td rowspan="5"><asp:Label ID="lblIsBasligi" runat="server" Text=""></asp:Label></td>
    <td rowspan="5"><asp:Label ID="lblIsMetni" runat="server" Text=""></asp:Label></td>
    <td ><asp:Label ID="lblProgramAdi" runat="server" Text="Doktora"></asp:Label></td>
    <td >
        <asp:Label ID="lblDoktora" runat="server" Text=""></asp:Label></td>
    <td><asp:Label ID="Label8" runat="server" Text="Pazartesi"></asp:Label></td>
    <td><asp:Label ID="lblPazartesiOO" runat="server" Text=""></asp:Label></td>
    <td ><asp:Label ID="lblPazartesiOS" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
    
    <td>Y.Lisans</td> 
    <td><asp:Label ID="lblYuksekLisans" runat="server" Text=""></asp:Label></td> 
    <td>Salı</td>
    <td><asp:Label ID="lblSaliOO" runat="server" Text=""></asp:Label> </td>
    <td><asp:Label ID="lblSaliOS" runat="server" Text=""></asp:Label> </td>
    </tr>
    
     <tr>
   
     <td>Lisans</td> 
    <td> <asp:Label ID="lblLisans" runat="server" Text=""></asp:Label></td> 
    <td>Çarşamba</td>
    <td><asp:Label ID="lblCarsambaOO" runat="server" Text=""></asp:Label> </td>
    <td><asp:Label ID="lblCarsambaOS" runat="server" Text=""></asp:Label> </td>
    </tr>
     <tr>
     <td>ÖnLisans</td> 
    <td><asp:Label ID="lblOnlisans" runat="server" Text=""></asp:Label></td> 
    <td>Perşembe</td>
    <td><asp:Label ID="lblPersembeOO" runat="server" Text=""></asp:Label> </td>
    <td><asp:Label ID="lblPersembeOS" runat="server" Text=""></asp:Label> </td>
    </tr>
     <tr>
     <td>Farketmez</td>
     <td><asp:Label ID="lblFarkEtmez" runat="server" Text=""></asp:Label></td>
     <td>Cuma</td>
     <td><asp:Label ID="lblCumaOO" runat="server" Text=""></asp:Label> </td>
     <td><asp:Label ID="lblCumaOS" runat="server" Text=""></asp:Label> </td>
     </tr>
 
    </table>
    </center>
    </div>
    </form>
</body>
</html>
