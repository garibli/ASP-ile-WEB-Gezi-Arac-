using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using skscalismaModel;

/// <summary>
/// Summary description for VeriCek
/// </summary>
public class VeriIslemleri
{
    
    TurnaEntities turna = new TurnaEntities();
    //**---------------Veri Çek-------------------------**//
  

    public bool persGiris(string mail,string yetki)
    {
        if (mail == null || yetki == "ogr")
            return true;

        return false;
    }
    public void ddlVeriCekBirimlerIlanEkle(DropDownList ddl, int birimId)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("SEÇİNİZ", "-1"));




        var getir = from birim in turna.tblBirimler
                    where birim.id == birimId
                    orderby birim.adi ascending
                    select new { birim.id, birim.adi };



        foreach (var item in getir)
        {
            ddl.Items.Add(new ListItem(item.adi.ToString(), item.id.ToString()));
        }
    }

    public void ddlVeriCekFakYukOkul(DropDownList ddl,string birimTuruEngelle)
	{
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("SEÇİNİZ", "-1"));

        var getir = from birim in turna.tblBirimler
                    orderby birim.adi ascending
                    select new { birim.id, birim.adi,birim.BirimTuru};

        
        foreach (var item in getir)
        {

            if (item.BirimTuru != birimTuruEngelle)
            ddl.Items.Add(new ListItem(item.adi.ToString(), item.id.ToString()));

        }
	}
    public void ddlVeriCekBolumunuz(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("SEÇİNİZ", "-1"));
        var getir = from bolum in turna.tblBolumler
                    orderby bolum.adi ascending
                    select new { bolum.adi, bolum.id };

        foreach (var item in getir)
        {
           
            ddl.Items.Add(new ListItem(item.adi.ToString(),item.id.ToString()));
        }

        
    }
    public void ddlVeriCekOgrenimTuru(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem(null, null));
        var getir = from ogrenimTuru in turna.tblOgrenimTuru select new { ogrenimTuru.adi,ogrenimTuru.id };

        foreach (var item in getir)
        {
            ddl.Items.Add(new ListItem(item.adi.ToString(), item.id.ToString()));
        }
    }
    public void ddlVeriCekBirimler(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("SEÇİNİZ", "-1"));
        
        
      

        var getir = from birim in turna.tblBirimler
                    orderby birim.adi ascending
                    select new { birim.id, birim.adi};



        foreach (var item in getir)
        {
            ddl.Items.Add(new ListItem(item.adi.ToString(), item.id.ToString()));
        }
    }
    public void ddlVeriCekParamBirimler(DropDownList ddl, int id)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem(null, null));
        var getir = from birimGetir in turna.tblBirimler where birimGetir.id == id orderby birimGetir.adi select new { birimGetir.id, birimGetir.adi };
          

        foreach (var item in getir)
        {
            ddl.Items.Add(new ListItem(item.adi.ToString(), item.id.ToString()));
        }
    }
    public void ddlVeriCekPersonelYetki(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem(null, null));
        var getir = from yetkiTuru in turna.tblYetkiTuru orderby yetkiTuru.adi select new { yetkiTuru.id, yetkiTuru.adi };

        //select * from tblYetkiTuru ORDER BY adi ASC;

        foreach (var item in getir)
        {
            ddl.Items.Add(new ListItem(item.adi.ToString(), item.id.ToString()));
        }
    }
    public void ddlVeriCekCalismaSekli (DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem(null, null));
        var getir = from calismaSekli in turna.tblCalismaSekli orderby calismaSekli.adi select new { calismaSekli.adi,calismaSekli.id };
            
            //turna.isTanimiGetir();
        
        //select * from tblCalismaSekli ORDER BY adi ASC;
        
        foreach (var item in getir)
        {
            ddl.Items.Add(new ListItem(item.adi.ToString(), item.id.ToString()));
        }
    }
    public void ddlVeriCekParamBolumlerGetir(DropDownList ddl, int birimID)
    {
        
        
            ddl.Items.Clear();
           ddl.Items.Add(new ListItem("SEÇİNİZ", "-1"));

            var getir = from bolumler in turna.tblBolumler where (bolumler.birimID == birimID)
                        orderby bolumler.adi ascending
                        select new { bolumler.adi,bolumler.id };
        

            foreach (var item in getir)
            {
                
                ddl.Items.Add(new ListItem(item.adi.ToString(), item.id.ToString()));

                ddl.SelectedIndex = 1;
            }

           
            
    
        
    }
    public void ddlVeriCekParamAltBirimCalisanGetir(DropDownList ddl,int birimID,int altBirimID,DateTime dt){
        
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("SEÇİNİZ",  "-1"));
          //  DateTime dt = DateTime.Now;
            var getir = (from ogr in turna.tblOgrenci
                         join calismaYer in turna.tblCalismaYerleri on ogr.id equals calismaYer.ogrID
                         join sgk in turna.SGKGirisCikis on
                         ogr.id equals sgk.ogrID
                         where calismaYer.calisacagiCalistigiYer == birimID && calismaYer.calisacagiCalistigiAltBirimi == altBirimID &&
                         ((sgk.SGKCikis.Value.Month >= dt.Month && (sgk.SGKCikis.Value.Year >= dt.Year)) || sgk.SGKCikis == null)
                         && ((sgk.SGKGiris.Value.Month <= dt.Month && sgk.SGKGiris.Value.Year <= dt.Year))
                         orderby ogr.ad ascending
                         select new { ogr.ogrNo, ogr.ad, ogr.soyad, ogr.id });



            foreach (var item in getir)
            {
                ddl.Items.Add(new ListItem(item.ad.ToString() + " " + item.soyad.ToString()+" "+item.ogrNo.ToString() , item.id.ToString()));
            }
        
    }
    public void ddlVeriCekParamBirimCalisanGetir(DropDownList ddl, int birimID,DateTime dt)
    {
        
             ddl.Items.Clear();
             ddl.Items.Add(new ListItem("SEÇİNİZ", "-1"));
            // DateTime dt = DateTime.Now;

             //var sorgu = (from ogr in turna.tblOgrenci
             //             join calismaYer in turna.tblCalismaYerleri on ogr.id equals calismaYer.ogrID
             //             join sgk in turna.SGKGirisCikis on
             //             ogr.id equals sgk.ogrID
             //             where calismaYer.calisacagiCalistigiYer == birimID && ((sgk.SGKCikis.Value.Month >= dt.Month && (sgk.SGKCikis.Value.Year >= dt.Year)) || sgk.SGKCikis == null)
             //             orderby ogr.ad ascending
             //             select new { ogr.ogrNo, ogr.ad, ogr.soyad, ogr.id }).Distinct();
           
        
             //int birOncekiAy = DateTime.Now.AddMonths(-1).Month;
             //int birOncekiYil = DateTime.Now.AddMonths(-1).Year;


             var sorgu = (from ogr in turna.tblOgrenci
                          join sgk in turna.SGKGirisCikis
                          on ogr.ogrNo equals sgk.ogrNo
                          join calismaYer in turna.tblCalismaYerleri
                          on ogr.ogrNo equals calismaYer.ogrNo
                          where calismaYer.calisacagiCalistigiYer == birimID &&
                         ((sgk.SGKCikis.Value.Month >= dt.Month && (sgk.SGKCikis.Value.Year >= dt.Year)) || sgk.SGKCikis == null)
                          && (((sgk.SGKGiris.Value.Month <= dt.Month && sgk.SGKGiris.Value.Year <= dt.Year)) || sgk.SGKGiris.Value.Year < dt.Year)
                          orderby ogr.ad ascending
                          select new { ogr.ogrNo, ogr.ad, ogr.soyad, ogr.id });



            foreach (var item in sorgu)
            {
                ddl.Items.Add(new ListItem(item.ad.ToString() + " " + item.soyad.ToString()+ " "+item.ogrNo.ToString() , item.id.ToString()));
            }
        
    }



    public void ddlVeriCekParamBirimCalisanGetirIDogrNo(DropDownList ddl, int birimID)
    {

        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("SEÇİNİZ", "-1"));
        DateTime dt = DateTime.Now;

        //var sorgu = (from ogr in turna.tblOgrenci
        //             join calismaYer in turna.tblCalismaYerleri on ogr.id equals calismaYer.ogrID
        //             join sgk in turna.SGKGirisCikis on
        //             ogr.id equals sgk.ogrID
        //             where calismaYer.calisacagiCalistigiYer == birimID && ((sgk.SGKCikis.Value.Month >= dt.Month && (sgk.SGKCikis.Value.Year >= dt.Year)) || sgk.SGKCikis == null)
        //             orderby ogr.ad ascending
        //             select new { ogr.ogrNo, ogr.ad, ogr.soyad, ogr.id }).Distinct();


        int birOncekiAy = DateTime.Now.AddMonths(-1).Month;
        int birOncekiYil = DateTime.Now.AddMonths(-1).Year;


        var sorgu = (from ogr in turna.tblOgrenci
                     join sgk in turna.SGKGirisCikis
                     on ogr.ogrNo equals sgk.ogrNo
                     join calismaYer in turna.tblCalismaYerleri
                     on ogr.ogrNo equals calismaYer.ogrNo
                     where calismaYer.calisacagiCalistigiYer == birimID &&
                     sgk.SGKGiris <= DateTime.Now
                     && (sgk.SGKCikis == null
                     || ((sgk.SGKCikis.Value.Month == DateTime.Now.Month && sgk.SGKCikis.Value.Year == DateTime.Now.Year) ||
                         (sgk.SGKCikis.Value.Month == birOncekiAy && sgk.SGKCikis.Value.Year == birOncekiYil)))
                     orderby ogr.ad ascending
                     select new { ogr.ogrNo, ogr.ad, ogr.soyad, ogr.id });



        foreach (var item in sorgu)
        {
            ddl.Items.Add(new ListItem(item.ad.ToString() + " " + item.soyad.ToString()+" "+item.ogrNo.ToString(), item.ogrNo.ToString()));
        }

    }



    bool ogrVarmı(string ogrNo)
    {

        var varmı = from ogr in turna.tblOgrenci
                    where ogr.ogrNo == ogrNo
                    select new { ogr.ogrNo };

        foreach (var item in varmı)
        {
            return true;
        }

        return false;


    }
    
    //**---------------Veri Kaydet---------------------**//
  


    //**----------------Veri Güncelle-------------------**//

    public bool guncelleKontenjanAzalt(int birimID, int bolumID, int calismaSekli)
    {

        TurnaEntities turna = new TurnaEntities();

        if (bolumID != -1)
        {
            var getir = from bolum in turna.tblBolumler
                        where bolum.id == bolumID
                        select new { bolum.AkademiKon, bolum.IdariKon, bolum.YedekAkademiKon, bolum.YedekIdariKon };




            int kontenjanAka = -1;
            int kontenjanIdari = -1;
            foreach (var item in getir)
            {
                kontenjanAka = Convert.ToInt16(item.AkademiKon) + Convert.ToInt16(item.YedekAkademiKon);
                kontenjanIdari = Convert.ToInt16(item.IdariKon) + Convert.ToInt16(item.YedekIdariKon);

            }

            if (calismaSekli == 1)
            {
                var calisanSay = from calisan in turna.tblCalismaYerleri
                                 where calisan.aktifMi == "1" && calisan.calisacagiCalistigiYer == birimID
                                 && calisan.calismaSekli == 1
                                 select new { calisan.id };
                int topCalisanSay = 0;
                foreach (var itemCalisanSay in calisanSay)
                {
                    topCalisanSay++;
                }

                if (topCalisanSay < kontenjanAka)
                {
                    return true;
                }

            }
            else
            {
                var calisanSay = from calisan in turna.tblCalismaYerleri
                                 where calisan.aktifMi == "1" && calisan.calisacagiCalistigiYer == birimID
                                 && calisan.calismaSekli == 2
                                 select new { calisan.id };
                int topCalisanSay = 0;
                foreach (var itemCalisanSay in calisanSay)
                {
                    topCalisanSay++;
                }

                if (topCalisanSay < kontenjanIdari)
                {
                    return true;
                }
            }

            return false;








        }
        return false;
    }

     

    public bool guncelleKontenjanArttir(int birimID, int bolumID)
    {

        TurnaEntities turna = new TurnaEntities();

        if (bolumID == -1)
        {
            var getir = from birim in turna.tblBirimler
                        where birim.id == birimID
                        select new { birim.UstKontenjan };

            int kontenjan = -1;
            foreach (var item in getir)
            {
                kontenjan = Convert.ToInt16(item.UstKontenjan);
            }

            if (kontenjan < 1)
            {
                return false;
            }
            else
            {

                tblBirimler konteAzalt = turna.tblBirimler.First(n => n.id == birimID);

                konteAzalt.UstKontenjan += 1;

                turna.SaveChanges();

                return true;



            }



        }
        else
        {
            var getir = from bolum in turna.tblBolumler
                        where bolum.id == bolumID
                        select new { bolum.altKontenjan };


            int altKontenjan = -1;
            foreach (var item in getir)
            {
                altKontenjan = Convert.ToInt16(item.altKontenjan);
            }

            if (altKontenjan < 1)
            {
                return false;
            }
            else
            {
                tblBolumler konteAzalt = turna.tblBolumler.First(n => n.id == birimID);

                konteAzalt.altKontenjan += 1;

                turna.SaveChanges();

                return true;

            }


        }





    }



    
}