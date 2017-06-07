using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wistoll.Funcoes;

public partial class paginas_AlterarDepartamento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];

        if(Session["funcionario"] != null)
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
                    if (pagina == "AlterarDepartamento.aspx")
                    {
                        n = 1;
                        break;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/ConsultaDepartamento.aspx");
                }

                Decodificar();
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    protected void Decodificar()
    {
        if (Request.QueryString["dto"] != null)
        {
            if (Request.QueryString["dto"].ToString() != "")
            {

                try
                {
                    string depar = Request.QueryString["dto"].ToString().Replace(" ", "+");
                    int n1 = Convert.ToInt32(Funcoes.AESDecodifica(depar));

                    Departamento dep = DepartamentoDB.Select(n1);

                    txbCodigo.Text = Convert.ToString(dep.Dep_cod);
                    txbDesc.Text = Convert.ToString(dep.Dep_descricao);
                    txbNome.Text = Convert.ToString(dep.Dep_nome);
                }
                catch (Exception erro)
                {
                    Response.Redirect("~/Paginas/ConsultaDepartamento.aspx");
                }
            }
        }
    }

    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];

        if (txbNome.Text != "")
        {
            Departamento dep = new Departamento();

            dep.Dep_cod = Convert.ToInt32(txbCodigo.Text);
            dep.Dep_nome = txbNome.Text;
            dep.Dep_descricao = txbDesc.Text;
            dep.Cod_fun = fmp.Funcionario.Pessoa.Pes_cod;

            switch (DepartamentoDB.Atualizar(dep))
            {
                case 0:
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>sucess();</script>", false);
                    txbNome.Text = "";
                    txbDesc.Text = "";
                    txbCodigo.Text = "";
                    break;

                case -2:
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                    break;
            }            

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning();</script>", false);
        }
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/paginas/ConsultaDepartamento.aspx");
    }
}