using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using Wistoll.Funcoes;

public partial class paginas_Process : System.Web.UI.Page
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
                    if (pagina == "Process.aspx")
                    {
                        n = 1;
                    }
                }

                if (n != 1)
                {
                    Response.Redirect("~/paginas/erro/erro404.aspx");
                }

                //CarregarComponentes();
                Decodificar();
                CarregarDrop();
                CarregarTramitar(fmp);
                CarregarFinalizar(fmp);
                CarregarDevolver(fmp);
                CarregarUpload();
            }
        }
        else
        {
            Session["info"] = null;
            Response.Redirect("~/paginas/Login.aspx");
        }
    }

    protected void CarregarTramitar(FunMod fmp)
    {
        //Processo pro = new Processo();
        Processo pro = ProcessoDB.Select(Convert.ToInt32(lblCodProcesso.Text));

        DataSet ds = new DataSet();
        ds = ModuloDB.ModuloUsuario(fmp.Funcionario.Fun_cod);
        foreach(DataRow dr in ds.Tables[0].Rows)
        {
            if (dr["mod_descricao"].Equals("Tramitar Processo") && pro.Status.Sta_valor != "Finalizado")
            {
                lnkTramitar1.Visible = true;
                break;
            }
        }
    }

    protected void CarregarFinalizar(FunMod fmp)
    {
        Processo pro = ProcessoDB.Select(Convert.ToInt32(lblCodProcesso.Text));

        DataSet ds = new DataSet();
        ds = ModuloDB.ModuloUsuario(fmp.Funcionario.Fun_cod);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (dr["mod_descricao"].Equals("Finalizar Processo") && pro.Status.Sta_valor != "Finalizado")
            {
                lnkFinalizar.Visible = true;
                break;
            }
        }
    }

    protected void CarregarDevolver(FunMod fmp)
    {
        Processo pro = ProcessoDB.Select(Convert.ToInt32(lblCodProcesso.Text));

        string matricula = TramitacaoDB.SelectDevolver();

        if(matricula == fmp.Funcionario.Fun_matricula && pro.Status.Sta_valor != "Finalizado")
        {
            lnkDevolver.Visible = true;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>AtivarCompose();</script>", false);
        }
    }

    protected void CarregarUpload()
    {
        Processo pro = ProcessoDB.Select(Convert.ToInt32(lblCodProcesso.Text));

        if(pro.Status.Sta_valor == "Finalizado")
        {
            flpArquivos.Visible = false;
            lblNomeAnexo.Visible = false;
            lnkUpload.Visible = false;
        }
    }

    protected void CarregarDrop()
    {
        DataSet ds = new DataSet();
        ds = SetorDB.SelectAllAtivo();

        ddlLocal.DataSource = ds;
        ddlLocal.DataTextField = "set_nome";
        ddlLocal.DataValueField = "set_cod";
        ddlLocal.DataBind();
        ddlLocal.Items.Insert(0, "Selecione..."); ;
    }

    //protected void btnEnviar_Click(object sender, EventArgs e)
    //{
    //    var caminho = @"C:\Users\Luiz Anthero\Downloads";
    //    var nome = fileAnexos.FileName;
    //    var completo = caminho + nome;

    //    fileAnexos.PostedFile.SaveAs(completo);
    //}

    protected void Decodificar()
    {
        string n = "";

        if (Request.QueryString["pro"] != null)
        {
            if (Request.QueryString["pro"].ToString() != "")
            {

                try
                {
                    string pro = Request.QueryString["pro"].ToString().Replace(" ", "+");
                    n = Convert.ToString(Funcoes.AESDecodifica(pro));

                    //return n;
                    CarregarComponentes(n);

                }
                catch (Exception e)
                {
                    n = "";
                }
            }
        }

    }

    protected void CarregarComponentes(string pro_cod)
    {
        DataSet ds = new DataSet();
        ds = ProcessoDB.SelectConsulta(pro_cod);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            DateTime dataFim, dataInicio, dataEnvio;
            TimeSpan time, timeQuinze;

            if (dr["dataFinalizar"] != DBNull.Value)
            {
                dataFim = Convert.ToDateTime(dr["dataFinalizar"]);
            }
            else
            {
                dataFim = Convert.ToDateTime(null);
            }

            dataInicio = Convert.ToDateTime(dr["dataPedido"]);
            time = dataFim.Subtract(dataInicio);

            if (dr["tra_dataEnvio"] != DBNull.Value)
            {
                dataEnvio = Convert.ToDateTime(dr["tra_dataEnvio"]);
            }
            else
            {
                dataEnvio = Convert.ToDateTime(null);
            }

            DateTime dtQuinze = dataEnvio.AddDays(15);
            timeQuinze = dtQuinze.Subtract(DateTime.Now);

            lblCodProcesso.Text = dr["codigo"].ToString();
            lblNroProcesso.Text = dr["numeroProcesso"].ToString();
            lblDetalheProcesso.Text = dr["dpr_cod"].ToString();
            lblTramitacao.Text = dr["tra_cod"].ToString();
            lblLocalAnterior.Text = dr["localAtual"].ToString();
            lblNumeroRedator.Text = dr["codRedator"].ToString();

            lblTitle.Text = "<div class='x_title'>" +
                            "<h2 class='green'>Exibicao do processo: " + dr["numeroProcesso"] + " | Data do envio do processo: " + dr["tra_dataEnvio"] + "</h2>" +
                            "<ul class='nav navbar-right panel_toolbox'>" +
                                "<li><a href='../paginas/ConsultaProcesso.aspx'><i class='fa fa-reply'></i></a></li>" +
                                "<li><a class='collapse-link'><i class='fa fa-chevron-up'></i></a></li>" +
                           "</ul> <div class='clearfix'></div> </div>";

            lblFeddBack.Text += CarregarObservacao(Convert.ToInt32(dr["tra_cod"]));

            lblResumo.Text = "<div class='x_title'>" +
                                        "<h2>Detalhes do Processo </h2>" +
                                        "<div class='clearfix'></div>" +
                                     "</div>" +
                                      "<div class='panel-body'>" +
                                            //"<h4><p class='title'><b>Processo</b></p></h4>" +
                                            "" +
                                            "<h3 class=''><b>Processo </b><i class='green fa fa-book'> " + dr["numeroProcesso"] + "</i></h3>" +
                                            "<div class='project_detail'>" +
                                                "<p class='title'>Número da Tramitação: <asp:Label ID='lblNumeroProcesso' runat='server' Visible='true' ClientIDMode='Static'>" + dr["tra_cod"] + "</asp:Label></p>" +
                                                "<p class='title'>Requerente: " + dr["requerente"] + " " + dr["requerenteSobrenome"] + "</p>" +
                                                "<p class='title'>Requerimento: " + dr["modelo"] + "</p>" +
                                                "<p class='title'>Redator: " + dr["redator"] + " " + dr["redatorSobrenome"] + "</p>" +
                                                "<p class='title'>Portador: " + dr["portador"] + " " + dr["portadorSobrenome"] + "</p>" +
                                                "<p class='title'>Situacao: " + dr["situacao"] + "</p>" +
                                                "<p class='title'>Local Atual: " + dr["localAtual"] + "</p>" +
                                             "</div><br />" +
                                             "<h5>Arquivos do Processo</h5>" +
                                                    "<ul class='list-unstyled project_files'>";

            DataSet dsAnexos = AnexosDB.Select(Convert.ToInt32(lblDetalheProcesso.Text));
            foreach (DataRow drAnexos in dsAnexos.Tables[0].Rows)
            {
                lblResumo.Text += "<li><a href='" + ConfigurationManager.AppSettings["url"] + "file/" + lblNroProcesso.Text.Replace('/', '-') + "/" + drAnexos["anx_nome"] + "' target='_blank'><i class='fa fa-file-word-o'></i>" + drAnexos["anx_descricao"] + "</a></li>";
            }
            

            //lblResumo.Text += "<li><a href='#'><i class='fa fa-file-pdf-o'></i>UAT.pdf</a></li>" +
            //                                        "<li><a href='#'><i class='fa fa-mail-forward'></i>Email-para-Flatbal.mln</a></li>" +
            //                                        "<li><a href='#'><i class='fa fa-picture-o'></i>Logo.png</a></li>" +
            //                                        "<li><a href='#'><i class='fa fa-file-word-o'></i>Contrato-10_12_2014.docx</a></li>";
            lblResumo.Text += "</ul><br />" +
                                "<div class='ln_solid'></div>" +
                                "<div class='text-center mtop20'>" +
                                "</div>";

            string diasRestantes = "", diasExibir = "", tramite = "";
            if (timeQuinze.TotalDays <= 0)
                diasRestantes = "0";
            else
                diasRestantes = timeQuinze.TotalDays.ToString();

            if (timeQuinze.TotalDays == 1)
            {
                diasExibir = diasRestantes + " dia";
            }
            else
            {
                diasExibir = diasRestantes + " dias";
            }

            if (dr["dataFinalizar"].Equals(null))
            {
                tramite = "Total de dias em trâmite";
            }
            else
            {
                tramite = "Tempo usado para finalizar";
            }

            string dtEnvio;
            string dtFim;
            string dias;
            if(dataEnvio.ToString()== "01/01/0001 00:00:00" || dataFim.ToString() == "01/01/0001 00:00:00")
            {
                dtEnvio = "0";
                dtFim = "0";
            }else
            {
                dtEnvio = dtQuinze.ToShortDateString();
                dtFim = dataFim.ToShortDateString();
            }
            if (time.TotalDays < 0)
                dias = "0";
            else
                dias = time.TotalDays.ToString();

            lblTempo.Text = "<ul class='stats-overview'>" +
                                 "<li><span class='name'>Tempo restante no setor </span><span class='value text-success'> " + diasExibir + " </span></li>" +
                                 "<li><span class='name'>Data prevista para devolução </span><span class='value text-success'> " + dtEnvio   + "</span></li>" +
                                 "<li class='name'><span class='name'>" + tramite + "</span><span class='value text-success'>" +dias + " dias</span></li>" +
                                "</ul><br />";

        }
    }

    protected string CarregarObservacao(int codigo)
    {
        string observacao = "";
        DataSet ds = new DataSet();
        ds = ObservacaoDB.Select(codigo);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            string ano, mes, dia, nomeMes = "";
            mes = DateTime.Now.ToString();
            dia = dr["obs_dataObservacao"] + "";
            dia = dia.Substring(0, 2);
            mes = dr["obs_dataObservacao"] + "";
            mes = mes.Substring(3, 2);
            ano = dr["obs_dataObservacao"] + "";
            ano = ano.Substring(6, 4);

            switch (mes)
            {
                case "01":
                    nomeMes = "Janeiro";
                    break;
                case "02":
                    nomeMes = "Fevereiro";
                    break;
                case "03":
                    nomeMes = "Março";
                    break;
                case "04":
                    nomeMes = "Abri";
                    break;
                case "05":
                    nomeMes = "Maio";
                    break;
                case "06":
                    nomeMes = "Junho";
                    break;
                case "07":
                    nomeMes = "Julho";
                    break;
                case "08":
                    nomeMes = "Agosto";
                    break;
                case "09":
                    nomeMes = "Setembro";
                    break;
                case "10":
                    nomeMes = "Outubro";
                    break;
                case "11":
                    nomeMes = "Novembro";
                    break;
                case "12":
                    nomeMes = "Dezembro";
                    break;
            }

            observacao += "<ul class='messages'>" +
                                    "<li>" +
                                        "<img src='../images/logo.png' class='avatar' alt='Avatar'/>" +
                                            "<div class='message_date'>" +
                                                "<h3 class='date text-info'>" + dia + "</h3>" +
                                                    "<p class='month'>" + nomeMes + "/" + ano + " </p>" +
                                             "</div>" +

                                              "<div class='message_wrapper'>" +
                                                    CarregarUsuario(Convert.ToInt32(dr["fun_cod"]), dia, mes, ano) +
                                                     "<blockquote class='message'>" + dr["obs_valor"] + "</blockquote><br />" +
                                                        "<p class='url'>" +
                                                            "<span class='fs1 text-info' aria-hidden='true' data-icon='?'></span>" +
                                                         //"<a href='#'><i class='fa fa-file-word-o'></i>Contrato-10_12_2014.docx</a>" +
                                                         "</p>" +
                                               "</div>" +
                                       "</li>" +
                                   "</ul>";
        }

        return observacao;
    }

    protected string CarregarUsuario(int codigo, string dia, string mes, string ano)
    {
        string usuario = "";
        Funcionario fun = FuncionarioDB.Select(codigo);
        usuario = "<h4 class='heading'>" + fun.Setor.Set_nome + "</h4>" +
                  "<div class='byline'>" +
                    "<span>" + dia + "/" + mes + "/" + ano + "</span> <a href='#''>" + fun.Pessoa.Pes_nome + " " + fun.Pessoa.Pes_sobrenome + "</a>" +
                  "</div><br />";

        return usuario;
    }

    protected void lnkUpload_Click(object sender, EventArgs e)
    {
        lblNroProcesso.Text = lblNroProcesso.Text.Replace('/', '-');
        string dir = Request.PhysicalApplicationPath + "file\\" + lblNroProcesso.Text + "\\";
        if (!Directory.Exists(dir))
        {
            //Caso não exista devermos criar
            Directory.CreateDirectory(dir);
        }

        try
        { //pegar o nome do arquivo
            string arq = flpArquivos.PostedFile.FileName;
            //tamanho maximo do upload em kb
            double permitido = 400;
            // Teste para verificar se foi submetido o arquivo
            if (flpArquivos.PostedFile != null)
            {
                //identificamos o tamanho do arquivo
                double tamanho = Convert.ToDouble(flpArquivos.PostedFile.ContentLength) / 1024;
                //verificamos a extensão através dos últimos 4 caracteres
                string extensao = arq.Substring(arq.Length - 4).ToLower();

                // o tamanho acima do permitido
                if (tamanho > permitido)
                { 
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>infoTamanho();</script>", false);
                    //tamanho do arquivo não suportado!
                }
                else if ((extensao != ".doc" && extensao != ".pdf" && extensao != "docx"))
                { 
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>infoExtensao();</script>", false);
                    //extensão diferente de doc, docx e pdf: extensão inválida
                }
                else
                {
                    string diretorio = "";
                    string nomeArquivo = DateTime.Now.ToString("yyyyMMddHHmmss");
                    //diretorio onde será gravado o arquivo criar o diretório arquivos no mesmo local da aplicação
                    if (extensao.Contains('.'))
                    { 
                        nomeArquivo = nomeArquivo + extensao;
                    }
                    else
                    { 
                        nomeArquivo = nomeArquivo + "." + extensao;
                    }

                    diretorio = Request.PhysicalApplicationPath + "file\\" + lblNroProcesso.Text + "\\" + nomeArquivo;
                    // verifica se já existe o nome do arquivo submetido

                    flpArquivos.PostedFile.SaveAs(diretorio);
                    
                    if(txbAnexoNome.Text != "")
                    {
                        Anexos anx = new Anexos();
                        anx.Dpr_cod = Convert.ToInt32(lblDetalheProcesso.Text);
                        FunMod fmp = (FunMod)Session["funcionario"];
                        anx.Cod_fun = fmp.Funcionario.Fun_cod;
                        anx.Anx_descricao = txbAnexoNome.Text;
                        anx.Anx_nome = nomeArquivo;

                        switch (AnexosDB.Insert(anx))
                        {
                            case 0:
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>sucess();</script>", false);
                                string pro = Request.QueryString["pro"].ToString().Replace(" ", "+");
                                Response.Redirect("../paginas/Process.aspx?pro=" + pro);
                                break;
                            case -2:
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
                                break;
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>warning();</script>", false);
                    }
                }
            }
            else
            { 
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false);
            }
        }
        catch { Page.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script>error();</script>", false); }
    }

    protected void lnkTramitar_Click(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];

        int codigo = Convert.ToInt32(ddlLocal.SelectedValue), fun_cod = 0;

        DataSet ds = new DataSet();
        ds = TramitacaoDB.ConsultaUsuario(codigo);

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            fun_cod = Convert.ToInt32(dr["fun_cod"]);
        }

        Tramitacao tra = new Tramitacao();
        tra.Funcionario = new Funcionario();

        string data = DateTime.Now.ToString();
        data = data.Substring(0, 10);

        tra.Tra_cod = Convert.ToInt32(lblTramitacao.Text);
        tra.Funcionario.Fun_cod = fun_cod;
        tra.Cod_fun = fmp.Funcionario.Fun_cod;
        tra.Tra_localAtual = ddlLocal.SelectedItem.Text;
        tra.Tra_dataEnvio = data;
        tra.Tra_localAnteriror = lblLocalAnterior.Text;

        switch (TramitacaoDB.Atualizar(tra))
        {
            case 0:
                break;
            case -2:
                break;
        }
    }

    [System.Web.Services.WebMethod(EnableSession = true)]
    public static void Enviar(string texto, int numero)
    {
        FunMod fmp = (FunMod)HttpContext.Current.Session["funcionario"];
        int codigo = fmp.Funcionario.Fun_cod;

        string pagina = Convert.ToString(HttpContext.Current.Request.Url);

        string data = DateTime.Now.ToString();
        data = data.Substring(0, 10);
        Observacao obs = new Observacao();
        Funcionario fun = new Funcionario();
        Tramitacao tra = new Tramitacao();
        obs.Funcionario = fun;
        obs.Tramitacao = tra;

        obs.Obs_valor = texto;
        obs.Obs_dataObservacao = data;
        obs.Tramitacao.Tra_cod = numero;
        obs.Funcionario.Fun_cod = codigo;

        if(texto != "")
        {
            ObservacaoDB.Insert(obs);
        }
    }

    protected void lnkDevolver_Click(object sender, EventArgs e)
    {
        FunMod fmp = (FunMod)Session["funcionario"];

        Funcionario fun = FuncionarioDB.Select(Convert.ToInt32(lblNumeroRedator.Text));

        Tramitacao tra = new Tramitacao();
        tra.Funcionario = new Funcionario();

        tra.Tra_cod = Convert.ToInt32(lblTramitacao.Text);
        tra.Tra_localAtual = fun.Setor.Set_nome;
        tra.Tra_localAnteriror = lblLocalAnterior.Text;
        string data = DateTime.Now.ToString();
        data = data.Substring(0, 10);
        tra.Tra_dataEnvio = data;
        tra.Funcionario.Fun_cod = Convert.ToInt32(lblNumeroRedator.Text);
        tra.Cod_fun = fmp.Funcionario.Fun_cod;

        switch (TramitacaoDB.Atualizar(tra))
        {
            case 0:
                Response.Redirect("../paginas/Process.aspx?pro=" + Request.QueryString["pro"].Replace(" ", "+"));
                break;
            case -2:
                break;
        }
    }

    protected void lnkSim_Click(object sender, EventArgs e)
    {
        switch (ProcessoDB.Finalizar(Convert.ToInt32(lblCodProcesso.Text))){
            case 0:
                Response.Redirect("../paginas/Process.aspx?pro=" + Request.QueryString["pro"].Replace(" ", "+"));
                break;
            case -2:
                break;
        }
    }
}