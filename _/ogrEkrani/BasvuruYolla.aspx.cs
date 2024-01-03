using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class ogrEkrani_BasvuruYolla : System.Web.UI.Page
{
    int ilanID1, ilanID2, ilanID3;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "ogr")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

        if (!IsPostBack)
        {


            TurnaEntities turna = new TurnaEntities();
            if (Session["ilanID1"] != null)
            {
                ilanID1 = Convert.ToInt16(Session["ilanID1"]);
            }
            else
            {
               Session["ilanID1"] = ilanID1 = -1;
            }
            if (Session["ilanID2"] != null)
            {
                ilanID2 = Convert.ToInt16(Session["ilanID2"]);
            }
            else
            {
               Session["ilanID2"] = ilanID2 = -1;
            }
            if (Session["ilanID3"] != null)
            {
                ilanID3 = Convert.ToInt16(Session["ilanID3"]);
            }
            else
            {
                Session["ilanID3"] = ilanID3 = -1;
            }



            ddl1.Visible = false;
            ddl2.Visible = false;
            ddl3.Visible = false;
            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;

            if (ilanID1 != -1)
            {
                var getir = from ilan in turna.tblIlanlar
                            join birim in turna.tblBirimler
                            on ilan.birimID equals birim.id
                            where ilan.id == ilanID1
                            select new { birim.adi, ilan.isBasligi, ilan.isMetni };
                foreach (var item in getir)
                {
                    string tercih = item.adi + " " + item.isBasligi;
                    ddl1.Visible = true;
                    ddl1.Items.Add(new ListItem("1", ilanID1.ToString()+" "));
                    ddl1.Items.Add(new ListItem("2", ilanID1.ToString())+"  ");
                    ddl1.Items.Add(new ListItem("3", ilanID1.ToString())+"   ");
                    lbl1.Visible = true;
                    lbl1.Text = tercih;
                    ddl1.Items.RemoveAt(0);
                }
            }
            if (ilanID2 != -1)
            {
                var getir = from ilan in turna.tblIlanlar
                            join birim in turna.tblBirimler
                            on ilan.birimID equals birim.id
                            where ilan.id == ilanID2
                            select new { birim.adi, ilan.isBasligi, ilan.isMetni };
                foreach (var item in getir)
                {
                    string tercih = item.adi + " " + item.isBasligi;
                    ddl2.Visible = true;
                    ddl2.Items.Add(new ListItem("1", ilanID2.ToString()+" "));
                    ddl2.Items.Add(new ListItem("2", ilanID2.ToString()+"  "));
                    ddl2.Items.Add(new ListItem("3", ilanID2.ToString()+"   "));
                    lbl2.Visible = true;
                    lbl2.Text = tercih;
                    ddl2.Items.RemoveAt(0);
                }
            }

            if (ilanID3 != -1)
            {
                var getir = from ilan in turna.tblIlanlar
                            join birim in turna.tblBirimler
                            on ilan.birimID equals birim.id
                            where ilan.id == ilanID3
                            select new { birim.adi, ilan.isBasligi, ilan.isMetni };
                foreach (var item in getir)
                {
                    string tercih = item.adi + " " + item.isBasligi;
                    ddl3.Visible = true;
                    ddl3.Items.Add(new ListItem("1", ilanID3.ToString()+" "));
                    ddl3.Items.Add(new ListItem("2", ilanID3.ToString()+"  "));
                    ddl3.Items.Add(new ListItem("3", ilanID3.ToString()+"   "));
                    lbl3.Visible = true;
                    lbl3.Text = tercih;
                    ddl3.Items.RemoveAt(0);
                }
            }


        }
        


    }
    protected void btnGonder_Click(object sender, EventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();
        int ilan1 = -1, ilan2 = -1, ilan3 = -1;
        if (ddl1.SelectedItem.Text.TrimEnd(' ') != ddl2.SelectedItem.Text.TrimEnd(' ') && ddl1.SelectedItem.Text.TrimEnd(' ') != ddl3.SelectedItem.Text.TrimEnd(' ') && ddl2.SelectedItem.Text.TrimEnd(' ') != ddl3.SelectedItem.Text.TrimEnd(' '))
        {
            if (ddl1.SelectedItem.Text.TrimEnd(' ') == "1")
            {
                ilan1 = Convert.ToInt16(Session["ilanID1"]);
            }
            else if (ddl1.SelectedItem.Text.TrimEnd(' ') == "2")
            {
                ilan2 = Convert.ToInt16(Session["ilanID1"]);
            }
            else if (ddl1.SelectedItem.Text.TrimEnd(' ') == "3")
            {
                ilan3 = Convert.ToInt16(Session["ilanID1"]);
            }
            if (ddl2.SelectedItem.Text.TrimEnd(' ') == "1")
            {
                ilan1 = Convert.ToInt16(Session["ilanID2"]);
            }
            else if (ddl2.SelectedItem.Text.TrimEnd(' ') == "2")
            {
                ilan2 = Convert.ToInt16(Session["ilanID2"]);
            }
            else if (ddl2.SelectedItem.Text.TrimEnd(' ') == "3")
            {
                ilan3 = Convert.ToInt16(Session["ilanID2"]);
            }
            if (ddl3.SelectedItem.Text.TrimEnd(' ') == "1")
            {
                ilan1 = Convert.ToInt16(Session["ilanID3"]);
            }
            else if (ddl3.SelectedItem.Text.TrimEnd(' ') == "2")
            {
                ilan2 = Convert.ToInt16(Session["ilanID3"]);
            }
            else if (ddl3.SelectedItem.Text.TrimEnd(' ') == "3")
            {
                ilan3 = Convert.ToInt16(Session["ilanID3"]);
            }
            string ogrNoAL=Session["ogrNo"].ToString();
            var ogrToplamPuanAl=(from toplamPuan in turna.tblOgrenciAnketCevablari where toplamPuan.ogrNo==ogrNoAL select new{toplamPuan.anketPuaniTop}).FirstOrDefault();
            tblOgrBasvuruBilgileri  basvuruEkle = new tblOgrBasvuruBilgileri();
           
            basvuruEkle.BasvuruID = Convert.ToInt16(ilan1);
           // basvuruEkle.MulakatSoruldumu = 0;
            basvuruEkle.ToplamPuan=Convert.ToInt16(ogrToplamPuanAl.anketPuaniTop);
            basvuruEkle.ogrNo = ogrNoAL;
            turna.tblOgrBasvuruBilgileri.AddObject(basvuruEkle);
            turna.SaveChanges();

            tblOgrBasvuruBilgileri basvuruEkle2 = new tblOgrBasvuruBilgileri();

            basvuruEkle2.BasvuruID =Convert.ToInt16(ilan2);
           // basvuruEkle2.MulakatSoruldumu = 0;
             basvuruEkle2.ToplamPuan=Convert.ToInt16(ogrToplamPuanAl.anketPuaniTop);
            basvuruEkle2.ogrNo = ogrNoAL;
            turna.tblOgrBasvuruBilgileri.AddObject(basvuruEkle2);
            turna.SaveChanges();



            tblOgrBasvuruBilgileri basvuruEkle3 = new tblOgrBasvuruBilgileri();

            basvuruEkle3.BasvuruID = Convert.ToInt16(ilan3);
          //  basvuruEkle3.MulakatSoruldumu = 0;
             basvuruEkle3.ToplamPuan=Convert.ToInt16(ogrToplamPuanAl.anketPuaniTop);
             basvuruEkle3.ogrNo = ogrNoAL;
            turna.tblOgrBasvuruBilgileri.AddObject(basvuruEkle3);
            turna.SaveChanges();




            Response.Redirect("BasvuruAlindi.aspx");
        }


        else
        {
            lblBilgi.Text = "İlan önceliklerinizi ayarlayınız. ";
        }
    }
        

       
    
}