using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Wistoll.Funcoes;

public partial class paginas_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["info"] != null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>info();</script>", false);
            Session.Abandon();
            Session["info"] = null;
        }
    }

    protected void btnLogar_Click(object sender, EventArgs e)
    {
        Funcionario fun = LoginDB.SelectLogin(new FuncionarioCrypto()
        {
            Fun_matricula = txbMatricula.Text,
            Fun_senha = txbSenha.Text
        });

        //Funcionario fun = LoginDB.SelectLogin(txbMatricula.Text, txbSenha.Text);

        //parte de sessões
        if (fun != null)
        {
            FunMod fmp = LoginDB.Sessão(fun.Fun_cod);
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
                //Response.Redirect("~/TesteSession.aspx");
            }
            else
            {
                if (fmp.Funcionario.Pessoa.Pes_ativo != "Ativo")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                }
                if(fmp.Funcionario.Fun_primeiroAcesso != false)
                {
                    Response.Redirect("~/paginas/AlterarSenha.aspx?par=" + Funcoes.AESCodifica(Convert.ToString(fun.Fun_cod)));
                }
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning();</script>", false);
        }
    }

}