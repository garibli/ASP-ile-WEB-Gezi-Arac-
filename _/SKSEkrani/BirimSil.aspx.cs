using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_SilmeIslemleri_BirimSil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.


       
        TurnaEntities turna = new TurnaEntities();


        var birimGetir = from birim in turna.tblBirimler
                         orderby birim.adi ascending
                         select new { birim.id, birim.adi, birim.BirimTuru, birim.UstKontenjan };

        GridViewBirimler.DataSource = birimGetir.ToList();
        GridViewBirimler.DataBind();
    }
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        int birimID = Convert.ToInt16(GridViewBirimler.SelectedRow.Cells[1].Text);
        
        TurnaEntities turna = new TurnaEntities();

        turna.birimSil(birimID);

       
        var birimGetir = from birim in turna.tblBirimler
                         orderby birim.adi ascending
                         select new { birim.id, birim.adi, birim.BirimTuru, birim.UstKontenjan };

        GridViewBirimler.DataSource = birimGetir.ToList();
        GridViewBirimler.DataBind();

    }
}