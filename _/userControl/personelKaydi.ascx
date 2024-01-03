<%@ Control Language="C#" AutoEventWireup="true" CodeFile="personelKaydi.ascx.cs" Inherits="userControl_personelKaydi" %>
<style>
     .conteMain{
         height:305px;
         width:463px;
         float:left;
     }
    .conteMin {
        height:20px;
        width:463px;
        margin-top:5px;      
    }
     .Aciklama{
       
        height:20px;
        width:155px;
        float:left;
       
    }
     .textBox{
        height:20px;
        width:148px;
        float:left;
    }
  
    .uyari{
        height:20px;
        width:160px;
        float:left;
        
    }
    .gonderBtn{
        float:right;
        height:20px;
        width:80px;
    }
</style>
<div class="conte">
    <div class="conteMin">
        <div class="Aciklama">Adınız</div>
        <div class="textBox"><asp:TextBox ID="txtAd" runat="server" MaxLength="30" Height="15px" Width="135px"></asp:TextBox></div>
        <div class="uyari">
        </div>
    </div>
    <div class="conteMin">
        <div class="Aciklama">Soyadınız</div>
        <div class="textBox"><asp:TextBox ID="txtSoyad" runat="server" MaxLength="15" Height="15px" Width="135px"></asp:TextBox></div>
        <div class="uyari">
        </div>
    </div>
    <div class="conteMin">
        <div class="Aciklama">Sifreniz</div>
        <div class="textBox"><asp:TextBox ID="txtSifre" runat="server" TextMode="Password" MaxLength="8" Height="15px" Width="135px"></asp:TextBox></div>
        <div class="uyari">
        </div>
    </div>
    <div class="conteMin">
        <div class="Aciklama">Sifrenizi Doğrulayınız</div>
        <div class="textBox"><asp:TextBox ID="txtSifreDogrula" runat="server" TextMode="Password" MaxLength="8" Height="15px" Width="135px"></asp:TextBox></div>
        <div class="uyari">
        </div>
    </div>
    <div class="conteMin">
        <div class="Aciklama">Mail Adresiniz</div>
        <div class="textBox"><asp:TextBox ID="txtMail" runat="server" MaxLength="50" Height="15px" Width="135px"></asp:TextBox></div>
        <div class="uyari">
        </div>
    </div>
    <div class="conteMin">
        <div class="Aciklama">dahiliNo</div>
        <div class="textBox"><asp:TextBox ID="txtDahiliNo" runat="server" MaxLength="5" Height="15px" Width="135px" AutoPostBack="True"></asp:TextBox></div>
        <div class="uyari">
            
         </div>
    </div>
    <div class="conteMin">
        <div class="Aciklama">Biriminiz</div>
        <div class="textBox">
            <asp:DropDownList ID="ddlBirim" runat="server" Height="20px" Width="140px">
            </asp:DropDownList>
        </div>
        <div class="uyari">
        </div>
    </div>
    <div class="conteMin">
        <div class="Aciklama">Yetkiniz</div>
        <div class="textBox">
            <asp:DropDownList ID="ddlYetki" runat="server" Height="20px" Width="140px">
            </asp:DropDownList>
            </div>
        <div class="uyari">
        </div>
    </div>
     <div class="conteMin" aria-autocomplete="none">
        <div class="Aciklama"></div>
        <div class="textBox">
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
            <asp:Button ID="btnGonder" runat="server" Height="20px" Text="Gönder" Width="80px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" OnClick="btnGonder_Click" />
            
            </div>
        <div class="uyari"></div>
    </div>
    

</div>