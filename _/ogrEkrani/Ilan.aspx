<%@ Page Title="" Language="C#" MasterPageFile="~/ogrEkrani/OgrMaster.master" AutoEventWireup="true" CodeFile="Ilan.aspx.cs" Inherits="ogrEkrani_Ilan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 10px;
        }
        td
        {
            max-width:150px;
            min-width:150px;
        }
        .style2
        {
            color: #CC0000;
        }
        .style3
        {}
        .style4
        {
            text-decoration: underline;
        }
    </style>
    <script src="../JScript/jquery-1.9.1.js"></script>
    <link href="../CSS/alanlar2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {


        });
    </script>


    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="conte">

   <div class="conteMin"> <h3>Seçilen Aşağıdan Seçeceğiniz İlanlar Buraya 
       Listelenecektir. Kontrol edip devam butonuna .</h3></div>
        <div class="conteMin">
 <asp:Label ID="lblBaslik" runat="server" Font-Bold="True" ForeColor="#000066"></asp:Label>

</div>
<div class="conteMin">

    <asp:Label ID="lbl1" runat="server" Font-Bold="False"></asp:Label>

</div>
<div class="conteMin">

    <asp:Label ID="lbl2" runat="server" Font-Bold="False"></asp:Label>

</div>
<div class="conteMin">

    <asp:Label ID="lbl3" runat="server" Font-Bold="False"></asp:Label>

</div>
<div class="conteMin">
            
            <asp:Button ID="btnGonder" runat="server" Height="20px" Text="Devam" 
        Width="127px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
        ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
        OnClick="btnGonder_Click" />
            
</div>
<div class="conteMin">
    <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
</div>

</div>


    <div style="width:1000px;float:left">
        <h3>İlanlar</h3></div>
    <div style="width:1000px;float:left;margin-top:5px"><h1 class="style2">
        <span class="style3"><span class="style4">ÖĞRENCİSİ OLDUĞUNUZ OKULDA</span>
        </span>başvuru yapabileceğiniz ilanlar.*(Geçici İnsan Kaynağı)</h1></div>
    <div style="width:1000px;float:left">
        <br />
        <asp:DataList ID="DataListFak" runat="server" CellPadding="4" 
            ForeColor="#333333" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" 
            Width="900px" onitemcommand="DataListFak_ItemCommand">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderTemplate>
                
                <table class="auto-style2">
                    <tr>
                        
                        <td>Seçim</td>
                        <td>Birim Adı</td>
                        <td>İş Başlığı</td>
                        <td>İş Tanımı</td>
                        <td>İş Metni</td>
                        <td>Kontenjan</td>
                    </tr>
                </table>
                
            </HeaderTemplate>
           
            <ItemStyle BackColor="#EFF3FB" />
           
            <ItemTemplate>
                  <table class="auto-style2">
                    <tr>
                        
                        <td>
                            <asp:LinkButton CommandArgument='<%#Eval("id") %>' CommandName="Ekle" runat="server" Text="">
                                 <img src="../img/aktif.png" style="width:25px; height:25px" />
                            </asp:LinkButton></td>
                        <td><%#Eval("isBasligi") %></td>
                        <td><%#Eval("bolumAdi") %></td>
                        <td><%#Eval("isMetni") %></td>
                        <td><%#Eval("kontenjan") %></td>
                        <td><%#Eval("isTanimi") %></td>
                    </tr>
                </table>
            </ItemTemplate>
           
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
           
        </asp:DataList>
    </div>
     <div style="width:1000px;float:left;margin-top:5px"><h1 class="style2">
         <span class="style4">İDARİ BİRİMLERDE</span>&nbsp; başvuru 
         yapabileceğiniz ilanlar.*(Geçici İnsan Kaynağı)</h1></div>
     <div style="width:1000px;float:left">
    </div>
     <div style="width:1000px;float:left;margin-top:10px;">
        <asp:DataList ID="DataListIdari" runat="server" CellPadding="4" 
             ForeColor="#333333" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" 
             OnItemCommand="DataListIdari_ItemCommand" Width="900px">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <FooterTemplate>
                Diğer İdari İlanlar
            </FooterTemplate>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderTemplate>
                
                <table class="auto-style2">
                    <tr>
                       
                        <td>Seçim</td>
                        <td>Birim Adı</td>
                        <td>İş Başlığı</td>
                        <td>İş Tanımı</td>
                        <td>İş Metni</td>
                        <td>Kontenjan</td>
                    </tr>
                </table>
                
            </HeaderTemplate>
           
            <ItemStyle BackColor="#EFF3FB" />
           
            <ItemTemplate>
                  <table class="auto-style2">
                    <tr>
                        <td>
                            <asp:LinkButton CommandArgument='<%#Eval("id") %>' CommandName="Ekle" runat="server" Text="">
                                 <img src="../img/aktif.png" style="width:25px; height:25px" />
                            </asp:LinkButton></td>
                        <td><%#Eval("bolumAdi")%></td>
                        <td><%#Eval("isBasligi")%></td>
                        <td><%#Eval("isTanimi")%></td>
                        <td><%#Eval("isMetni")%></td>
                        <td><%#Eval("kontenjan")%></td>
                    </tr>
                </table>
            </ItemTemplate>
           
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
           
        </asp:DataList>
         <br /><h1 class="style2">
             <span class="style4">AKADEMİK BİRİMLERDE</span> başvurabileceğiniz 
             ilanlar.*(Öğrenci Asistan)</h1>
         <asp:DataList ID="DataListAsisOgr" runat="server" CellPadding="4" 
             ForeColor="#333333" 
             OnSelectedIndexChanged="DataList1_SelectedIndexChanged" Width="900px" 
             onitemcommand="DataListDigerIdari_ItemCommand">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <FooterTemplate>
                Diğer İdari İlanlar
            </FooterTemplate>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderTemplate>
                
                <table class="auto-style2">
                    <tr>
                       
                        <td>Seçim</td>
                        <td>Birim Adı</td>
                        <td>İş Başlığı</td>
                        <td>İş Tanımı</td>
                        <td>İş Metni</td>
                        <td>Kontenjan</td>
                    </tr>
                </table>
                
            </HeaderTemplate>
           
            <ItemStyle BackColor="#EFF3FB" />
           
            <ItemTemplate>
                  <table class="auto-style2">
                    <tr>
                        <td>
                            <asp:LinkButton CommandArgument='<%#Eval("id") %>' CommandName="Ekle" runat="server" Text="">
                                 <img src="../img/aktif.png" style="width:25px; height:25px" />
                            </asp:LinkButton></td>
                        <td><%#Eval("bolumAdi")%></td>
                        <td><%#Eval("isBasligi")%></td>
                        <td><%#Eval("isTanimi")%></td>
                        <td><%#Eval("isMetni")%></td>
                        <td><%#Eval("kontenjan")%></td>
                    </tr>
                </table>
            </ItemTemplate>
           
            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
           
        </asp:DataList>
    </div>
    <div style="width:1000px;float:left;margin-top:10px">*&nbsp;&nbsp; Üç gruptanda birer tane 
        olmak üzere en fazla üç adet ilana başvurabilirsiniz.</div>
    <div style="width:1000px;float:left"> </div>
    <div style="width:1000px;float:left;margin-top:10px;margin-left:90px">
            
    </div>
</asp:Content>

