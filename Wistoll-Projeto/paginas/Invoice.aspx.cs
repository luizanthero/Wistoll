using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class paginas_Invoice : System.Web.UI.Page
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
                    if (pagina == "Invoice.aspx")
                    {
                        n = 1;
                    }

                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }

                cabecalho(fmp);
                Tabela();
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }


    protected void cabecalho(FunMod fmp)
    {

        string nome = "", atual = "", data = "", hora = "", email = "";

        nome = fmp.Funcionario.Pessoa.Pes_nome + " " + fmp.Funcionario.Pessoa.Pes_sobrenome;
        atual = DateTime.Now.ToString();
        data = atual.Substring(0, 10);
        hora = atual.Substring(10, 9);

        DataSet ds = new DataSet();
        ds = ContatoDB.SelectContatos(fmp.Funcionario.Fun_cod);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (dr["con_tipo"].Equals("Email"))
            {
                email += "<br>" + dr["con_tipo"] + ": " + dr["con_valor"];
            }
            else
            {
                email += "";
            }
        }

        lblCabecalho.Text = "<div class='row invoice-info'>" +
                                "<div class='col-sm-4 invoice-col'>" +
                                    "Solicitante: " +
                                    "<address>" +

                                        "<strong>" + nome + "</strong>" +
                                         email +

                                    "</address>" +
                                  "</div>" +

                                   "<div class='col-sm-4 invoice-col'>" +
                                         //"<b>Relatório: #383947 </b><br/>" +												
                                         "<b>Data: </b>" + data + "<br/><b> Hora: </b>" + hora +
                                    "</div>" +
                              "</div>";
    }

    protected void Tabela()
    {
        DataSet ds = AuditoriaDB.SelectAll();
        grdAuditoria.DataSource = ds.Tables[0].DefaultView;
        grdAuditoria.DataBind();
        //grdAuditoria.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void grdAuditoria_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}