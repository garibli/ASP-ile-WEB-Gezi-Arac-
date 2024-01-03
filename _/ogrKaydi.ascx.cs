using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;


public partial class NewFolder1_WebUserControl : System.Web.UI.UserControl
{
    TurnaEntities turna = new TurnaEntities();
    VeriIslemleri veri = new VeriIslemleri();
    IsKurallari isKuarallar = new IsKurallari();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            veri.ddlVeriCekFakYukOkul(ddlFakYukOkul, "0");
           
            veri.ddlVeriCekFakYukOkul(ddlCapFak, "0");
           
        }
        
      
       

    }
    public void messagebox(string mesaj)
    {


        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }
    protected void txtTC_TextChanged(object sender, EventArgs e)
    {
        
    }

    protected void txtCep_TextChanged(object sender, EventArgs e)
    {
        
        
    }

    protected void btnGonder_Click(object sender, EventArgs e)
    {
        if (false/*(txtTC.Text[0].ToString() == "9" && txtTC.Text[1].ToString() == "9") || txtOgrNo.Text[0].ToString() == "u"*/)
        {
            lblBilgi.Text = "Kısmi zamanlı çalışma yönetmeliğine uymadığı için kaydınız alınamamaktadır. Yönetmelik için üstmenüden Yönetmelik sekmesine tıklayınız.";

        }
        else
        {


            if (ddlOgrenimTuru.SelectedValue != "-1" && txtAd.Text != "" && txtSoyad.Text != "" && (txtTC.Text.Count() == 11) && (txtOgrNo.Text.Count() == 10) && ddlBolum.SelectedValue != "-1" && ddlFakYukOkul.SelectedValue != "-1"
                && txtSifre.Text != "" && txtSifreDogrula.Text != "" && txtSifre.Text == txtSifreDogrula.Text &&
                ddlSinif.SelectedValue != "-1")
            {

                string tc = txtTC.Text;
                int tcToplam = 0;
                char[] tcSay = tc.ToCharArray();


                //for (int i = 0; i < 9; i++)
                //{
                //    tcToplam += Convert.ToInt16(tcSay[i].ToString());
                //}

                if (true)//tcToplam % 10 == tcSay[10])
                {
                    string mails = txtOgrNo.Text + "ogr.sakarya.edu.tr";

                    if (isKuarallar.mailSakaryaMi(mails, "ogr.sakarya.edu.tr"))
                    {
                        var ogrKayıtlımı = from ogr in turna.tblOgrenci
                                           where
                                               ogr.mail == mails ||
                                               ogr.ogrNo == txtOgrNo.Text ||
                                               ogr.tc == txtTC.Text

                                           select new { ogr.mail };

                        string mail = "-1";

                        foreach (var item in ogrKayıtlımı)
                        {
                            mail = item.mail;
                        }


                        if (mail == "-1")
                        {



                            try
                            {


                                int birim = Convert.ToInt16(ddlFakYukOkul.SelectedValue);
                                int bolum = Convert.ToInt16(ddlBolum.SelectedValue);
                                //int ogrenimTuru = -1;
                                //var ogrenimGetir = from birimler in turna.tblBirimler
                                //                   join bolumler in turna.tblBolumler
                                //                   on birimler.id equals bolumler.birimID
                                //                   where birimler.id == birim && bolumler.id == bolum
                                //                   select new { bolumler.ogrenimTuru };
                                //foreach (var item in ogrenimGetir)
                                //{
                                //    ogrenimTuru = item.ogrenimTuru.Value;
                                //}
                                

                                double notOrtalamasi = Convert.ToDouble(ddlNot1.SelectedValue + "," + ddlNot2.SelectedValue + ddlNot3.SelectedValue);


                                turna.ogrEkle(txtOgrNo.Text.ToLower(), txtAd.Text.ToUpper(), txtSoyad.Text.ToUpper(), txtSifre.Text, txtTC.Text, mails, txtCep.Text, Convert.ToInt16(ddlFakYukOkul.SelectedValue), Convert.ToInt16(ddlBolum.SelectedValue), ddlOgrenimTuru.SelectedValue, Convert.ToInt16(ddlCapFak.SelectedValue), Convert.ToInt16(ddlCapBolum.SelectedValue), ddlSinif.SelectedValue, Convert.ToDecimal(notOrtalamasi),null);
                                turna.ogrHesapNoGSSEkle(txtOgrNo.Text.ToLower(), txtIBAN.Text, ddlGSS2243.SelectedValue);
                                messagebox("Kaydınız başarılı bir şekilde oluşturuldu\n kaydınızı aktifleştirmek için mail adresinizi kontrol ediniz...\n Mail adresiniz"+mails+"");

                                lblBilgi.Text = txtTC.Text + " TC'li kişinin Kaydı başarılı bir şekilde oluşturuldu";

                                txtTC.Text = "";
                                txtAd.Text = "";
                                txtSoyad.Text = "";
                                txtIBAN.Text = "";
                                txtCep.Text = "";
                                txtMail.Text = "";
                                txtOgrNo.Text = "";
                                
                                ddlFakYukOkul.SelectedIndex = 0;
                                ddlGSS2243.SelectedIndex = 0;
                                ddlNot1.SelectedIndex=0;
                                ddlNot2.SelectedIndex=0;
                                ddlNot3.SelectedIndex=0;
                                ddlOgrenimTuru.SelectedIndex=0;
                                ddlSinif.SelectedIndex=0;


                                //Response.Redirect("./ogrEkrani");
                            }
                            catch (Exception)
                            {
                                lblBilgi.Text = "Verilerinizi Kontrol Ediniz...";

                            }

                        }

                        else
                        {
                            lblBilgi.Text = "Mail adresiniz sistemde kayıtlıdır...";
                        }
                    }
                    else
                    {
                        lblBilgi.Text = "Lütfen öğrenci mail adresinizi giriniz...";
                    }
                }
                else
                {
                    lblBilgi.Text = "tc numaranızı kontrol ediniz.";
                }
            }
            else
            {
                lblBilgi.Text = "Gerekli alanları doğru bir şekilde doldurunuz...";
            }
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if(CheckBox1.Checked)
        {
            ddlCapFak.Visible = true;
            ddlCapBolum.Visible = true;
        }
        else
        {
            ddlCapFak.Visible = false;
            ddlCapBolum.Visible = false;
        }
    }
    protected void ddlFakYukOkul_SelectedIndexChanged(object sender, EventArgs e)
    {
        veri.ddlVeriCekParamBolumlerGetir(ddlBolum,Convert.ToInt16(ddlFakYukOkul.SelectedValue));
    }
    protected void ddlCapFak_SelectedIndexChanged(object sender, EventArgs e)
    {
        veri.ddlVeriCekParamBolumlerGetir(ddlCapBolum, Convert.ToInt16(ddlCapFak.SelectedValue));
    }
}