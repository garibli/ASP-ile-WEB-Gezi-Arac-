using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using skscalismaModel;

public partial class SKSEkrani_Kontenjan : System.Web.UI.Page
{
    public void calisanSayHesapla(int birimID)
    {
        TurnaEntities turna = new TurnaEntities();

        var calisanSay = from calisan in turna.tblCalismaYerleri
                         where calisan.aktifMi == "1" && calisan.calisacagiCalistigiYer == birimID 
                         && calisan.calismaSekli == 1 
                         select new { calisan.id };
        int topCalisanSay = 0;
        foreach (var itemCalisanSay in calisanSay)
        {
            topCalisanSay++;
        }

        tblBirimler calisanSayGuncelle = turna.tblBirimler.First(n => n.id == birimID);
    
            calisanSayGuncelle.calisanAkademi = topCalisanSay;

             calisanSay = from calisan in turna.tblCalismaYerleri
                             where calisan.aktifMi == "1" && calisan.calisacagiCalistigiYer == birimID
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
    public void gridViewGuncelle()
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.


        TurnaEntities turna = new TurnaEntities();

       


       
            int birimID = Convert.ToInt16(ddlBirim.SelectedValue);
            //var bolumGetir = from birimler in turna.tblBirimler
            //                 join bolumler in turna.tblBolumler
            //                 on birimler.id equals bolumler.birimID
            //                 orderby birimler.adi ascending, bolumler.adi ascending
                             
            //                 select new { bolumler.altKontenjan , birimler.EkKontenjan,birimler.IlkKontenjan,birimler.UstKontenjan };


            var bolumGetir = from birimler in turna.tblBirimler
                              join bolumler in turna.tblBolumler
                              on birimler.id equals bolumler.birimID
                              orderby birimler.adi ascending, bolumler.adi ascending
                             
                              select new { bolumler.altKontenjan,birimler.UstKontenjan,birimler.EkKontenjan,birimler.IlkKontenjan };







            var birimGetir = from birimler in turna.tblBirimler
                             orderby birimler.adi ascending
                             select new
                             {
                                 birimler.id,
                                 birimler.adi,
                                 KalanKontenjan = birimler.UstKontenjan,
                                 birimler.IlkKontenjan,
                                 birimler.EkKontenjan,
                                 toplamKontenjan = birimler.EkKontenjan + birimler.IlkKontenjan,
                                 birimler.AkademiKon,
                                 birimler.IdariKon,
                                 birimler.YedekAkademiKon,
                                 birimler.YedekIdariKon,
                                 birimler.calisanIdari,
                                 birimler.calisanAkademi
                             };




        DataTable dt = new DataTable("BolumKonte");

        dt.Columns.Add("id");
        dt.Columns.Add("Adi");//1
        dt.Columns.Add("AkademiKon");//2
        dt.Columns.Add("IdariKon");//3
        dt.Columns.Add("YedekAkademiKon");//4
        dt.Columns.Add("YedekIdariKon");//5
        dt.Columns.Add("ToplamKonte");//6
        dt.Columns.Add("GuncelCalisan");//7

        int topAkademiKon = 0;//topKalanKonte
        int topIdariKon = 0;//topİlkKonte
        int topYedekAkademiKon = 0;//topEkKonte
        int topYedekIdariKon = 0;//topKonte
        int topToplamKonte = 0;//topAltBolDag
        int topGuncelCalisan = 0;//topCalisanSay


        foreach (var item in bolumGetir)
        {
          //  topAltBolDag += Convert.ToInt16(item.altKontenjan);
        }



        foreach (var item in birimGetir)
        {

            topAkademiKon += Convert.ToInt16(item.AkademiKon);
            topIdariKon += Convert.ToInt16(item.IdariKon);
            topYedekAkademiKon += Convert.ToInt16(item.YedekAkademiKon);
            topYedekIdariKon += Convert.ToInt16(item.YedekIdariKon);
            topToplamKonte += Convert.ToInt16(item.AkademiKon) + Convert.ToInt16(item.IdariKon) +
                Convert.ToInt16(item.YedekAkademiKon) + Convert.ToInt16(item.YedekIdariKon);
            topGuncelCalisan += Convert.ToInt16(item.calisanAkademi) + Convert.ToInt16(item.calisanIdari);


            //topIlkKonte += Convert.ToInt16(item.IlkKontenjan);
            //topKalanKonte += Convert.ToInt16(item.KalanKontenjan);
            //topEkKonte += Convert.ToInt16(item.EkKontenjan);
            //topKonte += Convert.ToInt16(item.EkKontenjan) + Convert.ToInt16(item.IlkKontenjan);

            ////////////////////////////////////////////////////////////////top calisan say.

           


        }

        DataRow yeniSatir;
        yeniSatir = dt.NewRow();

       







        yeniSatir[1] = "--Toplamlar--";
        yeniSatir[2] = topAkademiKon;
        yeniSatir[3] = topIdariKon;
        yeniSatir[4] = topYedekAkademiKon;
        yeniSatir[5] = topYedekIdariKon;
        yeniSatir[6] = topToplamKonte;
        yeniSatir[7] = topGuncelCalisan;

        dt.Rows.Add(yeniSatir);

        int altBolDag = 0;
        foreach (var item in birimGetir)
        {
            DataRow yeniSatir2;
            yeniSatir = dt.NewRow();

            var calisanSay = from calisan in turna.tblCalismaYerleri
                             where calisan.aktifMi == "1" && calisan.calisacagiCalistigiYer == item.id
                             select new { calisan.id };
            int topCalisanSay = 0;
            //////////ÇALIŞSAN SAY.
            foreach (var itemCalisanSay in calisanSay)
            {
                topCalisanSay++;
            }


            yeniSatir[7] = topCalisanSay;

            topCalisanSay = 0;


            yeniSatir[1] = item.id;
            yeniSatir[1] = item.adi;
            yeniSatir[2] = item.AkademiKon;
            yeniSatir[3] = item.IdariKon;
            yeniSatir[4] = item.YedekAkademiKon;
            yeniSatir[5] = item.YedekIdariKon;
            yeniSatir[6] = item.AkademiKon + item.IdariKon + item.YedekAkademiKon + item.YedekIdariKon;

            //var bolumGetir2 = from birimler in turna.tblBirimler
            //                 join bolumler in turna.tblBolumler
            //                 on birimler.id equals bolumler.birimID
            //                 orderby birimler.adi ascending, bolumler.adi ascending
            //                 where birimler.id == item.id
            //                 select new { bolumler.altKontenjan };
         
         

            
            //foreach (var item2 in bolumGetir2)
            //{
            //    altBolDag += Convert.ToInt16(item2.altKontenjan);
            //}



            //yeniSatir[6] = altBolDag;

            //altBolDag = 0;

            dt.Rows.Add(yeniSatir);



        }






        GridViewBirim.DataSource = dt;
        GridViewBirim.DataBind();

        //GridViewBolum.DataSource = bolumGetir.ToList();
        //GridViewBolum.DataBind();
    }


   


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
        }
        
        
        VeriIslemleri veri = new VeriIslemleri();
        
        if(!IsPostBack)
        veri.ddlVeriCekBirimler(ddlBirim);

        gridViewGuncelle();
       

        





    }


    protected void btnGir_Click(object sender, EventArgs e)
    {
        if (ddlBirim.SelectedValue != "-1")
        {

            try
            {
                TurnaEntities turna = new TurnaEntities();

                // turna.kontenjanEkle(Convert.ToInt16(ddlBirim.SelectedValue), Convert.ToInt16(txtUstKontenjan.Text) + Convert.ToInt16(txtEkKonte.Text), Convert.ToInt16(txtEkKonte.Text), Convert.ToInt16(txtAkademik.Text));


                int birimID = Convert.ToInt16(ddlBirim.SelectedValue);

                tblBirimler birimGuncelle = turna.tblBirimler.First(n => n.id == birimID);

                birimGuncelle.IdariKon = Convert.ToInt16(txtIdariKonte.Text);
                birimGuncelle.AkademiKon = Convert.ToInt16(txtAkademik.Text);
                birimGuncelle.YedekAkademiKon = Convert.ToInt16(txtYedekAkademikKonte.Text);
                birimGuncelle.YedekIdariKon = Convert.ToInt16(txtYedekIdariKonte.Text);
               // birimGuncelle.calisanAkademi = Convert.ToInt16(txtAkademiCalisan.Text);
               // birimGuncelle.calisanIdari = Convert.ToInt16(txtIdariCalisan.Text);

                turna.SaveChanges();


                lblBilgi.Text = ddlBirim.SelectedValue + " ID'ye sahip Birimi Güncellediniz.";

                gridViewGuncelle();
            }
            catch (Exception)
            {
                lblBilgi.Text = "alanlara tam sayı değerler gir";
            }
            
        }
    }


    public void txtDoldur()
    {
        TurnaEntities turna = new TurnaEntities();

        if (ddlBirim.SelectedValue != "-1")
        {
            int birimID = Convert.ToInt16(ddlBirim.SelectedValue.ToString());

            var kontGetir = from birimler in turna.tblBirimler
                            where birimler.id == birimID
                            select new { birimler.AkademiKon, birimler.IdariKon, birimler.YedekAkademiKon, birimler.YedekIdariKon, birimler.calisanAkademi, birimler.calisanIdari };

            foreach (var item in kontGetir)
            {
                txtAkademik.Text = item.AkademiKon.ToString();
                txtIdariKonte.Text = item.IdariKon.ToString();
                txtYedekAkademikKonte.Text = item.YedekAkademiKon.ToString();
                txtYedekIdariKonte.Text = item.YedekIdariKon.ToString();
                txtAkademiCalisan.Text = item.calisanAkademi.ToString();
                txtIdariCalisan.Text = item.calisanIdari.ToString();

            }

        }
        else
        {
            txtAkademik.Text = "";
            txtIdariKonte.Text = "";
            txtYedekAkademikKonte.Text = "";
            txtYedekIdariKonte.Text = "";
            txtAkademiCalisan.Text = "";
            txtIdariCalisan.Text = "";


        }
    }


    protected void ddlBirim_SelectedIndexChanged(object sender, EventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();

        if (ddlBirim.SelectedValue != "-1")
        {
            int birimID = Convert.ToInt16(ddlBirim.SelectedValue.ToString());

            var kontGetir = from birimler in turna.tblBirimler
                            where birimler.id == birimID
                            select new { birimler.AkademiKon ,birimler.IdariKon,birimler.YedekAkademiKon,birimler.YedekIdariKon,birimler.calisanAkademi,birimler.calisanIdari};

            foreach (var item in kontGetir)
            {
                txtAkademik.Text = item.AkademiKon.ToString();
                txtIdariKonte.Text = item.IdariKon.ToString();
                txtYedekAkademikKonte.Text = item.YedekAkademiKon.ToString();
                txtYedekIdariKonte.Text = item.YedekIdariKon.ToString();
                txtAkademiCalisan.Text = item.calisanAkademi.ToString();
                txtIdariCalisan.Text = item.calisanIdari.ToString();
            
            }

        }
        else
        {
            txtAkademik.Text = "";
            txtIdariKonte.Text = "";
            txtYedekAkademikKonte.Text = "";
            txtYedekIdariKonte.Text = "";
            txtAkademiCalisan.Text = "";
            txtIdariCalisan.Text = "";
            

        }

     
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int birimID = Convert.ToInt16(ddlBirim.SelectedValue);
        if (birimID != -1)
        {

            calisanSayHesapla(birimID);
            txtDoldur();
        }
    }
}