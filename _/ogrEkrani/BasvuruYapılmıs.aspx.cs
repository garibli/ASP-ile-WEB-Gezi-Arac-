using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class ogrEkrani_BasvuruYapılmıs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "ogr")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

        if (Session["BasvuruVar"] == null)
        {
            Response.Redirect("./Default.aspx");
        }

        string ogrNo = Session["ogrNo"].ToString();
        TurnaEntities turna = new TurnaEntities();
        var basvuruSorgula = from basvuru in turna.tblOgrBasvuruBilgileri
                             where basvuru.ogrNo == ogrNo
                             select new { basvuru.BasvuruID };
        int[] i1 = new int [3];
        int sayac = 0;
        foreach (var item in basvuruSorgula)
        {
           
            i1[sayac] = Convert.ToInt16(item.BasvuruID);
           sayac++;

        }

        int ilanID = -1;

        if (i1[0] != -1)
        {
            ilanID = i1[0];
            var ilan1 = from ilan in turna.tblIlanlar
                        join birim in turna.tblBirimler
                        on ilan.birimID equals birim.id
                        where ilan.id == ilanID
                        select new { ilan.isBasligi,ilan.isTanimi,ilan.kontenjan,birim.adi };
            foreach (var item in ilan1)
            {
                lbl1.Text = item.adi + " - " + item.isBasligi + " - " + item.isTanimi;
            }
        }

        if (i1[1] != -1)
        {

            ilanID = i1[1];

            var ilan1 = from ilan in turna.tblIlanlar
                        join birim in turna.tblBirimler
                        on ilan.birimID equals birim.id
                        where ilan.id == ilanID
                        select new { ilan.isBasligi, ilan.isTanimi, ilan.kontenjan, birim.adi };
            foreach (var item in ilan1)
            {
                lbl2.Text = item.adi + " - " + item.isBasligi + " - " + item.isTanimi;
            }
        }

        if (i1[2] != -1)
        {
            ilanID = i1[2];

            var ilan1 = from ilan in turna.tblIlanlar
                        join birim in turna.tblBirimler
                        on ilan.birimID equals birim.id
                        where ilan.id == ilanID
                        select new { ilan.isBasligi, ilan.isTanimi, ilan.kontenjan, birim.adi };
            foreach (var item in ilan1)
            {
                lbl3.Text = item.adi + " - " + item.isBasligi + " - " + item.isTanimi;
            }
        }



    }
    protected void btnGonder_Click(object sender, EventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();

        string ogrNo = Session["ogrNo"].ToString();
        
        var basvuruSorgula = from basvuru in turna.tblOgrBasvuruBilgileri
                             where basvuru.ogrNo == ogrNo
                             select new { basvuru.id };
        int id = -1;

        foreach (var item in basvuruSorgula)
	{
            id = item.id;
	}

        tblOgrBasvuruBilgileri ilanSil = turna.tblOgrBasvuruBilgileri.First(n => n.id == id);
        turna.tblOgrBasvuruBilgileri.DeleteObject(ilanSil);
        turna.SaveChanges();

        Response.Redirect("Ilan.aspx");
    }
}