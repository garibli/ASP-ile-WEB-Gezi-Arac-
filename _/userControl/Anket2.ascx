<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Anket2.ascx.cs" Inherits="userControl_Anket2" %>

<div class="container">
 <div class="row" ><div class="col-md-12" style="font-size:large"><center><strong>Öğrenci Başvuru Bilgileri</strong></center></div></div></div>

 <div class="container"> <div class="row"><div class="col-md-12" style="margin-top:5px;margin-bottom:5px;color:Red"><center><strong style="font-size:large">2/3</strong></center></div></div></div>
      
  <div class="container"> <div class="row"><div class="col-md-12"><center>(AKADEMİK BİRİMLERDE ÖĞRENCİ ASİSTAN OLARAK ÇALIŞMAK İÇİN AŞAĞIDAKİ BİLGİLERİ DOLDURUN)</center></div></div></div>

   <div class="container"><div class="row"><div class="col-md-12"><center><strong>A) ÖĞRENCİ ASİSTANLARIN GENEL BİLGİLERİ  (Sadece 4. Sınıf Lisans Öğrencileri ile Yüksek Lisans Veya Doktora Öğrencileri Başvurabilir)</strong></center></div></div></div>
  <br />
  <div class="container col-md-offset-2" >
   <div class="row" style="margin-top:3px">
    <div class="col-md-6" style="font-size:medium" >
    Not Ortalaması-Transkript ( * Lütfen dip notu okuyunuz ) : </div>
  
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl11" runat="server">
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
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl12" runat="server" >
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
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl13" runat="server" >
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
        <asp:DropDownList  CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl14" runat="server">
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
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl15" runat="server">
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
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl25" runat="server">
            <asp:ListItem Selected="True" Value="0">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Evet</asp:ListItem>
            <asp:ListItem Value="0">Hayır</asp:ListItem>
        </asp:DropDownList>
    </div>   </div>

    <div class="row">
    <div class ="col-md-10 " style="margin-top:25px" style="margin-top:3px;font-size:medium">
            
        <strong>Başvuru bilgilerimin doğru olduğunu beyan ediyorum. Yanlış ve yanıltıcı 
        beyanlardan dolayı hertürlü hukuki, idari, cezai, müeyidelerin uygulanmasını 
        kabul ediyorum.</strong></div></div>

   <div class="row">
     <div class="col-md-offset-6">
            
            <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Text="Bitir" 
             OnClick="btnDevam_Click" />
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