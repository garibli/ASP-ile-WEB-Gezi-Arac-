<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="BirimEkle.aspx.cs" Inherits="SKSEkrani_BirimOkulEkle" %>

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
        <div class="col-md-2">Birim Adı*</div>
        <div class="col-md-5">
            <asp:TextBox ID="txtBirim" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
        </div>
        </div>
     
    <div class="row margin-bottom-5">
        <div class="col-md-2">Birim Türü*</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlBirimTuru" runat="server" CssClass="col-md-12 btn btn-default dropdown-toggle">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="0">Öğrencisi Olmayan</asp:ListItem>
                <asp:ListItem Value="5">Meslek Yüksekokulu</asp:ListItem>
                <asp:ListItem Value="1">Fakülte</asp:ListItem>
                <asp:ListItem Value="2">Enstitüsü Sayısal </asp:ListItem>
                <asp:ListItem Value="3">Enstitüsü Sözel</asp:ListItem>
                <asp:ListItem Value="4">Enstitüsü Sağlık </asp:ListItem>
                <asp:ListItem Value="6">Yuksekokul </asp:ListItem>
            </asp:DropDownList>
        </div>
     </div>
     <div class="row margin-bottom-5" style="visibility:hidden">
        <div class="col-md-2">İlk Kontenjan :</div>
        <div class="col-md-5">
            <asp:TextBox ID="txtIlkKontenjan" runat="server" CssClass="form-control"
                Font-Overline="False" ForeColor="Black"></asp:TextBox>
        </div>
         <span class="col-md-4"><strong>İlk atamada İlk Kontenjan = Ust Kontenjan Olucak.</strong></span></div>
     <div class="row margin-bottom-5" style="visibility:hidden">
        <div class="col-md-2">Ek Kontenjan :</div>
        <div class="col-md-5">
            <asp:TextBox ID="txtEkKontenjan" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
     </div>
     <div class="row margin-bottom-5" style="visibility:hidden">
        <div class="col-md-2">Ust Kontenjan :</div>
        <div class="col-md-5">
            <asp:TextBox ID="txtUstKontenjan" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
     </div>
    <div class="row margin-bottom-5">
        <div class="col-md-offset-6">
        <asp:Button ID="btnOlustur" runat="server" Text="Oluştur" CssClass="btn btn-default" OnClick="btnOlustur_Click"  />
        </div>

     </div>
      <div class="row margin-bottom-5">
        <div class="col-md-9">
            <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>

     </div></div>
    <div class="container">
    <div class="col-md-9">
        <asp:DataList ID="dtListBirim" runat="server">
            <HeaderTemplate>
                <table class="list-group-item active">
                    <tr>
                        <td style="width:100px">
                            id</td>
                        <td style="width:500px">
                            adı</td>
                        <td style="width:100px">
                            birim türü</td>
                        <td style="width:100px">
                            üst kontenjan</td>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <table class="list-group-item">
                    <tr>
                        <td style="width:100px">
                            <%#Eval("id")%></td>
                        <td style="width:500px">
                           <%#Eval("adi")%></td>
                        <td style="width:100px">
                            <%#Eval("BirimTuru")%></td>
                        <td style="width:100px">
                           <%#Eval("UstKontenjan")%></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList></div>





      
        <div class="col-md-2">
            *Birim Türü<br />
            0 -> Öğrencisi Olmayan <br />1 -> Fakülteler<br />2 -> Enstitüs Sayısal<br />3 -> Enstitüs Sözel<br />
            4 -> Enstitüs Sağlık<br />5 -> Meslek Yüksekokulu<br />6 ->Yüksekokul

        </div>
    </div>
</asp:Content>

