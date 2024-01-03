using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_GSSDegistir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

       

        if (!IsPostBack)
        {
            VeriIslemleri veri = new VeriIslemleri();
            veri.ddlVeriCekBirimler(ddlIlgiliBolum); 
        }
        
        

    }
    protected void btnGuncelle_Click(object sender, EventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();

        if (ddlCalisan.SelectedValue != "-1" && ddlIlgiliBolum.SelectedValue != "-1" && ddlGSS.SelectedValue != "-1")
        {
            turna.ogrGSS2243Guncelle1(ddlCalisan.SelectedValue, ddlGSS.SelectedValue);
            lblBilgi.Text = "GSS güncelemesi başarıyla gerçekleşti...";
        }
        else
            lblBilgi.Text = "Gerekli alanları doldurunuz...";
        
    }
    protected void ddlIlgiliBolum_SelectedIndexChanged(object sender, EventArgs e)
    {
       //Çalışanları getir.

        VeriIslemleri veri = new VeriIslemleri();

        veri.ddlVeriCekParamBirimCalisanGetirIDogrNo(ddlCalisan, Convert.ToInt16(ddlIlgiliBolum.SelectedValue));

    }
}