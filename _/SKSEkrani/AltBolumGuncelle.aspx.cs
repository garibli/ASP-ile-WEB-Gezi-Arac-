using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_AltBolumGuncelle : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

        

        if (!IsPostBack)
        {

        VeriIslemleri veri = new VeriIslemleri();

        veri.ddlVeriCekBirimler(ddlBirim);

        TurnaEntities turna = new TurnaEntities();

        var bolumGetir = from birimler in turna.tblBirimler
                         join bolumler in turna.tblBolumler
                         on birimler.id equals bolumler.birimID
                         orderby birimler.adi ascending, bolumler.adi ascending
                         select new {düzenle=bolumler.id, bolumID = bolumler.id, bolumAdi = bolumler.adi, bolumler.ogrenimTuru,bolumler.bolumTuru, Birimi = birimler.adi };

        

        GridViewBirimler.DataSource = bolumGetir.ToList();
        GridViewBirimler.DataBind();


        }

    }
    public void gridviewGuncelle() 
    {
        TurnaEntities turna = new TurnaEntities();
        if (ddlBirim.SelectedValue != "-1")
        {
            int birimID = Convert.ToInt16(ddlBirim.SelectedValue);

            var bolumGetir = from birimler in turna.tblBirimler
                             join bolumler in turna.tblBolumler
                             on birimler.id equals bolumler.birimID
                             orderby birimler.adi ascending, bolumler.adi ascending
                             where birimler.id == birimID
                             select new { bolumID = bolumler.id, bolumAdi = bolumler.adi, bolumler.ogrenimTuru, bolumler.bolumTuru, Birimi = birimler.adi };


            GridViewBirimler.DataSource = bolumGetir.ToList();
            GridViewBirimler.DataBind();
        }
        else
        {
            var bolumGetir = from birimler in turna.tblBirimler
                             join bolumler in turna.tblBolumler
                             on birimler.id equals bolumler.birimID
                             orderby birimler.adi ascending, bolumler.adi ascending
                             select new { bolumID = bolumler.id, bolumAdi = bolumler.adi, bolumler.ogrenimTuru, bolumler.bolumTuru, Birimi = birimler.adi };


            GridViewBirimler.DataSource = bolumGetir.ToList();
            GridViewBirimler.DataBind();
        }
    }
    protected void ddlBolum_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridviewGuncelle();
    }
    protected void btnGuncelle_Click(object sender, EventArgs e)
    {

        if (txtBirimID.Text != "")
        {
            TurnaEntities turna = new TurnaEntities();
            int birimID = Convert.ToInt16(txtBirimID.Text);
            tblBolumler altBolumGuncelle = turna.tblBolumler.First(u => u.id == birimID);

            altBolumGuncelle.adi = txtBirimAdi.Text;
            altBolumGuncelle.bolumTuru = ddlBolumTuru.SelectedValue;
            altBolumGuncelle.ogrenimTuru = Convert.ToInt16(ddlOgrenimTuru.SelectedValue);


           // turna.tblBolumler.Add(altBolumGuncelle);

            turna.SaveChanges();





            gridviewGuncelle();

            lblBilgi.Text = birimID.ToString() + " id 'ye sahip işlem gerçekleştirildi.";

        }
        else
        {
            lblBilgi.Text = "Öncelikle aşağıdan güncellenecek birimin seçilmesi gerekmektedir.";
        }


       
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtBirimID.Text = GridViewBirimler.SelectedRow.Cells[1].Text.ToString();
        string birimAdi = HttpUtility.HtmlDecode(GridViewBirimler.SelectedRow.Cells[2].Text.ToString());
        txtBirimAdi.Text = birimAdi.TrimEnd(' ');
        ddlOgrenimTuru.SelectedValue = GridViewBirimler.SelectedRow.Cells[3].Text.ToString();
        ddlBolumTuru.SelectedValue = GridViewBirimler.SelectedRow.Cells[4].Text.ToString();


       
    }
    
}