<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Banka.aspx.cs" Inherits="SKSEkrani_Banka" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    body
        {
            font-size: x-small;
           
        }
        
        
        td{
            border:groove 1px;
            
         
        }
           
        
        
        .auto-style1 {
          
            width:1250px;
        }
        .alan0{
            max-width:13px;
            min-width:13px;
            
        }
        .alan1{
            max-width:50px;
            min-width:50px;
        }
        .alan2{
            max-width:65px;
            min-width:65px;

        }
        .alan3{
            max-width:40px;
            min-width:40px
        }
        .alan4{
            max-width:40px;
            min-width:40px
        }
        .alan5{
           max-width:25px;
           min-width:25px;
        }
        .auto-style2 {
            width: 1500px;
        }
        
        .footerAlan1
        {
            max-width:745px;
            min-width:745px;
         
        }
        
         .alan00{
            max-width:13px;
            min-width:13px;
            
        }
        .birimAdi{
            max-width:150px;
            min-width:150px;
        }
        .alan11{
            max-width:120px;
            min-width:120px;
        }
        .alan22{
            max-width:85px;
            min-width:85px;

        }
        .alan33{
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
             max-width:30px;
             min-width:30px
        }
        .alan6
        {
             max-width:40px;
            min-width:40px
            }
        .alan44{
            max-width:15px;
            min-width:15px
        }
        .alan55{
           max-width:45px;
           min-width:45px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" 
            onitemdatabound="DataList1_ItemDataBound">
            <FooterTemplate>
            
                    
                <table class="auto-style1">
                   
                    
                  




                </table>
            </FooterTemplate>
            <HeaderTemplate>
                <table  class="auto-style1">
                    <tr>
                        <td style="min-width:210px">EVRAKIN ADI / KONUSU </td>
                        <td style="min-width:1060px">KISMİ ZAMANLI ÇALIŞTIRILAN ÖĞRENCİLERİN ÜCRET BORDROSU </td>
                        
                    </tr>
                </table>
                   <table class="auto-style1" >
                    <tr >
                    <td style="max-width:210px;min-width:210px">KURUM / BİRİM</td>
                    <td style="max-width:520px;min-width:520px">SAÜ. SAĞLIK KÜLTÜR ve SPOR DAİRESİ BAŞK.</td>
                    <td style="max-width:210px;min-width:210px">Vergi Dairesi</td>
                    <td style="max-width:270px;min-width:270px">GÜMRÜKÖNÜ VD</td>
                     <td style="text-align:right">AİT OLDUĞU AY /  YIL</td>
                    
                    </tr>
                    <tr >
                    <td>ADRESİ</td>
                    <td>Esentepe Kampüsü / Serdivan / SAKARYA</td>
                    <td >Vergi Numarası</td>
                    <td>7400019721</td>
                   
                    <td style="text-align:right"><asp:Label ID="lblAyYil" runat="server"></asp:Label></td>
                    </tr>
                    </table>
                <table class="auto-style1">
                   
                    <tr>
                        <td class="alan00">S.</td>
                       
                        <td class="alan22">T.C NO</td>
                        <td class="alan11">ADI</td>
                        <td class="alan11">SOYADI</td>
                        
                        <td class="IBANNO">IBANNO</td>
                              
                       <%-- <td class="alan6">Asgari Günlük Brüt Ücret</td>--%>
                      
                        <td class="alan4">Net Ücret</td>
                    </tr>







                </table>
            </HeaderTemplate>
            <ItemTemplate>
                  
                <table class="auto-style1">
                    <tr>
                        <td class="alan00"><%#Eval("sira")%></td>
                       
                        <td class="alan22" size="12" height="22"><%#Eval("TC")%></td>
                        <td class="alan11" size="12" height="22"><%#Eval("adi")%></td>
                        <td class="alan11" size="12" height="22"><%#Eval("soyadi")%></td>
                        
                        <td class="IBANNO" size="12" height="22"><%#Eval("ibanNo")%></td>
                       <%-- <td class="GSS"><%#Eval("GSSKendisi")%></td>--%>
                       
                        <td class="alan4"><%#Eval("netUcret")%></td>
                        
                        
                        
                        
                       
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    
    </div>
    </form>
</body>
</html>
