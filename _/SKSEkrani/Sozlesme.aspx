<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="Sozlesme.aspx.cs" Inherits="SKSEkrani_Sozlesme" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container margin-top-20">
        <div class="row"><div class="col-md-3">Çalıştığı Birimi</div>
        <div class="col-md-4"><asp:DropDownList ID="ddlOkul" runat="server" AutoPostBack="True" CssClass="form-control col-md-4"
            onselectedindexchanged="ddlOkul_SelectedIndexChanged">
        </asp:DropDownList></div>
        </div>
      <div class="row margin-bottom-10 margin-top-10"><div class="col-md-3">Öğrenci</div>
        <div class="col-md-4"><asp:DropDownList ID="ddlOgrenci" runat="server" CssClass="form-control col-md-4">
        </asp:DropDownList></div>
        </div>
   
        <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6"><asp:Button ID="btnGetir" runat="server" onclick="btnGetir_Click" Text="Getir" CssClass="btn btn-default"
           /></div>
        </div>
    
 
    </div>
</asp:Content>

