<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AlterarSetor.aspx.cs" Inherits="paginas_AlterarSetor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder1" Runat="Server">
    <div class="telas">

        <%--Formulario Cadastro--%>
        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Atualização de Setor</h2>
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
                                    <h5>Codígo do Setor:</h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="item form-group">
                                        <div class="col-md-5 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txbCodigo" runat="server" Enabled="false" CssClass="form-control" data-validate-length-range="1" data-validate-words="1"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <h5>Nome<span>*</span>:</h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="item form-group">
                                        <div class="col-md-5 col-sm-6 col-xs-12">
                                            <asp:TextBox ID="txbNome" runat="server" CssClass="form-control" data-validate-length-range="1" data-validate-words="1" placeholder="Entre com o nome do setor" required="required"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <h5>Descrição: </h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="col-md-5 col-sm-6 col-xs-12">
                                        <asp:TextBox ID="txbDesc" runat="server" CssClass="form-control" placeholder="Descrição do Setor"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style6">
                                    <h5>Nome do Departamento <span>*</span>:</h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="col-md-5 col-sm-6 col-xs-12">
                                        <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-control" data-validate-length-range="3" data-validate-words="2" placeholder="Entre com o nome do setor" required="required"></asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <div class="item form-group">
                            <div class="col-md-5 col-md-offset-8">
                                <asp:LinkButton ID="btnVoltar" runat="server" CssClass="btn btn-success" data-toggle="tooltip" data-placement="top" title="Voltar" OnClick="btnVoltar_Click"><i class="fa fa-reply"></i> Voltar</asp:LinkButton>
                                <asp:LinkButton ID="btnAtualizar" runat="server" CssClass="btn btn-primary" data-toggle="tooltip" data-placement="top" title="Atualizar" OnClick="btnAtualizar_Click"><i class="fa fa-save"></i> Atualizar</asp:LinkButton>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <%--/Formulario Cadastro--%>
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
                text: 'Acho que você esqueceu de preencher o campo nome ou departamento.',
                type: 'warning'
            });
        }
    </script>
</asp:Content>

