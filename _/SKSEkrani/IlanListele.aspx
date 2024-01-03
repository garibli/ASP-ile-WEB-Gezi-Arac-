<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="IlanListele.aspx.cs" Inherits="SKSEkrani_IlanListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="row margin-bottom-20">
    <div class="col-md-3">
    Birim Seçin</div>
<div class="col-md-5">
    <asp:DropDownList ID="ddlBirimler" runat="server" AutoPostBack="True" 
         onselectedindexchanged="ddlBirimler_SelectedIndexChanged" CssClass="btn btn-default dropdown-toggle col-md-12"
        >
    </asp:DropDownList>
</div>
</div>
<div class="row">
<div>

    <asp:DataList ID="dtListilan" runat="server"  CssClass="clist-group">
        <HeaderTemplate>
            <table class="list-group-item active">
                <tr>
                    <td style="width:200px">
                        ekleme zamanı</td>
                    <td style="width:200px">
                        iş başlığı</td>
                    <td style="width:350px">
                        iş metni</td>
                    <td style="width:200px">
                        iş tanımı
                    </td>
                    <td style="width:50px">
                        kontenjan</td>
                </tr>
            </table>
        </HeaderTemplate>
        <ItemTemplate>
            <table class=" list-group-item">
                <tr>
                    <td style="width:200px">
                        <%#Eval("eklemeZamani")%></td>
                    <td style="width:200px">
                        <%#Eval("isBasligi")%></td>
                    <td style="width:350px">
                        <%#Eval("isMetni")%></td>
                    <td style="width:200px">
                        <%#Eval("isTanimi")%></td>
                    <td style="width:50px">
                       <%#Eval("kontenjan")%></td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</div>
</div>

</asp:Content>

