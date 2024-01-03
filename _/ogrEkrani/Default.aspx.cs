using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class ogrEkrani_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "ogr")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
        {
            IsKurallari isK = new IsKurallari();
            if (!isK.anketGuncelmi(Session["Mail"].ToString()))
                Response.Redirect("./Anket.aspx");//anket cevapları güncel değilse.
        }

        lblAd.Text = Session["ad"].ToString() + " " + Session["soyad"].ToString();
        lblogrNo.Text = Session["ogrNo"].ToString();
        lblMail.Text = Session["Mail"].ToString();
        if (Session["calistigiYer"] != null)
        lblCalisBirim.Text ="Çalıştığı Birim : " + Session["calistigiYer"].ToString();
        if (Session["calistigiAltBirim"] != null)
        lblcalismaSekli.Text ="Çalışma Şekli : " + Session["calismaSekli"].ToString();
       

    }
}