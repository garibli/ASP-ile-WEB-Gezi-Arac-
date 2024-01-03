using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;

public partial class komisyon_iseAlinanOgrenciler : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        int birimId = Convert.ToInt16(Session["birimId"]);
        int bolumID = Convert.ToInt16(Session["bolumId"]);
        var sgkKontrol = from sgkAktifmi in turna.tblCalismaYerleri
                         join ogrenci in turna.tblOgrenci on sgkAktifmi.ogrNo equals ogrenci.ogrNo
                         join birim in turna.tblBirimler on ogrenci.okulu equals birim.id
                         join bolum in turna.tblBolumler on ogrenci.bolumu equals bolum.id
                         join CalismaBirim in turna.tblBirimler on sgkAktifmi.calisacagiCalistigiYer equals CalismaBirim.id
                         join calismSekli in turna.tblCalismaSekli on sgkAktifmi.calismaSekli equals calismSekli.id
                         where sgkAktifmi.calisacagiCalistigiYer == birimId && sgkAktifmi.calisacagiCalistigiAltBirimi == bolumID
                         select new { ad = ogrenci.ad, soyad = ogrenci.soyad, birim = birim.adi, bolum = bolum.adi, sgkKontrol = sgkAktifmi.aktifMi, calisacagiBirim = CalismaBirim.adi, calismaSekli =calismSekli.adi};
        ddlIseAlinanOgrenciler.DataSource = sgkKontrol.ToList();
        ddlIseAlinanOgrenciler.DataBind();       
    }
   
}