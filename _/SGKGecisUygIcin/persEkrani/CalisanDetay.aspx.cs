using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class persEkrani_CalisanDetay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


          if (Session["Mail"] == null || (Session["yetkiID"].ToString() != "1" && Session["yetkiID"].ToString() != "2") )
            Response.Redirect("../Default.aspx");

        int birimID = Convert.ToInt16(Session["birimID"].ToString());

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
                    where calistigi.aktifMi == "1" && birimi.id == birimID
                    select new { ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, gss.ibanNo, GSS = gss.GSS2243, CalistigiBirimAdi = birimi.adi, sgk.SGKGiris, sgk.SGKCikis, ogrenimTuru = ogrnmTuru1.adi, ogr.ceptel, ogr.mail};


        GridView1.DataSource = ogrGetir2.ToList();
        GridView1.DataBind();





    }
}