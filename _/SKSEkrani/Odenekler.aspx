<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="Odenekler.aspx.cs" Inherits="SKSEkrani_Odenekler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
<div class="row margin-bottom-5">


<div class="col-md-3">Asgari Brut Ucret</div>
<div class="col-md-5">
    <asp:TextBox ID="txtAsgariBrut" runat="server" CssClass="form-control" 
        AutoCompleteType="Department" MaxLength="10"></asp:TextBox>
    </div>
 </div>
    <div class="row margin-bottom-5">
<div class="col-md-3">Asgari Net Üçret</div>
<div class="col-md-5">
    <asp:TextBox ID="txtAsgariNet" runat="server" CssClass="form-control"  MaxLength="9"></asp:TextBox>
    </div>



</div>
<div class="row margin-bottom-5">

<div class="col-md-3">Asgari Günlük Üçret</div>
<div class="col-md-5">
    <asp:TextBox ID="txtAsgariGunlukUcret" runat="server" CssClass="form-control" 
        MaxLength="9"></asp:TextBox>
    </div>
</div>

<div class="row margin-bottom-5">

<div class="col-md-3">Damga Vergisi</div>
<div class="col-md-5">
    <asp:TextBox ID="txtDamgaVergisi" runat="server" CssClass="form-control"  MaxLength="9"></asp:TextBox>
    </div>
</div>
<div class="row margin-bottom-5">
<div class="col-md-3">Gelir Vergisi</div>
<div class="col-md-5">
    <asp:TextBox ID="txtGelirVergisi" runat="server" CssClass="form-control"  MaxLength="9"></asp:TextBox>
    </div>
    </div>
    <div class="row margin-bottom-5">
<div class="col-md-3">GSS43 Oranı</div>
<div class="col-md-5">
    <asp:TextBox ID="txtGSS43Orani" runat="server" CssClass="form-control"  MaxLength="9"></asp:TextBox>
    </div>




</div>

<div class="row margin-bottom-5">

<div class="col-md-3">Doktora Birim Fiyatı</div>
<div class="col-md-5">
    <asp:TextBox ID="txtDoktoraBirimFiyati" runat="server" CssClass="form-control"  
        MaxLength="8"></asp:TextBox>
    </div>
    </div>
    <div class="row margin-bottom-5">
<div class="col-md-3">YüksekLisans Birim Fiyatı</div>
<div class="col-md-5">
    <asp:TextBox ID="txtYuksekLisansFiyati" runat="server" CssClass="form-control" 
        MaxLength="8"></asp:TextBox>
    </div>
    </div>
    <div class="row margin-bottom-5">
<div class="col-md-3">Lisans Birim Fiyatı</div>
<div class="col-md-5">
    <asp:TextBox ID="txtLisansBirimFiyati" runat="server" CssClass="form-control" 
        MaxLength="8"></asp:TextBox>
    </div>




</div>

<div class="row margin-bottom-5">

<div class="col-md-3">ÖnLisans Birim Fiyatı</div>
<div class="col-md-5">
    <asp:TextBox ID="txtOnlisansBirimFiyati" runat="server" CssClass="form-control" 
        MaxLength="8"></asp:TextBox>
    </div>
    </div>
    <div class="row margin-bottom-5">
<div class="col-md-3">Azami Günlük Calisma Süresi</div>
<div class="col-md-5">
    <asp:TextBox ID="txtGunlukCalismaSuresi" runat="server" CssClass="form-control"  
        MaxLength="3"></asp:TextBox>
    </div>





</div>
<div class="row col-md-offset-7">


        <asp:Button ID="btnGuncelle" runat="server" Height="37px" Text="Güncelle" CssClass="btn btn-default" 
        OnClick="btnGuncelle_Click"  />


</div>

<div class="conteMin" style="margin-top:20px">




    <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>




</div>


</div>
</asp:Content>

