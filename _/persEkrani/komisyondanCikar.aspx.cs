using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class persEkrani_komisyondanCikar : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();

    protected void Page_Load(object sender, EventArgs e)
    {

        int birimID = Convert.ToInt16(Session["birimId"]);
        var personelGetir = from pers in turna.tblPersonel where (pers.birimId == birimID && (pers.yetkiID ==3)) select new { Ad = pers.adi, Soyad = pers.soyad, Mail = pers.mail, id = pers.id };
        ddlKomisyonSec.DataSource = personelGetir.ToList();
        ddlKomisyonSec.DataBind();
    }
    protected void ddlKomisyonCikar_ItemCommand(object source, DataListCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "komisyoncikar":
                {
                    int komisyonSecGetirID = int.Parse(e.CommandArgument.ToString());
                    tblPersonel ilanAktifleştir = turna.tblPersonel.First(k => k.id == komisyonSecGetirID);
                    ilanAktifleştir.yetkiID = 2;
                    turna.SaveChanges();
                    messagebox("komisyon üyeliğinden cikar");
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    break;
                }
            default:
                messagebox("sistemde hata olustu");
                break;


        }
    }
    public void messagebox(string mesaj)
    {
        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");
    }
}