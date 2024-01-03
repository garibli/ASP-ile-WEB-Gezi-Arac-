using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_SGKGecmisi : System.Web.UI.Page
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

       
    }
  
    protected void ddlBirimler_SelectedIndexChanged(object sender, EventArgs e)
    {

        VeriIslemleri veri = new VeriIslemleri();

        veri.ddlVeriCekParamBirimCalisanGetirIDogrNo(ddlOgr, Convert.ToInt16(ddlBirimler.SelectedValue));

    }
    public void guncelle() 
    {
        TurnaEntities turna = new TurnaEntities();

        var getirSGKGirisCikis = from sgk in turna.SGKGirisCikis
                                 where sgk.ogrNo == ddlOgr.SelectedValue
                                 select new { sgk.id, sgk.ogrNo, sgk.SGKGiris, sgk.SGKCikis };

        GridView1.DataSource = getirSGKGirisCikis.ToList();
        GridView1.DataBind();
    }
    protected void ddlOgr_SelectedIndexChanged(object sender, EventArgs e)
    {
        guncelle();


    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int sgkId = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);




        TurnaEntities turna = new TurnaEntities();

        SGKGirisCikis sgkSil = turna.SGKGirisCikis.First(n => n.id == sgkId);

        turna.SGKGirisCikis.DeleteObject(sgkSil);

        turna.SaveChanges();

        guncelle();


    }
}