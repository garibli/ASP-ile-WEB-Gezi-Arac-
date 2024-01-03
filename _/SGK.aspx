<%@ Page Title="" Language="C#" MasterPageFile="~/OgrMaster.master" AutoEventWireup="true" CodeFile="SGK.aspx.cs" Inherits="SGK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<iframe src="https://uyg.sgk.gov.tr/SigortaliTescil/amp/loginldap" id="iframeMap" 
        onload='iframeLoaded()' style="width: 800px; height: 500px" ></iframe>


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

