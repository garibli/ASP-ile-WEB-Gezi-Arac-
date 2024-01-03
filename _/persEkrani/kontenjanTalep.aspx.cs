using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;

public partial class persEkrani_kontenjanTalep : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || (Session["yetkiID"].ToString() != "1" && Session["yetkiID"].ToString() != "2"))
            Response.Redirect("../Default.aspx");
       
            int BolumID = Convert.ToInt16(Session["bolumID"]);
            int BirimID = Convert.ToInt16(Session["birimID"]);
            var BirimIDGetir = (from Birim in turna.tblBirimler
                                where Birim.id == BirimID
                                select new { BirimAdi = Birim.adi }).FirstOrDefault();
            var BolumIDGetir = (from Bolum in turna.tblBolumler
                                where Bolum.birimID == BirimID
                                select new { BolumAdi = Bolum.adi, BolumID = Bolum.id });
            if (!IsPostBack)
            {
            txtBirim.Text = BirimIDGetir.BirimAdi.ToString();
            ddlBolum.DataSource = BolumIDGetir.ToList();
            ddlBolum.DataValueField = "BolumID";
            ddlBolum.DataTextField = "BolumAdi";
            ddlBolum.DataBind();



            var kontenjanTalepGetir = from kontrolKontenjan in turna.tblTalepKontenjan
                                      join birim in turna.tblBirimler on kontrolKontenjan.birimID equals birim.id
                                      join bolum in turna.tblBolumler on kontrolKontenjan.bolumID equals bolum.id
                                      where kontrolKontenjan.birimID == BirimID && kontrolKontenjan.onay == 0
                                      select new { Birim = birim.adi, AltBirim = bolum.adi, IdariKontenjan = kontrolKontenjan.idariKontenjan, AkademikKontenjan = kontrolKontenjan.akademikKontenjan, id = kontrolKontenjan.id };
            dtListTalepKontenjanListe.DataSource = kontenjanTalepGetir.ToList();
            dtListTalepKontenjanListe.DataBind();



        }
    }
    protected void btnKontenjanTalep_Click(object sender, EventArgs e)
    {
         int BirimID = Convert.ToInt16(Session["birimID"]);
         int BolumID = Convert.ToInt16(ddlBolum.SelectedValue);
         try
         {
             var kontrolKontenjanTalep = (from kontrol in turna.tblTalepKontenjan where kontrol.bolumID == BolumID select new { kontrol.id }).FirstOrDefault();
            
                 tblTalepKontenjan tbltalepKontupdate = turna.tblTalepKontenjan.First(x => x.bolumID == BolumID);
                 tbltalepKontupdate.akademikKontenjan = Convert.ToInt16(txtAkademikKontenjan.Text);
                 tbltalepKontupdate.idariKontenjan = Convert.ToInt16(txtIdariKontenjan.Text);
                 turna.SaveChanges();
             
         }
         catch
         {


             int akademiktalepKontenjanSayisi = Convert.ToInt16(txtAkademikKontenjan.Text);
             int idaritalepKontenjanSayisi = Convert.ToInt16(txtIdariKontenjan.Text);
             tblTalepKontenjan kontenjanGir = new tblTalepKontenjan
             {
                 birimID = BirimID,
                 bolumID = BolumID,
                 akademikKontenjan = akademiktalepKontenjanSayisi,
                 idariKontenjan = idaritalepKontenjanSayisi,
                 tarih = DateTime.Now,
                 onay = 0
             };
             turna.tblTalepKontenjan.AddObject(kontenjanGir);
             turna.SaveChanges();
             Page.Response.Redirect(Page.Request.Url.ToString(), true);
         }
         Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    public void messagebox(string mesaj)
    {
        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }
    protected void dtListTalepKontenjanListe_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int talepKontejanID = int.Parse(e.CommandArgument.ToString());
        tblTalepKontenjan talepKontDelete = turna.tblTalepKontenjan.First(x => x.id == talepKontejanID);
        turna.tblTalepKontenjan.DeleteObject(talepKontDelete);
        turna.SaveChanges();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);

    }

    protected void btnSksGonder_Click(object sender, EventArgs e)
    {
        int BirimID = Convert.ToInt16(Session["birimID"]);
        tblTalepKontenjan tbltalepKontupdate = turna.tblTalepKontenjan.First(x => x.birimID == BirimID);
        tbltalepKontupdate.onay = 1;
        turna.SaveChanges();
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
}