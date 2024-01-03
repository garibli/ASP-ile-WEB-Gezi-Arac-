using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_BirimOkulEkle : System.Web.UI.Page
{
    public void birimDoldurGrid()
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.


        TurnaEntities turna = new TurnaEntities();


        var birimGetir = from birim in turna.tblBirimler
                         orderby birim.adi ascending
                         select new { birim.id, birim.adi, birim.BirimTuru, birim.UstKontenjan };

        dtListBirim.DataSource = birimGetir.ToList();
        dtListBirim.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
        }


        birimDoldurGrid();

    }
    protected void btnOlustur_Click(object sender, EventArgs e)
    {

        try
        {
            if (ddlBirimTuru.SelectedValue != "-1")
            {

                TurnaEntities turna = new TurnaEntities();
                int kontenjan = 0, ekKontenjan = 0;
                if (txtUstKontenjan.Text != "")
                    kontenjan = Convert.ToInt16(txtUstKontenjan.Text);
                if(txtEkKontenjan.Text != "")
                    ekKontenjan = Convert.ToInt16(txtEkKontenjan.Text);
                turna.BirimEkle(txtBirim.Text, kontenjan + ekKontenjan, ddlBirimTuru.SelectedValue, 0, 0, 0, 0, 0, 0, 0, 0);
                birimDoldurGrid();

                txtBirim.Text = "";
                txtUstKontenjan.Text = "";
                ddlBirimTuru.SelectedValue = "-1";
                lblBilgi.Text = "";
            }


            else
            {
                 
                 lblBilgi.Text = "* Alanlarını Doldurunuz...";
            }
       }
        catch (Exception)
        {

            lblBilgi.Text = "Girdiğiniz verileri kontrol ediniz...";
        }
    }
}