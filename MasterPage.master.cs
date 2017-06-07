using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Wistoll.Funcoes;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];

        if (Session["funcionario"] != null)
        {
            if (!Page.IsPostBack)
            {
                //Carregar Informações de Usuário
                lblNome.Text = fmp.Funcionario.Pessoa.Pes_nome;
                lblNome1.Text = fmp.Funcionario.Pessoa.Pes_nome;
                lblPerfil.Text = fmp.Funcionario.Perfil.Pfl_descricao;

                if (fmp.Funcionario.Perfil.Pfl_descricao.Equals("Administrador"))
                {
                    lblLogo.Text = "<a href='../paginas/Admin.aspx' class='site_title'><i class='wi fa-paw'></i><span>Wistoll</span></a>";
                    lblPrincipal.Text = "<a href='../paginas/Admin.aspx'><i class='fa fa-home'></i>Principal </a>";
                }
                else
                {
                    lblLogo.Text = "<a href='../paginas/Index.aspx' class='site_title'><i class='wi fa-paw'></i><span>Wistoll</span></a>";
                    lblPrincipal.Text = "<a href='../paginas/Index.aspx'><i class='fa fa-home'></i>Principal </a>";
                }

                //Carregar Menu
                DataSet ds = new DataSet();
                string cadastrar = "";
                string consultar = "";
                string imprimir = "";
                ds = FunModDB.SelectMenu(fmp.Funcionario.Fun_cod);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cadastrar = dr["mod_descricao"].ToString();
                    if (cadastrar.Substring(0, 9) == "Cadastrar")
                    {
                        lblCadastrar.Text += "<li><a href='../paginas/" + dr["mod_pagina"] + "'>" + dr["mod_descricao"] + "</a></li>";
                    }

                    consultar = dr["mod_descricao"].ToString();
                    if (consultar.Substring(0, 9) == "Consultar")
                    {
                        lblConsultar.Text += "<li><a href='../paginas/" + dr["mod_pagina"] + "'>" + dr["mod_descricao"] + "</a></li>";
                    }

                    imprimir = dr["mod_descricao"].ToString();
                    if (consultar.Substring(0, 8) == "Imprimir")
                    {
                        lblImprimir.Text += "<li><a href='../paginas/" + dr["mod_pagina"] + "'>" + dr["mod_descricao"] + "</a></li>";
                    }
                }

                //Carregar Imagem de Perfil

                Perfil pfl = PerfilDB.Select(fmp.Funcionario.Perfil.Pfl_cod);

                string imagem = pfl.Pfl_imagem;

                lblImagem.Text = "<img src='" + pfl.Pfl_imagem + "' alt='...' class='img-circle profile_img' />";
                lblImagem1.Text = "<img src='" + pfl.Pfl_imagem + "' alt='' />";
            }
        }
        else
        {
            Session["info"] = 0;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    protected void Sair_Click(object sender, EventArgs e)
    {
        Session["info"] = null;
        //encerra a sessão como um todo
        Session.Abandon();
        Session.RemoveAll();
        Response.Redirect("~/paginas/Login.aspx");
        //Response.Redirect("~/paginas/Erro/Erro500.aspx");
    }
}
