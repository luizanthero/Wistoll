<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewCadastroPadrao.aspx.cs" Inherits="paginas_NewCadastroPadrao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder1" runat="Server">



    <div class="telas">

        <%--   CADASTRO DE MODULO--%>
        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Cadastro de Modulo</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <br />

                        <table class="col-md-offset-3 col-md-12">
                            <tr>
                                <td class="auto-style6">
                                    <h5>Nome<span>*</span>:</h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="item form-group">
                                        <div class="col-md-5 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txbNomeModulo" runat="server" ValidationGroup="cadastroModulo" CssClass="form-control" data-validate-length-range="1" data-validate-words="1" placeholder="Entre com o nome do Modulo" required="required"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <h5>Pagina: </h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="col-md-5 col-sm-6 col-xs-12">
                                        <asp:TextBox ID="txbPag" runat="server" ValidationGroup="cadastroModulo" CssClass="form-control" placeholder="Nome da pagina"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <h5>Modulo Padrão:</h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="col-md-5 col-sm-6 col-xs-12">
                                        <asp:RadioButtonList ID="rblPadrao" runat="server" CssClass="iCheckAsp radio" ValidationGroup="cadastroModulo" TextAlign="Left" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="0">Não:</asp:ListItem>
                                            <asp:ListItem Value="1">Sim:</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </td>
                            </tr>
                        </table>



                        <div class="form-group">
                            <div class="col-md-5 col-md-offset-8">
                                <asp:LinkButton ID="btnApagarModulo" runat="server" CssClass="btn btn-default" data-toggle="tooltip" data-placement="top" title="Apagar" OnClick="btnApagarModulo_Click"><i class="fa fa-trash"></i> Apagar</asp:LinkButton>
                                <asp:LinkButton ID="btnSalvarModulo" runat="server" ValidationGroup="cadastroModulo" CssClass="btn btn-primary" data-toggle="tooltip" data-placement="top" title="Salvar" OnClick="btnSalvarModulo_Click"><i class="fa fa-save"></i> Salvar</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--CADASTRO DE Perfil--%>
        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Cadastro de Perfil</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <br />

                        <table class="col-md-offset-3 col-md-12">
                            <tr>
                                <td class="auto-style6">
                                    <h5>Descrição<span>*</span>:</h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="item form-group">
                                        <div class="col-md-5 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txbDescPerfil" runat="server" ValidationGroup="cadastroPerfil" CssClass="form-control" data-validate-length-range="1" data-validate-words="1" placeholder="Entre com o nome do Perfil" required="required"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                            </tr>

                        </table>

                        <div class="form-group">
                            <div class="col-md-5 col-md-offset-8">
                                <asp:LinkButton ID="btnApagar1" runat="server" CssClass="btn btn-default" data-toggle="tooltip" data-placement="top" title="Apagar"><i class="fa fa-trash"></i> Apagar</asp:LinkButton>
                                <asp:LinkButton ID="btnSalvar1" runat="server" ValidationGroup="cadastroPerfil"  CssClass="btn btn-primary" data-toggle="tooltip" data-placement="top" title="Salvar"><i class="fa fa-save"></i> Salvar</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--CADASTRO DE STATUS--%>
        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Cadastro de Status </h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <br />

                        <table class="col-md-offset-3 col-md-12">
                            <tr>
                                <td class="auto-style6">
                                    <h5>Descrição<span>*</span>:</h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="item form-group">
                                        <div class="col-md-5 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txbDescStatus" runat="server" ValidationGroup="cadastroStatus" CssClass="form-control" data-validate-length-range="1" data-validate-words="1" placeholder="Entre com o nome do Status" required="required"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                            </tr>



                        </table>

                        <div class="form-group">
                            <div class="col-md-5 col-md-offset-8">
                                <asp:LinkButton ID="btnApagarStatus" runat="server" CssClass="btn btn-default" data-toggle="tooltip" data-placement="top" title="Apagar" OnClick="btnApagarStatus_Click"><i class="fa fa-trash"></i> Apagar</asp:LinkButton>
                                <asp:LinkButton ID="btnSalvarStatus" runat="server" CssClass="btn btn-primary" ValidationGroup="cadastroStatus" data-toggle="tooltip" data-placement="top" title="Salvar" OnClick="btnSalvarStatus_Click"><i class="fa fa-save"></i> Salvar</asp:LinkButton>
                                <asp:Label ID="lblStatus" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--CADASTRO CARGO--%>

        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Cadastro de Cargo</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <br />

                        <table class="col-md-offset-3 col-md-12">
                            <tr>
                                <td class="auto-style6">
                                    <h5>Descrição<span>*</span>:</h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="item form-group">
                                        <div class="col-md-5 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txbDescCargo" runat="server" ValidationGroup="cadastroCargo" CssClass="form-control" data-validate-length-range="1" data-validate-words="1" placeholder="Entre com o nome do Cargo" required="required"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                            </tr>

                        </table>

                        <div class="form-group">
                            <div class="col-md-5 col-md-offset-8">
                                <asp:LinkButton ID="btnApagar3" runat="server" CssClass="btn btn-default" data-toggle="tooltip" data-placement="top" title="Apagar"><i class="fa fa-trash"></i> Apagar</asp:LinkButton>
                                <asp:LinkButton ID="btnSalvar3" runat="server" CssClass="btn btn-primary" ValidationGroup="cadastroCargo" data-toggle="tooltip" data-placement="top" title="Salvar"><i class="fa fa-save"></i> Salvar</asp:LinkButton>
                                <asp:Label ID="lblCargo" runat="server"></asp:Label>
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
        function sucess() {
            new PNotify({
                title: 'Parabéns',
                text: 'Consegui cadastrar sem nenhum problema.',
                type: 'success'
            });
        }
    </script>
    <script type="text/javascript">
        function error() {
            new PNotify({
                title: 'Me Desculpe',
                text: 'Não consegui inserir os dados. Tente Novamente!',
                type: 'error'
            });
        }
    </script>

</asp:Content>

