<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Invoice.aspx.cs" Inherits="paginas_Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder1" runat="Server">

    <div class="telas">

        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Resumo: <small>Atividades dos usuários </small></h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">

                        <section class="content invoice">
                            <!-- title row -->
                            <div class="row">
                                <div class="col-xs-12 invoice-header">
                                    <h1>
                                        <i class="fa fa-globe"></i> Relatórios de Auditoria.
                                        <%--<small class="pull-right"><i class="fa fa-calendar"></i>Período: 16/08/2016 à 20/09/2016</small>--%>
                                    </h1>
                                </div>
                                <!-- /.col -->
                            </div>

                            <asp:Label ID="lblCabecalho" runat="server" Text="Label"></asp:Label>

                            <br />
                            <!-- Table row -->
                            <div class="row">
                                <div class="col-xs-12 table estiloConsulta">
                                    <asp:GridView ID="grdAuditoria" runat="server" CssClass="table table-striped responsive-utilities jambo_table tabela" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="funcionario" HeaderText="Funcionario" />
                                            <asp:BoundField DataField="sobrenome" HeaderText="Sobrenome" />
                                            <asp:BoundField DataField="matricula" HeaderText="Matrícula" />
                                            <asp:BoundField DataField="dataAcao" HeaderText="Data da Ação" />
                                            <asp:BoundField DataField="tabela" HeaderText="Tabela Alterada" />
                                            <asp:BoundField DataField="campo" HeaderText="Registro Alterado" />
                                            <asp:BoundField DataField="acao" HeaderText="Ação Realizada" />
                                        </Columns>
                                    </asp:GridView>
                                    <%--<table class="table table-striped">
                                                    <thead>
                                                        <tr>
                                                            <th>Funcionário</th>
                                                            <th>Matricula</th>
                                                            <th>Data da Ação</th>
                                                            <th style="width: 59%">Ações Realizadas</th>
                                                            
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>Lucas Macedo</td>
                                                            <td>1211.1</td>
                                                            <td>25/08/2016</td>
                                                            <td>El snort testosterone trophy driving gloves handsome gerry Richardson helvetica tousled street art master testosterone trophy driving gloves handsome gerry Richardson
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td>Luiz Anthero</td>
                                                            <td>2207.0</td>
                                                            <td>02/09/2016</td>
                                                            <td>Wes Anderson umami biodiesel</td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td>Claudemr Silva</td>
                                                            <td>1606.2</td>
                                                            <td>10/09/2016</td>
                                                            <td>Terry Richardson helvetica tousled street art master, El snort testosterone trophy driving gloves handsome letterpress erry Richardson helvetica tousled</td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td>Camila Martineli</td>
                                                            <td>2404.3</td>
                                                            <td>19/09/2016</td>
                                                            <td>Tousled lomo letterpress erry Richardson helvetica tousled street art master helvetica tousled street art master, El snort testosterone</td>
                                                            
                                                        </tr>
                                                    </tbody>
                                                </table>--%>
                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.row -->

                            <div class="ln_solid"></div>

                            <!-- this row will not appear when printing -->
                            <div class="row no-print">
                                <div class="col-xs-12">
                                    <button class="btn btn-default" onclick="window.print();"><i class="fa fa-print"></i>Print</button>
                                    <button class="btn btn-primary pull-right" style="margin-right: 5px;"><i class="fa fa-download"></i>Generate PDF</button>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

