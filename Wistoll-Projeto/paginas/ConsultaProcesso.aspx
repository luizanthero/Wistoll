<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultaProcesso.aspx.cs" Inherits="paginas_ConsultaProcesso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="telas">

        <%--Lista de Processos--%>
        <div class="row">

            <div class="col-md-12">

                <div class="x_panel">

                    <div class="x_title">

                        <h2>Lista de Processos</h2>

                        <ul class="nav navbar-right panel_toolbox">

                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>
                                                        
                        </ul>

                        <div class="clearfix"></div>

                    </div>

                    <div class="x_content">                        

                        <div class="clearfix"></div>

                        <div class="row">

                            <div class="col-md-12 col-sm-12 col-xs-12">
                                
                                    <div class="x_content">

                                        <div class="form-group">
                                            <div class="col-md-12 estiloConsulta" data-step="1" data-intro="Com as opções na lateral da tabela, é possivel realizar Busca, Filtro, e alterar a quantidades de processos exibidos em uma página">
                                                <asp:GridView ID="grdProcessos" runat="server" CssClass="table table-striped responsive-utilities jambo_table tabela" AutoGenerateColumns="False" OnRowCommand="grdProcessos_RowCommand" data-step="2" data-intro="Para obter mais informações sobre o processo, Clique em ABRIR">
                                                    <Columns>
                                                        <asp:BoundField DataField="redator" HeaderText="Redator"/>
                                                        <asp:BoundField DataField="matriculaRedator" HeaderText="Matrícula" />
                                                        <asp:BoundField DataField="numeroProcesso" HeaderText="Processo" />
                                                        <asp:BoundField DataField="requerente" HeaderText="Requerente" />                                                        
                                                        <asp:BoundField DataField="dataPedido" HeaderText="Pedido" />
                                                        <asp:BoundField DataField="modelo" HeaderText="Modelo" />
                                                        <asp:BoundField DataField="dataFinalizar" HeaderText="Finalização" />
                                                        <asp:BoundField DataField="portador" HeaderText="Portador" />
                                                        <asp:BoundField DataField="matriculaPortador" HeaderText="Matrícula" />
                                                        <asp:BoundField DataField="localAtual" HeaderText="Local Atual" />
                                                        <asp:BoundField DataField="situacao" HeaderText="Situação" />
                                                        <asp:TemplateField HeaderText="Abrir">

                                                            <ItemTemplate>

                                                                <asp:LinkButton ID="lnkAcao" runat="server" CommandName="Abrir" CommandArgument='<%# Bind("numeroProcesso") %>' ><i class="fa fa-folder"></i> Abrir</asp:LinkButton>

                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                    </Columns>

                                                    <HeaderStyle Font-Size="Smaller" />

                                                </asp:GridView>
                                            </div>
                                        </div>

                                        <asp:Label ID="lbl" runat="server"></asp:Label>

                                       <%-- <div class="form-group">
                                            <div class="col-md-5 col-md-offset-7">
                                                <asp:LinkButton ID="btnVoltarPrimeiro" runat="server" CssClass="btn btn-primary" data-toggle="tooltip" data-placement="top" title="Primeira Página"><i class="fa fa-angle-double-left"></i> Primeiro </asp:LinkButton>
                                                <asp:LinkButton ID="btnAnterior" runat="server" CssClass="btn btn-success" data-toggle="tooltip" data-placement="top" title="Anterior"><i class="fa fa-angle-double-left"></i> Anterior </asp:LinkButton>
                                                <asp:LinkButton ID="btnProximo" runat="server" CssClass="btn btn-success" data-toggle="tooltip" data-placement="top" title="Próximo">Próximo <i class="fa fa-angle-double-right"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnUltimo" runat="server" CssClass="btn btn-success" data-toggle="tooltip" data-placement="top" title="Último"><i class="fa fa-angle-double-left"></i> Último </asp:LinkButton>

                                            </div>
                                        </div>--%>


                                    </div>
                                
                            </div>

                            <br />
                            <br />
                            <br />

                        </div>

                    </div>

                </div>

            </div>

        </div>
        <%--Lista de Processos--%>
    </div>
</asp:Content>

