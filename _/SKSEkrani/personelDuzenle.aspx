<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="personelDuzenle.aspx.cs" Inherits="SKSEkrani_personelDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
    <div class="col-md-12">
    <div ><a href="personelIslem.aspx" class="btn btn-default col-md-4">PERSONEL EKLE</a></div>
    <div ><a href="personelDuzenle.aspx" class="btn btn-default col-md-4">PERSONEL DÜZENLE/SİL</a></div>
    </div>
    </div><br />

    
    <div class="container">
     <div class="row margin-bottom-5">
                 <div class="col-md-3"> Personel ID :</div>
                    <div class="col-md-6">  
                        <asp:TextBox ID="txtPersID" runat="server" CssClass="form-control" 
                         MaxLength="30" Enabled="False"></asp:TextBox></div>
                        </div>
            
               <div class="row margin-bottom-5">
                 <div class="col-md-3"> AD</div>
                    <div class="col-md-6">  
                        <asp:TextBox ID="txtpersAd" runat="server" CssClass="form-control" placeholder="ad"
                         MaxLength="30"></asp:TextBox></div>
                    </div>
             <div class="row margin-bottom-5">
                <div class="col-md-3">
                     SOYAD </div>
                <div class="col-md-6">
                       <asp:TextBox ID="txtpersSoyad" runat="server" CssClass="form-control" placeholder="soyad"
                         MaxLength="15"></asp:TextBox>
                </div>
           </div>
           
        <div class="row margin-bottom-5">
        <div class="col-md-3"> TC NO </div>
        <div class="col-md-6">
            <asp:TextBox ID="txtpersTC" runat="server" CssClass="form-control" placeholder="TC"
                MaxLength="11"></asp:TextBox></div>
        </div>

          <div class="row margin-bottom-5">
        <div class="col-md-3">MAİL
        </div>
        <div class="col-md-6">
        <asp:TextBox ID="txtpersMail" runat="server" CssClass="form-control" placeholder="mail"
                MaxLength="50"></asp:TextBox></div></div>
                
          <div class="row margin-bottom-5">
        <div class="col-md-3">BİRİM
        </div>
        <div class="col-md-6">
        <asp:DropDownList ID="DropDownListBirim" runat="server" AutoPostBack="True" 
                CssClass="btn btn-default dropdown-toggle col-md-12" 
                onselectedindexchanged="DropDownListBirim_SelectedIndexChanged"></asp:DropDownList></div>
                </div>
        
        <div class="row margin-bottom-5">
        <div class="col-md-3">BÖLÜM </div>
        <div class="col-md-6">
        <asp:DropDownList ID="DropDownListBolum" runat="server" AutoPostBack="True" 
                CssClass="btn btn-default dropdown-toggle col-md-12" ></asp:DropDownList></div>
       </div>
     
        <div class="row margin-bottom-5">
        <div class="col-md-3">DAHİLİ NO </div>
        <div class="col-md-6">
        <asp:TextBox ID="TxtDahili" runat="server" MaxLength="5" CssClass="form-control" placeholder="dahili no"></asp:TextBox></div>
        </div>

     <div class="row margin-bottom-5">
        <div class="col-md-3">YETKİ</div>
        <div class="col-md-6">
        <asp:DropDownList ID="DropDownListYetki" runat="server" CssClass="btn btn-default dropdown-toggle col-md-12" >
                <asp:ListItem Value="-1">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="0">SKS YÖNETİCİ</asp:ListItem>
                <asp:ListItem Value="1">Birim Yetkilisi</asp:ListItem>
                <asp:ListItem Value="2">Birim Görevlisi</asp:ListItem>
            </asp:DropDownList></div>
      </div>


        <div class="row margin-bottom-5">
        <div class="col-md-3">SİFRE BELİRLE</div>
        <div class="col-md-6">
        <asp:TextBox ID="txtsifreIlk" runat="server" CssClass="form-control" MaxLength="8" placeholder="sifre"></asp:TextBox></div>
  
           
        </div>
       
       
       
                 
<br />        
        <div class="row col-md-offset-8" >
      
           <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle"  CssClass="btn btn-default "
                onclick="btnGuncelle_Click"/>
        </div>
       


       

        


       

        </div>
        <br />

       <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>




    <div  style="margin-top:20px; width:1300px">
    <asp:DataList ID="dlPersonelListele" runat="server" CellPadding="4" 
        ForeColor="#333333" 
            onitemcommand="dlPersonelListele_ItemCommand" Width="1150px" 
            onselectedindexchanged="dlPersonelListele_SelectedIndexChanged">
        <HeaderTemplate>
            <table class="col-md-12 list-group-item active">
                <tr>
                    <td style="width:200px" >
                        Ad Soyad</td>
                    <td style="width:250px">
                        Mail Adresi</td>
                    <td style="width:300px">
                       Birimi</td>
                    <td style="width:150px" >
                        Sifre</td>
                    <td style="width:100px">
                        Güncelle
                        </td >
                    <td style="width:100px">
                        SİL</td>
                </tr>
            </table>
        </HeaderTemplate>
        <ItemTemplate>
            <table class="col-md-12 list-group-item">
                <tr>
                    <td style="width:200px">
                        <%#Eval("Ad") %>&nbsp;&nbsp;<%#Eval("soyad") %></td>
                    <td style="width:250px" >
                       <%#Eval("Mail") %></td>
                   <td style="width:300px">
                       <%#Eval("birimAdi") %></td>

                    <td style="width:150px">
                       <%#Eval("Sifre")%></td>
                        <td  style="width:100px">
                        <asp:LinkButton ID="guncelleButon" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="guncellePersonel" ><img height="25px" src="../img/update.png" /></asp:LinkButton>
                        </td >
                    <td style="width:100px">
                        <asp:LinkButton ID="silButon" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="silPersonel" ><img height="25px" src="../img/delete.png" /></asp:LinkButton>
                        </td>
                </tr>
            </table>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>
    
    </div>
</asp:Content>

