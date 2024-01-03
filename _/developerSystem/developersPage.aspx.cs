using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;

public partial class developersPage : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["developer"] == null) 
        {
            Response.Redirect("devPageLogin.aspx");
        }
        try
        {
            var isTakip = from istakipbilgi in turna.tblIsTakip where istakipbilgi.kim=="" select new { istakipbilgi.isAcillik, istakipbilgi.isBaslik, istakipbilgi.isIcerik, istakipbilgi.kontrol, istakipbilgi.tarih, istakipbilgi.id, };
            dtListAtanmamis.DataSource = isTakip.ToList();
            dtListAtanmamis.DataBind();
            
            if (Session["developer"].ToString() == "ismail")
            {
                try
                {
                    var isTakip1 = from istakipbilgi in turna.tblIsTakip where istakipbilgi.kim == "ismail" select new { istakipbilgi.isAcillik, istakipbilgi.isBaslik, istakipbilgi.isIcerik, istakipbilgi.kontrol, istakipbilgi.tarih, istakipbilgi.id, };
                    dtlistAtananIsler.DataSource = isTakip1.ToList();
                    dtlistAtananIsler.DataBind();
                }
                catch { }
            }
            else if (Session["developer"].ToString() == "melih")
            {
                try
                {
                    var isTakip2 = from istakipbilgi in turna.tblIsTakip where istakipbilgi.kim == "melih" select new { istakipbilgi.isAcillik, istakipbilgi.isBaslik, istakipbilgi.isIcerik, istakipbilgi.kontrol, istakipbilgi.tarih, istakipbilgi.id, };
                    dtlistAtananIsler.DataSource = isTakip2.ToList();
                    dtlistAtananIsler.DataBind();
                }
                catch { }
            }
            else
            {

            }

        }
        catch { }
    }
    
    protected void dtListAtanmamis_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        tblIsTakip guncelle = turna.tblIsTakip.First(x => x.id == id);
        guncelle.kim = Session["developer"].ToString();
        guncelle.kontrol = "İŞE BAŞLANDI";
        turna.SaveChanges();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    protected void dtlistAtananIsler_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        tblIsTakip guncelle = turna.tblIsTakip.First(x => x.id == id);
        guncelle.kim = "";
        guncelle.kontrol = "İŞE BAŞLANMADI";
        turna.SaveChanges();
        Page.Response.Redirect(Page.Request.Url.ToString(),true);
    }
}