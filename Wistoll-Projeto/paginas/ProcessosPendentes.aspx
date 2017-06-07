<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProcessosPendentes.aspx.cs" Inherits="paginas_ProcessosPendentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container body">           
            

            <!-- page content -->
            <div class="" role="main">

                
                    <div class="clearfix"></div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="x_panel">
                                <div class="x_title">

                                    <h2>PENDENTES</h2>

                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><a href='<%=ResolveUrl("~/paginas/Index.aspx")%>' class="" data-toggle="tooltip" data-placement="bottom" title="Retornar Pagina Anterior"><i class="fa fa-reply"></i></a></li>
                                        <li><a class="collapse-link" data-toggle="tooltip" data-placement="bottom" title="Movimentar Painel"><i class="fa fa-chevron-up"></i></a></li>
										<li><a class="close-link" data-toggle="tooltip" data-placement="bottom" title="Fechar Painel"><i class="fa fa-close"></i></a></li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content estiloConsulta">

                                    <p>Informe dos Feed da página inicial</p>

                                    <asp:GridView ID="gridPendente" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered dt-responsive nowrap jambo_table tabela" OnRowCommand="gridPendente_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="redator" HeaderText="Redator" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
                                            <asp:BoundField DataField="numeroProcesso" HeaderText="Número do Processo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
                                            <asp:BoundField DataField="localAtual" HeaderText="Local Atual" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
                                            <asp:BoundField DataField="portador" HeaderText="Portador" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
                                            <asp:BoundField DataField="requerente" HeaderText="Requerente" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
                                            <asp:BoundField DataField="dataPedido" HeaderText="Pedido" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
                                            <asp:BoundField DataField="situacao" HeaderText="Status" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>

                                            <asp:TemplateField HeaderText="Abrir">

                                                <ItemTemplate>

                                                    <asp:LinkButton ID="lnkAcao" runat="server" CommandName="Abrir" CommandArgument='<%# Bind("numeroProcesso") %>' ><i class="fa fa-2x fa-folder-open"></i></asp:LinkButton>

                                                </ItemTemplate>

                                            </asp:TemplateField>

                                        </Columns>

                                        <HeaderStyle  Font-Size="16px" />
                                        <RowStyle Font-Size="14px" />

                                    </asp:GridView>

                                    <!-- start project list -->
                                    <%--<table class="table table-striped projects">
                                        <thead>
                                            <tr>
                                                <th style="width: 1%">#</th>
                                                <th style="width: 20%">Número do Processo</th>
                                                <th> Redator </th>
                                                <th>Status</th>
                                                <th style="width: 20%">Ação</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>#</td>
                                                <td>
                                                    <a href="#">Nº: 999.999.999-9</a>
                                                    <br />
                                                    <small>Criado: 01.01.2015</small>
                                                </td>
                                                <td>
                                                    <ul class="list-inline">
                                                        <li>
                                                            Lucas Santos
                                                        </li>
                                                        
                                                    </ul>
                                                </td>
      
                                                <td>
                                                    <button type="button" class="btn btn-warning btn-xs"><i class="fa fa-exclamation-circle"></i> Pendente </button>
                                                </td>
                                                <td>
                                                    <a href="#" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i> Visualizar </a>
                                                    <a href="#" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Editar </a>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td>#</td>
                                                <td>
                                                    <a href="#">Nº: 999.999.999-9</a>
                                                    <br />
                                                    <small>Criado: 01.01.2015</small>
                                                </td>
                                                <td>
                                                    <ul class="list-inline">
                                                        <li>
                                                            Lucas Santos
                                                        </li>
                                                        
                                                    </ul>
                                                </td>
      
                                                <td>
                                                    <button type="button" class="btn btn-warning btn-xs"><i class="fa fa-exclamation-circle"></i> Pendente </button>
                                                </td>
                                                <td>
                                                    <a href="#" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i> Visualizar </a>
                                                    <a href="#" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Editar </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>#</td>
                                                <td>
                                                    <a href="#">Nº: 999.999.999-9</a>
                                                    <br />
                                                    <small>Criado: 01.01.2015</small>
                                                </td>
                                                <td>
                                                    <ul class="list-inline">
                                                        <li>
                                                            Lucas Santos
                                                        </li>
                                                        
                                                    </ul>
                                                </td>
      
                                                <td>
                                                    <button type="button" class="btn btn-warning btn-xs"><i class="fa fa-exclamation-circle"></i> Pendente </button>
                                                </td>
                                                <td>
                                                    <a href="#" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i> Visualizar </a>
                                                    <a href="#" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Editar </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>#</td>
                                                <td>
                                                    <a href="#">Nº: 999.999.999-9</a>
                                                    <br />
                                                    <small>Criado: 01.01.2015</small>
                                                </td>
                                                <td>
                                                    <ul class="list-inline">
                                                        <li>
                                                            Lucas Santos
                                                        </li>
                                                        
                                                    </ul>
                                                </td>
      
                                                <td>
                                                    <button type="button" class="btn btn-warning btn-xs"><i class="fa fa-exclamation-circle"></i> Pendente </button>
                                                </td>
                                                <td>
                                                    <a href="#" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i> Visualizar </a>
                                                    <a href="#" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Editar </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>#</td>
                                                <td>
                                                    <a href="#">Nº: 999.999.999-9</a>
                                                    <br />
                                                    <small>Criado: 01.01.2015</small>
                                                </td>
                                                <td>
                                                    <ul class="list-inline">
                                                        <li>
                                                            Lucas Santos
                                                        </li>
                                                        
                                                    </ul>
                                                </td>
      
                                                <td>
                                                   <button type="button" class="btn btn-warning btn-xs"><i class="fa fa-exclamation-circle"></i> Pendente </button>
                                                </td>
                                                <td>
                                                    <a href="#" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i> Visualizar </a>
                                                    <a href="#" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Editar </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>#</td>
                                                <td>
                                                    <a href="#">Nº: 999.999.999-9</a>
                                                    <br />
                                                    <small>Criado: 01.01.2015</small>
                                                </td>
                                                <td>
                                                    <ul class="list-inline">
                                                        <li>
                                                            Lucas Santos
                                                        </li>
                                                        
                                                    </ul>
                                                </td>
      
                                                <td>
                                                    <button type="button" class="btn btn-warning btn-xs"><i class="fa fa-exclamation-circle"></i> Pendente </button>
                                                </td>
                                                <td>
                                                    <a href="#" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i> Visualizar </a>
                                                    <a href="#" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Editar </a>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td>#</td>
                                                <td>
                                                    <a href="#">Nº: 999.999.999-9</a>
                                                    <br />
                                                    <small>Criado: 01.01.2015</small>
                                                </td>
                                                <td>
                                                    <ul class="list-inline">
                                                        <li>
                                                            Lucas Santos
                                                        </li>
                                                        
                                                    </ul>
                                                </td>
      
                                                <td>
                                                    <button type="button" class="btn btn-warning btn-xs"><i class="fa fa-exclamation-circle"></i> Pendente </button>
                                                </td>
                                                <td>
                                                    <a href="#" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i> Visualizar </a>
                                                    <a href="#" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Editar </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>#</td>
                                                <td>
                                                    <a href="#">Nº: 999.999.999-9</a>
                                                    <br />
                                                    <small>Criado: 01.01.2015</small>
                                                </td>
                                                <td>
                                                    <ul class="list-inline">
                                                        <li>
                                                            Lucas Santos
                                                        </li>
                                                        
                                                    </ul>
                                                </td>
      
                                                <td>
                                                    <button type="button" class="btn btn-warning btn-xs"><i class="fa fa-exclamation-circle"></i> Pendente </button>
                                                </td>
                                                <td>
                                                    <a href="#" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i> Visualizar </a>
                                                    <a href="#" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Editar </a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class = "col-md-1">#</td>
                                                <td>
                                                    <a href="#">Nº: 999.999.999-9</a>
                                                    <br />
                                                    <small>Criado: 01.01.2015</small>
                                                </td>
                                                <td>
                                                    <ul class="list-inline">
                                                        <li>
                                                            Lucas Santos
                                                        </li>
                                                        
                                                    </ul>
                                                </td>
      
                                                <td>
                                                    <button type="button" class="btn btn-warning btn-xs"><i class="fa fa-exclamation-circle"></i> Pendente </button>
                                                </td>
                                                <td>
                                                    <a href="#" class="btn btn-primary btn-xs"><i class="fa fa-folder"></i> Visualizar </a>
                                                    <a href="#" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Editar </a>
                                                </td>
												
                                            </tr>
											
                                        </tbody>
                                    </table>--%>



                                    <!-- end project list -->

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                

            <!-- /page content -->
        </div>

</asp:Content>

