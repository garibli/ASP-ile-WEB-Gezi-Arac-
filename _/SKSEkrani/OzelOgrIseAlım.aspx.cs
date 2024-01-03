using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_OzelOgrIseAlım : System.Web.UI.Page
{

    TurnaEntities turna = new TurnaEntities();

    public void ddlOkulGetir(DropDownList ddl, string birimTuruEngelle)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("TÜM ÖĞRENCİLER", "-1"));

        var getir = from birim in turna.tblBirimler
                    orderby birim.adi ascending
                    select new { birim.id, birim.adi, birim.BirimTuru };


        foreach (var item in getir)
        {

            if (item.BirimTuru != birimTuruEngelle)
                ddl.Items.Add(new ListItem(item.adi.ToString(), item.id.ToString()));

        }
    }

    public void ddlOgrGetir(DropDownList ddl, int okulID)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("TÜM ÖĞRENCİLER", "-1"));

        var getir = from ogr in turna.tblOgrenci
                    join anket in turna.tblOgrenciAnketCevablari
                    on ogr.ogrNo equals anket.ogrNo
                    orderby ogr.ad ascending
                    where ogr.id == -1 
                    select new { ogr.ogrNo, ogr.ad, ogr.soyad, anket.secimlerIDPUANEk3 };

        if (okulID == -1)
        {
            getir = from ogr in turna.tblOgrenci
                    join anket in turna.tblOgrenciAnketCevablari
                    on ogr.ogrNo equals anket.ogrNo
                    where ogr.aktifMi == "0"
                    orderby ogr.ad ascending
                    select new { ogr.ogrNo, ogr.ad, ogr.soyad, anket.secimlerIDPUANEk3 };

        }
        else
        {
            getir = from ogr in turna.tblOgrenci
                    join anket in turna.tblOgrenciAnketCevablari
                    on ogr.ogrNo equals anket.ogrNo
                    where ogr.okulu == okulID && ogr.aktifMi == "0"
                    orderby ogr.ad ascending
                    select new { ogr.ogrNo, ogr.ad, ogr.soyad, anket.secimlerIDPUANEk3};


        }


        bool ekle = false;
        bool kayitYok = true;
        foreach (var item in getir)
        {

            var calisiyomu = from sgk in turna.SGKGirisCikis
                             where sgk.ogrNo == item.ogrNo
                             select new { sgk.SGKCikis };

            foreach (var item2 in calisiyomu)
            {
                kayitYok = false;
                if (item2.SGKCikis < DateTime.Now && item2.SGKCikis != null)
                    ekle = true;
                else
                    ekle = false;
            }

            if (item.secimlerIDPUANEk3[1].ToString() == " ")
            {

                if (ekle || kayitYok)
                {
                    ddl.Items.Add(new ListItem(item.ogrNo.ToString() + " " + item.ad.ToString() + " " + item.soyad.ToString(), item.ogrNo.ToString()));

                }

            }

            ekle = false;
            kayitYok = true;

        }




    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.



        if (!IsPostBack)
        {


            ddlOkulGetir(ddlOkulFiltrele, "0");

            ddlOgrGetir(ddlOgrenci, -1);

            ddlOkulGetir(ddlBirim, "-1");

            var calismaSekliGetir = from calismaSekli in turna.tblCalismaSekli
                                    orderby calismaSekli.adi ascending
                                    select new { calismaSekli.adi, calismaSekli.id };


            foreach (var item in calismaSekliGetir)
            {
                ddlCalismaSekli.Items.Add(new ListItem(item.adi.ToString(), item.id.ToString()));
            }

        }
    }

    protected void ddlOkulFiltrele_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlOgrGetir(ddlOgrenci, Convert.ToInt16(ddlOkulFiltrele.SelectedValue));
    }
    protected void ddlBirim_SelectedIndexChanged(object sender, EventArgs e)
    {
        VeriIslemleri veri = new VeriIslemleri();

        veri.ddlVeriCekParamBolumlerGetir(ddlAltBirim, Convert.ToInt16(ddlBirim.SelectedValue));
    }
    protected void btnIseAl_Click(object sender, EventArgs e)
    {
        int altBirim;
        if (ddlAltBirim.SelectedValue != "")
        {
            altBirim = Convert.ToInt16(ddlAltBirim.SelectedValue);
        }
        else
        {
            altBirim = -1;
        }

        int birim = Convert.ToInt16(ddlBirim.SelectedValue);

        int calismaSekli;

        if (ddlCalismaSekli.SelectedValue != "")
        {
            calismaSekli = Convert.ToInt16(ddlCalismaSekli.SelectedValue);
        }
        else
        {
            calismaSekli = -1;
        }


        string ogrNo = ddlOgrenci.SelectedValue;

        if (birim > -1 && calismaSekli > -1 && ogrNo != "-1")
        {


            var ogrIDGetir = from ogr in turna.tblOgrenci
                             where ogr.ogrNo == ogrNo
                             select new { ogr.id };
            int ogrID = -1;
            foreach (var item in ogrIDGetir)
            {
                ogrID = item.id;
            }

            VeriIslemleri veri = new VeriIslemleri();



           
        }
        else
        {
            lblBilgi.Text = "Gerekli Alanları Doldurunuz.";
        }




    }
}