using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_IstenCikar : System.Web.UI.Page
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
        TurnaEntities turna = new TurnaEntities();

        var ogrGetir = (from ogr in turna.tblOgrenci
                        join calismaYer in turna.tblCalismaYerleri
                        on ogr.ogrNo equals calismaYer.ogrNo
                        join birimler in turna.tblBirimler
                        on calismaYer.calisacagiCalistigiYer equals birimler.id
                        where calismaYer.aktifMi == "1"
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
                       where calismaYer.calisacagiCalistigiYer == birim && calismaYer.aktifMi == "1"
                        select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, CalismaBasvuruID = calismaYer.id }).Distinct();



        GridView1.DataSource = ogrGetir.ToList();
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       // int SGKID = Convert.ToInt16(GridView1.SelectedRow.Cells[12].Text);
        string ogrNo = GridView1.SelectedRow.Cells[3].Text;
        int calismaYerID = Convert.ToInt16(GridView1.SelectedRow.Cells[9].Text);
        int ogrID = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);
        string adSoyad = GridView1.SelectedRow.Cells[4].Text + " " + GridView1.SelectedRow.Cells[5].Text;

        lblAdSoyad.Text = adSoyad;
        lblOgrID.Text = ogrID.ToString();
        lblOgrNo.Text = ogrNo.ToString();
       // lblSGKID.Text = SGKID.ToString();
        lblCalYerID.Text = calismaYerID.ToString();
        

    }
    protected void btnOlustur_Click(object sender, EventArgs e)
    {
        try
        {

    
        string ogrNo = lblOgrNo.Text;//GridView1.SelectedRow.Cells[3].Text;
        string adSoyad = GridView1.SelectedRow.Cells[4].Text + " " + GridView1.SelectedRow.Cells[5].Text;
        int calismaYerID = Convert.ToInt16(lblCalYerID.Text);//GridView1.SelectedRow.Cells[9].Text);
        int ogrID = Convert.ToInt16(lblOgrID.Text);//GridView1.SelectedRow.Cells[1].Text);
        TurnaEntities turna = new TurnaEntities();

        DateTime tarih = new DateTime();
        if (Calendar1.SelectedDate.ToString() == "1.1.0001 00:00:00")
            tarih = DateTime.Today;
        else
            tarih = Calendar1.SelectedDate;

        tarih.ToString("MM-dd-yyyy");


        var cikistanSonraYoklamaVarmı = from yoklama in turna.tblCalisanYoklama
                                        where yoklama.ogrNo == ogrNo && tarih < yoklama.tarih
                                        select new { yoklama.tarih };

        bool cikistanSonraYoklamaVar = false;

        foreach (var item in cikistanSonraYoklamaVarmı)
        {
            cikistanSonraYoklamaVar = true;

        }

        var resmiTatilQuery2 = from resTa in turna.tblResmiTatilGunleri
                               where resTa.resmiTatil.Value.Month == tarih.Month && resTa.resmiTatil.Value.Day == tarih.Day && resTa.resmiTatil.Value.Year == tarih.Year
                               select new { resTa.resmiTatil };


        bool resmiTatil = false;
        foreach (var item in resmiTatilQuery2)
        {
            resmiTatil = true;
        }



        if (tarih.DayOfWeek.ToString() != "Saturday" && tarih.DayOfWeek.ToString() != "Sunday" && (!resmiTatil))
        {




            if (!cikistanSonraYoklamaVar)
            {
                turna.sgkCikis(ogrNo, tarih, calismaYerID);//hem çıkış yapılıyor hem pasif.
                //ÇalışmaYErleriAKtiflik 2 yapılarak işten çıkıltığı belirleniyor.
                turna.ogrAktifPasit("0", ogrNo);//ogrenci pasif yapıldı yani tekrardan yeni bir işe alınabilir.

                lblBilgi.Text = adSoyad + " " + ogrNo + " öğrenci numarasına sahip kişinin SİSTEMDEN SGK çıkış işlemi başarılı bir şekilde gerçekleştirildi.";

                VeriIslemleri veri = new VeriIslemleri();



                veri.guncelleKontenjanArttir(calismaYerID, -1);


            }
            else
            {
                lblBilgi.Text = "Çıkarılmak istenen çalışanın sonraki tarihe ait puantaj girişi mevcuttur." +
                    "Sgk çıkış işleminden önce çıkarılmak istenen tarihten sonraki puantaj girişlerine çalışma saati 0 olarak ayarlanmalıdır.";
            }


        }
        else
            lblBilgi.Text = "Girdiğiniz tarih için SGK çıkışı yapılamamakta lütfen tarih bilgisini kontrol edip tekrar deneyiniz.";



        var ogrGetir = (from ogr in turna.tblOgrenci
                        join calismaYer in turna.tblCalismaYerleri
                        on ogr.ogrNo equals calismaYer.ogrNo
                        join birimler in turna.tblBirimler
                        on calismaYer.calisacagiCalistigiYer equals birimler.id
                        where calismaYer.aktifMi == "1"
                        select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, CalismaBasvuruID = calismaYer.id }).Distinct();

        if (ddlBirimler.SelectedValue != "-1")
        {
            int birimID = Convert.ToInt16(ddlBirimler.SelectedValue);

            ogrGetir = (from ogr in turna.tblOgrenci
                        join calismaYer in turna.tblCalismaYerleri
                        on ogr.ogrNo equals calismaYer.ogrNo
                        join birimler in turna.tblBirimler
                        on calismaYer.calisacagiCalistigiYer equals birimler.id
                        where calismaYer.aktifMi == "1" && birimler.id == birimID
                        select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, CalismaBasvuruID = calismaYer.id }).Distinct();

        }



        GridView1.DataSource = ogrGetir.ToList();
        GridView1.DataBind();
        }
        catch (Exception ex)
        {

            lblBilgi.Text = "Hata oluştu. Hata mesajı : " + ex.Message;
        }
    }
    
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        lblTarih.Text = Calendar1.SelectedDate.ToShortDateString();
    }
}