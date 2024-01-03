<%@ Page Title="" Language="C#" MasterPageFile="~/komisyon/komisyonPage.master" AutoEventWireup="true" CodeFile="ogrIseAlim.aspx.cs" Inherits="komisyon_ogrIseAlim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="container">
            <div class="row">
                            
                <div class="col-md-4">
                      <asp:Button ID="Button1" runat="server" Text="ASIL LİSTE OLUŞTUR/SKS'YE GONDER"  class="btn btn-large blue"  onclick="Button1_Click" />
                </div>
                <div class="col-md-4 ">
                         <asp:Button ID="btn" runat="server" Text="SKS KAYDI YAPILAN ÖĞRENCİLER" class="btn btn-large green"  onclick="btn_Click"   />
                </div>
              </div>
        </div>
   
    <br />
    <div class="container col-md-12">
    <asp:DataList ID="ddlistOGrBasvuruBilgileri" runat="server" CellPadding="4" CssClass="table col-md-12" 
    ForeColor="#333333">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderTemplate>
            <table >
                <tr>
                    <td class="col-md-2">
                        AD
                        </td>
                    <td class="col-md-2">
                        SOYAD
                        </td>
                    <td class="col-md-3">
                        BIRIM
                    </td>
                    <td class="col-md-1">
                        PUAN
                        </td>
                       
                    <td class="col-md-1">
                        PROGRAM ADI
                        </td>
                
                </tr>
            </table>
        </HeaderTemplate>
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            <table>
                <tr>
                    <td class="col-md-2">
                      <%#Eval("ad") %> </td>
                    <td class="col-md-2">
                       <%#Eval("soyad") %> </td>
                    <td class="col-md-3">
                      <%#Eval("birim")%>  
                    </td>
                    <td class="col-md-1">
                         <%#Eval("puan") %> </td>
                         
                    <td class="col-md-1">
                       <%#Eval("programAdi")%>   </td>
                   </tr>
            </table>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#D1DDF1" ForeColor="#333333" Font-Bold="True" />
    </asp:DataList>   
    </div> 
</asp:Content>

