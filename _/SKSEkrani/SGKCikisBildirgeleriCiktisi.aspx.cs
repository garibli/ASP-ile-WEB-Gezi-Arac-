using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using skscalismaModel;
public partial class SKSEkrani_SGKCikisBildirgeleriCiktisi : System.Web.UI.Page
{

    int puantajAy;
    int puantajYıl;
    int toplamSay = 0;
    double genelTopSaat = 0.0;


    public string PuantajSifirGosterme(string puantaj)
    {
        string[] puantajDizi = puantaj.Split(',');

        if (puantajDizi.Count() > 1)
        {
            if (Convert.ToInt16(puantajDizi[1]) == 0)
            {
                return puantajDizi[0];
            }

        }
        return puantaj;

    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

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
                     //    join bolum in turna.tblBolumler
                     //   on calisti.calisacagiCalistigiAltBirimi equals bolum.id
                     join sgk in turna.SGKGirisCikis
                     on ogr.ogrNo equals sgk.ogrNo
                     join GSS in turna.tblOgrHesapNoGSS
                     on ogr.ogrNo equals GSS.ogrNo
                     //where // && (sgk.SGKCikis == null || (sgk.SGKCikis.Value.Month >= puantajAy && sgk.SGKCikis.Value.Year >= puantajYıl))
                     where (((sgk.SGKCikis.Value.Month >= puantajAy && sgk.SGKCikis.Value.Year >= puantajYıl)) )
                     && (((sgk.SGKGiris.Value.Month <= puantajAy && sgk.SGKGiris.Value.Year <= puantajYıl)) || sgk.SGKGiris.Value.Year < puantajYıl) && ogr.aktifMi != "1"
                     orderby birim.adi ascending
                     select new
                     {
                         //              birimAdi = birim.adi,
                         //              bolumAdi = bolum.adi,
                         ogr.ad,
                         ogr.soyad,
                         ogr.ogrenimTuru,
                         //  sgk.SGKGiris,
                         //   sgk.SGKCikis,
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
                     //    join bolum in turna.tblBolumler
                     //   on calisti.calisacagiCalistigiAltBirimi equals bolum.id
                     join sgk in turna.SGKGirisCikis
                     on ogr.ogrNo equals sgk.ogrNo
                     join GSS in turna.tblOgrHesapNoGSS
                     on ogr.ogrNo equals GSS.ogrNo
                     where (calisti.calisacagiCalistigiYer == puantajBirimi) &&
                     (((sgk.SGKCikis.Value.Month >= puantajAy && sgk.SGKCikis.Value.Year >= puantajYıl)) )
                     && (((sgk.SGKGiris.Value.Month <= puantajAy && sgk.SGKGiris.Value.Year <= puantajYıl)) || sgk.SGKGiris.Value.Year < puantajYıl) && ogr.aktifMi != "1"// && (sgk.SGKCikis == null || (sgk.SGKCikis.Value.Month >= puantajAy && sgk.SGKCikis.Value.Year == puantajYıl))
                     orderby birim.adi ascending
                     select new
                     {
                         //              birimAdi = birim.adi,
                         //              bolumAdi = bolum.adi,
                         ogr.ad,
                         ogr.soyad,
                         ogr.ogrenimTuru,
                         //  sgk.SGKGiris,
                         //   sgk.SGKCikis,
                         GSS.GSS2243,
                         ogr.ogrNo,
                         ogr.tc,



                     }).Distinct();

        }





        DataTable dt = new DataTable("puantaj");
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
        dt.Columns.Add("1"); dt.Columns.Add("2"); dt.Columns.Add("3"); dt.Columns.Add("4"); dt.Columns.Add("5");
        dt.Columns.Add("6"); dt.Columns.Add("7"); dt.Columns.Add("8"); dt.Columns.Add("9"); dt.Columns.Add("10");
        dt.Columns.Add("11"); dt.Columns.Add("12"); dt.Columns.Add("13"); dt.Columns.Add("14"); dt.Columns.Add("15");
        dt.Columns.Add("16"); dt.Columns.Add("17"); dt.Columns.Add("18"); dt.Columns.Add("19"); dt.Columns.Add("20");
        dt.Columns.Add("21"); dt.Columns.Add("22"); dt.Columns.Add("23"); dt.Columns.Add("24"); dt.Columns.Add("25");
        dt.Columns.Add("26"); dt.Columns.Add("27"); dt.Columns.Add("28"); dt.Columns.Add("29"); dt.Columns.Add("30");
        dt.Columns.Add("31");
        dt.Columns.Add("toplamSaat");

        int i = 1;
        double toplamSaat = 0;
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
            //yeniSatir[0] = i.ToString();

            foreach (var itemCB in calistiBolum)
            {
                yeniSatir[1] = itemCB.birimAdi;

            }
            var calisanAltBirim = from caAltYer in turna.tblCalismaYerleri
                                  join altBirim in turna.tblBolumler
                                  on caAltYer.calisacagiCalistigiAltBirimi equals altBirim.id
                                  where caAltYer.aktifMi != "1" && caAltYer.calisacagiCalistigiAltBirimi != -1 && caAltYer.ogrNo == item.ogrNo
                                  select new { altBirim.adi };

            foreach (var itemACB in calisanAltBirim)
            {
                if (itemACB.adi != null)
                    yeniSatir[2] = itemACB.adi;



            }

            var ogrOgrenimTuru = from ogr in turna.tblOgrenci
                                 join ogrenmTuru in turna.tblOgrenimTuru
                                 on ogr.ogrenimTuru equals ogrenmTuru.ogrenimNo
                                 where ogr.ogrNo == item.ogrNo
                                 select new { ogrenmTuru.adi };

            foreach (var item2 in ogrOgrenimTuru)
            {
                yeniSatir[6] = item2.adi;
            }



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
            yeniSatir[4] = item.ad;
            yeniSatir[5] = item.soyad;
            //if(item.ogrNo[0] == 'b')
            //    yeniSatir[6] = "1. öğretim";
            //else if (item.ogrNo[0] == 'g')
            //    yeniSatir[6] = "2. öğretim";
            //else if (item.ogrNo[0] == 'u')
            //    yeniSatir[6] = "Uzaktan öğretim";
            if (sgkG != "-1")
                yeniSatir[7] = sgkG;
            if (sgkC != "-1")
                yeniSatir[8] = sgkC;

            //if (item.GSS2243 == "22")
            //{
            //    yeniSatir[9] = "22";
            //    yeniSatir[10] = "";
            //}
            // else if (item.GSS2243 == "43")
            //{
            //  yeniSatir[9] = "";
            yeniSatir[10] = item.GSS2243;
            //}





            int ay = Convert.ToInt16(Session["puantajAy"]);
            var yoklamaGetir = from ogr in turna.tblOgrenci
                               join yoklama in turna.tblCalisanYoklama
                                   on ogr.ogrNo equals yoklama.ogrNo
                               where yoklama.tarih.Value.Month == ay &&
                                   yoklama.tarih.Value.Year == DateTime.Now.Year && ogr.ogrNo == item.ogrNo
                               orderby yoklama.tarih ascending
                               select new { yoklama.tarih, yoklama.calistigiSaat };




            foreach (var item2 in yoklamaGetir)
            {
                if (item2.tarih.Value.Day == 1)
                    yeniSatir[11] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 2)
                    yeniSatir[12] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 3)
                    yeniSatir[13] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 4)
                    yeniSatir[14] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 5)
                    yeniSatir[15] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 6)
                    yeniSatir[16] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 7)
                    yeniSatir[17] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 8)
                    yeniSatir[18] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 9)
                    yeniSatir[19] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 10)
                    yeniSatir[20] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 11)
                    yeniSatir[21] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 12)
                    yeniSatir[22] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 13)
                    yeniSatir[23] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 14)
                    yeniSatir[24] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 15)
                    yeniSatir[25] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 16)
                    yeniSatir[26] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 17)
                    yeniSatir[27] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 18)
                    yeniSatir[28] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 19)
                    yeniSatir[29] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 20)
                    yeniSatir[30] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 21)
                    yeniSatir[31] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 22)
                    yeniSatir[32] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 23)
                    yeniSatir[33] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 24)
                    yeniSatir[34] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 25)
                    yeniSatir[35] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 26)
                    yeniSatir[36] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 27)
                    yeniSatir[37] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 28)
                    yeniSatir[38] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 29)
                    yeniSatir[39] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 30)
                    yeniSatir[40] = PuantajSifirGosterme(item2.calistigiSaat.ToString());
                else if (item2.tarih.Value.Day == 31)
                    yeniSatir[41] = PuantajSifirGosterme(item2.calistigiSaat.ToString());

                toplamSaat += Convert.ToDouble(item2.calistigiSaat);

            }

            yeniSatir[42] = toplamSaat.ToString();
            dt.Rows.Add(yeniSatir);
            i++;
            genelTopSaat += toplamSaat;
            toplamSaat = 0;//Diğer Çalışan İçin sıfırlanıyor.
        }


        dt.DefaultView.Sort = "birimAdi ASC , okulAdi ASC , adi ASC";


        //DataTable dt2 = new DataTable();

        //dt2 = dt;



        //for (int i2 = 0; i2 < dt.Rows.Count; i2++)
        //{
        //    dt2.Rows[1]["sira"] = (i2 + 1).ToString();
        //}


        DataList1.DataSource = dt;
        DataList1.DataBind();

        // foreach(DataListItem item in DataList1.Items)
        //{
        //    string x = ((DataBoundLiteralControl)item.Controls[0]).Text;
        //}



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
            ((Label)e.Item.FindControl("lblTopSaat")).Text = genelTopSaat.ToString();
        }
    }
}