using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wistoll.Funcoes;

public partial class paginas_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];

        if (Session["funcionario"] != null)
        {

            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                string pagina = "";
                int n = 0;
                ds = FunModDB.SelectMenu(fmp.Funcionario.Fun_cod);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    pagina = dr["mod_pagina"].ToString();
                    if (pagina == "Admin.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }

                if (Session["teste"] != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>dark('" + fmp.Funcionario.Pessoa.Pes_nome + "');</script>", false);
                }

                Session["teste"] = null;

                //Carregar Processos
                CarregarProcessos();

                //Carregar Usuarios
                CarregarUsuarios();
                CarregarUsuariosInativos();

                //Carrega Requerentes
                CarregarRequerentes();
                CarregarRequerentesInativos();

                //Carregar Departamento
                CarregarDepartamento();
                CarregarDepartamentoInativo();

                //Carregar Setor
                CarregarSetor();
                CarregarSetorInativo();
            }
        }
    }

    protected void CarregarProcessos()
    {
        DataSet ds = new DataSet();
        ds = ProcessoDB.CountProcessos();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            string simbolo = "";
            string caminho = "";
            string cor = "";
            string borda = "";
            string noti = "";

            if (dr["sta_valor"].Equals("Deferido"))
            {
                simbolo = "'green fa fa-gavel'";
                caminho = "'../paginas/ProcessosDeferidos.aspx'";
                cor = "'green'";
                borda = "'pull-right border-green profile_thumb'";
                noti = "'left badge bg-green'";
            }

            if (dr["sta_valor"].Equals("Indeferido"))
            {
                simbolo = "'red fa fa-times'";
                caminho = "'../paginas/ProcessosIndeferidos.aspx'";
                cor = "'red'";
                borda = "'pull-right border-red profile_thumb'";
                noti = "'left badge bg-red'";
            }

            if (dr["sta_valor"].Equals("Pendente"))
            {
                simbolo = "'purple warning fa fa-spinner'";
                caminho = "'../paginas/ProcessosPendentes.aspx'";
                cor = "'purple'";
                borda = "'pull-right border-purple profile_thumb'";
                noti = "'left badge bg-purple'";
            }

            if (dr["sta_valor"].Equals("Finalizado"))
            {
                simbolo = "'black fa fa-check'";
                caminho = "'../paginas/ProcessosFinalizados.aspx'";
                cor = "'black'";
                borda = "'pull-right border-black profile_thumb'";
                noti = "'left badge bg-primary'";
            }

            lblProcessos.Text += "<div class='animated flipInY col-lg-3 col-md-3 col-sm-12 col-xs-12'>" +
                                    "<div class='tile-stats media event'>" +
                                        "<h2 class=" + borda + ">" +
                                            "<i class=" + simbolo + "><span class=" + noti + ">" + dr["count(pro_cod)"] + "</span></i>" +
                                        "</h2>" +      
                                        "<center><br/><h1><a class=" + cor +" href=" + caminho + ">" + dr["sta_valor"] + "s</a></h1><center>" +                                            
                                     "</div>" +
                                  "</div>";


            //lblProcessos.Text += "<div class='animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
            //                "<div class='tile-stats'>" +
            //                    "<div class='icon'>" +
            //                        "<i class=" + simbolo + "></i>" +
            //                    "</div>" +
            //                    "<div class='count'>" + dr["count(pro_cod)"] + "</div>" +
            //                    "<h3><a href='#'>" + dr["sta_valor"] + "</a></h3>" +
            //                    "<p></p>" +
            //                "</div>" +
            //            "</div>";


        }
    }

    protected void CarregarUsuarios()
    {
        DataSet ds = new DataSet();
        ds = FuncionarioDB.CountUsuarios();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            string perfil = Convert.ToString(dr["pfl_descricao"]);

            lblUsuarios.Text += "<div class='animated flipInY col-lg-3 col-md-3 col-sm-12 col-xs-12'>" +
                                    "<div class='tile-stats media event'>" +
                                        "<h2 class='pull-right border-aero profile_thumb'>" +
                                            "<i class='aero fa fa-user'><span class='left badge bg-orange'>" + dr["count(fun_cod)"] + "</span></i>" +
                                        "</h2>" +
                                        "<center><br/><h3><a class='title aero' href='../paginas/ConsultaUsuario.aspx?tip=" + 
                                        Funcoes.AESCodifica(perfil) + "'>" +
                                            dr["pfl_descricao"] + "</a></h3><center><br/>" +
                                     "</div>" +
                                  "</div>";

            //lblUsuarios.Text += "<div class='animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
            //                "<div class='tile-stats'>" +
            //                    "<div class='icon'>" +
            //                        "<i class='fa fa-user'></i>" +
            //                    "</div>" +
            //                    "<div class='count'>" + dr["count(fun_cod)"] + "</div>" +
            //                    "<h3><a href='../paginas/ConsultaUsuario.aspx'>" + dr["pfl_descricao"] + "</a></h3>" +
            //                    "<p></p>" +
            //                "</div>" +
            //            "</div>";

        }
    }

    protected void CarregarUsuariosInativos()
    {
        DataSet ds = new DataSet();
        ds = FuncionarioDB.CountUsuariosInativo();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            lblUsuariosInativos.Text += "<div class='animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
                            "<div class='tile-stats'>" +
                                "<div class='icon'>" +
                                    "<i class='fa fa-user'></i>" +
                                "</div>" +
                                "<div class='count'>" + dr["count(fun_cod)"] + "</div>" +
                                "<h3><a href='../paginas/ConsultaUsuario.aspx?par=" + Funcoes.AESCodifica("Inativo") + "'>Usuário</a></h3>" +
                                "<p></p>" +
                            "</div>" +
                        "</div>";

        }
    }

    protected void CarregarRequerentes()
    {
        DataSet ds = new DataSet();
        ds = RequerenteDB.CountRequerentes();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            lblRequerentes.Text += "<div class='animated flipInY col-lg-3 col-md-3 col-sm-12 col-xs-12'>" +
                                    "<div class='tile-stats media event'>" +
                                        "<h2 class='pull-right border-aero profile_thumb'>" +
                                            "<i class='aero fa fa-user'><span class='left badge bg-orange'>" + dr["count(req_cod)"] + "</span></i>" +
                                        "</h2>" +
                                        "<center><br/><h3><a class='title aero' href='../paginas/ConsultaRequerente.aspx?par=" + Funcoes.AESCodifica("Ativo") + "'>Requerente</a></h3><center><br/>" +
                                     "</div>" +
                                  "</div>";

            //lblRequerente.Text += "<div class='animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
            //                "<div class='tile-stats'>" +
            //                    "<div class='icon'>" +
            //                        "<i class='fa fa-user'></i>" +
            //                    "</div>" +
            //                    "<div class='count'>" + dr["count(req_cod)"] + "</div>" +
            //                    "<h3><a href='../paginas/ConsultaRequerente.aspx'>Requerente</a></h3>" +
            //                    "<p></p>" +
            //                "</div>" +
            //            "</div>";

        }
    }

    protected void CarregarRequerentesInativos()
    {
        DataSet ds = new DataSet();
        ds = RequerenteDB.CountRequerentesInativos();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            lblRequerentesInativos.Text += "<div class='animated flipiny col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
                            "<div class='tile-stats'>" +
                                "<div class='icon'>" +
                                    "<i class='fa fa-user'></i>" +
                                "</div>" +
                                "<div class='count'>" + dr["count(req_cod)"] + "</div>" +
                                "<h3><a href='../paginas/ConsultaRequerente.aspx?par=" + Funcoes.AESCodifica("Inativo") + "'>Requerente</a></h3>" +
                                "<p></p>" +
                            "</div>" +
                        "</div>";

        }
    }

    protected void CarregarDepartamento()
    {
        DataSet ds = new DataSet();
        ds = DepartamentoDB.CountDepartamento();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {

            lblDepartamento.Text += "<p/><div class='animated flipInY col-lg-3 col-md-3 col-sm-12 col-xs-12'>" +
                                    "<div class='tile-stats media event'>" +
                                        "<a class='pull-right border-aero profile_thumb'>" +
                                            "<i class='blue fa fa-tasks'></i><span class='left badge bg-blue'>" + dr["count(dep_cod)"] + "</span>" +
                                        "</a>" +
                                        "<center><br/><h3><a class='title blue' href='../paginas/ConsultaDepartamento.aspx'>Departamento</a></h3><center><br/>" +
                                     "</div>" +
                                  "</div>";

            //lblDepartamento.Text += "<div class='animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
            //                "<div class='tile-stats'>" +
            //                    "<div class='icon'>" +
            //                        "<i class='fa fa-bank'></i>" +
            //                    "</div>" +
            //                    "<div class='count'>" + dr["count(dep_cod)"] + "</div>" +
            //                    "<h3><a href='../paginas/ConsultaDepartamento.aspx'>Departamento</a></h3>" +
            //                    "<p></p>" +
            //                "</div>" +
            //            "</div>";

        }
    }

    protected void CarregarDepartamentoInativo()
    {
        DataSet ds = new DataSet();
        ds = DepartamentoDB.CountDepartamentoInativo();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            lblDepartamentoInativo.Text += "<div class='animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
                            "<div class='tile-stats'>" +
                                "<div class='icon'>" +
                                    "<i class='fa fa-tasks'></i>" +
                                "</div>" +
                                "<div class='count'>" + dr["count(dep_cod)"] + "</div>" +
                                "<h3><a href='../paginas/ConsultaDepartamento.aspx?par=" + 
                                Funcoes.AESCodifica("Inativo") + "'>Departamento</a></h3>" +
                                "<p></p>" +
                            "</div>" +
                        "</div>";
        }
    }

    protected void CarregarSetor()
    {
        DataSet ds = new DataSet();
        ds = SetorDB.CountSetor();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            lblSetor.Text += "<p/><div class='animated flipInY col-lg-3 col-md-3 col-sm-12 col-xs-12'>" +
                                    "<div class='tile-stats media event'>" +
                                        "<a class='pull-right border-aero profile_thumb'>" +
                                            "<i class='blue fa fa-tasks'></i><span class='left badge bg-blue'>" + dr["count(set_cod)"] + "</span>" +
                                        "</a>" +
                                        "<center><br/><h3><a class='title blue' href='../paginas/ConsultaSetor.aspx'>Setor</a></h3><center><br/>" +
                                     "</div>" +
                                  "</div>";


            //lblSetor.Text += "<div class='animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
            //                "<div class='tile-stats'>" +
            //                    "<div class='icon'>" +
            //                        "<i class='fa fa-bank'></i>" +
            //                    "</div>" +
            //                    "<div class='count'>" + dr["count(set_cod)"] + "</div>" +
            //                    "<h3><a href='../paginas/ConsultaSetor.aspx'>Setor</a></h3>" +
            //                    "<p></p>" +
            //                "</div>" +
            //            "</div>";

        }
    }

    protected void CarregarSetorInativo()
    {
        DataSet ds = new DataSet();
        ds = SetorDB.CountSetorInativo();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            lblSetorInativo.Text += "<div class='animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
                            "<div class='tile-stats'>" +
                                "<div class='icon'>" +
                                    "<i class='fa fa-tasks'></i>" +
                                "</div>" +
                                "<div class='count'>" + dr["count(set_cod)"] + "</div>" +
                                "<h3><a href='../paginas/ConsultaSetor.aspx?par=" +
                                Funcoes.AESCodifica("Inativo") + "'>Setor</a></h3>" +
                                "<p></p>" +
                            "</div>" +
                        "</div>";

        }
    }
}