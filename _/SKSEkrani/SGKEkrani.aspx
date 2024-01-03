<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="SGKEkrani.aspx.cs" Inherits="SKSEkrani_SGKEkrani" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
    <style type="text/css">
        #iframeMap
        {
            height: 420px;
            width: 769px;
        }
        #btnLogin
        {
            width: 71px;
            
        }
    </style>

    <script src="../JScript/jquery-1.9.1.js" type="text/javascript"></script>
    
        <script type="text/javascript">
            function ilkFonksiyonumuz() {

                alert("deneme");
               // $('#iframeMap').contents().find("a").css("background-color", "#BADA55");
                //  $('#iframeMap').contents().find("body").html("htmlllsadlasldl");
               
           }
        
        
        
        </script>  
    
    
    
    
    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<?php
   header('Location: https://uyg.sgk.gov.tr/SigortaliTescil/amp/loginldap'); 
?>
<%--<%:Page.Header.GetRouteUrl('X-Frame-Options: ALLOW-FROM https://uyg.sgk.gov.tr/SigortaliTescil/amp/loginldap') %>--%>
<iframe src="https://uyg.sgk.gov.tr/SigortaliTescil/amp/loginldap" id="iframeMap" onload='iframeLoaded()' ></iframe>


        <script type="text/javascript">
            function iframeLoaded() {
                var iFrameID = document.getElementById('idIframe');
                if (iFrameID) {
                    iFrameID.height = "";
                    if (iFrameID.contentWindow.document.body.scrollHeight < 500) {
                        iFrameID.height = "500px";
                    } else {
                        iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
                    }
                }
            }
            </script>


         <script type="text/javascript">

             $(document).ready(function () {

                 $("#man").click(function () {


                     var deneme = "111";

                     $("input:text").val("5555");
                     $("#txt2").val(deneme);
                     $('#iframeMap').contents().find("a").css("background-color", "#BADA55");
                     $('#iframeMap').contents().find("body").html("htmlllsadlasldl");
                     $('#iframeMap').contents().find("input:text").val("111");

                 });

                 return false;
             });

             
             function man_onclick() {

             }

         </script>    



       

    <br />
    <input name="man" id="man" type="button" value="button" onclick="return man_onclick()" />
     <input type="text" name="txt2" id="txt2" />
     
     
    <asp:TextBox ID="txt1" runat="server"></asp:TextBox>

</asp:Content>

