using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_personelDuzenle : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.



        var personeller = from personel in turna.tblPersonel 
                          join birim in turna.tblBirimler
                          on personel.birimId equals birim.id
                          orderby birim.adi ascending
                          select new {Ad=personel.adi, soyad=personel.soyad, Mail=personel.mail, Sifre=personel.sifre,id=personel.id,birimAdi = birim.adi };
        dlPersonelListele.DataSource = personeller.ToList();
        dlPersonelListele.DataBind();



        if (!IsPostBack)
        {

            var birimGetir = from birim in turna.tblBirimler 
                             orderby birim.adi ascending
                             select new { birim.adi, birim.id };
            DropDownListBirim.DataSource = birimGetir.ToList();
            DropDownListBirim.DataValueField = "id";
            DropDownListBirim.DataTextField = "adi";
            DropDownListBirim.DataBind();
            DropDownListBirim.Items.Insert(0, new ListItem("– Birim Seçiniz –", "-1"));

        }

    }
    public void bolumListele()
    {
        var birimSecildi = Convert.ToInt16(DropDownListBirim.SelectedItem.Value);

        var bolumGetir = from bolum in turna.tblBolumler 
                         where bolum.birimID == birimSecildi
                         orderby bolum.adi ascending
                         select new { bolum.adi, bolum.id };
        DropDownListBolum.DataSource = bolumGetir.ToList();
        DropDownListBolum.DataValueField = "id";
        DropDownListBolum.DataTextField = "adi";
        DropDownListBolum.DataBind();
        DropDownListBolum.Items.Insert(0, new ListItem("- Bolum Seçiniz -", "-1"));
    }
    protected void dlPersonelListele_ItemCommand(object source, DataListCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "silPersonel" :
                {
                    int personelSil = int.Parse(e.CommandArgument.ToString());

                    tblPersonel persSil = turna.tblPersonel.First(n => n.id == personelSil);


                    turna.tblPersonel.DeleteObject(persSil);

                    turna.SaveChanges();


                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    break;
                }
            case "guncellePersonel":
                {
                    int persGuncelleID = int.Parse(e.CommandArgument.ToString());

                    var guncelleQuery = from persVeri in turna.tblPersonel
                                        where persVeri.id == persGuncelleID
                                        select new { persVeri.mail, persVeri.persTC, persVeri.sifre, persVeri.soyad, persVeri.yetkiID, persVeri.dahiliNo, persVeri.bolumId, persVeri.birimId, persVeri.adi };


                    foreach (var item in guncelleQuery)
                    {
                        TxtDahili.Text = item.dahiliNo.ToString();
                        txtpersAd.Text = item.adi.ToString();
                        txtPersID.Text = persGuncelleID.ToString();
                        txtpersMail.Text = item.mail.ToString();
                        txtpersSoyad.Text = item.soyad.ToString();
                        txtpersTC.Text = item.persTC.ToString();
                        txtsifreIlk.Text = item.sifre.ToString();
                        DropDownListBirim.SelectedValue = item.birimId.ToString();
                        bolumListele();
                        if (item.bolumId != null)
                        DropDownListBolum.SelectedValue = item.bolumId.ToString();
                        DropDownListYetki.SelectedValue = item.yetkiID.ToString();
                    }




                    break;
                }
            default:
                messagebox("silme gerçekleştirilemedi");
                break;

        }
    }
    public void messagebox(string mesaj)
    {


        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }
    protected void btnGuncelle_Click(object sender, EventArgs e)
    {

        try
        {

        string[] mailKontrol = txtpersMail.Text.Split('@');





        if (mailKontrol[1].TrimEnd(' ') == "sakarya.edu.tr")
        {





            if (txtPersID.Text != "")
            {


                if (DropDownListYetki.SelectedValue == "0" && DropDownListBirim.SelectedValue != "49")
                {
                    lblBilgi.Text = "SKS Yöneticisi Yalnızca SKS biriminde görevlendirilcek personel için seçilebilir.";
                }
                else
                {




                    int persID = Convert.ToInt16(txtPersID.Text);
                    tblPersonel persGuncelle = turna.tblPersonel.First(n => n.id == persID);

                    persGuncelle.adi = txtpersAd.Text;
                    persGuncelle.birimId = Convert.ToInt16(DropDownListBirim.SelectedValue);
                    persGuncelle.bolumId = Convert.ToInt16(DropDownListBolum.SelectedValue);
                    persGuncelle.dahiliNo = TxtDahili.Text;
                    persGuncelle.mail = txtpersMail.Text;
                    persGuncelle.persTC = txtpersTC.Text;
                    persGuncelle.sifre = txtsifreIlk.Text;
                    persGuncelle.soyad = txtpersSoyad.Text;
                    persGuncelle.yetkiID = Convert.ToInt16(DropDownListYetki.SelectedValue);

                    turna.SaveChanges();

                    var personeller = from personel in turna.tblPersonel
                                      join birim in turna.tblBirimler
                                      on personel.birimId equals birim.id
                                      orderby birim.adi ascending
                                      select new { Ad = personel.adi, soyad = personel.soyad, Mail = personel.mail, Sifre = personel.sifre, id = personel.id, birimAdi = birim.adi };
                    dlPersonelListele.DataSource = personeller.ToList();
                    dlPersonelListele.DataBind();


                    lblBilgi.Text = "İşleminiz başarıyla gerçekleşti.";

                }
            }
            else
            {
                lblBilgi.Text = "Önce listeden personel seçmelisiniz.";
            }
        }
        
        else
        {
            lblBilgi.Text = "Üniversite mail adresi kullanılmalı.";
        }

        }
        catch (Exception)
        {

            lblBilgi.Text = "Bir hata oluştu girdiğiniz verileri kontrol ederek işleminizi tekrarlayınız.";
        }
    }
    protected void DropDownListBirim_SelectedIndexChanged(object sender, EventArgs e)
    {
        var birimSecildi = Convert.ToInt16(DropDownListBirim.SelectedItem.Value);

        var bolumGetir = from bolum in turna.tblBolumler 
                         where bolum.birimID == birimSecildi 
                         orderby bolum.adi ascending
                         select new { bolum.adi, bolum.id };
        DropDownListBolum.DataSource = bolumGetir.ToList();
        DropDownListBolum.DataValueField = "id";
        DropDownListBolum.DataTextField = "adi";
        DropDownListBolum.DataBind();
        DropDownListBolum.Items.Insert(0, new ListItem("- Bolum Seçiniz -", "-1"));
    }
    protected void dlPersonelListele_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}