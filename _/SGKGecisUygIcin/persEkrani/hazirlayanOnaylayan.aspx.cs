using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class persEkrani_hazirlayanOnaylayan : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        int birimId = Convert.ToInt16(Session["birimId"]);
        try
        {
            var dtlistHazirlayan = from hzOnay in turna.tblHazirlayanOnaylayan where hzOnay.birim==birimId select new { hzOnay.ad, hzOnay.soyad, hzOnay.unvan, hazirlayanOnaylayan = hzOnay.hazirlayanOnaylayan, hzOnay.id };
            DtlistIlan.DataSource = dtlistHazirlayan.ToList();
            DtlistIlan.DataBind();
        }
        catch { };
    }
   
    public void messagebox(string mesaj)
    {
        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");
    }
    protected void btnOnaylayanKayit_Click(object sender, EventArgs e)
    {
        if (ddListUnvan.SelectedItem.Value != "0")
        {
            string Ad = TxtAd.Text;
            string Soyad = txtSoyad.Text;
            string unvan = txtUnvan.Text;
            int onaylayanBirim = Convert.ToInt16(Session["birimID"]);
            int onaylayanBolum = Convert.ToInt16(Session["bolumID"]);
            string hazonay = ddListUnvan.SelectedItem.Value;
            tblHazirlayanOnaylayan hzOnaylayn = new tblHazirlayanOnaylayan
            {

                ad = Ad.ToString(),
                soyad = Soyad.ToString(),
                unvan = unvan.ToString(),
                birim = onaylayanBirim,
                bolum = onaylayanBolum,
                hazirlayanOnaylayan = hazonay.ToString()

            };
            turna.tblHazirlayanOnaylayan.AddObject(hzOnaylayn);
            turna.SaveChanges();
            txtUnvan.Text = "";
            txtSoyad.Text = "";
            TxtAd.Text = "";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);

        }
        else { messagebox("Lütfen Hazırlayan ya da Onaylayan Seçiniz"); }

    }
    protected void DtlistIlan_ItemCommand(object source, DataListCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "sil":
                {
                    int hazirlayanOnaylayanID = int.Parse(e.CommandArgument.ToString());
                    tblHazirlayanOnaylayan hzOnay = turna.tblHazirlayanOnaylayan.First(k => k.id == hazirlayanOnaylayanID);
                    turna.tblHazirlayanOnaylayan.DeleteObject(hzOnay);
                    turna.SaveChanges();
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);

                    break;
                }
           
            default:
                messagebox("silme gerçekleştirilemedi");
                break;

        }
    }

}