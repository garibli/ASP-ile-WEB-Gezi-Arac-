using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using skscalismaModel;
public partial class persEkrani_ilanDuzenle : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    VeriIslemleri veri = new VeriIslemleri();
    
    protected void Page_Load(object sender, EventArgs e)
    {
  
        if (Session["Mail"] == null || (Session["yetkiID"].ToString() != "1" && Session["yetkiID"].ToString() != "2") )
            Response.Redirect("../Default.aspx");

        if (IsPostBack) {
            return;
        }
        duzenle.Visible = false;
        int bolumIDGtr = Convert.ToInt16(Session["birimId"]);
        var ilanListe = from birim in turna.tblBirimler
                        join fakul in turna.tblIlanlar on birim.id equals fakul.birimID
                        join bolum in turna.tblBolumler on fakul.bolumID equals bolum.id
                        join calismaSekliGetir in turna.tblCalismaSekli on fakul.idari_Akademi equals calismaSekliGetir.id
                        where (fakul.birimID == bolumIDGtr && fakul.bitisSuresi >= DateTime.Now)
                        select new { silIlan = fakul.id, duzenleIlan = fakul.id, BirimAdi = birim.adi, isMetni = fakul.isBasligi, kontenjan = fakul.kontenjan, altBolum = bolum.adi, calismaSekli = calismaSekliGetir.adi };

        DtlistIlan.DataSource = ilanListe.ToList();
        DtlistIlan.DataBind();
        
    }
    protected void DtlistIlan_ItemCommand(object source, DataListCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "silButon":
                {
                    int personelSil = int.Parse(e.CommandArgument.ToString());
                    turna.ilanSil(personelSil);
                    
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    break;
                }
            case "duzenleButon":
                    {
                        DtlistIlan.Visible = false;
                        duzenle.Visible = true;
                        var ilanDuzenleID = int.Parse(e.CommandArgument.ToString());
                        lbl.Text = ilanDuzenleID.ToString();
                        var ilanBilgiGetir = (from bilgiGetir in turna.tblIlanlar where bilgiGetir.id == ilanDuzenleID select new { isbasligi = bilgiGetir.isBasligi, isMetni = bilgiGetir.isMetni, isTanimi = bilgiGetir.idari_Akademi, bitisSuresi = bilgiGetir.bitisSuresi, kontenjan=bilgiGetir.kontenjan,birimID=bilgiGetir.birimID ,bolum=bilgiGetir.bolumID,calismaSekli=bilgiGetir.idari_Akademi}).FirstOrDefault();
                       
                        txtBitisSuresi.Text = ilanBilgiGetir.bitisSuresi.ToString();
                        TxtIsNiteligi.Text = ilanBilgiGetir.isMetni.ToString() ;
                        TxtIsTanimi.Text = ilanBilgiGetir.isbasligi.ToString();
                        txtKontenjan.Text = ilanBilgiGetir.kontenjan.ToString();
                        var birimID = Convert.ToInt16(ilanBilgiGetir.birimID);
                        var bolumID = Convert.ToInt16(ilanBilgiGetir.bolum);
                        var calismaSekli = Convert.ToInt16(ilanBilgiGetir.isTanimi);
                        DDlistCalismaSekli.SelectedValue = calismaSekli.ToString();
                        var birimGetir = (from birim in turna.tblBirimler where birim.id == birimID select new {adi= birim.adi}).FirstOrDefault();
                        txtBirim.Text = birimGetir.adi.ToString();
                      
                        
                        var bolumGetir = (from bolum in turna.tblBolumler where bolum.id == bolumID select new { bolumAdi=bolum.adi ,bolumId=bolum.id}).FirstOrDefault();
                        var bolumII = bolumGetir.bolumAdi.ToString();
                        var bID = bolumGetir.bolumId.ToString();
                        var bolumlergetir = from bolumler in turna.tblBolumler where bolumler.birimID == birimID select new { bolumler.adi, bolumler.id };
                        DDlistBolum.DataSource = bolumlergetir.ToList();
                        DDlistBolum.DataTextField = "adi";
                        DDlistBolum.DataValueField = "id";
                        DataBind();
                        DDlistBolum.SelectedValue = bID;
                       
                        
                        
                        
                      
                        

                      
                

                        break;
                    }
            default:
                messagebox("silme gerçekleştirilemedi");
                break;

        }
    }



    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        if (DDlistBolum.SelectedItem.Value == "")
        {
            messagebox("boş kalan yerleri doldurunuz");
        }
        else
        {
            if (Convert.ToInt16(DDlistCalismaSekli.SelectedItem.Value) != 1 && Convert.ToInt16(DDlistCalismaSekli.SelectedItem.Value) != 2)
            {
                messagebox("boş kalan yerleri doldurunuz");
            }
            else
            {
                int  calismaSekli = Convert.ToInt16(DDlistCalismaSekli.SelectedItem.Value);
                var isTanimi = TxtIsTanimi.Text;
                var isNiteli = TxtIsNiteligi.Text;
                var bitisSuresi = txtBitisSuresi.Text;
                var kontenjan = txtKontenjan.Text;
                var bolum = DDlistBolum.SelectedItem.Value;
                var ilanDuzenleID = Convert.ToInt16(lbl.Text);



                tblIlanlar ilanUpdate = turna.tblIlanlar.First(k => k.id == ilanDuzenleID);
                ilanUpdate.isBasligi = isTanimi.ToString();
                ilanUpdate.isMetni = isNiteli.ToString();
                ilanUpdate.idari_Akademi = Convert.ToInt16(calismaSekli);
                ilanUpdate.bolumID = Convert.ToInt16(bolum);
                ilanUpdate.kontenjan = Convert.ToInt16(kontenjan);
                ilanUpdate.bitisSuresi = Convert.ToDateTime(bitisSuresi);
       
                turna.SaveChanges();
                messagebox("başarıyla güncellenmiştir");
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtBitisSuresi.Text = Calendar1.SelectedDate.ToString();
    }

    public void messagebox(string mesaj)
    {

        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }
    protected void iptalbtn_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
}