using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wistoll.Funcoes;
using Wistoll.RedefinirSenha;

public partial class paginas_CadastroUsuario : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];

        if (Session["funcionario"] != null)
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
                    if (pagina == "NewCadastroUsuario.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }

                CarregarPerfil();
                CarregarCargo();
                CarregarSetor();
                CarregarChecksAdicional();
                CarregarChecksPadrao();

            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    protected void CarregarPerfil()
    {
        DataSet ds = new DataSet();
        ds = PerfilDB.SelectAll();
        rblPerfil.DataSource = ds;
        rblPerfil.DataTextField = "pfl_descricao";
        rblPerfil.DataValueField = "pfl_cod";
        rblPerfil.DataBind();

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (dr["pfl_descricao"].Equals("Padrão"))
            {
                foreach (ListItem selecinado in rblPerfil.Items)
                {
                    selecinado.Selected = true;
                }
            }
        }
    }

    protected void CarregarCargo()
    {
        DataSet ds = new DataSet();
        ds = CargoDB.SelectAll();
        ddlCargo.DataSource = ds;
        ddlCargo.DataTextField = "car_descricao";
        ddlCargo.DataValueField = "car_cod";
        ddlCargo.DataBind();
        ddlCargo.Items.Insert(0, "Selecione...");
    }

    protected void CarregarSetor()
    {
        DataSet ds = new DataSet();
        ds = SetorDB.SelectAll();
        ddlSetor.DataSource = ds;
        ddlSetor.DataTextField = "set_nome";
        ddlSetor.DataValueField = "set_cod";
        ddlSetor.DataBind();
        ddlSetor.Items.Insert(0, "Selecione...");
    }

    protected void CarregarChecksAdicional()
    {
        DataSet ds = new DataSet();
        ds = ModuloDB.SelectAdicinoal();

        cblAdicional.DataSource = ds;
        cblAdicional.DataTextField = "mod_descricao";
        cblAdicional.DataValueField = "mod_cod";
        cblAdicional.DataBind();

    }

    protected void CarregarChecksPadrao()
    {
        DataSet ds = new DataSet();
        ds = ModuloDB.SelectPadrao();

        cblPadrao.DataSource = ds;
        cblPadrao.DataTextField = "mod_descricao";
        cblPadrao.DataValueField = "mod_cod";
        cblPadrao.DataBind();

        foreach (ListItem selecionadas in cblPadrao.Items)
        {
            selecionadas.Selected = true;
        }

    }

    protected void btnApagar_ServerClick(object sender, EventArgs e)
    {
        txbNome.Text = "";
        txbSobrenome.Text = "";
        txbDataNasc.Text = "";
        ddlCargo.SelectedIndex = 0;
        txbMatricula.Text = "";
        rblSexo.SelectedIndex = 0;
        rblPerfil.SelectedIndex = 2;
        rblChefe.SelectedIndex = 0;
        txbRg.Text = "";
        txbCpf.Text = "";
        ddlSetor.SelectedIndex = 0;
        ddlEstado.SelectedIndex = 0;
        txbCidade.Text = "";
        txbBairro.Text = "";
        txbRua.Text = "";
        txbNumero.Text = "";
        txbComplemento.Text = "";
        txbCep.Text = "";

        foreach (ListItem selecionadas in cblAdicional.Items)
        {
            selecionadas.Selected = false;
        }
    }

    protected void btnSalvar_ServerClick(object sender, EventArgs e)
    {
        FunMod funCod = (FunMod)Session["funcionario"];

        if (txbNome.Text != "" && txbSobrenome.Text != "" && txbDataNasc.Text != "" && ddlCargo.SelectedIndex != 0 && txbMatricula.Text != "" && txbCpf.Text != "" && txbRg.Text != "" && ddlSetor.SelectedIndex != 0 && txbCep.Text != "" && ddlEstado.SelectedIndex != 0 && txbCidade.Text != "" && txbBairro.Text != "" && txbRua.Text != "" && txbNumero.Text != "")
        {
            string[] listaContato = Request.Form.GetValues("lbTabela");


            if (listaContato != null)
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

                string ano = DateTime.Now.ToString();
                ano = ano.Substring(6, 4);
                string senha = RedefinirSenha.JuntarNumeroLetras() + ano;

                fmp.Funcionario.Pessoa.Pes_tipo = "Fisica";
                fmp.Funcionario.Pessoa.Pes_ativo = "Ativo";
                fmp.Funcionario.Pessoa.Cod_fun = funCod.Funcionario.Pessoa.Pes_cod;
                fmp.AlteraSenha(senha);
                fmp.Funcionario.Cod_fun = funCod.Funcionario.Pessoa.Pes_cod;
                fmp.Funcionario.Pessoa.Pes_nome = txbNome.Text;
                fmp.Funcionario.Pessoa.Pes_sobrenome = txbSobrenome.Text;
                fmp.Funcionario.Pessoa.Pes_dataNascimento = txbDataNasc.Text;
                fmp.Funcionario.Cargo.Car_cod = Convert.ToInt32(ddlCargo.SelectedValue);
                fmp.Funcionario.Fun_matricula = txbMatricula.Text;
                fmp.Funcionario.Pessoa.Pes_sexo = rblSexo.SelectedValue;
                fmp.Funcionario.Perfil.Pfl_cod = Convert.ToInt32(rblPerfil.SelectedValue);
                fmp.Funcionario.Pessoa.Pes_rg = txbRg.Text;
                fmp.Funcionario.Pessoa.Pes_cpf = txbCpf.Text;
                fmp.Funcionario.Setor.Set_cod = Convert.ToInt32(ddlSetor.SelectedValue);
                fmp.Funcionario.Pessoa.Pes_estado = ddlEstado.SelectedValue;
                fmp.Funcionario.Pessoa.Pes_cidade = txbCidade.Text;
                fmp.Funcionario.Pessoa.Pes_bairro = txbBairro.Text;
                fmp.Funcionario.Pessoa.Pes_rua = txbRua.Text;
                fmp.Funcionario.Pessoa.Pes_numero = txbNumero.Text;
                fmp.Funcionario.Pessoa.Pes_complemento = txbComplemento.Text;
                fmp.Funcionario.Pessoa.Pes_cep = txbCep.Text;

                if (rblChefe.SelectedIndex == 0)
                {
                    fmp.Funcionario.Fun_chefeDepartamento = false;
                    fmp.Funcionario.Fun_chefeSetor = false;
                }
                else if (rblChefe.SelectedIndex == 1)
                {
                    fmp.Funcionario.Fun_chefeDepartamento = false;
                    fmp.Funcionario.Fun_chefeSetor = true;
                }
                else if (rblChefe.SelectedIndex == 2)
                {
                    fmp.Funcionario.Fun_chefeDepartamento = true;
                    fmp.Funcionario.Fun_chefeSetor = false;
                }


                string contatos = "";

                for (int i = 0; i < listaContato.Length; i++)
                {
                    contatos += "(0, '" + listaContato[i].Split('|')[0] + "', '" + listaContato[i].Split('|')[1] + "', 'pes_con', " + funCod.Funcionario.Pessoa.Pes_cod + "),";
                }

                int n = 0, x = 0, y = 0;
                string destinatario = "";

                y = ValidarMatricula(fmp.Funcionario.Fun_matricula);

                for (int i = 0; i < listaContato.Length; i++)
                {
                    if (listaContato[i].Split('|')[0] == "Email")
                    {
                        x = ValidarEmail(listaContato[i].Split('|')[1]);
                        if(x != 0)
                        {
                            destinatario = listaContato[i].Split('|')[1];
                        }
                        n = 1;
                        break;
                    }
                }

                contatos = contatos.Substring(0, contatos.Length - 1);

                string listaPermissao = "";

                //foreach
                foreach (ListItem selecionadas in cblPadrao.Items)
                {
                    if (selecionadas.Selected == true)
                    {
                        listaPermissao += "('fun_per', " + selecionadas.Value + ", " + funCod.Funcionario.Pessoa.Pes_cod + "),";
                    }
                }

                foreach (ListItem selecionadas in cblAdicional.Items)
                {
                    if (selecionadas.Selected == true)
                    {
                        listaPermissao += "('fun_per', " + selecionadas.Value + ", " + funCod.Funcionario.Pessoa.Pes_cod + "),";
                    }
                }

                listaPermissao = listaPermissao.Substring(0, listaPermissao.Length - 1);

                string retorno = "";

                if (n != 0)
                {
                    if(y != 0)
                    {
                        if(x != 0)
                        {
                            retorno = FuncionarioDB.Insert(fmp, contatos, listaPermissao);

                            if (retorno != "Erro ao chamar procedure")
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>sucess();</script>", false);

                                //Enviar Email
                                EnviarEmail(fmp, destinatario, senha);

                                txbNome.Text = "";
                                txbSobrenome.Text = "";
                                txbDataNasc.Text = "";
                                ddlCargo.SelectedIndex = 0;
                                txbMatricula.Text = "";
                                rblSexo.SelectedIndex = 0;
                                rblPerfil.SelectedIndex = 2;
                                rblChefe.SelectedIndex = 0;
                                txbRg.Text = "";
                                txbCpf.Text = "";
                                ddlSetor.SelectedIndex = 0;
                                ddlEstado.SelectedIndex = 0;
                                txbCidade.Text = "";
                                txbBairro.Text = "";
                                txbRua.Text = "";
                                txbNumero.Text = "";
                                txbComplemento.Text = "";
                                txbCep.Text = "";

                                foreach (ListItem selecionadas in cblAdicional.Items)
                                {
                                    selecionadas.Selected = false;
                                }
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                                ddlTipoContato.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning2();</script>", false);
                            ddlTipoContato.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning3();</script>", false);
                        ddlTipoContato.SelectedIndex = 0;
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning1();</script>", false);
                    ddlTipoContato.SelectedIndex = 0;
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning1();</script>", false);
                ddlTipoContato.SelectedIndex = 0;
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning();</script>", false);
            ddlTipoContato.SelectedIndex = 0;
        }
    }

    protected int ValidarEmail(string email)
    {
        int x = 0;
        DataSet ds = new DataSet();
        ds = ContatoDB.SelectAll();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (!dr["con_valor"].Equals(email))
            {
                x = 1;
            }
            else
            {
                x = 0;
                break;
            }
        }
        return x;
    }

    protected int ValidarMatricula(string matricula)
    {
        int y = 0;
        DataSet ds = new DataSet();
        ds = FuncionarioDB.SelectAll();
        foreach(DataRow dr in ds.Tables[0].Rows)
        {
            if (!dr["fun_matricula"].Equals(matricula))
            {
                y = 1;
            }
            else
            {
                y = 0;
                break;
            }
        }
        return y;
    }

    protected void EnviarEmail(FunMod fmp, string destinatario, string senha)
    {
        string retorno, assunto, mensagem;
        
        assunto = "Redefinir Senha";
        mensagem = "Sua senha para logar no sistema Wistoll é: " + senha;
        
        retorno = Email.EnviarEmail(destinatario, assunto, mensagem);
    }

}