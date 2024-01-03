<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="GSSDegistir.aspx.cs" Inherits="SKSEkrani_GSSDegistir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="container">
      <div class="row margin-bottom-5">
        <div class="col-md-3">
           İlgili Birim
        </div>
        
        <div class="col-md-5">
            <asp:DropDownList ID="ddlIlgiliBolum" runat="server" CssClass="col-md-12 btn btn-default dropdown-toogle"
                OnSelectedIndexChanged="ddlIlgiliBolum_SelectedIndexChanged" 
                AutoPostBack="True" >
                <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
            </asp:DropDownList>
        </div>
     </div>
     
    <div class="row margin-bottom-5">
      
        <div class="col-md-3">
            Çalışan</div>
        
        <div class="col-md-5">
            <asp:DropDownList ID="ddlCalisan" runat="server" CssClass="col-md-12 btn btn-default dropdown-toogle" >
                <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
            </asp:DropDownList>
        </div>
     </div>
     <div class="row margin-bottom-5">
      
        <div class="col-md-3 ">
            GSS Durumu</div>
        
        <div class="col-md-5">
            <asp:DropDownList ID="ddlGSS" runat="server" CssClass="col-md-12 btn btn-default dropdown-toogle" >
                <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
                <asp:ListItem Value="22">Aileden</asp:ListItem>
                <asp:ListItem Value="43">Kendinden</asp:ListItem>
            </asp:DropDownList>
        </div>
     </div>

   
   <div class="row margin-bottom-5" >
   <div class="col-md-3"></div><div class="col-md-5">
        <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" 
            CssClass="btn btn-default" Font-Bold="True" 
            OnClick="btnGuncelle_Click"  />
         </div>
    </div>
    <div class="conteMin">
        <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    
    </div>

    </div>

</asp:Content>

