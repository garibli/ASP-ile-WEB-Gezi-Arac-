<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="isTakip.aspx.cs" Inherits="SKSEkrani_isTakip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
    <div class="row">
        <div class="col-md-3">İŞ BAŞLIĞI</div>
        <div class="col-md-3">
            <asp:TextBox ID="txtIsBasligi" runat="server" CssClass="form-control"></asp:TextBox></div>
    </div>
    <div class="row margin-top-10">
        <div class="col-md-3">İŞ İÇERİK</div>
        <div class="col-md-3">
            <asp:TextBox ID="txtIsIcerik" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox></div>
    </div>
      <div class="row margin-top-10 margin-bottom-25">
        <div class="col-md-3">İŞ ACİLLİĞİ</div>
        <div class="col-md-3">
            <asp:DropDownList ID="ddrAcillik" runat="server" CssClass="form-control">
            <asp:ListItem Value="1">ACİL</asp:ListItem>
            <asp:ListItem Value="2">ORTA ACİLLİKTE</asp:ListItem>
            <asp:ListItem Value="3">ACİL DEĞİL</asp:ListItem>
            </asp:DropDownList>
    </div>
    </div>
    <div class="row margin-top-10 margin-bottom-25">
        <div class="col-md-3"></div>
        <div class="col-md-3">
            <asp:Button ID="btnKaydet" runat="server" Text="KAYDET" 
                CssClass="btn btn-primary" onclick="btnKaydet_Click"/>
    </div>
    </div>
</div>
<hr />
<div class="container margin-top-20 margin-bottom-10" style="color:Blue"><div class="col-md-6" style="font-size:larger"><strong class="col-md-offset-2">DEVAM EDEN İŞLER </strong></div><div class="col-md-6" style="font-size:larger"><strong class="col-md-offset-2"> </strong></div></div>
<div class="container">
    <div class="col-md-6">
        <asp:DataList ID="dtListIsTakip" runat="server" 
            onitemcommand="dtListIsTakip_ItemCommand" >
            <ItemTemplate>
            <div class="col-md-11" >
            <div class="tab-content">
						<div id="tab_1" class="tab-pane active">
							<div id="accordion1" class="panel-group">
								<div class="panel panel-success" style="width:450px">
									<div class="panel-heading" >
										<h4 class="panel-title">
										<a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion1" href='#<%#Eval("id") %>'>
										<strong ><%#Eval("isBaslik")%></strong> </a>
										</h4>
									</div>
									<div id="<%#Eval("id") %>" class="panel-collapse collapse">
										<div class="panel-body">
											<%#Eval("isIcerik")%>
                                            <br />
                                            <br />
                                            <table class="margin-top-10">
                                            <tr>
                                            <td class="col-md-1"><%#Eval("tarih")%></td>
                                            <td class="col-md-1"><%#Eval("isAcillik")%></td>
                                            <td class="col-md-1"><%#Eval("kontrol")%></td>
                                            
                                            </tr>
                                            <tr>
                                            
                                            </tr>
                                            <tr>
                                              <td>
                                              <br />
                                              <br />
                                              <asp:LinkButton ID="lnkIsKaldir" runat="server" CssClass="btn btn-default" CommandArgument='<%#Eval("id") %>'>KALDIR</asp:LinkButton> </td>
                                            </tr>
                                            </table>
                                            
										</div>
									</div>
								</div>
								
							</div>
						</div>
						
								
						
								
								
							</div>
						</div>
            </ItemTemplate>
        </asp:DataList>
    </div>
    
   
</div>
</asp:Content>

