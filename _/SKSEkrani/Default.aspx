<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="SKSEkrani_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row"><div class="col-md-12"><div class="page-title"><h3><strong>ÖĞRENCİ İŞLEMLERİ</strong></h3></div></div></div>
     <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue-madison">
                    <a class="more" href="HizliCalisanEkle.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:25px;text-align:center">
								KAYIT
							</div>
							<div class="desc">
								
							</div>
						</div> 
						</a>
					</div>
				</div> 
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat red-intense">
                    <a class="more" href="CalisanDuzenle.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:25px">
								Güncelle (GENEL)
							</div>
							
						</div>
						
						</a>
					</div>
				</div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat green-haze">
                    <a class="more" href="GSSDegistir.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:25px">
								Güncelle(GSS) 
							</div>
							
						</div>
						
						</a>
					</div>
				</div>
                 <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat grey-cascade">
                    <a class="more" href="HesapNoGuncelle.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:25px">
								Güncelle(IBAN)
							</div>
							<div class="desc">
							
							</div>
						</div>
						
						</a>
					</div>
				</div> 

     </div>
     <div class="row">
       <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue-madison">
                    <a class="more" href="CalisanDuzenle.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:25px">
								Sil
							</div>
							<div class="desc">
							
							</div>
						</div>
						</a>
					</div>
				</div> 
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat purple">
                    <a class="more" href="IseAlim.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:25px">
								Çalışacağı yer
							</div>
							<div class="desc">
								 
							</div>
						</div>
						</a>
					</div>
				</div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat green">
                    <a class="more" href="OzelOgrIseAlım.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number">
								 Engelli 
							</div>
							<div class="desc">
								Öğrenci İşe Alım
							</div>
						</div>
						</a>
					</div>
				</div>
                 
     </div>
     <hr />
<div class="row"><div class="col-md-12"><div class="page-title"><h3><strong>SGK İŞLEMLERİ</strong></h3></div></div></div>
<div class="row">
       <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue-madison">
                    <a class="more" href="SGKGiris.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:25px">
								SGK Giriş
							</div>
							<div class="desc">
							
							</div>
						</div>
						</a>
					</div>
				</div> 
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat red-intense">
                    <a class="more" href="SGKCikis.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:25px">
								 SGK Çıkış
							</div>
							<div class="desc">
								 
							</div>
						</div>
						</a>
					</div>
				</div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat green-haze">
                    <a class="more" href="CalismaYerleri.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px">
								Mukerrer kayıt iptal
							</div>
							<div class="desc">
								
							</div>
						</div>
						</a>
					</div>
				</div>

                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat yellow">
                    <a class="more" href="SGKGecmisi.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px">
								  Mukerrer kayıt iptal/2
							</div>
							<div class="desc">
								
							</div>
						</div>
						</a>
					</div>
				</div>
     </div>

     <div class="row">
       <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue-madison">
                    <a class="more" href="SGKGirisGuncelle.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px">
								SGK Giriş Güncelle
							</div>
							<div class="desc">
							
							</div>
						</div>
						</a>
					</div>
				</div> 
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat red-intense">
                    <a class="more" href="SGKCikisGuncelle.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px">
								 SGK Çıkış Güncelle
							</div>
							<div class="desc">
								 
							</div>
						</div>
						</a>
					</div>
				</div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat yellow-crusta">
                    <a class="more" href="SGKCikisNull.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:25px">
								 SGK Çıkış Sil
							</div>
							<div class="desc">
								
							</div>
						</div>
						</a>
					</div>
				</div>

                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue">
                    <a class="more" href="#">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:25px">
								 Prim İşlemleri
							</div>
							<div class="desc">
								
							</div>
						</div>
						</a>
					</div>
				</div>


                 
     </div>

     <hr />
     <div class="row"><div class="col-md-12"><div class="page-title"><h3><strong>MUHASEBE İŞLEMLERİ</strong></h3></div></div></div>
      <div class="row">
       <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue-madison">
                    <a class="more" href="Odenekler.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number">
								BİRİM FİYAT
							</div>
							<div class="desc">
							Oranları
							</div>
						</div>
						</a>
					</div>
				</div> 
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat red-intense">
                    <a class="more" href="YasalKes.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number">
								 YASAL KESİNTİ
							</div>
							<div class="desc">
								 Olan Çalışanlar
							</div>
						</div>
						</a>
					</div>
				</div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat yellow-crusta">
                    <a class="more" href="TatilGunleri.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number">
								 RESMİ TATİL
							</div>
							<div class="desc">
								Günleri Giriş
							</div>
						</div>
						</a>
					</div>
				</div>

                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue">
                    <a class="more" href="PuantajGirilecekAySuresi.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number">
								 PUANTAJ 
							</div>
							<div class="desc">
								Girme Süresi Belirle
							</div>
						</div>
						</a>
					</div>
				</div>


                 
     </div>
</asp:Content>

