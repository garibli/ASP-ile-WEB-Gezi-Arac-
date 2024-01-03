<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="OgrListele.aspx.cs" Inherits="SKSEkrani_OgrListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/alanlar2.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
    <div class="row">
        <div class="col-md-2" style="font-size:medium;margin-top:6px;">Birim Seçin</div>
         <asp:DropDownList ID="ddlBirimler" runat="server" Width="200px"  CssClass="btn btn-default dropdown-toggle col-md-4"
                AutoPostBack="True" onselectedindexchanged="ddlBirimler_SelectedIndexChanged">
        </asp:DropDownList>
    
   
        <div class="col-md-2" style="font-size:medium;margin-top:6px;text-align:right">Aktif Calışıyor mu?</div>
          <asp:DropDownList ID="ddlAktifCalisanMi" runat="server" Width="200px" 
                AutoPostBack="True" CssClass="btn btn-default dropdown-toggle col-md-4"
                onselectedindexchanged="ddlAktifCalisanMi_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="1">EVET</asp:ListItem>
                <asp:ListItem Value="2">HAYIR</asp:ListItem>
            </asp:DropDownList>
    
    </div></div>


    <div class="container row margin-top-20">
    <div class="col-md-12">
     <asp:RadioButton ID="RBOkuduguOkul" runat="server" AutoPostBack="True" 
            GroupName="grp1" Text="Okuduğu Okula Göre Listele" />
    </div></div>

    <div class="container row">
    <div class="col-md-12">
        <asp:RadioButton ID="RBCalistigiBirim" runat="server" AutoPostBack="True" 
            Checked="True" GroupName="grp1" Text="Çalıştığı Birime Göre Listele" />
    </div></div>

    
        <asp:DataList ID="DtListOgrenci" runat="server" >
            <HeaderTemplate>
                <table style="font-size:10px;width:1600px"  class="list-group-item active col-md-12" >
                    <tr>
                        <td style="width:80px">
                            Tc</td>
                        <td style="width:80px">
                            OgrNo</td>
                        <td style="width:80px">
                            Ad</td>
                        <td style="width:80px">
                            Soyad</td>
                        <td style="width:200px">
                            IbanNo</td>
                        <td style="width:50px">
                            GSS</td>
                        <td style="width:100px">
                            ÇalışBirimAdi</td>
                        <td style="width:100px">
                            SGKGiriş</td>
                        <td style="width:100px">
                            SGKÇıkış</td>
                        <td style="width:100px">
                            ÖğrenimTürü</td>
                        <td style="width:100px">
                            CepTel</td>
                        <td style="width:100px">
                            Mail</td>
                        <td style="width:80px;text-align:center">
                            Aktifmi?</td>
                        <td style="width:100px">
                            Birim</td>
                        <td style="width:100px">
                            Bölüm</td>
                        <td style="width:50px">
                            Sınıf</td>
                        <td style="width:50px">
                            Sifre</td>
                        <td style="width:50px">
                            Not Ort</td>
                    </tr>
                </table>
            </HeaderTemplate>
        
            <ItemTemplate>
                <table style="font-size:10px;width:1600px" class=" list-group-item">
                    <tr>
                        <td style="width:80px">
                            <%#Eval("tc")%></td>
                        <td style="width:80px">
                            <%#Eval("ogrNo")%></td>
                        <td style="width:80px">
                            <%#Eval("ad")%></td>
                        <td style="width:80px">
                            <%#Eval("soyad")%></td>
                        <td style="width:200px">
                            <%#Eval("ibanNo")%></td>
                        <td style="width:50px">
                            <%#Eval("GSS")%></td>
                        <td style="width:100px">
                            <%#Eval("CalistigiBirimAdi")%></td>
                        <td style="width:100px">
                            <%#Eval("SGKGiris")%></td>
                        <td style="width:100px">
                            <%#Eval("SGKCikis")%></td>
                        <td style="width:100px">
                            <%#Eval("ogrenimTuru")%></td>
                        <td style="width:100px">
                             <%#Eval("ceptel")%></td>
                        <td style="width:100px">
                             <%#Eval("mail")%></td>
                        <td style="width:80px;text-align:center">
                            <%#Eval("aktifMi")%></td>
                        <td style="width:100px">
                             <%#Eval("okuduguOkul")%></td>
                        <td style="width:100px">
                             <%#Eval("okuduguBolum")%></td>
                        <td style="width:50px">
                             <%#Eval("Sinifi")%></td>
                        <td style="width:50px">
                             <%#Eval("sifre")%></td>
                        <td style="width:50px">
                             <%#Eval("notOrtalamasi")%></td>
                    </tr>
                </table>
            </ItemTemplate>
        
        </asp:DataList>
   

</asp:Content>

