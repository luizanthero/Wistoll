using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Wistoll.Funcoes;

public partial class paginas_Escqueceu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLimpar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Paginas/Login.aspx");
    }

    protected void btnEnviar_Click(object sender, EventArgs e)
    {
        string  box = "";

        box = txtEmail.Text;

        DataSet ds = new DataSet();
        ds = ContatoDB.SelectContatoEmail(box);
        if (ds.Tables[0].Rows.Count == 0)
        {
            //email += "<br>" + dr["con_tipo"] + ": " + dr["con_valor"];
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
            txtEmail.Text = "";

        }
        else
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                //email += "";                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>info();</script>", false);
                EnviarEmail();
                txtEmail.Text = "";
                //Response.Redirect("~/Paginas/Login.aspx");  

            }
        }
    }

    protected void EnviarEmail()
    {
        string retorno, assunto, mensagem;
        int codigo = 0;
        string ano = "", email = "", senha = "";

        ano = DateTime.Now.ToString();
        ano = ano.Substring(6, 4);

        senha = Wistoll.RedefinirSenha.RedefinirSenha.JuntarNumeroLetras() + ano;

        senha = Funcoes.AESDecodifica(Funcoes.AESCodifica(senha));

        assunto = "Redefinir Senha";
        mensagem = "Sua senha para logar no sistema Wistoll é: " + senha;

        codigo = FuncionarioDB.RedefinirSenhaContato(txtEmail.Text);
        email = txtEmail.Text;

        if (codigo != 0)
        {
            FuncionarioDB.RedefinirSenha(codigo, Funcoes.HashTexto(senha));
            retorno = Email.EnviarEmail(email, assunto, mensagem);
        }

        
    }

}