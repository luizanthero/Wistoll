using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class paginas_NewCadastroSetor : System.Web.UI.Page
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
                    if (pagina == "NewCadastroSetor.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }

                //DataSet ds = SetorDB.SelectAllChefe();
                //ddlMatricula.DataSource = ds;
                //ddlMatricula.DataTextField = "pes_nome";
                //// Nome da coluna do Banco de dados 
                //ddlMatricula.DataValueField = "fun_cod";
                //// ID da coluna do Banco 
                //ddlMatricula.DataBind();
                //ddlMatricula.Items.Insert(0, "Selecione");

                //DropDownLiist para o nome do Departamento

                DataSet ds2 = SetorDB.SelectDepartamento(); ;
                ddlDepartamento.DataSource = ds2;
                ddlDepartamento.DataTextField = "dep_nome";
                // Nome da coluna do Banco de dados 
                ddlDepartamento.DataValueField = "dep_cod";
                // ID da coluna do Banco 
                ddlDepartamento.DataBind();
                ddlDepartamento.Items.Insert(0, "Selecione");
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

        if ((txbNome.Text != "") && (ddlDepartamento.SelectedIndex != 0))
        {

            Setor set = new Setor();
            Departamento dep = new Departamento();

            set.Set_nome = txbNome.Text;
            set.Set_descricao = txbDesc.Text;

            int dep_cod = Convert.ToInt32(ddlDepartamento.SelectedValue);
            set.Departamento = dep;
            set.Departamento.Dep_cod = dep_cod;

            switch (SetorDB.Insert(set))
            {
                case 0:
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>sucess();</script>", false);
                    break;

                case -2:
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                    break;
            }

            txbNome.Text = "";
            txbDesc.Text = "";
            //ddlMatricula.SelectedIndex = 0;
            ddlDepartamento.SelectedIndex = 0;

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
        //ddlMatricula.SelectedIndex = 0;
        ddlDepartamento.SelectedIndex = 0;

    }
}