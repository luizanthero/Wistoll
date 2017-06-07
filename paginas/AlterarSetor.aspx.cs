using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wistoll.Funcoes;

public partial class paginas_AlterarSetor : System.Web.UI.Page
{
    FunMod fmp;

    protected void Page_Load(object sender, EventArgs e)
    {
        fmp = (FunMod)Session["funcionario"];

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
                    if (pagina == "AlterarSetor.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/Paginas/ConsultaSetor.aspx");
                }

                if (Request.QueryString["str"] != null && Request.QueryString["dto"] != null)
                {
                    if (Request.QueryString["str"].ToString() != "" && Request.QueryString["dto"].ToString() != "")
                    {

                        try
                        {
                            string setor = Request.QueryString["str"].ToString().Replace(" ", "+");
                            int n1 = Convert.ToInt32(Funcoes.AESDecodifica(setor));
                            string depar = Request.QueryString["dto"].ToString().Replace(" ", "+");
                            int n2 = Convert.ToInt32(Funcoes.AESDecodifica(depar));

                            Setor set = SetorDB.Select(n1);

                            txbCodigo.Text = Convert.ToString(set.Set_cod);
                            txbDesc.Text = Convert.ToString(set.Set_descricao);
                            txbNome.Text = Convert.ToString(set.Set_nome);
                            
                            //DropDownLiist para o nome do Departamento
                            DataSet ds2 = SetorDB.SelectDepartamento(); ;
                            ddlDepartamento.DataSource = ds2;
                            ddlDepartamento.DataTextField = "dep_nome";
                            // Nome da coluna do Banco de dados 
                            ddlDepartamento.DataValueField = "dep_cod";
                            // ID da coluna do Banco 
                            ddlDepartamento.DataBind();
                            ddlDepartamento.Items.Insert(0, "Selecione");
                            ddlDepartamento.SelectedValue = Convert.ToString(n2);
                        }
                        catch (Exception erro)
                        {
                            Response.Redirect("~/paginas/ConsultaSetor.aspx");
                        }
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
        txbNome.Text = "";
        txbDesc.Text = "";
        txbCodigo.Text = "";
    }

    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
        if (txbNome.Text != "")
        {
            Setor set = new Setor();
            Departamento dep = new Departamento();

            set.Set_cod = Convert.ToInt32(txbCodigo.Text);
            set.Set_nome = txbNome.Text;
            set.Set_descricao = txbDesc.Text;
            set.Cod_fun = fmp.Funcionario.Pessoa.Pes_cod;

            set.Departamento = dep;
            int dep_cod = Convert.ToInt32(ddlDepartamento.SelectedIndex);
            if(dep_cod == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning();</script>", false);
            }
            else
            {
                set.Departamento.Dep_cod = dep_cod;

                switch (SetorDB.Atualizar(set))
                {
                    case 0:
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>sucess();</script>", false);
                        txbNome.Text = "";
                        txbDesc.Text = "";
                        txbCodigo.Text = "";
                        ddlDepartamento.SelectedIndex = 0;
                        break;

                    case -2:
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                        break;
                }
            }

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning();</script>", false);
        }
    }
}