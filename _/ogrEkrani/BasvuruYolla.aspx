<%@ Page Title="" Language="C#" MasterPageFile="~/ogrEkrani/OgrMaster.master" AutoEventWireup="true" CodeFile="BasvuruYolla.aspx.cs" Inherits="ogrEkrani_BasvuruYolla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/alanlar2.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="conte">
<div class="conteMin">
Birden fazla başvuruda bulunacaksanız öncelikli ilanınızı seçin. Başvurularınızı kontrol ettikten sonra gönder butonuna tıklayınız.
</div>
<div class="conteMin">
    <asp:DropDownList ID="ddl1" runat="server" Height="16px" Width="40px">
        <asp:ListItem>0</asp:ListItem>
    </asp:DropDownList>
&nbsp;<asp:Label ID="lbl1" runat="server"></asp:Label>
</div>
<div class="conteMin">
    <asp:DropDownList ID="ddl2" runat="server" Height="16px" Width="40px">
        <asp:ListItem>00</asp:ListItem>
    </asp:DropDownList>
&nbsp;<asp:Label ID="lbl2" runat="server"></asp:Label>
</div>
<div class="conteMin">
    <asp:DropDownList ID="ddl3" runat="server" Height="16px" Width="40px">
        <asp:ListItem>000</asp:ListItem>
    </asp:DropDownList>
&nbsp;<asp:Label ID="lbl3" runat="server"></asp:Label>
</div>
<div class="conteMin">
            
            <asp:Button ID="btnGonder" runat="server" Height="20px" Text="Gönder" 
        Width="127px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
        ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
        OnClick="btnGonder_Click" />
            
</div>
<div class="conteMin">

    <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>

</div>
</div>
</asp:Content>

