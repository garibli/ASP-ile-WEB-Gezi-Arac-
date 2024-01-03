using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using skscalismaModel;
public partial class persEkrani_ogrGirisYoklama : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
          
        if (Session["Mail"] == null || (Session["yetkiID"].ToString() != "1" && Session["yetkiID"].ToString() != "2") )
            Response.Redirect("../Default.aspx");

    }
       
 }