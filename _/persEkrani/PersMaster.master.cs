using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class persEkrani_PersMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || (Session["yetkiID"].ToString() != "1" && Session["yetkiID"].ToString() != "2"))
            Response.Redirect("../Default.aspx");
        lblAdSoyad.Text = Session["ad"].ToString() + " " + Session["soyad"].ToString();
        lblMailAdresi.Text = Session["Mail"].ToString();
    }
    
    protected void ImgCikis_Click1(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Default.aspx");
    }

    protected void btnCikis_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Default.aspx");
    }
}
