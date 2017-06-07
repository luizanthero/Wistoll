using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class paginas_CadastroDepartamento : System.Web.UI.Page
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
                    if (pagina == "NewCadastroDepartamento.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }

                //DataSet ds = DepartamentoDB.SelectAllChefe();
                //ddlMatricula.DataSource = ds;
                //ddlMatricula.DataTextField = "pes_nome";
                //// Nome da coluna do Banco de dados 
                //ddlMatricula.DataValueField = "fun_cod";
                //// ID da coluna do Banco 
                //ddlMatricula.DataBind();
                //ddlMatricula.Items.Insert(0, "Selecione");
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }


    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        if (txbNome.Text != "")
        {

            Departamento dep = new Departamento();

            dep.Dep_nome = txbNome.Text;
            dep.Dep_descricao = txbDesc.Text;

            switch (DepartamentoDB.Insert(dep))
            {
                case 0:
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>sucess();</script>", false);
                    txbNome.Text = "";
                    txbDesc.Text = "";
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

    protected void btnApagar_Click(object sender, EventArgs e)
    {

        txbNome.Text = "";
        txbDesc.Text = "";

    }
}