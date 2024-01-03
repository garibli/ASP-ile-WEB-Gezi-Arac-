using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_SGKCikisNull : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
        }


        VeriIslemleri veri = new VeriIslemleri();
        if (!IsPostBack)
            veri.ddlVeriCekBirimler(ddlBirimler);

        TurnaEntities turna = new TurnaEntities();

        var ogrGetir = (from ogr in turna.tblOgrenci
                        join calismaYer in turna.tblCalismaYerleri
                        on ogr.ogrNo equals calismaYer.ogrNo
                        join birimler in turna.tblBirimler
                        on calismaYer.calisacagiCalistigiYer equals birimler.id
                        join SGK in turna.SGKGirisCikis
                        on ogr.ogrNo equals SGK.ogrNo
                        where calismaYer.aktifMi == "2"
                        select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, SGK.SGKGiris, SGK.SGKCikis, CalismaBasvuruID = calismaYer.id, SGKID = SGK.id }).Distinct();



        GridView1.DataSource = ogrGetir.ToList();
        GridView1.DataBind();
    }
    protected void ddlBirimler_SelectedIndexChanged(object sender, EventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();
        int birim = Convert.ToInt16(ddlBirimler.SelectedValue);
        var ogrGetir = (from ogr in turna.tblOgrenci
                        join calismaYer in turna.tblCalismaYerleri
                        on ogr.ogrNo equals calismaYer.ogrNo
                        join birimler in turna.tblBirimler
                        on calismaYer.calisacagiCalistigiYer equals birimler.id
                        join SGK in turna.SGKGirisCikis
                        on ogr.ogrNo equals SGK.ogrNo
                        where calismaYer.calisacagiCalistigiYer == birim && calismaYer.aktifMi == "2"
                        select new { ogr.id, ogr.tc, ogr.ogrNo, ogr.ad, ogr.soyad, ogr.mail, ogr.ceptel, CalistigiBirimAdi = birimler.adi, SGK.SGKGiris, SGK.SGKCikis, CalismaBasvuruID = calismaYer.id, SGKID = SGK.id }).Distinct();



        GridView1.DataSource = ogrGetir.ToList();
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {


            int SGKID = Convert.ToInt16(GridView1.SelectedRow.Cells[12].Text);
            int calismaYerID = Convert.ToInt16(GridView1.SelectedRow.Cells[11].Text);
            string ogrNo = GridView1.SelectedRow.Cells[3].Text;
            int ogrID = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);
            TurnaEntities turna = new TurnaEntities();

            int birim = Convert.ToInt16(ddlBirimler.SelectedValue);


            var altBirimGetir = from calismaYer in turna.tblCalismaYerleri
                                where calismaYer.id == calismaYerID
                                select new { calismaYer.calisacagiCalistigiYer, calismaYer.calisacagiCalistigiAltBirimi };

            int altBirim = -1;

            foreach (var item in altBirimGetir)
            {
                birim = Convert.ToInt16(item.calisacagiCalistigiYer);
                altBirim = Convert.ToInt16(item.calisacagiCalistigiAltBirimi);
            }

            VeriIslemleri veri = new VeriIslemleri();

            
        }
        catch (Exception)
        {


        }
    }
}
