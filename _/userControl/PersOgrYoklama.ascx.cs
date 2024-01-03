using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using skscalismaModel;
public partial class userControl_OgrYoklama : System.Web.UI.UserControl
{
    VeriIslemleri veri = new VeriIslemleri();
    TurnaEntities turna = new TurnaEntities();

    static string topluHideTakip="1";
    static string kisiSecerekHideTakip="1";
    static double[] PuantajToplam = new double[31];
    protected void Page_Load(object sender, EventArgs e)
    {
       
        var puantajGunu = from girilecekGun in turna.tblPuantajGirmeSuresi
                          where girilecekGun.id == 1
                          select new { girilecekGun.puantajSuresi };

        int kacGunGirelecek = -1;

        foreach (var item in puantajGunu)
        {
            kacGunGirelecek = Convert.ToInt16(item.puantajSuresi);
        }
        

      

        if (!(DateTime.Now.Day <= kacGunGirelecek))
        {
            Response.Redirect("../PuantajGirilemez.aspx");
        }




       
        if (!IsPostBack)
        {
            //aç bir gün öncesi için
            Session["kontroltoplu"] = "0";
            Session["kontrolkisiSecerek"] = "0";
            ddlYılSec.Items.Add(new ListItem((DateTime.Now.AddYears(-1).Year.ToString())));
            //toplupuantajHide.Visible = false;
            ddlYılSec.Items.Add(new ListItem(DateTime.Now.Year.ToString()));

            //toplupuantajHide.Visible = false;

            DateTime tarih = DateTime.Now.AddMonths(-1);
            //DateTime tarih = DateTime.Now; //1 gün öncesi için aç.12.ay için eklenecek

            //if (Calendar1.SelectedDate.ToString() == "1.1.0001 00:00:00")
            //    tarih = DateTime.Today;
            //else
            //    tarih = Calendar1.SelectedDate;



            tarih.ToString("MM-dd-yyyy");


           // veri.ddlVeriCekBirimler(ddlIlgiliBirim); // tüm bölümleri getirir.
            veri.ddlVeriCekParamBirimler(ddlIlgiliBirim, Convert.ToInt16(Session["birimID"].ToString()));// eğerki birimler ilan ekliycekse
            ddlBolumGetir();
            
            veri.ddlVeriCekParamBirimCalisanGetir(ddlCalisanlar, Convert.ToInt32(ddlIlgiliBirim.SelectedValue),tarih);
            calisanBirimGridViewGetir();
            ddlHizliPAy.Items.Add(new ListItem(DateTime.Now.AddMonths(-1).Month.ToString(), DateTime.Now.AddMonths(-1).Month.ToString()));
            //ddlHizliPAy.Items.Add(new ListItem(DateTime.Now.Month.ToString(), DateTime.Now.Month.ToString()));//12.ayda eklenecek
            
            ddlHizliPAy.SelectedIndex = 0;
           
            Calendar1.SelectedDate = DateTime.Now.AddMonths(-1);//Calendar1.SelectedDate = DateTime.Now;//12.ayda eklenecek
            Calendar1.VisibleDate = DateTime.Now.AddMonths(-1);//Calendar1.VisibleDate = DateTime.Now;//12.ayda eklenecek



            ////////////////////detayPuantaj////////////////////////////////

            DateTime kTarih = DateTime.Now.AddMonths(-1);
            //DateTime kTarih = DateTime.Now; //12. ayda eklenecek

            lblDetayTarih.Text = kTarih.ToShortDateString();

          

            int gunSay = DateTime.DaysInMonth(kTarih.Year, kTarih.Month);

            if (gunSay == 30)
            {
                TextBox31.Enabled = false;
            }
            else if (gunSay == 29)
            {
                TextBox31.Enabled = false;
                TextBox30.Enabled = false;

            }
            else if (gunSay == 28)
            {
                TextBox31.Enabled = false;
                TextBox30.Enabled = false;
                TextBox29.Enabled = false;
            }



            //////////////detayPuantaj Son///////////////////
           







        }
        ddlIlgiliBirim.SelectedIndex = 1 ;
        ddlIlgiliBirim.Enabled = false;
    }
    public void calisanAltBirimGridViewGetir()
    {
        try
        {
            DateTime tarih = new DateTime();
            if (Calendar1.SelectedDate.ToString() == "1.1.0001 00:00:00")
                tarih = DateTime.Now.AddMonths(-1);
                //tarih = DateTime.Now;//12. ayda eklenecek
            else
                tarih = Calendar1.SelectedDate;



            tarih.ToString("MM-dd-yyyy");

            if (ddlIlgiliBolum.SelectedValue != null)
            {
                int ilgiliAtlBirim = Convert.ToInt16(ddlIlgiliBolum.SelectedValue);

                var sorgu = (from ogr in turna.tblOgrenci
                            join calismaYer in turna.tblCalismaYerleri on ogr.id equals calismaYer.ogrID
                             join sgk in turna.SGKGirisCikis
                             on ogr.ogrNo equals sgk.ogrNo
                             where calismaYer.calisacagiCalistigiAltBirimi == ilgiliAtlBirim &&
                              (((sgk.SGKCikis.Value.Month >= tarih.Month && sgk.SGKCikis.Value.Year >= tarih.Year)) || sgk.SGKCikis == null)
                      && (((sgk.SGKGiris.Value.Month <= tarih.Month && sgk.SGKGiris.Value.Year <= tarih.Year)) || sgk.SGKGiris.Value.Year < tarih.Year)
                             //calismaYer.aktifMi == "1"
                            select new { ogr.ogrNo, ogr.ad, ogr.soyad }).Distinct();

                GridViewCalisanlar.DataSource = sorgu.ToList();
                GridViewCalisanlar.DataBind();
            }
        }
        catch (Exception)
        {


        }
    }
    public void calisanBirimGridViewGetir()
    {

        DateTime tarih = new DateTime();
        if (Calendar1.SelectedDate.ToString() == "1.1.0001 00:00:00")
             tarih = DateTime.Now.AddMonths(-1);
            //tarih = DateTime.Now;//12. ayda eklenecek
        else
            tarih = Calendar1.SelectedDate;



        tarih.ToString("MM-dd-yyyy");



        if ((ddlIlgiliBolum.SelectedValue == "" || ddlIlgiliBolum.SelectedValue == "-1") && ddlIlgiliBirim.SelectedValue != "-1")
        {
            int ilgiliBirim = Convert.ToInt16(ddlIlgiliBirim.SelectedValue);

            var sorgu = (from ogr in turna.tblOgrenci
                         join calismaYer in turna.tblCalismaYerleri on ogr.id equals calismaYer.ogrID
                         join sgk in turna.SGKGirisCikis
                             on ogr.ogrNo equals sgk.ogrNo
                         where calismaYer.calisacagiCalistigiYer == ilgiliBirim &&
                             (((sgk.SGKCikis.Value.Month >= tarih.Month && sgk.SGKCikis.Value.Year >= tarih.Year)) || sgk.SGKCikis == null)
                     && ((sgk.SGKGiris.Value.Month <= tarih.Month && sgk.SGKGiris.Value.Year <= tarih.Year))
                         //calismaYer.aktifMi == "1"
                         select new { ogr.ogrNo, ogr.ad, ogr.soyad }).Distinct();

            GridViewCalisanlar.DataSource = sorgu.ToList();
            GridViewCalisanlar.DataBind();

        }
        else if ((ddlIlgiliBolum.SelectedValue != "" || ddlIlgiliBolum.SelectedValue != "-1") && ddlIlgiliBirim.SelectedValue != "-1")
        {
            int ilgiliBirim = Convert.ToInt16(ddlIlgiliBirim.SelectedValue);
            int ilgiliBolum = Convert.ToInt16(ddlIlgiliBolum.SelectedValue);
            var sorgu = (from ogr in turna.tblOgrenci
                         join calismaYer in turna.tblCalismaYerleri on ogr.id equals calismaYer.ogrID
                         join sgk in turna.SGKGirisCikis
                              on ogr.ogrNo equals sgk.ogrNo

                         where calismaYer.calisacagiCalistigiYer == ilgiliBirim && calismaYer.calisacagiCalistigiAltBirimi == ilgiliBolum &&
                             (((sgk.SGKCikis.Value.Month >= tarih.Month && sgk.SGKCikis.Value.Year >= tarih.Year)) || sgk.SGKCikis == null)
                     && ((sgk.SGKGiris.Value.Month <= tarih.Month && sgk.SGKGiris.Value.Year <= tarih.Year))
                         //calismaYer.aktifMi == "1"

                          select new { ogr.ogrNo, ogr.ad, ogr.soyad }).Distinct();
            GridViewCalisanlar.DataSource = sorgu.ToList();
            GridViewCalisanlar.DataBind();
        }
    }
    protected void ddlBolumGetir()
    {
        DateTime tarih = new DateTime();
        if (Calendar1.SelectedDate.ToString() == "1.1.0001 00:00:00")
            tarih = DateTime.Now.AddMonths(-1);
            //tarih = DateTime.Now;//12. ayda eklenecek
        else
            tarih = Calendar1.SelectedDate;



        tarih.ToString("MM-dd-yyyy");


        int birimID=Convert.ToInt16(Session["birimID"]);
        int bolumID=Convert.ToInt16(Session["bolumID"]);
        if (ddlIlgiliBirim.SelectedValue != null)
        {
            string deger = Session["yetkiID"].ToString();
            
            try
            {
                if (Session["yetkiID"].ToString() == "1" && Session["bolumID"].ToString() == "-1")
                {
                    var bolumGetir = from bolum in turna.tblBolumler where bolum.birimID == birimID select new { bolum.adi ,bolum.id};
                    foreach (var item in bolumGetir)
                    {
                        ddlIlgiliBolum.Items.Add(new ListItem(item.adi,item.id.ToString()));
                    }
                }
                else
                {
                    var bolumGetir = from bolum in turna.tblBolumler where bolum.birimID == birimID && bolum.id==bolumID select new { bolum.adi, bolum.id };
                    foreach (var item in bolumGetir)
                    {
                        ddlIlgiliBolum.Items.Add(new ListItem(item.adi, item.id.ToString()));
                    }
                    ddlIlgiliBolum.SelectedIndex = 1;
                    ddlIlgiliBolum.Enabled = false;
                    
                }
                ddlCalisanlar.Items.Clear();
               
                veri.ddlVeriCekParamBirimCalisanGetir(ddlCalisanlar, Convert.ToInt32(ddlIlgiliBirim.SelectedValue),tarih);
                calisanBirimGridViewGetir();
            }
            catch (Exception)
            {
                
              
            }
            ddlIlgiliBirim.SelectedIndex = 1;
            ddlCalisanlar.Items.Clear();
         //   veri.ddlVeriCekParamAltBirimCalisanGetir(ddlCalisanlar, Convert.ToInt16(ddlIlgiliBirim.SelectedValue), Convert.ToInt16(ddlIlgiliBolum.SelectedValue));
            calisanAltBirimGridViewGetir();
        }
    }
    protected void ddlIlgiliBolum_SelectedIndexChanged(object sender, EventArgs e)
    {

        DateTime tarih = new DateTime();
        if (Calendar1.SelectedDate.ToString() == "1.1.0001 00:00:00")
            tarih = DateTime.Now.AddMonths(-1);
            //tarih = DateTime.Now;//12. ayda eklenecek
        else
            tarih = Calendar1.SelectedDate;



        tarih.ToString("MM-dd-yyyy");


        ddlCalisanlar.Items.Clear();
        veri.ddlVeriCekParamAltBirimCalisanGetir(ddlCalisanlar, Convert.ToInt16(ddlIlgiliBirim.SelectedValue), Convert.ToInt16(ddlIlgiliBolum.SelectedValue),tarih);
        calisanAltBirimGridViewGetir();
	
        
        
    }

    protected void btnGir_Click(object sender, EventArgs e)
    {
        if (ddlCalisanlar.SelectedValue != "")
        {
            DateTime tarih = new DateTime();
            if (Calendar1.SelectedDate.ToString() == "1.1.0001 00:00:00")
                tarih = DateTime.Now.AddMonths(-1);
                //tarih = DateTime.Now; //12.ayda eklenecek
            else
                tarih = Calendar1.SelectedDate;

            tarih.ToString("MM-dd-yyyy");

            System.Data.Objects.ObjectParameter kayitYapilsinmi = new System.Data.Objects.ObjectParameter("kayitYapilsinmi", typeof(int));
            System.Data.Objects.ObjectParameter aciklama = new System.Data.Objects.ObjectParameter("aciklama", typeof(decimal));

            turna.calisanYoklamaEklensinMi(Convert.ToInt32(ddlCalisanlar.SelectedValue), tarih, Convert.ToDecimal(ddlCalisanSaat.SelectedValue), kayitYapilsinmi, aciklama);

            lblAciklama.Text = aciklama.Value.ToString();
            lblTumCalisan.Text = null;
            lblCalisan.Text = null;

            string ogrenciNo = "-1";
            int ogrenciID = Convert.ToInt32(ddlCalisanlar.SelectedValue.ToString());
            var ogrNo = from ogr in turna.tblOgrenci
                        where ogr.id == ogrenciID
                        select new { ogr.ogrNo };

            foreach (var item in ogrNo)
            {
                ogrenciNo = item.ogrNo;
            }



             var ogrSGK = from SGK in turna.SGKGirisCikis
                         where SGK.ogrNo == ogrenciNo
                         select new { SGK.SGKGiris, SGK.SGKCikis };


            DateTime SGKGiris = Convert.ToDateTime("1.1.0001 00:00:00"), SGKCikis = Convert.ToDateTime("1.1.0001 00:00:00");

            foreach (var item in ogrSGK)
            {
                SGKGiris = Convert.ToDateTime(item.SGKGiris);
                SGKCikis = Convert.ToDateTime(item.SGKCikis);
            }

            if (SGKGiris <= Convert.ToDateTime(tarih) && (SGKCikis >= Convert.ToDateTime(tarih) || SGKCikis == Convert.ToDateTime("1.1.0001 00:00:00")))
            {



                if (Convert.ToInt32(kayitYapilsinmi.Value) == 1)
                {
                    turna.CalisanYoklamaEkle(ogrenciID, ogrenciNo, Convert.ToDateTime(tarih), Convert.ToDecimal(ddlCalisanSaat.SelectedValue));

                }
            }
            else
            {
                lblAciklama.Text = "seçili tarihe SGK giriş/çıkış tarihleriyle çeliştiği için puantaj girişi yapılamadı.";
            }

            yoklamaGuncelle(tarih.Month, tarih.Year);
            ddlAy.Visible = true;
            ddlYılSec.Visible = true;
            
        }
        else
            lblAciklama.Text = "Gerekli Alanlar doldurulmadı! İşlem geçerisiz...";
     
    }
    public void otoCalisanEkle(int ogrID,Label lblBilgi,Label lblNul1,Label lblNul2) 
    {
        if (ddlCalisanlar.SelectedValue != "")
        {
            DateTime tarih = new DateTime();

            //if (Calendar1.SelectedDate.ToString() == "1.1.0001 00:00:00")
            //    tarih = DateTime.Today;
            //else
            //    tarih = Calendar1.SelectedDate;
            
            //tarih = DateTime.Now; //12.ay da eklenecek
            tarih = DateTime.Now.AddMonths(-1);
            tarih.ToString("MM-dd-yyyy");

            System.Data.Objects.ObjectParameter kayitYapilsinmi = new System.Data.Objects.ObjectParameter("kayitYapilsinmi", typeof(int));
            System.Data.Objects.ObjectParameter aciklama = new System.Data.Objects.ObjectParameter("aciklama", typeof(string));


            var ogrNo = from ogr in turna.tblOgrenci
                        where ogr.id == ogrID
                        select new { ogr.ogrNo };

            string ogrenciNo = "-1";

            foreach (var item in ogrNo)
            {
                ogrenciNo = item.ogrNo;
            }



            var ogrSGK = from SGK in turna.SGKGirisCikis
                         where SGK.ogrNo == ogrenciNo
                         select new { SGK.SGKGiris, SGK.SGKCikis };

            DateTime SGKGiris = Convert.ToDateTime("1.1.0001 00:00:00"), SGKCikis = Convert.ToDateTime("1.1.0001 00:00:00");

            foreach (var item in ogrSGK)
            {
                SGKGiris = Convert.ToDateTime(item.SGKGiris);
                SGKCikis = Convert.ToDateTime(item.SGKCikis);
            }




            for (int i = 0; tarih.Month == tarih.AddDays(i).Month; i++)
            {
                //if (tarih.AddDays(i).Day == 30)
                //{
                //    string x; 
                //}

                if (Convert.ToDateTime(SGKGiris.ToShortDateString()) <= Convert.ToDateTime(tarih.AddDays(i).ToShortDateString()) && (Convert.ToDateTime(SGKCikis.ToShortDateString()) >= Convert.ToDateTime(tarih.AddDays(i).ToShortDateString()) || SGKCikis == Convert.ToDateTime("1.1.0001 00:00:00")))
                {





                    turna.calisanYoklamaEklensinMi(ogrID, Convert.ToDateTime(tarih.AddDays(i)), Convert.ToDecimal(0), kayitYapilsinmi, aciklama);

                    if (Convert.ToInt32(kayitYapilsinmi.Value) == 1)
                    {
                        turna.CalisanYoklamaEkle(ogrID, ogrenciNo, Convert.ToDateTime(tarih.AddDays(i)), Convert.ToDecimal(3));
                    }

                }
                else
                {
                    lblAciklama.Text = "Bağzı Tarihlere SGK giriş/çıkış tarihleriyle çeliştiği için puantaj girişi yapılamadı.";
                }
            }
            for (int i = -1; tarih.Month == tarih.AddDays(i).Month; i--)
            {

                if (Convert.ToDateTime(SGKGiris.ToShortDateString()) <= Convert.ToDateTime(tarih.AddDays(i).ToShortDateString()) && (Convert.ToDateTime(SGKCikis.ToShortDateString()) >= Convert.ToDateTime(tarih.AddDays(i).ToShortDateString()) || SGKCikis == Convert.ToDateTime("1.1.0001 00:00:00")))
                {

                    turna.calisanYoklamaEklensinMi(ogrID, Convert.ToDateTime(tarih.AddDays(i)), Convert.ToDecimal(ddlCalisanSaat.SelectedValue), kayitYapilsinmi, aciklama);

                    if (Convert.ToInt32(kayitYapilsinmi.Value) == 1)
                    {
                        turna.CalisanYoklamaEkle(ogrID, ogrenciNo, Convert.ToDateTime(tarih.AddDays(i)), Convert.ToDecimal(3));
                    }

                }
                else
                {
                    lblAciklama.Text = "Bağzı Tarihlere SGK giriş/çıkış tarihleriyle çeliştiği için puantaj girişi yapılamadı.";
                }
            }
            lblAciklama.Text += "İşleminiz Tamamlandı...";
            lblNul1.Text = null;
            lblNul2.Text = null;

            yoklamaGuncelle(tarih.Month, tarih.Year);
            ddlYılSec.Visible = true;
            ddlAy.Visible = true;
        }
    }
    protected void btnKisiTopluGir_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < PuantajToplam.Length; i++)
            {
                PuantajToplam[i] = Convert.ToDouble(0);
            }
            
            otoCalisanEkle(Convert.ToInt32(ddlCalisanlar.SelectedValue),lblCalisan,lblTumCalisan,lblAciklama);
            detayPuantajGunGun();
            double toplamPuantaj = 0;
            for (int i = 0; i < PuantajToplam.Length; i++)
            {
                toplamPuantaj = toplamPuantaj + PuantajToplam[i];
            }
            lblToplamPuantajYaz.Text = toplamPuantaj.ToString();

        }
        catch (Exception)
        {
            
           lblAciklama.Text="Gerekli Alanlar doldurulmadı! İşlem geçerisiz...";
        }
        
    }
    protected void btnTumuTopluGir_Click(object sender, EventArgs e)
    {
        try
        {

          //  if (ddlIlgiliBolum.SelectedValue == "")
          //  {
               
                for (int i = 1; i < ddlCalisanlar.Items.Count; i++)
                {
                    otoCalisanEkle(Convert.ToInt32(ddlCalisanlar.Items[i].Value), lblCalisan, lblTumCalisan, lblAciklama);
                }
                
               
           // }
            //else
            //{
            //    int birim = Convert.ToInt32(ddlIlgiliBirim.SelectedValue);
            //    int bolum = Convert.ToInt32(ddlIlgiliBolum.SelectedValue);
            //    int birOncekiAy = DateTime.Now.AddMonths(-1).Month;
            //    int birOncekiYil = DateTime.Now.AddMonths(-1).Year;
            //    var getir = from ogr in turna.tblOgrenci
            //                join sgk in turna.SGKGirisCikis
            //                on ogr.ogrNo equals sgk.ogrNo
            //                join calismaYer in turna.tblCalismaYerleri 
            //                on ogr.ogrNo equals calismaYer.ogrNo
            //                where calismaYer.calisacagiCalistigiYer == birim && calismaYer.calisacagiCalistigiAltBirimi == bolum &&
            //                sgk.SGKGiris <= DateTime.Now 
            //                && sgk.SGKCikis == null || ((sgk.SGKCikis.Value.Month == DateTime.Now.Month && sgk.SGKCikis.Value.Year == DateTime.Now.Year ) || (sgk.SGKCikis.Value.Month == birOncekiAy && sgk.SGKCikis.Value.Year == birOncekiYil))
            //                select new { ogr.id };

            //    //var getir = turna.altBirimParamCalisanGetir(Convert.ToInt32(ddlIlgiliBirim.SelectedValue), Convert.ToInt32(ddlIlgiliBolum.SelectedValue));
            //    var getir2 = turna.isTanimiGetir();
            //    foreach (var item in getir)
            //    {
            //        otoCalisanEkle(Convert.ToInt32(item.id), lblCalisan, lblTumCalisan, lblAciklama);
            //    }
            //}
            messagebox("Puantaj toplu olarak oluşturulmuştur.öğrenci bazında değişiklik yapmak istiyorsanız aşağıdaki detay butonuna tıklayınız.");
        }
        catch (Exception)
        {
            lblAciklama.Text = "Gerekli Alanlar doldurulmadı veya çalışanınız yok. İşlem geçersiz...";
         
        }

        
     

    }

    protected void yoklamaGuncelle(int trh,int year)
    {
        
        if (GridViewCalisanlar.SelectedRow != null)
        {
            string secilen = GridViewCalisanlar.SelectedRow.Cells[1].Text.ToString();

            var sorgu2 = from calisan in turna.tblCalismaYerleri join ogr1 in turna.tblOgrenci on calisan.ogrID equals ogr1.id
                         where ogr1.ogrNo == secilen select new { ogr1.id };

            foreach (var item in sorgu2)
            {
                try
                {
                    ddlCalisanlar.SelectedValue = item.id.ToString();
                }
                catch (Exception)
                {
                    
                    
                }
               

            }
           
            var sorgu = from yoklama in turna.tblCalisanYoklama
                        join ogr in turna.tblOgrenci on yoklama.ogrID equals ogr.id
                        let Tarih = yoklama.tarih.Value
                        let OgrenciNo = ogr.ogrNo
                        let Saat = yoklama.calistigiSaat
                        where ogr.ogrNo == secilen && Tarih.Month == trh && Tarih.Year == year orderby Tarih
                        select new { OgrenciNo, Tarih, Saat };

            GridViewTarih.DataSource = sorgu.ToList();
            GridViewTarih.DataBind();
           


            
        }
        
    }
    protected void GridViewCalisanlar_SelectedIndexChanged(object sender, EventArgs e)
    {
        yoklamaGuncelle(DateTime.Now.Month, DateTime.Now.Year);
        ddlYılSec.Visible = true;
        ddlAy.Visible = true;
        ddlYılSec.SelectedValue = DateTime.Now.Year.ToString();
        ddlAy.SelectedValue = DateTime.Now.Month.ToString();

    }

    protected void ddlAy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlYılSec.SelectedValue!="0" && ddlAy.SelectedValue != "0")
        {
            yoklamaGuncelle(Convert.ToInt16(ddlAy.SelectedValue), Convert.ToInt16(ddlYılSec.SelectedValue));
        }

    }
    protected void ddlYılSec_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAy.SelectedValue != "0" && ddlYılSec.SelectedValue != "0")
        {
            yoklamaGuncelle(Convert.ToInt16(ddlAy.SelectedValue), Convert.ToInt16(ddlYılSec.SelectedValue));
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        ddlAy.SelectedValue = Calendar1.SelectedDate.Month.ToString();
        ddlYılSec.SelectedValue = Calendar1.SelectedDate.Year.ToString();
    }

    public void messagebox(string mesaj)
    {


        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }
    protected void ddlIlgiliBirim_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    public void otoCalisanSil(int ogrID, Label lblBilgi, Label lblNul1, Label lblNul2)
    {
        if (ddlCalisanlar.SelectedValue != "")
        {
            DateTime tarih = new DateTime();
            if (Calendar1.SelectedDate.ToString() == "1.1.0001 00:00:00")
                tarih = DateTime.Today;
            else
                tarih = Calendar1.SelectedDate;



            tarih.ToString("MM-dd-yyyy");

            System.Data.Objects.ObjectParameter kayitYapilsinmi = new System.Data.Objects.ObjectParameter("kayitYapilsinmi", typeof(int));
            System.Data.Objects.ObjectParameter aciklama = new System.Data.Objects.ObjectParameter("aciklama", typeof(string));


            var ogrNo = from ogr in turna.tblOgrenci
                        where ogr.id == ogrID
                        select new { ogr.ogrNo };

            string ogrenciNo = "-1";

            foreach (var item in ogrNo)
            {
                ogrenciNo = item.ogrNo;
            }

            for (int i = 0; tarih.Month == tarih.AddDays(i).Month; i++)
            {
                turna.calisanYoklamaEklensinMi(ogrID, Convert.ToDateTime(tarih.AddDays(i)), Convert.ToDecimal(0), kayitYapilsinmi, aciklama);

                if (Convert.ToInt32(kayitYapilsinmi.Value) == 1)
                {
                    turna.CalisanYoklamaEkle(ogrID, ogrenciNo, Convert.ToDateTime(tarih.AddDays(i)), Convert.ToDecimal(0));
                }
            }
            for (int i = -1; tarih.Month == tarih.AddDays(i).Month; i--)
            {
                turna.calisanYoklamaEklensinMi(ogrID, Convert.ToDateTime(tarih.AddDays(i)), Convert.ToDecimal(ddlCalisanSaat.SelectedValue), kayitYapilsinmi, aciklama);

                if (Convert.ToInt32(kayitYapilsinmi.Value) == 1)
                {
                    turna.CalisanYoklamaEkle(ogrID, ogrenciNo, Convert.ToDateTime(tarih.AddDays(i)), Convert.ToDecimal(0));
                }
            }
            lblAciklama.Text = "İşleminiz Tamamlandı...";
            lblNul1.Text = null;
            lblNul2.Text = null;

            yoklamaGuncelle(tarih.Month, tarih.Year);
            ddlYılSec.Visible = true;
            ddlAy.Visible = true;
        }
    }


    protected void btnSil_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < PuantajToplam.Length; i++)
            {
                PuantajToplam[i] = Convert.ToDouble(0);
            }
            otoCalisanSil(Convert.ToInt32(ddlCalisanlar.SelectedValue), lblCalisan, lblTumCalisan, lblAciklama);
            lblAciklama.Text = "Çalışanın ilgili aydaki puantajı silindi.";
            detayPuantajGunGun();
            double toplamPuantaj = 0;
            for (int i = 0; i < PuantajToplam.Length; i++)
            {
                toplamPuantaj = toplamPuantaj + PuantajToplam[i];
            }
            lblToplamPuantajYaz.Text = toplamPuantaj.ToString();


        }
        catch (Exception)
        {

            lblAciklama.Text = "Gerekli Alanlar doldurulmadı! İşlem geçerisiz...";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox1, 1);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox2, 2);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox3, 3);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox4, 4);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox5, 5);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox6, 6);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox7, 7);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox8, 8);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox9, 9);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox10, 10);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox11, 11);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox12, 12);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox13, 13);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox14, 14);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox15, 15);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox16, 16);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox17, 17);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox18, 18);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox19, 19);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox20, 20);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox21, 21);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox22, 22);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox23, 23);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox24, 24);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox25, 25);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox26, 26);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox27, 27);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox28, 28);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox29, 29);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox30, 30);
        otoCalisanDetajPuantajEkle(Convert.ToInt16(ddlCalisanlar.SelectedValue), lblDetayHata, lblDetayHata0, lblDetayHata1, TextBox31, 31);

        detayPuantajGunGun();

        lblDetayBilgi.Text = "Puantajın kaydedilebilir hali* aşağıdadır.\n*Haftalık 15 Saati aşamazsın.\n*Hafta sonları ve tatil günlerine kayıt giremezsin";
    }


    /// <summary>
    /// //////////Detay puantajj Ekleeee
    /// </summary>
    private void otoCalisanDetajPuantajEkle(int ogrID, Label lblBilgi, Label lblNul1, Label lblNul2, TextBox txtcalistigiGun, int gun)
    {
        if (ddlCalisanlar.SelectedValue != "")
        {
            DateTime tarih = new DateTime();
            if (Calendar1.SelectedDate.ToString() == "1.1.0001 00:00:00")
                tarih = DateTime.Today;
            else
                tarih = Calendar1.SelectedDate;

            decimal calistigiGun = 0;

            if (txtcalistigiGun.Text != "")
            {

                try
                {
                    calistigiGun = Convert.ToDecimal(txtcalistigiGun.Text);
                }
                catch (Exception e)
                {

                    lblDetayHata0.Text = e.Message;
                }

            }
            int dorulanmısGunSay ;
            if(int.TryParse(calistigiGun.ToString(),out dorulanmısGunSay))
            {


                tarih.ToString("MM-dd-yyyy");

                System.Data.Objects.ObjectParameter kayitYapilsinmi = new System.Data.Objects.ObjectParameter("kayitYapilsinmi", typeof(int));
                System.Data.Objects.ObjectParameter aciklama = new System.Data.Objects.ObjectParameter("aciklama", typeof(string));


                var ogrNo = from ogr in turna.tblOgrenci
                            where ogr.id == ogrID
                            select new { ogr.ogrNo };

                string ogrenciNo = "-1";

                foreach (var item in ogrNo)
                {
                    ogrenciNo = item.ogrNo;
                }

                var ogrSGK = from SGK in turna.SGKGirisCikis
                             where SGK.ogrNo == ogrenciNo
                             select new { SGK.SGKGiris, SGK.SGKCikis };

                DateTime SGKGiris = Convert.ToDateTime("1.1.0001 00:00:00"), SGKCikis = Convert.ToDateTime("1.1.0001 00:00:00");

                foreach (var item in ogrSGK)
                {
                    SGKGiris = Convert.ToDateTime(item.SGKGiris);
                    SGKCikis = Convert.ToDateTime(item.SGKCikis);
                }
                try
                {
                    DateTime kullanılanTarih = Convert.ToDateTime(gun.ToString() + "." + tarih.Month.ToString() + "." + tarih.Year.ToString());



                    if (SGKGiris <= kullanılanTarih && (SGKCikis >= kullanılanTarih || SGKCikis == Convert.ToDateTime("1.1.0001 00:00:00")))
                    {




                        turna.calisanYoklamaEklensinMi(ogrID, kullanılanTarih, calistigiGun, kayitYapilsinmi, aciklama);

                        if (Convert.ToInt32(kayitYapilsinmi.Value) == 1)
                        {
                            turna.CalisanYoklamaEkle(ogrID, ogrenciNo, kullanılanTarih, calistigiGun);
                        }
                    }
                    else
                    {
                        //  lblAciklama.Text = "Bağzı Tarihlere SGK giriş/çıkış tarihleriyle çeliştiği için puantaj girişi yapılamadı.";
                    }
                }
                catch (Exception)
                {


                }

                // lblAciklama.Text += "İşleminiz Tamamlandı...";
                lblNul1.Text = null;
                lblNul2.Text = null;

                yoklamaGuncelle(tarih.Month, tarih.Year);
                ddlYılSec.Visible = true;
                ddlAy.Visible = true;
            }
             
            else
            {
                lblDetayHata0.Text = "Tam sayı girmeniz gerekmektedir. Tam sayı olmayan puantajlar işleme alınmamıştır.";
                
            }
        }
    }
    /// <summary>
    /// /////////////////////////detay puantaj ekle SONN/////////////////////////////////////
    /// </summary>


    public void detayPuantajGunGun()
    {
        DateTime tarih = Convert.ToDateTime(lblDetayTarih.Text);
        int ogrID = Convert.ToInt16(ddlCalisanlar.SelectedValue);
        var getirDetayPuantaj = from puantaj in turna.tblCalisanYoklama
                                where puantaj.ogrID == ogrID &&
                                puantaj.tarih.Value.Month == tarih.Month &&
                                puantaj.tarih.Value.Year == tarih.Year
                                select new { puantaj.calistigiSaat, puantaj.tarih };

        TextBox1.Text = ""; TextBox2.Text = ""; TextBox3.Text = ""; TextBox4.Text = ""; TextBox5.Text = ""; TextBox6.Text = ""; TextBox7.Text = "";
        TextBox8.Text = ""; TextBox9.Text = ""; TextBox10.Text = ""; TextBox11.Text = ""; TextBox12.Text = ""; TextBox13.Text = ""; TextBox14.Text = "";
        TextBox15.Text = ""; TextBox16.Text = ""; TextBox17.Text = ""; TextBox18.Text = ""; TextBox19.Text = ""; TextBox20.Text = ""; TextBox21.Text = "";
        TextBox22.Text = ""; TextBox23.Text = ""; TextBox24.Text = ""; TextBox25.Text = ""; TextBox26.Text = ""; TextBox27.Text = ""; TextBox28.Text = "";
        TextBox29.Text = ""; TextBox30.Text = ""; TextBox31.Text = "";




        foreach (var item in getirDetayPuantaj)
        {



            if (item.tarih.Value.Day == 1)
            {
                TextBox1.Text = item.calistigiSaat.ToString();
                PuantajToplam[0] = Convert.ToInt16(item.calistigiSaat);
                
            }
            else if (item.tarih.Value.Day == 2)
            {
                TextBox2.Text = item.calistigiSaat.ToString();
                PuantajToplam[1] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 3)
            {
                TextBox3.Text = item.calistigiSaat.ToString();
                PuantajToplam[2] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 4)
            {
                TextBox4.Text = item.calistigiSaat.ToString();
                PuantajToplam[3] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 5)
            {
                TextBox5.Text = item.calistigiSaat.ToString();
                PuantajToplam[4] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 6)
            {
                TextBox6.Text = item.calistigiSaat.ToString();
                PuantajToplam[5] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 7)
            {
                TextBox7.Text = item.calistigiSaat.ToString();
                PuantajToplam[6] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 8)
            {
                TextBox8.Text = item.calistigiSaat.ToString();
                PuantajToplam[7] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 9)
            {
                TextBox9.Text = item.calistigiSaat.ToString();
                PuantajToplam[8] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 10)
            {
                TextBox10.Text = item.calistigiSaat.ToString();
                PuantajToplam[9] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 11)
            {
                TextBox11.Text = item.calistigiSaat.ToString();
                PuantajToplam[10] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 12)
            {
                TextBox12.Text = item.calistigiSaat.ToString();
                PuantajToplam[11] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 13)
            {
                TextBox13.Text = item.calistigiSaat.ToString();
                PuantajToplam[12] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 14)
            {
                TextBox14.Text = item.calistigiSaat.ToString();
                PuantajToplam[13] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 15)
            {
                TextBox15.Text = item.calistigiSaat.ToString();
                PuantajToplam[14] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 16)
            {
                TextBox16.Text = item.calistigiSaat.ToString();
                PuantajToplam[15] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 17)
            {
                TextBox17.Text = item.calistigiSaat.ToString();
                PuantajToplam[16] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 18)
            {
                TextBox18.Text = item.calistigiSaat.ToString();
                PuantajToplam[17] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 19)
            {
                TextBox19.Text = item.calistigiSaat.ToString();
                PuantajToplam[18] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 20)
            {
                TextBox20.Text = item.calistigiSaat.ToString();
                PuantajToplam[19] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 21)
            {
                TextBox21.Text = item.calistigiSaat.ToString();
                PuantajToplam[20] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 22)
            {
                TextBox22.Text = item.calistigiSaat.ToString();
                PuantajToplam[21] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 23)
            {
                TextBox23.Text = item.calistigiSaat.ToString();
                PuantajToplam[22] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 24)
            {
                TextBox24.Text = item.calistigiSaat.ToString();
                PuantajToplam[23] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 25)
            {
                TextBox25.Text = item.calistigiSaat.ToString();
                PuantajToplam[24] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 26)
            {
                TextBox26.Text = item.calistigiSaat.ToString();
                PuantajToplam[25] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 27)
            {
                TextBox27.Text = item.calistigiSaat.ToString();
                PuantajToplam[26] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 28)
            {
                TextBox28.Text = item.calistigiSaat.ToString();
                PuantajToplam[27] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 29)
            {
                TextBox29.Text = item.calistigiSaat.ToString();
                PuantajToplam[28] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 30)
            {
                TextBox30.Text = item.calistigiSaat.ToString();
                PuantajToplam[29] = Convert.ToInt16(item.calistigiSaat);
            }
            else if (item.tarih.Value.Day == 31)
            {
                TextBox31.Text = item.calistigiSaat.ToString();
                PuantajToplam[30] = Convert.ToInt16(item.calistigiSaat);
            }
        }


    }





    protected void ddlCalisanlar_SelectedIndexChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < PuantajToplam.Length; i++) 
        {
            PuantajToplam[i] = 0;
        }
            detayPuantajGunGun();
            double toplamPuantaj = 0;
            for (int i = 0; i < PuantajToplam.Length; i++)
            {
                toplamPuantaj = toplamPuantaj + PuantajToplam[i];
            }

            lblToplamPuantajYaz.Text = toplamPuantaj.ToString();
    }

    protected void btnTopluPuantaj_Click(object sender, EventArgs e)
    {
       
        if (Session["kontroltoplu"] == "0") {
            Session["kontroltoplu"] = "1";
            Session["kontrolkisiSecerek"] = "0";
            return;
        }
        if (Session["kontroltoplu"] == "1") 
        {
            Session["kontroltoplu"] = "0";
            return;
        }
    }
    protected void btnKisiSecerek_Click(object sender, EventArgs e)
    {
        
        if (Session["kontrolkisiSecerek"] == "0")
        {
            Session["kontroltoplu"] = "0";
            Session["kontrolkisiSecerek"] = "1";
            return;
        }
        if (Session["kontrolkisiSecerek"] == "1") 
        { 
            Session["kontrolkisiSecerek"] = "0";
            return; 
        }
    }
    protected void GridViewTarih_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

        TextBox txt = (TextBox)sender;
        int id = Convert.ToInt16(txt.ID.Substring(7)) -1;
        try
        {
            if (txt.Text != "")
                PuantajToplam[id] = Convert.ToDouble(txt.Text);


            if (txt.Text == "")
                PuantajToplam[id] = 0;
           
            double x = 0;
            foreach (double item in PuantajToplam)
            {
                x = x + item;
            }
            lblToplamPuantajYaz.Text = x.ToString();
        }
        catch { txt.Text = ""; }
    }

}