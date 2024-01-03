using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class persEkrani_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        VeriIslemleri veri = new VeriIslemleri();

          
        if (Session["Mail"] == null || (Session["yetkiID"].ToString() != "1" && Session["yetkiID"].ToString() != "2") )
            Response.Redirect("../Default.aspx");

        //if (Session["Mail"] != null)
        //{

        //    if (veri.persGiris(Session["Mail"].ToString(), Session["yetkiID"].ToString()))
        //        Response.Redirect("../Default.aspx");
        //}
        //else
        //{
        //        Response.Redirect("../Default.aspx");
        //}
       
    }
}