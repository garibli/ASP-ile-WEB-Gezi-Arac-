using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
using System.Xml;
using System.Net;
using Microsoft.Win32;




public partial class ogrGiris : System.Web.UI.Page
{


    //registry.SetValue("ProxyEnable", 1); 
    //registry.SetValue("ProxyServer", textBox1.Text); 
    //string ogrnosab;
    //string ogrno;



    protected void Page_Load(object sender, EventArgs e)
    {

        //Response.Redirect("GuncellemeYapiliyor.aspx");

        Page.SetFocus(btnLogin);
    }

    protected void btnLogin_Click(object sender, EventArgs e)

    {
        string sabisogrno = null;


        string sifrem = txtUserPassword.Text.ToString();
        string ogrno = txtUserName.Text.ToString();
        //char[] ogrnom = ogrno.ToCharArray();
        //RegistryKey registry = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
        //registry.SetValue("ProxyEnable", 1);

        WebProxy wb = new WebProxy(WebProxy.GetDefaultProxy().Address);
        WebClient wc = new WebClient();
        wc.Proxy = wb;
        
        string site = wc.DownloadString("http://apiois.sabis.sakarya.edu.tr/api/OgrenciBilgi/GetOgrenciBilgiEdinme?tc=" + sifrem);
        //registry.SetValue("ProxyServer", site);
        XmlDocument xd = new XmlDocument();
        xd.LoadXml(site);

        XmlNodeList liste = xd.SelectNodes("ArrayOfDtoOgrenciGenelBilgileri/DtoOgrenciGenelBilgileri");

        //XmlNodeList Liste = xd.SelectNodes("ArrayOfDtoOgrenciGenelBilgileri/DtoOgrenciGenelBilgileri");

        foreach (XmlNode item in liste)
        {
            sabisogrno = item["_x003C_OgrenciNo_x003E_k__BackingField"].InnerText;

        }
        
        //char[] ogrnosabis = ogrnosab.ToCharArray();
        //string ogrno = txtUserName.Text;
        int deger = String.Compare(ogrno, sabisogrno);
        if (deger==0) 
        {
            lblBilgi.Text = "tc ve oğrenci numaranız uyuşuyor";
            lblBilgiKontrol.Visible = true;
        }
            //}

        else
        {
            lblBilgi.Text = "tc ve oğrenci numaranız uyuşmuyor !";
            lblBilgiKontrol.Visible = true;
        }

       
    }
}
