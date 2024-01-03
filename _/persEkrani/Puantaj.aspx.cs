using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_Puantaj : System.Web.UI.Page
{

    VeriIslemleri veri = new VeriIslemleri();
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || (Session["yetkiID"].ToString() != "1" && Session["yetkiID"].ToString() != "2"))
        {
            Session.Abandon();
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.
        }
        
        if (!IsPostBack)
        {



            veri.ddlVeriCekBirimler(ddlIlgiliBolum);
            //veri.ddlVeriCekParamBirimler(ddlIlgiliBirim, "Çerezden gelicek id"); eğerki birimler ilan ekliycekse

            ddlYil.Items.Add(new ListItem(DateTime.Now.Year.ToString(), DateTime.Now.Year.ToString()));
            ddlYil.Items.Add(new ListItem((DateTime.Now.AddYears(-1)).Year.ToString(), (DateTime.Now.AddYears(-1)).Year.ToString()));

            ddlAy.SelectedValue = DateTime.Now.AddMonths(-1).Month.ToString();//ddlAy.SelectedValue = DateTime.Now.Month.ToString();//12.ayda eklenecek
            ddlYil.SelectedIndex = 1;

            ddlIlgiliBolum.SelectedValue = Session["birimID"].ToString();

        }
        try
        {
            
            int birimID =Convert.ToInt16(Session["birimId"].ToString());
            var hazirlayan = from hazirlayanBUL in turna.tblHazirlayanOnaylayan where hazirlayanBUL.hazirlayanOnaylayan == "HAZIRLAYAN" && hazirlayanBUL.birim == birimID select new { hazirlayanBUL.id, hazirlayanBUL.ad, hazirlayanBUL.soyad };
            foreach (var item in hazirlayan)
	            {
		             ddlistHazirlayan.Items.Add(new ListItem(item.ad.ToString()+" "+item.soyad.ToString(),item.id.ToString()));
	            }
            var onaylayan = from onaylayanBUL in turna.tblHazirlayanOnaylayan where onaylayanBUL.hazirlayanOnaylayan == "ONAYLAYAN" && onaylayanBUL.birim == birimID select new { onaylayanBUL.id, onaylayanBUL.ad, onaylayanBUL.soyad };
            
            foreach (var item in onaylayan)
                {
                    ddlistOnaylayan.Items.Add(new ListItem(item.ad.ToString() + " " + item.soyad.ToString(), item.id.ToString()));
                }
            
        }
        catch { }

    }

    public void messagebox(string mesaj)
    {
        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");
    }
    protected void btnOlustur_Click(object sender, EventArgs e)
    {
        try
        {
            int hazirlayanID = Convert.ToInt16(ddlistHazirlayan.SelectedItem.Value);
            int onaylayanID = Convert.ToInt16(ddlistOnaylayan.SelectedItem.Value);
            Session["hazirlayan"] = hazirlayanID.ToString();
            Session["onaylayan"] = onaylayanID.ToString();
        }
        catch { }
            Session["puantajYil"] = ddlYil.SelectedValue;
      
        
            Session["puantajAy"] = ddlAy.SelectedValue;
       


        Session["puantajBirim"] = ddlIlgiliBolum.SelectedValue;


        if (Session["puantajAy"] == null || Session["puantajYil"] == null)
        {
            lblBilgi.Text = "Birim ve/veya ay ve/veya yıl Seçiniz...";
        }
        else
        {
            
            Response.Redirect("./PuantajCikti.aspx");
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

    protected void btnBordroList_Click(object sender, EventArgs e)
    {
       
        Session["bordroYil"] = ddlYil.SelectedValue;


        Session["bordroAy"] = ddlAy.SelectedValue;



        Session["puantajBirim"] = ddlIlgiliBolum.SelectedValue;



            Response.Redirect("~/CiktiIslemleri/BirimBordro.aspx");
        
    }
}