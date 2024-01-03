using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_IlanListele : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

        if (!IsPostBack)
        {

            VeriIslemleri veri = new VeriIslemleri();

            veri.ddlVeriCekBirimler(ddlBirimler);
        }


    }
    protected void ddlBirimler_SelectedIndexChanged(object sender, EventArgs e)
    {

        
        

        TurnaEntities turna = new TurnaEntities();
        int birimID = Convert.ToInt16(ddlBirimler.SelectedValue);
        if (birimID > 0)
        {
            var getir = from ilan in turna.tblIlanlar

                        where ilan.birimID == birimID
                        select new { ilan.eklemeZamani,ilan.isBasligi,ilan.isMetni,ilan.isTanimi,ilan.kontenjan};

            dtListilan.DataSource = getir.ToList();
            dtListilan.DataBind();


        }
    }
}