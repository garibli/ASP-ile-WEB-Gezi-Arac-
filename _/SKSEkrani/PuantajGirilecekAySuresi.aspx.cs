using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_PuantajGirilecekAySuresi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.




        TurnaEntities turna = new TurnaEntities();

        if (!IsPostBack)
        {


            var getir = from pSure in turna.tblPuantajGirmeSuresi
                        where pSure.id == 1
                        select new { pSure.puantajSuresi };

            foreach (var item in getir)
            {
                txtGunSayisi.Text = item.puantajSuresi.ToString();
            }
        }
    }
    protected void btnGir_Click(object sender, EventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();
        try
        {
            turna.puantajGirmeSuresi(Convert.ToInt16(txtGunSayisi.Text));
            lblBilgi.Text = "Güncelleme Başarıyla Gerçekleşti.";
        }
        catch (Exception)
        {

            lblBilgi.Text = "Hata oluştu işleminiz gerçekleşmedi.";
        }
       
    }
}