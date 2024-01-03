using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class devPageLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkButton_Click(object sender, EventArgs e)
    {
        if (txtSifre.Text == "melih") 
        {
            Session["developer"] = "melih";
            Response.Redirect("developersPage.aspx");
        }
        else if (txtSifre.Text == "ismail")
        {
            Session["developer"] = "ismail";
            Response.Redirect("developersPage.aspx");
        }
        else 
        {

        }
    }
}