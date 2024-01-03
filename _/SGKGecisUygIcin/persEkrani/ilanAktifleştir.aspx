<%@ Page Title="" Language="C#" MasterPageFile="~/persEkrani/PersMaster.master" AutoEventWireup="true" CodeFile="ilanAktifleştir.aspx.cs" Inherits="persEkrani_ilanAktifleştir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script src="../JScript/jquery-1.9.1.js" >
        
     </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#islemId").click(function () {

            })
        })
    </script>
    <style type="text/css">
       
        .auto-style4 {
           max-width: 90px;
           min-width: 90px;
        }
        .auto-style5 {
            max-width: 250px;
            min-width: 250px;
            
                   }
        .auto-style6 {
            max-width: 250px;
            min-width: 250px;
        }
        .auto-style7 {
            max-width: 200px;
            min-width: 200px;
        }

    </style>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width:1000px;float:left;margin-top:5px" id="ustConte" runat="server">
       
    <asp:DataList ID="dlGecmisListe" runat="server" CellPadding="3"  Width="900px" OnItemCommand="dlGecmisListe_ItemCommand">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle  Font-Bold="True" ForeColor="Black" />
        <HeaderTemplate>
        <div class="panel-heading" style="font-size:20px">İLANLAR ARŞİVİ</div>
            <div class="panel panel-info">
            <table  cellspacing="7px" class="table" style=" width: 900px;">
                <tr>
                    <td class="auto-style4">İlanNo</td>
                    <td class="auto-style5">İş Başlığı</td>
                    <td class="auto-style6">İş Tanımı</td>
                    <td class="auto-style7">Bitiş Tarihi</td>
                    <td>Aktifleştir</td>
                </tr>
            </table></div>
        </HeaderTemplate>
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            <table  cellspacing="7px" class="table" style=" width: 900px;">
                <tr>
                    <td class="auto-style4"><%#Eval("id") %></td>
                    <td class="auto-style5"><%#Eval("isBasligi") %></td>
                    <td class="auto-style6"><%#Eval("isTanimi") %></td>
                    <td class="auto-style7"><%#Eval("bitisSuresi") %></td>
                    <td><asp:LinkButton  CommandArgument='<%#Eval("id") %>' CommandName="aktiflestir" runat="server" >
                        <img  src="../img/aktif.png" style="height:20px;width:20px" /></asp:LinkButton></td>
                </tr>
            </table>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>
        </div>

        <div id="aktifleştirmeDiv" runat="server">      
            
        <div id="txtAktifleştirmeGun"><asp:TextBox ID="txtTarihGonder" runat="server"></asp:TextBox></div>
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                Width="200px" onselectionchanged="Calendar1_SelectionChanged">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
            <asp:Label ID="lblID" runat="server" Text="Label" Visible="false"></asp:Label>
            <div style="margin-top:20px"><asp:Button ID="BtnAktif" runat="server" 
                    Text="AKTİFLEŞTİR" onclick="BtnAktif_Click" />
            </div>
            <div style="margin-top:20px">
                <asp:Button ID="Button1" runat="server" Text="IPTAL" onclick="Button1_Click" 
                    Width="119px" /> </div>
        </div>
</asp:Content>

