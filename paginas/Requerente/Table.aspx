<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Table.aspx.cs" Inherits="paginas_Requerente_Table" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../fonts/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../css/animate.min.css" rel="stylesheet" />

    <link href="../../css/custom.css" rel="stylesheet" />
    <link href="../../css/green.css" rel="stylesheet" />

    <link href="../../css/Wistoll.css" rel="stylesheet" />

    <script src='<%=ResolveUrl("~/js/jquery.min.js")%>'></script>
    <script src='<%=ResolveUrl("~/js/custom.js")%>'></script>

</head>
<body class="nav-md">
    <form id="form1" runat="server">


        <div class="right_col" role="main">
            <div class="">

                <h3>Escolha o tipo de pesquisa</h3>

                <asp:dropdownlist id="ddlEscolha" runat="server" cssclass="form-control" autopostback="true" onselectedindexchanged="ddlEscolha_SelectedIndexChanged">
                    <asp:ListItem>Selecione...</asp:ListItem>
                    <asp:listitem>número do processo</asp:listitem>
                    <asp:listitem>nome do requerente</asp:listitem>
                </asp:dropdownlist>

                <asp:MultiView ID="mlvEscolha" runat="server" ActiveViewIndex="0">
                    <asp:View ID="view0" runat="server"></asp:View>
                    <asp:View ID="view1" runat="server">
                        <div class="page-title">

                            <div class="title_right">

                                <div class="col-md-5 col-sm-1 form-group pull-right top_search">
                                    <h2>Número do Processo</h2>
                                    <div class="input-group">

                                        <asp:TextBox ID="txbProcesso" runat="server" CssClass="form-control busca" data-inputmask="'mask': '9999-99-99.9999'"></asp:TextBox>

                                        <span class="input-group-btn">

                                            <asp:Button ID="btnIr" runat="server" CssClass="btn btn-round btn-default" Text="Ir!" OnClick="btnIr_Click" />

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

                                        <asp:TextBox ID="txbNome" runat="server" CssClass="form-control busca"></asp:TextBox>

                                        <span class="input-group-btn">

                                            <asp:Button ID="btnIr1" runat="server" CssClass="btn btn-round btn-default" Text="Ir!" OnClick="btnIr1_Click" />

                                        </span>

                                    </div>

                                </div>

                            </div>

                        </div>
                    </asp:View>
                </asp:MultiView>

                <div class="clearfix"></div>

                <div class="row">

                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="x_panel">
                            <div class="x_title">
                                <h2>Daily active users <small>Sessions</small></h2>
                                <ul class="nav navbar-right panel_toolbox">
                                    <li><a href="#"><i class="fa fa-chevron-up"></i></a>
                                    </li>
                                    <li class="dropdown">
                                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                                        <ul class="dropdown-menu" role="menu">
                                            <li><a href="#">Settings 1</a>
                                            </li>
                                            <li><a href="#">Settings 2</a>
                                            </li>
                                        </ul>
                                    </li>
                                    <li><a href="#"><i class="fa fa-close"></i></a>
                                    </li>
                                </ul>
                                <div class="clearfix"></div>
                            </div>
                            <div class="x_content">

                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:GridView ID="example" runat="server" CssClass="table table-striped responsive-utilities jambo_table" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="pes_nome" HeaderText="Nome" />
                                                <asp:BoundField DataField="pro_numeroProcesso" HeaderText="Número Processo" />
                                                <asp:BoundField DataField="pro_numeroProtocolo" HeaderText="Número Protocolo" />
                                                <asp:BoundField DataField="pro_dataPedido" HeaderText="Data do Pedido" />
                                                <asp:BoundField DataField="mrq_modelo" HeaderText="Tipo de Processo" />
                                                <asp:BoundField DataField="dpr_dataInicio" HeaderText="Data de Inicio" />
                                                <asp:BoundField DataField="dpr_dataFinalizar" HeaderText="Data de Finalização" />
                                                <asp:BoundField HeaderText="Ação" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                                <asp:Label ID="lbl" runat="server" Text=""></asp:Label>

                                <div class="form-group">
                                    <div class="col-md-5 col-md-offset-7">
                                        <asp:LinkButton ID="btnVoltarPrimeiro" runat="server" CssClass="btn btn-primary" data-toggle="tooltip" data-placement="top" title="Primeira Página"><i class="fa fa-angle-double-left"></i> Primeiro </asp:LinkButton>
                                        <asp:LinkButton ID="btnAnterior" runat="server" CssClass="btn btn-success" data-toggle="tooltip" data-placement="top" title="Anterior"><i class="fa fa-angle-double-left"></i> Anterior </asp:LinkButton>
                                        <asp:LinkButton ID="btnProximo" runat="server" CssClass="btn btn-success" data-toggle="tooltip" data-placement="top" title="Próximo">Próximo <i class="fa fa-angle-double-right"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btnUltimo" runat="server" CssClass="btn btn-success" data-toggle="tooltip" data-placement="top" title="Último"><i class="fa fa-angle-double-left"></i> Último </asp:LinkButton>

                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>

                    <br />
                    <br />
                    <br />

                </div>

            </div>
        </div>
        <!-- /page content -->

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
