using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wistoll.Funcoes;
using System.Data;

public partial class paginas_Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];

        if (Session["funcionario"] != null)
        {

            if (!IsPostBack)
            {
                DataSet ds2 = new DataSet();
                string pagina = "";
                int n = 0;
                ds2 = FunModDB.SelectMenu(fmp.Funcionario.Fun_cod);
                foreach (DataRow dr in ds2.Tables[0].Rows)
                {
                    pagina = dr["mod_pagina"].ToString();
                    if (pagina == "Index.aspx")
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
                DataSet ds1 = new DataSet();
                ds1 = ProcessoDB.CountProcessos();
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {

                    string simbolo = "";
                    string obs = "";
                    string caminho = "";

                    if (dr["sta_valor"].Equals("Deferido"))
                    {

                        simbolo = "'fa fa-gavel'";
                        obs = "Atenderam os requisitos";
                        caminho = "'../paginas/ProcessosDeferidos.aspx'";

                    }

                    if (dr["sta_valor"].Equals("Indeferido"))
                    {

                        simbolo = "'fa fa-times'";
                        obs = "Necessita novas informações";
                        caminho = "'../paginas/ProcessosIndeferidos.aspx'";

                    }

                    if (dr["sta_valor"].Equals("Pendente"))
                    {

                        simbolo = "'fa fa-spinner'";
                        obs = "Esperando a aprovação";
                        caminho = "'../paginas/ProcessosPendentes.aspx'";

                    }

                    if (dr["sta_valor"].Equals("Finalizado"))
                    {

                        simbolo = "'fa fa-check-circle-o'";
                        obs = "Enviados para o arquivo";
                        caminho = "'../paginas/ProcessosFinalizados.aspx'";

                    }

                    lblProcessos.Text += "<div class='animated flipInY col-lg-3 col-md-3 col-sm-6 col-xs-12'>" +
                                    "<div class='tile-stats'>" +
                                        "<div class='icon'>" +
                                            "<i class=" + simbolo + "></i>" +
                                        "</div>" +
                                        "<div class='count'>" + dr["count(pro_cod)"] + "</div>" +
                                        "<h3><a href=" + caminho +">" + dr["sta_valor"] + "s</a></h3>" +
                                        "<p>" + obs + "</p>" +
                                    "</div>" +
                                "</div>";

                }

                //Carregar Processos por Usuário
                DataSet ds = new DataSet();
                ds = ProcessoDB.SelectIndex(fmp.Funcionario.Pessoa.Pes_nome);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    int porcent = 0;
                    string obs = "";

                    if (dr["staValor"].Equals("Indeferido"))
                    {
                        porcent = 100;
                        obs = "Processo Indefirido!";
                    }
                    else if (dr["staValor"].Equals("Pendente"))
                    {
                        porcent = 1;
                        obs = "Processo requer um parecer!";
                    }
                    else if (dr["staValor"].Equals("Deferido"))
                    {
                        porcent = 50;
                        obs = "Seu processo foi aprovado!";
                    }
                    else if (dr["staValor"].Equals("Finalizado"))
                    {
                        porcent = 100;
                        obs = "Processo Finalizado!";
                    }

                    lblStatus.Text += "<div class='col-md-3 col-xs-12 widget widget_tally_box'>" +
                            "<a href='../paginas/Process.aspx?pro=" + Funcoes.AESCodifica(dr["numeroProcesso"].ToString()) + "'>" +
                                "<div class='x_panel'>" +
                                    "<div class='x_title'>" +
                                        "<h2>" + dr["numeroProcesso"] + "</h2>" +
                                        "<div class='clearfix'></div>" +
                                    "</div>" +
                                    "<div class='x_content'>" +
                                        "<div style = 'text-align: center; margin-bottom: 17px'>" +
                                            "<span class='chart' data-percent='" + porcent + "'>" +
                                                "<span class='percent'></span>" +
                                            "</span>" +
                                        "</div>" +
                                        "<div>" +
                                            "<h3 class='name_title'>" + dr["modelo"] + "</h3>" +
                                            "<div class='divider'></div>" +
                                            "<p>" + obs + "</p>" +
                                            "<p>Nome do Redator: " + dr["redator"] + " Matrícula: " + dr["matriculaRed"] + "</p>" +
                                            "<p>Status do Processo: " + dr["staValor"] + "</p>" +
                                        "</div>" +
                                    "</div>" +
                                "</div>" +
                            "</a>" +
                        "</div>";
                }
            }
        }
        else
        {
            Session["info"] = 0;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }
}