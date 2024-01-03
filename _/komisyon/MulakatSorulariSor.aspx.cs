using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class komisyon_MulakatSorulariSor : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    
    static double soru1tut=0;
    static double soru2tut=0;
    static double soru3tut=0;
    static double soru4tut=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || (Session["yetkiID"].ToString() != "3"))
            Response.Redirect("../Default.aspx");
       
        string ogrMail= Session["ogrMailGetir"].ToString();
        int birimID = Convert.ToInt16(Session["birimID"]);
        if (!IsPostBack)
        {
            soru1tut = 0;
            soru2tut = 0;
            soru3tut = 0;
            soru4tut = 0;
        }

        var ogrBilgi = (from adSoyad in turna.tblOgrenci join birim in turna.tblBirimler on adSoyad.okulu equals birim.id where adSoyad.mail == ogrMail select new { adSoyad.ad, adSoyad.soyad, birim.adi }).FirstOrDefault();
        lblAdSoyad.Text = ogrBilgi.ad.ToString() + " " + ogrBilgi.soyad.ToString();
        lblBirim.Text = ogrBilgi.adi.ToString();

        var MulakatSorulari = (from mSorulari in turna.tblMulakatSorulari where mSorulari.birimID == birimID select new {mSorulari.soru1,mSorulari.soru2,mSorulari.soru3,mSorulari.soru4 ,mSorulari.PuanMiktari}).FirstOrDefault();
        lblBirimPuan.Text = MulakatSorulari.PuanMiktari.ToString();
        if (MulakatSorulari.soru1.ToString().Trim() != "") 
        {
            mulakatSoru1.Visible = true;
            lblMSoru1.Text = MulakatSorulari.soru1.ToString().Trim();
        }
        if (MulakatSorulari.soru2.ToString().Trim() != "")
        {
            mulakatSoru2.Visible = true;
            lblMsoru2.Text = MulakatSorulari.soru2.ToString().Trim();
        }
        if (MulakatSorulari.soru3.ToString().Trim() != "")
        {
            mulakatSoru3.Visible = true;
            lblMsoru3.Text = MulakatSorulari.soru3.ToString().Trim();
        }
        if (MulakatSorulari.soru4.ToString().Trim() != "")
        {
            mulakatSoru4.Visible = true;
            lblMsoru4.Text = MulakatSorulari.soru4.ToString().Trim();
        }
    
    }
    
    protected void ddlSoruCevap1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblEklenecekPuan.Text = (Convert.ToDouble(lblEklenecekPuan.Text) - (Convert.ToDouble(soru1tut) * Convert.ToDouble(lblBirimPuan.Text))).ToString();
        double secilenDeger = Convert.ToDouble(ddlSoruCevap1.SelectedValue)*Convert.ToDouble(lblBirimPuan.Text);
        secilenDeger = secilenDeger + Convert.ToDouble(lblEklenecekPuan.Text);
        lblEklenecekPuan.Text = Convert.ToDouble(secilenDeger).ToString();
        soru1tut = Convert.ToDouble(ddlSoruCevap1.SelectedValue);
        if (20 < Convert.ToDouble(lblEklenecekPuan.Text)) { lblEklenecekPuan.Text = "20"; }
       
    }
    protected void ddlSoruCevap2_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblEklenecekPuan.Text = (Convert.ToDouble(lblEklenecekPuan.Text) - (Convert.ToDouble(soru2tut) * Convert.ToDouble(lblBirimPuan.Text))).ToString();
        double secilenDeger = Convert.ToDouble(ddlSoruCevap2.SelectedValue) * Convert.ToDouble(lblBirimPuan.Text);
        secilenDeger = secilenDeger + Convert.ToDouble(lblEklenecekPuan.Text);
        lblEklenecekPuan.Text = Convert.ToDouble(secilenDeger).ToString();
        soru2tut = Convert.ToDouble(ddlSoruCevap2.SelectedValue);
        if (20 < Convert.ToDouble(lblEklenecekPuan.Text)) { lblEklenecekPuan.Text = "20"; }
       
    }
    protected void ddlSoruCevap3_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblEklenecekPuan.Text = (Convert.ToDouble(lblEklenecekPuan.Text) - (Convert.ToDouble(soru3tut) * Convert.ToDouble(lblBirimPuan.Text))).ToString();
        double secilenDeger = Convert.ToDouble(ddlSoruCevap3.SelectedValue) * Convert.ToDouble(lblBirimPuan.Text);
        secilenDeger = secilenDeger + Convert.ToDouble(lblEklenecekPuan.Text);
        lblEklenecekPuan.Text = Convert.ToDouble(secilenDeger).ToString();
        soru3tut = Convert.ToDouble(ddlSoruCevap3.SelectedValue);
        if (20 < Convert.ToDouble(lblEklenecekPuan.Text)) { lblEklenecekPuan.Text = "20"; }
       
    }
    protected void ddlSoruCevap5_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblEklenecekPuan.Text = (Convert.ToDouble(lblEklenecekPuan.Text) - (Convert.ToDouble(soru4tut) * Convert.ToDouble(lblBirimPuan.Text))).ToString();
        double secilenDeger = Convert.ToDouble(ddlSoruCevap5.SelectedValue) * Convert.ToDouble(lblBirimPuan.Text);
        secilenDeger = secilenDeger + Convert.ToDouble(lblEklenecekPuan.Text);
        lblEklenecekPuan.Text = Convert.ToDouble(secilenDeger).ToString();
        soru4tut = Convert.ToDouble(ddlSoruCevap5.SelectedValue);
        if (20 < Convert.ToDouble(lblEklenecekPuan.Text)) { lblEklenecekPuan.Text = "20"; }
       
    }
    protected void btnPuanVer_Click(object sender, EventArgs e)
    {
        Session["soruKontrol"] = '1';
        int basvurusu = Convert.ToInt16(Session["basvuru"]);
        string ogrMail = Session["ogrMailGetir"].ToString();
       
        
            var ogrenci = (from ogr in turna.tblOgrenciAnketCevablari where ogr.ogrMail == ogrMail select new { ogr.anketPuani1, ogr.anketPuani2,ogr.anketPuani3 }).FirstOrDefault();
            int ogrPuanToplam = Convert.ToInt16(ogrenci.anketPuani1) + Convert.ToInt16(ogrenci.anketPuani2) +Convert.ToInt16(ogrenci.anketPuani3)+ Convert.ToInt16(lblEklenecekPuan.Text);



            var ogrNo = (from ogr in turna.tblOgrenci where ogr.mail == ogrMail select new { ogr.ogrNo }).FirstOrDefault();
            string no = ogrNo.ogrNo.ToString();

            tblOgrBasvuruBilgileri ogrToplam = turna.tblOgrBasvuruBilgileri.First(k => k.ogrNo == no);
            ogrToplam.ToplamPuan = Convert.ToInt16(ogrPuanToplam);
           // ogrToplam.MulakatSoruldumu = 1;
            turna.SaveChanges();
            Response.Redirect("../komisyon/OgrenciBasvuru.aspx");
        }
    
}