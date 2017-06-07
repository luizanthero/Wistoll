using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_Erro_Erro404 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];

        if (fmp.Funcionario.Perfil.Pfl_descricao.Equals("Administrador"))
        {
            Response.Redirect("~/paginas/Admin.aspx");
        }
        else
        {
            Response.Redirect("~/paginas/Index.aspx");
        }
    }
}