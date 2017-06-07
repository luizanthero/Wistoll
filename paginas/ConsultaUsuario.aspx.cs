using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wistoll.Funcoes;

public partial class paginas_ConsultaUsuario2 : System.Web.UI.Page
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
                    if (pagina == "ConsultaUsuario.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }

                string ativo = "";

                if (Request.QueryString["par"] != null && Request.QueryString["par"] != "")
                {
                    string par = Request.QueryString["par"].ToString().Replace(" ", "+");
                    ativo = Funcoes.AESDecodifica(par);
                }
                else
                {
                    ativo = "Ativo";
                }

                if (Request.QueryString["tip"] != null && Request.QueryString["tip"] != "")
                {
                    string tip = Request.QueryString["tip"].ToString().Replace(" ", "+");
                    ativo = Funcoes.AESDecodifica(tip);
                }

                CarregarUsuarios(ativo, fmp.Funcionario.Fun_cod);
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    public void CarregarUsuarios(string ativo, int fun_cod)
    {
        DataSet ds = new DataSet();
        Funcionario fun;
        Contato con;
        ds = FuncionarioDB.Consulta(ativo);
        foreach(DataRow dr in ds.Tables[0].Rows)
        {
            fun = FuncionarioDB.Select(Convert.ToInt32(dr["fun_cod"]));
            con = ContatoDB.Select(fun.Pessoa.Pes_cod);

            string visualizar = "";
            ds = ModuloDB.ModuloUsuario(fun_cod);
            foreach (DataRow dr1 in ds.Tables[0].Rows)
            {
                if (dr1["mod_descricao"].Equals("Editar Usuário"))
                {
                    visualizar = "<a href='../paginas/PerfilUsuarios.aspx?usu=" + Funcoes.AESCodifica(Convert.ToString(fun.Fun_cod)) + "'>" +
                                    "<button type='button' class='btn btn-primary btn-xs'>" +
                                        "<i class='fa fa-user'></i> Visualizar" +
                                    "</button>" +
                                 "</a>";
                    break;
                }
            }

            ds = FuncionarioDB.Consulta(ativo);
            lbl.Text += "<div class='col-md-4 col-sm-4 col-xs-12 animated fadeInDown'>" +
                        "<div class='well profile_view'>" +
                                    "<div class='col-sm-12'>" +
                                        "<h4 class='brief'><i>" + fun.Perfil.Pfl_descricao + "</i></h4>" +
                                        "<div class='left col-xs-10'>" +
                                            "<h2>" + fun.Pessoa.Pes_nome + " " + fun.Pessoa.Pes_sobrenome + "</h2>" +
                                            "<ul class='list-unstyled'>" +
                                                "<li><i class='fa fa-bank'></i> Setor: " + fun.Setor.Set_nome + "</li>" +
                                                "<li><i class='fa fa-bank'></i> Departamento: " + fun.Setor.Departamento.Dep_nome + "</li>" +
                                                "<li><i class='fa fa-phone'></i> " + con.Con_tipo + ": " + con.Con_valor + "</li>" +
                                                "<br /><br />" +    
                                            "</ul>" +
                                        "</div>" +
                                        "<div class='right col-xs-2 text-center'>" +
                                            "<img src = '" + fun.Perfil.Pfl_imagem + "' class='img-circle img-responsive' />" +
                                        "</div>" +
                                    "</div>" +
                                    "<div class='col-xs-12 bottom text-center'>" +
                                        "<div class='col-xs-12 bottom text-center'>" +
                                            visualizar +
                                        "</div>" +
                                    "</div>" +
                                "</div>" +
                            "</div>";
        }
    }
}