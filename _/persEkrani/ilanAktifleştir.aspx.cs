using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using skscalismaModel;

public partial class persEkrani_ilanAktifleştir : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }
        aktifleştirmeDiv.Visible = false;
          
        if (Session["Mail"] == null || (Session["yetkiID"].ToString() != "1" && Session["yetkiID"].ToString() != "2") )
            Response.Redirect("../Default.aspx");

        
        int birimId = Convert.ToInt16(Session["birimId"]);

        var gecmisIlanGetir = from gIlan in turna.tblIlanlar where (gIlan.birimID==birimId && gIlan.bitisSuresi<DateTime.Now) select new { gIlan.isBasligi, gIlan.isTanimi, gIlan.bitisSuresi, gIlan.id };
        dlGecmisListe.DataSource = gecmisIlanGetir.ToList();
        dlGecmisListe.DataBind();
        //gecmis ilanlari listeler.....

    }
   

    public void messagebox(string mesaj)
    {


        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }


    protected void dlGecmisListe_ItemCommand(object source, DataListCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "aktiflestir":
                {
                    aktifleştirmeDiv.Visible = true;
                    ustConte.Visible = false;
                    int ilanAktif = int.Parse(e.CommandArgument.ToString());
                    lblID.Text = ilanAktif.ToString();
                    
                 break;
                }
            default :
                messagebox("sistemde hata olustu");
                break;
            

        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtTarihGonder.Text = Calendar1.SelectedDate.ToString();
    }
    protected void BtnAktif_Click(object sender, EventArgs e)
    {
        var ilanID=Convert.ToInt16(lblID.Text);
        tblIlanlar ilanAktifleştir = turna.tblIlanlar.First(k => k.id ==ilanID );
        ilanAktifleştir.sksOnay = "0";
        ilanAktifleştir.bitisSuresi = Convert.ToDateTime(txtTarihGonder.Text);
        turna.SaveChanges();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
}