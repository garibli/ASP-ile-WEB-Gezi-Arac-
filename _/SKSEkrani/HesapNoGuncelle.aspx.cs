using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_HesapNoGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.


        VeriIslemleri veri = new VeriIslemleri();

        if (!IsPostBack)
        {
            veri.ddlVeriCekFakYukOkul(ddlBirim, "0");

            ogrListele();


        }


    }

    public void ogrListele()
    {
        TurnaEntities turna = new TurnaEntities();





        var ogrGetir = from ogr in turna.tblOgrenci
                       join birimi in turna.tblBirimler
                       on ogr.okulu equals birimi.id
                       join IBANNO in turna.tblOgrHesapNoGSS
                       on ogr.ogrNo equals IBANNO.ogrNo
                       orderby birimi.adi, ogr.ad ascending
                       select new { ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, OkulAdi = birimi.adi, ogr.ceptel, ogr.mail, IBANNO.ibanNo };


        if (ddlBirim.SelectedValue != "-1")
        {

            int birimID = Convert.ToInt16(ddlBirim.SelectedValue);

            ogrGetir = from ogr in turna.tblOgrenci
                       join birimi in turna.tblBirimler
                       on ogr.okulu equals birimi.id
                       where ogr.okulu == birimID
                       join IBANNO in turna.tblOgrHesapNoGSS
                        on ogr.ogrNo equals IBANNO.ogrNo
                       orderby birimi.adi, ogr.ad ascending
                       select new { ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, OkulAdi = birimi.adi, ogr.ceptel, ogr.mail, IBANNO.ibanNo };

        }





        GridView1.DataSource = ogrGetir.ToList();
        GridView1.DataBind();




    }


    protected void ddlBirim_SelectedIndexChanged(object sender, EventArgs e)
    {
        ogrListele();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtOgrNo.Text = GridView1.SelectedRow.Cells[2].Text;
        txtAdSoyad.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[3].Text.Trim(' ')) + " " + HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[4].Text.Trim(' '));
        TurnaEntities turna = new TurnaEntities();

        var hesapNoQuery = from hesapNo in turna.tblOgrHesapNoGSS
                           where hesapNo.ogrNo == txtOgrNo.Text
                           select new { hesapNo.ibanNo };

        foreach (var item in hesapNoQuery)
        {
            txtHesapNo.Text = item.ibanNo.Trim(' ');
        }


    }
    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        if (txtOgrNo.Text != "")
        {
            TurnaEntities turna = new TurnaEntities();

            tblOgrHesapNoGSS hesapNoGuncelle = turna.tblOgrHesapNoGSS.First(n => n.ogrNo == txtOgrNo.Text);

            hesapNoGuncelle.ibanNo = txtHesapNo.Text;

            turna.SaveChanges();

            ogrListele();

            lblBilgi.Text = "";
            lblBilgi.Text = txtOgrNo.Text.Trim(' ') + " " + txtAdSoyad.Text.Trim(' ') + " Başarılı bir şekilde gerçekleşti.";

        }
        else
        {
            lblBilgi.Text = "Aşağıdaki listeden işlem yapılcak öğrenciyi seçiniz.";
        }
    }
}