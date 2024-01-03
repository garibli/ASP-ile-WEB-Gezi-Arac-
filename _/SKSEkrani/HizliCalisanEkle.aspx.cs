using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_HizliCalisanEkle : System.Web.UI.Page
{

    TurnaEntities turna = new TurnaEntities();
    VeriIslemleri veri = new VeriIslemleri();
    IsKurallari isKuarallar = new IsKurallari();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
        }
        
        if (!IsPostBack)
        {
            veri.ddlVeriCekFakYukOkul(ddlFakYukOkul, "0");

            veri.ddlVeriCekFakYukOkul(ddlCapFak, "0");

        }
        

    }
    protected void btnGonder_Click(object sender, EventArgs e)
    {

        if ((txtTC.Text[0].ToString() == "9" && txtTC.Text[1].ToString() == "9") || txtOgrNo.Text[0].ToString() == "u")
        {
            lblBilgi.Text = "Kısmi zamanlı çalışma yönetmeliğine uymadığı için kaydınız alınamamaktadır. Yönetmelik için üstmenüden Yönetmelik sekmesine tıklayınız.";

        }
        else
        {

              if (ddlOgrenimTuru.SelectedValue != "-1" && txtAd.Text != "" && txtSoyad.Text != "" && (txtTC.Text.Count() == 11) && (txtOgrNo.Text.Count() == 10) && ddlBolum.SelectedValue != "-1" && ddlFakYukOkul.SelectedValue != "-1"
                && ddlSinif.SelectedValue != "-1")
            {


                if (isKuarallar.mailSakaryaMi(txtMail.Text, "ogr.sakarya.edu.tr"))
                {
                    var ogrKayıtlımı = from ogr in turna.tblOgrenci
                                       where
                                           ogr.mail == txtMail.Text ||
                                           ogr.ogrNo == txtOgrNo.Text ||
                                           ogr.tc == txtTC.Text

                                       select new { ogr.mail };

                    string mail = "-1";

                    foreach (var item in ogrKayıtlımı)
                    {
                        mail = item.mail;
                    }

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


                            turna.ogrEkle(txtOgrNo.Text, txtAd.Text, txtSoyad.Text, "123", txtTC.Text, txtMail.Text, txtCep.Text, Convert.ToInt16(ddlFakYukOkul.SelectedValue), Convert.ToInt16(ddlBolum.SelectedValue), ddlOgrenimTuru.SelectedValue, Convert.ToInt16(ddlCapFak.SelectedValue), Convert.ToInt16(ddlCapBolum.SelectedValue), ddlSinif.SelectedValue, Convert.ToDecimal(notOrtalamasi),txtMail.Text);
                            turna.ogrHesapNoGSSEkle(txtOgrNo.Text, txtIBAN.Text, ddlGSS2243.SelectedValue);

                            txtAd.Text = "";
                            txtCep.Text = "";
                            txtIBAN.Text = "";
                            txtMail.Text = "";
                            txtOgrNo.Text = "";
                            txtSoyad.Text = "";
                            txtTC.Text = "";

                            lblBilgi.Text = "Kayıt gerçekleştirildi. Kişi sisteme girerken öğrenci mail adresini ve şifre olarakda 123 yazarak girebilir...";


                        }
                        catch (Exception)
                        {
                            lblBilgi.Text = "Verilerinizi Kontrol Ediniz...";

                        }

                    }

                    else
                    {
                        lblBilgi.Text = "Sistemde kayıtlısınız...";
                    }
                }
                else
                {
                    lblBilgi.Text = "Lütfen öğrenci mail adresinizi giriniz...";
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
        if (CheckBox1.Checked)
        {
            ddlCapFak.Enabled = true;
            ddlCapBolum.Enabled = true;
        }
        else
        {
            ddlCapFak.Enabled = false;
            ddlCapBolum.Enabled = false;
        }
    }
    protected void ddlFakYukOkul_SelectedIndexChanged(object sender, EventArgs e)
    {
        veri.ddlVeriCekParamBolumlerGetir(ddlBolum, Convert.ToInt16(ddlFakYukOkul.SelectedValue));
  
    }
    protected void ddlCapFak_SelectedIndexChanged(object sender, EventArgs e)
    {
        veri.ddlVeriCekParamBolumlerGetir(ddlCapBolum, Convert.ToInt16(ddlCapFak.SelectedValue));
   
    }
}