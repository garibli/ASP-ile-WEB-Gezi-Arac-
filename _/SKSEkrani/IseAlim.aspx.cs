using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_IseAlim : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();

    public void ddlOkulGetir(DropDownList ddl,string birimTuruEngelle)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("TÜM ÖĞRENCİLER", "-1"));

        var getir = from birim in turna.tblBirimler
                    orderby birim.adi ascending
                    select new { birim.id, birim.adi, birim.BirimTuru };


        foreach (var item in getir)
        {

              if (item.BirimTuru != birimTuruEngelle)
                ddl.Items.Add(new ListItem(item.adi.ToString(), item.id.ToString()));

        }
    }

    public void ddlOgrGetir(DropDownList ddl,int okulID)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("TÜM ÖĞRENCİLER", "-1"));

        var getir = from ogr in turna.tblOgrenci
                    orderby ogr.ad ascending
                    where ogr.id == -1
                    select new { ogr.ogrNo, ogr.ad, ogr.soyad };

        if (okulID == -1)
        {
            getir = from ogr in turna.tblOgrenci
                    where ogr.aktifMi == "0"
                    orderby ogr.ad ascending
                    select new { ogr.ogrNo, ogr.ad, ogr.soyad };

        }
        else
        {
            getir = from ogr in turna.tblOgrenci
                    where ogr.okulu == okulID && ogr.aktifMi == "0"
                    orderby ogr.ad ascending
                    select new { ogr.ogrNo, ogr.ad, ogr.soyad };

            
        }


        bool ekle = false;
        bool kayitYok = true;
        foreach (var item in getir)
        {

            var calisiyomu = from sgk in turna.SGKGirisCikis
                             where sgk.ogrNo == item.ogrNo
                             select new { sgk.SGKCikis };

            foreach (var item2 in calisiyomu)
            {
                kayitYok = false;
                if (item2.SGKCikis < DateTime.Now && item2.SGKCikis != null)
                    ekle = true;
                else
                    ekle = false;
            }

            if (ekle || kayitYok )
            {
                ddl.Items.Add(new ListItem(item.ad.ToString() + " " + item.soyad.ToString() +" "+ item.ogrNo.ToString() , item.ogrNo.ToString()));
    
            }

            ekle = false;
            kayitYok = true;

               }



       
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.



        if (!IsPostBack)
        {

       
        ddlOkulGetir(ddlOkulFiltrele,"0");

        ddlOgrGetir(ddlOgrenci, -1);

        ddlOkulGetir(ddlBirim,"-1");

        var calismaSekliGetir = from calismaSekli in turna.tblCalismaSekli
                           orderby calismaSekli.adi ascending
                           select new { calismaSekli.adi, calismaSekli.id };


        foreach (var item in calismaSekliGetir)
        {
            ddlCalismaSekli.Items.Add(new ListItem(item.adi.ToString(), item.id.ToString()));
        }

        }
    }
    protected void ddlOkulFiltrele_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        ddlOgrGetir(ddlOgrenci, Convert.ToInt16(ddlOkulFiltrele.SelectedValue));
    }
    protected void ddlBirim_SelectedIndexChanged(object sender, EventArgs e)
    {
        VeriIslemleri veri = new VeriIslemleri();

        veri.ddlVeriCekParamBolumlerGetir(ddlAltBirim, Convert.ToInt16(ddlBirim.SelectedValue));
    }
    protected void btnIseAl_Click(object sender, EventArgs e)
    {
        int altBirim;
        if (ddlAltBirim.SelectedValue != "")
        {
            altBirim = Convert.ToInt16(ddlAltBirim.SelectedValue);
        }
        else
        {
            altBirim = -1;
        }
         
       int birim = Convert.ToInt16(ddlBirim.SelectedValue);

       int calismaSekli;

       if (ddlCalismaSekli.SelectedValue != "")
       {
           calismaSekli = Convert.ToInt16(ddlCalismaSekli.SelectedValue);
       }
       else
       {
           calismaSekli = -1;
       }


       string ogrNo = ddlOgrenci.SelectedValue;
       
        if (birim > -1 && calismaSekli > -1 && ogrNo != "-1")
    	{
           

            var ogrIDGetir = from ogr in turna.tblOgrenci
                        where ogr.ogrNo == ogrNo
                        select new { ogr.id };
            int ogrID = -1;
            foreach (var item in ogrIDGetir)
            {
                ogrID = item.id;
            }

            VeriIslemleri veri = new VeriIslemleri();



            if (veri.guncelleKontenjanAzalt(birim, altBirim,Convert.ToInt16(ddlCalismaSekli.SelectedValue)))
            {



               // lblBilgi.Text = "İşe alım gerçekleşti puntaj girilebilmesi için sgk giriş işlemini SGK Giriş sayfasından yapınız..";


                 bool resmiTatil = true;

                 DateTime tarih = DateTime.Now;
                 while (resmiTatil)
                 {


                     



                     var resmiTatilQuery = from resTa in turna.tblResmiTatilGunleri
                                           where resTa.resmiTatil.Value.Month == tarih.Month && resTa.resmiTatil.Value.Day == tarih.Day && resTa.resmiTatil.Value.Year == tarih.Year
                                           select new { resTa.resmiTatil };



                     foreach (var item in resmiTatilQuery)
                     {
                         resmiTatil = false;
                     }
                     if (!resmiTatil)
                     {
                         tarih = tarih.AddDays(1);
                         resmiTatil = true;
                     }
                     if (resmiTatil)
                     {
                         break;
                     }

                 }


                if (tarih.DayOfWeek.ToString() != "Monday")
                {
                    if (tarih.DayOfWeek.ToString() == "Friday")
                    {
                        tarih = tarih.AddDays(3);
                    }
                    else if (tarih.DayOfWeek.ToString() == "Saturday" )
                    {
                        tarih = tarih.AddDays(2);
                    }
                    else if (tarih.DayOfWeek.ToString() == "Sunday")
                    {
                        tarih = tarih.AddDays(1);
                    }
                    else if (tarih.DayOfWeek.ToString() != "Sunday" && tarih.DayOfWeek.ToString() != "Saturday" )
                    {
                        tarih = tarih.AddDays(1);
                    }
                    
                }
               

                if (tarih.DayOfWeek.ToString() != "Saturday" && tarih.DayOfWeek.ToString() != "Sunday" && (tarih.DayOfWeek.ToString() == "Monday" || tarih.ToShortDateString() != DateTime.Now.ToShortDateString()) )
                {
                    turna.HizliIseAl(ogrID, ogrNo, birim, altBirim, calismaSekli, Convert.ToInt16(Session["persID"]));
                    turna.ogrAktifPasit("1", ogrNo);//öğrenci aktif oldu yani çalışıyor yada sgk ya giriş için bekliyor.
                    ddlOgrGetir(ddlOgrenci, -1);

                    var ogrGetirCalismaYer = from ogr in turna.tblOgrenci
                                             join calismaYer in turna.tblCalismaYerleri
                                              on ogr.ogrNo equals calismaYer.ogrNo
                                              where ogr.ogrNo == ogrNo
                                             select new { calismaYer.id };
                    int CalismaYerID = -1;
                    foreach (var item in ogrGetirCalismaYer)
                    {
                        CalismaYerID = item.id;
                    }


                    int kontrol = turna.sgkGirisCikisEkle(ogrID, ogrNo, tarih, null, CalismaYerID);//hem giriş yapılıyor hem aktif ediliyor.
                    if (kontrol == 2)
                    {

                       



                        lblBilgi.Text = ogrNo + " öğrenci numarasına sahip kişinin işe girişi başarılı bir şekilde gerçekleştirildi.";

                        Session["sozlesmeOgrNo"] = ogrNo;

                        Response.Redirect("SozlesmeGetir.aspx");


                    }
                    else
                        lblBilgi.Text = "SGK Girişi Başarısız.Lütfen tekrar deneyiniz.";
                }


            }
            else
            {
                lblBilgi.Text = "Yeterli kontenjan olmadığı için işe alım gerçekleşemedi.";
            }
        }
        else
        {
            lblBilgi.Text = "Gerekli Alanları Doldurunuz.";
        }
       


       
    }
}