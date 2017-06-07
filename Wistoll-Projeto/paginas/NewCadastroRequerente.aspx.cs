using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_NewCadastroRequerente : System.Web.UI.Page
{
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
                    if (pagina == "NewCadastroRequerente.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    protected void btnApagarJur_ServerClick(object sender, EventArgs e)
    {
        txbNomeJur.Text = "";
        txbDataNascJur.Text = "";
        txbSiglaJur.Text = "";
        txbRazaoSocialJur.Text = "";
        txbCnpjJur.Text = "";
        ddlTipoContatoJur.SelectedIndex = 0;
        txbCepJur.Text = "";
        ddlEstadoJur.SelectedIndex = 0;
        txbCidadeJur.Text = "";
        txbBairroJur.Text = "";
        txbRuaJur.Text = "";
        txbNumeroJur.Text = "";
        txbComplementoJur.Text = "";
    }

    protected void btnSalvarJur_ServerClick(object sender, EventArgs e)
    {
        FunMod funCod = (FunMod)Session["funcionario"];

        if (txbNomeJur.Text != "" && txbDataNascJur.Text != "" && txbSiglaJur.Text != "" && txbRazaoSocialJur.Text != "" && txbCnpjJur.Text != "" && ddlEstadoJur.SelectedIndex != 0 && txbCepJur.Text != "" && txbCidadeJur.Text != "" && txbBairroJur.Text != "" && txbRuaJur.Text != "" && txbNumeroJur.Text != "" && txbComplementoJur.Text != "")
        {
            string[] listaContato = Request.Form.GetValues("lbTabelaJur");


            if (listaContato != null)
            {
                Requerente req = new Requerente();
                Pessoa pes = new Pessoa();
                req.Pessoa = pes;

                req.Pessoa.Cod_fun = funCod.Funcionario.Pessoa.Pes_cod;
                req.Cod_fun = funCod.Funcionario.Pessoa.Pes_cod;
                req.Pessoa.Pes_tipo = "Juridica";
                req.Pessoa.Pes_ativo = "Ativo";
                req.Pessoa.Pes_nome = txbNomeJur.Text;
                req.Pessoa.Pes_sobrenome = null;
                req.Pessoa.Pes_razaoSocial = txbRazaoSocialJur.Text;
                req.Pessoa.Pes_dataNascimento = txbDataNascJur.Text;
                req.Pessoa.Pes_sexo = null;
                req.Pessoa.Pes_cnpj = txbCnpjJur.Text;
                req.Pessoa.Pes_sigla = txbSiglaJur.Text;

                string contatos = "";
                for (int i = 0; i < listaContato.Length; i++)
                {
                    contatos += "(0, '" + listaContato[i].Split('|')[0] + "', '" + listaContato[i].Split('|')[1] + "', 'pes_con', " + funCod.Funcionario.Pessoa.Pes_cod + "),";
                }
                contatos = contatos.Substring(0, contatos.Length - 1);

                req.Pessoa.Pes_cep = txbCepJur.Text;
                req.Pessoa.Pes_estado = ddlEstadoJur.SelectedValue;
                req.Pessoa.Pes_cidade = txbCidadeJur.Text;
                req.Pessoa.Pes_bairro = txbBairroJur.Text;
                req.Pessoa.Pes_rua = txbRuaJur.Text;
                req.Pessoa.Pes_numero = txbNumeroJur.Text;
                req.Pessoa.Pes_complemento = txbComplementoJur.Text;

                string retorno = RequerenteDB.Insert(req, contatos);

                if (retorno != "Erro ao chamar procedure")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>sucess();</script>", false);
                    txbNomeJur.Text = "";
                    txbDataNascJur.Text = "";
                    txbSiglaJur.Text = "";
                    txbRazaoSocialJur.Text = "";
                    txbCnpjJur.Text = "";
                    ddlTipoContatoJur.SelectedIndex = 0;
                    txbCepJur.Text = "";
                    ddlEstadoJur.SelectedIndex = 0;
                    txbCidadeJur.Text = "";
                    txbBairroJur.Text = "";
                    txbRuaJur.Text = "";
                    txbNumeroJur.Text = "";
                    txbComplementoJur.Text = "";
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                    ddlTipoContatoJur.SelectedIndex = 0;
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning1();</script>", false);
                ddlTipoContatoJur.SelectedIndex = 0;
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning();</script>", false);
            ddlTipoContatoJur.SelectedIndex = 0;
        }
    }

    protected void btnApagarFis_ServerClick(object sender, EventArgs e)
    {
        txbNomeFis.Text = "";
        txbSobrenomeFis.Text = "";
        txbDataNascFis.Text = "";
        rblSexoFis.SelectedValue = "M";
        txbCpfFis.Text = "";
        txbRgFis.Text = "";
        ddlTipoContatoFis.SelectedIndex = 0;
        txbCepFis.Text = "";
        ddlEstadoFis.SelectedIndex = 0;
        txbCidadeFis.Text = "";
        txbBairroFis.Text = "";
        txbRuaFis.Text = "";
        txbNumeroFis.Text = "";
        txbComplementoFis.Text = "";
    }

    protected void btnSalvarFis_ServerClick(object sender, EventArgs e)
    {
        FunMod funCod = (FunMod)Session["funcionario"];

        if (txbNomeFis.Text != "" && txbSobrenomeFis.Text != "" && txbDataNascFis.Text != "" && txbCpfFis.Text != "" && txbRgFis.Text != "" && txbCepFis.Text != "" && ddlEstadoFis.SelectedIndex != 0 && txbCidadeFis.Text != "" && txbBairroFis.Text != "" && txbRuaFis.Text != "" && txbNumeroFis.Text != "")
        {
            string[] listaContato = Request.Form.GetValues("lbTabelaFis");


            if (listaContato != null)
            {
                Requerente req = new Requerente();
                Pessoa pes = new Pessoa();
                req.Pessoa = pes;

                req.Pessoa.Cod_fun = funCod.Funcionario.Pessoa.Pes_cod;
                req.Cod_fun = funCod.Funcionario.Pessoa.Pes_cod;
                req.Pessoa.Pes_tipo = "Fisica";
                req.Pessoa.Pes_ativo = "Ativo";
                req.Pessoa.Pes_nome = txbNomeFis.Text;
                req.Pessoa.Pes_sobrenome = txbSobrenomeFis.Text;
                req.Pessoa.Pes_dataNascimento = txbDataNascFis.Text;
                req.Pessoa.Pes_sexo = rblSexoFis.Text;
                req.Pessoa.Pes_cpf = txbCpfFis.Text;
                req.Pessoa.Pes_rg = txbRgFis.Text;

                string contatos = "";
                for (int i = 0; i < listaContato.Length; i++)
                {
                    contatos += "(0, '" + listaContato[i].Split('|')[0] + "', '" + listaContato[i].Split('|')[1] + "', 'pes_con', " + funCod.Funcionario.Pessoa.Pes_cod + "),";
                }
                contatos = contatos.Substring(0, contatos.Length - 1);

                req.Pessoa.Pes_cep = txbCepFis.Text;
                req.Pessoa.Pes_estado = ddlEstadoFis.SelectedValue;
                req.Pessoa.Pes_cidade = txbCidadeFis.Text;
                req.Pessoa.Pes_bairro = txbBairroFis.Text;
                req.Pessoa.Pes_rua = txbRuaFis.Text;
                req.Pessoa.Pes_numero = txbNumeroFis.Text;
                req.Pessoa.Pes_complemento = txbComplementoFis.Text;

                string retorno = RequerenteDB.Insert(req, contatos);

                if (retorno != "Erro ao chamar procedure")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>sucess();</script>", false);
                    txbNomeFis.Text = "";
                    txbSobrenomeFis.Text = "";
                    txbDataNascFis.Text = "";
                    rblSexoFis.SelectedValue = "M";
                    txbCpfFis.Text = "";
                    txbRgFis.Text = "";
                    ddlTipoContatoFis.SelectedIndex = 0;
                    txbCepFis.Text = "";
                    ddlEstadoFis.SelectedIndex = 0;
                    txbCidadeFis.Text = "";
                    txbBairroFis.Text = "";
                    txbRuaFis.Text = "";
                    txbNumeroFis.Text = "";
                    txbComplementoFis.Text = "";
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                    ddlTipoContatoFis.SelectedIndex = 0;
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning1();</script>", false);
                ddlTipoContatoFis.SelectedIndex = 0;
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning();</script>", false);
            ddlTipoContatoFis.SelectedIndex = 0;
        }
    }

    protected void ddlTipoPessoa_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddlTipoPessoa.SelectedValue)
        {
            case "0":
                mlv.ActiveViewIndex = 0;
                break;
            case "1":
                mlv.ActiveViewIndex = 1;
                break;
            case "2":
                mlv.ActiveViewIndex = 2;
                break;
        }
    }
}