﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class SKSEkrani_KontenjanIslemleri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Mail"] == null || Session["yetkiID"].ToString() != "0")
            Response.Redirect("../Default.aspx");//eğer girişe yetkili değilse.

    }
    protected void btnBirimKonteGuncelle_Click(object sender, EventArgs e)
    {
        Response.Redirect("Kontenjan.aspx");

          
    }
    protected void btnBolumKonte_Click(object sender, EventArgs e)
    {
        Response.Redirect("AltBolumKontenjanBelirle.aspx");
    }
}