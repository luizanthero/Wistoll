using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wistoll.Funcoes;

public partial class paginas_AlterarRequerente : System.Web.UI.Page
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
                    if (pagina == "AlterarRequerente.aspx")
                    {
                        n = 1;
                        break;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/ConsultaRequerente.aspx.aspx");
                }

                Decodificar(fmp);
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    protected string Decodificar(FunMod fmp)
    {
        string tipo = "";

        if (Request.QueryString["par"] != null)
        {
            if (Request.QueryString["par"].ToString() != "")
            {

                try
                {
                    string user = Request.QueryString["par"].ToString().Replace(" ", "+");
                    int cod = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["cod"].ToString().Replace(" ", "+")));
                    tipo = Funcoes.AESDecodifica(user);
                    

                    switch (tipo)
                    {
                        case "Fisica":
                            mlv.ActiveViewIndex = 0;
                            CarregarFisica(cod);
                            CarregarTabela(cod);
                            break;
                        case "Juridica":
                            mlv.ActiveViewIndex = 1;
                            CarregarJuridica(cod);
                            CarregarTabela1(cod);
                            break;
                    }

                    return tipo;

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

                    tipo = "";
                }
            }
        }

        return tipo;
    }

    protected void CarregarFisica(int codigo)
    {
        Pessoa pes = PessoaDB.Select(codigo);

        txbNomeFis.Text = pes.Pes_nome;
        txbSobrenomeFis.Text = pes.Pes_sobrenome;
        txbDataNascFis.Text = pes.Pes_dataNascimento;
        rblSexoFis.SelectedValue = pes.Pes_sexo;
        txbCpfFis.Text = pes.Pes_cpf;
        txbRgFis.Text = pes.Pes_rg;

        txbCepFis.Text = pes.Pes_cep;
        ddlEstadoFis.SelectedValue = pes.Pes_estado;
        txbCidadeFis.Text = pes.Pes_cidade;
        txbBairroFis.Text = pes.Pes_bairro;
        txbRuaFis.Text = pes.Pes_rua;
        txbNumeroFis.Text = pes.Pes_numero;
        txbComplementoFis.Text = pes.Pes_complemento;
    }

    protected void CarregarJuridica(int codigo)
    {
        Pessoa pes = PessoaDB.Select(codigo);

        txbNomeJur.Text = pes.Pes_nome;
        txbDataNascJur.Text = pes.Pes_dataNascimento;
        txbSiglaJur.Text = pes.Pes_sigla;
        txbRazaoSocialJur.Text = pes.Pes_razaoSocial;
        txbCnpjJur.Text = pes.Pes_cnpj;

        txbCepJur.Text = pes.Pes_cep;
        ddlEstadoJur.SelectedValue = pes.Pes_estado;
        txbCidadeJur.Text = pes.Pes_cidade;
        txbBairroJur.Text = pes.Pes_bairro;
        txbRuaJur.Text = pes.Pes_rua;
        txbNumeroJur.Text = pes.Pes_numero;
        txbComplementoJur.Text = pes.Pes_complemento;
    }

    protected void CarregarTabela(int n)
    {
        DataSet ds = new DataSet();
        ds = ContatoDB.SelectContatos(n);
        grdContato.DataSource = ds.Tables[0].DefaultView;
        grdContato.DataBind();
        grdContato.Visible = true;
    }

    protected void CarregarTabela1(int n)
    {
        DataSet ds = new DataSet();
        ds = ContatoDB.SelectContatos(n);
        grdContato1.DataSource = ds.Tables[0].DefaultView;
        grdContato1.DataBind();
        grdContato1.Visible = true;
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
            //if (lbl != null)
            //{
            //    if (lbl.Text == "Email")
            //    {
            //        e.Row.Cells[3].Text = "";
            //    }
            //}
            //if (lbl1 != null)
            //{
            //    if (lbl1.Text == "Email")
            //    {
            //        e.Row.Cells[3].Text = "";
            //    }
            //}
        }
    }

    protected void grdContato_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdContato.EditIndex = e.NewEditIndex;
        int n = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["cod"].Replace(" ", "+")));
        CarregarTabela(n);
    }

    protected void grdContato_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int n = Convert.ToInt32(grdContato.DataKeys[e.RowIndex].Value.ToString());

        ContatoDB.Excluir(n);
        int x = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["cod"].Replace(" ", "+")));
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
        int x = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["cod"].Replace(" ", "+")));
        CarregarTabela(x);
    }

    protected void grdContato_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdContato.EditIndex = -1;
        int x = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["cod"].Replace(" ", "+")));
        CarregarTabela(x);
    }

    protected void grdContato1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void grdContato1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl = (Label)e.Row.Cells[0].FindControl("lblTipoContato");
            Label lbl1 = (Label)e.Row.Cells[0].FindControl("lblTipoContato1");
            //if (lbl != null)
            //{
            //    if (lbl.Text == "Email")
            //    {
            //        e.Row.Cells[3].Text = "";
            //    }
            //}
            //if (lbl1 != null)
            //{
            //    if (lbl1.Text == "Email")
            //    {
            //        e.Row.Cells[3].Text = "";
            //    }
            //}
        }
    }

    protected void grdContato1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdContato1.EditIndex = e.NewEditIndex;
        int n = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["cod"].Replace(" ", "+")));
        CarregarTabela(n);
    }

    protected void grdContato1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int n = Convert.ToInt32(grdContato1.DataKeys[e.RowIndex].Value.ToString());

        ContatoDB.Excluir(n);
        int x = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["cod"].Replace(" ", "+")));
        CarregarTabela(x);
    }

    protected void grdContato1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];
        int n = Convert.ToInt32(grdContato1.DataKeys[e.RowIndex].Value.ToString());
        TextBox txb = (TextBox)grdContato1.Rows[e.RowIndex].FindControl("txbContato");
        Contato con = new Contato();
        con.Con_valor = txb.Text;
        con.Con_cod = n;
        con.Cod_fun = fmp.Funcionario.Fun_cod;
        ContatoDB.Atualizar(con);
        grdContato1.EditIndex = -1;
        int x = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["cod"].Replace(" ", "+")));
        CarregarTabela(x);
    }

    protected void grdContato1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdContato1.EditIndex = -1;
        int x = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["cod"].Replace(" ", "+")));
        CarregarTabela(x);
    }

    protected void lnkAddContato_Click(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];
        int n = Convert.ToInt32(Funcoes.AESDecodifica(Request.QueryString["cod"].Replace(" ", "+")));
        string tipo = "";
        string valor = "";
        int x = 0;

        if (ddlTipoContato.SelectedIndex != 0)
        {
            switch (ddlTipoContato.SelectedIndex)
            {
                case 1:
                    if (txbEmail.Text != "")
                    {
                        tipo = ddlTipoContato.SelectedValue;
                        valor = txbEmail.Text;
                        x = 1;
                    }
                    break;
                case 2:
                    if (txbTelefone.Text != "")
                    {
                        tipo = ddlTipoContato.SelectedValue;
                        valor = txbTelefone.Text;
                        x = 1;
                    }
                    break;
                case 3:
                    if (txbCelular.Text != "")
                    {
                        tipo = ddlTipoContato.SelectedValue;
                        valor = txbCelular.Text;
                        x = 1;
                    }
                    break;
            }

            if (x != 0)
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
                        Response.Redirect("../paginas/AlterarRequerente.aspx?par=" + Request.QueryString["par"].Replace(" ", "+") + "&cod=" + Request.QueryString["cod"].Replace(" ", "+"));
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