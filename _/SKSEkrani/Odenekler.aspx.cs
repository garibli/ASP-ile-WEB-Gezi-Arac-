using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_Odenekler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.


        if (!IsPostBack)
        {
            txtDoldur();
        }


    }

    public void txtDoldur()
    {
        TurnaEntities turna = new TurnaEntities();

        var getir = turna.tblOdenekler;


        foreach (var item in getir)
        {
            txtAsgariBrut.Text = item.asgariBrutUcret.ToString();
            txtAsgariNet.Text = item.asgariNetUcret.ToString();
            txtDamgaVergisi.Text = item.damgaVergisi.ToString();
            txtDoktoraBirimFiyati.Text = item.doktoraBirimFiyati.ToString();
            txtGelirVergisi.Text = item.gelirVergisi.ToString();
            txtGSS43Orani.Text = item.GSS43Orani.ToString();
            txtGunlukCalismaSuresi.Text = item.azamiGunlukCalismaSuresi.ToString();
            txtLisansBirimFiyati.Text = item.lisanBirimFiyati.ToString();
            txtOnlisansBirimFiyati.Text = item.onlisansBirimFiyati.ToString();
            txtYuksekLisansFiyati.Text = item.yuksekLisansBirimFiyati.ToString();
            txtAsgariGunlukUcret.Text = item.asgariGunlukUcret.ToString();

        }

    }
    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        try
        {

      
        TurnaEntities turna = new TurnaEntities();

        var getir = turna.tblOdenekler;


        bool kayitVar = false;
        foreach (var item in getir)
        {
            kayitVar = true;
        }

        if (kayitVar)
        {
            tblOdenekler odenekGuncelle = turna.tblOdenekler.First(u => u.id == 1);
            
            odenekGuncelle.asgariBrutUcret = Convert.ToDecimal(txtAsgariBrut.Text);
            odenekGuncelle.asgariNetUcret = Convert.ToDecimal(txtAsgariNet.Text);
            odenekGuncelle.azamiGunlukCalismaSuresi = Convert.ToDecimal(txtGunlukCalismaSuresi.Text);
            odenekGuncelle.damgaVergisi = Convert.ToDecimal(txtDamgaVergisi.Text);
            odenekGuncelle.doktoraBirimFiyati = Convert.ToDecimal(txtDoktoraBirimFiyati.Text);
            odenekGuncelle.gelirVergisi = Convert.ToDecimal(txtGelirVergisi.Text);
            odenekGuncelle.GSS43Orani = Convert.ToDecimal(txtGSS43Orani.Text);
            odenekGuncelle.lisanBirimFiyati = Convert.ToDecimal(txtLisansBirimFiyati.Text);
            odenekGuncelle.onlisansBirimFiyati = Convert.ToDecimal(txtOnlisansBirimFiyati.Text);
            odenekGuncelle.yuksekLisansBirimFiyati = Convert.ToDecimal(txtYuksekLisansFiyati.Text);
            odenekGuncelle.asgariGunlukUcret = Convert.ToDecimal(txtAsgariGunlukUcret.Text);
            turna.SaveChanges();

            txtDoldur();
            
        }
        else
        {
            tblOdenekler odenekEkle = new tblOdenekler { 
             
            asgariBrutUcret = Convert.ToDecimal(txtAsgariBrut.Text),
            asgariNetUcret = Convert.ToDecimal(txtAsgariNet.Text),
            azamiGunlukCalismaSuresi = Convert.ToDecimal(txtGunlukCalismaSuresi.Text),
            damgaVergisi = Convert.ToDecimal(txtDamgaVergisi.Text),
            doktoraBirimFiyati = Convert.ToDecimal(txtDoktoraBirimFiyati.Text),
            gelirVergisi = Convert.ToDecimal(txtGelirVergisi.Text),
            GSS43Orani = Convert.ToDecimal(txtGSS43Orani.Text),
            lisanBirimFiyati = Convert.ToDecimal(txtLisansBirimFiyati.Text),
            onlisansBirimFiyati = Convert.ToDecimal(txtOnlisansBirimFiyati.Text),
            yuksekLisansBirimFiyati = Convert.ToDecimal(txtYuksekLisansFiyati.Text),
            
            
            };

            turna.tblOdenekler.AddObject(odenekEkle);
            turna.SaveChanges();

            txtDoldur();
        }

        }
        catch (Exception)
        {

            lblBilgi.Text = "Verileri kaydedemekdik.Girdiğiniz verileri kısıtlara uygun değil lütfen verilerinizi tekrar kontrol edip ondalıklı sayıların arasına , koyduğunuzdan emin olunuz.";
            txtDoldur();
        }


    }
}