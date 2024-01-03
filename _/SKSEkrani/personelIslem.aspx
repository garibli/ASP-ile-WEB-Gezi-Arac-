<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="personelIslem.aspx.cs" Inherits="SKSEkrani_personelIslem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../JScript/jquery-1.9.1.js"></script>
<script type="text/javascript">
    
  
</script>
    <style type="text/css">

        .ortaMenu
        {
            margin-top:5px;
            background-color:#AAC1C0;
            width:605px;
            height:auto
            
        }
        #solKutu
        {
            margin-top:10px;
            }
            .conteMin
            {
                width:600px;
            }
            .alan1
            {
                width:200px;
                float:left;
                margin-top:15px;
                margin-left:10px;
            }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="container">
    <div class="col-md-12">
    <div ><a href="personelIslem.aspx" class="btn btn-default col-md-4">PERSONEL EKLE</a></div>
    <div ><a href="personelDuzenle.aspx" class="btn btn-default col-md-4">PERSONEL DÜZENLE/SİL</a></div>
    </div>
    </div>
    <br />
    <div id="HataMesaji">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="LblHata" 
            runat="server" Font-Bold="True" ForeColor="#000066"></asp:Label></div>
    <br />
    <div class="container">
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
      
           <asp:Button ID="Button1" runat="server" Text="KAYDET"  CssClass="btn btn-default" 
               onclick="Button1_Click"/>
        </div>

       

        </div>
</asp:Content>

