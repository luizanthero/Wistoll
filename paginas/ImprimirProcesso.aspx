<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ImprimirProcesso.aspx.cs" Inherits="paginas_ImprimirProcesso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder1" runat="Server">

    <div class="telas">
        <%-- <div class="title_right">

                            

                        </div>--%>
        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Imprimir Processos      <i class='fa fa-print'></i></h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">





                        <asp:GridView ID="grdProcessos" runat="server" CssClass="table table-striped responsive-utilities jambo_table tabela" AutoGenerateColumns="False">

                            <Columns>

                                <asp:BoundField DataField="numeroProcesso" HeaderText="Protocolo" />
                                <asp:BoundField DataField="dataPedido" HeaderText="Finalização" />
                                <asp:TemplateField HeaderText="Abrir">

                                    <ItemTemplate>

                                        <asp:LinkButton ID="lnkAcao" runat="server" CommandName="Imprimir" CommandArgument='<%# Bind("numeroProcesso") %>'><i class="fa fa-print"></i> Imprimir</asp:LinkButton>

                                    </ItemTemplate>

                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                                                <asp:Label ID="lbl" runat="server"></asp:Label>





                    </div>
                </div>
            </div>
        </div>
    </div>




</asp:Content>

