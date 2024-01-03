<%@ Page Title="" Language="C#" MasterPageFile="~/persEkrani/PersMaster.master" AutoEventWireup="true" CodeFile="kontenjanTalep.aspx.cs" Inherits="persEkrani_kontenjanTalep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
  
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
<div class="row margin-bottom-15">
    <div class="col-md-3">
    BİRİM
    </div>
     <div class="col-md-5">
       <asp:TextBox ID="txtBirim" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox> 
    </div>

</div>
<div class="row margin-bottom-35">
    <div class="col-md-3">
    BOLUM
    </div>
     <div class="col-md-5"> 
         <asp:DropDownList ID="ddlBolum" runat="server" 
             CssClass="dropdown dropdown-toogle btn btn-default" >
         </asp:DropDownList>
           </div>

</div>
<div class="row margin-bottom-35">
    <div class="col-md-4 " >
    
    </div>
    <div class="col-md-4 " ><strong>
    TALEP KOTENJAN
    </strong>
    </div>

</div>
<div class="row margin-bottom-15">
    <div class="col-md-3">
    AKADEMİK KOTENJAN
    </div>
     <div class="col-md-5">
       <asp:TextBox ID="txtAkademikKontenjan" runat="server" CssClass="form-control" Text="0"></asp:TextBox> 
    </div>

</div>
<div class="row margin-bottom-15">
    <div class="col-md-3">
    IDARİ KOTENJAN
    </div>
     <div class="col-md-5">
       <asp:TextBox ID="txtIdariKontenjan" runat="server" CssClass="form-control" Text="0"></asp:TextBox> 
    </div>

</div>
<div class="row margin-bottom-10">
    <div class="col-md-3">
    
    </div>
     <div class="col-md-5">
         <asp:Button ID="btnKontenjanTalep" runat="server" Text="Listeye Ekle" 
             CssClass="btn green col-md-12" onclick="btnKontenjanTalep_Click"/>
    </div>

</div>
<div class="row margin-bottom-10">
    <div class="col-md-10 col-md-offset-1" style="font-size:larger;color:Red"><strong>
       Listeye Eklenen Taleplerin SKS ye gönderilmesi için Aşağıdaki DEVAM ET-GONDER  butonuna Basmanız Gerekmektedir.</strong>
    </div>
    

</div>
<div class="row margin-bottom-10">
    <div class=" col-md-offset-5" style="font-size:larger;">
   <strong>   LİSTE</strong>
    </div>
    

</div>

<div class="col-md-12">
    <asp:DataList ID="dtListTalepKontenjanListe" runat="server" CellPadding="4" 
        ForeColor="#333333" CssClass="table" 
        onitemcommand="dtListTalepKontenjanListe_ItemCommand">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderTemplate>
            <table class="col-md-12">
                <tr>
                    <td class="col-md-3">
                        Birim</td>
                    <td class="col-md-3">
                        Alt Birim</td>
                    <td class="col-md-2">
                        İdari Kontenjan</td>
                    <td class="col-md-2">
                        Akademik Kontejan</td>
                    <td class="col-md-2">
                        SİL</td>
                    
                </tr>
            </table>
        </HeaderTemplate>

        <ItemStyle BackColor="#EFF3FB" />

        <ItemTemplate>
            <table class="col-md-12">
                <tr>
                    <td class="col-md-3">
                         <%#Eval("Birim") %></td>
                    <td class="col-md-3">
                        <%#Eval("AltBirim") %></td>
                    <td class="col-md-2">
                         <%#Eval("IdariKontenjan") %></td>
                    <td class="col-md-2">
                         <%#Eval("AkademikKontenjan") %></td>
                    <td class="col-md-2">
                        <asp:LinkButton ID="lnkDüzenle" runat="server" CommandArgument='<%#Eval("id") %>' CssClass="btn red">SİL</asp:LinkButton></td>
                    
                </tr>
            </table>
        </ItemTemplate>

        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />

    </asp:DataList>
    
    
    <div id="goster">
    <!--<div class="margin-bottom-10"><strong>
    SKS ye gönderdikten sonra talep edilen kontenjanınız kapatılacaktır. Eğer Devam etmek istiyorsanız aşağıdaki butona tıklayınız
  </strong></div>-->
    <asp:Button ID="btnSksGonder" runat="server" Text="DEVAM ET-GÖNDER" 
        CssClass="btn blue" onclick="btnSksGonder_Click"/>
    </div>
</div>

</div>

</asp:Content>

