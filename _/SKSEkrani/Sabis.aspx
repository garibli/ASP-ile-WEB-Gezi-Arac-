<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="Sabis.aspx.cs" Inherits="SKSEkrani_Sabis" %>

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
     
    .auto-style1 {
        color: #000066;
    }
     
</style>

 <div class="conteMin">
      
        <div class="textBox">
           İlgili Birim
        </div>
        <div class="uyari" style="width:70px">
            
           &nbsp;Ay
            
        </div>
        <div class="uyari">
            &nbsp;Yıl
        </div>
     </div>

    
    <div class="conteMin">
      
        <div class="textBox">
            <asp:DropDownList ID="ddlIlgiliBolum" runat="server" Height="20px" 
                Width="250px" 
                OnSelectedIndexChanged="ddlIlgiliBolum_SelectedIndexChanged" >
                <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="uyari" style="width:70px">
            
            <asp:DropDownList ID="ddlAy" runat="server" 
                OnSelectedIndexChanged="ddlAy_SelectedIndexChanged" Height="20px">
                <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
            </asp:DropDownList>
            
        </div>
        <div class="uyari">

            <asp:DropDownList ID="ddlYil" runat="server" 
                OnSelectedIndexChanged="ddlYil_SelectedIndexChanged" Height="20px">
                <asp:ListItem Value="-1">Seçiniz</asp:ListItem>
            </asp:DropDownList>
            
            </div>
     </div>
   <div class="conteMin" style="margin-top:5px">
        <asp:Button ID="btnOlustur" runat="server" Height="20px" Text="Oluştur" Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" OnClick="btnOlustur_Click"  />
         </div>
    
    <div class="conteMin">
        <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    
    </div>


</asp:Content>

