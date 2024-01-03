using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_isTakip : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            var isTakip = from istakipbilgi in turna.tblIsTakip select new { istakipbilgi.isAcillik, istakipbilgi.isBaslik, istakipbilgi.isIcerik, istakipbilgi.kontrol, istakipbilgi.tarih, istakipbilgi.id, };
            dtListIsTakip.DataSource = isTakip.ToList();
            dtListIsTakip.DataBind();
        }
        catch { }

    }
    protected void btnKaydet_Click(object sender, EventArgs e)
    {
        string isBaslik = txtIsBasligi.Text;
        string isIcerik = txtIsIcerik.Text;
        string kontrol = "İŞE BAŞLANMADI";
        DateTime tarih = DateTime.Now;
        string acil = "";
        if (ddrAcillik.SelectedValue == "1") 
        {
            acil = "ACİL";
        }
        else if (ddrAcillik.SelectedValue == "2")
        {
            acil = "ORTA ACİL";
        }
        else
        {
            acil = "ACİL DEĞİL";
        }
        tblIsTakip isTakipAdd = new tblIsTakip
        {
            isBaslik = isBaslik,
            isIcerik = isIcerik,
            isAcillik = acil,
            kontrol = kontrol,
            tarih = tarih,
            kim=""
        };
        turna.tblIsTakip.AddObject(isTakipAdd);
        turna.SaveChanges();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);

    }

    protected void dtListIsTakip_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int id = Convert.ToInt16(e.CommandArgument);
        tblIsTakip isSil = turna.tblIsTakip.First(x => x.id == id);
        turna.tblIsTakip.DeleteObject(isSil);
        turna.SaveChanges();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);

    }
}