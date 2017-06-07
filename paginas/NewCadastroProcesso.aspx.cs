using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class paginas_Protocolo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];
        CarregaNumProcesso();

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
                    if (pagina == "NewCadastroProcesso.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }

                CarregaData();
                CarregaRequerente();
                CarregaRequerimento();

            }

        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    protected void CarregaData()
    {
        string data = DateTime.Now.ToString();
        data = data.Substring(0, 10);
        txbDataPedido.Text = data;
    }

    protected void CarregaNumProcesso()
    {
        int numero = 0;
        DataSet ds = new DataSet();
        ds = ProcessoDB.SelectAllPro();
        foreach(DataRow dr in ds.Tables[0].Rows)
        {
            numero = Convert.ToInt32(dr["pro_cod"]);
        }
        numero++;
        string data = DateTime.Now.ToString();
        data = data.Substring(8, 2);
        string processo = Convert.ToString(numero) + "/" + data;

        txbNumero.Text = processo;
    }

    protected void CarregaRequerimento()
    {
        DataSet ds = ProcessoDB.SelectRequerimento();
        dpRequerimento.DataSource = ds;
        dpRequerimento.DataTextField = "mrq_descricao";
        // Nome da coluna do Banco de dados 
        dpRequerimento.DataValueField = "mrq_cod";
        // ID da coluna do Banco 
        dpRequerimento.DataBind();
        dpRequerimento.Items.Insert(0, "Selecione o modelo do requerimento...");
    }

    protected void CarregaRequerente()
    {
        DataSet ds = new DataSet();
        ds = RequerenteDB.SelectAllAtivo();
        ddlRequerente.DataSource = ds;
        ddlRequerente.DataTextField = "pes_nome";
        ddlRequerente.DataValueField = "req_cod";
        ddlRequerente.DataBind();
        ddlRequerente.Items.Insert(0, "Selecione...");
    }

    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        FunMod funCod = (FunMod)Session["funcionario"];

        string setor = funCod.Funcionario.Setor.Set_nome;

        Processo pro = new Processo();
        Requerente req = new Requerente();
        Status sta = new Status();
        ModeloRequerimento mrq = new ModeloRequerimento();

        if(dpRequerimento.SelectedIndex != 0 && ddlRequerente.SelectedIndex != 0)
        {
            pro.Pro_numeroProcesso = txbNumero.Text;
            pro.Pro_dataPedido = txbDataPedido.Text;
            pro.Cod_fun = funCod.Funcionario.Pessoa.Pes_cod;
            pro.Pro_ativo = "Ativo";
            pro.Requerente = req;
            pro.Status = sta;
            pro.ModeloRequerimento = mrq;
            pro.ModeloRequerimento.Mrq_cod = Convert.ToInt32(dpRequerimento.SelectedValue);
            pro.Requerente.Req_cod = Convert.ToInt32(ddlRequerente.SelectedValue);
            pro.Status.Sta_cod = 3;

            string retorno = ProcessoDB.Insert(pro, setor);

            if (retorno != "Erro ao chamar procedure")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>sucess();</script>", false);
                CarregaNumProcesso();
                dpRequerimento.SelectedIndex = 0;
                ddlRequerente.SelectedIndex = 0;
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
}