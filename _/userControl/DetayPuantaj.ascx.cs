using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using skscalismaModel;
public partial class userControl_DetayPuantaj : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = DateTime.Now.AddMonths(-1).ToShortDateString();

            
        



    }
}