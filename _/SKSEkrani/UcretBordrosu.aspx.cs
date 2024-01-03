using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using skscalismaModel;
public partial class SKSEkrani_UcretBordrosu : System.Web.UI.Page
{

    public double myRound(string sayi)
    {
        string[] sayiSplit = sayi.Split(',');
        bool arttir = false;
        if (sayiSplit.Count() >= 2)
        {


            for (int i = 0; i < sayiSplit[1].Count(); i++)
            {
                if (i == 2)
                {
                    if (Convert.ToInt16(sayiSplit[1][i]) > 4)
                    {
                        arttir = true;
                        break;
                    }
                }

            }
            if (arttir)
            {
                sayiSplit[1] += 01;
            }

            double sayRet = Convert.ToDouble((sayiSplit[0] + "," + sayiSplit[1]));


            return Math.Round(sayRet, 2);
        }
        else
        {
            return Convert.ToDouble(sayi);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.


        TurnaEntities turna = new TurnaEntities();

        DataTable dt = new DataTable("bordro");
        dt.Columns.Add("sira");//0
        dt.Columns.Add("birimAdi");//1
        dt.Columns.Add("TC");//2
        dt.Columns.Add("adi");//3
        dt.Columns.Add("soyadi");//4
        dt.Columns.Add("ogrenimTuru");//5
        dt.Columns.Add("SGKGiris");//6
        dt.Columns.Add("SGKCikis");//7
        dt.Columns.Add("GSSaile");//8
        dt.Columns.Add("GSSkendisi");//9
       
        dt.Columns.Add("calisanSaat");//no 10
        dt.Columns.Add("ucretSaatlikBrut");//11
        dt.Columns.Add("ucretAylikBrut");//12
        dt.Columns.Add("SGKPrimHesabinaEsasUcrethesabi");//13
        dt.Columns.Add("SGKPrimiIsciYuzde5");//14
        dt.Columns.Add("ucretGelirVergisineEsas");//15
        dt.Columns.Add("gelirVergisiKes");//16
        dt.Columns.Add("damgaVergisiKes");//17
        dt.Columns.Add("yasalKesintiOncesiBrut");//18
        dt.Columns.Add("yasalKesinti");//19
        dt.Columns.Add("Agi");//20
        dt.Columns.Add("netUcret");//21
        dt.Columns.Add("calisilanGunHesabi");//22
        dt.Columns.Add("ucretGunluk");//23
        dt.Columns.Add("SGKPrimHesabinaEsasUcretBildirimi");//24


        int bordroAy = Convert.ToInt16(Session["bordroAy"].ToString());
        int bordroYil = Convert.ToInt16(Session["bordroYil"].ToString());

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
                     join maasBordro in turna.tblOgrenciMaas
                     on ogr.ogrNo equals maasBordro.ogrNo
                     //where // && (sgk.SGKCikis == null || (sgk.SGKCikis.Value.Month >= puantajAy && sgk.SGKCikis.Value.Year >= puantajYıl))
                     where (((sgk.SGKCikis.Value.Month >= bordroAy && sgk.SGKCikis.Value.Year >= bordroYil)) || sgk.SGKCikis == null)
                     && (((sgk.SGKGiris.Value.Month <= bordroAy && sgk.SGKGiris.Value.Year == bordroYil)) || sgk.SGKGiris.Value.Year < bordroYil)
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


        double sgkIsciPrimiYuzde5 = 0;
        double odenecekUcret = 0.0;
        double gelirVergisiTutari = 0.0;
        double gelirVergisiOncesiCikanTutar = 0.0;
        double damgaVergisiTutari = 0.0;
        double yasalKesOncesiBrut = 0.0;
        double yasalKesinti = 0.0;

        MaasBordroIslemleri bordroIslem = new MaasBordroIslemleri(bordroAy, bordroYil);

        foreach (var item in getir)
        {
            
            

            DataRow yeniSatir;
            yeniSatir = dt.NewRow();
            
          //yeniSatir[0] = i.ToString();



            yeniSatir[1] = bordroIslem.calistigBirimAdi(item.ogrNo);




            yeniSatir[5] = bordroIslem.calisanOgrenimTuru(item.ogrNo);
           




            //var sgkGetir = from sgkGC in turna.SGKGirisCikis
            //               where sgkGC.ogrNo == item.ogrNo
            //               select new { sgkGC.SGKGiris, sgkGC.SGKCikis };

            var sgkGetir = from sgkGC in turna.tblOgrenciMaas
                           where sgkGC.aitOlduguAy.Value.Month == bordroAy && sgkGC.aitOlduguAy.Value.Year == bordroYil &&
                           sgkGC.ogrNo == item.ogrNo
                           select new { sgkGC.SGKGirisTarihi, sgkGC.SGKCikisTarihi };

            string sgkG = "-1";
            string sgkC = "-1";

            foreach (var itemSgk in sgkGetir)
            {
                if (itemSgk.SGKGirisTarihi != null && itemSgk.SGKGirisTarihi != Convert.ToDateTime("1.1.0001"))
                    sgkG = itemSgk.SGKGirisTarihi.Value.ToShortDateString();
                else
                    sgkG = "-1";
                if (itemSgk.SGKCikisTarihi != null && itemSgk.SGKCikisTarihi != Convert.ToDateTime("1.1.0001"))
                    sgkC = itemSgk.SGKCikisTarihi.Value.ToShortDateString();
                else
                    sgkC = "-1";
            }


            yeniSatir[2] = item.tc;
           
            yeniSatir[3] = item.ad;
            yeniSatir[4] = item.soyad;
            
            if (sgkG != "-1")
                yeniSatir[6] = sgkG;
            if (sgkC != "-1")
                yeniSatir[7] = sgkC;

            




            double calisanSaat = 0.0;
            double ogrBirimFiyat = 0.0;
            double brutUcret = 0.0;
            double SGKGunHesabiBrutUcret = 0.0;




            var getirBordroQuery = from ogrMaasBordro in turna.tblOgrenciMaas
                             where ogrMaasBordro.aitOlduguAy.Value.Month == bordroAy && ogrMaasBordro.aitOlduguAy.Value.Year == bordroYil
                             && ogrMaasBordro.ogrNo == item.ogrNo
                             select new { ogrMaasBordro.calistigiSaat,
                                            
                                            ogrMaasBordro.ogrenimTuruBirimFiyat,
                                            ogrMaasBordro.aylikBrutUcret,
                                            ogrMaasBordro.SGKPrimHesabinaEsasUcretHesabi,
                                           ogrMaasBordro.GSS43Prim,
                                           ogrMaasBordro.GSS,
                                           ogrMaasBordro.damgaVergisiTutari,
                                           ogrMaasBordro.gelirVergisiTutari
                                            
                             };


            double GSS43Kes = 0.0;
            string GSSDurumu = "";
            double damgaVer = 0.0;
            foreach (var itemBordro in getirBordroQuery)
            {
                calisanSaat = Convert.ToDouble(itemBordro.calistigiSaat);
                ogrBirimFiyat = Convert.ToDouble(itemBordro.ogrenimTuruBirimFiyat);
                brutUcret = Convert.ToDouble(itemBordro.aylikBrutUcret);
                SGKGunHesabiBrutUcret = Convert.ToDouble(itemBordro.SGKPrimHesabinaEsasUcretHesabi);
                GSS43Kes = Convert.ToDouble(itemBordro.GSS43Prim);
                GSSDurumu = itemBordro.GSS.ToString();
                damgaVer = Convert.ToDouble(itemBordro.damgaVergisiTutari);
                gelirVergisiTutari = Convert.ToDouble(itemBordro.gelirVergisiTutari);

            }



            if (GSSDurumu == "22")
            {
                yeniSatir[8] = "22";
                yeniSatir[9] = "";
            }
            else if (GSSDurumu == "43")
            {
                yeniSatir[8] = "43";
                yeniSatir[9] = "";
            }






            yeniSatir[10] = calisanSaat.ToString();

            yeniSatir[11] = ogrBirimFiyat;
                    



               
                    string ogrNo = item.ogrNo;

           

                


                        //double brutMaasTop = 0;

                       // double brutMaasGunTop = 0;
                            
                       // brutMaasTop = bordroIslem.calisanTopSaat(item.ogrNo) * bordroIslem.ogrOgrenimTuruBirimFiyat(item.ogrNo);
                        yeniSatir[12] = brutUcret;

                       // brutMaasGunTop = bordroIslem.calisanGunSay(item.ogrNo) * bordroIslem.getirAsgariGunlukUcret();
                        yeniSatir[13] = SGKGunHesabiBrutUcret;

                        if (SGKGunHesabiBrutUcret >= brutUcret)
                        {
                            yeniSatir[23] = SGKGunHesabiBrutUcret;
                        }
                        else
                        {
                            yeniSatir[23] = brutUcret;
                        }
                        

                    if (item.GSS2243 == "43" && calisanSaat != 0)
                    {
                        sgkIsciPrimiYuzde5 = GSS43Kes;
                    }
                  
                    yeniSatir[14] = sgkIsciPrimiYuzde5;


                    if (calisanSaat != 0)
                        yeniSatir[15] = gelirVergisiOncesiCikanTutar = brutUcret ;
                    else
                        yeniSatir[15] = 0;
                    if (calisanSaat != 0)
                 //   gelirVergisiTutari = gelirVergisiOncesiCikanTutar * bordroIslem.getirGelirVergisiOrani();
                    
                    yeniSatir[16] = gelirVergisiTutari;

                    if (calisanSaat != 0)
                        yeniSatir[17] = damgaVergisiTutari = damgaVer;
                    else
                        yeniSatir[17] = 0;

                    if (calisanSaat != 0)
                        yeniSatir[18] = yasalKesOncesiBrut = Math.Round((gelirVergisiOncesiCikanTutar - gelirVergisiTutari - damgaVergisiTutari), 2, MidpointRounding.AwayFromZero);
                    else
                        yeniSatir[18] = 0;

                    if (calisanSaat != 0)
                        yeniSatir[19] = yasalKesinti = Math.Round((yasalKesOncesiBrut * ((bordroIslem.calisanYasalKesinti(item.ogrNo))) / 100), 2, MidpointRounding.AwayFromZero);
                    else
                        yeniSatir[19] = 0;

            yeniSatir[20] = gelirVergisiTutari;
            if (calisanSaat != 0)
                        yeniSatir[21] = odenecekUcret = Math.Round((gelirVergisiOncesiCikanTutar - damgaVergisiTutari - yasalKesinti), 2, MidpointRounding.AwayFromZero);
                    else
                        yeniSatir[21] = 0;
                    
                    yeniSatir[22] = bordroIslem.calisanGunSay(item.ogrNo);        

                    yeniSatir[23] = bordroIslem.getirAsgariGunlukUcret();
                    


                    
            	
                dt.Rows.Add(yeniSatir);

               
                sgkIsciPrimiYuzde5 = 0;
                odenecekUcret = 0.0;
                gelirVergisiTutari = 0.0;
                gelirVergisiOncesiCikanTutar = 0.0;
                damgaVergisiTutari = 0.0;
                yasalKesOncesiBrut = 0.0;
                yasalKesinti = 0.0;


        }//item



        dt.DefaultView.Sort = "birimAdi ASC, adi ASC";
       

        DataList1.DataSource = dt;
        DataList1.DataBind();




        
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        int bordroAy = Convert.ToInt16(Session["bordroAy"].ToString());
        int bordroYil = Convert.ToInt16(Session["bordroYil"].ToString());

        if (e.Item.ItemType == ListItemType.Header)
        {
           

            ((Label)e.Item.FindControl("lblAyYil")).Text = bordroAy.ToString() + " / " + bordroYil.ToString();

        }

        if (e.Item.ItemType == ListItemType.Footer)
        {

            TurnaEntities turna = new TurnaEntities();

            var getirTopBordroQuery = from topBordroGetir in turna.tblOgrenciMaasTopBilgileri
                                      where topBordroGetir.ilgiliAy.Value.Month == bordroAy &&
                                      topBordroGetir.ilgiliAy.Value.Year == bordroYil
                                      select new { topBordroGetir.topCalisanSaat,
                                      topBordroGetir.topAylikBrutUcret,
                                      topBordroGetir.topSGKPrimIsciYuzde5,
                                      topBordroGetir.topUcretSGKPrimHesabinaEsas,
                                      topBordroGetir.topUcretGelirVergisiEsas,
                                      topBordroGetir.topGelirVergisiKes,
                                      topBordroGetir.topDamgaVergisiKes,
                                      topBordroGetir.topYasalKesinti,
                                      topBordroGetir.topNetUcret
                                      };


            foreach (var item in getirTopBordroQuery)
	{
            ((Label)e.Item.FindControl("lblTopSaat")).Text = item.topCalisanSaat.ToString();
           
            ((Label)e.Item.FindControl("lblTopAylikBrut")).Text = item.topAylikBrutUcret.ToString();
            ((Label)e.Item.FindControl("lblTopSGKPrimHesabiEsas")).Text = item.topUcretSGKPrimHesabinaEsas.ToString();
            ((Label)e.Item.FindControl("lblTopSGKYuzde5")).Text = item.topSGKPrimIsciYuzde5.ToString();
            ((Label)e.Item.FindControl("lblTopGelirVergisiEsas")).Text = item.topUcretGelirVergisiEsas.ToString();
            ((Label)e.Item.FindControl("lblTopGelirVergisiKes")).Text = item.topGelirVergisiKes.ToString();
            ((Label)e.Item.FindControl("lblTopDamgaVergisiKes")).Text = item.topDamgaVergisiKes.ToString();
            ((Label)e.Item.FindControl("lblYasalKesTop")).Text = item.topYasalKesinti.ToString();
            ((Label)e.Item.FindControl("lblTopAgi")).Text = item.topGelirVergisiKes.ToString();
            ((Label)e.Item.FindControl("lblTopNetUcret")).Text = item.topNetUcret.ToString();
	}


            
        }


    }
}