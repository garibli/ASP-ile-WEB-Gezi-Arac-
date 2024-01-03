using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_BirimListele : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.




        TurnaEntities turna = new TurnaEntities();


        var birim = turna.tblBirimler.OrderBy(n => n.adi);
        DtListBirim.DataSource = birim.ToList();
        DtListBirim.DataBind();

        
    }
}