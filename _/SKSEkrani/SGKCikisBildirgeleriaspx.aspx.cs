using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;

public partial class SKSEkrani_SGKCikisBildirgeleriaspx : System.Web.UI.Page
{
    VeriIslemleri veri = new VeriIslemleri();
    TurnaEntities turna = new TurnaEntities();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
        }

        if (!IsPostBack)
        {

            veri.ddlVeriCekBirimler(ddlIlgiliBolum);
            //veri.ddlVeriCekParamBirimler(ddlIlgiliBirim, "Çerezden gelicek id"); eğerki birimler ilan ekliycekse

            ddlAy.Items.Add(new ListItem(DateTime.Now.Month.ToString(), DateTime.Now.Month.ToString()));
            ddlAy.Items.Add(new ListItem((DateTime.Now.AddMonths(-1)).Month.ToString(), (DateTime.Now.AddMonths(-1)).Month.ToString()));
            ddlAy.Items.Add(new ListItem((DateTime.Now.AddMonths(-2)).Month.ToString(), (DateTime.Now.AddMonths(-2)).Month.ToString()));

            ddlYil.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
            ddlYil.Items.Add(new ListItem((DateTime.Now.AddYears(-1)).Year.ToString(), (DateTime.Now.AddYears(-1)).Year.ToString()));

            ddlAy.SelectedIndex = 2;
            ddlYil.SelectedIndex = 1;


        }
    }
    protected void btnOlustur_Click(object sender, EventArgs e)
    {

        Session["puantajYil"] = ddlYil.SelectedValue;


        Session["puantajAy"] = ddlAy.SelectedValue;



        Session["puantajBirim"] = ddlIlgiliBolum.SelectedValue;


        if (Session["puantajAy"] == null || Session["puantajYil"] == null)
        {
            lblBilgi.Text = "Birim ve/veya ay ve/veya yıl Seçiniz...";
        }
        else
        {

            Response.Redirect("./SGKCikisBildirgeleriCiktisi.aspx");
        }
    }
    protected void ddlIlgiliBolum_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlAy_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void ddlYil_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
}