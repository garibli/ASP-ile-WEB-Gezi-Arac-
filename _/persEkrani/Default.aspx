<%@ Page Title="" Language="C#" MasterPageFile="~/persEkrani/PersMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="persEkrani_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <style>
   div[title]:hover:after {
  content: attr(title);
  padding: 4px 8px;
  color: #333;
  position: absolute;
  left: 0;
  top: 100%;
  z-index: 20;
  white-space: nowrap;
  -moz-border-radius: 5px;
  -webkit-border-radius: 5px;
  border-radius: 5px;
  -moz-box-shadow: 0px 0px 4px #222;
  -webkit-box-shadow: 0px 0px 4px #222;
  box-shadow: 0px 0px 4px #222;
  background-image: -moz-linear-gradient(top, #eeeeee, #cccccc);
  background-image: -webkit-gradient(linear,left top,left bottom,color-stop(0, #eeeeee),color-stop(1, #cccccc));
  background-image: -webkit-linear-gradient(top, #eeeeee, #cccccc);
  background-image: -moz-linear-gradient(top, #eeeeee, #cccccc);
  background-image: -ms-linear-gradient(top, #eeeeee, #cccccc);
  background-image: -o-linear-gradient(top, #eeeeee, #cccccc);
}
   </style>
   <div class="row"><div class="col-md-12"><div class="page-title"><h3><strong>KONTENJAN İŞLEMLERİ</strong></h3></div></div></div>
    <div class="row">
    <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue-madison">
                    <a class="more" href="kontenjanTalep.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px;text-align:center">
								KONTENJAN TALEP
							</div>
							<div class="desc">
								
							</div>
						</div> 
						</a>
					</div>
				</div> 
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat red">
                    <a class="more" href="kontenjanTakip.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px;text-align:center">
								KONTENJAN TAKİP
							</div>
							<div class="desc">
								
							</div>
						</div> 
						</a>
					</div>
				</div> 
    </div> 
    <hr />
<div class="row">
<div class="col-md-12"><div class="page-title"><h3><strong>PUANTAJ İŞLEMLERİ</strong></h3></div></div></div>
     
     <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue-madison">
                    <a class="more" href="ogrYoklama.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px;text-align:center">
								PUANTAJ GİR
							</div>
							<div class="desc">
								
							</div>
						</div> 
						</a>
					</div>
				</div> 
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue">
                    <a class="more" href="Puantaj.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px">
								PUANTAJ GÖRÜNTÜLE
							</div>
							
						</div>
						
						</a>
					</div>
				</div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat green-haze">
                    <a class="more" href="hazirlayanOnaylayan.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px">
								HAZ. ONAY. KAYDET
							</div>
							
						</div>
						
						</a>
					</div>
				</div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat red-intense">
                    <a class="more" href="CalisanDetay.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px">
								ÇALIŞAN LİSTELE
							</div>
							
						</div>
						
						</a>
					</div>
				</div>
              
     </div> 
       <hr />
     <div class="row"><div class="col-md-12"><div class="page-title"><h3><strong>İLAN İŞLEMLERİ</strong></h3></div></div></div>
     
     <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue-madison">
                    <a class="more" href="IlanEkle.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px;text-align:center">
								İLAN OLUŞTUR
							</div>
							<div class="desc">
								
							</div>
						</div> 
						</a>
					</div>
				</div> 
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat red-intense">
                    <a class="more" href="ilanListele.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px">
								İLAN LİSTELE
							</div>
							
						</div>
						
						</a>
					</div>
				</div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat green-haze">
                    <a class="more" href="ilanDuzenle.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px">
								İLAN DÜZENLE/SİL
							</div>
							
						</div>
						
						</a>
					</div>
				</div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
					<div class="dashboard-stat blue">
                    <a class="more" href="ilanAktifleştir.aspx">
						<div class="visual">
						</div>
						<div class="details">
							<div class="number" style="font-size:20px">
								İLAN ARŞİVİ
							</div>
							
						</div>
						
						</a>
					</div>
				</div>
                
     </div> 
</asp:Content>

