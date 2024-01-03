<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="AltBolumEkle.aspx.cs" Inherits="SKSEkrani_AltBolumEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Alan1.css" rel="stylesheet" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div class="container">
   <div class="row margin-bottom-5">
        <div class="col-md-3">İlgili Birim*</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlBirim" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12">
            </asp:DropDownList>
          
        </div>
     </div> 
   
    <div class="row margin-bottom-5">
        <div class="col-md-3">Alt Birim Adı*</div>
        <div class="col-md-5">
            <asp:TextBox ID="txtAltBirim" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
        </div>
     </div>
    <div class="row margin-bottom-5">
        <div class="col-md-3">Öğrenim Türü*</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlOgrenimTuru" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12" 
                onselectedindexchanged="ddlOgrenimTuru_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="0">Öğrencisi Olmayan</asp:ListItem>
                <asp:ListItem Value="1">Ön Lisans</asp:ListItem>
                <asp:ListItem Value="2">Lisans</asp:ListItem>
                <asp:ListItem Value="3">Yüksek Lisans</asp:ListItem>
                <asp:ListItem Value="4">Doktora</asp:ListItem>
            </asp:DropDownList>
        </div>
     </div>
    <div class="row margin-bottom-5">
        <div class="col-md-3">Bölüm Türü*</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlBolumTuru" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="0">Öğrencisi Olmayan</asp:ListItem>
                <asp:ListItem Value="1">Sayısal</asp:ListItem>
                <asp:ListItem Value="2">Sözel</asp:ListItem>
                <asp:ListItem Value="3">Tıp</asp:ListItem>
                <asp:ListItem Value="4">Genel</asp:ListItem>
            </asp:DropDownList>
        </div>
     </div>   
    <div class="row margin-bottom-5">
        <div class="col-md-3"></div>
        <div class="col-md-5">
        <asp:Button ID="btnOlustur" runat="server"  Text="Oluştur" CssClass="btn btn-default" OnClick="btnOlustur_Click"  />
        </div>

     </div>
      <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-5">
            <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>

     </div>
     <div class="row">
         <asp:DataList ID="DtlistBolumEkle" runat="server"    >
             <HeaderTemplate>
                 <table class="list-group-item active col-md-12" >
                     <tr>
                         <td style="width:50px">
                             id</td>
                         <td style="width:350px">
                             Birim Adı</td>
                         <td style="width:80px">
                             bolumID</td>
                         <td style="width:350px">
                             Bolum Adı</td>
                         <td style="width:100px">
                             Öğrenim Türü</td>
                         <td style="width:100px">
                             Bolum Turu</td>
                     </tr>
                 </table>
             </HeaderTemplate>
             <ItemTemplate>
                 <table  class="list-group-item  col-md-12" >
                     <tr>
                         <td style="width:50px">
                             <%#Eval("id") %></td>
                         <td style="width:350px">
                             <%#Eval("birimAdi")%></td>
                         <td style="width:80px">
                             <%#Eval("bolumID")%></td>
                         <td style="width:350px">
                             <%#Eval("bolumAdi")%></td>
                         <td style="width:100px">
                             <%#Eval("OgrenimTuru")%></td>
                         <td style="width:100px">
                             <%#Eval("bolumTuru")%></td>
                     </tr>
                 </table>
             </ItemTemplate>
         </asp:DataList>
     </div>
     </div>  
    <div class="conte">
        <div class="conteMin" style="width:550px;height:auto">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        </div>
    </div>
</asp:Content>

