using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wistoll.Funcoes;

using System.Data;

public partial class paginas_ConsultaSetor : System.Web.UI.Page
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
                    if (pagina == "ConsultaSetor.aspx")
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
                    ativo = "Inativo";
                }
                else
                {
                    ativo = "Ativo";
                }

                DataSet ds = new DataSet();
                ds = SetorDB.Consulta(ativo);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string atualizar = "";
                    string desativar = "";
                    string ativar = "";
                    
                    if(Convert.ToString(dr["set_ativo"]) != "Inativo")
                    {
                        ds = ModuloDB.ModuloUsuario(fmp.Funcionario.Fun_cod);
                        foreach (DataRow dr1 in ds.Tables[0].Rows)
                        {
                            if (dr1["mod_descricao"].Equals("Editar Setor"))
                            {
                                atualizar = "<a href='../paginas/AlterarSetor.aspx?str=" + Funcoes.AESCodifica(Convert.ToString(dr["set_cod"])) + "&dto=" + Funcoes.AESCodifica(Convert.ToString(dr["dep_cod"])) + "'>" +
                                                "<button type='button' class='btn btn-primary btn-xs'>" +
                                                    " <i class='fa fa-edit'></i> Atualizar" +
                                                "</button>" +
                                            "</a>";
                                break;
                            }
                        }

                        foreach (DataRow dr2 in ds.Tables[0].Rows)
                        {
                            if (dr2["mod_descricao"].Equals("Desativar Setor"))
                            {
                                desativar += "<button type='button' class='btn btn-primary btn-xs' data-toggle='modal' data-target='#myModalDesativar'>" +
                                                    " <i class='fa fa-trash'></i> Excluir" +
                                             "</button>";
                                break;
                            }
                        }
                    }
                    else
                    {
                        ds = ModuloDB.ModuloUsuario(fmp.Funcionario.Fun_cod);
                        foreach (DataRow dr1 in ds.Tables[0].Rows)
                        {
                            if (dr1["mod_descricao"].Equals("Editar Departamento"))
                            {
                                ativar = "<button type='button' class='btn btn-primary btn-xs' data-toggle='modal' data-target='#myModalAtivar'>" +
                                                    " <i class='fa fa-check-circle'></i> Ativar" +
                                         "</button>";
                                break;
                            }
                        }
                    }
                        
                    ds = SetorDB.Consulta(ativo);
                    lbl.Text += "<div class='col-md-4 col-sm-4 col-xs-12 animated fadeInDown'>" +
                                    "<div class='well profile_view'>" +
                                        "<div class='col-sm-12'>" +
                                            "<div class='left col-xs-12'>" +
                                                "<h2>" + dr["set_nome"] + "</h2>" +
                                                "<ul class='list-unstyled'>" +
                                                    "<li>Codigo: " + dr["set_cod"] + "</li>" +
                                                    "<li>Departamento: " + dr["dep_nome"] + "</li>" +
                                                    "<li>Descrição: " + dr["set_descricao"] + "</li>" +
                                                    "<li><i class='fa fa-user'></i> Chefe do Setor: " + dr["nome"] + "</li>" +
                                                    "<li>Matrícula: " + dr["matricula"] + " </li> " +
                                                    "<br /><br />" +
                                                "</ul>" +
                                            "</div>" +
                                        "</div>" +
                                        "<div class='col-xs-12 bottom text-center'>" +
                                            atualizar + desativar + ativar +
                                        "</div>" +
                                    "</div>" +
                                "</div>" +

                                "<div class='modal fade' id='myModalDesativar' tabindex='- 1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>" +
                                            "<div class='modal-dialog' role='document'>" +
                                            "<div class='modal-content'>" +
                                              "<div class='modal-header'>" +
                                                "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
                                                  "<span aria-hidden='true'>&times;</span>" +
                                                "</button>" +
                                                "<h3 class='modal-title red' id='myModalLabel'>Aviso!</h3>" +
                                              "</div>" +
                                              "<div class='modal-body'>" +
                                                "<h2 class='text-center'>Tem certeza que deseja Excluir?</h2>" +
                                              "</div>" +
                                              "<div class='divider'></div>" +
                                              "<div class='col-xs-12 bottom text-right'>" +
                                                "<button type='button' class='btn btn-default' data-dismiss='modal'>Não</button>" +
                                                "<button type='button' class='btn btn-danger' onclick='desativar(" + dr["set_cod"] + ", " + fmp.Funcionario.Pessoa.Pes_cod + ")'>Sim</button>" +
                                              "</div>" +
                                            "</div>" +
                                          "</div>" +
                                        "</div>" +

                       "<div class='modal fade' id='myModalAtivar' tabindex='- 1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>" +
                                            "<div class='modal-dialog' role='document'>" +
                                            "<div class='modal-content'>" +
                                              "<div class='modal-header'>" +
                                                "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
                                                  "<span aria-hidden='true'>&times;</span>" +
                                                "</button>" +
                                                "<h3 class='modal-title red' id='myModalLabel'>Aviso!</h3>" +
                                              "</div>" +
                                              "<div class='modal-body'>" +
                                                "<h2 class='text-center'>Tem certeza que deseja Ativar?</h2>" +
                                              "</div>" +
                                              "<div class='divider'></div>" +
                                              "<div class='col-xs-12 bottom text-right'>" +
                                                "<button type='button' class='btn btn-default' data-dismiss='modal'>Não</button>" +
                                                "<button type='button' class='btn btn-danger' onclick='ativar(" + dr["set_cod"] + ", " + fmp.Funcionario.Pessoa.Pes_cod + ")'>Sim</button>" +
                                              "</div>" +
                                            "</div>" +
                                          "</div>" +
                                        "</div>";
                }

                if (lbl.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>info();</script>", false);
                }
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    [System.Web.Services.WebMethod]
    public static void Ativar(int fun, string codigo)
    {
        Setor set = new Setor();

        set.Set_cod = Convert.ToInt32(codigo);
        set.Cod_fun = fun;

        SetorDB.Ativar(set);
    }

    [System.Web.Services.WebMethod]
    public static void Desativar(int fun, string codigo)
    {
        Setor set = new Setor();

        set.Set_cod = Convert.ToInt32(codigo);
        set.Cod_fun = fun;

        SetorDB.Excluir(set);
    }
}