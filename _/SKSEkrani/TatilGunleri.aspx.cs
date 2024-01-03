using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_TatilGunleri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

        TurnaEntities turna = new TurnaEntities();

        var resmiTatilQuery = turna.tblResmiTatilGunleri;

        GridView1.DataSource = resmiTatilQuery.ToList().OrderBy(n => n.resmiTatil);

        GridView1.DataBind();



    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int ID = Convert.ToInt16(GridView1.SelectedRow.Cells[1].Text);

        TurnaEntities turna = new TurnaEntities();


        tblResmiTatilGunleri silTatilGunu = turna.tblResmiTatilGunleri.First(n => n.id == ID);

        turna.tblResmiTatilGunleri.DeleteObject(silTatilGunu);

        turna.SaveChanges();


        var resmiTatilQuery = turna.tblResmiTatilGunleri;

        GridView1.DataSource = resmiTatilQuery.ToList().OrderBy(n => n.resmiTatil);

        GridView1.DataBind();


    }
    protected void btnGir_Click(object sender, EventArgs e)
    {

        TurnaEntities turna = new TurnaEntities();


        tblResmiTatilGunleri ekleTatilGunu = new tblResmiTatilGunleri() { resmiTatil = Calendar1.SelectedDate };

        turna.tblResmiTatilGunleri.AddObject(ekleTatilGunu);

        turna.SaveChanges();


        var resmiTatilQuery = turna.tblResmiTatilGunleri;

        GridView1.DataSource = resmiTatilQuery.ToList().OrderBy(n => n.resmiTatil);

        GridView1.DataBind();


    }
}