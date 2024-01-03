using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class komisyon_ogrIseAlim : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        int birimId = Convert.ToInt16(Session["birimId"]);
        int bolumID = Convert.ToInt16(Session["bolumId"]);

        var ogrBilgi = from ogrenciAnkCVP in turna.tblOgrenciAnketCevablari
                       join ogrenciBavuru in turna.tblOgrBasvuruBilgileri on ogrenciAnkCVP.ogrNo equals ogrenciBavuru.ogrNo
                       join ilanBilgi in turna.tblIlanlar on ogrenciBavuru.BasvuruID equals ilanBilgi.id
                       join ogrBilgis in turna.tblOgrenci on ogrenciBavuru.ogrNo equals ogrBilgis.ogrNo
                       join birims in turna.tblBirimler on ilanBilgi.birimID equals birims.id
                      orderby ogrenciBavuru.ToplamPuan descending
                       where birims.id == birimId && ilanBilgi.bolumID==bolumID //&& (ogrenciBavuru.MulakatSoruldumu == 0 || ogrenciBavuru.MulakatSoruldumu == 1)&& ogrenciBavuru.SKSGonder==0
                       select new { ad = ogrBilgis.ad, soyad = ogrBilgis.soyad, puan = ogrenciBavuru.ToplamPuan, programAdi = ilanBilgi.programAdi, birim = birims.adi };


       /*    var basvuruBilgi = from ilanBilgi in turna.tblIlanlar
                           join bsvrBilgi in turna.tblOgrBasvuruBilgileri on ilanBilgi.id equals bsvrBilgi.BasvuruID
                           join ogrBilgi in turna.tblOgrenci on bsvrBilgi.ogrNo equals ogrBilgi.ogrNo
                           join anketCvp in turna.tblOgrenciAnketCevablari on ogrBilgi.ogrNo equals anketCvp.ogrNo
                           join birimID in turna.tblBirimler on ogrBilgi.okulu equals birimID.id orderby bsvrBilgi.ToplamPuan
                           where (bsvrBilgi.MulakatSoruldumu == 0 || bsvrBilgi.MulakatSoruldumu == 1) && (ilanBilgi.birimID == birimId && ilanBilgi.bolumID == bolumID)
                           select new { ad = ogrBilgi.ad, soyad = ogrBilgi.soyad, puan =bsvrBilgi.ToplamPuan, programAdi = ilanBilgi.programAdi, birim = birimID.adi, id = ogrBilgi.mail };
        */
            ddlistOGrBasvuruBilgileri.DataSource =ogrBilgi.ToList();
            ddlistOGrBasvuruBilgileri.DataBind();

     
          
            ddlistOGrBasvuruBilgileri.Visible = true;
                   
        
        }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        int birimId = Convert.ToInt16(Session["birimId"]);
        int bolumID = Convert.ToInt16(Session["bolumId"]);
        var ilanSayisi = from ilanBul in turna.tblIlanlar where ilanBul.birimID == birimId && ilanBul.bolumID == bolumID select new {ilanBul.id};
        List<int> IlanGir = new List<int>();
        foreach (var item in ilanSayisi)
        {
            IlanGir.Add(Convert.ToInt16(item.id));
        }
        for (int i = 0; i < IlanGir.Count; i++) 
        {
            var altKontenjanBul = (from kontenjan in turna.tblBolumler where kontenjan.id == bolumID select new { kontenjan.altKontenjan }).FirstOrDefault();
            int kontenjanSiniri = Convert.ToInt16(altKontenjanBul.altKontenjan);
            int ilanID=Convert.ToInt16(IlanGir[i]);
            var asilListeCikar = (from kisiler in turna.tblOgrBasvuruBilgileri where kisiler.BasvuruID == ilanID orderby kisiler.ToplamPuan descending select new {kisiler.ogrNo }).Take(kontenjanSiniri);
            foreach (var item in asilListeCikar)
            {
                string ogrNo = item.ogrNo.ToString();
                tblOgrBasvuruBilgileri ogrBasvuruSKSGonder = turna.tblOgrBasvuruBilgileri.First(m => m.ogrNo == ogrNo);
                ogrBasvuruSKSGonder.SKSGonder = 1;

                var deleteOgrBul = from ogrDelete in turna.tblOgrBasvuruBilgileri where ogrDelete.ogrNo == ogrNo && ogrDelete.SKSGonder == 0 select new { ogrDelete.id };

                foreach (var bulID in deleteOgrBul)
                {
                    tblOgrBasvuruBilgileri ogrBasvuruSil = turna.tblOgrBasvuruBilgileri.First(m => m.id == bulID.id);
                    turna.tblOgrBasvuruBilgileri.DeleteObject(ogrBasvuruSil);
                }
                
                
                //  turna.HizliIseAl(ogrBilgiGetir.id, ogrNo, ogrBilgiGetir.birimID, ogrBilgiGetir.bolumID, ogrBilgiGetir.idari_Akademi, Convert.ToInt16(Session["persID"]));
              //  turna.ogrAktifPasit("1", ogrNo);

               // messagebox(ogrBilgiGetir.id.ToString() + "," + ogrNo.ToString() + "" + ogrBilgiGetir.birimID.ToString() + "" + ogrBilgiGetir.bolumID.ToString() + "" + ogrBilgiGetir.idari_Akademi.ToString() + "" + Convert.ToInt16(Session["persID"]).ToString());
                ///buraya melihten alınan Kodlar konulacak..
            }
        }
        turna.SaveChanges();
    }
    public void messagebox(string mesaj)
    {


        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }
    protected void btn_Click(object sender, EventArgs e)
    {
        Response.Redirect("../komisyon/iseAlinanOgrenciler.aspx");
    }
}

   
