using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_Sozlesme : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

        }
        if (!IsPostBack)
        {
            VeriIslemleri veri = new VeriIslemleri();

            veri.ddlVeriCekFakYukOkul(ddlOkul, "-1");
        }
      

        
    }
    protected void btnGetir_Click(object sender, EventArgs e)
    {
        if (ddlOgrenci.SelectedValue != "-1")
        {
            Session["sozlesmeOgrNo"] = ddlOgrenci.SelectedValue;


            Response.Redirect("SozlesmeGetir.aspx");


        }
        
    }
    protected void ddlOkul_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlOgrenci.Items.Clear();

        TurnaEntities turna = new TurnaEntities();

        int okulID = Convert.ToInt16(ddlOkul.SelectedValue);


        ddlOgrenci.Items.Add(new ListItem("SEÇİNİZ", "-1",true));
      


        var ogrGetir = from ogr in turna.tblOgrenci
                       join calismaYer in turna.tblCalismaYerleri
                       on ogr.ogrNo equals calismaYer.ogrNo
                       where calismaYer.calisacagiCalistigiYer == okulID
                       orderby ogr.ad ascending
                       select new { ogr.ogrNo,ogr.ad,ogr.soyad };


        foreach (var item in ogrGetir)
        {
            ddlOgrenci.Items.Add(new ListItem( item.ad + " " + item.soyad+" " + item.ogrNo + " " , item.ogrNo));
        }


    }
}