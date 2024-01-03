<%@ Page Title="" Language="C#" MasterPageFile="~/persEkrani/PersMaster.master" AutoEventWireup="true" CodeFile="kontenjanTakip.aspx.cs" Inherits="persEkrani_kontenjanTakip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
    <asp:DataList ID="dtLKontenjan" runat="server" CellPadding="4" CssClass="table"
        ForeColor="#333333">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderTemplate>
       <table class="col-md-11" border="3px" style="height:50px">
            <tr>
                <td class="col-md-3"></td>
                <td class="col-md-4"> TALEP EDİLEN KONTENJAN</td>
                <td class="col-md-4"> AÇILAN KONTENJAN</td>
            </tr>
        </table >
            <table class="col-md-11" border="2px" style="height:50px">
                <tr>
                    <td class="col-md-3">
                        Birim</td>
                    <td class="col-md-2">
                        Akademik</td>
                    <td class="col-md-2">
                        İdari</td>
                    <td class="col-md-2">
                        Akademik</td>
                    <td class="col-md-2">
                        İdari</td>
                </tr>
            </table>
        </HeaderTemplate>
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            <table class="col-md-11" >
                <tr>
                    <td class="col-md-3">
                       <%#Eval("AltBirim") %> </td>
                    <td class="col-md-2">
                       <%#Eval("AkademikTalep") %> </td>
                    <td class="col-md-2">
                       <%#Eval("İdariTalep") %> </td>
                    <td class="col-md-2">
                       <%#Eval("YanitAkademik") %> </td>
                    <td class="col-md-2">
                       <%#Eval("YanitIdari") %> </td>
                </tr>
            </table>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>
</asp:Content>

