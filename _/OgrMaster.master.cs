using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class ogrEkrani_OgrMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
      

     //   lblBilgi.Text = Session["ad"].ToString() + " " + Session["soyad"].ToString();
    }
    protected void ImgCikis_Click(object sender, ImageClickEventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../Default.aspx");
    }
}
