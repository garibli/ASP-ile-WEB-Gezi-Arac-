using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;

public partial class persEkrani_kontenjanTakip : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        int BirimID=Convert.ToInt16(Session["birimId"]);
        var takipKontenjan = from kontenjanTalep in turna.tblTalepKontenjan
                             join kontenjanBilgisi in turna.tblBolumler on kontenjanTalep.bolumID equals kontenjanBilgisi.id
                             where kontenjanBilgisi.birimID == BirimID
                             select new {AltBirim= kontenjanBilgisi.adi, AkademikTalep=kontenjanTalep.akademikKontenjan, İdariTalep= kontenjanTalep.idariKontenjan, YanitAkademik= kontenjanBilgisi.AkademiKon, YanitIdari= kontenjanBilgisi.IdariKon };
        dtLKontenjan.DataSource = takipKontenjan.ToList();
        dtLKontenjan.DataBind();

    }
}