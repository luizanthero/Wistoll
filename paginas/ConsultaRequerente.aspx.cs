using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Wistoll.Funcoes;

public partial class paginas_ConsultaRequerente : System.Web.UI.Page
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
                    if (pagina == "ConsultaRequerente.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }
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

            CarregarRequerentes(ativo);

            if (lbl.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>info();</script>", false);
            }

        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }

    }
    public void CarregarRequerentes(string ativo)
    {
        FunMod fmp = (FunMod)Session["funcionario"];

        DataSet ds = new DataSet();
        Requerente req;
        Contato con;
        ds = RequerenteDB.Consulta(ativo);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            req = RequerenteDB.Select(Convert.ToInt32(dr["req_cod"]));
            con = ContatoDB.Select(req.Pessoa.Pes_cod);

            string tipo = req.Pessoa.Pes_tipo;

            string atualizar = "";
            string desativar = "";
            string ativar = "";

            if (Convert.ToString(dr["Pes_ativo"]) != "Inativo")
            {
                ds = ModuloDB.ModuloUsuario(fmp.Funcionario.Fun_cod);
                foreach (DataRow dr1 in ds.Tables[0].Rows)
                {
                    if (dr1["mod_descricao"].Equals("Editar Requerente"))
                    {
                        atualizar = "<a href='../paginas/AlterarRequerente.aspx?par=" + Funcoes.AESCodifica(tipo) + "&cod=" + Funcoes.AESCodifica(Convert.ToString(dr["pes_cod"])) + "'>" +
                                        "<button type='button' class='btn btn-primary btn-xs'>" +
                                            " <i class='fa fa-edit'></i> Atualizar" +
                                        "</button>" +
                                    "</a>";
                        break;
                    }
                }

                foreach (DataRow dr2 in ds.Tables[0].Rows)
                {
                    if (dr2["mod_descricao"].Equals("Desativar Requerente"))
                    {
                        desativar = "<button type='button' class='btn btn-primary btn-xs' data-toggle='modal' data-target='#myModalDesativar'>" +
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
                    if (dr1["mod_descricao"].Equals("Editar Requerente"))
                    {
                        ativar = "<button type='button' class='btn btn-primary btn-xs' data-toggle='modal' data-target='#myModalAtivar'>" +
                                    " <i class='fa fa-check-circle'></i> Ativar" +
                                 "</button>";
                        break;
                    }
                }
            }
            ds = RequerenteDB.Consulta(ativo);

            string contato = "";

            if (con.Con_tipo == "Email")
            {
                contato += "<li><i class='fa fa-envelope'></i> E-mail: " + con.Con_valor + "</li>";

            }
            else if (con.Con_tipo == "Telefone")
            {
                contato += "<li><i class='fa fa-phone'></i> Telefone: " + con.Con_valor + "</li>";
            }
            else if (con.Con_tipo == "Celular")
            {
                contato += "<li><i class='fa fa-mobile-phone'></i> Celular: " + con.Con_valor + "</li>";
            }

            string documento = "", titulo = ""; ;

            if(req.Pessoa.Pes_tipo != "Fisica")
            {
                documento = "<li><i class='fa fa-user'></i> CNPJ: " + req.Pessoa.Pes_cnpj + "</li>";
                titulo = "<h4 class='brief'><i>Empresa</i></h4>";
            }
            else
            {
                documento = "<li><i class='fa fa-user'></i> CPF: " + req.Pessoa.Pes_cpf + "</li>";
                titulo = "<h4 class='brief'><i>Pessoa</i></h4>";
            }

            lbl.Text += "<div class='col-md-4 col-sm-4 col-xs-12 animated fadeInDown'>" +
                            "<div class='well profile_view'>" +
                               " <div class='col-sm-12'> " +
                                   titulo +                                    
                                    "<div class='left col-xs-10'>" +
                                       "<h2>" + req.Pessoa.Pes_nome + " " + req.Pessoa.Pes_sobrenome + "</h2>" +
                                        "<ul class='list-unstyled'>" +
                                            documento +
                                            "<li><i class='fa fa-home'></i> Endereço: " + req.Pessoa.Pes_cidade + "/" + req.Pessoa.Pes_estado + "</li>" +
                                            contato +
                                            "<br /><br />" +
                                        "</ul>" +
                                    "</div>" +
                                    "<div class='right col-xs-2 text-center'>" +
                                        //"<img src = '" + req.Perfil.Pfl_imagem + "' class='img-circle img-responsive' />" +
                                    "</div>" +
                                "</div>" +
                                "<div class='col-xs-12 bottom text-center'>" +
                                    "<div class='col-xs-12 bottom text-center'>" +
                                        atualizar + desativar + ativar +
                                    "</div>" +
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
                                                "<button type='button' class='btn btn-danger' onclick='desativar(" + dr["pes_cod"] + ", " + fmp.Funcionario.Pessoa.Pes_cod + ")'>Sim</button>" +
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
                                                "<button type='button' class='btn btn-danger' onclick='ativar(" + dr["pes_cod"] + ", " + fmp.Funcionario.Pessoa.Pes_cod + ")'>Sim</button>" +
                                              "</div>" +
                                            "</div>" +
                                          "</div>" +
                                        "</div>";
        }
    }
    [System.Web.Services.WebMethod]
    public static void Ativar(int fun, string codigo)
    {
        Pessoa pes = new Pessoa();

        pes.Pes_cod = Convert.ToInt32(codigo);
        pes.Cod_fun = fun;

        PessoaDB.Ativar(pes);
    }

    [System.Web.Services.WebMethod]
    public static void Desativar(int fun, string codigo)
    {
        Pessoa pes = new Pessoa();

        pes.Pes_cod = Convert.ToInt32(codigo);
        pes.Cod_fun = fun;

        PessoaDB.Excluir(pes);
    }
}