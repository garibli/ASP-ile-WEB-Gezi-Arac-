<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="Kontenjan.aspx.cs" Inherits="SKSEkrani_Kontenjan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/Alan1.css" rel="stylesheet" />
   
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container"> 
    <div class="row">
    <div class="col-md-3"> Birim :</div>
       <div class="col-md-7"> <asp:DropDownList ID="ddlBirim" runat="server" CssClass="col-md-5 btn btn-default dropdown-toggle " AutoPostBack="True" OnSelectedIndexChanged="ddlBirim_SelectedIndexChanged" >
        </asp:DropDownList>
        </div>
        </div>
        
    <div class="row margin-top-10">
    <div class="col-md-3"> Akademik Kontenjan :</div>
       <div class="col-md-3"> <asp:TextBox ID="txtAkademik" runat="server" 
               CssClass="form-control col-md-6"></asp:TextBox>
        </div>
        <div class="col-md-3"><strong></strong></div>
        </div>

    <div class="row margin-top-10">
    <div class="col-md-3"> İdari Kontenjan :</div>
       <div class="col-md-3"> <asp:TextBox ID="txtIdariKonte" runat="server" CssClass="form-control col-md-6"></asp:TextBox>
        </div>
        </div>
      
      <div class="row margin-top-10">
    <div class="col-md-3"> Yedek Akademik Kontenjan :</div>
       <div class="col-md-3"> <asp:TextBox ID="txtYedekAkademikKonte" runat="server" CssClass="form-control col-md-6"></asp:TextBox>
        </div><div class="col-md-3"><strong></strong></div>
        </div>
         <div class="row margin-top-10">
    <div class="col-md-3"> Yedek İdari Kontenjan :</div>
       <div class="col-md-3"> <asp:TextBox ID="txtYedekIdariKonte" runat="server" CssClass="form-control col-md-6"></asp:TextBox>
        </div><div class="col-md-3"><strong></strong></div>
        </div>
         <div class="row margin-top-10 center-block"> 
          <asp:Button ID="Button1" runat="server" CssClass="btn blue col-md-offset-4"  
                 Text="Çalışan Sayısı Güncelle" onclick="Button1_Click" />
        </div> 
        <div class="row margin-top-10">
    <div class="col-md-3"> Akademik Çalışan :</div>
       <div class="col-md-3"> <asp:TextBox ID="txtAkademiCalisan" runat="server" 
               CssClass="form-control col-md-6" Enabled="False"></asp:TextBox>
        </div><div class="col-md-3"><strong></strong></div>
        </div>
        <div class="row margin-top-10">
    <div class="col-md-3"> İdari Çalışan :</div>
       <div class="col-md-3"> <asp:TextBox ID="txtIdariCalisan" runat="server" 
               CssClass="form-control col-md-6" Enabled="False"></asp:TextBox>
        </div><div class="col-md-3"><strong></strong></div>
        </div>
        
        
        <div class="container  margin-top-10" > 
          <asp:Button ID="btnGir" runat="server" CssClass="btn blue col-md-offset-5" OnClick="btnGir_Click" Text="GİRİN" />
        </div> 
        <div class="row"><asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label></div>
    </div>
   

         <h3>Birim Kontejanları</h3>
        <asp:GridView ID="GridViewBirim" CssClass="table table-hover" 
        runat="server" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" 
        BorderStyle="None" BorderWidth="1px" >
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
   
    </asp:Content>

