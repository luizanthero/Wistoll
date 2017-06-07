<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultaDepartamento.aspx.cs" Inherits="paginas_ConsultaDepartamento" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--/** ********  Busca Div  ********** **/--%>
    <script>
        var str;
        $(document).ready(function () {
            $(".busca").keyup(function (event) {
                str = $(".busca").val();
                var er = new RegExp(str, "im");
                $(".profile_view").stop().hide(1000);
                $(".profile_view").each(function () {
                    val = $(this).html();
                    if (er.test(val)) {
                        $(this).stop().show(1000);
                    }
                });
            });
        });
    </script>
    <%--/** ********  Busca Div  ********** **/--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="telas">

        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">

                    <div class="x_title">

                        <h2>Consulta de Departamento</h2>

                        <ul class="nav navbar-right panel_toolbox" >
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>

                        <div class="clearfix"></div>

                    </div>

                    <div class="x_content">

                        <%--Buscar Departamento--%>
                        <div class="title_right">

                            <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search" data-step="2" data-intro="Local de Busca. É possivel realizar a busca pelo Nome, código, e pelo no do Chefe ou sua Matrícula do Departamento">

                                <div class="input-group">

                                    <asp:TextBox ID="txbFeed" runat="server" CssClass="form-control busca" placeholder="Buscar Departamento..."></asp:TextBox>

                                    <span class="input-group-btn">

                                        <a class="btn btn btn-round btn-default"><i class="fa fa-search"></i></a>

                                    </span>

                                </div>

                            </div>

                        </div>
                        <%--/Buscar Departamento--%>


                        <%---<li><i class='fa fa-users'></i> Quantidade de funcionários: 25</li>---%>

                        <div class="clearfix"></div>

                        <asp:Label ID="lbl" runat="server"></asp:Label>

                        <%--<div class="col-md-4 col-sm-4 col-xs-12 animated fadeInDown">
                            <div class="well profile_view">
                                <div class="col-sm-12">
                                    <div class="left col-xs-12">
                                        <h2>Teste</h2>
                                        <ul class="list-unstyled">
                                            <li>Codigo: </li>
                                            <li>Descrição: </li>
                                            <li><i class="fa fa-user"></i> Chefe do Departamento: </li>
                                            <li>Matrícula: </li>
                                            <br /><br />
                                        </ul>
                                    </div>
                                </div>
                                <div class="col-xs-12 bottom text-center">
                                    <a>
                                        <i></i>
                                    </a>
                                </div>
                            </div>
                        </div>--%>

                        <div id="Excluir" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-hidden="true">
                            <div class="modal-dialog modal-sm">
                                <div class="modal-content">

                                    <div class="modal-header">
                                        <center><h3 class="modal-title center red" id="modal1"> Deseja realmente excluir? </h3></center>
                                   </div>

                                    <div class="modal-footer">
                                        <div class="form-group">
                                            <div class="col-md-6">

                                                <table class="col-md-offset-2">
                                                    <tr>
                                                        <td><asp:LinkButton ID="lnkConfirma" runat="server" CssClass="btn btn-default" data-toggle="tooltip" data-placement="bottom" title="Confirmar">Confirmar <i class="fa fa-check"></i></asp:LinkButton></td>
                                                        <td><a></a></td>
                                                        <td><asp:LinkButton ID="lnkCancelar" runat="server" CssClass="btn btn-default" data-toggle="tooltip" data-placement="bottom" title="Cancelar" data-dismiss="modal">Cancelar <i class="fa fa-close"></i></asp:LinkButton></td>
                                                    </tr>
                                                </table>

                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div id="Ativar" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-hidden="true">
                            <div class="modal-dialog modal-sm">
                                <div class="modal-content">

                                    <div class="modal-header">
                                        <center><h3 class="modal-title center red" id="modal2"> Deseja realmente Ativar? </h3></center>
                                   </div>

                                    <div class="modal-footer">
                                        <div class="form-group">
                                            <div class="col-md-6">

                                                <table class="col-md-offset-2">
                                                    <tr>
                                                        <td><asp:LinkButton ID="lnkConfirma1" runat="server" CssClass="btn btn-default" data-toggle="tooltip" data-placement="bottom" title="Confirmar">Confirmar <i class="fa fa-check"></i></asp:LinkButton></td>
                                                        <td><a></a></td>
                                                        <td><asp:LinkButton ID="lnkCancelar2" runat="server" CssClass="btn btn-default" data-toggle="tooltip" data-placement="bottom" title="Cancelar" data-dismiss="modal">Cancelar <i class="fa fa-close"></i></asp:LinkButton></td>
                                                    </tr>
                                                </table>

                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="<%=ResolveUrl("~/js/pnotify.buttons.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/pnotify.core.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/Pnotify.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/pnotify.nonblock.js")%>"></script>
    <script type="text/javascript">
        function info() {
            new PNotify({
                title: 'Lamento',
                text: 'Não encontrei nenhum departamento.',
                type: 'info'
            });
        }
    </script>

    <script>
        function ativar(codigo, fun) {
            var jsonText = JSON.stringify({ codigo: codigo, fun: fun });
            $.ajax({
                type: 'POST',
                url: 'ConsultaDepartamento.aspx/Ativar',
                data: jsonText,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function () {
                    location.href = "ConsultaDepartamento.aspx";
                }
            });
        }
    </script>

    <script>
        function desativar(codigo, fun) {
            var jsonText = JSON.stringify({ codigo: codigo, fun: fun });
            $.ajax({
                type: 'POST',
                url: 'ConsultaDepartamento.aspx/Desativar',
                data: jsonText,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function () {
                    location.href = "ConsultaDepartamento.aspx";
                }
            });
        }
    </script>

</asp:Content>

