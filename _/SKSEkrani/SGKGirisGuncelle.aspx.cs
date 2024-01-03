using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_SGKGirisGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
        }


        VeriIslemleri veri = new VeriIslemleri();
        if (!IsPostBack)
        {
            veri.ddlVeriCekBirimler(ddlBirimler);

            Calendar1.SelectedDate = DateTime.Now;
            lblTarih.Text = Calendar1.SelectedDate.ToShortDateString();
        }
        if (!IsPostBack)
        {


            TurnaEntities turna = new TurnaEntities();

            var ogrGetir = (from ogr in turna.tblOgrenci
                            join calismaYer in turna.tblCalismaYerleri
                            on ogr.ogrNo equals calismaYer.ogrNo
                            join birimler in turna.tblBirimler
                            on calismaYer.calisacagiCalistigiYer equals birimler.id
                            join SGK in turna.SGKGirisCikis
                            on ogr.ogrNo equals SGK.ogrNo
                            where calismaYer.aktifMi == "1"
                            select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, SGK.SGKGiris, CalismaBasvuruID = calismaYer.id, SGKID = SGK.id }).Distinct().OrderBy(x => x.ad);

            GridView1.DataSource = ogrGetir.ToList();
            GridView1.DataBind();

            foreach (var item in ogrGetir)
            {
                ddlCalisan.Items.Add(new ListItem(item.ad + " " + item.soyad + " " + item.ogrNo, item.ogrNo + "/" + item.id + "/" + item.SGKID + "/" + item.CalismaBasvuruID));
            }


        }
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
                        join SGK in turna.SGKGirisCikis
                        on ogr.ogrNo equals SGK.ogrNo
                        where calismaYer.calisacagiCalistigiYer == birim && calismaYer.aktifMi == "1"
                        select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, SGK.SGKGiris, CalismaBasvuruID = calismaYer.id, SGKID = SGK.id }).Distinct();



        GridView1.DataSource = ogrGetir.ToList();
        GridView1.DataBind();

        foreach (var item in ogrGetir)
        {
            ddlCalisan.Items.Add(new ListItem(item.ad + " " + item.soyad + " " + item.ogrNo, item.ogrNo + "/" + item.id + "/" + item.SGKID + "/" + item.CalismaBasvuruID));
        }

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int SGKID = Convert.ToInt16(GridView1.SelectedRow.Cells[11].Text);
            string ogrNo = GridView1.SelectedRow.Cells[3].Text;
            int calismaYerID = Convert.ToInt16(GridView1.SelectedRow.Cells[10].Text);
            int ogrID = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);
            string adSoyad = GridView1.SelectedRow.Cells[4].Text + " " + GridView1.SelectedRow.Cells[5].Text;

            lblAdSoyad.Text = adSoyad;
            lblOgrID.Text = ogrID.ToString();
            lblOgrNo.Text = ogrNo.ToString();
            lblSGKID.Text = SGKID.ToString();
            lblCalYerID.Text = calismaYerID.ToString();
        }
        catch (Exception ex)
        {

            lblBilgi.Text = "Bir hata oluştu. Hata Mesajı : " + ex.Message;

        }
        

    }

    protected void btnOlustur_Click(object sender, EventArgs e)
    {
        try
        {


            int SGKID = Convert.ToInt16(lblSGKID.Text); //GridView1.SelectedRow.Cells[11].Text);
            string ogrNo = lblOgrNo.Text;//GridView1.SelectedRow.Cells[3].Text;
            int calismaYerID = Convert.ToInt16(lblCalYerID.Text);//GridView1.SelectedRow.Cells[10].Text);
            int ogrID = Convert.ToInt16(lblOgrID.Text);//GridView1.SelectedRow.Cells[1].Text);
            TurnaEntities turna = new TurnaEntities();

            DateTime tarih = new DateTime();
            //if (Calendar1.SelectedDate.ToString() == "1.1.0001 00:00:00")
            //    tarih = DateTime.Today;
            //else
            //    tarih = Calendar1.SelectedDate;


            tarih = Convert.ToDateTime(lblTarih.Text);

            tarih.ToString("MM-dd-yyyy");



            var resmiTatilQuery = from resTa in turna.tblResmiTatilGunleri
                                  where resTa.resmiTatil.Value.Month == tarih.Month && resTa.resmiTatil.Value.Day == tarih.Day && resTa.resmiTatil.Value.Year == tarih.Year
                                  select new { resTa.resmiTatil };


            bool resmiTatil = false;
            foreach (var item in resmiTatilQuery)
            {
                resmiTatil = true;
            }



            if (tarih.DayOfWeek.ToString() != "Saturday" && tarih.DayOfWeek.ToString() != "Sunday" && (!resmiTatil))
            {
                SGKGirisCikis sgkGirisGuncelle = turna.SGKGirisCikis.First(n => n.id == SGKID);

                sgkGirisGuncelle.SGKGiris = tarih;

                turna.SaveChanges();




                lblBilgi.Text = ogrNo + " öğrenci numarasına sahip kişinin işe girişi başarılı bir şekilde güncelleştirildi.";

            }
            else
                lblBilgi.Text = "Girdiğiniz tarih için işe alım yapılamamakta lütfen tarih bilgisini kontrol edip tekrar deneyiniz.";




            int birim = Convert.ToInt16(ddlBirimler.SelectedValue);




            var ogrGetir = (from ogr in turna.tblOgrenci
                            join calismaYer in turna.tblCalismaYerleri
                            on ogr.ogrNo equals calismaYer.ogrNo
                            join birimler in turna.tblBirimler
                            on calismaYer.calisacagiCalistigiYer equals birimler.id
                            join SGK in turna.SGKGirisCikis
                            on ogr.ogrNo equals SGK.ogrNo
                            where calismaYer.aktifMi == "1"
                            select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, SGK.SGKGiris, CalismaBasvuruID = calismaYer.id, SGKID = SGK.id }).Distinct().OrderBy(x => x.ad);

            if (birim != -1)
            {
                ogrGetir = (from ogr in turna.tblOgrenci
                            join calismaYer in turna.tblCalismaYerleri
                            on ogr.ogrNo equals calismaYer.ogrNo
                            join birimler in turna.tblBirimler
                            on calismaYer.calisacagiCalistigiYer equals birimler.id
                            join SGK in turna.SGKGirisCikis
                            on ogr.ogrNo equals SGK.ogrNo
                            where calismaYer.aktifMi == "1" && birimler.id == birim
                            select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, SGK.SGKGiris, CalismaBasvuruID = calismaYer.id, SGKID = SGK.id }).Distinct().OrderBy(x => x.ad);

            }


            GridView1.DataSource = ogrGetir.ToList();
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            lblBilgi.Text = "Bir hata oluştu. Hata Mesajı : " + ex.Message;

        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        lblTarih.Text = Calendar1.SelectedDate.ToShortDateString();
    }
    protected void ddlCalisan_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblAdSoyad.Text = ddlCalisan.SelectedItem.ToString();
        string[] bilgi = ddlCalisan.SelectedValue.Split('/');

        lblOgrID.Text = bilgi[1];
        lblOgrNo.Text = bilgi[0];
        lblSGKID.Text = bilgi[2];
        lblCalYerID.Text = bilgi[3];

    }
}