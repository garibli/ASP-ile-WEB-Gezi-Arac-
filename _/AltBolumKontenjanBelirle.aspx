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
    <div class="conteMin">
        <div class="Aciklama">
            Birim :</div>
        <div class="textBox">
            <asp:DropDownList ID="ddlBirim" runat="server" Height="20px" Width="205px" AutoPostBack="True" OnSelectedIndexChanged="ddlBirim_SelectedIndexChanged" >
            </asp:DropDownList>
        </div>
    </div>
    <div class="conteMin">
        <div class="Aciklama">
            Alt Bolum</div>
        <div class="textBox">
            <asp:DropDownList ID="ddlAltBolum" runat="server" Height="20px" Width="205px" 
                AutoPostBack="True" 
                OnSelectedIndexChanged="ddlAltBolum_SelectedIndexChanged" >
            </asp:DropDownList>
        </div>
    </div>
    
    
    <div class="conteMin">
        <div class="Aciklama">
            Kontenjan :</div>
        <div class="textBox">
            <asp:TextBox ID="txtKontenjan" runat="server" Width="196px"></asp:TextBox>
        </div>
    </div>

       <div class="conteMin">
       
           
           <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#000066"></asp:Label>
       
    </div>
      <div class="conteMin">
       
           <asp:Label ID="lblBilgi0" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
    </div>

    <div class="conteMin">
        <div class="Aciklama">
        </div>
        <div class="textBox">
            <asp:Button ID="btnGir" runat="server" Height="20px" Text="Girin" Width="117px" BackColor="White" BorderColor="#000066" BorderStyle="Solid" ForeColor="#1E002F" BorderWidth="1px" Font-Bold="True" OnClick="btnGir_Click" />
        </div>
    </div>
    <div class="conte" style="margin-top:10px;width:350px;margin-left:10px">
        <h3>
            Bölüm Kontejanları</h3>
        <asp:GridView ID="GridViewBolum" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
</asp:Content>

