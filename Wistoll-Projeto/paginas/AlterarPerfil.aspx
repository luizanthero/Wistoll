<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AlterarPerfil.aspx.cs" Inherits="paginas_AlterarPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder1" runat="Server">

    <div class="telas">

        <div class="container body">

            <%-- DIV main-container --%>
            <div class="main_container">

                <!-- page content -->
                <div role="main">

                    <div class="clearfix"></div>

                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="x_panel">

                                <h3>
                                    <asp:Label ID="lblInfo" runat="server"></asp:Label>
                                </h3>

                                <div class="x_content">

                                    <div class="col-md-4 col-sm-4 col-xs-12 profile_left">

                                        <div class="profile_img">

                                            <div id="crop-avatar">

                                                <%--<div class="avatar-view">
                                                    <img src="../images/perfil/Admin.png" alt="..." />                                                      

                                                </div>--%>

                                                <center><asp:Label ID="lblImagem" runat="server" Text="Label"></asp:Label></center>


                                                <center><h3><asp:Label ID="lbl" runat="server">Nome do Usuário</asp:Label></h3></center>

                                            </div>
                                            <!-- end of image cropping -->

                                        </div>

                                        <center>

                                            <asp:Label ID="lblDados" runat="server"></asp:Label>

                                            <div class="ln_solid"></div>

                                            <h2><b><asp:Label ID="lblPermissoes" runat="server"> Permissões Adicionais</asp:Label></b></h2>

                                            <asp:CheckBoxList ID="cblPadrao" runat="server" CssClass="col-md-12 iCheckAsp radio" TextAlign="Right" Enabled="false" Visible="false"></asp:CheckBoxList>
                                            <asp:CheckBoxList ID="checkAdicionais" runat="server" CssClass="col-md-12 iCheckAsp radio" TextAlign="Right"></asp:CheckBoxList>

                                        </center>
                                    </div>

                                    <%-- DIV col-md-9 --%>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <br />

                                        <%-- DIV da tabs --%>
                                        <div class="" role="tabpanel" data-example-id="togglable-tabs">
                                            <ul id="myTab" class="nav nav-tabs bar_tabs" role="tablist">
                                                <li role="presentation" class="active"><a href="#tab_content1" id="home-tab" role="tab" data-toggle="tab" aria-expanded="true">Alterar Dados</a></li>
                                                <li role="presentation"><a href="#tab_content2" id="home-tab1" role="tab" data-toggle="tab" aria-expanded="false">Alterar Contato</a></li>
                                            </ul>

                                            <div id="myTabContent" class="tab-content">

                                                <div role="tabpanel" class="tab-pane fade active in" id="tab_content1" aria-labelledby="home-tab">
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <table class="col-md-12">

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Nome: <span class="required">*</span></label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:TextBox ID="txtNome1" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </td>

                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Sobrenome: <span class="required">*</span></label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12 ">
                                                                        <asp:TextBox ID="txtSobrenome1" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Sexo: <span class="required">*</span></label>
                                                                    <asp:RadioButtonList ID="rdbSexo" runat="server" CssClass="iCheckAsp radio" TextAlign="Left" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="M">Masculino: </asp:ListItem>
                                                                        <asp:ListItem Value="F">Feminino: </asp:ListItem>
                                                                    </asp:RadioButtonList>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">



                                                                    <asp:Label ID="lblPerfil" runat="server" CssClass="control-label col-md-3"> Perfil de Utilizador: <span class="required">*</span></asp:Label>

                                                                    <asp:Label ID="lblAdmin" runat="server" CssClass="control-label col-md-3" Visible="false"> Administrador </asp:Label>

                                                                    <asp:RadioButtonList ID="rdbUsu" runat="server" CssClass="iCheckAsp radio" TextAlign="Left" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="2">Usuário Gestor: </asp:ListItem>
                                                                        <asp:ListItem Value="3">Usuário Supervisor: </asp:ListItem>
                                                                        <asp:ListItem Value="4">Usuário Padrão: </asp:ListItem>
                                                                    </asp:RadioButtonList>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Matrícula: </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:TextBox ID="txtMatricula1" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Cargo: </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:DropDownList ID="ddlCargo" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:DropDownList>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Setor: </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:DropDownList ID="ddlSetor" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:DropDownList>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Especialidade: <span class="required">*</span></label>
                                                                    <asp:RadioButtonList ID="rdbChefe" runat="server" CssClass="iCheckAsp radio" TextAlign="Left" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="0">Nao é Chefe: </asp:ListItem>
                                                                        <asp:ListItem Value="1">Chefe de Setor: </asp:ListItem>
                                                                        <asp:ListItem Value="2">Chefe de Departamento: </asp:ListItem>
                                                                    </asp:RadioButtonList>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Data de Nasciimento: </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:TextBox ID="txtDataNas1" runat="server" CssClass="form-control col-md-7 col-xs-12" data-inputmask="'mask': '99/99/9999'"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">RG: </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:TextBox ID="txtRG1" runat="server" CssClass="form-control col-md-7 col-xs-12" data-inputmask="'mask': '99.999.999-*'"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">CPF: </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:TextBox ID="txtCPF1" runat="server" CssClass="form-control col-md-7 col-xs-12" data-inputmask="'mask': '999.999.999-99'"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>
                                                    </table>

                                                    <table class="col-md-12">

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Rua: </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:TextBox ID="txtRua1" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Número: </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:TextBox ID="txtNumero1" runat="server" CssClass="form-control col-md-7 col-xs-12" TextMode="Number"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Complemento: </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:TextBox ID="txtComplemento1" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Bairro: </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:TextBox ID="txtBairro1" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">CEP: </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:TextBox ID="txtCEP1" runat="server" CssClass="form-control col-md-7 col-xs-12" data-inputmask="'mask': '99999-999'"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Cidade: </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:TextBox ID="txtCidade1" runat="server" CssClass="form-control col-md-7 col-xs-12"></asp:TextBox>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">

                                                                <div class="item form-group">

                                                                    <label class="control-label col-md-3">Estado: </label>
                                                                    <div class="col-md-6 col-sm-6 col-xs-12">
                                                                        <asp:DropDownList ID="ddlEstados" runat="server" CssClass="form-control">
                                                                            <asp:ListItem Value="0">Selecione...</asp:ListItem>
                                                                            <asp:ListItem Value="AC">Acre</asp:ListItem>
                                                                            <asp:ListItem Value="AL">Alagoas</asp:ListItem>
                                                                            <asp:ListItem Value="AP">Amapá</asp:ListItem>
                                                                            <asp:ListItem Value="AM">Amazonas</asp:ListItem>
                                                                            <asp:ListItem Value="BA">Bahia</asp:ListItem>
                                                                            <asp:ListItem Value="CE">Ceará</asp:ListItem>
                                                                            <asp:ListItem Value="DF">Distrito Federal</asp:ListItem>
                                                                            <asp:ListItem Value="ES">Espirito Santo</asp:ListItem>
                                                                            <asp:ListItem Value="GO">Goiás</asp:ListItem>
                                                                            <asp:ListItem Value="MA">Maranhão</asp:ListItem>
                                                                            <asp:ListItem Value="MT">Mato Grosso</asp:ListItem>
                                                                            <asp:ListItem Value="MS">Mato Grosso do Sul</asp:ListItem>
                                                                            <asp:ListItem Value="MG">Minas Gerais</asp:ListItem>
                                                                            <asp:ListItem Value="PA">Pará</asp:ListItem>
                                                                            <asp:ListItem Value="PB">Paraiba</asp:ListItem>
                                                                            <asp:ListItem Value="PR">Paraná</asp:ListItem>
                                                                            <asp:ListItem Value="PE">Pernambuco</asp:ListItem>
                                                                            <asp:ListItem Value="PI">Piauí</asp:ListItem>
                                                                            <asp:ListItem Value="RJ">Rio de Janeiro</asp:ListItem>
                                                                            <asp:ListItem Value="RN">Rio Grande do Norte</asp:ListItem>
                                                                            <asp:ListItem Value="RS">Rio Grnade do Sul</asp:ListItem>
                                                                            <asp:ListItem Value="RO">Rondônia</asp:ListItem>
                                                                            <asp:ListItem Value="RR">Roraima</asp:ListItem>
                                                                            <asp:ListItem Value="SC">Santa Catarina</asp:ListItem>
                                                                            <asp:ListItem Value="SP">São Paulo</asp:ListItem>
                                                                            <asp:ListItem Value="SE">Sergipe</asp:ListItem>
                                                                            <asp:ListItem Value="TO">Tocantis</asp:ListItem>

                                                                        </asp:DropDownList><span class="fa fa-flag form-control-feedback right" aria-hidden="true"></span>
                                                                    </div>

                                                                </div>

                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="auto-style6">
                                                                <div class="ln_solid"></div>
                                                                <div class='col-md-offset-2'>
                                                                    <div class='col-md-4'>
                                                                        <asp:LinkButton ID="btnSalvar" runat="server" class='btn btn-dark col-md-12' OnClick="btnSalvar_Click"><i class='fa fa-save'></i> Salvar</asp:LinkButton>
                                                                    </div>
                                                                    <div class='col-md-4'>
                                                                        <asp:Label ID="lblBtnCancelar" runat="server"></asp:Label>
                                                                    </div>
                                                                    <div class='col-md-4'>
                                                                        <asp:Label ID="lblBtnExcluir" runat="server"></asp:Label>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>

                                                    </table>

                                                </div>

                                                <div role="tabpanel" class="tab-pane fade" id="tab_content2" aria-labelledby="home-tab1">

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

                                                </div>
                                            </div>
                                        </div>
                                        <%-- DIV da tabs --%>
                                    </div>
                                    <%-- DIV col-md-9 --%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-- DIV main-container --%>
            <!-- /page content -->
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

    <script>
        function ativar(codigo) {
            var jsonText = JSON.stringify({ codigo: codigo });
            $.ajax({
                type: 'POST',
                url: 'PerfilUsuarios.aspx/Ativar',
                data: jsonText,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function () {
                    location.href = "ConsultaUsuario.aspx";
                }
            });
        }
    </script>

    <script>
        function desativar(codigo) {
            var jsonText = JSON.stringify({ codigo: codigo });
            $.ajax({
                type: 'POST',
                url: 'PerfilUsuarios.aspx/Desativar',
                data: jsonText,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function () {
                    location.href = "ConsultaUsuario.aspx";
                }
            });
        }
    </script>

</asp:Content>

