using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Wistoll.Funcoes;

public partial class paginas_AlterarPerfil : System.Web.UI.Page
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
                    if (pagina == "AlterarPerfil.aspx")
                    {
                        n = 1;
                    }

                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }

                Decodificar(fmp);
                //PerfilUsuario(fmp);
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    protected void AlterarUsuario(int n)
    {
        FunMod funCod = (FunMod)Session["funcionario"];

        FunMod fmp = FunModDB.Select(n);

        if (fmp.Funcionario.Perfil.Pfl_descricao.Equals("Administrador"))
        {
            rdbUsu.Visible = false;
            lblAdmin.Visible = true;

        }

        string imagem = "", nome = "", sobrenome = "", sexo = "", perfil = "", matricula = "", dtNas = "", rg = "", cpf = "",
            rua = "", numero = "", complemento = "", bairro = "", cep = "", cidade = "", estado = "", usuario = "", caminho = "",
            situacao = "", cargo = "", setor = "";

        bool CheSet = false, CheDep = false;

        imagem = fmp.Funcionario.Perfil.Pfl_imagem;
        nome = fmp.Funcionario.Pessoa.Pes_nome;
        sobrenome = fmp.Funcionario.Pessoa.Pes_sobrenome;
        sexo = fmp.Funcionario.Pessoa.Pes_sexo;
        perfil = fmp.Funcionario.Perfil.Pfl_cod.ToString();
        matricula = fmp.Funcionario.Fun_matricula;
        dtNas = fmp.Funcionario.Pessoa.Pes_dataNascimento;
        rg = fmp.Funcionario.Pessoa.Pes_rg;
        cpf = fmp.Funcionario.Pessoa.Pes_cpf;
        rua = fmp.Funcionario.Pessoa.Pes_rua;
        numero = fmp.Funcionario.Pessoa.Pes_numero;
        complemento = fmp.Funcionario.Pessoa.Pes_complemento;
        bairro = fmp.Funcionario.Pessoa.Pes_bairro;
        cep = fmp.Funcionario.Pessoa.Pes_cep;
        cidade = fmp.Funcionario.Pessoa.Pes_cidade;
        estado = fmp.Funcionario.Pessoa.Pes_estado;
        usuario = fmp.Funcionario.Perfil.Pfl_descricao;
        situacao = fmp.Funcionario.Pessoa.Pes_ativo;
        cargo = Convert.ToString(fmp.Funcionario.Cargo.Car_cod);
        setor = Convert.ToString(fmp.Funcionario.Setor.Set_cod);
        CheDep = fmp.Funcionario.Fun_chefeDepartamento;
        CheSet = fmp.Funcionario.Fun_chefeSetor;


        lblImagem.Text = "<div class='avatar-view' title='" + nome + " " + sobrenome + "'>" +
                            "<img src='" + imagem + "' alt='...'/>" +
                        "</div>";

        //Campos do textbox
        txtNome1.Text = nome;
        txtSobrenome1.Text = sobrenome;
        rdbSexo.SelectedValue = sexo;
        rdbUsu.SelectedValue = perfil;
        txtMatricula1.Text = matricula;
        txtDataNas1.Text = dtNas;
        txtRG1.Text = rg;
        txtCPF1.Text = cpf;
        txtRua1.Text = rua;
        txtNumero1.Text = numero;
        txtComplemento1.Text = complemento;
        txtBairro1.Text = bairro;
        txtCEP1.Text = cep;
        txtCidade1.Text = cidade;
        ddlEstados.SelectedValue = estado;
        ddlCargo.SelectedValue = cargo;
        ddlSetor.SelectedValue = setor;

        if (CheSet == false && CheDep == false)
        {
            rdbChefe.SelectedValue = Convert.ToString(0);
        }
        else if (CheSet != false)
        {
            rdbChefe.SelectedValue = Convert.ToString(1);
        }
        else if (CheDep != false)
        {
            rdbChefe.SelectedValue = Convert.ToString(2);
        }


        lbl.Text = nome + " " + sobrenome;

        string caminhoPerfil = "";

        if (fmp.Funcionario.Pessoa.Pes_cod == funCod.Funcionario.Pessoa.Pes_cod)
        {
            caminhoPerfil = "<li><a href='../paginas/UsuarioPerfil.aspx' data-toggle='tooltip' data-placement='bottom' title='Retornar Pagina Anterior'><i class='fa fa-reply'></i></a></li>";
            lblBtnCancelar.Text = "<a href = '../Paginas/UsuarioPerfil.aspx' class='btn btn-dark col-md-12' ><i class='fa fa-close'></i> Cancelar</a>";
            lblBtnExcluir.Text = BotaoExcluir(funCod.Funcionario.Pessoa.Pes_cod);
        }
        else
        {
            caminhoPerfil = "<li><a href='../paginas/PerfilUsuarios.aspx?usu=" + Funcoes.AESCodifica(Convert.ToString(n)) + "' data-toggle='tooltip' data-placement='bottom' title='Retornar Pagina Anterior'><i class='fa fa-reply'></i></a></li>";
            lblBtnCancelar.Text = "<a href = '../Paginas/PerfilUsuarios.aspx?usu=" + Funcoes.AESCodifica(Convert.ToString(n)) + "' class='btn btn-dark col-md-12' ><i class='fa fa-close'></i> Cancelar</a>";
            lblBtnExcluir.Text = BotaoExcluirUsuarios(fmp.Funcionario.Pessoa.Pes_cod);
        }

        lblInfo.Text = "<center><div class='x_title blue'>" +
                            "Alterar Usuário " + nome + " " + sobrenome +
                            "<ul class='nav navbar-right panel_toolbox'>" +
                                caminhoPerfil +
                            "</ul>" +
                        "<div class='clearfix'></div>" +
                        "</div></center>";

        lblDados.Text = "<br/><center><ul class='list-unstyled user_data'>" +
                            "<li class='m-top-xs'><i class='fa fa-user'></i> Matrícula: " + matricula + " | " + situacao + "</li>" +
                            "<li><i class='fa fa-briefcase user-profile-icon'></i> Usuário: " + usuario + "</li>" +
                        //"<li><i class='fa fa-map-marker user-profile-icon'></i> Endereço: " + local + "</li>" +
                        //"<li><i class='fa fa-map-marker user-profile-icon'></i> Contato: " + valor + "</li>" +
                        "</ul></center>";


    }

    protected string BotaoExcluir(int codigo)
    {
        Pessoa pes = PessoaDB.Select(codigo);

        string botao = "";

        if (pes.Pes_ativo != "Inativo")
        {
            botao = "<a class='btn btn-dark col-md-12' data-toggle='modal' data-target='#myModalDesativar'>" +
                          "<i class='fa fa-trash'></i> Excluir Usuário " +
                    "</a>" +
                    "<div class='modal fade' id='myModalDesativar' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>" +
                                            "<div class='modal-dialog' role='document'>" +
                                            "<div class='modal-content'>" +
                                              "<div class='modal-header'>" +
                                                "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
                                                  "<span aria-hidden='true'>&times;</span>" +
                                                "</button>" +
                                                "<h3 class='modal-title text-left red' id='myModalLabel'>Aviso!</h3>" +
                                              "</div>" +
                                              "<div class='modal-body'>" +
                                                "<h2 class='text-center'>Tem certeza que deseja EXCLUIR seu Usuário?</h2>" +
                                                "<h4 class='text-center'>Se você fizer isso ficará impossibilitado de acessar o sistema novamente!</h4>" +
                                              "</div>" +
                                              "<div class='divider'></div>" +
                                              "<div class='col-xs-12 bottom text-right'>" +
                                                "<button type='button' class='btn btn-default' data-dismiss='modal'>Não</button>" +
                                                "<button type='button' class='btn btn-danger' onclick='desativar(" + codigo + ")'>Sim</button>" +
                                              "</div>" +
                                            "</div>" +
                                          "</div>" +
                                        "</div>";
        }
        else
        {
            botao = "<a class='btn btn-dark col-md-12' data-toggle='modal' data-target='#myModalAtivar'>" +
                          "<i class='fa fa-check-circle'></i> Ativar " +
                    "</a>" +
                    "<div class='modal fade' id='myModalAtivar' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>" +
                                            "<div class='modal-dialog' role='document'>" +
                                            "<div class='modal-content'>" +
                                              "<div class='modal-header'>" +
                                                "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
                                                  "<span aria-hidden='true'>&times;</span>" +
                                                "</button>" +
                                                "<h3 class='modal-title text-left red' id='myModalLabel'>Aviso!</h3>" +
                                              "</div>" +
                                              "<div class='modal-body'>" +
                                                "<h2 class='text-center'>Tem certeza que deseja Ativar este Usuário?</h2>" +
                                              "</div>" +
                                              "<div class='divider'></div>" +
                                              "<div class='col-xs-12 bottom text-right'>" +
                                                "<button type='button' class='btn btn-default' data-dismiss='modal'>Não</button>" +
                                                "<button type='button' class='btn btn-danger' onclick='ativar(" + codigo + ")'>Sim</button>" +
                                              "</div>" +
                                            "</div>" +
                                          "</div>" +
                                        "</div>";
        }

        return botao;
    }

    protected string BotaoExcluirUsuarios(int codigo)
    {
        Pessoa pes = PessoaDB.Select(codigo);

        string botao = "";

        if (pes.Pes_ativo != "Inativo")
        {
            botao = "<a class='btn btn-dark col-md-12' data-toggle='modal' data-target='#myModalDesativar'>" +
                          "<i class='fa fa-trash'></i> Excluir Usuário " +
                    "</a>" +
                    "<div class='modal fade' id='myModalDesativar' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>" +
                                            "<div class='modal-dialog' role='document'>" +
                                            "<div class='modal-content'>" +
                                              "<div class='modal-header'>" +
                                                "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
                                                  "<span aria-hidden='true'>&times;</span>" +
                                                "</button>" +
                                                "<h3 class='modal-title text-left red' id='myModalLabel'>Aviso!</h3>" +
                                              "</div>" +
                                              "<div class='modal-body'>" +
                                                "<h2 class='text-center'>Tem certeza que deseja EXCLUIR este Usuário?</h2>" +
                                                "<h4 class='text-center'>Se você fizer isso este usuário ficará impossibilitado de acessar o sistema novamente!</h4>" +
                                              "</div>" +
                                              "<div class='divider'></div>" +
                                              "<div class='col-xs-12 bottom text-right'>" +
                                                "<button type='button' class='btn btn-default' data-dismiss='modal'>Não</button>" +
                                                "<button type='button' class='btn btn-danger' onclick='desativar(" + codigo + ")'>Sim</button>" +
                                              "</div>" +
                                            "</div>" +
                                          "</div>" +
                                        "</div>";
        }
        else
        {
            botao = "<a class='btn btn-dark col-md-12' data-toggle='modal' data-target='#myModalAtivar'>" +
                          "<i class='fa fa-check-circle'></i> Ativar " +
                    "</a>" +
                    "<div class='modal fade' id='myModalAtivar' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>" +
                                            "<div class='modal-dialog' role='document'>" +
                                            "<div class='modal-content'>" +
                                              "<div class='modal-header'>" +
                                                "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
                                                  "<span aria-hidden='true'>&times;</span>" +
                                                "</button>" +
                                                "<h3 class='modal-title text-left red' id='myModalLabel'>Aviso!</h3>" +
                                              "</div>" +
                                              "<div class='modal-body'>" +
                                                "<h2 class='text-center'>Tem certeza que deseja Ativar este Usuário?</h2>" +
                                              "</div>" +
                                              "<div class='divider'></div>" +
                                              "<div class='col-xs-12 bottom text-right'>" +
                                                "<button type='button' class='btn btn-default' data-dismiss='modal'>Não</button>" +
                                                "<button type='button' class='btn btn-danger' onclick='ativar(" + codigo + ")'>Sim</button>" +
                                              "</div>" +
                                            "</div>" +
                                          "</div>" +
                                        "</div>";
        }

        return botao;
    }

    protected int Decodificar(FunMod fmp)
    {
        int n = 0;

        if (Request.QueryString["pfl"] != null)
        {
            if (Request.QueryString["pfl"].ToString() != "")
            {

                try
                {
                    string user = Request.QueryString["pfl"].ToString().Replace(" ", "+");
                    n = Convert.ToInt32(Funcoes.AESDecodifica(user));

                    AlterarUsuario(n);
                    CarregarChecks(n, fmp);
                    CarregarTabela(n);
                    CarregarCargo(n);
                    CarregarSetor(n);
                    CarregarChecksPadrao(n);

                    return n;

                }
                catch (Exception erro)
                {
                    if (fmp.Funcionario.Perfil.Pfl_descricao.Equals("Administrador"))
                    {
                        Response.Redirect("~/Paginas/Admin.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/Paginas/Index.aspx");
                    }

                    n = 0;

                }
            }
        }

        return n;
    }

    protected void CarregarCargo(int fun_cod)
    {
        Funcionario fun = FuncionarioDB.Select(fun_cod);
        DataSet ds = new DataSet();
        if (fun.Perfil.Pfl_descricao == "Administrador")
        {
            ds = CargoDB.SelectAllAdministrador();
        }
        else
        {
            ds = CargoDB.SelectAll();
        }
        ddlCargo.DataSource = ds;
        ddlCargo.DataTextField = "car_descricao";
        ddlCargo.DataValueField = "car_cod";
        ddlCargo.DataBind();
        ddlCargo.Items.Insert(0, "Selecione...");
    }

    protected void CarregarSetor(int fun_cod)
    {
        Funcionario fun = FuncionarioDB.Select(fun_cod);
        DataSet ds = new DataSet();
        if (fun.Perfil.Pfl_descricao == "Administrador")
        {
            ds = SetorDB.SelectAllAdministrador();
        }
        else
        {
            ds = SetorDB.SelectAll();
        }
        ddlSetor.DataSource = ds;
        ddlSetor.DataTextField = "set_nome";
        ddlSetor.DataValueField = "set_cod";
        ddlSetor.DataBind();
        ddlSetor.Items.Insert(0, "Selecione...");
    }

    protected void CarregarChecksPadrao(int fun_cod)
    {
        Funcionario fun = FuncionarioDB.Select(fun_cod);
        DataSet ds = new DataSet();
        if (fun.Perfil.Pfl_descricao != "Administrador")
        {
            ds = ModuloDB.SelectPadrao();
        }
        else
        {
            ds = ModuloDB.SelectPadraoAdmin();
        }

        cblPadrao.DataSource = ds;
        cblPadrao.DataTextField = "mod_descricao";
        cblPadrao.DataValueField = "mod_cod";
        cblPadrao.DataBind();

        foreach (ListItem selecionadas in cblPadrao.Items)
        {
            selecionadas.Selected = true;
        }

    }

    protected void CarregarChecks(int fun_cod, FunMod fmp)
    {
        Funcionario fun = FuncionarioDB.Select(fun_cod);
        int n = 0;
        DataSet ds1 = new DataSet();
        ds1 = ModuloDB.ModuloUsuario(fmp.Funcionario.Fun_cod);
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            if (dr1["mod_descricao"].Equals("Habilitar Permissão"))
            {
                n = 1;
                break;
            }
        }

        if (n != 1)
        {
            lblPermissoes.Visible = false;
            checkAdicionais.Visible = false;
            DataSet ds = new DataSet();

            if (fun.Perfil.Pfl_descricao != "Administrador")
            {
                ds = ModuloDB.SelectAdicinoal();
            }
            else
            {
                ds = ModuloDB.SelectAdicinoalAdmin();
            }

            checkAdicionais.DataSource = ds;
            checkAdicionais.DataTextField = "mod_descricao";
            checkAdicionais.DataValueField = "mod_cod";
            checkAdicionais.DataBind();

            DataSet dsFunc = new DataSet();
            dsFunc = ModuloDB.SelectAdicinoalFuncionario(fun_cod);

            foreach (DataRow dr in dsFunc.Tables[0].Rows)
            {
                foreach (ListItem selecionadas in checkAdicionais.Items)
                {
                    if (Convert.ToInt32(dr["mod_cod"]) == Convert.ToInt32(selecionadas.Value))
                    {
                        selecionadas.Selected = true;
                    }
                }
            }
        }
        else
        {
            lblPermissoes.Visible = true;
            checkAdicionais.Visible = true;
            DataSet ds = new DataSet();
            if (fun.Perfil.Pfl_descricao != "Administrador")
            {
                ds = ModuloDB.SelectAdicinoal();
            }
            else
            {
                ds = ModuloDB.SelectAdicinoalAdmin();
            }

            checkAdicionais.DataSource = ds;
            checkAdicionais.DataTextField = "mod_descricao";
            checkAdicionais.DataValueField = "mod_cod";
            checkAdicionais.DataBind();

            DataSet dsFunc = new DataSet();
            dsFunc = ModuloDB.SelectAdicinoalFuncionario(fun_cod);


            foreach (DataRow dr in dsFunc.Tables[0].Rows)
            {
                foreach (ListItem selecionadas in checkAdicionais.Items)
                {
                    if (Convert.ToInt32(dr["mod_cod"]) == Convert.ToInt32(selecionadas.Value))
                    {
                        selecionadas.Selected = true;
                    }
                }
            }
        }
    }


    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        FunMod funCod = (FunMod)Session["funcionario"];

        string texto = Request.QueryString["pfl"].Replace(" ", "+");
        int n = Convert.ToInt32(Funcoes.AESDecodifica(texto));
        FunMod fmp1 = FunModDB.Select(n);

        if (txtNome1.Text != "" && txtSobrenome1.Text != "" && txtDataNas1.Text != "" && ddlCargo.SelectedIndex != 0 && txtMatricula1.Text != "" && txtCPF1.Text != "" && txtRG1.Text != "" && txtCEP1.Text != "" && ddlEstados.SelectedIndex != 0 && txtCidade1.Text != "" && txtBairro1.Text != "" && txtRua1.Text != "" && txtNumero1.Text != "" && txtComplemento1.Text != "")
        {
            FunMod fmp = new FunMod();
            Funcionario fun = new Funcionario();
            fmp.Funcionario = fun;
            Modulo mod = new Modulo();
            fmp.Modulo = mod;
            Pessoa pes = new Pessoa();
            fmp.Funcionario.Pessoa = pes;
            Perfil pfl = new Perfil();
            fmp.Funcionario.Perfil = new Perfil();
            Setor set = new Setor();
            fmp.Funcionario.Setor = set;
            Cargo car = new Cargo();
            fmp.Funcionario.Cargo = car;
            //Contato con = new Contato();
            //con.Pessoa = pes;

            fmp.Funcionario.Pessoa.Pes_cod = fmp1.Funcionario.Pessoa.Pes_cod;
            fmp.Funcionario.Pessoa.Pes_tipo = "Fisica";
            fmp.Funcionario.Pessoa.Pes_ativo = "Ativo";
            fmp.Funcionario.Pessoa.Cod_fun = funCod.Funcionario.Pessoa.Pes_cod;
            fmp.Funcionario.Cod_fun = funCod.Funcionario.Pessoa.Pes_cod;
            fmp.Funcionario.Pessoa.Pes_nome = txtNome1.Text;
            fmp.Funcionario.Pessoa.Pes_sobrenome = txtSobrenome1.Text;
            fmp.Funcionario.Pessoa.Pes_dataNascimento = txtDataNas1.Text;
            fmp.Funcionario.Cargo.Car_cod = Convert.ToInt32(ddlCargo.SelectedValue);
            fmp.Funcionario.Fun_cod = fmp1.Funcionario.Fun_cod;
            fmp.Funcionario.Fun_matricula = txtMatricula1.Text;
            fmp.Funcionario.Pessoa.Pes_sexo = rdbSexo.SelectedValue;
            if(rdbUsu.Visible != false)
            {
                fmp.Funcionario.Perfil.Pfl_cod = Convert.ToInt32(rdbUsu.SelectedValue);
            }
            else
            {
                fmp.Funcionario.Perfil.Pfl_cod = 1;
            }
            fmp.Funcionario.Pessoa.Pes_rg = txtRG1.Text;
            fmp.Funcionario.Pessoa.Pes_cpf = txtCPF1.Text;
            fmp.Funcionario.Setor.Set_cod = Convert.ToInt32(ddlSetor.SelectedValue);
            fmp.Funcionario.Pessoa.Pes_estado = ddlEstados.SelectedValue;
            fmp.Funcionario.Pessoa.Pes_cidade = txtCidade1.Text;
            fmp.Funcionario.Pessoa.Pes_bairro = txtBairro1.Text;
            fmp.Funcionario.Pessoa.Pes_rua = txtRua1.Text;
            fmp.Funcionario.Pessoa.Pes_numero = txtNumero1.Text;
            fmp.Funcionario.Pessoa.Pes_complemento = txtComplemento1.Text;
            fmp.Funcionario.Pessoa.Pes_cep = txtCEP1.Text;

            if (rdbChefe.SelectedIndex == 0)
            {
                fmp.Funcionario.Fun_chefeDepartamento = false;
                fmp.Funcionario.Fun_chefeSetor = false;
            }
            else if (rdbChefe.SelectedIndex == 1)
            {
                fmp.Funcionario.Fun_chefeDepartamento = false;
                fmp.Funcionario.Fun_chefeSetor = true;
            }
            else if (rdbChefe.SelectedIndex == 2)
            {
                fmp.Funcionario.Fun_chefeDepartamento = true;
                fmp.Funcionario.Fun_chefeSetor = false;
            }

            string listaPermissao = "";

            //foreach
            foreach (ListItem selecionadas in cblPadrao.Items)
            {
                if (selecionadas.Selected == true)
                {
                    listaPermissao += "('fun_per', " + selecionadas.Value + ", " + funCod.Funcionario.Pessoa.Pes_cod + "),";
                }
            }

            foreach (ListItem selecionadas in checkAdicionais.Items)
            {
                if (selecionadas.Selected == true)
                {
                    listaPermissao += "('fun_per', " + selecionadas.Value + ", " + funCod.Funcionario.Pessoa.Pes_cod + "),";
                }
            }

            listaPermissao = listaPermissao.Substring(0, listaPermissao.Length - 1);

            string retorno = "";

            retorno = FuncionarioDB.Update(fmp, listaPermissao);
            retorno = retorno.Substring(0, 4);

            if (retorno != "Erro")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>sucess();</script>", false);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning();</script>", false);
        }
    }

    protected void CarregarTabela(int n)
    {
        DataSet ds = new DataSet();
        ds = ContatoDB.SelectContatos(n);
        grdContato.DataSource = ds.Tables[0].DefaultView;
        grdContato.DataBind();
        grdContato.Visible = true;
    }

    protected void grdContato_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void grdContato_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.Cells[0].FindControl("lblTipoContato");
            Label lbl1 = (Label)e.Row.Cells[0].FindControl("lblTipoContato1");
            if (lbl != null)
            {
                if (lbl.Text == "Email")
                {
                    e.Row.Cells[3].Text = "";
                }
            }
            if (lbl1 != null)
            {
                if (lbl1.Text == "Email")
                {
                    e.Row.Cells[3].Text = "";
                }
            }
        }
    }

    protected void grdContato_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdContato.EditIndex = e.NewEditIndex;
        int n = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["pfl"].Replace(" ", "+")));
        CarregarTabela(n);
    }

    protected void grdContato_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int n = Convert.ToInt32(grdContato.DataKeys[e.RowIndex].Value.ToString());

        ContatoDB.Excluir(n);
        int x = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["pfl"].Replace(" ", "+")));
        CarregarTabela(x);
    }

    protected void grdContato_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];
        int n = Convert.ToInt32(grdContato.DataKeys[e.RowIndex].Value.ToString());
        TextBox txb = (TextBox)grdContato.Rows[e.RowIndex].FindControl("txbContato");
        Contato con = new Contato();
        con.Con_valor = txb.Text;
        con.Con_cod = n;
        con.Cod_fun = fmp.Funcionario.Fun_cod;
        ContatoDB.Atualizar(con);
        grdContato.EditIndex = -1;
        int x = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["pfl"].Replace(" ", "+")));
        CarregarTabela(x);
    }

    protected void grdContato_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdContato.EditIndex = -1;
        int x = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["pfl"].Replace(" ", "+")));
        CarregarTabela(x);
    }

    protected void lnkAddContato_Click(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];
        int n = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["pfl"].Replace(" ", "+")));
        string tipo = "";
        string valor = "";
        int x = 0;

        if(ddlTipoContato.SelectedIndex != 0)
        {
            switch (ddlTipoContato.SelectedIndex)
            {
                case 1:
                    if(txbEmail.Text != "")
                    {
                        tipo = ddlTipoContato.SelectedValue;
                        valor = txbEmail.Text;
                        x = 1;
                    }
                    break;
                case 2:
                    if(txbTelefone.Text != "")
                    {
                        tipo = ddlTipoContato.SelectedValue;
                        valor = txbTelefone.Text;
                        x = 1;
                    }
                    break;
                case 3:
                    if(txbCelular.Text != "")
                    {
                        tipo = ddlTipoContato.SelectedValue;
                        valor = txbCelular.Text;
                        x = 1;
                    }
                    break;
            }

            if(x != 0)
            {
                Contato con = new Contato();
                con.Pessoa = new Pessoa();

                con.Con_tipo = tipo;
                con.Con_valor = valor;
                con.Pessoa.Pes_cod = n;
                con.Cod_fun = fmp.Funcionario.Fun_cod;

                switch (ContatoDB.Insert(con))
                {
                    case 0:
                        Response.Redirect("../paginas/AlterarPerfil.aspx?pfl=" + Request.QueryString["pfl"].Replace(" ", "+"));
                        break;
                    case -2:
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>erroContato();</script>", false);
                        break;
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>erroContato();</script>", false);
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>erroContato();</script>", false);
        }
    }
}