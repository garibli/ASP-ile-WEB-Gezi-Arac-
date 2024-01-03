<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="PersonelListele.aspx.cs" Inherits="SKSEkrani_PersonelListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>

    <script type="text/javascript" charset="utf8" src="//cdn.datatables.net/1.10.2/js/jquery.dataTables.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 
    <div class="container">
    <div class="row">
        <div class="col-md-2" style="font-size:larger;margin-top:6px;text-align:center">Birime Göre Listele</div>
        <asp:DropDownList ID="ddlBirim" runat="server" AutoPostBack="True" CssClass="btn btn-default dropdown-toggle col-md-5"
            onselectedindexchanged="ddlBirim_SelectedIndexChanged" Width="220px">
        </asp:DropDownList>
    </div>
    </div>
    <div class="container margin-top-20">
    <div class="col-md-12 list-group">
        <asp:DataList ID="DtListPersonel" runat="server" >
            <HeaderTemplate>
            <div  class="col-md-12 list-group-item active">
                <table id="dt1">
                    <tr>
                        <td  style="width:120px">
                            persTC</td>
                        <td  style="width:140px">
                            AD</td>
                        <td  style="width:140px">
                            SOYAD</td>
                        <td style="width:190px">
                            MAİL</td>
                        <td  style="width:100px">
                            DAHİLİ No</td>
                        <td  style="width:200px">
                           BİRİM ADI</td>
                        <td  style="width:40px;text-align:right">
                           yetkiID</td>
                    </tr>
                </table>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
            <div class="col-md-12 list-group-item">
                <table >
                    <tr>
                        <td  style="font-size:smaller;width:120px"><%#Eval("persTC")%>
                            </td>
                        <td  style="font-size:small;width:140px"><%#Eval("adi")%>
                            </td>
                        <td  style="font-size:small;width:140px"><%#Eval("soyad")%>
                           </td>
                        <td style="font-size:smaller;width:190px"><%#Eval("mail")%>
                           </td>
                        <td  style="font-size:small;width:100px"><%#Eval("dahiliNo")%>
                            </td>
                        <td  style="font-size:smaller;width:200px"><%#Eval("birimAdi")%>
                           </td>
                        <td  style="font-size:small;width:40px;text-align:right"><%#Eval("yetkiID")%>
                            </td>
                    </tr>
                </table>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#dt1').dataTable({
                "language": {
                    "lengthMenu": "Sayfa başı _MENU_ kayıt görüntüle",
                    "zeroRecords": "Hiç birşey bulunamadı - üzgünüm",
                    "info": "Gösterilen sayfa _PAGE_ de _PAGES_",
                    "infoEmpty": "Hiç bir kayıda ulaşılamıyor.",
                    "infoFiltered": "(Toplam _MAX_ kayıttan filtrelenen)"
                }
            });
           


        });


    </script>



</asp:Content>

