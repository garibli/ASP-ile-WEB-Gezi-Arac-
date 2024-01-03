using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_OgrListele : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

        VeriIslemleri veri = new VeriIslemleri();

        if (!IsPostBack)
        {

            veri.ddlVeriCekBirimler(ddlBirimler);

        }
        ogrListele();
        
    }

    public void ogrListele() 
    {
        TurnaEntities turna = new TurnaEntities();


        var ogrGetir2 = from ogr in turna.tblOgrenci
                       join calistigi in turna.tblCalismaYerleri
                       on ogr.ogrNo equals calistigi.ogrNo
                       join birimi in turna.tblBirimler
                       on calistigi.calisacagiCalistigiYer equals birimi.id
                       join okuduguBirimi in turna.tblBirimler
                       on ogr.okulu equals okuduguBirimi.id
                       join okuduguBolumu in turna.tblBolumler
                       on ogr.bolumu equals okuduguBolumu.id
                       join ogrnmTuru1 in turna.tblOgrenimTuru
                       on ogr.ogrenimTuru equals ogrnmTuru1.ogrenimNo
                       join gss in turna.tblOgrHesapNoGSS
                       on ogr.ogrNo equals gss.ogrNo
                       join sgk in turna.SGKGirisCikis
                       on ogr.ogrNo equals sgk.ogrNo
                       orderby birimi.adi, ogr.ad ascending
                       where calistigi.aktifMi == "1"
                       
                       select new { ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad,gss.ibanNo, GSS = gss.GSS2243, CalistigiBirimAdi = birimi.adi,sgk.SGKGiris,sgk.SGKCikis, ogrenimTuru = ogrnmTuru1.adi, ogr.ceptel, ogr.mail, ogr.aktifMi,okuduguOkul = okuduguBirimi.adi,okuduguBolum = okuduguBolumu.adi,ogr.sifre,ogr.Sinifi,ogr.notOrtalamasi };

        if (ddlBirimler.SelectedValue != "" && ddlBirimler.SelectedValue != "-1")
        {

            int birimID = Convert.ToInt16(ddlBirimler.SelectedValue);

            ogrGetir2 = from ogr in turna.tblOgrenci
                        join calistigi in turna.tblCalismaYerleri
                        on ogr.ogrNo equals calistigi.ogrNo
                        join birimi in turna.tblBirimler
                        on calistigi.calisacagiCalistigiYer equals birimi.id
                        join okuduguBirimi in turna.tblBirimler
                        on ogr.okulu equals okuduguBirimi.id
                        join okuduguBolumu in turna.tblBolumler
                        on ogr.bolumu equals okuduguBolumu.id
                        join ogrnmTuru1 in turna.tblOgrenimTuru
                        on ogr.ogrenimTuru equals ogrnmTuru1.ogrenimNo
                        join gss in turna.tblOgrHesapNoGSS
                        on ogr.ogrNo equals gss.ogrNo
                        join sgk in turna.SGKGirisCikis
                        on ogr.ogrNo equals sgk.ogrNo
                        orderby birimi.adi, ogr.ad ascending
                        where calistigi.aktifMi == "1" && birimi.id == birimID
                        select new { ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, gss.ibanNo, GSS = gss.GSS2243, CalistigiBirimAdi = birimi.adi, sgk.SGKGiris, sgk.SGKCikis, ogrenimTuru = ogrnmTuru1.adi, ogr.ceptel, ogr.mail, ogr.aktifMi, okuduguOkul = okuduguBirimi.adi, okuduguBolum = okuduguBolumu.adi, ogr.sifre, ogr.Sinifi, ogr.notOrtalamasi };

        }




        ddlAktifCalisanMi.Enabled = false;



        if (RBOkuduguOkul.Checked)
        {


            ddlAktifCalisanMi.Enabled = true;



              var  ogrGetir = from ogr in turna.tblOgrenci
                           join birimi in turna.tblBirimler
                           on ogr.okulu equals birimi.id
                           join ogrnmTuru1 in turna.tblOgrenimTuru
                           on ogr.ogrenimTuru equals ogrnmTuru1.ogrenimNo
                           join gss in turna.tblOgrHesapNoGSS
                           on ogr.ogrNo equals gss.ogrNo
                           orderby birimi.adi, ogr.ad ascending
                              select new { SGKGiris = "*", SGKCikis = "*", ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, gss.ibanNo, GSS = gss.GSS2243, CalistigiBirimAdi = "*", okuduguOkul = birimi.adi, ogrenimTuru = ogrnmTuru1.adi, ogr.ceptel, ogr.mail, ogr.aktifMi, ogr.sifre, ogr.Sinifi, ogr.notOrtalamasi ,okuduguBolum="*" };
                          
            



            if (ddlBirimler.SelectedValue != "-1" && ddlAktifCalisanMi.SelectedValue == "-1")
            {

                int birimID = Convert.ToInt16(ddlBirimler.SelectedValue);

                ogrGetir = from ogr in turna.tblOgrenci
                           join birimi in turna.tblBirimler
                           on ogr.okulu equals birimi.id
                           where ogr.okulu == birimID
                           join ogrnmTuru1 in turna.tblOgrenimTuru
                           on ogr.ogrenimTuru equals ogrnmTuru1.ogrenimNo
                           join gss in turna.tblOgrHesapNoGSS
                           on ogr.ogrNo equals gss.ogrNo
                           orderby birimi.adi, ogr.ad ascending
                           select new { SGKGiris = "*", SGKCikis = "*", ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, gss.ibanNo, GSS = gss.GSS2243, CalistigiBirimAdi = "*", okuduguOkul = birimi.adi, ogrenimTuru = ogrnmTuru1.adi, ogr.ceptel, ogr.mail, ogr.aktifMi, ogr.sifre, ogr.Sinifi, ogr.notOrtalamasi, okuduguBolum = "*" };

            }
            else if (ddlBirimler.SelectedValue == "-1" && ddlAktifCalisanMi.SelectedValue != "-1")
            {
                // int birimID = Convert.ToInt16(ddlBirimler.SelectedValue);
                string akifmi = ddlAktifCalisanMi.SelectedValue;

                if (akifmi == "1")
                {

                    ogrGetir = from ogr in turna.tblOgrenci
                               join birimi in turna.tblBirimler
                               on ogr.okulu equals birimi.id
                               join ogrnmTuru1 in turna.tblOgrenimTuru
                               on ogr.ogrenimTuru equals ogrnmTuru1.ogrenimNo
                               join gss in turna.tblOgrHesapNoGSS
                               on ogr.ogrNo equals gss.ogrNo
                               where ogr.aktifMi == akifmi
                               orderby birimi.adi, ogr.ad ascending
                               select new { SGKGiris = "*", SGKCikis = "*", ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, gss.ibanNo, GSS = gss.GSS2243, CalistigiBirimAdi = "*", okuduguOkul = birimi.adi, ogrenimTuru = ogrnmTuru1.adi, ogr.ceptel, ogr.mail, ogr.aktifMi, ogr.sifre, ogr.Sinifi, ogr.notOrtalamasi, okuduguBolum = "*" };

                }
                else if (akifmi == "2")
                {
                    ogrGetir = from ogr in turna.tblOgrenci
                               join birimi in turna.tblBirimler
                               on ogr.okulu equals birimi.id
                               join ogrnmTuru1 in turna.tblOgrenimTuru
                               on ogr.ogrenimTuru equals ogrnmTuru1.ogrenimNo
                               join gss in turna.tblOgrHesapNoGSS
                               on ogr.ogrNo equals gss.ogrNo
                               where ogr.aktifMi != "1"
                               orderby birimi.adi, ogr.ad ascending
                               select new { SGKGiris = "*", SGKCikis = "*", ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, gss.ibanNo, GSS = gss.GSS2243, CalistigiBirimAdi = "*", okuduguOkul = birimi.adi, ogrenimTuru = ogrnmTuru1.adi, ogr.ceptel, ogr.mail, ogr.aktifMi, ogr.sifre, ogr.Sinifi, ogr.notOrtalamasi, okuduguBolum = "*" };

                }

            }
            else if (ddlBirimler.SelectedValue != "-1" && ddlAktifCalisanMi.SelectedValue != "-1")
            {
                int birimID = Convert.ToInt16(ddlBirimler.SelectedValue);
                string akifmi = ddlAktifCalisanMi.SelectedValue;

                if (akifmi == "1")
                {

                    ogrGetir = from ogr in turna.tblOgrenci
                               join birimi in turna.tblBirimler
                               on ogr.okulu equals birimi.id
                               join ogrnmTuru1 in turna.tblOgrenimTuru
                               on ogr.ogrenimTuru equals ogrnmTuru1.ogrenimNo
                               join gss in turna.tblOgrHesapNoGSS
                               on ogr.ogrNo equals gss.ogrNo
                               where ogr.okulu == birimID && ogr.aktifMi == akifmi
                               orderby birimi.adi, ogr.ad ascending
                               select new { SGKGiris = "*", SGKCikis = "*", ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, gss.ibanNo, GSS = gss.GSS2243, CalistigiBirimAdi = "*", okuduguOkul = birimi.adi, ogrenimTuru = ogrnmTuru1.adi, ogr.ceptel, ogr.mail, ogr.aktifMi, ogr.sifre, ogr.Sinifi, ogr.notOrtalamasi, okuduguBolum = "*" };

                }
                else if (akifmi == "2")
                {
                    ogrGetir = from ogr in turna.tblOgrenci
                               join birimi in turna.tblBirimler
                               on ogr.okulu equals birimi.id
                               join ogrnmTuru1 in turna.tblOgrenimTuru
                               on ogr.ogrenimTuru equals ogrnmTuru1.ogrenimNo
                               join gss in turna.tblOgrHesapNoGSS
                               on ogr.ogrNo equals gss.ogrNo
                               where ogr.okulu == birimID && ogr.aktifMi != "1"
                               orderby birimi.adi, ogr.ad ascending
                               select new { SGKGiris = "*", SGKCikis = "*", ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, gss.ibanNo, GSS = gss.GSS2243, CalistigiBirimAdi = "*", okuduguOkul = birimi.adi, ogrenimTuru = ogrnmTuru1.adi, ogr.ceptel, ogr.mail, ogr.aktifMi, ogr.sifre, ogr.Sinifi, ogr.notOrtalamasi, okuduguBolum = "*" };

                }


            }

            

            DtListOgrenci.DataSource = ogrGetir.ToList();
            DtListOgrenci.DataBind();

        }
        else
        {

            DtListOgrenci.DataSource = ogrGetir2.ToList().Distinct();
            DtListOgrenci.DataBind();
        }


      




    }




    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlBirimler_SelectedIndexChanged(object sender, EventArgs e)
    {
        ogrListele();
    }
    protected void ddlAktifCalisanMi_SelectedIndexChanged(object sender, EventArgs e)
    {
        ogrListele();
    }
}