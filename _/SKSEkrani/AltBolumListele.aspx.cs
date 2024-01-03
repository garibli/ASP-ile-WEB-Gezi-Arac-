using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_AltBolumListele : System.Web.UI.Page
{

    public void gridViewDoldur()
    {

        TurnaEntities turna = new TurnaEntities();

        var bolumGetirQuery = from bolum in turna.tblBolumler
                              join birim in turna.tblBirimler
                              on bolum.birimID equals birim.id
                              join bolumTuru in turna.tblBolumTuru
                              on bolum.bolumTuru equals bolumTuru.bolumNo
                              join ogrenimTuru in turna.tblOgrenimTuru
                              on bolum.ogrenimTuru equals ogrenimTuru.ogrenimNo
                              orderby birim.adi, bolum.adi
                              select new { bolum.adi, bolum.altKontenjan, ogrenimTuru = ogrenimTuru.adi, bolumTuru = bolumTuru.adi, birimAdi = birim.adi, birim.UstKontenjan };

        try
        {

            if (Convert.ToInt16(ddlBirim.SelectedValue) > -1)
            {
                int birimID = Convert.ToInt16(ddlBirim.SelectedValue);



                bolumGetirQuery = from bolum in turna.tblBolumler
                                  join birim in turna.tblBirimler
                                  on bolum.birimID equals birim.id
                                  join bolumTuru in turna.tblBolumTuru
                                  on bolum.bolumTuru equals bolumTuru.bolumNo
                                  join ogrenimTuru in turna.tblOgrenimTuru
                                  on bolum.ogrenimTuru equals ogrenimTuru.ogrenimNo
                                  orderby birim.adi, bolum.adi
                                  where bolum.birimID == birimID
                                  select new { bolum.adi, bolum.altKontenjan, ogrenimTuru = ogrenimTuru.adi, bolumTuru = bolumTuru.adi, birimAdi = birim.adi, birim.UstKontenjan };
                             
                                



            }

        }
        catch (Exception)
        {


        }




        DtListBolum.DataSource = bolumGetirQuery.ToList();
        DtListBolum.DataBind();


    }


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.


        if (!IsPostBack)
        {
            VeriIslemleri veri = new VeriIslemleri();

            veri.ddlVeriCekBirimler(ddlBirim);


            gridViewDoldur();
        }

      
    }
    protected void ddlBirim_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridViewDoldur();
    }
}