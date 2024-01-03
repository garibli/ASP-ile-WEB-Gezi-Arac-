using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SGKGecisUygIcin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int BirimId = Convert.ToInt16(Request.QueryString["id"]);

        TurnaEntities turna = new TurnaEntities();

        var sorgu = (from ogr in turna.tblOgrenci
                     join calismaYer in turna.tblCalismaYerleri on ogr.id equals calismaYer.ogrID
                     join gss in turna.tblOgrHesapNoGSS on ogr.ogrNo equals gss.ogrNo
                     where calismaYer.calisacagiCalistigiYer == BirimId
                     //&& calismaYer.aktifMi == "1"
                     select new { ogr.tc, ogr.ad, ogr.soyad,gss.GSS2243 }).Distinct();


        foreach (var item in sorgu)
        {
            ddl1.Items.Add(new ListItem(item.tc + "/" + item.ad + "/" + item.soyad + "/" + item.GSS2243));
        }


        var birimGetir = from bolum in turna.tblBirimler
                         select new { bolum.adi,bolum.id };

        foreach (var item in birimGetir)
        {
            ddl2.Items.Add(new ListItem(item.adi + "/" + item.id));
        }


        var tatilGunleri = from tatil in turna.tblResmiTatilGunleri
                           select new { tatil.resmiTatil };

        foreach (var item in tatilGunleri)
        {

            ddl3.Items.Add(new ListItem(item.resmiTatil.ToString()));

        }

        var ogrSGKGirisGetir = (from ogr in turna.tblOgrenci
                        join calismaYer in turna.tblCalismaYerleri
                        on ogr.ogrNo equals calismaYer.ogrNo
                        join birimler in turna.tblBirimler
                        on calismaYer.calisacagiCalistigiYer equals birimler.id
                        where calismaYer.aktifMi == "1" && birimler.id == BirimId
                        select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, CalismaBasvuruID = calismaYer.id }).Distinct();

        foreach (var item in ogrSGKGirisGetir.ToList())
        {
            ddlSGKGirisliler.Items.Add(new ListItem(item.ogrNo.ToString(), item.ogrNo.ToString()));
        }


    }
}