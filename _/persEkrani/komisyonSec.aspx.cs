using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class persEkrani_komisyonSec : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        int birimID=Convert.ToInt16(Session["birimId"]);
        var personelGetir = from pers in turna.tblPersonel where( pers.birimId == birimID&&(pers.yetkiID==1 || pers.yetkiID==2 ) ) select new { Ad = pers.adi, Soyad = pers.soyad, Mail = pers.mail, id = pers.id };
        ddlKomisyonSec.DataSource = personelGetir.ToList();
        ddlKomisyonSec.DataBind();
    }
    protected void ddlKomisyonSec_ItemCommand(object source, DataListCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "komisyonSec":
                {
                    int komisyonSecGetirID = int.Parse(e.CommandArgument.ToString());
                    tblPersonel ilanAktifleştir = turna.tblPersonel.First(k => k.id == komisyonSecGetirID);
                    ilanAktifleştir.yetkiID = 3;
                    turna.SaveChanges();
                    messagebox("komisyon üyesi secildi");
                    
                    if (Session["persID"].ToString() == komisyonSecGetirID.ToString())
                    {
                        Session.Abandon();
                        Response.Redirect("../Default.aspx");
                    }
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                 break;
                }
            default :
                messagebox("sistemde hata olustu");
                break;
            

        }
    }
    public void messagebox(string mesaj)
    {
        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");
  }
}