<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AlterarRequerente.aspx.cs" Inherits="paginas_AlterarRequerente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder1" runat="Server">
    <div class="telas">

        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <%--<div class="x_title">
                        <h2>Alterar Requerente</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li>
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>--%>
                    <div class="x_content">
                        <div class="clearfix"></div>

                        <asp:MultiView ID="mlv" runat="server">
                            <asp:View ID="View1" runat="server">

                                <div>
                                    <h2>Alterar Pessoa</h2>
                                    <div class="ln_solid alert-info"></div>
                                    <table data-step="2" data-intro='Formulário de cadastro dos dados pessoais do Requerente'>

                                        <tr>

                                            <td class="auto-style6">Nome<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbNomeFis" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                            <td class="auto-style6" data-step="3" data-intro='Todos'>Sobrenome<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbSobrenomeFis" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                            <td class="auto-style6">Data de Nascimento<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbDataNascFis" runat="server" CssClass="form-control" data-inputmask="'mask': '99/99/9999'"></asp:TextBox>
                                                </div>
                                            </td>

                                        </tr>
                                        <tr>

                                            <td class="auto-style6">Sexo<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:RadioButtonList ID="rblSexoFis" runat="server" CssClass="iCheckAsp radio" TextAlign="Left" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="M" Selected="True">M: </asp:ListItem>
                                                        <asp:ListItem Value="F">F: </asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </td>

                                            <td class="auto-style6">CPF<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbCpfFis" runat="server" CssClass="form-control" data-inputmask="'mask': '999.999.999-99'"></asp:TextBox>
                                                </div>
                                            </td>

                                            <td class="auto-style6">RG<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbRgFis" runat="server" CssClass="form-control" data-inputmask="'mask': '99.999.999-*'"></asp:TextBox>
                                                </div>
                                            </td>

                                        </tr>

                                    </table>

                                    <div class="modal fade" id="addContato" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog" role="document">
                                            <div class="modal-content" style="min-width: 850px;">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                    <h3 class="modal-title" id="myModalLabel">Adicionar Contato!</h3>
                                                </div>
                                                <div class="modal-body" style="min-height: 200px;">
                                                    <table>
                                                        <tr>
                                                            <td class="auto-style6">Contato<span>*</span>:</td>
                                                            <td class="auto-style5">
                                                                <div class="col-md-11">
                                                                    <asp:DropDownList ID="ddlTipoContato" runat="server" CssClass="form-control selectpicker" ClientIDMode="Static" onchange="contato(this)">
                                                                        <asp:ListItem Value="0">Selecione...</asp:ListItem>
                                                                        <asp:ListItem Value="1">Email</asp:ListItem>
                                                                        <asp:ListItem Value="2">Telefone</asp:ListItem>
                                                                        <asp:ListItem Value="3">Celular</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                            <td class="auto-style5">
                                                                <div id="divEmail" style="display: none;" class="col-md-11">
                                                                    <asp:TextBox ID="txbEmail" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                                </div>
                                                                <div id="divTelefone" style="display: none;" class="col-md-11">
                                                                    <asp:TextBox ID="txbTelefone" runat="server" CssClass="form-control" ClientIDMode="Static" data-inputmask="'mask': '(99) 9999-99999'"></asp:TextBox>
                                                                </div>
                                                                <div id="divCelular" style="display: none;" class="col-md-11">
                                                                    <asp:TextBox ID="txbCelular" runat="server" CssClass="form-control" ClientIDMode="Static" data-inputmask="'mask': '(99) 99999-99999'"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <%--<img src="../images/transparente.png" class="profile_info" style="margin-left: 120px; margin-top: 30px;" />--%>
                                                </div>
                                                <div class="divider"></div>
                                                <div class="col-xs-12 bottom text-right">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Não</button>
                                                    <asp:LinkButton ID="lnkAddContato" runat="server" CssClass="btn btn-dark" OnClick="lnkAddContato_Click"><i class="fa fa-plus"> Add</i></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <asp:GridView ID="grdContato" runat="server" CssClass="table table-striped responsive-utilities jambo_table" DataKeyNames="con_cod" AutoGenerateColumns="False" OnRowCommand="grdContato_RowCommand" OnRowDataBound="grdContato_RowDataBound" OnRowEditing="grdContato_RowEditing" OnRowDeleting="grdContato_RowDeleting" OnRowUpdating="grdContato_RowUpdating" OnRowCancelingEdit="grdContato_RowCancelingEdit">
                                        <Columns>
                                            <%--<asp:BoundField DataField="con_tipo" HeaderText="Tipo Contato" ApplyFormatInEditMode="false" />--%>
                                            <asp:TemplateField HeaderText="Tipo Contato">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblTipoContato" runat="server" Text='<%#Eval("con_tipo") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTipoContato1" runat="server" Text='<%#Eval("con_tipo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="con_valor" HeaderText="Contato" />--%>
                                            <asp:TemplateField HeaderText="Contato">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txbContato" runat="server" Text='<%#Eval("con_valor") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContato" runat="server" Text='<%#Eval("con_valor") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Editar">
                                                <ItemTemplate>
                                                    <div class="text-center">
                                                        <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Edit"><i class="fa fa-2x fa-edit blue"></i></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <div class="text-center">
                                                        <asp:LinkButton ID="lnkSalvar" runat="server" CommandName="Update"><i class="fa fa-2x fa-check blue"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkCancelar" runat="server" CommandName="Cancel"><i class="fa fa-2x fa-close red"></i></asp:LinkButton>
                                                    </div>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Excluir">
                                                <ItemTemplate>
                                                    <div class="text-center">
                                                        <asp:LinkButton ID="lnkExcluir" runat="server" CommandName="Delete"><i class="fa fa-2x fa-minus-circle red"></i></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                    <div class="btn btn-dark col-md-5 col-md-offset-3" data-toggle="modal" data-target="#addContato"><i class="fa fa-plus">Add</i></div>

                                    <div class="clearfix"></div>

                                    <h2>Alterar Endereço</h2>
                                    <div class="ln_solid alert-info"></div>
                                    <table data-step="3" data-intro='Formulário de cadastro dos dados complementares do Requerente'>
                                        <tr>

                                            <td class="auto-style6">CEP<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbCepFis" runat="server" CssClass="form-control" data-inputmask="'mask': '99999-999'">></asp:TextBox>
                                                </div>
                                            </td>

                                            <td class="auto-style6">Estado<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:DropDownList ID="ddlEstadoFis" runat="server" CssClass="form-control">
                                                        <asp:ListItem>Selecionar...</asp:ListItem>
                                                        <asp:ListItem Value="AC">Acre</asp:ListItem>
                                                        <asp:ListItem Value="AL">Alagoas</asp:ListItem>
                                                        <asp:ListItem Value="AP">Amapá</asp:ListItem>
                                                        <asp:ListItem Value="AM">Amazonas</asp:ListItem>
                                                        <asp:ListItem Value="BA">Bahia</asp:ListItem>
                                                        <asp:ListItem Value="CE">Ceará</asp:ListItem>
                                                        <asp:ListItem Value="DF">Distrito Federal</asp:ListItem>
                                                        <asp:ListItem Value="ES">Espírito Santo</asp:ListItem>
                                                        <asp:ListItem Value="GO">Goiás</asp:ListItem>
                                                        <asp:ListItem Value="MA">Maranhão</asp:ListItem>
                                                        <asp:ListItem Value="MT">Mato Grosso</asp:ListItem>
                                                        <asp:ListItem Value="MS">Mato Grosso do Sul</asp:ListItem>
                                                        <asp:ListItem Value="MG">Minas Gerais</asp:ListItem>
                                                        <asp:ListItem Value="PA">Pará</asp:ListItem>
                                                        <asp:ListItem Value="PB">Paraíba</asp:ListItem>
                                                        <asp:ListItem Value="PR">Paraná</asp:ListItem>
                                                        <asp:ListItem Value="PE">Pernambuco</asp:ListItem>
                                                        <asp:ListItem Value="PI">Piauí</asp:ListItem>
                                                        <asp:ListItem Value="RJ">Rio de Janeiro</asp:ListItem>
                                                        <asp:ListItem Value="RN">Rio Grande do Norte</asp:ListItem>
                                                        <asp:ListItem Value="RS">Rio Grande do Sul</asp:ListItem>
                                                        <asp:ListItem Value="RO">Rondônia</asp:ListItem>
                                                        <asp:ListItem Value="RR">Roraima</asp:ListItem>
                                                        <asp:ListItem Value="SC">Santa Catarina</asp:ListItem>
                                                        <asp:ListItem Value="SP">São Paulo</asp:ListItem>
                                                        <asp:ListItem Value="SE">Sergipe</asp:ListItem>
                                                        <asp:ListItem Value="TO">Tocantins</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>

                                            <td class="auto-style6">Cidade<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbCidadeFis" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                        </tr>

                                        <tr>

                                            <td class="auto-style6">Bairro<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbBairroFis" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                            <td class="auto-style6">Rua<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbRuaFis" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                            <td class="auto-style6">Número<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbNumeroFis" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                        </tr>

                                        <tr>

                                            <td class="auto-style6">Complemento:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbComplementoFis" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <br />
                                    <div class="form-group">
                                        <div class="col-md-5 col-md-offset-8" data-step="4" data-intro="Botões para apagar os campos do formulário e salvá-los respectivamente">
                                            <button id="btnApagarFis" runat="server" class="btn btn-default" title="Apagar"><i class="fa fa-trash"></i>Apagar</button>
                                            <button id="btnSalvarFis" runat="server" class="btn btn-primary" title="Salvar"><i class="fa fa-save"></i>Salvar</button>
                                        </div>
                                    </div>
                                </div>

                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <div>
                                    <h2>Alterar Empresa</h2>
                                    <div class="ln_solid alert-info"></div>
                                    <table class="col-md-11" data-step="2" data-intro='Formulário de cadastro da Empresa do Requerente'>

                                        <tr>

                                            <td class="auto-style6">Nome<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div>
                                                    <asp:TextBox ID="txbNomeJur" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                            <td class="auto-style6">Data de Criação<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbDataNascJur" runat="server" CssClass="form-control" data-inputmask="'mask': '99/99/9999'"></asp:TextBox>
                                                </div>
                                            </td>

                                            <td class="auto-style6">Sigla:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbSiglaJur" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                        </tr>
                                        <tr>

                                            <td class="auto-style6">Razão Social<span>*</span>:</td>
                                            <td class="auto-style5" colspan="3">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbRazaoSocialJur" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                            <td class="auto-style6">CNPJ<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbCnpjJur" runat="server" CssClass="form-control" data-inputmask="'mask': '99.999.999/9999-99'"></asp:TextBox>
                                                </div>
                                            </td>

                                        </tr>

                                    </table>

                                    <asp:GridView ID="grdContato1" runat="server" CssClass="table table-striped responsive-utilities jambo_table" DataKeyNames="con_cod" AutoGenerateColumns="False" OnRowCommand="grdContato1_RowCommand" OnRowDataBound="grdContato1_RowDataBound" OnRowEditing="grdContato1_RowEditing" OnRowDeleting="grdContato1_RowDeleting" OnRowUpdating="grdContato1_RowUpdating" OnRowCancelingEdit="grdContato1_RowCancelingEdit">
                                        <Columns>
                                            <%--<asp:BoundField DataField="con_tipo" HeaderText="Tipo Contato" ApplyFormatInEditMode="false" />--%>
                                            <asp:TemplateField HeaderText="Tipo Contato">
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblTipoContato" runat="server" Text='<%#Eval("con_tipo") %>'></asp:Label>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTipoContato1" runat="server" Text='<%#Eval("con_tipo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="con_valor" HeaderText="Contato" />--%>
                                            <asp:TemplateField HeaderText="Contato">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txbContato" runat="server" Text='<%#Eval("con_valor") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContato" runat="server" Text='<%#Eval("con_valor") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Editar">
                                                <ItemTemplate>
                                                    <div class="text-center">
                                                        <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Edit"><i class="fa fa-2x fa-edit blue"></i></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <div class="text-center">
                                                        <asp:LinkButton ID="lnkSalvar" runat="server" CommandName="Update"><i class="fa fa-2x fa-check blue"></i></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkCancelar" runat="server" CommandName="Cancel"><i class="fa fa-2x fa-close red"></i></asp:LinkButton>
                                                    </div>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Excluir">
                                                <ItemTemplate>
                                                    <div class="text-center">
                                                        <asp:LinkButton ID="lnkExcluir" runat="server" CommandName="Delete"><i class="fa fa-2x fa-minus-circle red"></i></asp:LinkButton>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>

                                    <div class="btn btn-dark col-md-5 col-md-offset-3" data-toggle="modal" data-target="#addContato"><i class="fa fa-plus">Add</i></div>

                                    <div class="clearfix"></div>

                                    <h4>Alterar Endereço</h4>
                                    <div class="ln_solid alert-info"></div>
                                    <table data-step="3" data-intro='Formulário de cadastro complementares da Empresa do Requerente'>
                                        <tr>

                                            <td class="auto-style6">CEP<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbCepJur" runat="server" CssClass="form-control" data-inputmask="'mask': '99999-999'">></asp:TextBox>
                                                </div>
                                            </td>

                                            <td class="auto-style6">Estado<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:DropDownList ID="ddlEstadoJur" runat="server" CssClass="form-control">
                                                        <asp:ListItem>Selecionar...</asp:ListItem>
                                                        <asp:ListItem Value="AC">Acre</asp:ListItem>
                                                        <asp:ListItem Value="AL">Alagoas</asp:ListItem>
                                                        <asp:ListItem Value="AP">Amapá</asp:ListItem>
                                                        <asp:ListItem Value="AM">Amazonas</asp:ListItem>
                                                        <asp:ListItem Value="BA">Bahia</asp:ListItem>
                                                        <asp:ListItem Value="CE">Ceará</asp:ListItem>
                                                        <asp:ListItem Value="DF">Distrito Federal</asp:ListItem>
                                                        <asp:ListItem Value="ES">Espírito Santo</asp:ListItem>
                                                        <asp:ListItem Value="GO">Goiás</asp:ListItem>
                                                        <asp:ListItem Value="MA">Maranhão</asp:ListItem>
                                                        <asp:ListItem Value="MT">Mato Grosso</asp:ListItem>
                                                        <asp:ListItem Value="MS">Mato Grosso do Sul</asp:ListItem>
                                                        <asp:ListItem Value="MG">Minas Gerais</asp:ListItem>
                                                        <asp:ListItem Value="PA">Pará</asp:ListItem>
                                                        <asp:ListItem Value="PB">Paraíba</asp:ListItem>
                                                        <asp:ListItem Value="PR">Paraná</asp:ListItem>
                                                        <asp:ListItem Value="PE">Pernambuco</asp:ListItem>
                                                        <asp:ListItem Value="PI">Piauí</asp:ListItem>
                                                        <asp:ListItem Value="RJ">Rio de Janeiro</asp:ListItem>
                                                        <asp:ListItem Value="RN">Rio Grande do Norte</asp:ListItem>
                                                        <asp:ListItem Value="RS">Rio Grande do Sul</asp:ListItem>
                                                        <asp:ListItem Value="RO">Rondônia</asp:ListItem>
                                                        <asp:ListItem Value="RR">Roraima</asp:ListItem>
                                                        <asp:ListItem Value="SC">Santa Catarina</asp:ListItem>
                                                        <asp:ListItem Value="SP">São Paulo</asp:ListItem>
                                                        <asp:ListItem Value="SE">Sergipe</asp:ListItem>
                                                        <asp:ListItem Value="TO">Tocantins</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>

                                            <td class="auto-style6">Cidade<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbCidadeJur" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                        </tr>

                                        <tr>

                                            <td class="auto-style6">Bairro<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbBairroJur" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                            <td class="auto-style6">Rua<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbRuaJur" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                            <td class="auto-style6">Número<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbNumeroJur" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                        </tr>

                                        <tr>

                                            <td class="auto-style6">Complemento:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:TextBox ID="txbComplementoJur" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </td>

                                        </tr>
                                    </table>
                                    <br />
                                    <br />
                                    <br />
                                    <div class="form-group">
                                        <div class="col-md-5 col-md-offset-8" data-step="4" data-intro="Botões para apagar os campos do formulário e salvá-los respectivamente">
                                            <button id="btnApagarJur" runat="server" class="btn btn-default" title="Apagar"><i class="fa fa-trash"></i>Apagar</button>
                                            <button id="btnSalvarJur" runat="server" class="btn btn-primary" title="Salvar"><i class="fa fa-save"></i>Salvar</button>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>
                        </asp:MultiView>

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
        function erroContato() {
            new PNotify({
                title: 'Me Desculpe',
                text: 'Contato não foi inserido. Tente Novamente!',
                type: 'error'
            });
        }
    </script>
    <script type="text/javascript">
        function warning() {
            new PNotify({
                title: 'Atenção',
                text: 'Você esqueceu de preencher alguns campos!',
                type: 'warning'
            });
        }
    </script>
    <script type="text/javascript">
        function warning1() {
            new PNotify({
                title: 'Atenção',
                text: 'Obrigatório adicionar pelo menos um Email de contato!',
                type: 'warning'
            });
        }
    </script>

    <script>
        function contato(ddl) {
            switch (ddl.selectedIndex) {
                case 0:
                    $("#divEmail").css("display", "none");
                    $("#divTelefone").css("display", "none");
                    $("#divCelular").css("display", "none");
                    $("#btnContato").css("display", "none");
                    break;
                case 1:
                    $("#divEmail").css("display", "block");
                    $("#divTelefone").css("display", "none");
                    $("#divCelular").css("display", "none");
                    $("#btnContato").css("display", "block");
                    $("#txbEmail").attr("placeholder", "Ex: exemplo@exemplo.com");
                    break;
                case 2:
                    $("#divTelefone").css("display", "block");
                    $("#divEmail").css("display", "none");
                    $("#divCelular").css("display", "none");
                    $("#btnContato").css("display", "block");
                    $("#txbTelefone").attr("placeholder", "Ex: (99) 9999-9999");
                    break;
                case 3:
                    $("#divCelular").css("display", "block");
                    $("#divEmail").css("display", "none");
                    $("#divTelefone").css("display", "none");
                    $("#btnContato").css("display", "block");
                    $("#txbCelular").attr("placeholder", "Ex: (99) 99999-9999");
                    break;
            }

        }
    </script>

</asp:Content>

