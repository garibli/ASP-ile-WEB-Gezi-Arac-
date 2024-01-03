using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;

public partial class komisyon_komisyoncik : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void komisyoncik_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt16(Session["persID"]);
        tblPersonel ilanAktifleştir = turna.tblPersonel.First(k => k.id ==id );
        ilanAktifleştir.yetkiID = 2;
        turna.SaveChanges();
        Session.Abandon();
        Response.Redirect("../Default.aspx");
       
    }
}