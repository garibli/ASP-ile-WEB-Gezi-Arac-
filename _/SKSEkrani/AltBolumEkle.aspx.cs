using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_AltBolumEkle : System.Web.UI.Page
{
    public void BolumDoldurGrid()
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

        VeriIslemleri veri = new VeriIslemleri();

        if (!IsPostBack)
        veri.ddlVeriCekBirimler(ddlBirim);
       
        TurnaEntities turna = new TurnaEntities();


        var bolumGetir = from birimler in turna.tblBirimler
                         join bolumler in turna.tblBolumler
                         on birimler.id equals bolumler.birimID
                         join bolumTuru in turna.tblBolumTuru
                         on bolumler.bolumTuru equals bolumTuru.bolumNo
                         join ogrenTuru in turna.tblOgrenimTuru
                         on bolumler.ogrenimTuru equals ogrenTuru.ogrenimNo
                         orderby birimler.adi ascending, bolumler.adi ascending
                         select new { birimler.id, birimAdi = birimler.adi, bolumID = bolumler.id, bolumAdi = bolumler.adi, OgrenimTuru = ogrenTuru.adi, bolumTuru = bolumTuru.adi };


        DtlistBolumEkle.DataSource = bolumGetir.ToList();
        DtlistBolumEkle.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
        }


        BolumDoldurGrid();

    }
    protected void btnOlustur_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlBirim.SelectedValue != "-1" && ddlBolumTuru.SelectedValue != "-1" && ddlOgrenimTuru.SelectedValue != "-1" && txtAltBirim.Text != "" )
            {

                TurnaEntities turna = new TurnaEntities();

                int birimID = Convert.ToInt16(ddlBirim.SelectedValue);


                turna.BolumEkle(Convert.ToInt16(ddlBirim.SelectedValue), txtAltBirim.Text, Convert.ToInt16(ddlOgrenimTuru.SelectedValue), ddlBolumTuru.SelectedValue, 0, 0, 0, 0, 0, 0, 0);
               
                BolumDoldurGrid();

                txtAltBirim.Text = "";
                
            }


            else
            {

                lblBilgi.Text = "* Alanlarını Doldurunuz...";
            }
        }
        catch (Exception)
        {

            lblBilgi.Text = "Girdiğiniz verileri kontrol ediniz...";
        }
    }
    protected void ddlOgrenimTuru_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}