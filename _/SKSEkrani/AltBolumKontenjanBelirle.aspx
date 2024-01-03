<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="AltBolumKontenjanBelirle.aspx.cs" Inherits="SKSEkrani_AltBolumKontenjanBelirle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    .conteMin {
        height:20px;
        width:772px;
        margin-top:5px;      
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
        
    }    .conte {
        width:800px;
        height:auto;
        float:left;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container row">
        <div class="col-md-3">
            Birim :</div>
        <div class="col-md-6">
            <asp:DropDownList ID="ddlBirim" runat="server" CssClass="col-md-6 btn btn-default dropdown-toggle " AutoPostBack="True" OnSelectedIndexChanged="ddlBirim_SelectedIndexChanged" >
            </asp:DropDownList>
        </div>
    </div>
    <div class="container row margin-top-10">
        <div class="col-md-3">
            Alt Bolum :</div>
        <div class="col-md-6">
            <asp:DropDownList ID="ddlAltBolum" runat="server" CssClass="btn btn-default dropdown-toggle col-md-6"
                AutoPostBack="True" 
                OnSelectedIndexChanged="ddlAltBolum_SelectedIndexChanged" >
            </asp:DropDownList>
        </div>
    </div>
    
    
    <div class="container row margin-top-10">
        <div class="col-md-3">
            Akademik Kontenjan :</div>
        <div class="col-md-3">
            <asp:TextBox ID="txtAkademiKon" runat="server" CssClass="form-control col-md-3"></asp:TextBox>
        </div>
    </div>
     <div class="container row margin-top-10">
        <div class="col-md-3">
            Idari Kontenjan :</div>
        <div class="col-md-3">
            <asp:TextBox ID="txtIdariKon" runat="server" CssClass="form-control col-md-3"></asp:TextBox>
        </div>
    </div>
      <div class=" container row margin-top-10">
      <div class="col-md-3"></div>
      <div class="col-md-3">
            <asp:Button ID="Button1" runat="server"  Text="Çalışan Sayısı Güncelle" 
                CssClass="btn green col-md-12 " onclick="Button1_Click"  />
        </div>
        </div>
     <div class="container row margin-top-10">
        <div class="col-md-3">
            Akademik Çalışan :</div>
        <div class="col-md-3">
            <asp:TextBox ID="txtAkademikCalisan" runat="server" 
                CssClass="form-control col-md-3" Enabled="False"></asp:TextBox>
        </div>
    </div> <div class="container row margin-top-10">
        <div class="col-md-3">
            Idari Çalışan :</div>
        <div class="col-md-3">
            <asp:TextBox ID="txtIdariCalisan" runat="server" 
                CssClass="form-control col-md-3" Enabled="False"></asp:TextBox>
        </div>
    </div>
    <div class="container col-md-12">
       <div class="row">
           <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#000066"></asp:Label>
    </div>
    </div>
    <div class="container col-md-12">
      <div class="row">
           <asp:Label ID="lblBilgi0" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    </div>
    </div>
    <div class="container row margin-top-10">
       
        <div class="col-md-offset-3 col-md-6">
            <asp:Button ID="btnGir" runat="server"  Text="Girin" CssClass="btn blue " OnClick="btnGir_Click" />
        </div>
    </div>
    <div class="conte" style="margin-top:10px;width:757px; margin-left:10px">
        <h3>
            Bölüm Kontejanları</h3>
        <asp:GridView ID="GridViewBolum" CssClass="table table-hover"  runat="server" 
            CellPadding="3" Width="750px" BackColor="White" BorderColor="#CCCCCC" 
            BorderStyle="None" BorderWidth="1px">
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
    </div>
</asp:Content>

