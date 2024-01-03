<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PuantajCikti.aspx.cs" Inherits="SKSEkrani_PuantajCikti" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-size: x-small
        }
        
        
        
        .auto-style1 {
          
            width:1540px;
        }
        td{
            border:groove 1px;
            
        }
        .auto-style2 {
            width: 1540px;
        }
        .auto-style4 {
            width: 440px;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            width: 440px;
            text-align: center;
        }
        .auto-style7 {
            text-align: right;
        }
        .auto-style8 {
            width: 440px;
            text-align: right;
        }
        .conteA4{
            width:595px;
            height:842px;
        }
        .alan0{
            max-width:13px;
            min-width:13px;
            
        }
        .alan1{
            max-width:70px;
            min-width:70px;
        }
        .alan2{
            max-width:85px;
            min-width:85px;

        }
        .alan3{
            max-width:60px;
            min-width:60px
        }
        .ogrTuru
        {
             max-width:40px;
            min-width:40px
        }
        
        
        .GSS
        {
             max-width:25px;
            min-width:25px
        }
        .alan4{
            max-width:15px;
            min-width:15px;
            text-align:center;
        }
        .alan5{
           max-width:45px;
           min-width:45px;
           text-align:center;
        }
        .footerAlan1
        {
            max-width:745px;
            min-width:745px;
         
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound">
            <FooterTemplate>
                <table class="auto-style2">
                     <tr>
                        <td class="footerAlan1" style="text-align: center;">Toplam Çalışan : 
                            <asp:Label ID="lblTopCalisan" runat="server" Text=""></asp:Label></td>
                        <td class="footerAlan1" style="text-align: center;">Toplam Saat : 
                            <asp:Label ID="lblTopSaat" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="footerAlan1" style="text-align: center;">&nbsp;</td>
                        <td class="footerAlan1" style="text-align: right;">SKS.MH.FR.02</td>
                    </tr>
                    <tr>
                        <td class="footerAlan1" style="text-align: center;">HAZIRLAYAN</td>
                        <td class="footerAlan1" style="text-align: center;">ONAYLAYAN&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="footerAlan1">ADI SOYADI :&nbsp; </td>
                        <td class="footerAlan1">ADI SOYADI :</td>
                    </tr>
                    <tr>
                        <td class="footerAlan1">ÜNVANI :</td>
                        <td class="footerAlan1">ÜNVANI :</td>
                    </tr>
                    <tr>
                        <td style="border-bottom:none" class="footerAlan1">İMZASI :</td>
                        <td style="border-bottom:none" class="footerAlan1">İMZASI :</td>
                    </tr>
                    <tr>
                        <td style="border-top:none;border-bottom:none" class="footerAlan1">&nbsp;</td>
                        <td style="border-top:none;border-bottom:none" class="footerAlan1">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="border-top:none;" class="footerAlan1" >&nbsp;</td>
                        <td style="border-top:none;" class="footerAlan1">&nbsp;</td>
                    </tr>
                </table>
            </FooterTemplate>
            <HeaderTemplate>
                <table class="auto-style1">
                    <tr>
                        <td>SAKARYA ÜNİVERSİTESİNDE KISMİ ZAMANLI STATÜDE ÇALIŞAN ÜNİVERSİTE ÖĞRENCİLERİNE AİT ÇALIŞMA ÇİZELGESİ </td>
                        <td><strong>Ay :</strong></td>
                        <td>
                            <asp:Label ID="lblAy" runat="server" Text="" Font-Bold="True"></asp:Label>
                        </td>
                        <td style="font-weight: 700">Yıl :</td>
                        <td>
                            <asp:Label ID="lblYil" runat="server" Text="" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    </table>
                <table class="auto-style1" >
                    <tr>
                        <td class="alan0">S.</td>
                        <td class="alan1" style="max-width:200px;min-width:200px;" >OKUL ADI</td>
                       <%-- <td class="alan1" style="max-width:100px;min-width:100px;">BİRİM ADI (VARSA)</td>--%>
                        <td class="alan2">T.C NO</td>
                        <td class="alan1" style="max-width: 150px;min-width:150px; font-size: small;">ADI</td>
                        <td class="alan1" style="max-width:150px;min-width:150px; font-size:  small;">SOYADI</td>
                        <td class="ogrTuru">Öğrenim Türü</td>
                        <td class="alan3">SGK Giriş Tarihi</td>
                        <td class="alan3">SGK Çıkış Tarihi</td>
                       <%-- <td class="GSS">GSS (Aileden)</td>--%>
                        <td class="GSS">GSS</td>
                        <td class="alan4">1</td>
                        <td class="alan4">2</td>
                        <td class="alan4">3</td>
                        <td class="alan4">4</td>
                        <td class="alan4">5</td>
                        <td class="alan4">6</td>
                        <td class="alan4">7</td>
                        <td class="alan4">8</td>
                        <td class="alan4">9</td>
                        <td class="alan4">10</td>
                        <td class="alan4">11</td>
                        <td class="alan4">12</td>
                        <td class="alan4">13</td>
                        <td class="alan4">14</td>
                        <td class="alan4">15</td>
                        <td class="alan4">16</td>
                        <td class="alan4">17</td>
                        <td class="alan4">18</td>
                        <td class="alan4">19</td>
                        <td class="alan4">20</td>
                        <td class="alan4">21</td>
                        <td class="alan4">22</td>
                        <td class="alan4">23</td>
                        <td class="alan4">24</td>
                        <td class="alan4">25</td>
                        <td class="alan4">26</td>
                        <td class="alan4">27</td>
                        <td class="alan4">28</td>
                        <td class="alan4">29</td>
                        <td class="alan4">30</td>
                        <td class="alan4">31</td>
                        <td class="alan5" style="max-width: 20px;min-width:20px;">Top. Saat</td>
                        <td class="alan5" style="max-width: 20px;min-width:20px;">Öğr. İmza</td>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                  
                <table class="auto-style1">
                    <tr>
                        <td class="alan0"><%#Eval("sira")%></td>
                        <td class="alan1" style="max-width:200px;min-width:200px;font-size: smaller;"><%#Eval("birimAdi")%></td>
                        <%--<td class="alan1" style="max-width:100px;min-width:100px;"><%#Eval("okulAdi")%></td>--%>
                        <td class="alan2"><%#Eval("TC")%></td>
                        <td class="alan1" style="max-width:200px;min-width:150px; font-size: small;"><%#Eval("adi")%></td>
                        <td class="alan1" style="max-width:200px;min-width:150px; font-size: small;"><%#Eval("soyadi")%></td>
                        <td class="ogrTuru"><%#Eval("ogrenimTuru")%></td>
                        <td class="alan3"><%#Eval("sgkGiris")%></td>
                        <td class="alan3"><%#Eval("sgkCikis")%></td>
                      <%--  <td class="GSS"><%#Eval("GSSaile")%></td>--%>
                        <td class="GSS"><%#Eval("GSSKendisi")%></td>
                        <td class="alan4"><%#Eval("1")%></td>
                        <td class="alan4"><%#Eval("2")%></td>
                        <td class="alan4"><%#Eval("3")%></td>
                        <td class="alan4"><%#Eval("4")%></td>
                        <td class="alan4"><%#Eval("5")%></td>
                        <td class="alan4"><%#Eval("6")%></td>
                        <td class="alan4"><%#Eval("7")%></td>
                        <td class="alan4"><%#Eval("8")%></td>
                        <td class="alan4"><%#Eval("9")%></td>
                        <td class="alan4"><%#Eval("10")%></td>
                        <td class="alan4"><%#Eval("11")%></td>
                        <td class="alan4"><%#Eval("12")%></td>
                        <td class="alan4"><%#Eval("13")%></td>
                        <td class="alan4"><%#Eval("14")%></td>
                        <td class="alan4"><%#Eval("15")%></td>
                        <td class="alan4"><%#Eval("16")%></td>
                        <td class="alan4"><%#Eval("17")%></td>
                        <td class="alan4"><%#Eval("18")%></td>
                        <td class="alan4"><%#Eval("19")%></td>
                        <td class="alan4"><%#Eval("20")%></td>
                        <td class="alan4"><%#Eval("21")%></td>
                        <td class="alan4"><%#Eval("22")%></td>
                        <td class="alan4"><%#Eval("23")%></td>
                        <td class="alan4"><%#Eval("24")%></td>
                        <td class="alan4"><%#Eval("25")%></td>
                        <td class="alan4"><%#Eval("26")%></td>
                        <td class="alan4"><%#Eval("27")%></td>
                        <td class="alan4"><%#Eval("28")%></td>
                        <td class="alan4"><%#Eval("29")%></td>
                        <td class="alan4"><%#Eval("30")%></td>
                        <td class="alan4"><%#Eval("31")%></td>
                        <td class="alan5" style="max-width: 20px;min-width:20px;"><%#Eval("toplamSaat")%></td>
                        <td class="alan5" style="max-width: 20px;min-width:20px;" ></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    
    </div>
    </form>
</body>
</html>
