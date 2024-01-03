<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="userControl_Login" %>
<style>
     .conteMain{
         height:auto;
         width:350px;
         float:left;
     }
    .conteMin {
        height:20px;
        width:350px;
        margin-top:5px;  
        float:left;    
    }
    .conteMinAciklama {
        height:140px;
        width:533px;
        margin-top:5px;      
    }
     .Aciklama{
       
        height:20px;
        width:100px;
        float:left;
       
    }
     .textBox{
        height:20px;
        width:218px;
        float:left;
    }
  
    .uyari{
        height:20px;
        width:160px;
        float:left;
        
    }
    .gonderBtn{
        float:right;
        height:20px;
        width:80px;
    }
    .aciklama2{
        height:135px;
        width:218px;
        
        float:left;
        }
   .satir{
       margin-top:5px;
   }
</style>
 <div class="row">
        <div class=" col-md-offset-4 col-md-4 ">
          <!-- BEGIN SAMPLE FORM PORTLET-->
          <div class="portlet box blue">
            <div class="portlet-title">
              <div class="caption">
               GİRİŞ
              </div>
            </div>
            <div class="portlet-body form">
              <form role="form">
                <div class="form-body">
                  <div class="form-group">
                    <label>Mail Adresi</label>
                    <div class="input-group">
                    <asp:TextBox ID="txtMail" CssClass="form-control" runat="server" placeholder="Email Address"></asp:TextBox>
                     
                      <span class="input-group-addon">
                        <i class="fa fa-envelope"></i>
                      </span>
                    </div>
                  </div>
                  <div class="form-group">
                    <label for="exampleInputPassword1">Şifre</label>
                    <div class="input-group">
                     <asp:TextBox ID="txtSifre" cssClass="form-control" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                     
                      <span class="input-group-addon">
                        <i class="fa fa-user"></i>
                      </span>
                    </div>
                  </div>
                  </div>
               <asp:Label ID="lblBilgi" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                <div class="form-actions">
                   <asp:Button ID="btnGonder" runat="server" CssClass="btn blue"  Text="Gönder" OnClick="btnGonder_Click" />
                  <a  class="btn btn-default" href="http://skscalisma.sakarya.edu.tr/OgrKaydiGiris.aspx" >Vazgeç</a>
                <a href="#" class="btn btn-warning col-md-offset-3">Şifremi unuttum</a>
                
                </div>
              </form>
              </div>
            </div>
            </div>
          </div>
          <!-- END SAMPLE FORM PORTLET-->
