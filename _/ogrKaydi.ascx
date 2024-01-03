<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ogrKaydi.ascx.cs" Inherits="NewFolder1_WebUserControl" %>
<style>
     .conteMain{
         height:345px;
         width:850px;
         float:left;
     }
    .conteMin {
        height:20px;
        width:850px;
        margin-top:5px;      
    }
     .Aciklama{
       
        height:20px;
        width:270px;
        float:left;
       
    }
     .textBox{
        height:20px;
        width:148px;
        float:left;
    }
  
    .uyari{
        height:20px;
        width:329px;
        float:left;
        
    }
    .gonderBtn{
        float:right;
        height:20px;
        width:80px;
    }
</style>
 <div class="container">
        <div class="row">
        <div class=" col-md-offset-2 col-md-8">
            <h3><asp:Label ID="lblBilgi"  runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></h3>
        </div>
        </div>   
    </div>
<div class="portlet box red col-md-8 col-md-offset-2">
            <div class="portlet-title">
              <div class="caption">
                <i class="fa fa-gift"></i> SKS-KISMİ ZAMANLI İŞE ALIM ÖN KAYIT FORMU
              </div>
              
            </div>
            <div class="portlet-body form col-md-12">
              <form role="form-horizontal">
                <div class="form-body">
                  <div class="form-group">
                  <div class="row col-md-12"  style="margin-top:10px">
                  <label class="col-md-3 control-label">TC Kimlik Nunamaranız</label>
                  <div class="col-md-9">
                   <asp:TextBox ID="txtTC" runat="server" MaxLength="11" class="form-control " placeholder="TC NO"
                 OnTextChanged="txtTC_TextChanged"></asp:TextBox>
                 </div>
                   </div>
                  </div>
                 <div class="form-group  "  >
                 <div class="row col-md-12" style="margin-top:10px">
                 <div><label  class="col-md-3 control-label">Öğrenci Numaranız</label></div>
                 <div class="col-md-9"> 
                    <asp:TextBox ID="txtOgrNo" runat="server" MaxLength="10"  class="form-control " placeholder="Öğrenci NO"
                 OnTextChanged="txtTC_TextChanged"></asp:TextBox>
                  </div>
                  </div>  
                  </div>
                   <div class="form-group margin-top-10"  style="margin-bottom:10px">
                   <div class="row col-md-12" style="margin-top:10px">
                    <label  class="col-md-3 control-label">Adınız</label>
                    <div class="col-md-9"> 
                    <asp:TextBox ID="txtAd" runat="server" MaxLength="30" class="form-control " placeholder="Ad"></asp:TextBox>           
                  </div>
                  </div></div>
                   <div class="form-group margin-bottom-10">
                    <div class="row col-md-12" style="margin-top:10px">
                    <label class="col-md-3 control-label">Soyadınız</label>
                    <div class="col-md-9"> 
                    <asp:TextBox ID="txtSoyad" runat="server" MaxLength="15" class="form-control " placeholder="Soyad"></asp:TextBox>
                  </div>
                  </div></div> s
                   <div class="form-group margin-bottom-10">
                   <div class="row col-md-12" style="margin-top:10px;visibility: hidden">
                    
                     <div class="col-md-9"> 
                    <asp:TextBox ID="txtMail" Visible="false" runat="server" MaxLength="50" class="form-control " placeholder="Öğrenci Mail Adresiniz"></asp:TextBox>
                  </div>
                  </div></div>
                   <div class="form-group margin-bottom-10 ">
                    <div class="row col-md-12" style="margin-top:10px">
                    <label class="col-md-3 control-label">Cep Numaranız</label>
                    <div class="col-md-9"> 
                    <asp:TextBox ID="txtCep" runat="server" MaxLength="10" class="form-control " placeholder="5XXXXXXXX"
                 OnTextChanged="txtCep_TextChanged"></asp:TextBox>
                  </div>
                  </div></div>

                  <div class="form-group margin-bottom-10">
                   <div class="row col-md-12" style="margin-top:10px">
                    <label class="col-md-3 control-label">Fakulte</label>
                    <div class="col-md-9"> 
                    <asp:DropDownList ID="ddlFakYukOkul" runat="server"   class="form-control "
                AutoPostBack="True" OnSelectedIndexChanged="ddlFakYukOkul_SelectedIndexChanged">
            </asp:DropDownList>
                   </div>
                  </div></div>

                 <div class="form-group margin-bottom-10">
                 <div class="row col-md-12" style="margin-top:10px">
                    <label  class="col-md-3 control-label">Bölümünüz</label>
                    <div class="col-md-9"> 
                    <asp:DropDownList ID="ddlBolum" runat="server"  class="form-control">
            </asp:DropDownList>
                    </div>
                  </div></div>
                 <div class="form-group margin-bottom-10">
                 <div class="row col-md-12" style="margin-top:10px">
                    <label class="col-md-3 control-label">Öğrenim Türü</label>
                    <div class="col-md-9"> 
                      <asp:DropDownList ID="ddlOgrenimTuru" runat="server"  class="form-control ">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="1">Önlisans</asp:ListItem>
                <asp:ListItem Value="2">Lisans</asp:ListItem>
                <asp:ListItem Value="3">Yüksek Lisans</asp:ListItem>
                <asp:ListItem Value="4">Doktora</asp:ListItem>
            </asp:DropDownList>
                    </div>
                  </div></div>
                  <div class="form-group margin-bottom-10">
                  <div class="row col-md-12" style="margin-top:10px">
                    <label  class="col-md-3 control-label">Sınıfınız</label>
                    <div class="col-md-9"> 
                    <asp:DropDownList ID="ddlSinif" runat="server" class="form-control "
                >
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
              </asp:DropDownList>
                   </div>
                   </div></div>
                    <div  class="form-group margin-bottom-10">
                    <div class="row col-md-12" style="margin-top:10px">
                    <label class="col-md-3 control-label">NOT ORTALAMANIZ:</label>
                       
                 <div class="col-md-2">
            <asp:DropDownList ID="ddlNot1" runat="server" class="form-control input-sm">
                <asp:ListItem Selected="True">0</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
            </asp:DropDownList>
           </div>
           <div class="col-md-1"><label><strong>,</strong></label>
           </div>
           <div class="col-md-2">
            <asp:DropDownList ID="ddlNot2" runat="server" class="form-control input-sm">
                <asp:ListItem Selected="True">0</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
            </asp:DropDownList>
            </div>
            <div class="col-md-2">
            <asp:DropDownList ID="ddlNot3" runat="server" class="form-control input-sm">
                <asp:ListItem Selected="True">0</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
            </asp:DropDownList>
          </div>
          </div>
                  </div>
                  <div class="form-group margin-bottom-10">
                  <div class="row col-md-12 " style="margin-top:10px">
                    <label  class="col-md-3 control-label">Ziraat IBAN NO</label>
                    <div class="col-md-9">
                     <asp:TextBox ID="txtIBAN" runat="server" class="form-control " placeholder="YOKSA BOŞ BIRAKIN!!"></asp:TextBox>
                    </div>
                  </div></div>
                  <div class="form-group margin-bottom-10 " id="sifre" runat="server">
                   <div class="row col-md-12 " style="margin-top:10px;visibility: hidden;">
                    <label   class="col-md-3 control-label" >Şifreniz</label>
                    <div class="col-md-9" >
                    <asp:TextBox ID="txtSifre" runat="server" TextMode="Password" MaxLength="8" Text="123" Enabled="false"
             class="form-control " placeholder="Şifre Belirle"></asp:TextBox>
                  </div>
                  </div></div>
                 
                  <div class="form-group margin-bottom-10"  id="sifre" >
                  <div class="row col-md-12" style="margin-top:10px; visibility: hidden;">
                    <label  class="col-md-3 control-label">Şifreyi Doğrulayın</label>
                     <div class="col-md-9">
                    <asp:TextBox ID="txtSifreDogrula" runat="server" Text="123" Enabled="false"
                TextMode="Password" MaxLength="8" class="form-control " placeholder="Şifre Tekrar"></asp:TextBox>
                    </div></div>
                  </div>
                       <div class="form-group margin-bottom-10">
                        <div class="row col-md-12" style="margin-top:10px">
                    <label  class="col-md-7 control-label">Ailenizin sağlık sigortasından yararlanıyormusunuz ?</label >
                     <div class="col-md-5">
                    <asp:DropDownList ID="ddlGSS2243" runat="server" class="form-control">
                <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
                <asp:ListItem Value="22">Evet</asp:ListItem>
                <asp:ListItem Value="43">Hayır</asp:ListItem>
            </asp:DropDownList>
              </div></div></div>
                  <div class="form-group margin-bottom-10" style="margin-top:10px"><label class="col-md-3 control-label">Çap Yapıyormusunuz :</label>
                   <div class="col-md-9">
                   <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" /></div>
                  </div>
                  
                       <div class="form-group margin-bottom-10">
                        <div class="row col-md-12" style="margin-top:10px">
                    <label  class="col-md-3 control-label">Çap Fakülte/Yüksekokul</label>
                    <div class="col-md-9">
                     <asp:DropDownList ID="ddlCapFak" runat="server" class="form-control"
                Visible="False" OnSelectedIndexChanged="ddlCapFak_SelectedIndexChanged" 
                AutoPostBack="True">
            </asp:DropDownList>
                    </div></div>
                  </div>
                       <div class="form-group ">
                       <div class="row col-md-12" style="margin-top:10px">
                     
                    <label class="col-md-3">Çap Bölümünüz</label>
                    <div class="col-md-9">
                    <asp:DropDownList ID="ddlCapBolum" runat="server" class="form-control"
                Visible="False">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
            </asp:DropDownList>
            </div>
                   </div>
                  </div>
                      <div class="form-group ">
                       <div class="row" style="margin-top:10px">
                     
                    <label class="col-md-3"></label>
                    <div class="col-md-9">
            </div>
                   </div>
                  </div>
                <div class="form-actions right">
                 <asp:Button ID="btnGonder" runat="server" CssClass="btn btn-success" Text="Gönder"   OnClick="btnGonder_Click" />
                 
                </div>
                
              </form>
            </div>
         </div>

            
 
            
           
            
       
   
    

