using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using skscalismaModel;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public partial class SKSEkrani_SabisCalisan : System.Web.UI.Page
{
    int puantajAy;
    int puantajYıl;
    int toplamSay = 0;







    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");

        }



        TurnaEntities turna = new TurnaEntities();
        int puantajBirimi = Convert.ToInt16(Session["puantajBirim"]);
        puantajAy = Convert.ToInt16(Session["puantajAy"]);
        puantajYıl = Convert.ToInt16(Session["puantajYil"]);


        var getir = (from ogr in turna.tblOgrenci
                     join calisti in turna.tblCalismaYerleri
                     on ogr.ogrNo equals calisti.ogrNo
                     join birim in turna.tblBirimler
                     on calisti.calisacagiCalistigiYer equals birim.id

                     join sgk in turna.SGKGirisCikis
                     on ogr.ogrNo equals sgk.ogrNo
                     join GSS in turna.tblOgrHesapNoGSS
                     on ogr.ogrNo equals GSS.ogrNo

                     where (((sgk.SGKCikis.Value.Month >= puantajAy && sgk.SGKCikis.Value.Year >= puantajYıl)) || sgk.SGKCikis == null)
                     && (((sgk.SGKGiris.Value.Month <= puantajAy && sgk.SGKGiris.Value.Year <= puantajYıl)) || sgk.SGKGiris.Value.Year < puantajYıl)
                     orderby birim.adi ascending
                     select new
                     {

                         ogr.ad,
                         ogr.soyad,
                         ogr.ogrenimTuru,

                         GSS.GSS2243,
                         ogr.ogrNo,
                         ogr.tc,


                     }).Distinct();




        if (puantajBirimi != -1)
        {



            getir = (from ogr in turna.tblOgrenci
                     join calisti in turna.tblCalismaYerleri
                     on ogr.ogrNo equals calisti.ogrNo
                     join birim in turna.tblBirimler
                     on calisti.calisacagiCalistigiYer equals birim.id
                     join sgk in turna.SGKGirisCikis
                     on ogr.ogrNo equals sgk.ogrNo
                     join GSS in turna.tblOgrHesapNoGSS
                     on ogr.ogrNo equals GSS.ogrNo
                     where (calisti.calisacagiCalistigiYer == puantajBirimi) &&
                     (((sgk.SGKCikis.Value.Month >= puantajAy && sgk.SGKCikis.Value.Year >= puantajYıl)) || sgk.SGKCikis == null)
                     && (((sgk.SGKGiris.Value.Month <= puantajAy && sgk.SGKGiris.Value.Year <= puantajYıl)) || sgk.SGKGiris.Value.Year < puantajYıl) // && (sgk.SGKCikis == null || (sgk.SGKCikis.Value.Month >= puantajAy && sgk.SGKCikis.Value.Year == puantajYıl))
                     orderby birim.adi ascending
                     select new
                     {
                         ogr.ad,
                         ogr.soyad,
                         ogr.ogrenimTuru,

                         GSS.GSS2243,
                         ogr.ogrNo,
                         ogr.tc,



                     }).Distinct();

        }





        DataTable dt = new DataTable("SabisCalisan");
        dt.Columns.Add("sira");
        dt.Columns.Add("birimAdi");
        dt.Columns.Add("okulAdi");
        dt.Columns.Add("TC");
        dt.Columns.Add("adi");
        dt.Columns.Add("soyadi");
        dt.Columns.Add("ogrenimTuru");
        dt.Columns.Add("SGKGiris");
        dt.Columns.Add("SGKCikis");
        dt.Columns.Add("GSSaile");
        dt.Columns.Add("GSSkendisi");

        dt.Columns.Add("toplamSaat");

        int i = 1;
        List<OrtalamaliOgrenciBilgileri> ogrenci = new List<OrtalamaliOgrenciBilgileri>();

        foreach (var item in getir)
        {


            toplamSay++;

            var calistiBolum = from caYer in turna.tblCalismaYerleri
                               join birim in turna.tblBirimler
                               on caYer.calisacagiCalistigiYer equals birim.id
                               where caYer.ogrNo == item.ogrNo
                               select new { birimAdi = birim.adi };

            DataRow yeniSatir;
            yeniSatir = dt.NewRow();


            foreach (var itemCB in calistiBolum)
            {
                yeniSatir[1] = itemCB.birimAdi;

            }
            var calisanAltBirim = from caAltYer in turna.tblCalismaYerleri
                                  join altBirim in turna.tblBolumler
                                  on caAltYer.calisacagiCalistigiAltBirimi equals altBirim.id
                                  where caAltYer.aktifMi == "1" && caAltYer.calisacagiCalistigiAltBirimi != -1 && caAltYer.ogrNo == item.ogrNo
                                  select new { altBirim.adi };

            foreach (var itemACB in calisanAltBirim)
            {
                if (itemACB.adi != null)
                    yeniSatir[2] = itemACB.adi;



            }

            //var ogrOgrenimTuru = from ogr in turna.tblOgrenci
            //                     join ogrenmTuru in turna.tblOgrenimTuru
            //                     on ogr.ogrenimTuru equals ogrenmTuru.ogrenimNo
            //                     where ogr.ogrNo == item.ogrNo
            //                     select new { ogrenmTuru.adi };

            //foreach (var item2 in ogrOgrenimTuru)
            //{
            //    yeniSatir[6] = item2.adi;
            //}



            var sgkGetir = from sgkGC in turna.SGKGirisCikis
                           where sgkGC.ogrNo == item.ogrNo
                           select new { sgkGC.SGKGiris, sgkGC.SGKCikis };

            string sgkG = "-1";
            string sgkC = "-1";

            foreach (var itemSgk in sgkGetir)
            {
                if (itemSgk.SGKGiris != null)
                    sgkG = itemSgk.SGKGiris.Value.ToShortDateString();
                else
                    sgkG = "-1";
                if (itemSgk.SGKCikis != null)
                    sgkC = itemSgk.SGKCikis.Value.ToShortDateString();
                else
                    sgkC = "-1";
            }


            yeniSatir[3] = item.tc;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://apiois.sabis.sakarya.edu.tr/");

                //  client.BaseAddress = new Uri("http://apiois.local.sabis.sakarya.edu.tr/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response;

                response = client.GetAsync("api/OgrenciBilgi/GetOgrenciBilgiEdinme?tc=" + item.tc).Result;



                if (response.IsSuccessStatusCode)
                {
                    var ob = response.Content.ReadAsAsync<List<OgrenciGenelBilgileri>>().Result;
                    ogrenci.Add(new OrtalamaliOgrenciBilgileri() { ogrenciBilgisi = ob[0] });
                    yeniSatir[4] = ogrenci.Last().ogrenciBilgisi.AdSoyad;
                    yeniSatir[5] = ogrenci.Last().ogrenciBilgisi.FakulteYoMyoEnstitu;
                    

                }
            }
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://apiois.sabis.sakarya.edu.tr/");

                    //  client.BaseAddress = new Uri("http://apiois.local.sabis.sakarya.edu.tr/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response;

                    response = client.GetAsync("api/OgrenciBilgi/GetOzetTranskript?ogrenciID=" + ogrenci.Last().ogrenciBilgisi.ID + "?vukuatliMi=false").Result;



                    if (response.IsSuccessStatusCode)
                    {
                        var ob = response.Content.ReadAsAsync<DtoTranskriptDonemOzet>().Result;
                    ogrenci.Last().GenelNotOrtalamasi = ob.OrtalamaGenel;

                    }

                yeniSatir[6] = ogrenci.Last().GenelNotOrtalamasi;




                //yeniSatir[4] = item.ad;
                //yeniSatir[5] = item.soyad;

                if (sgkG != "-1")
                    yeniSatir[7] = sgkG;
                //if (sgkC != "-1")
                //    yeniSatir[8] = sgkC;


                //yeniSatir[10] = item.GSS2243;













                dt.Rows.Add(yeniSatir);
                i++;


            }


            dt.DefaultView.Sort = "birimAdi ASC , okulAdi ASC , adi ASC";



        }

        DataList1.DataSource = dt;
        DataList1.DataBind();
    }





    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            ((Label)e.Item.FindControl("lblAy")).Text = puantajAy.ToString();

            ((Label)e.Item.FindControl("lblYil")).Text = puantajYıl.ToString();

        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            ((Label)e.Item.FindControl("lblTopCalisan")).Text = toplamSay.ToString();

        }
    }
}