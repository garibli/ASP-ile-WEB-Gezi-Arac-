using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class KisitliYetki : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void btnGonder_Click(object sender, EventArgs e)
    {
        //if (txtSifre.Text == "19x1z4")
        //{
        //    Session["KisitliYetki"] = "1";
        //    Response.Redirect("./Default.aspx");
        //}
        //else
        //{
        //    lblBilgi.Text = "Yanlış Şifre";
        //}
    }
}