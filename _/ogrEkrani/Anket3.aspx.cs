using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class ogrEkrani_Anket3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "ogr" || Session["ozelOgr"] == null)
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.


    }
}