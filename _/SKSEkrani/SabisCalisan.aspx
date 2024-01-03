<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SabisCalisan.aspx.cs" Inherits="SKSEkrani_SabisCalisan" %>

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
                        
                    </tr>
                
                </table>
            </FooterTemplate>
            <HeaderTemplate>
                <table class="auto-style1">
                    <tr>
                        <td>SAKARYA ÜNİVERSİTESİNDE KISMİ ZAMANLI STATÜDE ÇALIŞAN ÜNİVERSİTE ÖĞRENCİLERİNE AİT SABİS VERİLERİ </td>
                        
                    </tr>
                    </table>
                <table class="auto-style1" >
                    <tr>
                        <td class="alan0">S.</td>
                        <td class="alan1" style="max-width:200px;min-width:200px;" >ÇALIŞTIĞI BİRİM</td>
                       <%-- <td class="alan1" style="max-width:100px;min-width:100px;">BİRİM ADI (VARSA)</td>--%>
                        <td class="alan2">T.C NO</td>
                        <td class="alan1" style="max-width: 150px;min-width:150px; font-size: small;">ADI SOYADI</td>
                        
                       
                        <td class="alan3">SGK Giriş Tarihi</td>
                        
                       <%-- <td class="GSS">GSS (Aileden)</td>--%>
                        
                        <td class="alan4">NOTU</td>
                        
                        <td class="alan5" style="max-width: 150px;min-width:150px;">OKULU</td>
                        <td class="alan5" style="max-width: 150px;min-width:150px;">PROGRAMI</td>
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
                        
                        
                        <td class="alan3"><%#Eval("sgkGiris")%></td>
                        
                    
                        <td class="alan4"><%#Eval("NOTU")%></td>
                        
                        <td class="alan5" style="max-width: 150px;min-width:150px;"><%#Eval("OKULU")%></td>
                        <td class="alan5" style="max-width: 150px;min-width:150px;" <%#Eval("PROGRAMI")%>/td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    
    </div>
    </form>
</body>
</html>
