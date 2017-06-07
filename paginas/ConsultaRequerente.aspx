<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultaRequerente.aspx.cs" Inherits="paginas_ConsultaRequerente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="telas">

        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">

                        <h2>Consulta de Requerente</h2>

                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>

                        <div class="clearfix"></div>

                    </div>
                    <div class="x_content">

                        <%--Buscar Requerente--%>
                        <div class="title_right">

                            <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search" data-step="1" data-intro="Local da Busca. É possivel realizar a busca pelo Nome, CPF ou CNPJ, Endereço ou Contato do Requerente">

                                <div class="input-group">

                                    <asp:TextBox ID="txbBuscar" runat="server" CssClass="form-control" placeholder="Buscar Requerente..."></asp:TextBox>

                                    <span class="input-group-btn">

                                        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-round btn-default" Text="Buscar" />

                                    </span>

                                </div>

                            </div>

                        </div>
                        <%--/Buscar Requerente--%>

                        <div class="clearfix"></div>

                        <asp:Label ID="lbl" runat="server" data-step="2" data-intro="Todos os Requerente Ativos do Sistema"></asp:Label>


                        <%--<div class="col-md-4 col-sm-4 col-xs-12 animated fadeInDown">
                            <div class="well profile_view">
                                <div class="col-sm-12">
                                    <h4 class="brief"><i>Requerente</i></h4>
                                    <div class="left col-xs-10">
                                        <h2>Lucas Henrique P. dos Santos</h2>

                                        <ul class="list-unstyled">
                                            <li><i class="fa fa-home"></i>Endereço: Alameda São Paulo </li>
                                            <li><i class="fa fa-phone"></i>Telefone: (12) 3133-3133 </li>
                                            <li><i class="fa fa-mobile-phone"></i>Celular: (12) 99608-8247 </li>
                                            <li><i class="fa fa-envelope"></i>E-mail: lucashenriqueear@gmail.com</li>
                                            <br /><br />

                                                       
                                        </ul>
                                    </div>
                                    <div class="right col-xs-2 text-center">
                                        <img src="../images/profile.png" class="img-circle img-responsive" />
                                    </div>
                                </div>
                                <div class="col-xs-12 bottom text-center">
                                    <div class="col-xs-12 col-sm-6 emphasis">
                                        <p class="ratings">
                                            Permissão:
                                            
                                        </p>
                                    </div>
                                    <div class="col-xs-12 col-sm-6 emphasis">

                                        <button type="button" class="btn btn-primary btn-xs">
                                            <i class="fa fa-user"></i>Visualizar
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>--%>


                        
                                 

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
                text: 'Não encontrei nenhum requerente.',
                type: 'info'
            });
        }
    </script>

    <script>
        function ativar(codigo, fun) {
            var jsonText = JSON.stringify({ codigo: codigo, fun: fun });
            $.ajax({
                type: 'POST',
                url: 'ConsultaRequerente.aspx/Ativar',
                data: jsonText,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function () {
                    location.href = "ConsultaRequerente.aspx";
                }
            });
        }
    </script>

    <script>
        function desativar(codigo, fun) {
            var jsonText = JSON.stringify({ codigo: codigo, fun: fun });
            $.ajax({
                type: 'POST',
                url: 'ConsultaRequerente.aspx/Desativar',
                data: jsonText,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function () {
                    location.href = "ConsultaRequerente.aspx";
                }
            });
        }
    </script>

</asp:Content>

