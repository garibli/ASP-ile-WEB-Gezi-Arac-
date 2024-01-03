using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class komisyon_OgrenciBasvuru : System.Web.UI.Page
{
    TurnaEntities turna = new TurnaEntities();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            return;
        }
        int birimId = Convert.ToInt16(Session["birimId"]);
        int bolumID = Convert.ToInt16(Session["bolumId"]);

        var ogrBilgi = from ogrenciAnkCVP in turna.tblOgrenciAnketCevablari
                       join ogrenciBavuru in turna.tblOgrBasvuruBilgileri on ogrenciAnkCVP.ogrNo equals ogrenciBavuru.ogrNo
                       join ilanBilgi in turna.tblIlanlar on ogrenciBavuru.BasvuruID equals ilanBilgi.id
                       join ogrBilgis in turna.tblOgrenci on ogrenciBavuru.ogrNo equals ogrBilgis.ogrNo
                       join birims in turna.tblBirimler on ilanBilgi.birimID equals birims.id
                       
                       where birims.id == birimId && ilanBilgi.bolumID==bolumID //&& (ogrenciBavuru.MulakatSoruldumu == 0 || ogrenciBavuru.MulakatSoruldumu == -1)
                       select new { ad = ogrBilgis.ad, soyad = ogrBilgis.soyad, puan = ogrenciAnkCVP.anketPuani1, puan2 = ogrenciAnkCVP.anketPuani2, puan3 = ogrenciAnkCVP.anketPuani3, programAdi = ilanBilgi.programAdi, birim = birims.adi, id = ogrBilgis.mail };


                       /*     var ogrBilgiGetir = from ilanBilgi in turna.tblIlanlar
                            join bsvrBilgi in turna.tblOgrBasvuruBilgileri on ilanBilgi.id equals bsvrBilgi.BasvuruID
                            join ogrBilgi in turna.tblOgrenci on bsvrBilgi.ogrNo equals ogrBilgi.ogrNo
                            join anketCvp in turna.tblOgrenciAnketCevablari on ogrBilgi.ogrNo equals anketCvp.ogrNo
                            join birimID in turna.tblBirimler on ogrBilgi.okulu equals birimID.id
                            where (bsvrBilgi.MulakatSoruldumu == 0 || bsvrBilgi.MulakatSoruldumu == -1) && (ilanBilgi.birimID == birimId && ilanBilgi.bolumID == bolumID)
                            select new { ad = ogrBilgi.ad, soyad = ogrBilgi.soyad, puan = anketCvp.anketPuani1, puan2 = anketCvp.anketPuani2, puan3 = anketCvp.anketPuani3, programAdi = ilanBilgi.programAdi, birim = birimID.adi,id=ogrBilgi.mail };
       */ ddlistOGrBasvuruBilgileri.DataSource = ogrBilgi.ToList();
        ddlistOGrBasvuruBilgileri.DataBind();

        ogrBilgiMenu.Visible = false;
        ddlistOGrBasvuruBilgileri.Visible = true;
        
      

    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "bilgiGoster":
                {

                    Session["basvuru"] = 1;
                  ddlistOGrBasvuruBilgileri.Visible = false;
                 
               
                  ogrBilgiMenu.Visible = true;
                  string bilgiOgr = e.CommandArgument.ToString();
                 
                  Session["ogrMailGetir"] = bilgiOgr.ToString();
                   
                   var anketCevap = (from anketCVP in turna.tblOgrenciAnketCevablari where anketCVP.ogrMail == bilgiOgr select new { anketCVP.secimlerIDPUANEk1,anketCVP.secimlerIDPUANEk2,anketCVP.secimlerIDPUANEk3 }).FirstOrDefault();
                    string   verilenCevap1 = anketCevap.secimlerIDPUANEk1.ToString();
                    string verilenCevap2 = anketCevap.secimlerIDPUANEk2.ToString();
                    string verilenCevap3 = anketCevap.secimlerIDPUANEk3.ToString();

                    ddl11.SelectedIndex = Convert.ToInt16(verilenCevap1[0].ToString());
                    ddl12.SelectedIndex = Convert.ToInt16(verilenCevap1[2].ToString());
                    ddl13.SelectedIndex = Convert.ToInt16(verilenCevap1[4].ToString());
                    ddl14.SelectedIndex = Convert.ToInt16(verilenCevap1[6].ToString());
                    ddl15.SelectedIndex = Convert.ToInt16(verilenCevap1[8].ToString());
                    ddl16.SelectedIndex = Convert.ToInt16(verilenCevap1[10].ToString());
                    ddl17.SelectedIndex = Convert.ToInt16(verilenCevap1[12].ToString());
                    ddl18.SelectedIndex = Convert.ToInt16(verilenCevap1[14].ToString());
                    ddl19.SelectedIndex = Convert.ToInt16(verilenCevap1[16].ToString());
                    ddl110.SelectedIndex = Convert.ToInt16(verilenCevap1[18].ToString());
                    ddl21.SelectedIndex = Convert.ToInt16(verilenCevap2[0].ToString());
                    ddl22.SelectedIndex = Convert.ToInt16(verilenCevap2[2].ToString());
                    ddl23.SelectedIndex = Convert.ToInt16(verilenCevap2[4].ToString());
                    ddl24.SelectedIndex = Convert.ToInt16(verilenCevap2[6].ToString());
                    ddl25.SelectedIndex = Convert.ToInt16(verilenCevap2[8].ToString());

                    //ddl21.SelectedIndex = Convert.ToInt16(verilenCevaplar[10].ToString());

                    //ddl23.SelectedIndex = Convert.ToInt16(verilenCevaplar[12].ToString());
                    //ddl24.SelectedIndex = Convert.ToInt16(verilenCevaplar[14].ToString());
                    if (verilenCevap2[16].ToString() == "1")
                    {

                        ddl26.SelectedIndex = 1;
                        // CheckBox1.Checked = true;
                    }
                    else
                    {
                        ddl26.SelectedIndex = 2;
                    }

                    ddl31.SelectedIndex = Convert.ToInt16(verilenCevap3[0].ToString());
                    ddl32.SelectedIndex = Convert.ToInt16(verilenCevap3[2].ToString());
                    // ddl13.SelectedIndex = Convert.ToInt16(verilenCevap3[4].ToString());
                    ddl33.SelectedIndex = Convert.ToInt16(verilenCevap3[6].ToString());
                    ddl34.SelectedIndex = Convert.ToInt16(verilenCevap3[8].ToString());


                    break;
                 }
            default:             
                break;


        }
    }
  
    public void messagebox(string mesaj)
    {


        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }

    protected void btnMulakat_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("../komisyon/MulakatSorulariSor.aspx");
        }
        catch
        {
            messagebox("Mulakat sorunuz bulunmamaktadır");
        }
    }
}