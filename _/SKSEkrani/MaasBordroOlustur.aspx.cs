using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_MaasBordroOlustur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
        }


        if (!IsPostBack)
        {

            ddlYil.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
            ddlYil.Items.Add(new ListItem((DateTime.Now.AddYears(-1)).Year.ToString(), (DateTime.Now.AddYears(-1)).Year.ToString()));

            ddlYil.SelectedIndex = 1;
            ddlAy.SelectedValue = DateTime.Now.Month.ToString();

            dataListDoldur();

        }
    }

    //public void calisanBordroOlustur(string ay, string yil, int persID)
    //{
    //    int bordroAy = Convert.ToInt16(ay);
    //    int bordroYil = Convert.ToInt16(yil);

    //    var getir = (from ogr in turna.tblOgrenci
    //                 join calisti in turna.tblCalismaYerleri
    //                 on ogr.ogrNo equals calisti.ogrNo
    //                 join birim in turna.tblBirimler
    //                 on calisti.calisacagiCalistigiYer equals birim.id
    //                 //    join bolum in turna.tblBolumler
    //                 //   on calisti.calisacagiCalistigiAltBirimi equals bolum.id
    //                 join sgk in turna.SGKGirisCikis
    //                 on ogr.ogrNo equals sgk.ogrNo
    //                 join GSS in turna.tblOgrHesapNoGSS
    //                 on ogr.ogrNo equals GSS.ogrNo
    //                 //where // && (sgk.SGKCikis == null || (sgk.SGKCikis.Value.Month >= puantajAy && sgk.SGKCikis.Value.Year >= puantajYıl))
    //                 where (((sgk.SGKCikis.Value.Month >= bordroAy && sgk.SGKCikis.Value.Year >= bordroYil)) || sgk.SGKCikis == null)
    //                 && ((sgk.SGKGiris.Value.Month <= bordroAy && sgk.SGKGiris.Value.Year <= bordroYil))
    //                 orderby birim.adi ascending
    //                 select new
    //                 {
    //                     //              birimAdi = birim.adi,
    //                     //              bolumAdi = bolum.adi,
    //                     ogr.ad,
    //                     ogr.soyad,
    //                     ogr.ogrenimTuru,
    //                     //  sgk.SGKGiris,
    //                     //   sgk.SGKCikis,
    //                     GSS.GSS2243,
    //                     ogr.ogrNo,
    //                     ogr.tc,


    //                 }).Distinct();


    //    double sgkIsciPrimiYuzde5 = 0;
    //    double odenecekUcret = 0.0;
    //    double gelirVergisiTutari = 0.0;
    //    double gelirVergisiOncesiCikanTutar = 0.0;
    //    double damgaVergisiTutari = 0.0;
    //    double yasalKesOncesiBrut = 0.0;
    //    double yasalKesinti = 0.0;
    //    int BirimID;
    //    /////toplam Verileri
    //    double topCalisanSaat = 0;
    //    double topAylikBrutUcret = 0;
    //    double topUcretSGKPrimHesabinaEsas = 0;
    //    double topSGKPrimIsciYuzde5 = 0;
    //    double topUcretGelirVergisiEsas = 0;
    //    double topGelirVergisiKes = 0;
    //    double topDamgaVergisiKes = 0;
    //    double topYasalKesinti = 0;
    //    double topNetUcret = 0;
    //    int topCalisanSay = 0;





    //    foreach (var item in getir)
    //    {







    //        BirimID = calistigBirimID(item.ogrNo);




    //        string ogrTuru = calisanOgrenimTuru(item.ogrNo);





    //        var sgkGetir = from sgkGC in turna.SGKGirisCikis
    //                       where sgkGC.ogrNo == item.ogrNo
    //                       select new { sgkGC.SGKGiris, sgkGC.SGKCikis };

    //        DateTime sgkG = Convert.ToDateTime("1.1.0001 00:00:00");
    //        DateTime sgkC = Convert.ToDateTime("1.1.0001 00:00:00");

    //        foreach (var itemSgk in sgkGetir)
    //        {
    //            if (itemSgk.SGKGiris != null)
    //                sgkG = Convert.ToDateTime(itemSgk.SGKGiris);

    //            if (itemSgk.SGKCikis != null)
    //                sgkC = Convert.ToDateTime(itemSgk.SGKCikis);

    //        }


    //        string TC = item.tc;


    //        string ad = item.ad;
    //        string soyad = item.soyad;

    //        string GSS = "-1";

    //        if (item.GSS2243 == "22")
    //        {
    //            GSS = "22";
    //        }
    //        else if (item.GSS2243 == "43")
    //        {
    //            GSS = "43";
    //        }




    //        double calisanSaat;

    //        calisanSaat = calisanTopSaat(item.ogrNo);






    //        double ogrenimTuruBirimFiyat = ogrOgrenimTuruBirimFiyat(item.ogrNo);





    //        string ogrNo = item.ogrNo;






    //        double brutMaasTop = 0;

    //        double brutMaasGunTop = 0;

    //        brutMaasTop = calisanTopSaat(item.ogrNo) * ogrOgrenimTuruBirimFiyat(item.ogrNo);


    //        brutMaasGunTop = calisanGunSay(item.ogrNo) * getirAsgariGunlukUcret();//SGKPrimEsasına göre ödenene ücret.






    //        if (item.GSS2243 == "43" && calisanSaat != 0)
    //        {
    //            sgkIsciPrimiYuzde5 = getirGss43Orani() * brutMaasTop;
    //        }


    //        gelirVergisiOncesiCikanTutar = 0;
    //        if (calisanSaat != 0)
    //            gelirVergisiOncesiCikanTutar = brutMaasTop - sgkIsciPrimiYuzde5;

    //        if (calisanSaat != 0)
    //            gelirVergisiTutari = gelirVergisiOncesiCikanTutar * getirGelirVergisiOrani();



    //        if (calisanSaat != 0)
    //            damgaVergisiTutari = 5 * getirDamgaVergisi();


    //        if (calisanSaat != 0)
    //            yasalKesOncesiBrut = gelirVergisiOncesiCikanTutar - gelirVergisiTutari - damgaVergisiTutari;

    //        double YasalKes = 0;
    //        if (calisanSaat != 0)
    //            yasalKesinti = calisanYasalKesinti(item.ogrNo);


    //        if (calisanSaat != 0)
    //            odenecekUcret = yasalKesOncesiBrut - yasalKesinti;//netUcret


    //        double CalisanGunSay = calisanGunSay(item.ogrNo);

    //        double asgariGunlukUcret = getirAsgariGunlukUcret();


    //        tblOgrenciMaas ogrMaasEkle = new tblOgrenciMaas
    //        {

    //            aitOlduguAy = Convert.ToDateTime("1." + ay.ToString() + "." + yil.ToString()),
    //            aylikBrutUcret = Convert.ToDecimal(getirAsgariBrutUcret()),
    //            calistigiGunSayisi = CalisanGunSay.ToString(),
    //            damgaVergisiTutari = Convert.ToDecimal(damgaVergisiTutari),
    //            düzenlemeTarihi = DateTime.Now.ToShortDateString(),
    //            gelirVergisiTutari = Convert.ToDecimal(gelirVergisiTutari),
    //            GSS43Prim = Convert.ToDecimal(sgkIsciPrimiYuzde5),
    //            odenecekUcret = Convert.ToDecimal(brutMaasTop),
    //            ogrenimSekli = ogrOgrenimTuru(item.ogrNo),
    //            ogrNo = ogrNo,
    //            ogrTC = TC,
    //            yasalKesinti = Convert.ToDecimal(calisanYasalKesinti(item.ogrNo)),
    //            yasalKesintiOrani = Convert.ToDecimal(calisanYasalKesintiOrani(item.ogrNo)),
    //            SGKPrimHesabinaEsasUcretHesabi = Convert.ToDecimal(brutMaasGunTop),
    //            SGKGirisTarihi = sgkG,
    //            SGKCikisTarihi = sgkC,
    //            asgariGunlukBrut = Convert.ToDecimal(asgariGunlukUcret),
    //            calistigiBirimID = BirimID,
    //            GSS = GSS,
    //            calistigiSaat = Convert.ToDecimal(calisanSaat)

    //        };

    //        turna.tblOgrenciMaas.Add(ogrMaasEkle);

    //        turna.SaveChanges();



    //        ////toplam Veriler.
    //        topCalisanSaat += calisanSaat;
    //        topAylikBrutUcret += brutMaasTop;
    //        topUcretSGKPrimHesabinaEsas = brutMaasGunTop;
    //        topSGKPrimIsciYuzde5 += sgkIsciPrimiYuzde5;
    //        topUcretGelirVergisiEsas += gelirVergisiOncesiCikanTutar;
    //        topGelirVergisiKes += gelirVergisiTutari;
    //        topDamgaVergisiKes += damgaVergisiTutari;
    //        topYasalKesinti += calisanYasalKesinti(item.ogrNo);
    //        topNetUcret += odenecekUcret;
    //        topCalisanSay++;




    //        //////kişisel Veriler.
    //        sgkIsciPrimiYuzde5 = 0;
    //        odenecekUcret = 0.0;
    //        gelirVergisiTutari = 0.0;
    //        gelirVergisiOncesiCikanTutar = 0.0;
    //        damgaVergisiTutari = 0.0;
    //        yasalKesOncesiBrut = 0.0;
    //        yasalKesinti = 0.0;






    //    }//item


    //    tblOgrenciMaasTopBilgileri topMaasBilgi = new tblOgrenciMaasTopBilgileri()
    //    {
    //        ilgiliAy = Convert.ToDateTime("1/" + ay.ToString() + "/" + yil.ToString()),
    //        olusturanPersID = persID,
    //        olusturmaTarihi = DateTime.Now,
    //        topAylikBrutUcret = topAylikBrutUcret.ToString(),
    //        topCalisanSaat = topCalisanSaat.ToString(),
    //        topCalisanSay = topCalisanSay.ToString(),
    //        topDamgaVergisiKes = topDamgaVergisiKes.ToString(),
    //        topGelirVergisiKes = topGelirVergisiKes.ToString(),
    //        topNetUcret = topNetUcret.ToString(),
    //        topSGKPrimIsciYuzde5 = topSGKPrimIsciYuzde5.ToString(),
    //        topUcretGelirVergisiEsas = topUcretGelirVergisiEsas.ToString(),
    //        topUcretSGKPrimHesabinaEsas = topUcretSGKPrimHesabinaEsas.ToString(),
    //        topYasalKesinti = topYasalKesinti.ToString()


    //    };

    //    turna.tblOgrenciMaasTopBilgileri.Add(topMaasBilgi);
    //    turna.SaveChanges();

    //}

    public void dataListDoldur() 
    {
 
        TurnaEntities turna = new TurnaEntities();
        var getir = from bordroOzet in turna.tblOgrenciMaasTopBilgileri
                    join pers in turna.tblPersonel
                    on bordroOzet.olusturanPersID equals pers.id
                    select new
                    {
                        bordroOzet.id,
                        bordroOzet.ilgiliAy,
                        bordroOzet.olusturmaTarihi,
                        bordroOzet.topAylikBrutUcret,
                        bordroOzet.topCalisanSaat,
                        bordroOzet.topCalisanSay,
                        bordroOzet.topDamgaVergisiKes,
                        bordroOzet.topGelirVergisiKes,
                        bordroOzet.topNetUcret,
                        bordroOzet.topSGKPrimIsciYuzde5,
                        bordroOzet.topUcretGelirVergisiEsas,
                        bordroOzet.topUcretSGKPrimHesabinaEsas,
                        bordroOzet.topYasalKesinti,
                        persAdSoyad = pers.adi + " " + pers.soyad
                    };


        DataList1.DataSource = getir.ToList();
        DataList1.DataBind();




    }



    protected void btnOlustur_Click(object sender, EventArgs e)
    {
        if (ddlAy.SelectedValue != "" && ddlYil.SelectedValue != "")
        {

         //   lblBilgi.Text = "Bordro oluşturma işlemi bir kaç dakika sürebilir. Lütfen Bekleyiniz...";

            int ay = Convert.ToInt16(ddlAy.SelectedValue);
            int yil = Convert.ToInt16(ddlYil.SelectedValue);
            TurnaEntities turna = new TurnaEntities();

            var bordroVarmi = from bordro in turna.tblOgrenciMaas
                              where bordro.aitOlduguAy.Value.Month == ay && bordro.aitOlduguAy.Value.Year == yil
                              select new { bordro.ogrNo };

            bool bordroVar = false;

            foreach (var item in bordroVarmi)
            {
                bordroVar = true;
            }

            if (!bordroVar)
            {
                Session["bordroAy"] = ddlAy.SelectedValue;
                Session["bordroYil"] = ddlYil.SelectedValue;
                MaasBordroIslemleri bordroIslem = new MaasBordroIslemleri(Convert.ToInt16(ddlAy.SelectedValue), Convert.ToInt16(ddlYil.SelectedValue));
                bordroIslem.calisanBordroOlustur(ddlAy.SelectedValue, ddlYil.SelectedValue, Convert.ToInt16(Session["persID"]));
                lblBilgi.Text = ddlAy.SelectedValue + ". Ay'a ve " + ddlYil.SelectedValue+" yıla ait bordro oluşturuldu.";
                dataListDoldur();
            }
            else
            {
                lblBilgi.Text = "Oluşturmak istediğiniz tarihe ilişkin bordro bulunmaktadır.";
            }


        }
        else
        {
            lblBilgi.Text = "Ay ve/veya yil seçiniz";
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();

        switch (e.CommandName)
        {
            case "_listele":
                {
                    DateTime ilgiliTarih = Convert.ToDateTime(e.CommandArgument.ToString());

                    Session["bordroAy"] = ilgiliTarih.Month;
                    Session["bordroYil"] = ilgiliTarih.Year;

                    Response.Redirect("./UcretBordrosu.aspx");



                    break;
                }
            case "_guncelle":
                {

                   // lblBilgi.Text = "Bordro güncelleme işlemi bir kaç dakika sürebilir. Lütfen Bekleyiniz...";


                    DateTime ilgiliTarih = Convert.ToDateTime(e.CommandArgument.ToString());

                    tblOgrenciMaasTopBilgileri ogrMaasTopBil = turna.tblOgrenciMaasTopBilgileri.First(n => n.ilgiliAy == ilgiliTarih);

                    turna.tblOgrenciMaasTopBilgileri.DeleteObject(ogrMaasTopBil);

                    turna.SaveChanges();

                    //tblOgrenciMaas ogrMaas = turna.tblOgrenciMaas.First(n => n.aitOlduguAy == ilgiliTarih);

                    //turna.tblOgrenciMaas.Remove(ogrMaas);

                    //turna.SaveChanges();

                    turna.ogrMaasSil(ilgiliTarih);


                    MaasBordroIslemleri bordroIslem = new MaasBordroIslemleri(Convert.ToInt16(ilgiliTarih.Month.ToString()), Convert.ToInt16(ilgiliTarih.Year.ToString()));
                    bordroIslem.calisanBordroOlustur(ilgiliTarih.Month.ToString(), ilgiliTarih.Year.ToString() , Convert.ToInt16(Session["persID"]));
                    lblBilgi.Text = ilgiliTarih.Month.ToString() + ". Ay'a ve " + ilgiliTarih.Year.ToString() + " yıla ait bordro guncellendi.";


                    dataListDoldur();








                    break;
                }
            case "_sil":
                {
                  

                    DateTime ilgiliTarih = Convert.ToDateTime(e.CommandArgument.ToString());

                    tblOgrenciMaasTopBilgileri ogrMaasTopBil = turna.tblOgrenciMaasTopBilgileri.First(n => n.ilgiliAy == ilgiliTarih);

                    turna.tblOgrenciMaasTopBilgileri.DeleteObject(ogrMaasTopBil);

                    turna.SaveChanges();

                    //tblOgrenciMaas ogrMaas = turna.tblOgrenciMaas.First(n => n.aitOlduguAy == ilgiliTarih);

                    //turna.tblOgrenciMaas.Remove(ogrMaas);

                    //turna.SaveChanges();


                    turna.ogrMaasSil(ilgiliTarih);

                    lblBilgi.Text = ilgiliTarih.Month.ToString() + ". Ay'a ve " + ilgiliTarih.Year.ToString() + " yıla ait bordro silindi.";



                    dataListDoldur();

                    break;
                }


            case "_banka":
                {
                    DateTime ilgiliTarih = Convert.ToDateTime(e.CommandArgument.ToString());

                    Session["bordroAy"] = ilgiliTarih.Month;
                    Session["bordroYil"] = ilgiliTarih.Year;

                    Response.Redirect("./Banka.aspx");



                    break;
                }           

        }
    }
    protected void btnXML_Click(object sender, EventArgs e)
    {
        MaasBordroIslemleri xmlOlustur = new MaasBordroIslemleri(Convert.ToInt16(ddlAy.SelectedValue), Convert.ToInt16(ddlYil.SelectedValue));

        xmlOlustur.XMLOlustur(Convert.ToInt16(ddlAy.SelectedValue), Convert.ToInt16(ddlYil.SelectedValue));
    }
    protected void btnXML0_Click(object sender, EventArgs e)
    {
        Response.Redirect("ftp://skscalisma.sakarya.edu.tr/assets/XML/");
    }
    protected void btnSil_Click(object sender, EventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();

        int ilgiliAY = Convert.ToInt16(ddlAy.SelectedValue);
        int ilgiliYil = Convert.ToInt16(ddlYil.SelectedValue);

        turna.ogrMaasSil(Convert.ToDateTime("1." + ilgiliAY.ToString() + "." + ilgiliYil.ToString()));

        try
        {

      
        tblOgrenciMaasTopBilgileri maasSil2 = turna.tblOgrenciMaasTopBilgileri.First(n => n.ilgiliAy.Value.Month == ilgiliAY && n.ilgiliAy.Value.Year == ilgiliYil);

        turna.tblOgrenciMaasTopBilgileri.DeleteObject(maasSil2);

        turna.SaveChanges();
        }
        catch (Exception exp)
        {
            lblBilgi.Text = exp.Message;

        }
        dataListDoldur();
    }
}