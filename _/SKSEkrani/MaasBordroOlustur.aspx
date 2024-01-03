<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="MaasBordroOlustur.aspx.cs" Inherits="SKSEkrani_MaasBordroOlustur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../CSS/alanlar2.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        
        td
        {
            max-width:75px;
            min-width:75px;
            font-size:smaller;
        }
        .style3
        {
            height: 20px;
            width: 772px;
            margin-top: 5px;
            color: #000066;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="container row col-md-12">
    <div class="col-md-1">
           Ay 
    </div>
    <div class="col-md-3">
            <asp:DropDownList ID="ddlAy" runat="server" CssClass="btn btn-default dropdown dropdown-toogle col-md-11">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>11</asp:ListItem>
                <asp:ListItem>12</asp:ListItem>
            </asp:DropDownList>
    
    </div>
     <div class="col-md-1">
          Yıl
    </div>
    <div class="col-md-3">
 
            <asp:DropDownList ID="ddlYil" runat="server" CssClass="btn btn-default dropdown dropdown-toogle col-md-11">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
            </asp:DropDownList>
    </div>
    </div>

  
  

<div class="container row col-md-12 margin-top-20">
    
   <div class="col-md-2">
        <asp:Button ID="btnOlustur" runat="server" Text="Oluştur" CssClass="btn btn-default col-md-12" Font-Bold="True" OnClick="btnOlustur_Click"  />
    </div>
    <div class="col-md-2">
        <asp:Button ID="btnXML" runat="server" Text="XML Oluştur" 
            CssClass="btn btn-default col-md-12"
            OnClick="btnXML_Click"  />
    </div>
    
    <div class="col-md-3">
        <asp:Button ID="btnXML0" runat="server" CssClass="btn btn-default col-md-12" Text="Oluşan XML Dosyaları" 
            OnClick="btnXML0_Click"  />
    
    </div>
    
    <div class="col-md-2">
        <asp:Button ID="btnSil" runat="server" CssClass="btn btn-default col-md-12" Text="İlgili Ayı Sil" 
            
            OnClick="btnSil_Click"  />
    </div>

    </div>
    <div class="container row col-md-12 margin-top-20">
    
        <strong >Bordro oluşturma/güncelleme işlemi bir kaç dakika sürebilir.
    </strong>
    
    
    
    </div>
    <div class="container row margin-top-20 col-md-12">
        <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    
    
    
    </div>
    <div class="container" >   
     <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333" 
            Width="1300px" CssClass="table table-hover" onitemcommand="DataList1_ItemCommand">
            <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderTemplate>
                <table class="style2">
                    <tr>
                    <td>
                            ID</td>
                        <td>
                            Toplam Çalışılan Saat</td>
                        <td>
                            Toplam Aylık Brüt Ücret</td>
                        <td>
                            Toplam SGK Prim Hesabına Göre</td>
                        <td>
                            Toplam SGK %5 Kesinti</td>
                        <td>
                            Toplam Ücret Gelir Vergisi Esas</td>
                        <td>
                            Toplam Gelir Vergisi Kesintisi</td>
                        <td>
                            Toplam Damga Vergisi Kesintisi</td>
                        <td>
                            Toplam Yasal Kesinti</td>
                        <td>
                            Toplam AGİ</td>
                        <td>
                            Toplam Net Ucret</td>
                        <td>
                            Toplam Çalışan Sayısı</td>
                        <td>
                            İligili Tarih</td>
                        <td>
                            Oluşturma Tarihi</td>
                        <td>
                            Oluşturan Personel</td>
                            <td>
                            Görüntüle</td>
                            <td>
                            Güncelle</td>
                            <td>
                            Sil</td>
                            <td>
                            Banka</td>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemStyle CssClass="table table-hover" BackColor="#F7F6F3" ForeColor="#333333" />
            <ItemTemplate >
                <table class="style2" >
                    <tr>
                        <td>
                            <%#Eval("id") %></td>
                        <td>
                            <%#Eval("topCalisanSaat")%></td>
                        <td>
                           <%#Eval("topAylikBrutUcret")%></td>
                        <td>
                            <%#Eval("topUcretSGKPrimHesabinaEsas")%></td>
                        <td>
                            <%#Eval("topSGKPrimIsciYuzde5")%></td>
                        <td>
                            <%#Eval("topUcretGelirVergisiEsas")%></td>
                        <td>
                            <%#Eval("topGelirVergisiKes")%></td>
                        <td>
                            <%#Eval("topDamgaVergisiKes")%></td>
                        <td>
                            <%#Eval("topYasalKesinti")%></td>
                        <td>
                            <%#Eval("topGelirVergisiKes")%></td>
                        <td>
                            <%#Eval("topNetUcret")%></td>
                        <td>
                            <%#Eval("topCalisanSay")%></td>
                        <td>
                            <%#Eval("ilgiliAy")%></td>
                        <td>
                            <%#Eval("olusturmaTarihi")%></td>
                        <td>
                            <%#Eval("persAdSoyad")%></td>
                             <td>
                             <asp:LinkButton ID="LinkButton1"  CommandArgument='<%#Eval("ilgiliAy") %>' CommandName="_listele" runat="server" >
                        <img  src="../img/ilanListele.png" style="height:20px;width:20px" /></asp:LinkButton>
                             </td>

                             <td>
                            <asp:LinkButton ID="LinkButton2"  CommandArgument='<%#Eval("ilgiliAy") %>' CommandName="_guncelle" runat="server" >
                        <img  src="../img/update.png" style="height:20px;width:20px" /></asp:LinkButton>
                            </td>

                             <td>
                            <asp:LinkButton ID="LinkButton3"  CommandArgument='<%#Eval("ilgiliAy") %>' CommandName="_sil" runat="server" >
                        <img  src="../img/delete.png" style="height:20px;width:20px" /></asp:LinkButton>
                            </td>
                            <td>
                             <asp:LinkButton ID="LinkButton4"  CommandArgument='<%#Eval("ilgiliAy") %>' CommandName="_banka" runat="server" >
                        <img  src="../img/ilanListele.png" style="height:20px;width:20px" /></asp:LinkButton>
                             </td>
                    </tr>
                </table>
            </ItemTemplate>
            <SelectedItemStyle CssClass="table table-hover" BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:DataList>
    
    
    
        
    
    </div>
</asp:Content>

