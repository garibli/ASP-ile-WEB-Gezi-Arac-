<%@ Page Title="" Language="C#" MasterPageFile="~/anaTasarim.master" AutoEventWireup="true" CodeFile="PuantajGirilemez.aspx.cs" Inherits="PuantajGirilemez" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="container col-md-12" style="font-size:x-large;color:Gray">
        <strong>Şuanda puantaj girilemez... Puantaj girişleri bir önceki ay için ay 
        başından itibaren SKS&#39;nin belirlediği gün dahilinde alınmaktadır. Genellikle bu 
        süre 6 gün olmaktadır...</strong></p>
    <p class="col-md-12" style="font-size:x-large">
        <asp:Button ID="btntamam" runat="server" Text="Tamam" class="btn btn-default col-md-offset-5"
            Font-Bold="True" Font-Size="X-Large"
            OnClick="btntamam_Click"  />
        </p>
</asp:Content>

