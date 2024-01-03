using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class ogrEkrani_Ilan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "ogr")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
       string ogrNo = Session["ogrNo"].ToString();
        TurnaEntities turna = new TurnaEntities();


        var ozelOgrenciMi = from ozel in turna.tblOgrenciAnketCevablari
                            where ozel.ogrNo == ogrNo
                            select new { ozel.secimlerIDPUANEk3 };

        string ozelEk3 = "0";
        
        foreach (var item in ozelOgrenciMi)
        {
            ozelEk3 = item.secimlerIDPUANEk3.ToString();
        }

        if (ozelEk3[1].ToString() == " ")
        {
            Response.Redirect("OzelOgrenci.aspx");
        }


        
        
        
        var basvuruSorgula = from basvuru in turna.tblOgrBasvuruBilgileri
                             where basvuru.ogrNo == ogrNo
                             select new { basvuru.id };


        


        bool basvuruVar = false;

        foreach (var item in basvuruSorgula)
        {
            basvuruVar = true;
        }

        if (basvuruVar)
        {
            Session["BasvuruVar"] = "1";
            Response.Redirect("BasvuruYapılmıs.aspx");
            
        }


        {
            IsKurallari isK = new IsKurallari();
            if (!isK.anketGuncelmi(Session["Mail"].ToString()))
                Response.Redirect("./Anket.aspx");//anket cevapları güncel değilse.
        }



        ///////////////////öğrenci bilgileri/////////////////////
       
        string ogrMail = Session["Mail"].ToString();
        var ogrGetir = from ogr in turna.tblOgrenci
                       where ogr.mail == ogrMail
                       select new { ogr.okulu, ogr.capOkulu, ogr.notOrtalamasi,ogr.Sinifi,ogr.ogrenimTuru };
        
        int ogrokul = -1, capOkulu = -1;
        int sinif = 0;
        double notOrtalamasi = 0;
        int ogrenimTuru = 0;
        
        foreach (var item in ogrGetir)
        {
            if (item.okulu != null)
                ogrokul = item.okulu.Value;
            if (item.capOkulu != null)
                capOkulu = Convert.ToInt16(item.capOkulu);
            if (item.Sinifi != null)
                sinif = Convert.ToInt16(item.Sinifi);
            if (item.notOrtalamasi != null)
                notOrtalamasi = Convert.ToDouble(item.notOrtalamasi);
            if(item.ogrenimTuru != null)
                ogrenimTuru = Convert.ToInt16(item.ogrenimTuru);

        }


        var bolumTuruGetir = from ogr in turna.tblOgrenci
                             join bolum in turna.tblBolumler on ogr.bolumu equals bolum.id
                             where ogr.ogrNo == ogrNo
                             select new { bolum.bolumTuru };

        string ogrbTuru = "-1";

        foreach (var item in bolumTuruGetir)
        {
            ogrbTuru = item.bolumTuru.ToString();
        }
       

        //2den büyük 
        //enstütilerde olabiliyor.
        /////////////////////////////asistan öğrenci////////////////////////////////////

        var asistanOgr = from ilan in turna.tblIlanlar
                      join okul in turna.tblBirimler on ilan.birimID equals okul.id
                      join bolum in turna.tblBolumler on okul.id equals bolum.birimID
                      where ((okul.id == ogrokul || okul.id == capOkulu) &&
                      ilan.bitisSuresi >= DateTime.Now && ilan.idari_Akademi == 1 )
                      && sinif == 4   && notOrtalamasi > 2.50  && (bolum.bolumTuru == ogrbTuru    )///b.turu==b.turu
                      orderby okul.adi ascending
                      select new { ilan.id, bolumAdi = okul.adi, ilan.isBasligi, ilan.isTanimi, ilan.isMetni, ilan.kontenjan };



        
        DataListAsisOgr.DataSource = asistanOgr.ToList();
        DataListAsisOgr.DataBind();

        /////////////////////////////////////////////////////////////////////////////////////////
        







        /////////////////////////////////////fakultesindeki idari ilanlar///////////////////////////////////
        var DigerIlan = from ilan in turna.tblIlanlar
                        join birim in turna.tblBirimler on ilan.birimID equals birim.id
                        where (((birim.id == ogrokul) && notOrtalamasi > 2.00 && ilan.idari_Akademi == 2) && ilan.bitisSuresi >= DateTime.Now) //idari_akademi = 2 idari ; 1 Akademi
                        select new { bolumAdi = birim.adi, ilan.isBasligi, ilan.isTanimi, ilan.isMetni, ilan.kontenjan, ilan.id };

        DataListFak.DataSource = DigerIlan.ToList();
        DataListFak.DataBind();
        ///////////////////////////////////////////////////////////////////////////////////////////////////////









        ///////////////////////////////////////////diğer idari ilanlar/////////////////////////////////////////
        var DigerKurumIlan = from ilan in turna.tblIlanlar
                        join birim in turna.tblBirimler on ilan.birimID equals birim.id
                             where (((birim.BirimTuru == "0") && notOrtalamasi > 2.00 && ilan.idari_Akademi == 2) && ilan.bitisSuresi >= DateTime.Now) //idari_akademi = 2 idari ; 1 Akademi
                        select new { bolumAdi = birim.adi, ilan.isBasligi, ilan.isTanimi, ilan.isMetni, ilan.kontenjan, ilan.id };



        DataListIdari.DataSource = DigerKurumIlan.ToList();
        DataListIdari.DataBind();
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        





        ///////////////////////////////////////////yükseklisan doktora öğrencileri/////////////////////////////////////
        var ogrYuksekLisan = from ogr in turna.tblOgrenci
                             where ogr.ogrNo == ogrNo
                             select new { ogr.ogrenimTuru };
        int ogrTuru = -1 ;

        foreach (var item in ogrYuksekLisan)
	{
            ogrTuru = Convert.ToInt16(item.ogrenimTuru);
	}
        ////////////////////////////////////////yük dok.
        if (ogrTuru > 2)
        {

            DataListIdari.Visible = false;


            asistanOgr = from ilan in turna.tblIlanlar
                      join okul in turna.tblBirimler on ilan.birimID equals okul.id
                      join bolum in turna.tblBolumler on okul.id equals bolum.birimID
                      where ((okul.id == ogrokul) && notOrtalamasi > 2.50 && ilan.bitisSuresi >= DateTime.Now && ilan.idari_Akademi == 1
                      && bolum.bolumTuru == ogrbTuru )
                      select new { ilan.id, bolumAdi = okul.adi, ilan.isBasligi, ilan.isTanimi, ilan.isMetni, ilan.kontenjan };
          
            DataListFak.DataSource = asistanOgr.ToList();
            DataListFak.DataBind();


             DigerIlan = from ilan in turna.tblIlanlar
                            join birim in turna.tblBirimler on ilan.birimID equals birim.id
                            where (((birim.BirimTuru == "0" || birim.BirimTuru == ogrbTuru) && notOrtalamasi > 2.00 && ilan.idari_Akademi == 2) && ilan.bitisSuresi >= DateTime.Now) //idari_akademi = 2 idari ; 1 Akademi
                            select new { bolumAdi = birim.adi, ilan.isBasligi, ilan.isTanimi, ilan.isMetni, ilan.kontenjan, ilan.id };


             DataListIdari.DataSource = DigerIlan.ToList();
             DataListIdari.DataBind();
        }
       
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        
    }
    protected void btnGonder_Click(object sender, EventArgs e)
    {
        if (Session["ilanID1"] != null || Session["ilanID2"] != null || Session["ilanID3"] != null)
        {
            Response.Redirect("BasvuruYolla.aspx");

        }
        else
        {
            lblBilgi.Text = "Önce ilan başvurunuzu yapınız.";
                 
        }
    }
   // string[] ilanBasvuru = new string[3];
    protected void GridViewFakIlan_SelectedIndexChanged(object sender, EventArgs e)
    {




    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void DataListFak_ItemCommand(object source, DataListCommandEventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();
        switch (e.CommandName)
        {
            case "Ekle":
              int  ilanID1 = Convert.ToInt16(e.CommandArgument);
              Session["ilanID1"] = ilanID1;
                var getir = from ilan in turna.tblIlanlar
                            join birim in turna.tblBirimler
                            on ilan.birimID equals birim.id
                            where ilan.id == ilanID1
                            select new { birim.adi, ilan.isBasligi, ilan.isMetni };
                foreach (var item in getir)
                {
                    lbl1.Text = item.adi + " " + item.isBasligi;
                }


                break;
        }
    }
    protected void DataListIdari_ItemCommand(object source, DataListCommandEventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();
        switch (e.CommandName)
        {
            case "Ekle":
                  int ilanID2 = Convert.ToInt16(e.CommandArgument);
                 Session["ilanID2"] = ilanID2;
                    var getir = from ilan in turna.tblIlanlar
                            join birim in turna.tblBirimler
                            on ilan.birimID equals birim.id
                            where ilan.id == ilanID2
                            select new { birim.adi, ilan.isBasligi, ilan.isMetni };
                foreach (var item in getir)
                {
                    lbl2.Text = item.adi + " " + item.isBasligi;
                }

                break;
        }
    }
    protected void DataListDigerIdari_ItemCommand(object source, DataListCommandEventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();
        switch (e.CommandName)
        {
            case "Ekle":
                int ilanID3 = Convert.ToInt16(e.CommandArgument);
                Session["ilanID3"] = ilanID3;
                var getir = from ilan in turna.tblIlanlar
                            join birim in turna.tblBirimler
                            on ilan.birimID equals birim.id
                            where ilan.id == ilanID3
                            select new { birim.adi, ilan.isBasligi, ilan.isMetni };
                foreach (var item in getir)
                {
                    lbl3.Text = item.adi + " " + item.isBasligi;
                }


                break;
        }
    }
}