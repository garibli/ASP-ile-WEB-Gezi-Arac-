using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_SozlesmeGetir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["sozlesmeOgrNo"] == null)
	{
            Response.Redirect("Default.aspx");
	}

        string ogrNo = Session["sozlesmeOgrNo"].ToString();

        TurnaEntities turna = new TurnaEntities();

        var getir = from ogr in turna.tblOgrenci
                    join okul in turna.tblBirimler
                    on ogr.okulu equals okul.id
                    join bolum in turna.tblBolumler
                    on ogr.bolumu equals bolum.id
                    where ogr.ogrNo == ogrNo
                    select new { ogr.ad,ogr.soyad,okulAdi = okul.adi,bolumAdi = bolum.adi,ogr.ceptel,ogr.tc,ogr.Sinifi,ogr.mail };
        foreach (var item in getir)
        {
            txtTC.Text = item.tc.ToString();
            txtAdSoyad.Text = item.ad.TrimEnd(' ') + " " + item.soyad.TrimEnd(' ');
            txtOkulu.Text = item.okulAdi.ToString();
            txtBolum.Text = item.bolumAdi.ToString();
            txtMail.Text = item.mail.ToString();
            txtCep.Text = "0"+item.ceptel.ToString();
            txtSinifi.Text = item.Sinifi.ToString();
            txtOkulNo.Text = ogrNo;

        }

        var getir2 = from ogr in turna.tblOgrenci
                    join iban in turna.tblOgrHesapNoGSS
                    on ogr.ogrNo equals iban.ogrNo
                    where ogr.ogrNo == ogrNo
                    select new { iban.ibanNo,iban.GSS2243 };

        foreach (var item in getir2)
        {
            txtIBAN.Text = item.ibanNo.ToString();
            if (item.GSS2243 == "22")
            {
                cbxGSS22.Checked = true;
            }
            else if (item.GSS2243 == "43")
            {
                cbxGSS43.Checked = true;
            }
           
        }



        var getir3 = from ogr in turna.tblOgrenci
                     join calisacagi in turna.tblCalismaYerleri
                     on ogr.ogrNo equals calisacagi.ogrNo
                    join okul in turna.tblBirimler
                    on calisacagi.calisacagiCalistigiYer equals okul.id
                    where ogr.ogrNo == ogrNo
                    select new { okul.adi };

        foreach (var item in getir3)
        {
            txtCalisacagi.Text = item.adi.ToString();
        }
       

    }
}