using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Wistoll.Funcoes;

public partial class paginas_ConsultaProcesso : System.Web.UI.Page
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
                    if (pagina == "ConsultaProcesso.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }

                CarregarTabela();
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
        
        if(grdProcessos.Rows.Count > 0)
             grdProcessos.HeaderRow.TableSection = TableRowSection.TableHeader;
        
        //deletando o usuario do lucasa
        // __________________
        //|     DELETING     |
        //|__________________|
        // __________________
        //|||||||||50%       |
        //|||||||||__________|
        //
        //

    }

    private void CarregarTabela()
    {
        DataSet ds = ProcessoDB.SelectAll();
        int qtd = ds.Tables[0].Rows.Count;

        grdProcessos.DataSource = ds.Tables[0].DefaultView;
        grdProcessos.DataBind();
        grdProcessos.HeaderRow.TableSection = TableRowSection.TableHeader;
        grdProcessos.Visible = true;



    }

    //    if (qtd > 0)
    //    {
            

    //        if (qtd == 1)
    //        {
    //            lbl.Text = "<h4>Foi Encontrado " + qtd + " registro</h4>";
    //        }
    //        else
    //        {
    //            lbl.Text = "<h4>Foram encontrados " + qtd + " registros</h4>";
    //        }

    //    }
    //    else
    //    {
    //        grdProcessos.Visible = false;
    //        lbl.Text = "Não foram encontrados registros";
    //    }


    //    // Botões de Anteiror e Próximo 
    //    if (qtd > 5)
    //    {
    //        btnProximo.Visible = true;
    //        btnAnterior.Visible = true;
    //    }
    //    else
    //    {
    //        btnProximo.Visible = false;
    //        btnAnterior.Visible = false;
    //    }

    //    // Botões de Último e Primeiro
    //    if (qtd > 20)
    //    {
    //        btnUltimo.Visible = true;
    //        btnVoltarPrimeiro.Visible = true;
    //    }
    //    else
    //    {
    //        btnUltimo.Visible = false;
    //        btnVoltarPrimeiro.Visible = false;
    //    }
    //}

    
    public void CarregarTabelaNumero(string pro_numero)
    {
        DataSet ds = ProcessoDB.SelectNumProcesso(pro_numero);
        int qtd = ds.Tables[0].Rows.Count;

        if (qtd > 0)
        {
            grdProcessos.DataSource = ds.Tables[0].DefaultView;
            grdProcessos.DataBind();
            grdProcessos.Visible = true;

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
            grdProcessos.Visible = false;
            lbl.Text = "<h4> Não foram encontrados registros </h4>";
        }
    }

    public void CarregarTabelaNome(string pes_nome)
    {
        DataSet ds = ProcessoDB.SelectNomProcesso(pes_nome);
        int qtd = ds.Tables[0].Rows.Count;

        if (qtd > 0)
        {
            grdProcessos.DataSource = ds.Tables[0].DefaultView;
            grdProcessos.DataBind();
            grdProcessos.Visible = true;

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
            grdProcessos.Visible = false;
            lbl.Text = "<h4> Não foram encontrados registros </h4>";
        }
    }
    

    protected void grdProcessos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Abrir")
        {
            //Response.Redirect("~/paginas/Process.aspx");

            string caminho = "";

            //Processo pro = new Processo();

            caminho = "~/paginas/Process.aspx?pro=" + Funcoes.AESCodifica(Convert.ToString(e.CommandArgument));
            Response.Redirect(caminho);

        }
    }


    protected void grdProcessos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdProcessos.PageIndex = e.NewPageIndex;
        CarregarTabela();
    }
}