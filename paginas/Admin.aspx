<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="paginas_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder1" runat="Server">
    <div class="telas">

        <div class="row">
            <div class="col-md-12">
                <div class="well">
                    <h3>Gerenciamento de Atividades</h3>
                </div>
                <div class="x_content">

                    <div class="row">
                        <div class="col-md-12">
                            <div class="divider">
                                <h2>Processos</h2>
                            </div>
                            <div class="x_content">
                                <div class="row" data-step="1" data-intro='Todos Processo e seus Status: Deferido►Processo Aprovado Indeferido►Processo em avaliação Pendente►Processo em haver Finalizado►Processo finalizado'>
                                    <asp:Label ID="lblProcessos" runat="server"></asp:Label>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="divider">
                                <h2>Usuários e Requerentes</h2>
                            </div>
                            <div class="x_content" >
                                <div class="row" data-step="2" data-intro='Todos os Usuários ativos do Sistema e respectivamente sua quantidade'>
                                    <asp:Label ID="lblUsuarios" runat="server"></asp:Label>
                                    <asp:Label ID="lblRequerentes" runat="server"></asp:Label>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="divider">
                                <h2>Departamentos e Setores</h2>
                            </div>
                            <div class="x_content">
                                <div class="row" data-step="3" data-intro='Todos os Setores e Departamento Ativos'>
                                    <asp:Label ID="lblDepartamento" runat="server"></asp:Label>
                                    <asp:Label ID="lblSetor" runat="server"></asp:Label>
                                </div>
                            </div>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="divider">
                                <h2>Inativos</h2>
                            </div>
                            <div class="x_content">
                                <div class="row" data-step="4" data-intro='Todos Usuários, Setores e Departamento inativos do Sistema. Para reativar algum inativo clicar no campo desejado, "Visualizar", e "Ativar"'>
                                    <asp:Label ID="lblUsuariosInativos" runat="server"></asp:Label>
                                    <asp:Label ID="lblRequerentesInativos" runat="server"></asp:Label>
                                    <asp:Label ID="lblDepartamentoInativo" runat="server"></asp:Label>
                                    <asp:Label ID="lblSetorInativo" runat="server"></asp:Label>
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
        function dark(nome) {
            new PNotify({
                title: 'Bem Vindo, ' + nome + '!',
                text: 'Separei algumas coisas importantes para você!',
                type: 'dark'
            });
        }
    </script>
</asp:Content>

