<%@ Page Title="" Language="C#" MasterPageFile="~/ogrEkrani/OgrMaster.master" AutoEventWireup="true" CodeFile="BasvuruYapılmıs.aspx.cs" Inherits="ogrEkrani_BasvuruYapılmıs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            color: #000066;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span class="style1"><strong>Daha önce başvuru yaptınız. Başvurularınız ;<br />
    <br />
    </strong>
    <asp:Label ID="lbl1" runat="server" Font-Bold="True" ForeColor="#000066"></asp:Label>
    <br />
    <asp:Label ID="lbl2" runat="server" Font-Bold="True" ForeColor="#000066"></asp:Label>
    <br />
    <asp:Label ID="lbl3" runat="server" Font-Bold="True" ForeColor="#000066"></asp:Label>
    <br />
    <br />
    Başvuruları silip yeniden başvuru yapmak için aşağıdaki buttona tıklayınız.<br />
            
            <asp:Button ID="btnGonder" runat="server" Height="20px" Text="Tekrar Başvuru Yapın" 
             Width="150px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" 
             ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" 
             OnClick="btnGonder_Click" />
            
            &nbsp;</span>  
</asp:Content>

