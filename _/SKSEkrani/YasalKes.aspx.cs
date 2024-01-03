using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_YasalKes : System.Web.UI.Page
{

    public void yasalKesGetir() 
    {
        TurnaEntities turna = new TurnaEntities();

        var getir = from yasalKes in turna.tblYasalKesinti
                    join ogr in turna.tblOgrenci
                    on yasalKes.ogrNo equals ogr.ogrNo
                    orderby ogr.ad ascending
                    select new { yasalKes.id, yasalKes.ogrNo, ogr.ad, ogr.soyad, yasalKes.yasalKesintiOrani };


        GridViewBirimler.DataSource = getir.ToList();
        GridViewBirimler.DataBind();



    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.




        if (!IsPostBack)
        {
            VeriIslemleri veri = new VeriIslemleri();

            veri.ddlVeriCekBirimler(ddlBirimler);

            yasalKesGetir();

        }
      
       


    }
    protected void ddlBirimler_SelectedIndexChanged(object sender, EventArgs e)
    {
        TurnaEntities turna = new TurnaEntities();
        if (ddlBirimler.SelectedValue != "-1")
        {
            int calBirimID = Convert.ToInt16(ddlBirimler.SelectedValue);

            var ogrNo = from ogr in turna.tblOgrenci
                        join calistigi in turna.tblCalismaYerleri
                        on ogr.ogrNo equals calistigi.ogrNo
                        where calistigi.calisacagiCalistigiYer == calBirimID
                        select new { ogr.ad, ogr.soyad, ogr.ogrNo };

            foreach (var item in ogrNo)
            {
                ddlCalisan.Items.Add(new ListItem(item.ad + " " + item.soyad, item.ogrNo));
            }




        }
    }
    protected void ddlCalisan_SelectedIndexChanged(object sender, EventArgs e)
    {



    }
    protected void btnGir_Click(object sender, EventArgs e)
    {
        try
        {

        if (ddlCalisan.SelectedValue != "" || txtOrani.Text!="" )//|| txtYasalKes.Text != "")
	{
              tblYasalKesinti yasalKes = new tblYasalKesinti();

              yasalKes.ogrNo = ddlCalisan.SelectedValue;
              yasalKes.yansitilcakMaasDonemi = DateTime.Now;//(Convert.ToDateTime("1." + ddlMaasDonemiAY.SelectedValue + "." + ddlMaasDonemiYIL.SelectedValue));
              yasalKes.yasalKesintiOrani = Convert.ToDecimal(txtOrani.Text);
              yasalKes.yasalKesintiTutari = 0;//Convert.ToDecimal(txtYasalKes.Text);

              TurnaEntities turna = new TurnaEntities();
              turna.tblYasalKesinti.AddObject(yasalKes);
              turna.SaveChanges();

              lblBilgi.Text = "Yasal kesinti oluşturuldu.";

    }
        else
        {
            lblBilgi.Text = "Gerekli alanları doldurunuz";
        }


        }
        catch (Exception)
        {

            lblBilgi.Text = "Bir hata oluştu.Girdiğiniz Değerleri kontrol edip tekrar deneyiniz.";
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int birimID = Convert.ToInt16(GridViewBirimler.SelectedRow.Cells[1].Text);

        TurnaEntities turna = new TurnaEntities();

        tblYasalKesinti yasalKesSil = turna.tblYasalKesinti.First(n => n.id == birimID);

        turna.tblYasalKesinti.DeleteObject(yasalKesSil);

        turna.SaveChanges();

        yasalKesGetir();

    }
}