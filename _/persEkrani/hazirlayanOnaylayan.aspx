<%@ Page Title="" Language="C#" MasterPageFile="~/persEkrani/PersMaster.master" AutoEventWireup="true" CodeFile="hazirlayanOnaylayan.aspx.cs" Inherits="persEkrani_hazirlayanOnaylayan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblKayit" runat="server" Text=""></asp:Label> 
    <div class="container">
    <div class="col-md-12 col-sm-12 col-lg-12">
        <div class="cool-md-12 col-sm-12 col-lg-12">
            <div class="center-block font-grey-cascade" style="font-size:20px;text-align:center">HAZIRLAYAN-ONAYLAYAN KAYIT</div>
            <br />
            <div class="col-md-6">
                    <label>ADI</label><asp:TextBox ID="TxtAd"
                runat="server" CssClass="form-control"></asp:TextBox>
            </div>
           <div class="col-md-6">
                    <label>SOYADI</label>
                      <asp:TextBox ID="txtSoyad"
                runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-6 margin-top-10">
                    <label>ÜNVAN</label>
                <asp:TextBox ID="txtUnvan" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-6 margin-top-10">
                    <label>HAZ/ONAY</label>
                    <asp:DropDownList ID="ddListUnvan" runat="server" CssClass="form-control " >
                    <asp:ListItem Value="0">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="HAZIRLAYAN">HAZIRLAYAN</asp:ListItem>
                <asp:ListItem Value="ONAYLAYAN">ONAYLAYAN</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
         <div class="container col-md-12 col-sm-12 col-lg-12 margin-top-20">
            <div class="row">
                <div class="col-md-offset-11">
                    <asp:Button ID="btnOnaylayanKayit" runat="server" Text="Kaydet" 
                        CssClass="btn btn-default " onclick="btnOnaylayanKayit_Click" />
                </div>
            </div>
        </div>
    </div>
</div>
    <div class="container margin-top-20">
        <div class="col-md-12" style="font-size:20px">
            <strong><center><asp:Label ID="lblKayitli" runat="server" ForeColor="Gray" Text="Kayıtlı Kişiler"></asp:Label></center></strong>
        </div>
    </div>
    <div class="container">
    <div class="col-md-12">
   <asp:DataList ID="DtlistIlan" runat="server" CellPadding="3" CssClass="col-md-12 margin-top-20 "
        ForeColor="Black" onitemcommand="DtlistIlan_ItemCommand" Font-Size="Larger"
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" 
        BorderWidth="1px" GridLines="Vertical">
        <AlternatingItemStyle BackColor="#CCCCCC" />
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle  Font-Bold="True" ForeColor="White" BackColor="Black" />
        <HeaderTemplate>
            <table  class="col-md-12 margin-top-10" >
                <tr>
                  <td class="col-md-2">AD</td>
                        <td class="col-md-2"> SOYAD</td>
                        <td class="col-md-3">UNVAN</td>
                        <td class="col-md-3">HAZIRLAYAN</td>
                        <td class="col-md-2">SİL</td>
                </tr>
            </table>
        </HeaderTemplate>
        <ItemTemplate>
            <table  class="col-md-12 margin-top-10" >
                <tr>
                        <td class="col-md-2"><%#Eval("ad") %></td>
                        <td class="col-md-2"><%#Eval("soyad") %></td>
                        <td class="col-md-3"><%#Eval("unvan") %></td>
                        <td class="col-md-3"><%#Eval("hazirlayanOnaylayan") %></td>  
                        <td class="col-md-2"><asp:LinkButton ID="LinkbtnSil" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="sil" CssClass="btn btn-default" >
                            sil</asp:LinkButton></td>
                   
                </tr>
            </table>
        </ItemTemplate>
       
        <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
   </div>
   </div>
</asp:Content>

