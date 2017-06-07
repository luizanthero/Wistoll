<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResultadoRequerente.aspx.cs" Inherits="paginas_Requerente_ResultadoRequerente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Wistoll</title>

    <link href="../../css/bootstrap.min.css" rel="stylesheet" />

    <link href="../../fonts/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../css/animate.min.css" rel="stylesheet" />

    <!-- Custom styling plus plugins -->
    <link href="../../css/custom.css" rel="stylesheet" />


    <script src="../../js/jquery.min.js"></script>
    <script src="../../js/custom.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="container body telas">

                <div class="main_container">

                    <br />
                    <br />
                    

                    <div class="row">

                        <div class="col-md-1"></div>

                        <div class="col-md-10">

                            <div class="text-center">

                                <div class="x_panel">

                                    <div class="col-md-12">
                                        <div class="col-middle">
                                            <div class="text-center">

                                                <h1 class="error-number"><i class="fa fa-paw"></i>istoll</h1>

                                                <h4>Sistema de Gerenciador de Protocolos </h4>
                                                <div class="ln_solid"></div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="x_title">

                                        <h2 class="col-md-12"><i class="fa fa-arrow-down"></i> VISUALIZAÇÃO <i class="fa fa-arrow-down"></i></h2>

                                        <ul class="nav navbar-right panel_toolbox">

                                                                                         
                                            <li>
                                                <a class="atalho" href="javascript: index=9;zoom(mais)" onfocus="javascript: index=9;zoom(mais)" accesskey="N" title="Tamanho Normal">
                                                    <h3><i class="fa fa-reply"></i></h3>
                                                </a>
                                            </li>
                                            <li><a></a></li>
                                            <li>
                                                <a class="atalho" href="javascript: zoom(menos)" onfocus="javascript: zoom(menos)" accesskey="M" title="Diminuir 10%">
                                                    <h3><i class="fa fa-search-minus"></i></h3>
                                                </a>
                                            </li>
                                            <li><a></a></li>
                                            <li>
                                                <a class="atalho" href="javascript: zoom(mais)" onfocus="javascript: zoom(mais)" accesskey="A" title="Aumenter 10%">
                                                    <h3><i class="fa fa-search-plus"></i></h3>
                                                </a>
                                            </li>
                                           
                                            <li><a></a></li><li><a></a></li><li><a></a></li><li><a></a></li>
                                            <li><a></a></li><li><a></a></li><li><a></a></li><li><a></a></li>

                                            <li>
                                                <a href='<%=ResolveUrl("~/paginas/Requerente/ListaRequerente.aspx")%>'>
                                                    <h3><i class="fa fa-close" data-toggle="tooltip" data-placement="bottom" title="Movimentar Painel"></i></h3>
                                                </a>
                                            </li>

                                        </ul>

                                        <div class="clearfix"></div>

                                    </div>

                                    <div class="x_content">

                                        <ul class="nav navbar-right panel_toolbox">
                                            <input type="hidden" value="100%" id="percent" size="2" class="form-control" />
                                        </ul>

                                        <h3>Processo: 2011.11.10 </h3>
                                        <br />
                                        <div id="texto">
                                            <p>
                                                Situação: Finalizado
                                            </p>

                                            <p>
                                                Este processo, por sua vez após ser feita toda a análise e concluido as etapas necessárias,
                                                foi finalizado e estará sujeito a uma nova abertura caso os serviços requisitados pelo requerente
                                                acabem de ser válidos pela legislação ou ele necessite de um novo documento.
                                            </p>
                                        </div>

                                        <br /><br />
                                        <div class="ln_solid"></div>
                                        <!-- footer content -->
                                        <footer>
                                            <div class="">
                                                <p class="pull-right">
                                                    Sistema Gerenciador de Potocolos. |
                                                    <span class="lead"><i class="wi fa-paw"></i>istoll</span>
                                                </p>
                                            </div>
                                            <div class="clearfix"></div>
                                        </footer>

                                    </div>

                                </div>

                            </div>

                        </div>

                    </div>

                </div>

            </div>

            

        </div>
    </form>

    <div id="custom_notifications" class="custom-notifications dsp_none">
                <ul class="list-unstyled notifications clearfix" data-tabbed_notifications="notif-group">
                </ul>
                <div class="clearfix"></div>
                <div id="notif-group" class="tabbed_notifications"></div>
            </div>


            <script src="../../js/ComponentesCustom.js"></script>
            <script src="../../js/bootstrap.min.js"></script>

            
           
</body>
</html>
