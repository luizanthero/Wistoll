<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewCadastroUsuario.aspx.cs" Inherits="paginas_CadastroUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="telas">

        <div class="row">
            <div class="col-md-12">

                <div class="x_panel">

                    <div class="x_title">

                        <h2>Cadastro de Usuário</h2>

                        <ul class="nav navbar-right panel_toolbox">

                            <li>
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                            </li>
                            <%--<li>
                                <a class="close-link">
                                    <i class="fa fa-close"></i>
                                </a>
                            </li>--%>
                        </ul>

                        <div class="clearfix"></div>

                    </div>

                    <div class="x_content">
                        <br />
                        <h4>Cadastro Pessoal</h4>
                        <div class="ln_solid alert-info"></div>
                        <table class="auto-style4" data-step="1" data-intro='Formulário de Cadastro do Usuário com os dados pessoais'>

                            <tr>

                                <td class="auto-style6" >Nome<span>*</span>:</td>
                                <td class="auto-style5" >
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txbNome" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </td>

                                <td class="auto-style6">Sobrenome<span>*</span>:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txbSobrenome" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </td>

                                <td class="auto-style6">Data de Nascimento<span>*</span>:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txbDataNasc" runat="server" CssClass="form-control" data-inputmask="'mask': '99/99/9999'"></asp:TextBox>
                                    </div>
                                </td>

                            </tr>
                            <tr>

                                <td class="auto-style6">Cargo<span>*</span>:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:DropDownList ID="ddlCargo" data-live-search="true" runat="server" CssClass="form-control selectpicker"></asp:DropDownList>
                                    </div>
                                </td>

                                <td class="auto-style6">Matrícula<span>*</span>:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txbMatricula" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                    </div>
                                </td>

                                <td class="auto-style6">Sexo<span>*</span>:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:RadioButtonList ID="rblSexo" runat="server" CssClass="iCheckAsp radio" TextAlign="Left" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="M" Selected="True">M: </asp:ListItem>
                                            <asp:ListItem Value="F">F: </asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </td>

                            </tr>

                            <tr>

                                <td class="auto-style6">Perfil<span>*</span>:</td>
                                <td class="auto-style4">
                                    <div class="col-md-11">
                                        <asp:RadioButtonList ID="rblPerfil" runat="server" CssClass="iCheckAsp radio" RepeatDirection="Horizontal" TextAlign="Right"></asp:RadioButtonList>
                                    </div>
                                </td>

                                <td class="auto-style6">CPF<span>*</span>:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txbCpf" runat="server" CssClass="form-control" data-inputmask="'mask': '999.999.999-99'"></asp:TextBox>
                                    </div>
                                </td>

                                <td class="auto-style6">RG<span>*</span>:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txbRg" runat="server" CssClass="form-control" data-inputmask="'mask': '99.999.999-*'"></asp:TextBox>
                                    </div>
                                </td>

                            </tr>

                            <tr>

                                <td class="auto-style6">Setor<span>*</span>:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:DropDownList ID="ddlSetor" runat="server" data-live-search="true" CssClass="form-control selectpicker"></asp:DropDownList>
                                    </div>
                                </td>

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
                                <td class="auto-style6"><a id="btnContato" class="btn btn-dark col-md-4" style="display: none;" href="javascript:AddContato()"><i class="fa fa-plus"></i>Add</a></td>

                            </tr>

                            <tr>

                                <td class="auto-style6">Chefe<span>*</span>:</td>
                                <td class="auto-style4" colspan="2">
                                    <div class="col-md-11">
                                        <asp:RadioButtonList ID="rblChefe" runat="server" CssClass="iCheckAsp radio" RepeatDirection="Horizontal" TextAlign="Right">
                                            <asp:ListItem Value="0" Selected="True">Não é Chefe</asp:ListItem>
                                            <asp:ListItem Value="1">Chefe Setor</asp:ListItem>
                                            <asp:ListItem Value="2">Chefe Departamento</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </td>

                            </tr>

                        </table>

                        <br />
                        <br />

                        <div id="divTabela" style="display: none;" class="col-md-7 col-md-offset-2">
                            <table id="tblContato" class="table table-responsive">
                                <thead>
                                    <tr>
                                        <th>Tipo do Contato</th>
                                        <th>Contato</th>
                                        <th></th>
                                    </tr>
                                </thead>
                            </table>
                        </div>

                        <select id="lbTabela" name="lbTabela" style="display: none;"></select>

                        <div class="clearfix"></div>

                        <br />
                        <h4>Cadastro de Endereço</h4>
                        <div class="ln_solid alert-info"></div>
                        <table data-step="2" data-intro='Formulário de cadastro do Usuário com os dados complementares'>
                            <tr>

                                <td class="auto-style6">CEP<span>*</span>:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txbCep" runat="server" CssClass="form-control" data-inputmask="'mask': '99999-999'">></asp:TextBox>
                                    </div>
                                </td>

                                <td class="auto-style6">Estado<span>*</span>:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:DropDownList ID="ddlEstado" runat="server" data-live-search="true" CssClass="form-control selectpicker">
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
                                        <asp:TextBox ID="txbCidade" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </td>

                            </tr>

                            <tr>

                                <td class="auto-style6">Bairro<span>*</span>:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txbBairro" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </td>

                                <td class="auto-style6">Rua<span>*</span>:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txbRua" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </td>

                                <td class="auto-style6">Número<span>*</span>:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txbNumero" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </td>

                            </tr>

                            <tr>

                                <td class="auto-style6">Complemento:</td>
                                <td class="auto-style5">
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txbComplemento" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </td>

                            </tr>
                        </table>
                        <br />
                        <h4>Cadastro de Permissões</h4>
                        <div class="ln_solid alert-info"></div>

                        <div class="form-group">
                            <div class="table table-responsive col-md-5 col-md-offset-3" data-step="3" data-intro='Permissões Padrão►Permissões do Usuário previamente definidas e padronizadas.  Permissões Adicionais►Permissões do Usuário adicionais, para adicionar é necesssario clicar nos CheckBox da respectiva permissão '>
                                Permissões Padrão
                                <div class="form-group" >
                                    <asp:CheckBoxList ID="cblPadrao" runat="server" CssClass="col-md-4 iCheckAsp radio" Enabled="false"></asp:CheckBoxList>
                                </div>
                                Permissões Adicionais
                                <div class="form-group" >
                                    <asp:CheckBoxList ID="cblAdicional" runat="server" CssClass="col-md-4 iCheckAsp radio"></asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <div class="form-group" >
                            <div class="col-md-5 col-md-offset-8" data-step="4" data-intro="Botões para apagar os campos do formulário e salvá-los respectivamente">
                                <button id="btnApagar" runat="server" class="btn btn-default" title="Apagar" onserverclick="btnApagar_ServerClick"><i class="fa fa-trash"></i> Apagar</button>
                                <button id="btnSalvar" runat="server" class="btn btn-primary" title="Salvar" onserverclick="btnSalvar_ServerClick"><i class="fa fa-save"></i> Salvar</button>
                            </div>
                        </div>

                        <asp:Label ID="lbl" runat="server"></asp:Label>

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
         function erroEmail() {
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
    <script type="text/javascript">
        function warning2() {
            new PNotify({
                title: 'Atenção',
                text: 'Email já esta cadastrado!',
                type: 'warning'
            });
        }
    </script>
    <script type="text/javascript">
        function warning3() {
            new PNotify({
                title: 'Atenção',
                text: 'Matrícula já esta cadastrado!',
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
        (function ($) {
            AddContato = function () {

                var newRow = $("<tr>");
                var cols = "";
                var valor = "";

                if ($("#ddlTipoContato").val() == 1) {
                    valor = $("#txbEmail").val();
                    $("#txbEmail").val("");
                } else if ($("#ddlTipoContato").val() == 2) {
                    valor = $("#txbTelefone").val();
                    $("#txbTelefone").val("");
                } else if ($("#ddlTipoContato").val() == 3) {
                    valor = $("#txbCelular").val();
                    $("#txbCelular").val("");
                }

                var contato = $("#ddlTipoContato option:selected").text() + "|" + valor;

                $("#lbTabela").append("<option value='" + contato + "'>" + contato + "</option>");

                cols += '<td>' + $("#ddlTipoContato option:selected").text() + '</td>';
                cols += '<td>' + valor + '</td>';
                cols += '<td>';
                cols += '<a onclick="RemoveTableRow(this, \'' + contato + '\')" type="button" class="btn btn-dark"><i class="fa fa-minus"> Remover</i></button>';
                cols += '</td>';

                $("#divTabela").css("display", "block");

                newRow.append(cols);
                $("#tblContato").append(newRow);

                return false;
            };
        })(jQuery);
    </script>

    <script>
        (function ($) {

            RemoveTableRow = function (handler, contato) {
                var tr = $(handler).closest('tr');
                $("#lbTabela option[value='" + contato + "']").remove();
                tr.fadeOut(400, function () {
                    tr.remove();
                });

                return false;
            };
        })(jQuery);
    </script>

    <%--<script>
        function RemoveTableRow(handler, contato) {
            var tr = $(handler).closest('tr');
            $("#lbTabela").remove().append(contato);
            tr.fadeOut(400, function () {
                tr.remove();
            });

            return false;
        }
    </script>--%>

</asp:Content>

