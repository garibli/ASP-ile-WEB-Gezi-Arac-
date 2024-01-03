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
        sayfa2.Visible = false;
        try
        {
            var isTakip = from istakipbilgi in turna.tblIsTakip where istakipbilgi.kim=="" select new { istakipbilgi.isAcillik, istakipbilgi.isBaslik, istakipbilgi.isIcerik, istakipbilgi.kontrol, istakipbilgi.tarih, istakipbilgi.id, };
            dtListAtanmamis.DataSource = isTakip.ToList();
            dtListAtanmamis.DataBind();
        }
        catch { }
    }
    protected void btnGir_Click(object sender, EventArgs e)
    {
        if (txtSifre.Text == "ismail")
        {
            sayfa1.Visible = false;
            sayfa2.Visible = true;
            Session["developer"] = "ismail";
            try
            {
                var isTakip = from istakipbilgi in turna.tblIsTakip where istakipbilgi.kim == "ismail" select new { istakipbilgi.isAcillik, istakipbilgi.isBaslik, istakipbilgi.isIcerik, istakipbilgi.kontrol, istakipbilgi.tarih, istakipbilgi.id, };
                dtlistAtananIsler.DataSource = isTakip.ToList();
                dtlistAtananIsler.DataBind();
            }
            catch { }
        }
        else if (txtSifre.Text == "melih")
        {
            sayfa1.Visible = false;
            sayfa2.Visible = true;
            Session["developer"] = "melih";
            try
            {
                var isTakip = from istakipbilgi in turna.tblIsTakip where istakipbilgi.kim == "melih" select new { istakipbilgi.isAcillik, istakipbilgi.isBaslik, istakipbilgi.isIcerik, istakipbilgi.kontrol, istakipbilgi.tarih, istakipbilgi.id, };
                dtlistAtananIsler.DataSource = isTakip.ToList();
                dtlistAtananIsler.DataBind();
            }
            catch { }
        }
        else 
        {
            
        }
    }
    protected void dtListAtanmamis_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        tblIsTakip guncelle = turna.tblIsTakip.First(x => x.id == id);
        guncelle.kim = Session["developer"].ToString();
        guncelle.kontrol = "İŞE BAŞLANDI";
        turna.SaveChanges();
    }
    protected void dtlistAtananIsler_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        tblIsTakip guncelle = turna.tblIsTakip.First(x => x.id == id);
        guncelle.kim = "";
        guncelle.kontrol = "İŞE BAŞLANMADI";
        turna.SaveChanges();
    }
}