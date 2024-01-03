using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_AltBolumKontenjanBelirle : System.Web.UI.Page
{
    public void gridViewGuncelle()
    {
      

        TurnaEntities turna = new TurnaEntities();

        var bolumGetir = from birimler in turna.tblBirimler
                         join bolumler in turna.tblBolumler
                         on birimler.id equals bolumler.birimID
                         orderby birimler.adi ascending, bolumler.adi ascending
                         select new { birimler.id, birimler.adi, bolumID = bolumler.id, bolumAdi = bolumler.adi, bolumler.AkademiKon,bolumler.IdariKon };

           
      
        if (ddlBirim.SelectedValue != "" && ddlBirim.SelectedValue != "-1")
        
        {

            int birimID = Convert.ToInt16(ddlBirim.SelectedValue);

            bolumGetir = from birimler in turna.tblBirimler
                         join bolumler in turna.tblBolumler
                         on birimler.id equals bolumler.birimID
                         where birimler.id == birimID
                         orderby birimler.adi ascending, bolumler.adi ascending
                         select new { birimler.id, birimler.adi, bolumID = bolumler.id, bolumAdi = bolumler.adi, bolumler.AkademiKon, bolumler.IdariKon };

         

        }

        
        GridViewBolum.DataSource = bolumGetir.ToList();
        GridViewBolum.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
        }


        VeriIslemleri veri = new VeriIslemleri();

        if (!IsPostBack)
            veri.ddlVeriCekBirimler(ddlBirim);

        gridViewGuncelle();

    }


    protected void btnGir_Click(object sender, EventArgs e)
    {



        TurnaEntities turna = new TurnaEntities();




        try
        {


            int bolumID = Convert.ToInt16(ddlAltBolum.SelectedValue);

            tblBolumler bolumKonGuncelle = turna.tblBolumler.First(n => n.id == bolumID);

            bolumKonGuncelle.AkademiKon = Convert.ToInt16(txtAkademiKon.Text);
            bolumKonGuncelle.IdariKon = Convert.ToInt16(txtIdariKon.Text);

            turna.SaveChanges();



        }
        catch (Exception)
        {

            lblBilgi.Text = "Birim ve Bölüm alanlarının seçildğinden emin olup tekrar deneyiniz.";
        }



        //try
        //{



        //    if (Convert.ToInt16(txtKontenjan.Text) >= 0)
        //    {


        //        if (ddlBirim.SelectedValue != "" && ddlAltBolum.SelectedValue != "")
        //        {

        //            TurnaEntities turna = new TurnaEntities();

        //            int altBolumID =Convert.ToInt16(ddlAltBolum.SelectedValue);
        //            var altKonteQuery = from altKonte in turna.tblBolumler
        //                                where altKonte.id == altBolumID
        //                                select new { altKonte.altKontenjan };

        //            int birimID1 = Convert.ToInt16(ddlBirim.SelectedValue);
        //            var bolumQuery = from bolumKonte in turna.tblBirimler
        //                             where bolumKonte.id == birimID1
        //                             select new { bolumKonte.UstKontenjan };

        //            foreach (var item in bolumQuery)
        //            {
        //                ustKontenjan = Convert.ToInt16(item.UstKontenjan);
        //            }




        //            foreach (var item in altKonteQuery)
        //            {
        //                altKontenjan = Convert.ToInt16(item.altKontenjan);
        //            }



        //            if (altKontenjan > Convert.ToInt16(txtKontenjan.Text))
        //            {
        //                int bolumID = Convert.ToInt16(ddlAltBolum.SelectedValue);
        //                tblBolumler konteEkle = turna.tblBolumler.First(n => n.id == bolumID);

        //                konteEkle.altKontenjan = Convert.ToInt16(txtKontenjan.Text);

        //                int kalan = altKontenjan - Convert.ToInt16(txtKontenjan.Text);

        //                int birimID = Convert.ToInt16(ddlBirim.SelectedValue);

        //                tblBirimler birimKonteGuncelle = turna.tblBirimler.First(n => n.id == birimID);

        //                birimKonteGuncelle.UstKontenjan += kalan;



        //                turna.SaveChanges();
        //                lblBilgi0.Text = "";

        //            }
        //            else if (altKontenjan < Convert.ToInt16(txtKontenjan.Text))
        //            {

        //                int eklenicekKontenjan = Convert.ToInt16(txtKontenjan.Text) - altKontenjan;

        //                int kalan = ustKontenjan - eklenicekKontenjan;

        //                if (kalan > -1)
        //                {

        //                    int bolumID = Convert.ToInt16(ddlAltBolum.SelectedValue);
        //                    tblBolumler konteEkle = turna.tblBolumler.First(n => n.id == bolumID);

        //                    konteEkle.altKontenjan = Convert.ToInt16(txtKontenjan.Text);



        //                    int birimID = Convert.ToInt16(ddlBirim.SelectedValue);

        //                    tblBirimler birimKonteGuncelle = turna.tblBirimler.First(n => n.id == birimID);

        //                    birimKonteGuncelle.UstKontenjan = kalan;

        //                    turna.SaveChanges();
        //                    lblBilgi0.Text = "";
        //                }
        //            }
        //            else
        //            {
        //                if (altKontenjan != Convert.ToInt16(txtKontenjan.Text))
        //                {
        //                    lblBilgi0.Text = "İşleminiz geçersiz. Yeterli üst kontenjana sahip değilsiniz.";
                            
        //                }
        //                else
        //                {
        //                    lblBilgi0.Text = "";
        //                }

        //            }


        //            int birimID2 = Convert.ToInt16(ddlBirim.SelectedValue);

        //            var birimKonte = from birim in turna.tblBirimler
        //                             where birim.id == birimID2
        //                             select new { birim.UstKontenjan };

        //            foreach (var item in birimKonte)
        //            {
        //                lblBilgi.Text = "Birim " + item.UstKontenjan.ToString() + " üst kontenjana sahiptir. Bölüme tanımlanıcak kontenjan üst kontenjandan alıncaktır!";
        //            }



        //            gridViewGuncelle();

        //        }
        //        else
        //        {
        //            lblBilgi0.Text = "Birim ve/veya Bölüm Seçiniz...";
                   
                    
        //        }


        //    }
        //    else
        //    {
        //        lblBilgi0.Text = "- Değer giremezsin!";
                
        //    }


        //}
        //catch (Exception)
        //{

        //    lblBilgi0.Text = "Bir hata oluştu verilerinizi kontrol edip işlemi tekrarlayınız.";
        //}


    }

    static int ustKontenjan = -1;
    protected void ddlBirim_SelectedIndexChanged(object sender, EventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();

        if (ddlBirim.SelectedValue != "-1")
        {
            int birimID = Convert.ToInt16(ddlBirim.SelectedValue.ToString());

            var kontGetir = from birimler in turna.tblBirimler
                            where birimler.id == birimID
                            select new { birimler.UstKontenjan };

            foreach (var item in kontGetir)
            {
              //  lblBilgi.Text = "Birim " + item.UstKontenjan.ToString() + " üst kontenjana sahiptir. Bölüme tanımlanıcak kontenjan üst kontenjandan alıncaktır!";
                lblBilgi0.Text = "";
                ustKontenjan = Convert.ToInt16(item.UstKontenjan);
            }

        }
        else
        {
            //txtKontenjan.Text = "";

        }


        VeriIslemleri veri = new VeriIslemleri();

        veri.ddlVeriCekParamBolumlerGetir(ddlAltBolum, Convert.ToInt16(ddlBirim.SelectedValue));
        ddlAltBolum.SelectedIndex = 0;
        gridViewGuncelle();

    }
    static int altKontenjan = -1;
    protected void ddlAltBolum_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAltBolum.SelectedValue != "-1")
        {
            TurnaEntities turna = new TurnaEntities();

            int altBirimID = Convert.ToInt16(ddlAltBolum.SelectedValue);
            var kontGetir = from bolumler in turna.tblBolumler
                            where bolumler.id == altBirimID
                            select new { bolumler.IdariKon,bolumler.AkademiKon,bolumler.calisanIdari,bolumler.calisanAkademi };

            foreach (var item in kontGetir)
            {
                txtAkademiKon.Text = item.AkademiKon.ToString();
                txtIdariKon.Text = item.IdariKon.ToString();
                txtAkademikCalisan.Text = item.calisanAkademi.ToString();
                txtIdariCalisan.Text = item.calisanIdari.ToString();
                
               // altKontenjan = Convert.ToInt16(item.altKontenjan);
            }
            
        }
       
    }
    public void calisanSayHesapla(int birimID,int bolumID)
    {
        TurnaEntities turna = new TurnaEntities();

        var calisanSay = from calisan in turna.tblCalismaYerleri
                         where calisan.aktifMi == "1" && calisan.calisacagiCalistigiYer == birimID
                         && calisan.calisacagiCalistigiAltBirimi == bolumID
                         && calisan.calismaSekli == 1
                         select new { calisan.id };
        int topCalisanSay = 0;
        foreach (var itemCalisanSay in calisanSay)
        {
            topCalisanSay++;
        }

        tblBolumler calisanSayGuncelle = turna.tblBolumler.First(n => n.id == bolumID);

        calisanSayGuncelle.calisanAkademi = topCalisanSay;

        calisanSay = from calisan in turna.tblCalismaYerleri
                     where calisan.aktifMi == "1" && calisan.calisacagiCalistigiYer == birimID
                      && calisan.calisacagiCalistigiAltBirimi == bolumID
                     && calisan.calismaSekli == 2
                     select new { calisan.id };
        topCalisanSay = 0;
        foreach (var itemCalisanSay in calisanSay)
        {
            topCalisanSay++;
        }


        calisanSayGuncelle.calisanIdari = topCalisanSay;



        turna.SaveChanges();

        gridViewGuncelle();




    }

    public void txtDoldur()
    {
        TurnaEntities turna = new TurnaEntities();

        if (ddlBirim.SelectedValue != "-1")
        {
            int bolumID = Convert.ToInt16(ddlAltBolum.SelectedValue.ToString());

            var kontGetir = from bolumler in turna.tblBolumler
                            where bolumler.id == bolumID
                            select new { bolumler.calisanAkademi,bolumler.calisanIdari };

            foreach (var item in kontGetir)
            {
                txtIdariCalisan.Text = item.calisanIdari.ToString();
                txtAkademikCalisan.Text = item.calisanAkademi.ToString();

            }

        }
        else
        {
            txtIdariCalisan.Text = "";
            txtAkademikCalisan.Text = "";


        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int birimID = Convert.ToInt16(ddlBirim.SelectedValue);
            int bolumID = Convert.ToInt16(ddlAltBolum.SelectedValue);

            if (bolumID != -1 || birimID != -1)
            {
                calisanSayHesapla(birimID, bolumID);
                txtDoldur();
                gridViewGuncelle();
            }
        }
        catch (Exception)
        {
            lblBilgi.Text = "Birim ve Bolum alanlarının seçildiğinden emin olup tekrar deneyiniz.";
           
        }
        
    }
}