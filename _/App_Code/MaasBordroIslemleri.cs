using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using skscalismaModel;
/// <summary>
/// Summary description for MaasBordroIslemleri
/// </summary>
public class MaasBordroIslemleri
{

    int _bordroAy, _bordroYil;

    public MaasBordroIslemleri(int bordroAy, int bordroYil)
    {

        _bordroAy = bordroAy;
        _bordroYil = bordroYil;

    }


    public string calistigBirimAdi(string ogrNo)
    {
        TurnaEntities turna = new TurnaEntities();
        var calistiBolum = from caYer in turna.tblCalismaYerleri
                           join birim in turna.tblBirimler
                           on caYer.calisacagiCalistigiYer equals birim.id
                           where caYer.ogrNo == ogrNo
                           select new { birimAdi = birim.adi };

        string birimAdi = "?";

        foreach (var itemCB in calistiBolum)
        {

            birimAdi = itemCB.birimAdi;
        }

        return birimAdi;



    }

    public int calistigBirimID(string ogrNo)
    {
        TurnaEntities turna = new TurnaEntities();
        var calistiBolum = from caYer in turna.tblCalismaYerleri
                           join birim in turna.tblBirimler
                           on caYer.calisacagiCalistigiYer equals birim.id
                           where caYer.ogrNo == ogrNo
                           select new { birim.id };

        int birimID = -1;

        foreach (var itemCB in calistiBolum)
        {

            birimID = itemCB.id;
        }

        return birimID;



    }

    public string calisanOgrenimTuru(string ogrNo)
    {
        TurnaEntities turna = new TurnaEntities();
        var ogrOgrenimTuru = from ogr in turna.tblOgrenci
                             join ogrenmTuru in turna.tblOgrenimTuru
                             on ogr.ogrenimTuru equals ogrenmTuru.ogrenimNo
                             where ogr.ogrNo == ogrNo
                             select new { ogrenmTuru.adi };


        foreach (var item2 in ogrOgrenimTuru)
        {
            return item2.adi;
        }

        return "?";


    }


    public double calisanTopSaat(string ogrNo)
    {
        TurnaEntities turna = new TurnaEntities();
        var calisanTopSaatQuery = from calisanSaat in turna.tblCalisanYoklama
                                  where calisanSaat.ogrNo == ogrNo && calisanSaat.tarih.Value.Month == _bordroAy && calisanSaat.tarih.Value.Year == _bordroYil
                                  select new { calisanSaat.calistigiSaat };

        double toplamSaat = 0;
        foreach (var item2 in calisanTopSaatQuery)
        {
            toplamSaat += Convert.ToDouble(item2.calistigiSaat);
        }

        return toplamSaat;

    }

    public double calisanGunSayi(string ogrNo)
    {


        double toplamSaat = calisanTopSaat(ogrNo);

        if (toplamSaat > 3)
        {
            return Convert.ToInt16(toplamSaat / 7.5);
        }
        else if (toplamSaat != 0 && toplamSaat < 4)
        {
            return 1;
        }

        return 0;
    }
    public double calisanGunSay(string ogrNo)
    {


        double toplamSaat = calisanTopSaat(ogrNo);
        double gun = calisanGunSayi(ogrNo);
        double gunx = toplamSaat / 7.5;


        if (gun >= gunx)
        {
            return gun;
        }
        else 

        return gun+1;
    }

    public int ogrOgrenimTuru(string ogrNo)
    {
        TurnaEntities turna = new TurnaEntities();
        var ogrOgrenimTuruQuery = from ogr in turna.tblOgrenci
                                  where ogr.ogrNo == ogrNo
                                  select new { ogr.ogrenimTuru };


        foreach (var item3 in ogrOgrenimTuruQuery)
        {
            return Convert.ToInt16(item3.ogrenimTuru);
        }
        return -1;
    }

    public double ogrOgrenimTuruBirimFiyat(string ogrNo)
    {
        TurnaEntities turna = new TurnaEntities();
        var sabitlerQuery = turna.tblOdenekler;

        int ogrTuruAl = ogrOgrenimTuru(ogrNo);


        foreach (var item2 in sabitlerQuery)
        {

            if (ogrTuruAl == 1)//önlisans
            {
                return Convert.ToDouble(item2.onlisansBirimFiyati);
            }
            else if (ogrTuruAl == 2)//lisans
            {
                return Convert.ToDouble(item2.lisanBirimFiyati);
            }
            else if (ogrTuruAl == 3)//yükseklisans
            {
                return Convert.ToDouble(item2.yuksekLisansBirimFiyati);
            }
            else if (ogrTuruAl == 4)//doktora
            {
                return Convert.ToDouble(item2.doktoraBirimFiyati);
            }
        }
        return -1;
    }

    public double getirAsgariBrutUcret()
    {
        TurnaEntities turna = new TurnaEntities();
        var sabitlerQuery = turna.tblOdenekler;
        foreach (var item2 in sabitlerQuery)
        {
            return Convert.ToDouble(item2.asgariBrutUcret);
        }
        return -1;


    }

    public double getirAsgariGunlukUcret()
    {
        TurnaEntities turna = new TurnaEntities();
        var sabitlerQuery = turna.tblOdenekler;
        foreach (var item2 in sabitlerQuery)
        {
            return Convert.ToDouble(item2.asgariGunlukUcret);
        }
        return -1;
    }


    public double getirGss43Orani()
    {
        TurnaEntities turna = new TurnaEntities();
        var sabitlerQuery = turna.tblOdenekler;
        foreach (var item2 in sabitlerQuery)
        {
            return Convert.ToDouble(item2.GSS43Orani);
        }
        return -1;
    }

    public double getirGelirVergisiOrani()
    {
        TurnaEntities turna = new TurnaEntities();
        var sabitlerQuery = turna.tblOdenekler;

        foreach (var item2 in sabitlerQuery)
        {
            return Convert.ToDouble(item2.gelirVergisi);
        }
        return -1;
    }

    public double getirDamgaVergisi()
    {
        TurnaEntities turna = new TurnaEntities();
        var sabitlerQuery = turna.tblOdenekler;
        foreach (var item2 in sabitlerQuery)
        {
            return Convert.ToDouble(item2.damgaVergisi);
        }
        return -1;
    }



    public double calisanYasalKesinti(string ogrNo)///oranını döndürüyor.
    {
        TurnaEntities turna = new TurnaEntities();
        var yasalKesQuery = from yaslKes in turna.tblYasalKesinti
                            where yaslKes.ogrNo == ogrNo
                            select new { yaslKes.yasalKesintiOrani };
        double yasalKesinti = 0;
        foreach (var itemYasalKes in yasalKesQuery)
        {

            yasalKesinti += Convert.ToDouble(itemYasalKes.yasalKesintiOrani);
        }
        return Math.Round(yasalKesinti, 2, MidpointRounding.AwayFromZero);


    }

    public double calisanYasalKesintiOrani(string ogrNo)
    {
        TurnaEntities turna = new TurnaEntities();
        var yasalKesQuery = from yaslKes in turna.tblYasalKesinti
                            where yaslKes.ogrNo == ogrNo && yaslKes.yansitilcakMaasDonemi.Value.Month == _bordroAy
                            && yaslKes.yansitilcakMaasDonemi.Value.Year == _bordroYil
                            select new { yaslKes.yasalKesintiOrani };
        double yasalKesinti = 0;
        foreach (var itemYasalKes in yasalKesQuery)
        {

            yasalKesinti += Convert.ToDouble(itemYasalKes.yasalKesintiOrani);
        }
        return yasalKesinti;


    }

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

    public double SKSGunlukBrutHesapla(double ogrenimTuruBirimFiyat)
    {
        return myRound((ogrenimTuruBirimFiyat * 7.5).ToString());
    }
    public double brutMaasTopHesapla(string ogrNo)
    {
        return myRound((calisanTopSaat(ogrNo) * ogrOgrenimTuruBirimFiyat(ogrNo)).ToString());
    }

    public double brutMaasGunTopHesapla(double SGKGunlukBrut, double SKSGunlukBrut,string ogrNo)
    {
        if (SGKGunlukBrut > SKSGunlukBrut)
        {
            return myRound(((calisanGunSay(ogrNo)) * (getirAsgariGunlukUcret())).ToString());//SGKPrimEsasına göre ödenene ücret.

        }
        else
        {
           return myRound(((calisanGunSay(ogrNo)) * SKSGunlukBrut).ToString());//SGKPrimEsasına göre ödenene ücret.

        }

    }

    public double sgkIsciPrimiYuzde5Hesapla(double brutMaasGunTop, double brutMaasTop)
    {

        if (brutMaasGunTop > brutMaasTop)
        {


            return myRound((getirGss43Orani() * brutMaasGunTop).ToString());
        }
        else
        {
            return myRound((getirGss43Orani() * brutMaasTop).ToString());
        }
    }
    public double gelirVergisiOncesiCikanTutarHesapla(double brutMaasTop, double sgkIsciPrimiYuzde5)
    {
        return myRound((brutMaasTop - sgkIsciPrimiYuzde5 + sgkIsciPrimiYuzde5).ToString());
    }
    public double gelirVergisiTutariHesapla(double gelirVergisiOncesiCikanTutar) 
    {
       return myRound((gelirVergisiOncesiCikanTutar * getirGelirVergisiOrani()).ToString());
    }
    public double damgaVergisiTutariHesapla(double brutMaasTop)
    {
       return myRound((brutMaasTop * getirDamgaVergisi()).ToString());
    }
    public double yasalKesOncesiBrutHesapla(double gelirVergisiOncesiCikanTutar, double gelirVergisiTutari, double damgaVergisiTutari)
    {
       return myRound((gelirVergisiOncesiCikanTutar - gelirVergisiTutari - damgaVergisiTutari).ToString());
    }
    public double yasalKesintiHesapla(double yasalKesOncesiBrut,string ogrNo)
    {
        return myRound(((calisanYasalKesinti(ogrNo) / 100) * yasalKesOncesiBrut).ToString());
    }
    public double odenecekUcretHesapla(double gelirVergisiOncesiCikanTutar, double yasalKesinti, double damgaVergisiTutari)
    {
        return myRound((gelirVergisiOncesiCikanTutar - yasalKesinti - damgaVergisiTutari).ToString());//netUcret
        // odenecekUcret = double.Parse(odenecekUcret.ToString("0.##"));
    }
    public double asgariBurutUcretHesapla(string ogrNo)
    {
        return myRound((calisanTopSaat(ogrNo) * ogrOgrenimTuruBirimFiyat(ogrNo)).ToString()); 
    }
    public void calisanBordroOlustur(string ay, string yil, int persID)
    {
        TurnaEntities turna = new TurnaEntities();

        ///////////Toplam Bilgileri Hata Düzeltmesi//////////////////

        tblOgrenciMaasTopBilgileri topMaasBilgi = new tblOgrenciMaasTopBilgileri()
        {

            ilgiliAy = Convert.ToDateTime("1/" + ay.ToString() + "/" + yil.ToString()),
            olusturanPersID = persID,
            olusturmaTarihi = DateTime.Now,
            topAylikBrutUcret = "Oluştu",
            topCalisanSaat = "Hata",
            topCalisanSay = "",
            topDamgaVergisiKes = "Oluşturun ",
            topGelirVergisiKes = "Tekrar",
            topNetUcret = "",
            topSGKPrimIsciYuzde5 = "",
            topUcretGelirVergisiEsas = "",
            topUcretSGKPrimHesabinaEsas = "",
            topYasalKesinti = "",




        };

        turna.tblOgrenciMaasTopBilgileri.AddObject(topMaasBilgi);
        turna.SaveChanges();



        /////////////////////////////////////////////////////////
        int bordroAy = Convert.ToInt16(ay);
        int bordroYil = Convert.ToInt16(yil);

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
                     where (((sgk.SGKCikis.Value.Month >= bordroAy && sgk.SGKCikis.Value.Year >= bordroYil)) || sgk.SGKCikis == null)
                     && (((sgk.SGKGiris.Value.Month <= bordroAy && sgk.SGKGiris.Value.Year <= bordroYil)) || sgk.SGKGiris.Value.Year < bordroYil)
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

        int BirimID;
        /////toplam Verileri
        double topCalisanSaat = 0;
        double topAylikBrutUcret = 0;
        double topUcretSGKPrimHesabinaEsas = 0;
        double topSGKPrimIsciYuzde5 = 0;
        double topUcretGelirVergisiEsas = 0;
        double topGelirVergisiKes = 0;
        double topDamgaVergisiKes = 0;
        double topYasalKesinti = 0;
        double topNetUcret = 0;
        int topCalisanSay = 0;



 double calisanSaat = 0f;

       


        foreach (var item in getir)
        {




            BirimID = calistigBirimID(item.ogrNo);




            string ogrTuru = calisanOgrenimTuru(item.ogrNo);





            var sgkGetir = from sgkGC in turna.SGKGirisCikis
                           where sgkGC.ogrNo == item.ogrNo
                           select new { sgkGC.SGKGiris, sgkGC.SGKCikis };

            DateTime sgkG = Convert.ToDateTime("1.1.0001 00:00:00");
            DateTime sgkC = Convert.ToDateTime("1.1.0001 00:00:00");

            foreach (var itemSgk in sgkGetir)
            {
                if (itemSgk.SGKGiris != null)
                    sgkG = Convert.ToDateTime(itemSgk.SGKGiris);

                if (itemSgk.SGKCikis != null)
                    sgkC = Convert.ToDateTime(itemSgk.SGKCikis);

            }


            string TC = item.tc;


            string ad = item.ad;
            string soyad = item.soyad;

            string GSS = "-1";

            if (item.GSS2243 == "22")
            {
                GSS = "22";
            }
            else if (item.GSS2243 == "43")
            {
                GSS = "43";
            }





            calisanSaat = calisanTopSaat(item.ogrNo);






            double ogrenimTuruBirimFiyat = ogrOgrenimTuruBirimFiyat(item.ogrNo);





            string ogrNo = item.ogrNo;




            double saat = 7.5;


            double SGKGunlukBrut = getirAsgariGunlukUcret();
            double SKSGunlukBrut = SKSGunlukBrutHesapla(ogrenimTuruBirimFiyat);








            double brutMaasTop = 0;

            double brutMaasGunTop = 0;

            brutMaasTop = brutMaasTopHesapla(item.ogrNo);

            brutMaasGunTop = brutMaasGunTopHesapla(SGKGunlukBrut, SKSGunlukBrut, item.ogrNo);
            


            // brutMaasGunTop = Math.Round(brutMaasGunTop, 2);




            if (item.GSS2243 == "43" && calisanSaat != 0)
            {
                sgkIsciPrimiYuzde5 = sgkIsciPrimiYuzde5Hesapla(brutMaasGunTop, brutMaasTop);
                

            }


            gelirVergisiOncesiCikanTutar = 0;
            if (calisanSaat != 0)
                gelirVergisiOncesiCikanTutar = gelirVergisiOncesiCikanTutarHesapla(brutMaasTop, sgkIsciPrimiYuzde5);

            if (calisanSaat != 0)
            {
                gelirVergisiTutari = gelirVergisiTutariHesapla(gelirVergisiOncesiCikanTutar);

            }






           if (calisanSaat != 0)
                damgaVergisiTutari = damgaVergisiTutariHesapla(brutMaasTop);





            if (calisanSaat != 0)
                yasalKesOncesiBrut = yasalKesOncesiBrutHesapla(gelirVergisiOncesiCikanTutar, gelirVergisiTutari, damgaVergisiTutari);

            // double YasalKes = 0;
            if (calisanSaat != 0)
                yasalKesinti = yasalKesintiHesapla(yasalKesOncesiBrut, item.ogrNo);


            if (calisanSaat != 0)
                odenecekUcret = odenecekUcretHesapla(gelirVergisiOncesiCikanTutar, yasalKesinti, damgaVergisiTutari);



            double CalisanGunSay = calisanGunSay(item.ogrNo);

            double asgariGunlukUcret = getirAsgariGunlukUcret();

            // double asgariBurutUcret = getirAsgariBrutUcret();
            double calisanYasalKes = calisanYasalKesinti(item.ogrNo);
            double calisanYasalKesOrani = calisanYasalKesintiOrani(item.ogrNo);
            int ogrenimSekli = ogrOgrenimTuru(item.ogrNo);
            //tblOgrenciMaas ogrMaasEkle = new tblOgrenciMaas()
            //{

            //    aitOlduguAy = Convert.ToDateTime("1." + ay.ToString() + "." + yil.ToString()),
            //    aylikBrutUcret = Convert.ToDecimal(asgariBurutUcret),
            //    calistigiGunSayisi = CalisanGunSay.ToString(),
            //    damgaVergisiTutari = Convert.ToDecimal(damgaVergisiTutari),
            //    düzenlemeTarihi = DateTime.Now,
            //    gelirVergisiTutari = Convert.ToDecimal(gelirVergisiTutari),
            //    GSS43Prim = Convert.ToDecimal(sgkIsciPrimiYuzde5),
            //    odenecekUcret = Convert.ToDecimal(brutMaasTop),
            //    ogrenimSekli = ogrenimSekli,
            //    ogrNo = ogrNo,
            //    ogrTC = TC,
            //    yasalKesinti = Convert.ToDecimal(calisanYasalKes),
            //    yasalKesintiOrani = Convert.ToDecimal(calisanYasalKesOrani),
            //    SGKPrimHesabinaEsasUcretHesabi = Convert.ToDecimal(brutMaasGunTop),
            //    SGKGirisTarihi = sgkG,
            //    SGKCikisTarihi = sgkC,
            //    asgariGunlukBrut = Convert.ToDecimal(asgariGunlukUcret),
            //    calistigiBirimID = BirimID,
            //    GSS = GSS,
            //    calistigiSaat = Convert.ToDecimal(calisanSaat)

            //};

            //turna.tblOgrenciMaas.Add(ogrMaasEkle);

            //turna.SaveChanges();

            decimal calYasKes = Convert.ToDecimal(calisanYasalKes);


            double asgariBurutUcret = asgariBurutUcretHesapla(item.ogrNo);


            turna.ogrMaasEkle(Convert.ToDateTime("1." + ay.ToString() + "." + yil.ToString()),
                Math.Round(Convert.ToDecimal(asgariBurutUcret), 2, MidpointRounding.AwayFromZero),
                CalisanGunSay.ToString(),
                Convert.ToDecimal(damgaVergisiTutari),
                DateTime.Now,
                Convert.ToDecimal(gelirVergisiTutari),
                Convert.ToDecimal(sgkIsciPrimiYuzde5),
                Math.Round(Convert.ToDecimal(brutMaasTop), 2, MidpointRounding.AwayFromZero),
                ogrenimSekli,
                ogrNo,
                TC,
                calYasKes,
                Convert.ToDecimal(calisanYasalKesOrani),
                Math.Round(Convert.ToDecimal(brutMaasGunTop), 2, MidpointRounding.AwayFromZero),
                sgkG,
                sgkC,
                Math.Round(Convert.ToDecimal(asgariGunlukUcret), 2, MidpointRounding.AwayFromZero),
                BirimID,
                GSS,
                Convert.ToDecimal(calisanSaat),
                Convert.ToDecimal(ogrenimTuruBirimFiyat));

            ////toplam Veriler.

            topCalisanSaat += calisanSaat;
            topAylikBrutUcret += brutMaasTop;
            if (brutMaasTop > brutMaasGunTop)
            {
                topUcretSGKPrimHesabinaEsas += brutMaasTop;
            }
            else
            {
                topUcretSGKPrimHesabinaEsas += brutMaasGunTop;
            }


            /////////////////////myround eklendi yüzde5 kesintiye

            topSGKPrimIsciYuzde5 += Math.Round(sgkIsciPrimiYuzde5, 2, MidpointRounding.AwayFromZero);



            topUcretGelirVergisiEsas += gelirVergisiOncesiCikanTutar;
            topGelirVergisiKes += gelirVergisiTutari;
            topDamgaVergisiKes += damgaVergisiTutari;
            topYasalKesinti += yasalKesinti;
            topNetUcret += odenecekUcret;
            topCalisanSay++;




            //////kişisel Veriler.
            sgkIsciPrimiYuzde5 = 0;
            odenecekUcret = 0.0;
            gelirVergisiTutari = 0.0;
            gelirVergisiOncesiCikanTutar = 0.0;
            damgaVergisiTutari = 0.0;
            yasalKesOncesiBrut = 0.0;
            yasalKesinti = 0.0;






        }//item

        topAylikBrutUcret = Math.Round(topAylikBrutUcret, 2, MidpointRounding.AwayFromZero);
        topDamgaVergisiKes = Math.Round(topDamgaVergisiKes, 2, MidpointRounding.AwayFromZero);
        topGelirVergisiKes = Math.Round(topGelirVergisiKes, 2, MidpointRounding.AwayFromZero);
        topNetUcret = Math.Round(topNetUcret, 2, MidpointRounding.AwayFromZero);
        topSGKPrimIsciYuzde5 = Math.Round(topSGKPrimIsciYuzde5, 2, MidpointRounding.AwayFromZero);
        topUcretGelirVergisiEsas = Math.Round(topUcretGelirVergisiEsas, 2, MidpointRounding.AwayFromZero);

       

        topUcretSGKPrimHesabinaEsas = Math.Round(topUcretSGKPrimHesabinaEsas, 2, MidpointRounding.AwayFromZero);
        topYasalKesinti = Math.Round(topYasalKesinti, 2, MidpointRounding.AwayFromZero);


        DateTime ilgiliTarih = Convert.ToDateTime("1/" + ay.ToString() + "/" + yil.ToString());

        tblOgrenciMaasTopBilgileri topMaasBilgiEkle = turna.tblOgrenciMaasTopBilgileri.First(n => n.ilgiliAy == ilgiliTarih);


        //  ilgiliAy = Convert.ToDateTime("1/" + ay.ToString() + "/" + yil.ToString());
        topMaasBilgiEkle.olusturanPersID = persID;
        topMaasBilgiEkle.olusturmaTarihi = DateTime.Now;
        topMaasBilgiEkle.topAylikBrutUcret = topAylikBrutUcret.ToString();
        topMaasBilgiEkle.topCalisanSaat = topCalisanSaat.ToString();
        topMaasBilgiEkle.topCalisanSay = topCalisanSay.ToString();
        topMaasBilgiEkle.topDamgaVergisiKes = topDamgaVergisiKes.ToString();
        topMaasBilgiEkle.topGelirVergisiKes = topGelirVergisiKes.ToString();
        topMaasBilgiEkle.topNetUcret = topNetUcret.ToString();
        topMaasBilgiEkle.topSGKPrimIsciYuzde5 = topSGKPrimIsciYuzde5.ToString();
        topMaasBilgiEkle.topUcretGelirVergisiEsas = topUcretGelirVergisiEsas.ToString();
        topMaasBilgiEkle.topUcretSGKPrimHesabinaEsas = topUcretSGKPrimHesabinaEsas.ToString();
        topMaasBilgiEkle.topYasalKesinti = topYasalKesinti.ToString();






        //  turna.tblOgrenciMaasTopBilgileri.Add(topMaasBilgiEkle);
        turna.SaveChanges();

    }

    public int eksikGunHesabı(string _girisTarihi, string _cikisTarihi,int calistigiGun) 
    {
        DateTime girisTarihi = DateTime.MinValue, cikisTarihi = DateTime.MinValue;
            
        if (_girisTarihi != "-1")
        {
            girisTarihi = Convert.ToDateTime(_girisTarihi);
        }
        if (_cikisTarihi != "-1")
        {
            cikisTarihi = Convert.ToDateTime(_cikisTarihi);
        }

        DateTime isTarih = DateTime.Parse("1" + "/" + _bordroAy.ToString() + "/" + _bordroYil.ToString());
        int gunSay = DateTime.DaysInMonth(_bordroYil, _bordroAy);
        if ((girisTarihi.Year < _bordroYil || (girisTarihi.Month < _bordroAy && girisTarihi.Year == _bordroYil)) && 
            (cikisTarihi == DateTime.MinValue || (cikisTarihi.Month > _bordroAy && cikisTarihi.Year == _bordroYil) || cikisTarihi.Year > _bordroYil))
        {
            
            return gunSay - calistigiGun;
        }
        else if ((girisTarihi.Month == _bordroAy && girisTarihi.Year == _bordroYil) && 
            (cikisTarihi == DateTime.MinValue || (cikisTarihi.Month != _bordroAy && cikisTarihi.Year == _bordroYil) || cikisTarihi.Year != _bordroYil))
        {
            return (gunSay - girisTarihi.Day ) - calistigiGun + 1;
        }
        else if ((girisTarihi.Month == _bordroAy && girisTarihi.Year == _bordroYil) && 
            ((cikisTarihi.Month == _bordroAy && cikisTarihi.Year == _bordroYil) ))
        {
            return cikisTarihi.Day - girisTarihi.Day - calistigiGun + 1;
        }
        else if (((girisTarihi.Year < _bordroYil || (girisTarihi.Month < _bordroAy && girisTarihi.Year == _bordroYil)) && 
            ((cikisTarihi.Month == _bordroAy && cikisTarihi.Year == _bordroYil) )))
	    {
            return cikisTarihi.Day - calistigiGun;
	    }
        return 0;
    }

    private void XML(int bordroAy, int bordroYil,string _GSS) 
    {
        /* int sira22=0;
         * int sira43=0;
         * 
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
                             where GSS.GSS2243 == _GSS && ((((sgk.SGKCikis.Value.Month >= bordroAy && sgk.SGKCikis.Value.Year >= bordroYil)) || sgk.SGKCikis == null)
                             && (((sgk.SGKGiris.Value.Month <= bordroAy && sgk.SGKGiris.Value.Year == bordroYil)) || sgk.SGKGiris.Value.Year < bordroYil))
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
         * if (_GSS==22)
         * {
         * 
         * sayi22++
         * }
         * else
         * {
         * 
         * sayi43++
         * }
         * 
         




                 
         
         
         
         
         
         
         
         
         
         
         
         */
        TurnaEntities turna = new TurnaEntities();

        string serverPath = "~/assets/XML/" + _bordroAy.ToString() + bordroYil.ToString() +"_"+_GSS+".xml";
       // XmlTextWriter createXML = new XmlTextWriter(HttpContext.Current.Server.MapPath(serverPath), System.Text.UTF8Encoding.UTF8);
        //createXML.Formatting = Formatting.Indented;

        string xmlTemp = null;

       xmlTemp = @"<?xml version=""1.0"" encoding=""iSO-8859-9""?>";


       // createXML.WriteStartDocument();
        //createXML.WriteComment("skscalisma.sakarya.edu.tr tarafından otomatik olarak oluşturulmuştur.");
        //XML içine Açıklama satırı ekleme

       // createXML.WriteStartElement("AYLIKBILDIRGELER");
        //Başlangıç etiketimiz
        xmlTemp += "<AYLIKBILDIRGELER>";
        

        //XmlDocument _data = new XmlDocument();
        //_data.Load(HttpContext.Current.Server.MapPath(serverPath));

        //XmlElement _element = _data.CreateElement("AYLIKBILDIRGELER");
        // _element.SetAttribute("item", Guid.NewGuid().ToString());

        // createXML.WriteStartElement("ISYERI");
         xmlTemp += "<ISYERI ";
        // _isyeri.InnerText = "ISYERI";
         xmlTemp += @"ISYERISICIL=""156100101100497805401"" KONTROLNO=""1"" ISYERIARACINO=""0"" ISYERIUNVAN=""SAKARYA ÜNİVERSİTESİ SAĞ.KÜL.DAİ.BŞK."" ISYERIADRES=""ESENTEPE KAMPÜSÜ ADAPAZARI "" ISYERIVERGINO=""7400422305"" />";
         //createXML.WriteAttributeString("ISYERISICIL", "156100101100497805401");
         //createXML.WriteAttributeString("KONTROLNO", "1");
         //createXML.WriteAttributeString("ISYERIARACINO", "0");
         //createXML.WriteAttributeString("ISYERIUNVAN", "SAKARYA ÜNİVERSİTESİ SAĞ.KÜL.DAİ.BŞK.");
         //createXML.WriteAttributeString("ISYERIADRES", "ESENTEPE KAMPÜSÜ ADAPAZARI ");
         //createXML.WriteAttributeString("ISYERIVERGINO", "7400019682");
        //_data.AppendChild(_isyeri);
         //createXML.WriteEndDocument();

        // createXML.WriteStartElement("BORDRO");
         xmlTemp += "<BORDRO ";
        // _isyeri.InnerText = "ISYERI";
         xmlTemp += @"DONEMAY=""" + _bordroAy.ToString() + @""""+ " ";
         xmlTemp += @"DONEMYIL=""" + _bordroYil.ToString() + @""""+" ";
         xmlTemp += @"BELGEMAHIYET=""A""/>";
         //createXML.WriteAttributeString("DONEMAY", _bordroAy.ToString());
         //createXML.WriteAttributeString("DONEMYIL", _bordroYil.ToString());
         //createXML.WriteAttributeString("BELGEMAHIYET", "A");
        //_data.AppendChild(_bordro);
         

       // createXML.WriteStartElement("BILDIRGELER");
        xmlTemp += "<BILDIRGELER ";
        // _isyeri.InnerText = "ISYERI";
        xmlTemp += @"BELGETURU=""" + _GSS + @""" KANUN=""00000"">";
       // createXML.WriteAttributeString("BELGETURU", "22");
       // createXML.WriteAttributeString("KANUN", "00000");
       // _data.AppendChild(_bildirgeler);

        //createXML.WriteStartElement("SIGORTALILAR");
        xmlTemp += "<SIGORTALILAR>";
        // _isyeri.InnerText = "ISYERI";
        //_bildirgeler.AppendChild(_sigortalılar);

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
                     where GSS.GSS2243 == _GSS && ((((sgk.SGKCikis.Value.Month >= bordroAy && sgk.SGKCikis.Value.Year >= bordroYil)) || sgk.SGKCikis == null)
                     && (((sgk.SGKGiris.Value.Month <= bordroAy && sgk.SGKGiris.Value.Year == bordroYil)) || sgk.SGKGiris.Value.Year < bordroYil))
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
        int sira = 0;
        foreach (var item in getir)
        {




            sira++;
            if (sira == 152)
            {
                
            }
            //createXML.WriteStartElement("SIGORTALI");
            xmlTemp += "<SIGORTALI ";
            xmlTemp += @"SIRA=""" + sira.ToString() + @""" ";
            xmlTemp += @"TCKNO=""" + item.tc.ToString() + @""" ";
            xmlTemp += @"AD=""" + item.ad.ToString().TrimEnd(' ') + @""" ";
            xmlTemp += @"SOYAD=""" + item.soyad.ToString().TrimEnd(' ') + @""" ";
            //createXML.WriteAttributeString("SIRA", sira.ToString());
            //createXML.WriteAttributeString("TCKNO", item.tc.ToString());
            //createXML.WriteAttributeString("AD", item.ad.ToString().TrimEnd(' '));
            //createXML.WriteAttributeString("SOYAD", item.soyad.ToString().TrimEnd(' '));





            //yeniSatir[1] = bordroIslem.calistigBirimAdi(item.ogrNo);




            //yeniSatir[5] = bordroIslem.calisanOgrenimTuru(item.ogrNo);





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



            //yeniSatir[2] = item.tc;

            //yeniSatir[3] = item.ad;
            //yeniSatir[4] = item.soyad;

            //if (sgkG != "-1")
            //    yeniSatir[6] = sgkG;
            //if (sgkC != "-1")
            //    yeniSatir[7] = sgkC;






            double calisanSaat = 0.0;
            double ogrBirimFiyat = 0.0;
            double brutUcret = 0.0;
            double SGKGunHesabiBrutUcret = 0.0;




            var getirBordroQuery = from ogrMaasBordro in turna.tblOgrenciMaas
                                   where ogrMaasBordro.aitOlduguAy.Value.Month == bordroAy && ogrMaasBordro.aitOlduguAy.Value.Year == bordroYil
                                   && ogrMaasBordro.ogrNo == item.ogrNo
                                   select new
                                   {
                                       ogrMaasBordro.calistigiSaat,

                                       ogrMaasBordro.ogrenimTuruBirimFiyat,
                                       ogrMaasBordro.aylikBrutUcret,
                                       ogrMaasBordro.SGKPrimHesabinaEsasUcretHesabi,
                                       ogrMaasBordro.GSS43Prim,
                                       ogrMaasBordro.GSS,
                                       ogrMaasBordro.damgaVergisiTutari,
                                       ogrMaasBordro.calistigiGunSayisi,
                                       ogrMaasBordro.gelirVergisiTutari

                                   };



            double GSS43Kes = 0.0;
            string GSSDurumu = "";
            double damgaVer = 0.0;
            string calistigiGunSay = "";
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
                calistigiGunSay = itemBordro.calistigiGunSayisi;

            }









            //yeniSatir[10] = calisanSaat.ToString();

            //yeniSatir[11] = ogrBirimFiyat;







            //double brutMaasTop = 0;

            // double brutMaasGunTop = 0;

            // brutMaasTop = bordroIslem.calisanTopSaat(item.ogrNo) * bordroIslem.ogrOgrenimTuruBirimFiyat(item.ogrNo);
            // yeniSatir[12] = brutUcret;

            // brutMaasGunTop = bordroIslem.calisanGunSay(item.ogrNo) * bordroIslem.getirAsgariGunlukUcret();
            //  yeniSatir[13] = SGKGunHesabiBrutUcret;


            ////////////XML Devammmmmm//////////////////

           
            if (SGKGunHesabiBrutUcret >= brutUcret)
            {
               // createXML.WriteAttributeString("PEK", SGKGunHesabiBrutUcret.ToString());
                xmlTemp += @"PEK=""" + SGKGunHesabiBrutUcret.ToString().Replace(',','.') + @""" ";
               
            }
            else
            {

                //createXML.WriteAttributeString("PEK", brutUcret.ToString());
                xmlTemp += @"PEK=""" + brutUcret.ToString().Replace(',','.') + @""" ";
                


            }
           // _bordro.SetAttribute("GUN", calistigiGunSay);

            DateTime sgkGiris = DateTime.MinValue, sgkCikis = DateTime.MinValue;
            if (sgkC != "-1")
            {
                sgkCikis = Convert.ToDateTime(sgkC);
            }
            if (sgkG != "-1")
            {
                sgkGiris = Convert.ToDateTime(sgkG);
            }

           // createXML.WriteAttributeString("GUN", calistigiGunSay);
            xmlTemp += @"GUN=""" + calistigiGunSay.ToString() + @""" ";


            if (sgkGiris.Month == _bordroAy && sgkGiris.Year == _bordroYil)
            {
                //createXML.WriteAttributeString("GIRISGUN", sgkGiris.Day.ToString() + sgkGiris.Month.ToString());
                string _girisGun = sgkGiris.Day.ToString();
                string girisGun, girisAy;
                string _girisAy = sgkGiris.Month.ToString();
                if (_girisGun.Count() == 1)
                    girisGun = "0" + _girisGun;
                else
                    girisGun = _girisGun;
                if (_girisAy.Count() == 1)
                    girisAy = "0" + _girisAy;
                else
                    girisAy = _girisAy;
                xmlTemp += @"GIRISGUN=""" + girisGun + girisAy + @""" ";

            }
            if (sgkCikis.Month == _bordroAy && sgkCikis.Year == _bordroYil)
            {
                //createXML.WriteAttributeString("CIKISGUN", sgkCikis.Day.ToString() + sgkCikis.Month.ToString());
                string _cikiGun = sgkCikis.Day.ToString();
                string cikisGun, cikisAy;
                string _cikisAy = sgkCikis.Month.ToString();
                if (_cikiGun.Count() == 1)
                    cikisGun = "0" + _cikiGun;
                else
                    cikisGun = _cikiGun;
                if (_cikisAy.Count() == 1)
                    cikisAy = "0" + _cikisAy;
                else
                    cikisAy = _cikisAy;
                
                xmlTemp += @"CIKISGUN=""" + cikisGun + cikisAy  + @""" ";

            }


            //createXML.WriteAttributeString("EKSIKGUNSAYISI", eksikGunHesabı(sgkG, sgkC, Convert.ToInt16(calistigiGunSay)).ToString());
            xmlTemp += @"EKSIKGUNSAYISI=""" + eksikGunHesabı(sgkG, sgkC, Convert.ToInt16(calistigiGunSay)).ToString() + @""" ";

            //createXML.WriteAttributeString("EKSIKGUNNEDENI", "6");
            xmlTemp += @"EKSIKGUNNEDENI=""" + "6" + @""" ";

            if (sgkCikis.Month == _bordroAy && sgkCikis.Year == _bordroYil)
            {
                //createXML.WriteAttributeString("ISTENCIKISNEDENI", "22");
                xmlTemp += @"ISTENCIKISNEDENI=""" + "22" + @""" ";

            }
            xmlTemp += @"MESLEKKOD=""" + "9901.02" + @""" ";
            //createXML.WriteAttributeString("RAPCALISTI", "2");
            xmlTemp += @"RAPCALISTI=""" + "2" + @""" ";


            if (item.GSS2243 == "43" && calisanSaat != 0)
            {
                sgkIsciPrimiYuzde5 = GSS43Kes;
            }

            //  yeniSatir[14] = sgkIsciPrimiYuzde5;



            //  yeniSatir[15] = gelirVergisiOncesiCikanTutar = myRound((brutUcret - sgkIsciPrimiYuzde5).ToString());

            if (calisanSaat != 0)
                //   gelirVergisiTutari = gelirVergisiOncesiCikanTutar * bordroIslem.getirGelirVergisiOrani();

                //  yeniSatir[16] = gelirVergisiTutari;

                //if (calisanSaat != 0)
                // yeniSatir[17] = damgaVergisiTutari = damgaVer;
                // else
                //   yeniSatir[17] = 0;

                //    if (calisanSaat != 0)
                //     //   yeniSatir[18] = yasalKesOncesiBrut = Math.Round((gelirVergisiOncesiCikanTutar - gelirVergisiTutari - damgaVergisiTutari), 2, MidpointRounding.AwayFromZero);
                //    else
                //        yeniSatir[18] = 0;

                //    if (calisanSaat != 0)
                //        yeniSatir[19] = yasalKesinti = Math.Round((yasalKesOncesiBrut * ((bordroIslem.calisanYasalKesinti(item.ogrNo))) / 100), 2, MidpointRounding.AwayFromZero);
                //    else
                //        yeniSatir[19] = 0;

                //    if (calisanSaat != 0)
                //        yeniSatir[20] = odenecekUcret = Math.Round((yasalKesOncesiBrut - yasalKesinti), 2, MidpointRounding.AwayFromZero);
                //    else
                //        yeniSatir[20] = 0;

                //    yeniSatir[21] = bordroIslem.calisanGunSay(item.ogrNo);        

                //    yeniSatir[22] = bordroIslem.getirAsgariGunlukUcret();





                //dt.Rows.Add(yeniSatir);

                

            sgkIsciPrimiYuzde5 = 0;
            odenecekUcret = 0.0;
            gelirVergisiTutari = 0.0;
            gelirVergisiOncesiCikanTutar = 0.0;
            damgaVergisiTutari = 0.0;
            yasalKesOncesiBrut = 0.0;
            yasalKesinti = 0.0;

            

           // _data.DocumentElement.AppendChild(_element);
            //createXML.WriteEndElement();

            xmlTemp += "/>";
          


        }//item
        xmlTemp += "</SIGORTALILAR></BILDIRGELER></AYLIKBILDIRGELER>";
        //createXML.WriteEndElement();
        //createXML.WriteEndElement();
        //createXML.WriteEndElement();

        XmlDocument docXMLTemp = new XmlDocument();

        docXMLTemp.LoadXml(xmlTemp);

        docXMLTemp.Save(HttpContext.Current.Server.MapPath(serverPath));
            
       



       

        //createXML.Close();
      
    }
    

    public void XMLOlustur(int bordroAy, int bordroYil)
    {


        XML(bordroAy, bordroYil,"22");

        XML(bordroAy, bordroYil, "43");
        


    }
    
}



