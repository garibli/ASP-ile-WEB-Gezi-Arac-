using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_SilmeIslemleri_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
    }

    protected void btnBirimSil_Click(object sender, EventArgs e)
    {
        Response.Redirect("./BirimSil.aspx");
    }
    protected void btnAltBirimSil_Click(object sender, EventArgs e)
    {
        Response.Redirect("./AltBirimSil.aspx");
    }
    protected void btnCalisanSil_Click(object sender, EventArgs e)
    {
        Response.Redirect("./CalisanDuzenle.aspx");
    }
    protected void btnPersSil_Click(object sender, EventArgs e)
    {
        Response.Redirect("./personelDuzenle.aspx");
    }
    protected void btnPersSil0_Click(object sender, EventArgs e)
    {
        Response.Redirect("./SGKGecmisi.aspx");
    }
    protected void btnPersSil1_Click(object sender, EventArgs e)
    {
        Response.Redirect("./CalismaYerleri.aspx");
    }
}