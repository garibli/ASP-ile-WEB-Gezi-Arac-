<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="BirimListele.aspx.cs" Inherits="SKSEkrani_BirimListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="container">
        <div class="col-md-12 list-group">
            <asp:DataList ID="DtListBirim" runat="server" CssClass="clist-group">
                <HeaderTemplate>
                <div  class="col-md-12 list-group-item active">
                    <table>
                        <tr >
                            <td style="font-size:smaller;width:70px">
                                id</td>
                            <td  style="font-size:smaller;width:320px">
                                Birim Adı</td>
                            <td style="font-size:smaller;width:100px">
                                Üst Kontenjan</td>
                            <td  style="font-size:smaller;width:90px">
                                Birim Türü</td>
                            <td  style="font-size:smaller;width:90px">
                                İlk Kontejan</td>
                            <td  style="font-size:smaller;width:90px">
                                Ek Kontenjan</td>
                        </tr>
                    </table></div>
                </HeaderTemplate>
                <ItemTemplate>
                 <div class="col-md-12 list-group-item">
                    <table>
                        <tr >
                            <td  style="font-size:smaller;width:70px">
                                <%#Eval("id")%></td>
                            <td style="font-size:smaller;width:320px"">
                                <%#Eval("adi")%></td>
                            <td  style="font-size:smaller;width:100px"">
                               <%#Eval("UstKontenjan")%></td>
                            <td  style="font-size:smaller;width:90px"">
                                <%#Eval("BirimTuru")%></td>
                            <td style="font-size:smaller;width:90px"">
                                <%#Eval("IlkKontenjan")%></td>
                            <td style="font-size:smaller;width:90px"">
                                <%#Eval("EkKontenjan")%></td>
                        </tr>
                    </table>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        </div>





</asp:Content>

