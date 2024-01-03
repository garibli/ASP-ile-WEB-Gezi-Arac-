using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_SGKGiris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
        }
        

        VeriIslemleri veri = new VeriIslemleri();
        if(!IsPostBack)
            veri.ddlVeriCekBirimler(ddlBirimler);

        TurnaEntities turna = new TurnaEntities();

        var ogrGetir = (from ogr in turna.tblOgrenci
                        join calismaYer in turna.tblCalismaYerleri
                        on ogr.ogrNo equals calismaYer.ogrNo
                        join birimler in turna.tblBirimler
                        on calismaYer.calisacagiCalistigiYer equals birimler.id
                        where calismaYer.aktifMi == "0"
                        select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, CalismaBasvuruID = calismaYer.id }).Distinct();



        GridView1.DataSource = ogrGetir.ToList();
        GridView1.DataBind();

    }
    protected void ddlBirimler_SelectedIndexChanged(object sender, EventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();
        int birim = Convert.ToInt16(ddlBirimler.SelectedValue);
        var ogrGetir = (from ogr in turna.tblOgrenci
                       join calismaYer in turna.tblCalismaYerleri
                       on ogr.ogrNo equals calismaYer.ogrNo
                       join birimler in turna.tblBirimler
                       on calismaYer.calisacagiCalistigiYer equals birimler.id
                       where calismaYer.calisacagiCalistigiYer == birim && calismaYer.aktifMi == "0"
                        select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, CalismaBasvuruID = calismaYer.id }).Distinct();



        GridView1.DataSource = ogrGetir.ToList();
        GridView1.DataBind();

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

       
       string ogrNo = GridView1.SelectedRow.Cells[3].Text;
       int calismaYerID = Convert.ToInt16(GridView1.SelectedRow.Cells[9].Text);
        int ogrID = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);
       TurnaEntities turna = new TurnaEntities();

       DateTime tarih = new DateTime();
       if (Calendar1.SelectedDate.ToString() == "1.1.0001 00:00:00")
           tarih = DateTime.Today;
       else
           tarih = Calendar1.SelectedDate;

       tarih.ToString("MM-dd-yyyy");



       var resmiTatilQuery = from resTa in turna.tblResmiTatilGunleri
                             where resTa.resmiTatil.Value.Month == tarih.Month && resTa.resmiTatil.Value.Day == tarih.Day && resTa.resmiTatil.Value.Year == tarih.Year
                             select new { resTa.resmiTatil };


       bool resmiTatil = false;
       foreach (var item in resmiTatilQuery)
       {
           resmiTatil = true;
       }



       if (tarih.DayOfWeek.ToString() != "Saturday" && tarih.DayOfWeek.ToString() != "Sunday" && (tarih.DayOfWeek.ToString() == "Monday" || tarih.ToShortDateString() != DateTime.Now.ToShortDateString()) && (!resmiTatil))
       {
           int kontrol = turna.sgkGirisCikisEkle(ogrID, ogrNo, tarih, null, calismaYerID);//hem giriş yapılıyor hem aktif ediliyor.
           if ( kontrol == 2)
           {
               lblBilgi.Text = ogrNo + " öğrenci numarasına sahip kişinin işe girişi başarılı bir şekilde gerçekleştirildi.";
           }
           else
               lblBilgi.Text = "İşlem BAŞARISIZ. Lütfen tekrar deneyiniz.";
       }
       else
           lblBilgi.Text = "Girdiğiniz tarih için işe alım yapılamamakta lütfen tarih bilgisini kontrol edip tekrar deneyiniz.";
     
      


       int birim = Convert.ToInt16(ddlBirimler.SelectedValue);

       
      

       var ogrGetir = (from ogr in turna.tblOgrenci
                           join calismaYer in turna.tblCalismaYerleri
                           on ogr.ogrNo equals calismaYer.ogrNo
                           join birimler in turna.tblBirimler
                           on calismaYer.calisacagiCalistigiYer equals birimler.id
                           where calismaYer.aktifMi == "0"
                           select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, CalismaBasvuruID = calismaYer.id }).Distinct();
       
       if (birim != -1)
       {
                ogrGetir = (from ogr in turna.tblOgrenci
                           join calismaYer in turna.tblCalismaYerleri
                           on ogr.ogrNo equals calismaYer.ogrNo
                           join birimler in turna.tblBirimler
                           on calismaYer.calisacagiCalistigiYer equals birimler.id
                           where calismaYer.aktifMi == "0" && birimler.id == birim
                           select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, CalismaBasvuruID = calismaYer.id }).Distinct();
   
       }


       GridView1.DataSource = ogrGetir.ToList();
       GridView1.DataBind();
        }
        catch (Exception)
        {


        }
    }
}