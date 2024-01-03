using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_Ekleme_İşlemleri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.



    }
    protected void btnPersEkle_Click(object sender, EventArgs e)
    {
        Response.Redirect("./personelIslem.aspx");
    }
    protected void btnBirimEkle_Click(object sender, EventArgs e)
    {
        Response.Redirect("./BirimEkle.aspx");
    }
    protected void btnBolumEkle_Click(object sender, EventArgs e)
    {
        Response.Redirect("./AltBolumEkle.aspx");
    }
}