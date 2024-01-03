using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_PersonelListele : System.Web.UI.Page
{

    public void gridViewDoldur() 
    {

        TurnaEntities turna = new TurnaEntities();

        var perGetirQuery = from pers in turna.tblPersonel
                            join birim in turna.tblBirimler
                            on pers.birimId equals birim.id
                            orderby birim.adi, pers.adi ascending
                            select new { pers.persTC, pers.adi, pers.soyad, pers.mail, pers.dahiliNo, birimAdi = birim.adi, pers.yetkiID };

        DtListPersonel.DataSource = perGetirQuery.ToList();
        DtListPersonel.DataBind();
       

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