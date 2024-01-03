<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Anket3.ascx.cs" Inherits="userControl_Anket3" %>


<div class="container">
 <div class="row" ><div class="col-md-12" style="font-size:large"><center><strong>
        Öğrenci Başvuru Bilgileri</strong></center></div></div>

 <div class ="col-md-12" style="font-size:large"><center> <strong style="margin-top:5px;margin-bottom:5px;color:Red">
       3/3</strong></center></div>

        <div class="col-md-12"><center><strong>İlgili alanları seçiniz.																						
</strong></center></div>
      </div>
      
   <div class="container col-md-offset-2">
   
    <div class="row" style="margin-top:3px" >
    <div class="col-md-6" style="font-size:medium" >
    Engelli ise konusu ve derecesi 
        :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl11" runat="server">
            <asp:ListItem Value="0" Selected="True">Seciniz</asp:ListItem>
            <asp:ListItem Value="1">% 40-44 Engelli</asp:ListItem>
            <asp:ListItem Value="2">%  45-49 Engelli</asp:ListItem>
            <asp:ListItem Value="3">% 50-54 Engelli</asp:ListItem>
            <asp:ListItem Value="4">% 55-59 Engelli</asp:ListItem>
            <asp:ListItem Value="5">% 60 ve üzeri engelli</asp:ListItem>
        </asp:DropDownList>
    </div>
        </div>
     <div class ="row" style="margin-top:3px">
     <div class ="col-md-6" style="font-size:medium" >
        Şehit Yakını ise durumu 

 :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6"  ID="ddl12" runat="server" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Kardeşi şehit</asp:ListItem>
            <asp:ListItem Value="2">Çocuğu şehit</asp:ListItem>
            <asp:ListItem Value="3">Annesi şehit</asp:ListItem>
            <asp:ListItem Value="4">Babası şehit</asp:ListItem>
            <asp:ListItem Value="5">Anne ve Babası şehit</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <%--<div style="margin-top:5px">
     <div class="Aciklama">
         Ulusal yayın sayısı (Yayın listesini form ekinde veriniz)
 :</div>
    <div class ="aciklama1">
        <asp:DropDownList CssClass="CssDropDownList" ID="ddl13" runat="server" >
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="2">1 Adet
</asp:ListItem>
            <asp:ListItem Value="4">2 Adet</asp:ListItem>
            <asp:ListItem Value="6">3 Adet</asp:ListItem>
            <asp:ListItem Value="8">4 Adet</asp:ListItem>
            <asp:ListItem Value="10">5 ve daha fazlası</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>--%>
    <div class ="row" style="margin-top:3px">
     <div class ="col-md-6" style="font-size:medium" >
         SHÇEK'dan gelen öğrenci ise durum bilgisi

 :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6"  ID="ddl14" runat="server">
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Anne baba sağ ve birlikte</asp:ListItem>
            <asp:ListItem Value="2">Anne baba ayrı</asp:ListItem>
            <asp:ListItem Value="3">Anne ölü baba sağ</asp:ListItem>
            <asp:ListItem Value="4">Anne sağ baba ölü</asp:ListItem>
            <asp:ListItem Value="5">Anne ve Baba ölü</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    <div class ="row" style="margin-top:3px">
     <div class ="col-md-6" style="font-size:medium" >
         Sportif başarı veya Özel Yetenek durumu

 :</div>
    <div class ="col-md-6">
        <asp:DropDownList CssClass="btn btn-default dropdown-toggle col-md-6" ID="ddl15" runat="server">
            <asp:ListItem Value="0" Selected="True">Seçiniz</asp:ListItem>
            <asp:ListItem Value="1">Hakem</asp:ListItem>
            <asp:ListItem Value="2">Sertifikalı Çalıştırıcı</asp:ListItem>
            <asp:ListItem Value="3">Eğitmen</asp:ListItem>
            <asp:ListItem Value="4">Antrenör</asp:ListItem>
            <asp:ListItem Value="5">Milli sporcu</asp:ListItem>
        </asp:DropDownList>
    </div>
         </div>
    
    <div class="container">
     <div class ="row" style="margin-top:3px">
     <div class="col-md-offset-6">
            
            <asp:Button ID="Button3" runat="server"  CssClass="btn btn-primary" Text="Bitir" 
             
             OnClick="btnDevam_Click" />
            
            </div>
     </div>
     </div>
     
</div>