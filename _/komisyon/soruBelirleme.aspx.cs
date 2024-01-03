using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class komisyon_soruBelirleme : System.Web.UI.Page
{

    static int a = 0;
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblSoruSayisiHesapla.Text = "0";
        int birimID = Convert.ToInt16(Session["birimID"]);
        if (!IsPostBack) { }
        try
        {
            var mSoruSoranID = (from mSoruKisisi in turna.tblMulakatSorulari where mSoruKisisi.birimID == birimID select new { mSoruKisisi.komisyonID }).FirstOrDefault();
            int kisiID = Convert.ToInt16(mSoruSoranID.komisyonID);
            var kisiGetir = (from kisiAdi in turna.tblPersonel where kisiAdi.id == kisiID select new { kisiAdi.adi, kisiAdi.soyad }).FirstOrDefault();
            lblKomisyonAdSoyad.Text = kisiGetir.adi.ToString() + kisiGetir.soyad.ToString();
            ikinciKutu.Visible = false;
        }
        catch
        {
            if (!IsPostBack)
            {
                ilkKutu.Visible = false;
                sorularıBelirle2.Visible = false;
                sorularıBelirle3.Visible = false;
                sorularıBelirle4.Visible = false;
                soru1Gor.Visible = false;
                soru2Gor.Visible = false;
                soru3Gor.Visible = false;
                soru4Gor.Visible = false;
                lblSoruSayisiHesapla.Text = a.ToString();
                return;
            }

        }
    }
    protected void btnEkle1_Click(object sender, EventArgs e)
    {
        if (txtSoru1.Text.Trim() == "")
        {
            messagebox("Soruyu Girin. Sonra EKLE butonuna tıklayın!!!");
        }
        else
        {
            a = a + 1;
            lblSoruSayisiHesapla.Text = a.ToString();
            lblSoruEkle1.Text = txtSoru1.Text;
            soru1Gor.Visible = true;
            sorularıBelirle2.Visible = true;
        }
    }


    protected void btnEkle2_Click(object sender, EventArgs e)
    {
        if (txtSoru2.Text.Trim() == "")
        {
            messagebox("Soruyu Girin. Sonra EKLE butonuna tıklayın!!!");
        }
        else
        {
            a = a + 1;
            lblSoruSayisiHesapla.Text = a.ToString();
            lblSoruEkle2.Text = txtSoru2.Text;
            soru2Gor.Visible = true;
            sorularıBelirle3.Visible = true;
        }

    }
    protected void btnEkle3_Click(object sender, EventArgs e)
    {
        if (txtSoru3.Text.Trim() == "")
        {
            messagebox("Soruyu Girin. Sonra EKLE butonuna tıklayın!!!");
        }
        else
        {
            a = a + 1;
            lblSoruSayisiHesapla.Text = a.ToString();
            lblSoruEkle3.Text = txtSoru3.Text;
            soru3Gor.Visible = true;
            sorularıBelirle4.Visible = true;
        }

    }
    protected void btnEkle4_Click(object sender, EventArgs e)
    {
        if (txtSoru4.Text.Trim() == "")
        {
            messagebox("Soruyu Girin. Sonra EKLE butonuna tıklayın!!!");
        }
        else
        {
            a = a + 1;
            lblSoruSayisiHesapla.Text = a.ToString();
            lblSoruEkle4.Text = txtSoru4.Text;
            soru4Gor.Visible = true;
            messagebox("Son sorunuzu eklediniz. Limitiniz dolmuştur!!");

        }

    }



    public void messagebox(string mesaj)
    {


        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }
    protected void btnCikar1_Click(object sender, EventArgs e)
    {

        a = a - 1;
        lblSoruSayisiHesapla.Text = a.ToString();
        lblSoruEkle1.Text = "";
        soru1Gor.Visible = false;

    }
    protected void btnCikar2_Click(object sender, EventArgs e)
    {
        a = a - 1;
        lblSoruSayisiHesapla.Text = a.ToString();
        lblSoruEkle2.Text = "";
        soru2Gor.Visible = false;
    }
    protected void btnCikar3_Click(object sender, EventArgs e)
    {
        a = a - 1;
        lblSoruSayisiHesapla.Text = a.ToString();
        lblSoruEkle3.Text = "";
        soru3Gor.Visible = false;
    }
    protected void btnCikar4_Click(object sender, EventArgs e)
    {
        a = a - 1;
        lblSoruSayisiHesapla.Text = a.ToString();
        lblSoruEkle4.Text = "";
        soru4Gor.Visible = false;
    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        if (a == 0) { messagebox("Sorunuz Bulunmamaktadır. TEKRAR kontrol edin!!"); }
        else
        {
            double soruPuanTut = 0;
            if (a == 1)
            {
                soruPuanTut = 4;
            }
            else if (a == 2)
            {
                soruPuanTut = 2;
            }
            else if (a == 3)
            {
                soruPuanTut = 1.34;
            }
            else
            {
                soruPuanTut = 1;
            }

            string soru1 = lblSoruEkle1.Text.ToString();
            string soru2 = lblSoruEkle2.Text.ToString();
            string soru3 = lblSoruEkle3.Text.ToString();
            string soru4 = lblSoruEkle4.Text.ToString();
            int persID=Convert.ToInt16(Session["persID"]);
            int birimID = Convert.ToInt16(Session["birimID"]);
            tblMulakatSorulari sorulariEkle = new tblMulakatSorulari
            {
                komisyonID=Convert.ToInt16(persID),
                soru1 = soru1.ToString(),
                soru2 = soru2.ToString(),
                soru3 = soru3.ToString(),
                soru4 = soru4.ToString(),
                PuanMiktari = Convert.ToDecimal(soruPuanTut),
                birimID=birimID
            };
            turna.tblMulakatSorulari.AddObject(sorulariEkle);
            turna.SaveChanges();
            a = 0;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
   
    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        Response.Redirect("../komisyon/SoruGuncelle.aspx");
    }
}