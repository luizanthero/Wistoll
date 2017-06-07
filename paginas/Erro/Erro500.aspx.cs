using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_Erro_Erro500 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/paginas/login.aspx");
    }
}