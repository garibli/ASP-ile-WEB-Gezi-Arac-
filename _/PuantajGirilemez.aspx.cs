using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class PuantajGirilemez : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Session["Mail"] == null || Session["yetkiID"].ToString() == null)
             Response.Redirect("./Default.aspx");
        
    }
    protected void btntamam_Click(object sender, EventArgs e)
    {
        string mail = Session["Mail"].ToString();
        string yetki = Session["yetkiID"].ToString();

        if (Session["Mail"] != null && Session["yetkiID"].ToString() == "0")
        {
            Response.Redirect("./SKSEkrani/Default.aspx");
        }
        if (Session["Mail"] != null && Session["yetkiID"].ToString() != "0")
        {
            Response.Redirect("./persEkrani/Default.aspx");
        }
       
            Response.Redirect("./Default.aspx");
       

    }
}