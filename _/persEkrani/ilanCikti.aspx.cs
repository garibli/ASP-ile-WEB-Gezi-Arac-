using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class persEkrani_ilanCikti : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || (Session["yetkiID"].ToString() != "1" && Session["yetkiID"].ToString() != "2"))
            Response.Redirect("../Default.aspx");

     int ilanID =Convert.ToInt16(Session["ilanID"].ToString());
     var ilanBilgiGetir = (from bilgiler in turna.tblIlanlar where bilgiler.id == ilanID select new { bilgiler.programAdi, bilgiler.bolumID,bilgiler.birimID, bilgiler.isMetni, bilgiler.idari_Akademi,bilgiler.bitisSuresi,bilgiler.kontenjan,bilgiler.calismaGunleri }).FirstOrDefault();
   //  lblIsBasligi.Text = ilanBilgiGetir.isBasligi.ToString();
     if (ilanBilgiGetir.idari_Akademi == 1)
     {
         lblIsBasligi.Text = "Geçici Insan Kaynağı";
     }
     else 
     {
         lblIsBasligi.Text = "Gecici İnsan Kaynağı";
     }
     lblIsMetni.Text = ilanBilgiGetir.isMetni.ToString();
   
     int bolumID =Convert.ToInt16(ilanBilgiGetir.bolumID);
     var bolumAdiGetir = (from bolumAdi in turna.tblBolumler where bolumAdi.id == bolumID select new { bolumAdi.adi }).FirstOrDefault();
     lblBolumAdi.Text = bolumAdiGetir.adi.ToString();

     int donem = DateTime.Now.Year;
     lblEğitimÖğretimDönemi.Text = donem.ToString() + " / " + (donem + 1).ToString();
  
     int birimID = Convert.ToInt16(ilanBilgiGetir.birimID);
     var birimAdiGetir = (from birimAdi in turna.tblBirimler where birimAdi.id==birimID select new{birimAdi.adi}).FirstOrDefault();
     lblBirimAdiGetir.Text = birimAdiGetir.adi.ToString();

     lblSonBasvuruTarihi.Text = ilanBilgiGetir.bitisSuresi.ToString();
     lblBasvuruYeri.Text = "www.skscalisma.sakarya.edu.tr";
     if (ilanBilgiGetir.programAdi.ToString().Trim() == "Doktora") 
     {
         lblDoktora.Text = ilanBilgiGetir.kontenjan.ToString();
     }
     if (ilanBilgiGetir.programAdi.ToString().Trim() == "YuksekLisans")
     {
         lblYuksekLisans.Text = ilanBilgiGetir.kontenjan.ToString();
     }
     if (ilanBilgiGetir.programAdi.ToString().Trim() == "Lisans")
     {
         lblLisans.Text = ilanBilgiGetir.kontenjan.ToString();
     }
     if (ilanBilgiGetir.programAdi.ToString().Trim() == "ÖnLisans")
     {
         lblOnlisans.Text = ilanBilgiGetir.kontenjan.ToString();
     }
     if (ilanBilgiGetir.programAdi.ToString().Trim() == "FarkEtmez")
     {
         lblFarkEtmez.Text = ilanBilgiGetir.kontenjan.ToString();
     }

     string x = ilanBilgiGetir.calismaGunleri.ToString();

     char[] calismaGunleri = x.ToCharArray();
        char[] calismaGunleriSonHali=new char[10];
        for (int i = 0; i < 10; i++) 
        {
            if (calismaGunleri[i] == '0') { calismaGunleriSonHali[i] = ' '; }
            else { calismaGunleriSonHali[i] = 'X'; }
        }
        lblPazartesiOO.Text = calismaGunleriSonHali[0].ToString();
        lblSaliOO.Text = calismaGunleriSonHali[1].ToString();
        lblCarsambaOO.Text = calismaGunleriSonHali[2].ToString();
        lblPersembeOO.Text = calismaGunleriSonHali[3].ToString();
        lblCumaOO.Text = calismaGunleriSonHali[4].ToString();
        lblPazartesiOS.Text = calismaGunleriSonHali[5].ToString();
        lblSaliOS.Text = calismaGunleriSonHali[6].ToString();
        lblCarsambaOS.Text = calismaGunleriSonHali[7].ToString();
        lblPersembeOS.Text = calismaGunleriSonHali[8].ToString();
        lblCumaOS.Text = calismaGunleriSonHali[9].ToString();

        var paraGetir = (from getir in turna.tblOdenekler where getir.id == 1 select new { getir.onlisansBirimFiyati, getir.lisanBirimFiyati, getir.yuksekLisansBirimFiyati, getir.doktoraBirimFiyati }).FirstOrDefault();
        lblOnLisansPara.Text = paraGetir.onlisansBirimFiyati.ToString().Substring(0, 3);
        lisansPara.Text = paraGetir.lisanBirimFiyati.ToString().Substring(0, 3);
        lblYukseklisansPara.Text = paraGetir.yuksekLisansBirimFiyati.ToString().Substring(0, 3);
        lblDoktoraPara.Text = paraGetir.doktoraBirimFiyati.ToString().Substring(0, 3);
        lblKontenjanSayisi.Text = ilanBilgiGetir.kontenjan.ToString();
    
    }
  

   
}