<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="AltBolumListele.aspx.cs" Inherits="SKSEkrani_AltBolumListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <div class="container">
    <div class="col-md-12 row">
    <div class="col-md-2 margin-top-10" style="font-size:medium">
        Birime Göre Listele
        </div><div class="col-md-4">
        <asp:DropDownList ID="ddlBirim" runat="server" AutoPostBack="True"  CssClass="btn btn-default dropdown-toggle col-md-5"
            onselectedindexchanged="ddlBirim_SelectedIndexChanged" Width="220px">
        </asp:DropDownList>
    </div></div></div>
    <p>
    <div class="container">
    <div class="col-md-12 list-group">
        <asp:DataList ID="DtListBolum" runat="server">
            <HeaderTemplate>
                <table  class="col-md-12 list-group-item active">
                    <tr>
                        <td style="width:270px;font-size:smaller">
                            Adi</td>
                        <td style="width:100px;font-size:smaller">
                            Alt Kontenjan</td>
                        <td style="width:100px;font-size:smaller">
                            Öğrenim Türü</td>
                        <td style="width:100px;font-size:smaller">
                            Bölüm Türü</td>
                        <td style="width:210px;font-size:smaller">
                            Birim Adi</td>
                        <td style="width:40px;font-size:smaller;text-align:right">
                            Üst Kontenjan</td>
                        
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                  <table class="col-md-12 list-group-item">
                    <tr>
                        <td style="width:270px;font-size:smaller">
                            <%#Eval("adi")%></td>
                        <td style="width:100px;font-size:smaller">
                            <%#Eval("altKontenjan")%></td>
                        <td style="width:100px;font-size:smaller">
                            <%#Eval("ogrenimTuru")%></td>
                        <td style="width:100px;font-size:smaller">
                            <%#Eval("bolumTuru")%></td>
                        <td style="width:210px;font-size:smaller">
                           <%#Eval("birimAdi")%></td>
                        <td style="width:40px;font-size:smaller;text-align:right">
                            <%#Eval("UstKontenjan")%></td>
                        
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
    </div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
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
    </p>



</asp:Content>

