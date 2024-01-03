﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="OzelOgrIseAlım.aspx.cs" Inherits="SKSEkrani_OzelOgrIseAlım" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<link href="../CSS/Alan1.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="container">
    
         <div class="row margin-bottom-5">
    
        <div class="col-md-3">
    
        OKUDUĞU OKULA GÖRE LİSTELE
        </div>
        <div class="col-md-5">
        <asp:DropDownList ID="ddlOkulFiltrele" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12"
                AutoPostBack="True" 
                onselectedindexchanged="ddlOkulFiltrele_SelectedIndexChanged">
        </asp:DropDownList>
           </div>
           </div>

        
         
         
         <div class="row margin-bottom-5">
    
        <div class="col-md-3">
    
        ÖĞRENCİ
        </div>
        <div class="col-md-5">
        <asp:DropDownList ID="ddlOgrenci" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12">
        </asp:DropDownList>
           </div>
           

        </div>

         <div class="row margin-bottom-5">
    
        <div class="col-md-3">
    
            ÇALIŞACAĞI BİRİM
        </div>
        <div class="col-md-5">
        <asp:DropDownList ID="ddlBirim" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12"
                AutoPostBack="True" onselectedindexchanged="ddlBirim_SelectedIndexChanged">
        </asp:DropDownList>
           </div>
           

        </div>
       <div class="row margin-bottom-5" >
    
        <div class="col-md-3">
    
            VARSA ÇALIŞACAĞI ALT BİRİM
        </div>
        <div class="col-md-5">
        <asp:DropDownList ID="ddlAltBirim" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12">
        </asp:DropDownList>
           </div>
           

        </div>
             <div class="row margin-bottom-5">
    
        <div class="col-md-3">
    
            ÇALIŞMA ŞEKLİ
        </div>
        <div class="col-md-5">
        <asp:DropDownList ID="ddlCalismaSekli" runat="server" CssClass="btn btn-default dropdown-toogle col-md-12">
        </asp:DropDownList>
           </div>
           

        </div>

               <div class="row" >
    
        
        <div class="col-md-offset-7">
       
        <asp:Button ID="btnIseAl" runat="server"  Text="İşe Al" CssClass="btn btn-default" onclick="btnIseAl_Click"  />
       
           </div>
           

        </div>

        <div class="conteMin" style="width:750px">
    
        <div class="textBox">
    
          
        </div>
        <div class="textBox">
       
            <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
       
           </div>
           

        </div>
    </div></div>
</asp:Content>

