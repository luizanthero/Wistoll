<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TesteReq.aspx.cs" Inherits="paginas_TesteReq" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../fonts/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/animate.min.css" rel="stylesheet" />

    <link href="../css/custom.css" rel="stylesheet" />
    <link href="../css/green.css" rel="stylesheet" />

    <link href="../css/Wistoll.css" rel="stylesheet" />

    <script src='<%=ResolveUrl("~/js/jquery.min.js")%>'></script>
    <script src='<%=ResolveUrl("~/js/custom.js")%>'></script>

</head>
<body>
    <form id="form1" runat="server">
    
        <div class="telas" role="main">


        <div class="clearfix"></div>

        <div class="row">

            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Cadastro de Pessoas </h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>

                            <li><a class="close-link"><i class="fa fa-close"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">


                        <!-- Smart Wizard -->
                        <p>Etapas de Cadastro.</p>
                        <div id="wizard" class="form_wizard wizard_horizontal">

                            <ul class="wizard_steps">

                                <li>
                                    <a href="#step-1">
                                        <span class="step_no">1</span>
                                        <span class="step_descr">Etapa 1<br />
                                            <small>Cadastro do Requerente</small></span>
                                    </a>
                                </li>

                                <li>
                                    <a href="#step-2">
                                        <span class="step_no">2</span>
                                        <span class="step_descr">Etapa 2<br />
                                            <small>Cadastro da Pessoa</small></span>
                                    </a>
                                </li>

                                <li>
                                    <a href="#step-3">
                                        <span class="step_no">3</span>
                                        <span class="step_descr">Etapa 3<br />
                                            <small>Cadastro de Contato</small></span>
                                    </a>
                                </li>

                                <li>
                                    <a href="#step-4">
                                        <span class="step_no">4</span>
                                        <span class="step_descr">Etapa 4<br />
                                            <small>Confirmação do Cadastro</small></span>
                                    </a>
                                </li>

                            </ul>

                            <!-- Formulário da Etapa 1-->

                            <div id="step-1">

                              <%--  <form class="form-horizontal form-label-left">--%>

                                    <center><span class="section"> Cadastro do Requerente </span></center>

                                    <table class="col-md-offset-1 col-md-12">

                                        <tr>
                                            <td class="auto-style6">

                                                <div class="item form-group">

                                                    <label class="control-label col-md-2 col-sm-3 col-xs-12">Número Requerente: <span class="required">*</span></label>
                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                        <asp:TextBox ID="TextBox19" runat="server" CssClass="form-control col-md-7 col-xs-12" data-validate-minmax="5" placeholder="Entre com o número do requerente"></asp:TextBox>

                                                    </div>

                                                </div>

                                            </td>
                                        </tr>
                                        

                                    </table>

                               <%-- </form>--%>

                            </div>

                            <!-- Formulario da ETAPA 2 -->

                            <div id="step-2">

                               <%-- <form class="form-horizontal form-label-left">--%>

                                    <center><span class="section"> Cadastro da Pessoa </span></center>

                                    <div class="item form-group">

                                        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Nome Completo: <span class="required">*</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txbNome" runat="server" CssClass="form-control col-md-7 col-xs-12" data-validate-length-range="3" data-validate-words="2" placeholder="Entre com o nome" ></asp:TextBox>

                                        </div>

                                    </div>

                                    <div class="item form-group">

                                                    <label class="control-label col-md-2 col-sm-3 col-xs-12">Sexo: <span class="required">*</span></label>

                                                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" CssClass="iCheckAsp radio" TextAlign="Left" RepeatDirection="Horizontal" AutoPostBack="True">
                                                        <asp:ListItem>M: </asp:ListItem>
                                                        <asp:ListItem>F: </asp:ListItem>
                                                    </asp:RadioButtonList>

                                    </div>  
                                    
                                    <asp:DropDownList ID="ddlEscolha" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlEscolha_SelectedIndexChanged">
                    <asp:ListItem>Selecione...</asp:ListItem>
                    <asp:listitem>número do processo</asp:listitem>
                    <asp:listitem>nome do requerente</asp:listitem>
                </asp:DropDownList>

                <asp:MultiView ID="mlvEscolha" runat="server">
                    <asp:View ID="view0" runat="server"></asp:View>
                    <asp:View ID="view1" runat="server">
                        <div class="page-title">

                            <div class="title_right">

                                <div class="col-md-5 col-sm-1 form-group pull-right top_search">
                                    <h2>Número do Processo</h2>
                                    <div class="input-group">

                                        <asp:TextBox ID="txbProcesso" runat="server" CssClass="form-control busca" data-inputmask="'mask': '9999-99-99.9999'"></asp:TextBox>

                                        <span class="input-group-btn">

                                            <asp:Button ID="btnIr" runat="server" CssClass="btn btn-round btn-default" Text="Ir!"/>

                                        </span>

                                    </div>

                                </div>

                            </div>

                        </div>
                    </asp:View>
                    <asp:View ID="view2" runat="server">
                        <div class="page-title">

                            <div class="title_right">

                                <div class="col-md-5 col-sm-1 form-group pull-right top_search">
                                    <h2>Nome Completo do Requerente</h2>
                                    <div class="input-group">

                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control busca"></asp:TextBox>

                                        <span class="input-group-btn">

                                            <asp:Button ID="btnIr1" runat="server" CssClass="btn btn-round btn-default" Text="Ir!"  />

                                        </span>

                                    </div>

                                </div>

                            </div>

                        </div>
                    </asp:View>
                </asp:MultiView>                                  

                                <%--</form>--%>

                            </div>

                            <!-- Formulario da ETAPA 3 -->

                            <div id="step-3">

                            <%--    <form class="form-horizontal form-label-left">--%>

                                    <center><span class="section"> Cadastro de Contato </span></center>

                                    <div class="item form-group">

                                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Tipo de Contato: <span class="required">*</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txbMatricula" runat="server" CssClass="form-control col-md-7 col-xs-12" data-validate-minmax="5" placeholder="Entre com o contato"></asp:TextBox>

                                        </div>

                                    </div>


                                <%--</form>--%>

                            </div>

                            <!-- Formulario da ETAPA 4 -->

                            <div id="step-4">

                                <center><h2 class="StepTitle"> Confirmação do Cadastro </h2></center>

                                <div class="ln_solid"></div>

                                <center><h2 class="StepTitle"> Etapa 1 - Cadastro do Requerente </h2></center>

                              <%--  <form class="form-horizontal form-label-left">--%>

                                    <div class="item form-group">

                                        <label class="control-label col-md-3 col-sm-3 col-xs-12">Número Requerimento: <span class="required">*</span></label>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control col-md-7 col-xs-12" disabled="disabled"></asp:TextBox>

                                        </div>

                                    </div>                                    

                                <%--</form>--%>


                            </div>


                        </div>
                    </div>
                </div>

            </div>
        </div>



    </div>



    <script type="text/javascript">
        $(document).ready(function () {
            // Smart Wizard 	
            $('#wizard').smartWizard();

            function onFinishCallback() {
                $('#wizard').smartWizard('showMessage', 'Finish Clicked');
                //alert('Finish Clicked');
            }
        });

        $(document).ready(function () {
            // Smart Wizard	
            $('#wizard_verticle').smartWizard({
                transitionEffect: 'slide'
            });

        });
    </script>

    </form>


    <script src='<%=ResolveUrl("~/js/bootstrap.min.js")%>'></script>

    <!-- chart js -->
    <script src='<%=ResolveUrl("~/js/chart.min.js")%>'></script>
    <!-- bootstrap progress js -->
    <script src='<%=ResolveUrl("~/js/bootstrap-progressbar.min.js")%>'></script>
    <script src='<%=ResolveUrl("~/js/jquery.nicescroll.min.js")%>'></script>
    <!-- icheck -->
    <script src='<%=ResolveUrl("~/js/icheck.min.js")%>'></script>
    <!-- easypie -->
    <script src='<%=ResolveUrl("js/jquery.easypiechart.min.js")%>'></script>

    <script src='<%=ResolveUrl("~/js/ComponentesCustom.js")%>'></script>
    <!-- input mask -->
    <script src='<%=ResolveUrl("~/js/jquery.inputmask.js")%>'></script>

    <script src='<%=ResolveUrl("~/js/jquery.nicescroll.min.js")%>'></script>

    <script src='<%=ResolveUrl("~/js/jquery.smartWizard.js")%>'></script>

    <!-- daterangepicker -->
    <script src="<%=ResolveUrl("~/js/moment.min.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/daterangepicker.js")%>"></script>


    <!-- image cropping -->
    <script src="<%=ResolveUrl("~/js/main.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/cropper.min.js")%>"></script>


    <!-- moris js -->
    <script src="<%=ResolveUrl("~/js/raphael-min.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/morris.js")%>"></script>

    <script src="<%=ResolveUrl("~/js/ScriptPerfil.js")%>"></script>

    <script src="<%=ResolveUrl("~/js/validator.js")%>"></script>

    <script src="<%=ResolveUrl("~/js/pnotify.buttons.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/pnotify.core.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/Pnotify.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/pnotify.nonblock.js")%>"></script>


    <script>
        $(document).ready(function () {
            $('input.tableflat').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green'
            });
        });

        var asInitVals = new Array();
        $(document).ready(function () {
            var oTable = $('#example').dataTable({
                "oLanguage": {
                    "sSearch": "Localize:"
                },
                "aoColumnDefs": [
                    {
                        'bSortable': false,
                        'aTargets': [0]
                    } //disables sorting for column one
                ],
                'iDisplayLength': 12,
                "sPaginationType": "full_numbers",
                "dom": 'T<"clear">lfrtip',
                "tableTools": {
                    "sSwfPath": "<?php echo base_url('assets2/js/Datatables/tools/swf/copy_csv_xls_pdf.swf'); ?>"
                }
            });
            $("tfoot input").keyup(function () {
                /* Filter on the column based on the index of this element's parent <th> */
                oTable.fnFilter(this.value, $("tfoot th").index($(this).parent()));
            });
            $("tfoot input").each(function (i) {
                asInitVals[i] = this.value;
            });
            $("tfoot input").focus(function () {
                if (this.className == "search_init") {
                    this.className = "";
                    this.value = "";
                }
            });
            $("tfoot input").blur(function (i) {
                if (this.value == "") {
                    this.className = "search_init";
                    this.value = asInitVals[$("tfoot input").index(this)];
                }
            });
        });
    </script>

</body>
</html>
