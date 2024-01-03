using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_Listele : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

    }
    protected void btnPersListele_Click(object sender, EventArgs e)
    {
        Response.Redirect("./PersonelListele.aspx");

    }
    protected void btnOgrListele_Click(object sender, EventArgs e)
    {
        Response.Redirect("./OgrListele.aspx");
    }
    protected void btnBirimListele_Click(object sender, EventArgs e)
    {
        Response.Redirect("./BirimListele.aspx");
        
    }
    protected void btnBolumListele_Click(object sender, EventArgs e)
    {
        Response.Redirect("./AltBolumListele.aspx");
    }
}