<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AlterarDepartamento.aspx.cs" Inherits="paginas_AlterarDepartamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder1" Runat="Server">
    <div class="telas">

        <%--Formulario Atualização--%>
        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Cadastro de Departamento</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <br />

                        <table class="col-md-11 col-md-12">
                            <tr>
                                <td class="auto-style6">
                                    <h5>Código:</h5>
                                </td>
                                <td class="auto-style6">
                                    <div class="item form-group">
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txbCodigo" runat="server" CssClass="form-control" data-validate-length-range="1" data-validate-words="1" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <h5>Nome do Departamento<span>*</span>:</h5>
                                </td>
                                <td class="auto-style6">
                                    <div class="item form-group">
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txbNome" runat="server" CssClass="form-control" data-validate-length-range="1" data-validate-words="1" placeholder="Entre com o nome do departamento" required="required"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <h5>Descrição:</h5>
                                </td>
                                <td class="auto-style6">
                                    <div class="form-group">
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txbDesc" runat="server" CssClass="form-control col-md-7 col-xs-12" placeholder="Descrição do departamento"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <div class="item form-group">
                            <div class="col-md-5 col-md-offset-7">
                                <asp:LinkButton ID="btnVoltar" runat="server" CssClass="btn btn-success" data-toggle="tooltip" data-placement="top" title="Voltar" OnClick="btnVoltar_Click"><i class="fa fa-reply"></i> Voltar</asp:LinkButton>
                                <asp:LinkButton ID="btnAtualizar" runat="server" CssClass="btn btn-primary" data-toggle="tooltip" data-placement="top" title="Salvar" OnClick="btnAtualizar_Click"><i class="fa fa-save"></i> Atualizar</asp:LinkButton>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <%--/Formulario Atualização--%>
    </div>

    <script src="<%=ResolveUrl("~/js/pnotify.buttons.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/pnotify.core.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/Pnotify.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/pnotify.nonblock.js")%>"></script>

    <script type="text/javascript">
        function sucess() {
            new PNotify({
                title: 'Parabéns',
                text: 'Consegui atualizar sem nenhum problema.',
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
    <script type="text/javascript">
        function warning() {
            new PNotify({
                title: 'Atenção',
                text: 'Acho que você esqueceu de preencher o campo nome.',
                type: 'warning'
            });
        }
    </script>

</asp:Content>

