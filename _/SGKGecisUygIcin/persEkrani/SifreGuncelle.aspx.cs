using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class persEkrani_SifreGuncelle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || (Session["yetkiID"].ToString() != "1" && Session["yetkiID"].ToString() != "2"))
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

        }
    }
}