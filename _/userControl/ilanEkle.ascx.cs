using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class userControl_ilanEkle : System.Web.UI.UserControl
{
    TurnaEntities turna = new TurnaEntities();
    VeriIslemleri veri = new VeriIslemleri();
    protected void Page_Load(object sender, EventArgs e)
    {
       int birim= Convert.ToInt16(Session["birimID"]);
        if (!IsPostBack)
        {
            veri.ddlVeriCekCalismaSekli(ddlCalismaSekli);
            veri.ddlVeriCekBirimlerIlanEkle(ddlIlgiliBirim , birim);
            //veri.ddlVeriCekParamBirimler(ddlIlgiliBirim, "Çerezden gelicek id"); eğerki birimler ilan ekliycekse
        }
    }
    protected void btnGonder_Click(object sender, EventArgs e)
    {
        int kontrol = 1;
        int kontenjan=0;
        var kontenjanBul = 0;
        int UstkontenjanBirimId = 0;
        var ilanlıKontenjanSayisi=0;
        int persID = Convert.ToInt16(Session["persID"]);
        int persBolumID=Convert.ToInt16(Session["bolumID"]);
        int persBirimID=Convert.ToInt16(Session["birimID"]);
        string[] gunler = new string[11]; 

        //kontenjan kontrolu. eger kontenjan sınırı aşıyosa ilan eklenmeyecek
        if (chkBoxPazartesiOO.Checked == true) { gunler[1] = "1"; }
        else { gunler[1] = "0"; }
        if (chkBoxSaliOO.Checked == true) { gunler[2] = "1"; }
        else{gunler[2]="0";}
        if (chkBoxCarsambaOO.Checked == true) { gunler[3] = "1"; }
        else { gunler[3] = "0"; }
        if (chkBoxPersembeOO.Checked == true) { gunler[4] = "1"; }
        else { gunler[4] = "0"; }
        if (chkBoxCumaOO.Checked == true) { gunler[5] = "1"; }
        else { gunler[5] = "0"; }
        if (chkBoxPazartesiOS.Checked == true) { gunler[6] = "1"; }
        else { gunler[6] = "0"; }
        if (chkBoxSaliOS.Checked == true) { gunler[7] = "1"; }
        else { gunler[7] = "0"; }
        if (chkBoxCarsambaOS.Checked == true) { gunler[8] = "1"; }
        else { gunler[8] = "0"; }
        if (chkBoxPersembeOS.Checked == true) { gunler[9] = "1"; }
        else { gunler[9] = "0"; }
        if (chkBoxCumaOS.Checked == true) { gunler[10] = "1"; }
        else { gunler[10] = "0"; }
        string calismaGunu = gunler[1] + gunler[2] + gunler[3] + gunler[4] + gunler[5] + gunler[6] + gunler[7] + gunler[8] + gunler[9] + gunler[10];
       
        


        try
        {
             kontenjan = Convert.ToInt16(txtKontenjan.Text);
        }
        catch
        {
            kontenjan = 0;
        }
        try
        {
             UstkontenjanBirimId = Convert.ToInt16(ddlIlgiliBirim.SelectedItem.Value);
        }
        catch 
        {
            UstkontenjanBirimId = -1;

        }
        int ustkontenjanBirimId= Convert.ToInt16(ddlIlgiliBirim.SelectedItem.Value);

        //kontenjan kontrolu
        if (UstkontenjanBirimId != -1)
        {
            //verilen ilanlardak toplam kontenjan sayısı
            int birimIdGetir = Convert.ToInt16(ddlIlgiliBirim.SelectedItem.Value);
            try
            {
                var ilanlıKontenjan = from kontenjanBak in turna.tblIlanlar where kontenjanBak.birimID == birimIdGetir select new { kontenjanBak.kontenjan };
                foreach (var item in ilanlıKontenjan)
                {
                    ilanlıKontenjanSayisi += Convert.ToInt16(item.kontenjan);
                }
            }
            catch
            {
                ilanlıKontenjanSayisi = 0;
            }

            //bolume verilen kontenjan sınırı
            var birimKontenjanSiniri = from birim in turna.tblBirimler where birim.id == birimIdGetir select new { birim.UstKontenjan };
            foreach (var item in birimKontenjanSiniri)
            {
                kontenjanBul += Convert.ToInt16(item.UstKontenjan);
            }
            //girilen kontenjanın bolume verilen kontenjan sınırından buyuk-küçük kontrolunun yapılması
            if (kontenjanBul < kontenjan)
            {
                messagebox("kontenjan sınırını aştınız.Kontenjan sınırını arttırmak için SKS ye başvurun");
                kontrol = 0;
                txtKontenjan.Text = null;
            }
            
            kontenjanBul = kontenjanBul - ilanlıKontenjanSayisi;
            if (kontenjanBul < kontenjan)
            {
                messagebox("kontenjan sınırını aştınız.Kontenjan sınırını attırmak için SKS ye başvurun");
                kontrol = 0;
                txtKontenjan.Text = null;
            }
        }
        else 
        {
            
            try
            {
                var ilanlıKontenjan = from kontenjanBak in turna.tblIlanlar where kontenjanBak.birimID == persBirimID select new { kontenjanBak.kontenjan };
                foreach (var item in ilanlıKontenjan)
                {
                    ilanlıKontenjanSayisi =ilanlıKontenjanSayisi+ Convert.ToInt16(item.kontenjan);
                }
            }
            catch
            {
                ilanlıKontenjanSayisi = 0;
            }

            var kontenjanSiniri = from birimKontenjan in turna.tblBirimler where birimKontenjan.id == persBirimID select new { birimKontenjan.UstKontenjan };
            foreach (var item in kontenjanSiniri)
            {
                kontenjanBul =kontenjanBul+ Convert.ToInt16(item.UstKontenjan);
            }

            if (kontenjanBul < kontenjan)
            {
                messagebox("kontenjan sınırını aştınız.Kontenjan sınırını arttırmak için SKS ye başvurun");
                kontrol = 0;
                txtKontenjan.Text = null;
            }
            kontenjanBul = kontenjanBul - ilanlıKontenjanSayisi;
            if (kontenjanBul < kontenjan)
             {
                messagebox("kontenjan sınırını aştınız.Kontenjan sınırını attırmak için SKS ye başvurun");
                kontrol = 0;
                txtKontenjan.Text = null;
            }
        }


        if (kontrol == 1)
        {
            if (txtBaslik.Text == "" || ddlIlgiliBirim.SelectedValue == "-1" || ddlIlgiliBolum.SelectedValue == "" || txtKontenjan.Text == "" || ddlCalismaSekli.SelectedValue == "" || txtTarih.Text == ""||ddlProgramAdi.SelectedItem.Value=="0")
            {
                LblHata.Text = "Gerekli alanları doldurmanız gerekmektedir.";
            }
            else
            {
              
               
               if (Convert.ToDateTime(txtTarih.Text) < DateTime.Now)
                    {
                    LblHata.Text = "Bitiş tarihi bugunden önce seçilemez";
                    txtTarih.Text = null;
                    }
                   else
                  {
                    int birimGetir = Convert.ToInt16(ddlIlgiliBirim.SelectedValue);
                    int bolumGetir = Convert.ToInt16(ddlIlgiliBolum.SelectedValue);
                    int kontenjanGetir = Convert.ToInt16(txtKontenjan.Text);
                    int calismasekliGetir = Convert.ToInt16(ddlCalismaSekli.SelectedValue);
                    string programAdi = ddlProgramAdi.SelectedItem.Text;
                    

                    turna.IlanEkle(persID, txtBaslik.Text, txtAciklama.Text, birimGetir, bolumGetir, kontenjanGetir, calismasekliGetir, 1, Convert.ToDateTime(txtTarih.Text), "0",  programAdi, calismaGunu);
                   
                    
                    LblHata.Text = "Başarılı bir şekilde kaydedildi";

                    txtBaslik.Text = null;
                    txtAciklama.Text = null;
                    txtKontenjan.Text = null;
                    txtTarih.Text = null;
                    ddlCalismaSekli.SelectedValue = "";
                    ddlIlgiliBirim.SelectedValue = "-1";
                    ddlIlgiliBolum.SelectedValue = "-1";
                    messagebox("İlanınız sisteme yüklenmiştir");
                    
                   
                }

            }
       
        }
    }
    protected void ddlIlgiliBirim_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsPostBack) { return; }
        
        veri.ddlVeriCekParamBolumlerGetir(ddlIlgiliBolum, Convert.ToInt16(ddlIlgiliBirim.SelectedValue));
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtTarih.Text = Calendar1.SelectedDate.ToString();
       
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void messagebox(string mesaj)
    {


        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + mesaj + "')</SCRIPT>");

    }
   
}