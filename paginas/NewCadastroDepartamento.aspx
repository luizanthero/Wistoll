<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewCadastroDepartamento.aspx.cs" Inherits="paginas_CadastroDepartamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="telas">

        <%--Formulario Cadastro--%>
        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Cadastro de Departamento</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a href="javascript:void(0);" onclick="javascript:introJs().start();"><i class="fa fa-question"></i></a></li>
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content"  data-step="1" data-intro='Formulário de Cadastro do Departamento'>
                        <br />

                        <table class="col-md-11 col-md-12">
                            <tr data-step="2" data-intro='Nome do Departamento Ex: Fiscalização, TI, Logística...'>
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
                            <tr data-step="3" data-intro='Descrição do Departamento'>
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
                            <div class="col-md-5 col-md-offset-7" data-step="4" data-intro='Botões para apagar (limpar) e salvar os dados do formulário respectivamente'>
                                <asp:LinkButton ID="btnApagar" runat="server" CssClass="btn btn-default" data-toggle="tooltip" data-placement="top" title="Apagar" OnClick="btnApagar_Click"><i class="fa fa-trash"></i> Apagar</asp:LinkButton>
                                <asp:LinkButton ID="btnSalvar" runat="server" CssClass="btn btn-primary" data-toggle="tooltip" data-placement="top" title="Salvar" OnClick="btnSalvar_Click"><i class="fa fa-save"></i> Salvar</asp:LinkButton>
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

