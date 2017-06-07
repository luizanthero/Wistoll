using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class paginas_Requerente_Table : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CarregarTabela();
    }

    private void CarregarTabela()
    {
        DataSet ds = ProcessoDB.SelectAll();
        int qtd = ds.Tables[0].Rows.Count;

        if (qtd > 0)
        {
            example.DataSource = ds.Tables[0].DefaultView;
            example.DataBind();
            example.Visible = true;

            if (qtd == 1)
            {
                lbl.Text = "<h4>Foi Encontrado " + qtd + " registro</h4>";
            }
            else
            {
                lbl.Text = "<h4>Foram encontrados " + qtd + " registros</h4>";
            }

        }
        else
        {
            example.Visible = false;
            lbl.Text = "<h4> Não foram encontrados registros </h4>";
        }


        // Botões de Anteiror e Próximo 
        if (qtd > 5)
        {
            btnProximo.Visible = true;
            btnAnterior.Visible = true;
        }
        else
        {
            btnProximo.Visible = false;
            btnAnterior.Visible = false;
        }

        // Botões de Último e Primeiro
        if (qtd > 20)
        {
            btnUltimo.Visible = true;
            btnVoltarPrimeiro.Visible = true;
        }
        else
        {
            btnUltimo.Visible = false;
            btnVoltarPrimeiro.Visible = false;
        }

    }

    protected void btnIr_Click(object sender, EventArgs e)
    {
        string pro_numero;
        pro_numero = txbProcesso.Text;
        if (pro_numero.Equals(""))
        {
            CarregarTabela();
        }
        else
        {
            CarregarTabelaNumero(pro_numero);
        }
        txbProcesso.Text = "";
    }

    public void CarregarTabelaNumero(string pro_numero)
    {
        DataSet ds = ProcessoDB.SelectNumProcesso(pro_numero);
        int qtd = ds.Tables[0].Rows.Count;

        if (qtd > 0)
        {
            example.DataSource = ds.Tables[0].DefaultView;
            example.DataBind();
            example.Visible = true;

            if (qtd == 1)
            {
                lbl.Text = "<h4>Foi Encontrado " + qtd + " registro</h4>";
            }
            else
            {
                lbl.Text = "<h4>Foram encontrados " + qtd + " registros</h4>";
            }

        }
        else
        {
            example.Visible = false;
            lbl.Text = "<h4> Não foram encontrados registros </h4>";
        }
    }

    public void CarregarTabelaNome(string pes_nome)
    {
        DataSet ds = ProcessoDB.SelectNomProcesso(pes_nome);
        int qtd = ds.Tables[0].Rows.Count;

        if (qtd > 0)
        {
            example.DataSource = ds.Tables[0].DefaultView;
            example.DataBind();
            example.Visible = true;

            if (qtd == 1)
            {
                lbl.Text = "<h4>Foi Encontrado " + qtd + " registro</h4>";
            }
            else
            {
                lbl.Text = "<h4>Foram encontrados " + qtd + " registros</h4>";
            }

        }
        else
        {
            example.Visible = false;
            lbl.Text = "<h4> Não foram encontrados registros </h4>";
        }
    }

    protected void ddlEscolha_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEscolha.SelectedIndex == 1)
        {
            mlvEscolha.SetActiveView(view1);
        }
        else if(ddlEscolha.SelectedIndex == 2)
        {
            mlvEscolha.SetActiveView(view2);
        }
        else
        {
            mlvEscolha.SetActiveView(view0);
        }
    }

    protected void btnIr1_Click(object sender, EventArgs e)
    {
        string pes_nome;
        pes_nome = txbNome.Text;
        if (pes_nome.Equals(""))
        {
            CarregarTabela();
        }
        else
        {
            CarregarTabelaNome(pes_nome);
        }
        txbNome.Text = "";
    }
}