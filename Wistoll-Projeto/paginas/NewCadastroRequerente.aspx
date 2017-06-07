<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewCadastroRequerente.aspx.cs" Inherits="paginas_NewCadastroRequerente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="telas">

        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Cadastro de Requerente</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li>
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">

                        <div class="form-group text-right col-md-offset-3">
                            <asp:Label ID="lblTipoPessoa" runat="server" CssClass="control-label col-md-3 col-sm-3 col-xs-12">Tipo de Pessoa<span>*</span>:</asp:Label>
                            <div class="col-md-3 col-sm-6 col-xs-12" data-step="1" data-intro='Selecionar se o Requerente é uma Pessoa Física ou Jurídica. Ao clicar abrirá o formulário de cadastro da respectiva pessoa'>
                                <asp:DropDownList ID="ddlTipoPessoa" runat="server" CssClass="form-control col-md-7 col-xs-12 selectpicker" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoPessoa_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Selecionar...</asp:ListItem>
                                    <asp:ListItem Value="1">Física</asp:ListItem>
                                    <asp:ListItem Value="2">Jurídica</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="clearfix"></div>

                        <asp:MultiView ID="mlv" runat="server">
                            <asp:View ID="View0" runat="server"></asp:View>
                            <asp:View ID="View1" runat="server">

                                <div>
                                    <h4>Cadastro da Pessoa</h4>
                                    <div class="ln_solid alert-info"></div>
                                    <table data-step="2" data-intro='Formulário de cadastro dos dados pessoais do Requerente'>

                                        <tr>

                                            <td class="auto-style6" >Nome<span>*</span>:</td>
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

                                        <tr>

                                            <td class="auto-style6">Contato<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:DropDownList ID="ddlTipoContatoFis" runat="server" CssClass="form-control selectpicker" ClientIDMode="Static" onchange="contatoFis(this)">
                                                        <asp:ListItem Value="0">Selecione...</asp:ListItem>
                                                        <asp:ListItem Value="1">Email</asp:ListItem>
                                                        <asp:ListItem Value="2">Telefone</asp:ListItem>
                                                        <asp:ListItem Value="3">Celular</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>

                                            <td class="auto-style5">
                                                <div id="divEmailFis" style="display: none;" class="col-md-11">
                                                    <asp:TextBox ID="txbEmailFis" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                                <div id="divTelefoneFis" style="display: none;" class="col-md-11">
                                                    <asp:TextBox ID="txbTelefoneFis" runat="server" CssClass="form-control" ClientIDMode="Static" data-inputmask="'mask': '(99) 9999-99999'"></asp:TextBox>
                                                </div>
                                                <div id="divCelularFis" style="display: none;" class="col-md-11">
                                                    <asp:TextBox ID="txbCelularFis" runat="server" CssClass="form-control" ClientIDMode="Static" data-inputmask="'mask': '(99) 99999-99999'"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td class="auto-style6"><a id="btnContatoFis" class="btn btn-dark col-md-4" style="display: none;" href="javascript:AddContatoFis()"><i class="fa fa-plus"></i>Add</a></td>

                                        </tr>

                                    </table>

                                    <br />
                                    <br />

                                    <div id="divTabelaFis" style="display: none;" class="col-md-7 col-md-offset-2">
                                        <table id="tblContatoFis" class="table table-responsive">
                                            <thead>
                                                <tr>
                                                    <th>Tipo do Contato</th>
                                                    <th>Contato</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                        </table>
                                    </div>

                                    <select id="lbTabelaFis" name="lbTabelaFis" style="display: none;"></select>

                                    <div class="clearfix"></div>

                                    <h4>Cadastro de Endereço</h4>
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
                                                    <asp:DropDownList ID="ddlEstadoFis" runat="server" data-live-search="true" CssClass="form-control selectpicker">
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
                                            <button id="btnApagarFis" runat="server" class="btn btn-default" title="Apagar" onserverclick="btnApagarFis_ServerClick"><i class="fa fa-trash"></i> Apagar</button>
                                            <button id="btnSalvarFis" runat="server" class="btn btn-primary" title="Salvar" onserverclick="btnSalvarFis_ServerClick"><i class="fa fa-save"></i> Salvar</button>
                                        </div>
                                    </div>
                                </div>

                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <div>
                                    <h4>Cadastro da Empresa</h4>
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

                                        <tr>

                                            <td class="auto-style6">Contato<span>*</span>:</td>
                                            <td class="auto-style5">
                                                <div class="col-md-11">
                                                    <asp:DropDownList ID="ddlTipoContatoJur" runat="server" CssClass="form-control selectpicker" ClientIDMode="Static" onchange="contatoJur(this)">
                                                        <asp:ListItem Value="0">Selecione...</asp:ListItem>
                                                        <asp:ListItem Value="1">Email</asp:ListItem>
                                                        <asp:ListItem Value="2">Telefone</asp:ListItem>
                                                        <asp:ListItem Value="3">Celular</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>

                                            <td class="auto-style5">
                                                <div id="divEmailJur" style="display: none;" class="col-md-11">
                                                    <asp:TextBox ID="txbEmailJur" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                                <div id="divTelefoneJur" style="display: none;" class="col-md-11">
                                                    <asp:TextBox ID="txbTelefoneJur" runat="server" CssClass="form-control" ClientIDMode="Static" data-inputmask="'mask': '(99) 9999-99999'"></asp:TextBox>
                                                </div>
                                                <div id="divCelularJur" style="display: none;" class="col-md-11">
                                                    <asp:TextBox ID="txbCelularJur" runat="server" CssClass="form-control" ClientIDMode="Static" data-inputmask="'mask': '(99) 99999-99999'"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td class="auto-style6"><a id="btnContatoJur" class="btn btn-dark col-md-4" style="display: none;" href="javascript:AddContatoJur()"><i class="fa fa-plus"></i>Add</a></td>

                                        </tr>

                                    </table>

                                    <br />
                                    <br />

                                    <div id="divTabelaJur" style="display: none;" class="col-md-7 col-md-offset-2">
                                        <table id="tblContatoJur" class="table table-responsive">
                                            <thead>
                                                <tr>
                                                    <th>Tipo do Contato</th>
                                                    <th>Contato</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                        </table>
                                    </div>

                                    <select id="lbTabelaJur" name="lbTabelaJur" style="display: none;"></select>

                                    <div class="clearfix"></div>

                                    <h4>Cadastro de Endereço</h4>
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
                                                    <asp:DropDownList ID="ddlEstadoJur" runat="server" data-live-search="true" CssClass="form-control selectpicker">
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
                                            <button id="btnApagarJur" runat="server" class="btn btn-default" title="Apagar" onserverclick="btnApagarJur_ServerClick"><i class="fa fa-trash"></i> Apagar</button>
                                            <button id="btnSalvarJur" runat="server" class="btn btn-primary" title="Salvar" onserverclick="btnSalvarJur_ServerClick"><i class="fa fa-save"></i> Salvar</button>
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
                text: 'Obrigatório adicionar pelo menos um contato!',
                type: 'warning'
            });
        }
    </script>

    <script>
        function contatoFis(ddl) {
            switch (ddl.selectedIndex) {
                case 0:
                    $("#divEmailFis").css("display", "none");
                    $("#divTelefoneFis").css("display", "none");
                    $("#divCelularFis").css("display", "none");
                    $("#btnContatoFis").css("display", "none");
                    break;
                case 1:
                    $("#divEmailFis").css("display", "block");
                    $("#divTelefoneFis").css("display", "none");
                    $("#divCelularFis").css("display", "none");
                    $("#btnContatoFis").css("display", "block");
                    $("#txbEmailFis").attr("placeholder", "Ex: exemplo@exemplo.com");
                    break;
                case 2:
                    $("#divTelefoneFis").css("display", "block");
                    $("#divEmailFis").css("display", "none");
                    $("#divCelularFis").css("display", "none");
                    $("#btnContatoFis").css("display", "block");
                    $("#txbTelefoneFis").attr("placeholder", "Ex: (99) 9999-9999");
                    break;
                case 3:
                    $("#divCelularFis").css("display", "block");
                    $("#divEmailFis").css("display", "none");
                    $("#divTelefoneFis").css("display", "none");
                    $("#btnContatoFis").css("display", "block");
                    $("#txbCelularFis").attr("placeholder", "Ex: (99) 99999-9999");
                    break;
            }
        }
    </script>

    <script>
        function contatoJur(ddl) {
            switch (ddl.selectedIndex) {
                case 0:
                    $("#divEmailJur").css("display", "none");
                    $("#divTelefoneJur").css("display", "none");
                    $("#divCelularJur").css("display", "none");
                    $("#btnContatoJur").css("display", "none");
                    break;
                case 1:
                    $("#divEmailJur").css("display", "block");
                    $("#divTelefoneJur").css("display", "none");
                    $("#divCelularJur").css("display", "none");
                    $("#btnContatoJur").css("display", "block");
                    $("#txbEmailJur").attr("placeholder", "Ex: exemplo@exemplo.com");
                    break;
                case 2:
                    $("#divTelefoneJur").css("display", "block");
                    $("#divEmailJur").css("display", "none");
                    $("#divCelularJur").css("display", "none");
                    $("#btnContatoJur").css("display", "block");
                    $("#txbTelefoneJur").attr("placeholder", "Ex: (99) 9999-9999");
                    break;
                case 3:
                    $("#divCelularJur").css("display", "block");
                    $("#divEmailJur").css("display", "none");
                    $("#divTelefoneJur").css("display", "none");
                    $("#btnContatoJur").css("display", "block");
                    $("#txbCelularJur").attr("placeholder", "Ex: (99) 99999-9999");
                    break;
            }
        }
    </script>

    <script>
        (function ($) {
            AddContatoFis = function () {

                var newRow = $("<tr>");
                var cols = "";
                var valor = "";

                if ($("#ddlTipoContatoFis").val() == 1) {
                    valor = $("#txbEmailFis").val();
                    $("#txbEmailFis").val("");
                } else if ($("#ddlTipoContatoFis").val() == 2) {
                    valor = $("#txbTelefoneFis").val();
                    $("#txbTelefoneFis").val("");
                } else if ($("#ddlTipoContatoFis").val() == 3) {
                    valor = $("#txbCelularFis").val();
                    $("#txbCelularFis").val("");
                }

                var contato = $("#ddlTipoContatoFis option:selected").text() + "|" + valor;

                $("#lbTabelaFis").append("<option value='" + contato + "'>" + contato + "</option>");

                cols += '<td>' + $("#ddlTipoContatoFis option:selected").text() + '</td>';
                cols += '<td>' + valor + '</td>';
                cols += '<td>';
                cols += '<a onclick="RemoveTableRowFis(this, \'' + contato + '\')" type="button" class="btn btn-dark"><i class="fa fa-minus"> Remover</i></button>';
                cols += '</td>';

                $("#divTabelaFis").css("display", "block");

                newRow.append(cols);
                $("#tblContatoFis").append(newRow);

                return false;
            };
        })(jQuery);
    </script>

    <script>
        (function ($) {
            AddContatoJur = function () {

                var newRow = $("<tr>");
                var cols = "";
                var valor = "";

                if ($("#ddlTipoContatoJur").val() == 1) {
                    valor = $("#txbEmailJur").val();
                    $("#txbEmailJur").val("");
                } else if ($("#ddlTipoContatoJur").val() == 2) {
                    valor = $("#txbTelefoneJur").val();
                    $("#txbTelefoneJur").val("");
                } else if ($("#ddlTipoContatoJur").val() == 3) {
                    valor = $("#txbCelularJur").val();
                    $("#txbCelularJur").val("");
                }

                var contato = $("#ddlTipoContatoJur option:selected").text() + "|" + valor;

                $("#lbTabelaJur").append("<option value='" + contato + "'>" + contato + "</option>");

                cols += '<td>' + $("#ddlTipoContatoJur option:selected").text() + '</td>';
                cols += '<td>' + valor + '</td>';
                cols += '<td>';
                cols += '<a onclick="RemoveTableRowJur(this, \'' + contato + '\')" type="button" class="btn btn-dark"><i class="fa fa-minus"> Remover</i></button>';
                cols += '</td>';

                $("#divTabelaJur").css("display", "block");

                newRow.append(cols);
                $("#tblContatoJur").append(newRow);

                return false;
            };
        })(jQuery);
    </script>

    <script>
        (function ($) {

            RemoveTableRowFis = function (handler, contato) {
                var tr = $(handler).closest('tr');
                $("#lbTabelaFis option[value='" + contato + "']").remove();
                tr.fadeOut(400, function () {
                    tr.remove();
                });

                return false;
            };
        })(jQuery);
    </script>

    <script>
        (function ($) {

            RemoveTableRowJur = function (handler, contato) {
                var tr = $(handler).closest('tr');
                $("#lbTabelaJur option[value='" + contato + "']").remove();
                tr.fadeOut(400, function () {
                    tr.remove();
                });

                return false;
            };
        })(jQuery);
    </script>

</asp:Content>

