using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_BirimGuncelle : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
        var birimGetir = from birim in turna.tblBirimler
                         orderby birim.adi ascending
                         select new { birim.id, birim.adi, birim.BirimTuru, birim.UstKontenjan };

        dtListBirimTablo.DataSource = birimGetir.ToList();
        dtListBirimTablo.DataBind();
        
    }
    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        if (txtBirimID.Text != "")
        {
            TurnaEntities turna = new TurnaEntities();
            int birimID = Convert.ToInt16(txtBirimID.Text);
            tblBirimler birimGuncelle = turna.tblBirimler.First(u => u.id == birimID );

            birimGuncelle.adi = txtBirimAdi.Text;
            birimGuncelle.BirimTuru = ddlBirimTuru.SelectedValue;
            turna.SaveChanges();
            lblBilgi.Text = birimID.ToString() + " id 'ye sahip işlem gerçekleştirildi.";
            var birimGetir = from birim in turna.tblBirimler
                             orderby birim.adi ascending
                             select new { birim.id, birim.adi, birim.BirimTuru, birim.UstKontenjan };

            dtListBirimTablo.DataSource = birimGetir.ToList();
            dtListBirimTablo.DataBind();

        }
        else
        {
            lblBilgi.Text = "Öncelikle aşağıdan güncellenecek birimin seçilmesi gerekmektedir.";
        }
    }
    protected void dtListBirimTablo_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int birimId = int.Parse(e.CommandArgument.ToString());
        var birimBilgiGetir = (from birim in turna.tblBirimler where birim.id == birimId select new { birim.id, birim.adi, birim.BirimTuru }).FirstOrDefault();
        txtBirimAdi.Text = birimBilgiGetir.adi.TrimEnd(' ');
        txtBirimID.Text = birimBilgiGetir.id.ToString();
        ddlBirimTuru.SelectedValue = birimBilgiGetir.BirimTuru;
        
    }
}