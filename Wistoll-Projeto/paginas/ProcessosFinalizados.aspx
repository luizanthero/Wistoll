<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProcessosFinalizados.aspx.cs" Inherits="paginas_ProcessosFinalizados" %>

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

                                    <h2>FINALIZADOS</h2>

                                    <ul class="nav navbar-right panel_toolbox">
                                        <li><a href='<%=ResolveUrl("~/paginas/Index.aspx")%>' class="" data-toggle="tooltip" data-placement="bottom" title="Retornar Pagina Anterior"><i class="fa fa-reply"></i></a></li>
                                        <li><a class="collapse-link" data-toggle="tooltip" data-placement="bottom" title="Movimentar Painel"><i class="fa fa-chevron-up"></i></a></li>
										<li><a class="close-link" data-toggle="tooltip" data-placement="bottom" title="Fechar Painel"><i class="fa fa-close"></i></a></li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content estiloConsulta">

                                    <p>Informe dos Feed da página inicial</p>

                                    <!-- start project list -->
                                  <asp:GridView ID="gridFinalizado" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered dt-responsive nowrap jambo_table tabela" OnRowCommand="gridFinalizado_RowCommand">
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


                                    <!-- end project list -->

                                     <div class="col-md-12 col-sm-12 col-xs-12" style="text-align:right;">
                                            <ul class="pagination pagination-split">
                                                <li><a href="#">1</a></li>
                                                <li><a href="#">2</a></li>
                                                <li><a href="#">3</a></li>
                                                
                                                <li>...</li>
                                                
                                                <li><a href="#">38</a></li>
                                                <li><a href="#">39</a></li>
                                                <li><a href="#">40</a></li>
                                            </ul>
                                        </div>
                                        <div class="clearfix"></div>

                                   <!-- -->

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                

            <!-- /page content -->
        </div>

</asp:Content>

