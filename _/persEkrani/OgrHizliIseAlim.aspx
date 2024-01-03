<%@ Page Title="" Language="C#" MasterPageFile="~/persEkrani/PersMaster.master" AutoEventWireup="true" CodeFile="OgrHizliIseAlim.aspx.cs" Inherits="persEkrani_OgrHizliIseAlim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<div class="bottomBox">SKS ÖĞRENCİ KAYDI</div>
<hr />
    <asp:Label ID="lblKalanKontenjan" runat="server" Text=""></asp:Label>
<div class="row">
  <div class="form-group">
    <label for="inputPassword3" class="col-sm-2 control-label">NUMARASI</label>
    <div class="col-sm-7">
    <div class="input-group">
        <asp:TextBox ID="TxtNumara" runat="server" class="form-control" placeholder="Numara"></asp:TextBox>
      <span class="input-group-btn">
          <asp:Button ID="btnNumara" runat="server" Text="ÖGRENCİNİN BİLGİLERİNİ GETİR" 
            class="btn btn-default btn-primary" onclick="btnNumara_Click" />
            <asp:Button ID="btnHata" runat="server" Text="!" 
            class="btn btn-default btn-danger" 
            tittle="Numara Sistemde Kayıtlı Değildir. Lütfen Dikkatli Girin!!" 
            onclick="btnHata_Click" />
            <asp:Button ID="btnDogru" class="btn btn-default btn-success" runat="server"/>
      </span>
    </div>
  </div>
  
  </div>
  </div>
<div class="row">
  <div class="form-group">
    <label for="inputPassword3" class="col-sm-2 control-label">BİRİM</label>
    <div class="col-sm-7">
        <asp:DropDownList ID="ddlOkuduguBirim" runat="server" Height="35px" 
            style="border-radius:5px" Width="100%"  AutoPostBack="true" 
            onselectedindexchanged="ddlOkuduguBirim_SelectedIndexChanged">     
        <asp:ListItem>OKUDUĞU BİRİMİ SEÇİNİZ</asp:ListItem>
        </asp:DropDownList>
    </div>
  </div>
   </div>  
<div class="row">
  <div class="form-group">
    <label for="inputPassword3" class="col-sm-2 control-label">OKUL</label>
    <div class="col-sm-7">
        <asp:DropDownList ID="ddlOkuduguBolum" runat="server" Height="35px" 
            style="border-radius:5px"  Width="100%" >     
        <asp:ListItem Value="0">OKUDUĞU BÖLÜMÜ SEÇİNİZ</asp:ListItem>
        </asp:DropDownList>
    </div>
  </div>
   </div>  
<div class="row">
<div class="form-group">
    <label for="inputEmail3" class="col-md-2 control-label">ADI</label>
    <div class="col-md-7">
        <asp:TextBox ID="txtAD" runat="server" class="form-control" placeholder="Adı"></asp:TextBox>
    </div>
  </div>
  </div>

<div class="row">
  <div class="form-group">
    
    <label for="inputPassword3" class="col-sm-2 control-label">SOYADI</label>
    <div class="col-sm-7">
        <asp:TextBox ID="txtSoyad" runat="server" class="form-control" placeholder="Soyadı"></asp:TextBox>
    </div>
  </div>
  </div>
<div class="row">
  <div class="form-group">
    <label for="inputPassword3" class="col-sm-2 control-label">E-MAİL</label>
    <div class="col-sm-7">
        <asp:TextBox ID="txtMail" runat="server" class="form-control" placeholder="Okul Mail Adresi"></asp:TextBox>
    
    </div>
  </div>
   </div>  
<hr />
<div class="row">
  <div class="form-group">
    <label for="inputPassword3" class="col-sm-3 control-label">ÇALIŞACAĞI BİRİM</label>
    <div class="col-sm-7">
        <asp:DropDownList ID="ddlCalisacagiBirim" runat="server" Height="35px" 
            style="border-radius:5px" Width="510px"  AutoPostBack="true">     
        <asp:ListItem>ÇALIŞACAĞI BİRİMİ SEÇİNİZ</asp:ListItem>
        </asp:DropDownList>
    </div>
  </div>
   </div>  
<div class="row">
  <div class="form-group">
    <label for="inputPassword3" class="col-sm-3 control-label">ÇALIŞACCAĞI BÖLÜM</label>
    <div class="col-sm-7">
        <asp:DropDownList ID="ddlCalisacagiBolum" runat="server" Height="35px" style="border-radius:5px" Width="510px">     
        <asp:ListItem>ÇALIŞACAĞI BÖLÜMÜ SEÇİNİZ</asp:ListItem>
        </asp:DropDownList>
    </div>
  </div>
   </div>  
<div class="row">
  <div class="form-group">
    <label for="inputPassword3" class="col-sm-3 control-label">ÇALIŞMA ŞEKLİ</label>
    <div class="col-sm-7">
        <asp:DropDownList ID="ddlCalismaSekli" runat="server" Height="35px" style="border-radius:5px" Width="510px">     
        <asp:ListItem Value="0">ÇALIŞMA ŞEKLİNİ SEÇİNİZ</asp:ListItem>
        <asp:ListItem Value="1">Öğrenci Asistan</asp:ListItem>
        <asp:ListItem Value="2">Gecici İnsan Kaynağı</asp:ListItem>
        </asp:DropDownList>
    </div>
  </div>
   </div>  
<div class="row">
        <div class="col-lg-4">
                <div class="get-started">
                      <asp:Button ID="btnIseAlim" runat="server" Text="İŞE AL"  
                          class="btn btn-large btn-primary" Width="150px" Height="50px" 
                          onclick="btnIseAlim_Click" />
                </div>
        </div>
        <div class="col-lg-8">
                <asp:Label ID="lblIseAL" runat="server" Text="" Enabled="false"></asp:Label>
        </div>
</div>

<br />
<hr />
</asp:Content> 

