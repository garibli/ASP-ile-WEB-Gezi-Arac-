<%@ Page Title="" Language="C#" MasterPageFile="~/persEkrani/PersMaster.master" AutoEventWireup="true" CodeFile="Puantaj.aspx.cs" Inherits="SKSEkrani_Puantaj" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
    .conte {
        width:800px;
        height:auto;
    }
    .conteMin {
        height:20px;
        width:772px;
        margin-top:5px;      
    }
    .conteDataView{
        height:auto;
        width:380px;
        margin-top:10px;  
        float:left;
    }
     .Aciklama{
       
        height:20px;
        width:125px;
        float:left;
       
    }
     .textBox{
        height:20px;
        width:250px;
        float:left;
    }
     
    .uyari {
        height: 20px;
        width: 160px;
        float: left;
        margin-left:5px;
    }
     .calander{
         width:200px;
         height:180px;
         float:left;
         margin-top:5px;
     }
     
    </style>
    <div class="container" style="font-size:larger">
        <div class="col-md-12">
        <div class="col-md-4">
                 HAZIRLAYAN
        </div>
        <div class="col-md-4">
                 ONAYLAYAN
        </div>
        
        <div class="col-md-12 row">
        <div class="col-md-4">
                 <asp:DropDownList ID="ddlistHazirlayan" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
                 <asp:DropDownList ID="ddlistOnaylayan" runat="server" CssClass="form-control">
                 
            </asp:DropDownList>
        </div>
        </div>
        </div>
    </div>
    <div class="container" style="font-size:larger;margin-top:50px">
            <div class="col-md-12">
                    
       
                        <div class="col-md-3" style="font-size:medium">
                              İLGİLİ BİRİM
                        </div>
                        <div class="col-md-2"  style="font-size:medium">
                              AY
                        </div>
                        <div class="col-md-3" style="font-size:medium">
                              YIL
                        </div>
                </div>
             </div>
    
    <div class="container">
      
        <div class="col-md-12">
        <div class="col-md-3">
            <asp:DropDownList ID="ddlIlgiliBolum" runat="server"  CssClass="btn btn-default dropdown-toggle col-md-12"
                OnSelectedIndexChanged="ddlIlgiliBolum_SelectedIndexChanged" 
                Enabled="False" >
                <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-2">
            
            <asp:DropDownList ID="ddlAy" runat="server"  CssClass="btn btn-default dropdown-toggle col-md-12"
                OnSelectedIndexChanged="ddlAy_SelectedIndexChanged" >
                <asp:ListItem Value="1"></asp:ListItem>
                <asp:ListItem Value="2"></asp:ListItem>
                <asp:ListItem Value="3"></asp:ListItem>
                <asp:ListItem Value="4"></asp:ListItem>
                <asp:ListItem Value="5"></asp:ListItem>
                <asp:ListItem Value="6"></asp:ListItem>
                <asp:ListItem Value="7"></asp:ListItem>
                <asp:ListItem Value="8"></asp:ListItem>
                <asp:ListItem Value="9"></asp:ListItem>
                <asp:ListItem Value="10"></asp:ListItem>
                <asp:ListItem Value="11"></asp:ListItem>
                <asp:ListItem Value="12"></asp:ListItem>
            </asp:DropDownList>
            
        </div>
        <div class="col-md-3">

            <asp:DropDownList ID="ddlYil" runat="server"  CssClass="btn btn-default dropdown-toggle col-md-12"
                OnSelectedIndexChanged="ddlYil_SelectedIndexChanged">
                <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
            </asp:DropDownList>
            
            </div>
            </div>
     </div>
   <div class="container" style="margin-top:25px">
    <div class="col-md-12">
        <div class="col-md-2">
        <asp:Button ID="btnOlustur" runat="server" Text="Puantaj Görüntüle" CssClass="btn btn-default col-md-12 " Font-Bold="True" OnClick="btnOlustur_Click"  />
         
         &nbsp;<asp:Button ID="btnBordroList" runat="server" Text="Bordro Görüntüle" CssClass="btn btn-default col-md-12 " Font-Bold="True" OnClick="btnBordroList_Click"  />
         
         </div>
         </div>
    </div>
    <div class="conteMin">
        <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    
    </div>


</asp:Content>

