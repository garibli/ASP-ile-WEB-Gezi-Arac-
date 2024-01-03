using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_BilgiGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.


    }
    protected void btnGSSGuncelle_Click(object sender, EventArgs e)
    {
        Response.Redirect("./GSSDegistir.aspx");
    }
    protected void btnBirimGuncelle_Click(object sender, EventArgs e)
    {
        Response.Redirect("./BirimGuncelle.aspx");
    }
    protected void btnAltBolumGuncelleme_Click(object sender, EventArgs e)
    {
        Response.Redirect("./AltBolumGuncelle.aspx");
    }
    protected void btnCalisanGuncelle_Click(object sender, EventArgs e)
    {
        Response.Redirect("./CalisanDuzenle.aspx");
    }
    protected void btnHesapNo_Click(object sender, EventArgs e)
    {
        Response.Redirect("./HesapNoGuncelle.aspx");
    }
    protected void btnSGKGirisGuncelle_Click(object sender, EventArgs e)
    {
        Response.Redirect("./SGKGirisGuncelle.aspx");
    }
    protected void btnSGKCikisGuncelle_Click(object sender, EventArgs e)
    {
        Response.Redirect("./SGKCikisGuncelle.aspx");
    }
    protected void btnSGKCikisGuncelle0_Click(object sender, EventArgs e)
    {
        Response.Redirect("./SGKCikisNull.aspx");
    }
}