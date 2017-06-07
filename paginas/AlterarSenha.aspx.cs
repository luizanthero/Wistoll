using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wistoll.Funcoes;

public partial class paginas_AlterarSenha : System.Web.UI.Page
{
    int n = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["par"] != null)
        {
            if (Request.QueryString["par"].ToString() != "")
            {

                try
                {
                    string par = Request.QueryString["par"].ToString().Replace(" ", "+");
                    n = Convert.ToInt32(Funcoes.AESDecodifica(par));
                }
                catch (Exception erro)
                {
                    Response.Redirect("~/Paginas/Login.aspx");

                    n = 0;
                }
            }
        }
    }

    protected void btnLimpar_Click(object sender, EventArgs e)
    {
        txbSenha.Text = "";
        txbNova.Text = "";
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        Funcionario fun = new Funcionario();
        if(txbSenha.Text == txbNova.Text)
        {
            if (ValidarSenha(txbSenha.Text))
            {
                FunMod fmp = new FunMod();
                if (fmp != null)
                {
                    fmp.Funcionario = fun;
                    fmp.Funcionario.Fun_cod = n;
                    fmp.AlteraSenha(txbNova.Text);
                    fmp.Funcionario.Cod_fun = n;

                    switch (FuncionarioDB.AlterarSenha(fmp))
                    {
                        case 0:
                            fmp = LoginDB.Sessão(n);
                            if (fmp.Funcionario.Pessoa.Pes_ativo == "Ativo" && fmp.Funcionario.Fun_primeiroAcesso == false)
                            {
                                //testa a validade do parametro da sessão
                                Session.Add("teste", "first");
                                Session.Add("Funcionario", fmp);
                                Session.Add("info", "mensagem");
                                if (fmp.Funcionario.Perfil.Pfl_descricao.Equals("Administrador"))
                                {
                                    Response.Redirect("~/paginas/Admin.aspx");
                                }
                                else
                                {
                                    Response.Redirect("~/paginas/Index.aspx");
                                }
                            }
                            break;
                        case -2:
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                            break;
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning1();</script>", false);
            }    
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning();</script>", false);
        }
    }

    protected bool ValidarSenha(string senha)
    {
        if (senha.Length < 8)
        {
            return false;
        }

        if (!senha.Any(c => char.IsDigit(c)))
        {
            return false;
        }

        if (!senha.Any(c => char.IsLower(c)))
        {
            return false;
        }

        if (!senha.Any(c => char.IsUpper(c)))
        {
            return false;
        }

        return true;
    }
}