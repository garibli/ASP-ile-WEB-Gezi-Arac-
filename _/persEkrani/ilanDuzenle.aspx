<%@ Page Title="" Language="C#" MasterPageFile="~/persEkrani/PersMaster.master" AutoEventWireup="true" CodeFile="ilanDuzenle.aspx.cs" Inherits="persEkrani_ilanDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" src="../JScript/jquery-1.9.1.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".style3").click(function () {
            var refreshID = setInterval(function () {
                $("#duzenle").hide();
                return false;
            });
        });
    });

</script>
    <style type="text/css">
        
       
       .auto-style5 {
            max-width: 50px;
            min-width:50px;
        }
        .auto-style7 {
           max-width: 140px;
           min-width:140px;
        }
        .auto-style9 {
            max-width: 100px;
            min-width:100px;

        }
        .auto-style10 {
           max-width: 210px;
           min-width:210px;
        }
        .auto-style11 {
           max-width: 70px;
           min-width:70px;
        }
        .auto-style12 {
           max-width: 70px;
           min-width:70px;
        }
        .style1
        {
            width: 491px;
        }
        .style2
        {
            width: 13px;
        }
        .style3
        {
            width: 594px;
        }
        .style4
        {
            width: 18px;
        }
        .style5
        {
            width: 636px;
        }
        .style6
        {
            width: 56px;
        }
        .style7
        {
            width: 101px;
        }
        .style8
        {
            width: 64px;
        }
        .style9
        {
            width: 129px;
        }
        .style10
        {
            width: 139px;
        }
        .textboxKutu
        {
            margin-top:5px;
            }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="container">
    <asp:DataList ID="DtlistIlan" runat="server" CellPadding="4" CssClass="table"
        ForeColor="#333333" onitemcommand="DtlistIlan_ItemCommand">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle  Font-Bold="True" ForeColor="White" BackColor="#507CD1" />
        <HeaderTemplate>
         
            
            <table class="col-md-12">
                <tr>
                  <td class="col-md-3">İDR/AKADE Birim adı</td>
                        <td class="col-md-2"> Alt Bir./Böl. Adı(varsa)</td>
                        <td class="col-md-3">Çalişma Şekli</td>
                        <td class="col-md-1">Kontenjan</td>
                        <td class="col-md-1">sil</td>
                        <td class="col-md-2">düzenle</td>
                </tr>
            </table>
        </HeaderTemplate>
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            <table class="col-md-12">
                <tr>
                
               
                        <td class="col-md-3"><%#Eval("BirimAdi") %></td>
                        <td class="col-md-2"><%#Eval("altBolum") %></td>
                        <td class="col-md-3"><%#Eval("calismaSekli") %></td>
                        <td class="col-md-1"><%#Eval("kontenjan") %></td>
                        <td class="col-md-1"><asp:LinkButton ID="LinkbtnSil" runat="server" CommandArgument='<%#Eval("silIlan") %>' CommandName="silButon"  Text="SİL" CssClass="btn red"></asp:LinkButton></td>
                        <td class="col-md-2"> <asp:LinkButton ID="LinkBtnDüzenle" runat="server" CommandArgument='<%#Eval("duzenleIlan") %>' CommandName="duzenleButon" Text="DÜZENLE" CssClass="btn green"></asp:LinkButton></td>
                   
                </tr>
            </table>
        </ItemTemplate>
       
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>
  </div>
  <div id="duzenle" runat="server" style="height:1100px">
      <div class="solKutu">Calışma şekli</div>

      <div class="textboxKutu">
          <asp:DropDownList ID="DDlistCalismaSekli" runat="server" Height="21px" 
              Width="200px"> 
              <asp:ListItem Value="1">Öğrenci asistan</asp:ListItem>
              <asp:ListItem Value="2">Gecici insan kaynağı</asp:ListItem>
             
          </asp:DropDownList>
      </div>

      <div class="solKutu">İş Tanımı   </div><div class="textboxKutu">
          <asp:TextBox ID="TxtIsTanimi" runat="server" Width="200px"></asp:TextBox></div>

      <div class="solKutu">İş Niteliği  </div><div class="textboxKutu">
          <asp:TextBox ID="TxtIsNiteligi" runat="server" Height="150px" Width="200px" TextMode="MultiLine"></asp:TextBox></div>

      <div class="solKutu">Birim       </div><div class="textboxKutu">
          <asp:TextBox ID="txtBirim" runat="server" Enabled="false" Width="300px"></asp:TextBox></div>

      <div class="solKutu">Bolum       </div><div class="textboxKutu">
          <asp:DropDownList ID="DDlistBolum" runat="server" Height="20px" Width="300px">
          </asp:DropDownList>
      </div>

      <div class="solKutu">Kontenjan</div><div class="textboxKutu"> 
          <asp:TextBox ID="txtKontenjan" runat="server" Height="20px" Width="200px"></asp:TextBox></div>

      <div class="solKutu">Bitiş Suresi</div><div class="textboxKutu">
          <asp:TextBox ID="txtBitisSuresi" runat="server" Width="200px"></asp:TextBox></div>
      
      
      <div id="takvim">
          <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
              BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
              Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
              onselectionchanged="Calendar1_SelectionChanged" Width="200px">
              <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
              <NextPrevStyle VerticalAlign="Bottom" />
              <OtherMonthDayStyle ForeColor="#808080" />
              <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
              <SelectorStyle BackColor="#CCCCCC" />
              <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
              <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
              <WeekendDayStyle BackColor="#FFFFCC" />
          </asp:Calendar>
      </div>
     
      <div style="margin-top:15px">
          <asp:Button ID="btnUpdate" runat="server" Text="DEĞİŞTİR/KAYDET" 
              onclick="btnUpdate_Click" Width="201px" Height="39px"  /></div>
              <div> 
                  <asp:Label ID="lbl" runat="server" Text="" Visible=false></asp:Label></div>
                  <div style="margin-top:10px"> 
                      <asp:Button ID="iptalbtn" runat="server" Text="İPTAL" onclick="iptalbtn_Click" 
                          Width="200px" Height="40px" /></div>
      </div>

      
</asp:Content>

