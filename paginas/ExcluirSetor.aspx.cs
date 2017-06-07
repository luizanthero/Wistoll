using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Wistoll.Funcoes;

public partial class paginas_ExcluirSetor : System.Web.UI.Page
{
    int codigo = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];

        if (Session["funcionario"] != null)
        {
            if (!Page.IsPostBack)
            {
                DataSet ds1 = new DataSet();
                string pagina = "";
                int n = 0;
                ds1 = FunModDB.SelectMenu(fmp.Funcionario.Fun_cod);
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    pagina = dr["mod_pagina"].ToString();
                    if (pagina == "ExcluirSetor.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }

                if (Request.QueryString["par"] != null)
                {
                    if (Request.QueryString["par"].ToString() != "")
                    {
                        string valor = Request.QueryString["par"].ToString().Replace(" ", "+");
                        int n1 = Convert.ToInt32(Funcoes.AESDecodifica(valor));

                        Setor set = SetorDB.Select(n1);

                        txbCodigo.Text = Convert.ToString(set.Set_cod);
                        txbDesc.Text = Convert.ToString(set.Set_descricao);
                        txbNome.Text = Convert.ToString(set.Set_nome);

                        txbNomeDepar.Text = set.Departamento.Dep_nome;
                    }
                }
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/paginas/ConsultaSetor.aspx");
    }

    protected void btnApagar_Click(object sender, EventArgs e)
    {
        Setor set = new Setor();

        set.Set_cod = Convert.ToInt32(txbCodigo.Text);
        set.Set_nome = txbNome.Text;
        set.Set_descricao = txbDesc.Text;

        switch (SetorDB.Excluir(set))
        {
            case 0:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>sucess();</script>", false);
                txbNome.Text = "";
                txbDesc.Text = "";
                txbCodigo.Text = "";
                txbNomeDepar.Text = "";
                break;
            case -2:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                break;
        }
    }
}