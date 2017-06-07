<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultaUsuario.aspx.cs" Inherits="paginas_ConsultaUsuario2" %>

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

                        <h2>Consulta de Usuário</h2>

                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>

                        <div class="clearfix"></div>

                    </div>

                    <div class="x_content">

                        <div class="row">

                            <%--Buscar Usuário--%>
                            <div class="title_right">

                                <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search" data-step="1" data-intro="Local da Busca. É possivel realizar a busca pelo Nome, Departamento, setor ou contato do Usuário">

                                    <div class="input-group">

                                        <asp:TextBox ID="txbFeed" runat="server" CssClass="form-control busca" placeholder="Buscar Usuário..."></asp:TextBox>

                                        <span class="input-group-btn">

                                            <a class="btn btn btn-round btn-default"><i class="fa fa-search"></i></a>

                                        </span>

                                    </div>

                                </div>

                            </div>
                            <%--/Buscar Usuário--%>

                            <div class="clearfix"></div>

                            <asp:Label ID="lbl" runat="server" data-step="2" data-intro="Todos os Usúarios do Sistema"></asp:Label>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

