using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paginas_ImprimirProcesso : System.Web.UI.Page
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
                    if (pagina == "ConsultaProcesso.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/Erro/Erro404.aspx");
                }

                //CarregarTabela();
                CarregarProcesso();
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    //private void CarregarTabela()
    //{
    //    DataSet ds = ProcessoDB.SelectAll();
    //    int qtd = ds.Tables[0].Rows.Count;
    //    grdProcessos.DataSource = ds.Tables[0].DefaultView;
    //    grdProcessos.DataBind();
    //    grdProcessos.HeaderRow.TableSection = TableRowSection.TableHeader;
    //    grdProcessos.Visible = true;



    //}


    private void CarregarProcesso()
    {
        DataSet ds = new DataSet();
        ds = ProcessoDB.SelectAll();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            string imprimir = "";

            //ds = ModuloDB.ModuloUsuario(fmp.Funcionario.Fun_cod);
            //foreach (DataRow dr1 in ds.Tables[0].Rows)
            //{
            //    if (dr1["mod_descricao"].Equals("Imprimir Processo"))
            //    {
                    //imprimir = "<button type='button' class='btn btn-primary btn-xs' " +
                    //                    " <i class='fa fa-print'>Imprimir</i> " +
                    //         "</button>";
            imprimir = "<button class='btn btn-default' onclick='window.print();'><i class='fa fa-print'></i>Imprimir</button>"; 

            //        break;
            //    }
            //}

            lbl.Text += "<div class='col-md-4 col-sm-4 col-xs-12 animated fadeInDown'>" +
                                    "<div class='well profile_view'>" +
                                        "<div class='col-sm-12'>" +
                                            "<div class='left col-xs-12'>" +
                                                "<h2> <i class='fa fa-file-text'></i> Processo:" + dr["numeroProcesso"] + "</h2>" +
                                                "<ul class='list-unstyled'>" +
                                                    "<li><i class='fa fa-user'></i>  Requerente: " + dr["requerente"] + "</li>" +
                                                    "<li><i  class='fa fa-check'></i>  Finalização: " + dr["dataFinalizar"] + "</li>" +
                                             
                                                    "<br /><br />" +
                                                "</ul>" +
                                            "</div>" +
                                        "</div>" +

                                        "<div class='col-xs-12 bottom text-center'>" +
                                        imprimir +
                                        "</div>" +
                                    "</div>" +
                                "</div>";
        }
        



        }


}