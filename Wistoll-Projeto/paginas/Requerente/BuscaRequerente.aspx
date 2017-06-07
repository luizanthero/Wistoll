<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuscaRequerente.aspx.cs" Inherits="paginas_Requerente_BuscaRequerente" %>

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

</head>
<body class="nav-md">

    <form id="form1" runat="server">

        <div class="container body telas">

            <div class="main_container">

                <br />
                <br />
                <br />
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

                                    <h2 class="col-md-12"><i class="fa fa-arrow-down"></i>REALIZE A BUSCA POR <i class="fa fa-arrow-down"></i></h2>

                                    <div class="clearfix"></div>

                                </div>

                                <div class="x_content">

                                    <br />

                                    <form id="form2" data-parsley-validate class="form-horizontal form-label-left">

                                        <div class="form-group">

                                            <%--<asp:Label ID="Label1" runat="server" CssClass="control-label col-md-4"> Numero do processo<span class="required">*</span> / Nome do Requerente <span class="required">*</span> </asp:Label>--%>
                                            <label class="control-label col-md-4">Numero do processo<span class="required">*</span> / Nome do Requerente <span class="required">*</span></label>

                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtRequerente" runat="server" CssClass="form-control col-md-6" required="required"></asp:TextBox>
                                                <%--<input type="text" runat="server" id="txtRequerente" class="form-control col-md-6" required="required" data-toggle="tooltip" data-placement="bottom" title="Obrigatório Preeencher" />--%>
                                            </div>


                                            <div class="col-md-offset-8">

                                                <div class="col-md-4">
                                                    <asp:LinkButton ID="lkBusca" runat="server" CssClass="btn btn-success" data-toggle="tooltip" data-placement="bottom" title="Buscar" PostBackUrl="~/paginas/Requerente/ListaRequerente.aspx" TabIndex="1"><i class="fa fa-search"></i> Buscar</asp:LinkButton>
                                                </div>

                                                <div class="col-md-1">

                                                    <asp:LinkButton ID="lkCancelar" runat="server" CssClass="btn btn-primary" data-toggle="tooltip" data-placement="bottom" title="Cancelar" TabIndex="2"><i class="fa fa-close"></i> Cancelar</asp:LinkButton>
                                                    
                                                </div>

                                            </div>

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

                                    </form>



                                </div>


                            </div>


                        </div>

                    </div>


                    <div class="clearfix"></div>
                    <!-- /page content -->

                </div>



                <br />
                <br />



            </div>

          
        </div>
    </form>

    <div id="custom_notifications" class="custom-notifications dsp_none">
                <ul class="list-unstyled notifications clearfix" data-tabbed_notifications="notif-group">
                </ul>
                <div class="clearfix"></div>
                <div id="notif-group" class="tabbed_notifications"></div>
            </div>

            <script src="../../js/bootstrap.min.js"></script>

            <script src="../../js/custom.js"></script>

</body>
</html>
