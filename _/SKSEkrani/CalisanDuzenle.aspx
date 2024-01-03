<%@ Page Title="" Language="C#" MasterPageFile="~/SKSEkrani/MasterPage.master" AutoEventWireup="true" CodeFile="CalisanDuzenle.aspx.cs" Inherits="SKSEkrani_SilmeIslemleri_CalisanSil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div class="container">
   <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Calisan ID</div>
        <div class="col-md-5">
            <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox></div>
        <div class="uyari">
            
         </div>
     </div>
     <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">T.C Kimlik Numaranız</div>
        <div class="col-md-5">
            <asp:TextBox ID="txtTC" runat="server" MaxLength="11" 
                CssClass="form-control"></asp:TextBox></div>
        <div class="uyari">
            
         </div>
     </div>
     <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Öğrenci Numaranız</div>
        <div class="col-md-5">
            <asp:TextBox ID="txtOgrNo" runat="server" MaxLength="10" CssClass="form-control" Enabled="False"></asp:TextBox></div>
        <div class="uyari">
            
         </div>
    </div>
    <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Adınız</div>
        <div class="col-md-5"><asp:TextBox ID="txtAd" runat="server" MaxLength="30" CssClass="form-control"></asp:TextBox></div>
        <div class="uyari">
        </div>
    </div>
    <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Soyadınız</div>
        <div class="col-md-5"><asp:TextBox ID="txtSoyad" runat="server" MaxLength="15" CssClass="form-control"></asp:TextBox></div>
        <div class="uyari">
        </div>
    </div>
    
    <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Mail Adresiniz</div>
        <div class="col-md-5"><asp:TextBox ID="txtMail" runat="server" MaxLength="50" CssClass="form-control"></asp:TextBox></div>
        <div class="uyari">
        </div>
    </div>
    <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Cep Numaranız</div>
        <div class="col-md-5">
            <asp:TextBox ID="txtCep" runat="server" MaxLength="10" 
                CssClass="form-control"></asp:TextBox></div>
        <div class="uyari">
            
         </div>
    </div>
    <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Fakülte/Yuksekokul</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlFakYukOkul" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlFakYukOkul_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="uyari">
        </div>
    </div>
    <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Bölümünüz</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlBolum" runat="server" CssClass="form-control">
            </asp:DropDownList>
            </div>
        <div class="uyari">
        </div>
    </div>

    <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Öğrenim Türü</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlOgrenimTuru" runat="server" CssClass="form-control">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="1">Önlisans</asp:ListItem>
                <asp:ListItem Value="2">Lisans</asp:ListItem>
                <asp:ListItem Value="3">Yüksek Lisans</asp:ListItem>
                <asp:ListItem Value="4">Doktora</asp:ListItem>
            </asp:DropDownList>
            </div>
        <div class="uyari">
        </div>
    </div>
    <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Sınıfınız</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlSinif" runat="server" CssClass="form-control">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
            </asp:DropDownList>
            </div>
        <div class="uyari">
        </div>
    </div>
    <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Not Ortalamanız</div>
        <div class="col-md-6">
            <asp:DropDownList ID="ddlNot1" runat="server" CssClass="btn btn-default dropdown-toggle col-md-2">
                <asp:ListItem Selected="True">0</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
            </asp:DropDownList>
<div class="col-md-1"><strong>,</strong></div>
            <asp:DropDownList ID="ddlNot2" runat="server" CssClass="btn btn-default dropdown-toggle col-md-2">
                <asp:ListItem Selected="True">0</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlNot3" runat="server" CssClass="btn btn-default dropdown-toggle col-md-2 ">
                <asp:ListItem Selected="True">0</asp:ListItem>
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
                <asp:ListItem>6</asp:ListItem>
                <asp:ListItem>7</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>9</asp:ListItem>
            </asp:DropDownList>
            </div>
        <div class="uyari">
        </div>
    </div>
    <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Sifre</div>
        <div class="col-md-5"><asp:TextBox ID="txtSifre" runat="server" MaxLength="8" 
               CssClass="form-control"></asp:TextBox></div>
        <div class="uyari">
        </div>
    </div>
    
    
    <div class="row" style="margin-bottom:2px">
    <div class="col-md-3">Cap Yapıyormusunuz:</div>
    <div class="col-md-5"> 
        <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" />
     </div>
    <div class="uyari"></div>
        </div>
     <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Çap Fakülte/Yuksekokul</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlCapFak" runat="server" CssClass="form-control"
                Enabled="False" OnSelectedIndexChanged="ddlCapFak_SelectedIndexChanged" 
                AutoPostBack="True">
            </asp:DropDownList>
        </div>
        <div class="uyari">
        </div>
    </div>
    <div class="row" style="margin-bottom:2px">
        <div class="col-md-3">Çap Bölümünüz</div>
        <div class="col-md-5">
            <asp:DropDownList ID="ddlCapBolum" runat="server" CssClass="form-control"
                Enabled="False">
                <asp:ListItem Selected="True" Value="-1">SEÇİNİZ</asp:ListItem>
            </asp:DropDownList>
            </div>
        <div class="uyari">
        </div>
    </div>
    
     <div class="row" style="margin-bottom:2px">
        <div class="col-md-3"></div>
        <div class="col-md-2">
            
            <asp:Button ID="btnGuncelle" runat="server" CssClass="btn btn-default col-md-12" Text="Güncelle" 
                OnClick="btnGonder_Click" />
           </div>
           <div class="col-md-2">
            <asp:Button ID="btnSil" runat="server" CssClass="btn red col-md-12" Text="Sil"  OnClick="btnSil_Click " />
            
            </div>
        <div class="uyari"></div>
    </div>
    <div class="container" style="margin-top:70px;margin-bottom:20px">
        <div class="col-md-3"></div>
        <div class="col-md-5">
            <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
        </div>
        
    </div>
</div>
   
    <hr />
    <div class="row">
    <div class=" col-md-3">
    Okuduğu Okula Göre Listele</div>
    <div class="col-md-5">
    <asp:DropDownList ID="ddlBirim" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlBirim_SelectedIndexChanged" CssClass="form-control">
    </asp:DropDownList>
    </div>
    </div>
    <br />
    <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
        ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" CssClass="table "
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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



    </asp:Content>

