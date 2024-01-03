<%@ Page Title="" Language="C#" MasterPageFile="~/komisyon/komisyonPage.master" AutoEventWireup="true" CodeFile="soruBelirleme.aspx.cs" Inherits="komisyon_soruBelirleme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="ilkKutu" class="container" runat="server">
   <div class="col-md-12 margin-bottom-20 text"> <font face="arial" color="gray" size="5"> Mulakat sorularınız 
       <asp:Label ID="lblKomisyonAdSoyad" runat="server" Text="" ForeColor="Red"></asp:Label>  tarafından belirlenmiştir. Soruları görmek istiyorsanız aşağıdaki butona tıklayınız..</font>
       </div>
   <div  class="col-md-6">
    <asp:Button ID="btnGuncelle" runat="server" Text="GÜNCELLE/GÖR" CssClass="btn green col-md-6" 
        onclick="btnGuncelle_Click" />
</div>
</div>
<div id="ikinciKutu" class="container" runat="server">
    <div style="font-size:20px;margin-bottom:10px;text-align:center;color:Red"><strong>En fazla 4 soru oluşturulabilir. ilk soru oluşturulduğunda ikinci soru aktif hale gelecektir!!</strong> </div>
     <div style="font-size:20px;margin-bottom:10px;text-align:center;color:Red"><strong>Sorularınız Bitince KAYDET butonuna tıklayınız </strong> </div>
    <div style="font-size:25px;margin-bottom:10px;text-align:center"><strong>Mulakat Soruları Belirle</strong> </div>
<hr />
<div>belirlenen mulakat soru sayısı: 
    <asp:Label ID="lblSoruSayisiHesapla" runat="server" Text=""></asp:Label></div>
<div style="margin-bottom:25px" id="sorularıBelirle1" runat="server">
    <asp:Label ID="lblSoru1" runat="server" Text="1.Soru"></asp:Label>
    <asp:TextBox ID="txtSoru1" runat="server" style="margin-left: 44px" 
        Width="494px"></asp:TextBox><asp:Button ID="btnEkle1" runat="server" 
        Text="EKLE" onclick="btnEkle1_Click" />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    </div>
    <div style="margin-bottom:25px" runat="server" id="sorularıBelirle2">
    <asp:Label ID="lblSoru2" runat="server" Text="2.Soru"></asp:Label>
    <asp:TextBox ID="txtSoru2" runat="server" style="margin-left: 44px" 
        Width="494px"></asp:TextBox><asp:Button ID="btnEkle2" runat="server" 
            Text="EKLE" onclick="btnEkle2_Click" />

    </div>
    <div style="margin-bottom:25px" runat="server" id="sorularıBelirle3">
    <asp:Label ID="lblSoru3" runat="server" Text="3.Soru"></asp:Label>
    <asp:TextBox ID="txtSoru3" runat="server" style="margin-left: 44px" 
        Width="494px"></asp:TextBox><asp:Button ID="btnEkle3" runat="server" 
            Text="EKLE" onclick="btnEkle3_Click" />

    </div>
    <div style="margin-bottom:25px" runat="server" id="sorularıBelirle4">
    <asp:Label ID="lblSoru4" runat="server" Text="4.Soru"></asp:Label>
    <asp:TextBox ID="txtSoru4" runat="server" style="margin-left: 44px" 
        Width="494px"></asp:TextBox><asp:Button ID="btnEkle4" runat="server" 
            Text="EKLE" onclick="btnEkle4_Click" />

    </div>
    <hr />
    <div id="Sorular" runat="server">
    <div id="soru1Gor" runat="server">
    <asp:Label ID="lblSoruEkle1" runat="server" Text="" Width="800px"></asp:Label>
    <asp:Button ID="btnCikar1" runat="server" Text="Çıkar" onclick="btnCikar1_Click" />
    </div>

    <div id="soru2Gor" runat="server">
    <asp:Label ID="lblSoruEkle2" runat="server" Text="" Width="800px"></asp:Label>
    <asp:Button ID="btnCikar2" runat="server" Text="Çıkar" onclick="btnCikar2_Click" />
    </div>

    <div id="soru3Gor" runat="server">
    <asp:Label ID="lblSoruEkle3" runat="server" Text="" Width="800px"></asp:Label>
        <asp:Button ID="btnCikar3" runat="server" Text="Çıkar" 
            onclick="btnCikar3_Click" />
    
    </div>
    <div id="soru4Gor" runat="server">
    <asp:Label ID="lblSoruEkle4" runat="server" Text="" Width="800px"></asp:Label>
        <asp:Button ID="btnCikar4" runat="server" Text="Çıkar" 
            onclick="btnCikar4_Click" />
    
    </div>
        <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" Width="173px" 
            Height="35px" onclick="btnKaydet_Click" />

    </div>
    </div>
</asp:Content>

