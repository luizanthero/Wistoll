using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wistoll.Funcoes;

public partial class paginas_UsuarioPerfil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];

        if (Session["funcionario"] != null)
        {
            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();
                string pagina = "";
                int n = 0;
                ds = FunModDB.SelectMenu(fmp.Funcionario.Fun_cod);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    pagina = dr["mod_pagina"].ToString();
                    if (pagina == "UsuarioPerfil.aspx")
                    {
                        n = 1;
                    }

                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }

                PerfilUsuario(fmp);
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    protected void PerfilUsuario(FunMod fmp)
    {

        //Variavéis
        string imagem = "", nome = "", matricula = "", usuario = "", local = "", caminho = "", situacao = "";
        int codigo = 0;

        string mes, dia = "", nomeMes = "", acao = "", mensagem = "";

        imagem = fmp.Funcionario.Perfil.Pfl_imagem;
        codigo = fmp.Funcionario.Pessoa.Pes_cod;
        nome = fmp.Funcionario.Pessoa.Pes_nome + " " + fmp.Funcionario.Pessoa.Pes_sobrenome;
        matricula = fmp.Funcionario.Fun_matricula;
        usuario = fmp.Funcionario.Perfil.Pfl_descricao;
        local = fmp.Funcionario.Pessoa.Pes_cidade + "," + fmp.Funcionario.Pessoa.Pes_estado;
        situacao = fmp.Funcionario.Pessoa.Pes_ativo;

        Contato con = new Contato();
        ContatoDB.Select(fmp.Funcionario.Pessoa.Pes_cod);

        //if (con.Con_tipo.Equals("email"))
        //{

        //}

        caminho = "<a href='../paginas/AlterarPerfil.aspx?pfl=" + Funcoes.AESCodifica(Convert.ToString(fmp.Funcionario.Fun_cod)) +
                     "' Class='btn btn-dark col-md-12'>" +
                          "<i class='fa fa-edit'></i> Editar </a>";

        //Labels com os dados do Banco
        lblInfo.Text = "<center><div class='x_title blue'>" +
                            "Detalhes do usuário " + nome +
                        "<div class='clearfix'></div>" +
                        "</div></center>";

        lblImagem.Text = "<div class='avatar-view' title='" + nome + "'>" +
                            "<img src='" + imagem + "' alt='...'/>" +
                        "</div>";

        lblDados.Text = "<br/><center><ul class='list-unstyled user_data'>" +
                            "<li class='m-top-xs'><i class='fa fa-user'></i> Matrícula: " + matricula + " | " + situacao + "</li>" +
                            "<li><i class='fa fa-briefcase user-profile-icon'></i> Usuário: " + usuario + "</li>" +
                            "<li><i class='fa fa-map-marker user-profile-icon'></i> Endereço: " + local + "</li>" +
                        //"<li><i class='fa fa-map-marker user-profile-icon'></i> Contato: " + valor + "</li>" +
                        "</ul></center><br/>" +

                        "<div class='col-md-12'>" +
                         caminho + "</div>";
                         //"<div class='col-md-6'>" +
                         //   "<button type='button' class='btn btn-dark col-md-12' data-toggle='modal' data-target='#myModalDesativar'>" +
                         //       "<i class='fa fa-trash'></i> Excluir " +
                         //   "</button>" +
                         //"</div>" +
                         //"<div class='modal fade' id='myModalDesativar' tabindex='- 1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>" +
                         //                   "<div class='modal-dialog' role='document'>" +
                         //                   "<div class='modal-content'>" +
                         //                     "<div class='modal-header'>" +
                         //                       "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
                         //                         "<span aria-hidden='true'>&times;</span>" +
                         //                       "</button>" +
                         //                       "<h3 class='modal-title red' id='myModalLabel'>Aviso!</h3>" +
                         //                     "</div>" +
                         //                     "<div class='modal-body'>" +
                         //                       "<h2 class='text-center'>Tem certeza que deseja fazer isso?</h2>" +
                         //                       "<h4 class='text-center'>Se você fizer isso ficará impossibilitado de acessar o sistema novamente!</h4>" +
                         //                     "</div>" +
                         //                     "<div class='divider'></div>" +
                         //                     "<div class='col-xs-12 bottom text-right'>" +
                         //                       "<button type='button' class='btn btn-default' data-dismiss='modal'>Não</button>" +
                         //                       "<button type='button' class='btn btn-danger' onclick='desativar(" + fmp.Funcionario.Pessoa.Pes_cod + ")'>Sim</button>" +
                         //                     "</div>" +
                         //                   "</div>" +
                         //                 "</div>" +
                         //               "</div>";


        DataSet ds = new DataSet();
        ds = AuditoriaDB.SelectPerfilAudCon(fmp.Funcionario.Fun_cod);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {            

                acao = dr["acao"] + "";

                if (acao.Equals("Atualização"))
                {
                    mensagem = nome + " atualizou " + dr["tabela"];
                }
                else if (acao.Equals("Exclusão"))
                {
                    mensagem = nome + " excluiu " + dr["tabela"];
                }
                else if (acao.Equals("Inserção"))
                {
                    mensagem = nome + " cadastrou " + dr["tabela"];
                }
                else if (acao.Equals("Ativação"))
                {
                    mensagem = nome + " ativou " + dr["tabela"];
                }
                else if (acao.Equals("Alteração de Senha"))
                {
                    mensagem = nome + " alterou " + dr["tabela"];
                }

                dia = dr["dataAcao"] + "";
                dia = dia.Substring(0, 2);
                mes = dr["dataAcao"] + "";
                mes = mes.Substring(3, 2);

                switch (mes)
                {
                    case "01":
                        nomeMes = "Janeiro";
                        break;
                    case "02":
                        nomeMes = "Fevereiro";
                        break;
                    case "03":
                        nomeMes = "Março";
                        break;
                    case "04":
                        nomeMes = "Abri";
                        break;
                    case "05":
                        nomeMes = "Maio";
                        break;
                    case "06":
                        nomeMes = "Junho";
                        break;
                    case "07":
                        nomeMes = "Julho";
                        break;
                    case "08":
                        nomeMes = "Agosto";
                        break;
                    case "09":
                        nomeMes = "Setembro";
                        break;
                    case "10":
                        nomeMes = "Outubro";
                        break;
                    case "11":
                        nomeMes = "Novembro";
                        break;
                    case "12":
                        nomeMes = "Dezembro";
                        break;
                }

            if (fmp.Funcionario.Fun_cod.Equals(dr["aud_funcionario"]))
            {

                lblTabbFeed.Text += "<ul class='messages'><li><img src='" + imagem + "' class='avatar' alt='Avatar'>" +
                                        "<div class='message_date'>" +
                                            "<h3 class='date text-info'>" + dia + "</h3>" +
                                                "<p class='month'>" + nomeMes + "</p>" +
                                        "</div>" +
                                        "<div class='message_wrapper'>" +
                                            "<h4 class='heading'>" + nome + "</h4>" +
                                                "<blockquote class='message'>" + mensagem + "</blockquote>" +
                                                 "<br />" +
                                             "<p class='url'>" +
                                                "<span class='fs1 text-info' aria-hidden='true' data-icon='?'></span>" +
                                             "</p>" +
                                         "</div></li></ul>";

            }                      

        }       

        

    }

    [System.Web.Services.WebMethod]
    public static void Desativar(string codigo)
    {
        Pessoa pes = new Pessoa();

        pes.Pes_cod = Convert.ToInt32(codigo);

        PessoaDB.Excluir(pes);
    }
}