 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewCadastroSetor.aspx.cs" Inherits="paginas_NewCadastroSetor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="telas">

        <%--Formulario Cadastro--%>
        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Cadastro do Setor</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a href="javascript:void(0);" onclick="javascript:introJs().start();"><i class="fa fa-question"></i></a></li>
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                        </ul>
                        <div class="clearfix" ></div>
                    </div>
                    <div class="x_content " data-step="1" data-intro='Formulário de Cadastramento de Setor'>
                        <br />

                        <table class="col-md-offset-3 col-md-10">
                            <tr data-step="2" data-intro='Nome do Setor'>
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
                            <tr data-step="3" data-intro='Descrição do Setor'>
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
                                <td class="auto-style6" data-step="4" data-intro='Selecionar o Departamento no qual estará o setor'>
                                    <h5>Nome do Departamento <span>*</span>:</h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="col-md-5 col-sm-6 col-xs-12">
                                        <asp:DropDownList ID="ddlDepartamento" runat="server" data-live-search="true" CssClass="form-control selectpicker" data-validate-length-range="3" data-validate-words="2" placeholder="Entre com o nome do setor" required="required"></asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                        </table>



                        <div class="form-group">
                            <div class="col-md-5 col-md-offset-7" data-step="5" data-intro='Botões para apagar (limpar) e salvar os dados do formulário respectivamente'>
                                <br /><br />
                                <asp:LinkButton ID="btnApagar" runat="server" CssClass="btn btn-default" data-toggle="tooltip" data-placement="top" title="Apagar" OnClick="btnApagar_Click"><i class="fa fa-trash"></i> Apagar</asp:LinkButton>
                                <asp:LinkButton ID="btnSalvar" runat="server" CssClass="btn btn-primary" data-toggle="tooltip" data-placement="top" title="Salvar" OnClick="btnSalvar_Click"><i class="fa fa-save"></i> Salvar</asp:LinkButton>
                                <asp:Label ID="lbl" runat="server"></asp:Label>
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
                text: 'Acho que os campos nome e departamento não foram preenchidos.',
                type: 'warning'
            });
        }
    </script>

</asp:Content>

