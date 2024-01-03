using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_CalismaYerleri : System.Web.UI.Page
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
        {
            veri.ddlVeriCekBirimler(ddlBirimler);
            veri.ddlVeriCekBirimler(ddlOkuduguOkul);
        }

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int sgkId = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);




        TurnaEntities turna = new TurnaEntities();

        tblCalismaYerleri calismaYerSil = turna.tblCalismaYerleri.First(n => n.id == sgkId);

        turna.tblCalismaYerleri.DeleteObject(calismaYerSil);

        turna.SaveChanges();

        guncelle();

    }
    protected void ddlOgr_SelectedIndexChanged(object sender, EventArgs e)
    {
        guncelle();

    }
    protected void ddlBirimler_SelectedIndexChanged(object sender, EventArgs e)
    {
        VeriIslemleri veri = new VeriIslemleri();

        veri.ddlVeriCekParamBirimCalisanGetirIDogrNo(ddlOgr, Convert.ToInt16(ddlBirimler.SelectedValue));

    }
    public void guncelle()
    {
        TurnaEntities turna = new TurnaEntities();

        var getirSGKGirisCikis = from sgk in turna.tblCalismaYerleri
                                 join okul in turna.tblBirimler
                                 on sgk.calisacagiCalistigiYer equals okul.id
                                 where sgk.ogrNo == ddlOgr.SelectedValue
                                 select new { sgk.id, sgk.ogrNo, okul.adi };

        GridView1.DataSource = getirSGKGirisCikis.ToList();
        GridView1.DataBind();
    }
    protected void ddlOkuduguOkul_SelectedIndexChanged(object sender, EventArgs e)
    {
        VeriIslemleri veri = new VeriIslemleri();

        TurnaEntities turna = new TurnaEntities();

        int okuduguOkul = Convert.ToInt16(ddlOkuduguOkul.SelectedValue);


        var ogrGetir = from ogr in turna.tblOgrenci
                       where ogr.okulu == okuduguOkul
                       orderby ogr.ad
                       select ogr;

        ddlOgr.Items.Clear();

        foreach (var item in ogrGetir)
        {
            ddlOgr.Items.Add(new ListItem(item.ad + " " + item.soyad + " " + item.ogrNo, item.ogrNo));

        }




    }
}