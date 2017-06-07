using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_NewCadastroPadrao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnApagarModulo_Click(object sender, EventArgs e)
    {

    }

    protected void btnSalvarModulo_Click(object sender, EventArgs e)
    {
        Modulo mod = new Modulo();

        mod.Mod_descricao = txbNomeModulo.Text;
        mod.Mod_pagina = txbPag.Text;
        mod.Mod_padrao = Convert.ToInt32(rblPadrao.SelectedValue);

        switch (ModuloDB.Insert(mod))
        {
            case 0:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>sucess();</script>", false);
                txbNomeModulo.Text = "";
                txbPag.Text = "";
                break;
            case -2:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                break;
        }
    }

    protected void btnApagarStatus_Click(object sender, EventArgs e)
    {
        txbDescStatus.Text = "";
    }

    protected void btnSalvarStatus_Click(object sender, EventArgs e)
    {
        Status sta = new Status();

        sta.Sta_valor = txbDescStatus.Text;

        switch (StatusDB.Insert(sta))
        {
            case 0:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>sucess();</script>", false);
                txbDescStatus.Text = "";
                break;
            case -2:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                break;
        }
    }
}