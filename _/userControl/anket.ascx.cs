using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class userControl_anket : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ///Tüm cevaplar tek stringde tutulur (once ilk nesnenin seçilen indexi sonra value değeri)
        ///00 11 21 32 44 55 56 gibi sonra ordan tekrar çekilerek gösterilir.
        ///
        if (!IsPostBack)
        {

            TurnaEntities turna = new TurnaEntities();

            string ogrNo = Session["ogrNo"].ToString();

            var anketGetir = from anketCvb in turna.tblOgrenciAnketCevablari
                             where anketCvb.ogrNo == ogrNo
                             select new { anketCvb.secimlerIDPUANEk1 };

            string verilenCevaplar = "-1";

            foreach (var item in anketGetir)
            {
                verilenCevaplar = item.secimlerIDPUANEk1;
            }

            if (verilenCevaplar != "-1")
            {
                ddl11.SelectedIndex = Convert.ToInt16(verilenCevaplar[0].ToString());
                ddl12.SelectedIndex = Convert.ToInt16(verilenCevaplar[2].ToString());
                ddl13.SelectedIndex = Convert.ToInt16(verilenCevaplar[4].ToString());
                ddl14.SelectedIndex = Convert.ToInt16(verilenCevaplar[6].ToString());
                ddl15.SelectedIndex = Convert.ToInt16(verilenCevaplar[8].ToString());
                ddl16.SelectedIndex = Convert.ToInt16(verilenCevaplar[10].ToString());
                ddl17.SelectedIndex = Convert.ToInt16(verilenCevaplar[12].ToString());
                ddl18.SelectedIndex = Convert.ToInt16(verilenCevaplar[14].ToString());
                ddl19.SelectedIndex = Convert.ToInt16(verilenCevaplar[16].ToString());
                ddl110.SelectedIndex = Convert.ToInt16(verilenCevaplar[18].ToString());
                //ddl21.SelectedIndex = Convert.ToInt16(verilenCevaplar[20].ToString());
                //ddl22.SelectedIndex = Convert.ToInt16(verilenCevaplar[22].ToString());
                //ddl23.SelectedIndex = Convert.ToInt16(verilenCevaplar[24].ToString());
                //ddl24.SelectedIndex = Convert.ToInt16(verilenCevaplar[26].ToString());
                //ddl25.SelectedIndex = Convert.ToInt16(verilenCevaplar[28].ToString());
                //ddl26.SelectedIndex = Convert.ToInt16(verilenCevaplar[30].ToString());
                

            }
        }

    }
   
   
    protected void btnDevam_Click(object sender, EventArgs e)
    {

        string anket = ddl11.SelectedIndex + " " + ddl12.SelectedIndex + " " + ddl13.SelectedIndex + " " +
            ddl14.SelectedIndex + " " + ddl15.SelectedIndex + " " + ddl16.SelectedIndex + " " +
            ddl17.SelectedIndex + " " + ddl18.SelectedIndex + " " + ddl19.SelectedIndex + " " +
            ddl110.SelectedIndex + " ";//+ ddl21.SelectedIndex + " " +
            //ddl22.SelectedIndex + " " + ddl23.SelectedIndex + " " + ddl24.SelectedIndex + " " +
            //ddl25.SelectedIndex + " " + ddl26.SelectedIndex;


        int anketPuan = Convert.ToInt16(ddl12.SelectedValue) + Convert.ToInt16(ddl13.SelectedValue) + Convert.ToInt16(ddl14.SelectedValue) + Convert.ToInt16(ddl15.SelectedValue)
             + Convert.ToInt16(ddl16.SelectedValue) + Convert.ToInt16(ddl17.SelectedValue) + Convert.ToInt16(ddl18.SelectedValue) + Convert.ToInt16(ddl19.SelectedValue)
             + Convert.ToInt16(ddl110.SelectedValue); //+ Convert.ToInt16(ddl21.SelectedValue) + Convert.ToInt16(ddl22.SelectedValue) + Convert.ToInt16(ddl23.SelectedValue)
              // + Convert.ToInt16(ddl24.SelectedValue) + Convert.ToInt16(ddl25.SelectedValue) + Convert.ToInt16(ddl26.SelectedValue);


        TurnaEntities turna = new TurnaEntities();
        Session["anketEk1"] = anket;
        Session["anketPuanEk1"] = anketPuan;

        Response.Redirect("./Anket2.aspx");

        


    }
}