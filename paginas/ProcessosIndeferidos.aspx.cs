using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wistoll.Funcoes;

public partial class paginas_Feed_ProcessosIndeferidos : System.Web.UI.Page
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
                    if (pagina == "ProcessosIndeferidos.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }
                carregarGrid();
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    protected void carregarGrid()
    {
        DataSet ds = ProcessoDB.SelectAllIndeferido();
        int qtd = ds.Tables[0].Rows.Count;
        gridIndeferido.DataSource = ds.Tables[0].DefaultView;
        gridIndeferido.DataBind();
        gridIndeferido.HeaderRow.TableSection = TableRowSection.TableHeader;
        gridIndeferido.Visible = true;
    }

    protected void gridIndeferido_RowCommand(object sender, GridViewCommandEventArgs e)
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
}