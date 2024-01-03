using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_SilmeIslemleri_CalisanSil : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    VeriIslemleri veri = new VeriIslemleri();
    IsKurallari isKuarallar = new IsKurallari();



    public void ogrListele()
    {
        TurnaEntities turna = new TurnaEntities();





        var ogrGetir = from ogr in turna.tblOgrenci
                       join birimi in turna.tblBirimler
                       on ogr.okulu equals birimi.id
                       orderby birimi.adi, ogr.ad ascending
                       select new { ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, OkulID = birimi.id, OkulAdi = birimi.adi, ogr.bolumu, ogr.ceptel, ogr.mail, ogr.aktifMi, ogr.capOkulu, ogr.capBolumu, ogr.sifre, ogr.id, ogr.ogrenimTuru, ogr.Sinifi, ogr.notOrtalamasi };


        if (ddlBirim.SelectedValue != "-1" )
        {

            int birimID = Convert.ToInt16(ddlBirim.SelectedValue);

            ogrGetir = from ogr in turna.tblOgrenci
                       join birimi in turna.tblBirimler
                       on ogr.okulu equals birimi.id
                       where ogr.okulu == birimID
                       orderby birimi.adi, ogr.ad ascending
                       select new { ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, OkulID = birimi.id, OkulAdi = birimi.adi, ogr.bolumu, ogr.ceptel, ogr.mail, ogr.aktifMi, ogr.capOkulu, ogr.capBolumu, ogr.sifre, ogr.id, ogr.ogrenimTuru,ogr.Sinifi,ogr.notOrtalamasi };

        }
       


        

        GridView1.DataSource = ogrGetir.ToList();
        GridView1.DataBind();




    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

        if (!IsPostBack)
        {
            veri.ddlVeriCekFakYukOkul(ddlFakYukOkul, "0");

            veri.ddlVeriCekFakYukOkul(ddlCapFak, "0");

            veri.ddlVeriCekFakYukOkul(ddlBirim, "0");


            ogrListele();
        }


    }
    public void messagebox(string mesaj)
    {


        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }
    protected void btnGonder_Click(object sender, EventArgs e)
    {
        if ( txtID.Text != "")
        {

            int ogrID = Convert.ToInt16(txtID.Text);


            if (txtAd.Text != "" && txtSoyad.Text != "" && (txtTC.Text.Count() == 11) && (txtOgrNo.Text.Count() == 10) && ddlBolum.SelectedValue != "-1" && ddlFakYukOkul.SelectedValue != "-1" && txtSifre.Text != "" )
            {

                if (isKuarallar.mailSakaryaMi(txtMail.Text.TrimEnd(' '), "ogr.sakarya.edu.tr"))
                {
                    


                   



                        try
                        {


                            int birim = Convert.ToInt16(ddlFakYukOkul.SelectedValue);
                            int bolum = Convert.ToInt16(ddlBolum.SelectedValue);
                            //int ogrenimTuru = -1;
                            //var ogrenimGetir = from birimler in turna.tblBirimler
                            //                   join bolumler in turna.tblBolumler
                            //                   on birimler.id equals bolumler.birimID
                            //                   where birimler.id == birim && bolumler.id == bolum
                            //                   select new { bolumler.ogrenimTuru };
                            //foreach (var item in ogrenimGetir)
                            //{
                            //    ogrenimTuru = item.ogrenimTuru.Value;
                            //}


                            tblOgrenci ogrGuncelle = turna.tblOgrenci.First(n => n.id == ogrID);

                            ogrGuncelle.ogrNo = txtOgrNo.Text;
                            ogrGuncelle.ad = txtAd.Text;
                            ogrGuncelle.soyad = txtSoyad.Text;
                            ogrGuncelle.sifre = txtSifre.Text;
                            ogrGuncelle.tc = txtTC.Text;
                            ogrGuncelle.mail = txtMail.Text;
                            ogrGuncelle.ceptel = txtCep.Text;
                            ogrGuncelle.okulu = Convert.ToInt16(ddlFakYukOkul.SelectedValue);
                            ogrGuncelle.bolumu = Convert.ToInt16(ddlBolum.SelectedValue);
                            ogrGuncelle.ogrenimTuru = Convert.ToInt16(ddlOgrenimTuru.SelectedValue);
                            ogrGuncelle.capOkulu = Convert.ToInt16(ddlCapFak.SelectedValue);
                            ogrGuncelle.capBolumu = Convert.ToInt16(ddlCapBolum.SelectedValue);
                            ogrGuncelle.Sinifi = ddlSinif.SelectedValue;
                            double notOrtalamasi = Convert.ToDouble(ddlNot1.SelectedValue + "," + ddlNot2.SelectedValue + ddlNot3.SelectedValue);

                            ogrGuncelle.notOrtalamasi = Convert.ToDecimal(notOrtalamasi);


                            turna.SaveChanges();


                            ogrListele();


                            lblBilgi.Text = "Güncellendi.";
                        }
                        catch (Exception)
                        {
                            lblBilgi.Text = "Verilerinizi Kontrol Ediniz...";

                        }

                   
                }
                else
                {
                    lblBilgi.Text = "Lütfen öğrenci mail adresinizi giriniz...";
                }
            }
            else
            {
                lblBilgi.Text = "Gerekli alanları doğru bir şekilde doldurunuz...";
            }
        }
        else
        {
            lblBilgi.Text = "Güncellenilcek Öğrenciyi aşağıdaki listeden seçiniz.";
        }

        ogrListele();

    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked)
        {
            ddlCapFak.Enabled = true;
            ddlCapBolum.Enabled = true;
        }
        else
        {
            ddlCapFak.Enabled = false;
            ddlCapBolum.Enabled = false;
        }
    }
    protected void ddlFakYukOkul_SelectedIndexChanged(object sender, EventArgs e)
    {
        veri.ddlVeriCekParamBolumlerGetir(ddlBolum, Convert.ToInt16(ddlFakYukOkul.SelectedValue));
    }
    protected void ddlCapFak_SelectedIndexChanged(object sender, EventArgs e)
    {
        veri.ddlVeriCekParamBolumlerGetir(ddlCapBolum, Convert.ToInt16(ddlCapFak.SelectedValue));
    }



    protected void ddlBirim_SelectedIndexChanged(object sender, EventArgs e)
    {
        ogrListele();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        lblBilgi.Text = "";
        

        txtTC.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[1].Text);
        txtOgrNo.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[2].Text);
        txtAd.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[3].Text).TrimEnd(' ');
        txtSoyad.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[4].Text).TrimEnd(' ');
        ddlFakYukOkul.SelectedValue = GridView1.SelectedRow.Cells[5].Text;
        bolumListele();
        ddlBolum.SelectedValue = GridView1.SelectedRow.Cells[7].Text;
        txtCep.Text = GridView1.SelectedRow.Cells[8].Text;
        txtMail.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[9].Text).TrimEnd(' ');
        txtSifre.Text = HttpUtility.HtmlDecode(GridView1.SelectedRow.Cells[13].Text).TrimEnd(' ');
        txtID.Text = GridView1.SelectedRow.Cells[14].Text;

        int ogrenimTuru = Convert.ToInt16(GridView1.SelectedRow.Cells[15].Text);

        ddlSinif.SelectedValue = GridView1.SelectedRow.Cells[16].Text;

        if (ogrenimTuru > 0 && ogrenimTuru < 5)
        {
            ddlOgrenimTuru.SelectedValue = ogrenimTuru.ToString();
        }
        else
        {
            ddlOgrenimTuru.SelectedValue = "-1";
        }

        

        if (GridView1.SelectedRow.Cells[11].Text != "-1")
        {
            ddlCapFak.Text = GridView1.SelectedRow.Cells[11].Text;
            ddlCapFak.SelectedValue = GridView1.SelectedRow.Cells[11].Text;
            CheckBox1.Checked = true;
            if (CheckBox1.Checked)
            {
                ddlCapFak.Enabled = true;
                ddlCapBolum.Enabled = true;
            }
            else
            {
                ddlCapFak.Enabled = false;
                ddlCapBolum.Enabled = false;
            }
        }
       
        if (GridView1.SelectedRow.Cells[12].Text != "-1")
        {
            bolumListeleCap();
            ddlCapBolum.Text = GridView1.SelectedRow.Cells[12].Text;
           
                CheckBox1.Checked = true;
           
                ddlCapFak.Enabled = true;
                ddlCapBolum.Enabled = true;
           
           
            
        }
        if (GridView1.SelectedRow.Cells[11].Text == "-1" && GridView1.SelectedRow.Cells[12].Text == "-1")
        {
            CheckBox1.Checked = false;

            ddlCapFak.Enabled = false;
            ddlCapBolum.Enabled = false;
        }


    }
    public void bolumListele()
    {
        var birimSecildi = Convert.ToInt16(ddlFakYukOkul.SelectedItem.Value);

        var bolumGetir = from bolum in turna.tblBolumler
                         where bolum.birimID == birimSecildi
                         orderby bolum.adi ascending
                         select new { bolum.adi, bolum.id };
        ddlBolum.DataSource = bolumGetir.ToList();
        ddlBolum.DataValueField = "id";
        ddlBolum.DataTextField = "adi";
        ddlBolum.DataBind();
        ddlBolum.Items.Insert(0, new ListItem("- Bolum Seçiniz -", "-1"));
    }
    public void bolumListeleCap()
    {
        var birimSecildi = Convert.ToInt16(ddlCapFak.SelectedItem.Value);

        var bolumGetir = from bolum in turna.tblBolumler
                         where bolum.birimID == birimSecildi
                         orderby bolum.adi ascending
                         select new { bolum.adi, bolum.id };
        ddlCapBolum.DataSource = bolumGetir.ToList();
        ddlCapBolum.DataValueField = "id";
        ddlCapBolum.DataTextField = "adi";
        ddlCapBolum.DataBind();
        ddlCapBolum.Items.Insert(0, new ListItem("- Bolum Seçiniz -", "-1"));
    }
    protected void btnSil_Click(object sender, EventArgs e)
    {
        if (txtID.Text != "")
        {
            int ogrID = Convert.ToInt16(txtID.Text);

            tblOgrenci ogrSil = turna.tblOgrenci.First(n => n.id == ogrID);

            turna.tblOgrenci.DeleteObject(ogrSil);

            turna.SaveChanges();


            tblOgrHesapNoGSS ogrHesapGSS = turna.tblOgrHesapNoGSS.First(n => n.ogrNo == txtOgrNo.Text);

            turna.tblOgrHesapNoGSS.DeleteObject(ogrHesapGSS);

            turna.SaveChanges();


            lblBilgi.Text = txtOgrNo.Text + " Nolu öğrenci başarıyla silinmiştir.";

            txtAd.Text = "";
            txtCep.Text = "";
            txtID.Text = "";
            txtMail.Text = "";
            txtOgrNo.Text = "";
            txtSifre.Text = "";
            txtSoyad.Text = "";
            txtTC.Text = "";
            


            ogrListele();


        }
        else
        {
            lblBilgi.Text = "Önce aşağıdaki listeden öğrenci seçiniz.";
        }

    }
}