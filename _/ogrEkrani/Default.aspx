<%@ Page Title="" Language="C#" MasterPageFile="~/ogrEkrani/OgrMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ogrEkrani_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <style>
       .lbl{
           width:800px;
           margin-top:5px;
           float:left
       }
       .lbl1{
           width:100px;
           float:left
       }

   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <div style="margin-top:35px">
     <div class="lbl">
        <div class="lbl1">
           <strong>Öğrenci</strong></div>
     <asp:Label ID="lblAd" runat="server" Font-Bold="True"></asp:Label>
    </div>
    <div class="lbl">
      <div class="lbl1">  <strong>Öğrenci No 
     </strong></div>
     <asp:Label ID="lblogrNo" runat="server" Font-Bold="True"></asp:Label>
    </div>
   
      <div class="lbl" >
            <div class="lbl1">
          <strong>Mail&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong></div>
            <div class="lbl1">
     <asp:Label ID="lblMail" runat="server" Font-Bold="True"></asp:Label></div>
    </div>
      <div class="lbl">  
     <asp:Label ID="lblCalisBirim" runat="server" Font-Bold="True"></asp:Label>
    </div>
      <div class="lbl" style="margin-bottom:35px">

     <asp:Label ID="lblcalismaSekli" runat="server" Font-Bold="True"></asp:Label>
               
    </div>
     </div>

</asp:Content>

