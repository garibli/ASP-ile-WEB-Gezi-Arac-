using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblBilgi.Text = Session["ad"].ToString() + " " + Session["soyad"].ToString();
    }
   
    protected void btnCikis_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Default.aspx"); 
    }
}
