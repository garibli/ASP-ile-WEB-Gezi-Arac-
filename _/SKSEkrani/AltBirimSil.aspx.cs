using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_SilmeIslemleri_AltBirimSil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.




        TurnaEntities turna = new TurnaEntities();

        var bolumGetir = from birimler in turna.tblBirimler
                         join bolumler in turna.tblBolumler
                         on birimler.id equals bolumler.birimID
                         orderby birimler.adi ascending, bolumler.adi ascending
                         select new { bolumID = bolumler.id, bolumAdi = bolumler.adi, Birimi = birimler.adi };
       
        
        GridViewBirimler.DataSource = bolumGetir.ToList();
        GridViewBirimler.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        int bolumID = Convert.ToInt16(GridViewBirimler.SelectedRow.Cells[1].Text);

        TurnaEntities turna = new TurnaEntities();

        turna.bolumSil(bolumID);


        var bolumGetir = from birimler in turna.tblBirimler
                         join bolumler in turna.tblBolumler
                         on birimler.id equals bolumler.birimID
                         orderby birimler.adi ascending, bolumler.adi ascending
                         select new { bolumID = bolumler.id, bolumAdi = bolumler.adi, Birimi = birimler.adi };
       
        GridViewBirimler.DataSource = bolumGetir.ToList();
        GridViewBirimler.DataBind();
    }
}