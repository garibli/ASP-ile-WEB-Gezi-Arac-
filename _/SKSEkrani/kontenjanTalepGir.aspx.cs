using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;

public partial class SKSEkrani_kontenjanTalepGir : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");

        try
        {
            var kontenjanTalepGetir = from kont in turna.tblTalepKontenjan
                                      join
                                          birim in turna.tblBirimler on kont.birimID equals birim.id
                                      join
                                          bolum in turna.tblBolumler on kont.bolumID equals bolum.id
                                          where kont.onay==1
                                      select new { birim = birim.adi, bolum = bolum.adi, akademik = kont.akademikKontenjan, idari = kont.idariKontenjan, tarih = kont.tarih, id = kont.id };
            dtLstKontenjanTalep.DataSource = kontenjanTalepGetir.ToList();
            dtLstKontenjanTalep.DataBind();

            int akademik = 0;
            int idari = 0;
            foreach (var item in kontenjanTalepGetir)
            {
                akademik += Convert.ToInt16(item.akademik);
                idari += Convert.ToInt16(item.idari);
            }
            lblAkademik.Text = akademik.ToString();
            lblIdari.Text = idari.ToString();
            lblToplam.Text = Convert.ToString(akademik + idari);
        }
        catch 
        {
            lblAkademik.Text = "0";
            lblIdari.Text = "0";
            lblToplam.Text = "0";
        }
    }

    protected void dtLstKontenjanTalep_ItemCommand(object source, DataListCommandEventArgs e)
    {
        int kontenjanTalepID = int.Parse(e.CommandArgument.ToString());
        messagebox("Bu işleminizi henüz gerçekleştirememekteyiz.");
    }
    public void messagebox(string mesaj)
    {

        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }
}