using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class persEkrani_ilanListele : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    
    protected void Page_Load(object sender, EventArgs e)
    {
          
        if (Session["Mail"] == null || (Session["yetkiID"].ToString() != "1" && Session["yetkiID"].ToString() != "2") )
            Response.Redirect("../Default.aspx");
    
        //dataliste atacağımız verileri ilanListe atıyoruz. ilanListen Datalistimize DataSource yardımıyla aktarıyoruz. DataBind() ile baıyoruz.
        try
        {
         int bolumIDGtr = Convert.ToInt16(Session["birimId"]);
         var ilanListe = from birim in turna.tblBirimler
                         join fakul in turna.tblIlanlar on birim.id equals fakul.birimID 
                         join bolum in turna.tblBolumler on fakul.bolumID equals bolum.id
                         join calismaSekliGetir in turna.tblCalismaSekli on fakul.idari_Akademi equals calismaSekliGetir.id
                         where (fakul.birimID == bolumIDGtr && fakul.bitisSuresi >= DateTime.Now )
                         select new { id = fakul.id, birimAdi = birim.adi, isMetni = fakul.isMetni, kontenjan = fakul.kontenjan, altBolum = bolum.adi, calismaSekli=calismaSekliGetir.adi };
         
        DlListe.DataSource = ilanListe.ToList();
        DlListe.DataBind();
        }
        catch 
        {
            messagebox("sayfa yuklenemedi");
        }

    }
    public void messagebox(string mesaj)
    {


        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }


    protected void DlListe_ItemCommand(object source, DataListCommandEventArgs e)
    {
        DlListe.Visible = false;
       
        int ilanID = int.Parse(e.CommandArgument.ToString());
        Session["ilanID"] = ilanID.ToString();
        Response.Redirect("../persEkrani/ilanCikti.aspx");
       
    }
    
}