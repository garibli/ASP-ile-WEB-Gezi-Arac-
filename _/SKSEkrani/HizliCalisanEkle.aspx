<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="HizliCalisanEkle.aspx.cs" Inherits="SKSEkrani_HizliCalisanEkle" %>

<%@ Register src="../userControl/ogrKaydi.ascx" tagname="ogrKaydi" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container" style="margin-top:5px">
    <div class="row margin-bottom-10">
            <div class="col-md-8">
                <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </div>
            
        </div>
    <div class="row margin-bottom-10 col-md-12">
    
                    <a id="asama" runat="server" href="IseAlim.aspx" class="btn blue">DİĞER AŞAMAYA GEÇ</a>
    </div>
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                T.C Kimlik Numarası</div>
            <div class="col-md-5">
                <asp:TextBox ID="txtTC" runat="server" MaxLength="11" 
                CssClass="form-control"></asp:TextBox>
            </div>
            
        </div>
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                Öğrenci Numarası</div>
            <div class="col-md-5">
                <asp:TextBox ID="txtOgrNo" runat="server" MaxLength="10" 
                CssClass="form-control"></asp:TextBox>
            </div>
            
        </div>
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                Adı </div>
            <div class="col-md-5">
                <asp:TextBox ID="txtAd" runat="server" MaxLength="30" CssClass="form-control"></asp:TextBox>
            </div>
            
        </div>
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                Soyadı</div>
            <div class="col-md-5">
                <asp:TextBox ID="txtSoyad" runat="server" MaxLength="15" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                Mail Adresi</div>
            <div class="col-md-5">
                <asp:TextBox ID="txtMail" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                Cep Numarası</div>
            <div class="col-md-5">
                <asp:TextBox ID="txtCep" runat="server" MaxLength="10" 
                CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                *Bilinmiyorsa boş bırakın</div>
        </div>
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                Fakülte/Yuksekokul</div>
            <div class="col-md-5">
                <asp:DropDownList ID="ddlFakYukOkul" runat="server" CssClass="col-md-12 btn btn-default dropdown-toggle" AutoPostBack="True" OnSelectedIndexChanged="ddlFakYukOkul_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                Bölümü</div>
            <div class="col-md-5">
                <asp:DropDownList ID="ddlBolum" runat="server" CssClass="col-md-12 btn btn-default dropdown-toggle">
                </asp:DropDownList>
            </div>
            <div class="uyari">
            </div>
        </div>
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                Öğrenim Türü</div>
            <div class="col-md-5">
                <asp:DropDownList ID="ddlOgrenimTuru" runat="server" CssClass="col-md-12 btn btn-default dropdown-toggle">
                    <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                    <asp:ListItem Value="1">Önlisans</asp:ListItem>
                    <asp:ListItem Value="2">Lisans</asp:ListItem>
                    <asp:ListItem Value="3">Yüksek Lisans</asp:ListItem>
                    <asp:ListItem Value="4">Doktora</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="uyari">
            </div>
        </div>
         <div class="row margin-bottom-5">
        <div class="col-md-3">Sınıfınız</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlSinif" runat="server" CssClass="col-md-12 btn btn-default dropdown-toggle">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
            </asp:DropDownList>
            </div>
        <div class="uyari">
        </div>
    </div>
    <div class="row margin-bottom-5">
        <div class="col-md-3">Not Ortalamanız</div>
        <div class="col-md-6">
            <asp:DropDownList ID="ddlNot1" runat="server" CssClass="col-md-3 btn btn-default dropdown-toggle">
                <asp:ListItem Selected="True">0</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
            </asp:DropDownList>
                 <div class="col-md-1">
                ,
                </div>
            <asp:DropDownList ID="ddlNot2" runat="server" CssClass="col-md-3 btn btn-default dropdown-toggle">
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
            <asp:DropDownList ID="ddlNot3" runat="server" CssClass="col-md-3 btn btn-default dropdown-toggle">
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
        <div class="uyari">
        </div>
    </div>
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                IBAN NO</div>
            <div class="col-md-5">
                <asp:TextBox ID="txtIBAN" runat="server" MaxLength="26" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
            *Yoksa Boş Bırakın</div>
        </div>
        
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                Aileniz üzerinden sigortanız varmı</div>
            <div class="col-md-5">
                <asp:DropDownList ID="ddlGSS2243" runat="server" CssClass="col-md-12 btn btn-default dropdown-toggle">
                    <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
                    <asp:ListItem Value="22">Evet</asp:ListItem>
                    <asp:ListItem Value="43">Hayır</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="uyari">
            </div>
        </div>
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                Cap Yapıyormusunuz:</div>
            <div class="col-md-2">
                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" />
            </div>
            <div class="uyari">
            </div>
        </div>
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                Çap Fakülte/Yuksekokul</div>
            <div class="col-md-5">
                <asp:DropDownList ID="ddlCapFak" runat="server" CssClass="col-md-12 btn btn-default dropdown-toggle"
                Enabled="False" OnSelectedIndexChanged="ddlCapFak_SelectedIndexChanged" 
                AutoPostBack="True">
                </asp:DropDownList>
            </div>
            <div class="uyari">
            </div>
        </div>
        <div class="row margin-bottom-5">
            <div class="col-md-3">
                Çap Bölümünüz</div>
            <div class="col-md-5">
                <asp:DropDownList ID="ddlCapBolum" runat="server" CssClass="col-md-12 btn btn-default dropdown-toggle"
                Enabled="False">
                    <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="uyari">
            </div>
        </div>

            <div class="row">
            
                <asp:Button ID="btnGonder" runat="server"  Text="Gönder" CssClass="btn btn-default" OnClick="btnGonder_Click" />
            
                
            
            </div>
            

            <div class="uyari">
            </div>
        
        
    </div>



</asp:Content>

