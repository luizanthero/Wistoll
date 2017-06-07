<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListaRequerente.aspx.cs" Inherits="paginas_Requerente_ListaRequerente" %>

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

                                    <%-- Inicio da parte da busca  --%>

                                    <div class="title_right">

                                        <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">

                                            <div class="input-group">

                                                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Nova Busca..."></asp:TextBox>

                                                <span class="input-group-btn">

                                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-round btn-success" Text="Ir!" />

                                                </span>

                                            </div>

                                        </div>

                                    </div>

                                    <%-- Fim do campo de busca --%>

                                     <div class="ln_solid"></div>

                                    <div class="x_title">

                                        <h2 class="col-md-12"><i class="fa fa-arrow-down"></i>RESULTADO DA BUSCA <i class="fa fa-arrow-down"></i></h2>

                                        <div class="clearfix"></div>

                                    </div>

                                    <div class="x_content">


                                        <div id="texto">

                                            <p>
                                                <table class="table table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th>#</th>
                                                            <th>Processo</th>
                                                            <th>Data</th>
                                                            <th>Pedido</th>
                                                            <th>Requerente</th>
                                                            <th>Status</th>
                                                            <th>Ação</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <th scope="row">1</th>
                                                            <td>2011.11.10</td>
                                                            <td>10/11/2015</td>
                                                            <td>Oficio</td>
                                                            <td>Lucas</td>
                                                            <td>Finalizado</td>
                                                            <td><a href='<%=ResolveUrl("~/paginas/Requerente/ResultadoRequerente.aspx")%>'><i class="fa fa-folder-open-o"></i>Visualizar </a></td>
                                                        </tr>
                                                        <tr>
                                                            <th scope="row">2</th>
                                                            <td>2012.11.10</td>
                                                            <td>10/11/2015</td>
                                                            <td>Alvara</td>
                                                            <td>Lucas</td>
                                                            <td>Deferido</td>
                                                            <td><a href='<%=ResolveUrl("~/paginas/Requerente/ResultadoRequerente.aspx")%>'><i class="fa fa-folder-open-o"></i>Visualizar </a></td>
                                                        </tr>
                                                        <tr>
                                                            <th scope="row">3</th>
                                                            <td>2013.11.10</td>
                                                            <td>10/11/2015</td>
                                                            <td>Sentença</td>
                                                            <td>Lucas</td>
                                                            <td>Pendente</td>
                                                            <td><a href='<%=ResolveUrl("~/paginas/Requerente/ResultadoRequerente.aspx")%>'><i class="fa fa-folder-open-o"></i>Visualizar </a></td>
                                                        </tr>
                                                        <tr>
                                                            <th scope="row">4</th>
                                                            <td>2014.11.10</td>
                                                            <td>10/11/2015</td>
                                                            <td>Denuncia</td>
                                                            <td>Lucas</td>
                                                            <td>Indeferido</td>
                                                            <td><a href='<%=ResolveUrl("~/paginas/Requerente/ResultadoRequerente.aspx")%>'><i class="fa fa-folder-open-o"></i>Visualizar </a></td>
                                                        </tr>
                                                        <tr>
                                                            <th scope="row">5</th>
                                                            <td>2015.11.10</td>
                                                            <td>10/11/2015</td>
                                                            <td>Administrativo</td>
                                                            <td>Lucas</td>
                                                            <td>Finalizado</td>
                                                            <td><a href='<%=ResolveUrl("~/paginas/Requerente/ResultadoRequerente.aspx")%>'><i class="fa fa-folder-open-o"></i>Visualizar </a></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </p>

                                            <%--<h2 class="col-md-12">Nova Busca: <a href='<%=ResolveUrl("~/paginas/Requerente/BuscaRequerente.aspx")%>'><i class="fa fa-search"></i></a></h2>--%>
                                        </div>

                                        <br />
                                        <br />
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
