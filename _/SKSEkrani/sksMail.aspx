<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="sksMail.aspx.cs" Inherits="SKSEkrani_sksMail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="container">
        <div class="col-md-3">
            
        <div class=" row margin-bottom-20 margin-top-20 col-md-offset-1" style="font-size:larger">
            <strong>
                 <asp:CheckBox ID="chkHepsiSec" runat="server" AutoPostBack="true"
                oncheckedchanged="chkHepsiSec_CheckedChanged" />&nbsp;&nbsp;&nbsp;HEPSİ
            </strong>
        </div>
        
            <asp:DataList ID="dtListPersonel" runat="server" CssClass="table" 
                onitemcommand="dtListPersonel_ItemCommand">
                <ItemTemplate>
                    <table style="font-size:small">
                        <tr>
                            <td>
                              <asp:LinkButton ID="lnkSec" runat="server" CommandArgument='<%#Eval("mail") %>' >Sec</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                             
                                <%#Eval("adi") %>&nbsp;&nbsp; <%#Eval("soyad") %><br />
                                 ( <%#Eval("mail") %>)
                                </td>
                            
                             </tr>
                           
                    </table>
                </ItemTemplate>
            </asp:DataList>
            
        </div>
        <div class="col-md-3">
        <div class="row" style="margin-top:20px">
                                
                               <div class="col-md-11">
                               <div class="margin-bottom-20" style="font-size:larger"><center><strong>KİME</strong></center></div>
                                    <asp:ListBox ID="lstBoxMails" runat="server" CssClass="form-control " 
                                       Height="400px" SelectionMode="Multiple"></asp:ListBox>
                                       
                                   <asp:Button ID="btnCıkar" runat="server" Text="CIKAR" 
                                       CssClass="btn btn-default margin-top-10 col-md-offset-8" 
                                       onclick="btnCıkar_Click" />

                                  </div>
             </div>
        </div>
        <div class="col-md-6">
        <div class="row margin-bottom-15" style="font-size:larger;margin-top:20px"><strong><center>MAİL BİLGİSİ</center></strong></div>
			                    <div class="row margin-bottom-10">
										        <label class="col-md-10"><asp:Label ID="lblUyari" runat="server" Text="" Visible="false"></asp:Label></label>
                                                
										</div>
                        
                                        <div class="row margin-bottom-10">
										        <label class="col-md-2">Baslık</label>
                                                <div class="col-md-9">
                                                 <asp:TextBox ID="txtKonu" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                                                 </div>
										</div>
                                        <div class="row margin-bottom-25">
										        <label class="col-md-2">Icerik</label>
                                                <div class="col-md-9">
                                                 <asp:TextBox ID="txtIcerik" runat="server" CssClass="form-control" TextMode="MultiLine" Height="150px"></asp:TextBox>
										        </div>
                                        </div>
                                        <div class="row margin-bottom-25">
										        <label class="col-md-2">Mail Şifre</label>
                                                <div class="col-md-9">
                                                 <asp:TextBox ID="txtSifre" runat="server" CssClass="form-control" TextMode="SingleLine"  placeholder="Mail şifrenizi giriniz. Şifreniz kayıt altına alınmamaktadır"></asp:TextBox>
										        </div>
                                        </div>
                                        <div class="row">
                                        <div class="col-md-3 col-md-offset-5">
                                            <asp:Button ID="btnGonder" runat="server" Text="GÖNDER" 
                                                CssClass="btn btn-primary" onclick="btnGonder_Click" /></div>
                                         <div class="col-md-2">
                                            <asp:Button ID="btnVazgec" runat="server" Text="VAZGEÇ" CssClass="btn red" /></div>
                                         </div>   
									</div>
                        </div>
                    
                
		
</asp:Content>

