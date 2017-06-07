<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewCadastroProcesso.aspx.cs" Inherits="paginas_Protocolo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="telas">
        <%--Formulario Cadastro--%>
        <div class="row">
            <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Cadastro de Processo</h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a href="javascript:void(0);" onclick="javascript:introJs().start();"><i class="fa fa-question"></i></a></li>
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content" data-step="1" data-intro='Formulário de Cadastro de Processo'>
                        <br />

                        <table class="auto-style4">
                            <tr data-step="2" data-intro='Número do processo. Este campo não é necessario o preenchimento'>
                                <td class="auto-style6">
                                    <h5>Número do Processo<span>*</span>:</h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txbNumero" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>

                            <tr data-step="4" data-intro='Nome do Requerente.'>
                                <td class="auto-style6">
                                    <h5>Nome do Requerente: <span>*</span>:</h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="col-md-11">
                                        <asp:DropDownList ID="ddlRequerente" runat="server" data-live-search="true" CssClass="form-control col-md-7 col-xs-12 selectpicker" required="required" autocomplete="off"></asp:DropDownList>
                                    </div>
                                </td>
                                <td>
                                    <h2 class="title" data-step="5" data-intro="Caso Requerente não esteja cadastrado, clicar neste botão para efetuar o cadastro">
                                        <%--<button type="button" id="btnCadastro" runat="server" class="btn btn-dark" data-toggle="modal" data-target="#cadastro"><i class="fa fa-plus"></i>Add</button>--%>
                                        <a class="btn btn-dark" href="../paginas/NewCadastroRequerente.aspx"><i class="fa fa-plus"></i>Add</a>
                                    </h2>
                                </td>
                            </tr>

                            <tr data-step="6" data-intro='Data na qual sera feita o processo. Este campo não é necessario o preenchimento'>
                                <td class="auto-style6">
                                    <h5>Data Pedido: <span>*</span>:</h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txbDataPedido" runat="server" CssClass="form-control col-md-7 col-xs-12" data-inputmask="'mask': '99/99/9999'" placeholder="DD/MM/AAAA" required="required" Enabled="false"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr data-step="7" data-intro='Modelo do Requerimento'>
                                <td class="auto-style6">
                                    <h5>Requerimento: <span>*</span>:</h5>
                                    <span></span></td>
                                <td class="auto-style5" colspan="2">
                                    <div class="col-md-11">
                                        <asp:DropDownList ID="dpRequerimento" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <div class="form-group">
                            <div class="col-md-5 col-md-offset-8" data-step="8" data-intro='Botões para apagar (limpar) e salvar os dados do formulário respectivamente'>
                                <asp:LinkButton ID="btnApagar" runat="server" CssClass="btn btn-default" data-toggle="tooltip" data-placement="top" title="Apagar"><i class="fa fa-trash"></i> Apagar</asp:LinkButton>
                                <asp:LinkButton ID="btnSalvar" runat="server" CssClass="btn btn-primary" data-toggle="tooltip" data-placement="top" title="Salvar" OnClick="btnSalvar_Click"><i class="fa fa-trash"></i> Salvar</asp:LinkButton>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <%--/Formulario Cadastro--%>
    </div>

    <%--<div id="cadastro" class="modal fade bs-example-modal-lg scroll" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h3 class="modal-title" id="modal">Cadastro de Requerente</h3>
                </div>
                <div class="modal-body">
                    <div class="item form-group">
                        <label class="control-label col-md-4 col-sm-6 col-xs-12 text-right">Tipo de Pessoa: <span class="required">*</span></label>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <asp:DropDownList ID="ddlEscolha" runat="server" CssClass="form-control" onchange="selecionar(this)">
                                <asp:ListItem>Selecione...</asp:ListItem>
                                <asp:ListItem>Pessoa Física</asp:ListItem>
                                <asp:ListItem>Pessoa Jurídica</asp:ListItem>
                            </asp:DropDownList>
                            <span class="fa fa-user form-control-feedback right" aria-hidden="true"></span>
                            <div class="page-title" id="view1" style="display: none;">
                                <div class="x_content">
                                    <h4>Cadastro Pessoa Física</h4>
                                    <div class="ln_solid alert-info"></div>
                                    <table class="auto-style4">
                                        <tr>
                                            <td class="auto-style6">Nome<span>*</span>:</td>
                                            <td class="auto-style5">
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
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="page-title" id="view2" style="display: none;">
                                <div class="x_content">
                                    <h4>Cadastro Pessoa Jurídica</h4>
                                    <div class="ln_solid alert-info"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

    <%--Modal--%>
    <div class="col-md-12">

        <div id="cadastro" class="modal fade bs-example-modal-lg scroll" tabindex="-1" role="dialog" aria-hidden="true">

            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <div class="modal-header">
                        <h3 class="modal-title left" id="modal">Cadastro do Requerente </h3>
                        <br />
                    </div>

                    <br />

                    <div class="modal-body">
                        <div class="item form-group">
                            <label class="control-label col-md-4 col-sm-3 col-xs-12">Pessoa: <span class="required">*</span></label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlEscolha" runat="server" CssClass="form-control" onchange="selecionar(this)">
                                    <asp:ListItem>Selecione...</asp:ListItem>
                                    <asp:ListItem>Pessoa Física</asp:ListItem>
                                    <asp:ListItem>Pessoa Jurídica</asp:ListItem>
                                </asp:DropDownList><span class="fa fa-user form-control-feedback right" aria-hidden="true"></span>
                            </div>
                        </div>
                        <div class="page-title" id="view1" style="display: none;">
                            <div class="x_content">
                                <br />
                                <h4>Cadastro Pessoa Física</h4>
                                <div class="ln_solid alert-info"></div>
                                <table class="auto-style4">

                                    <tr>

                                        <td class="auto-style6">Nome<span>*</span>:</td>
                                        <td class="auto-style5">
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

                                    </tr>
                                    <tr>
                                        <td class="auto-style6">Data de Nascimento<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="txbDataNasc" runat="server" CssClass="form-control" data-inputmask="'mask': '99/99/9999'"></asp:TextBox>
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
                                        <td class="auto-style6">Contato<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:DropDownList ID="ddlTipoContato" runat="server" CssClass="form-control" ClientIDMode="Static" onchange="contato(this)">
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



                                </table>


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
                                <table>
                                    <tr>

                                        <td class="auto-style6">CEP<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" data-inputmask="'mask': '99999-999'">></asp:TextBox>
                                            </div>
                                        </td>

                                        <td class="auto-style6">Estado<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control">
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



                                    </tr>

                                    <tr>

                                        <td class="auto-style6">Bairro<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </td>

                                        <td class="auto-style6">Rua<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </td>



                                    </tr>

                                    <tr>
                                        <td class="auto-style6">Número<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </td>


                                        <td class="auto-style6">Cidade<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style6">Complemento:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>

                                    <br />
                                </table>

                                <div class="form-group">
                                    <div class="col-md-5 col-md-offset-8">
                                        <table>
                                            <tr>
                                                <td>
                                                    <button id="Button1" runat="server" class="btn btn-default" title="Apagar"><i class="fa fa-trash"></i>Apagar</button></td>
                                                <td>
                                                    <button id="Button2" runat="server" class="btn btn-primary" title="Salvar"><i class="fa fa-save"></i>Salvar</button></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <asp:Label ID="lbl" runat="server"></asp:Label>

                            </div>
                        </div>
                        <div class="page-title" id="view2" style="display: none;">

                            <div class="x_content">
                                <br />
                                <h4>Cadastro Pessoa Jurídica</h4>
                                <div class="ln_solid alert-info"></div>
                                <table class="auto-style4">

                                    <tr>

                                        <td class="auto-style6">CNPJ<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="txtCNPJ" runat="server" CssClass="form-control col-md-7 col-xs-12" data-validate-minmax="5" placeholder="Entre com número do CNPJ"></asp:TextBox>
                                            </div>
                                        </td>

                                        <td class="auto-style6">Sigla<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="txtSigla" runat="server" CssClass="form-control col-md-7 col-xs-12" data-validate-minmax="5" placeholder="Entre com a sigla"></asp:TextBox>
                                            </div>
                                        </td>



                                    </tr>
                                    <tr>

                                        <td class="auto-style6">Razão Social<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="txtSocial" runat="server" CssClass="form-control col-md-7 col-xs-12" data-validate-minmax="5" placeholder="Entre com a razão social"></asp:TextBox>
                                            </div>
                                        </td>




                                        <td class="auto-style6">Contato<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" ClientIDMode="Static" onchange="contato(this)">
                                                    <asp:ListItem Value="0">Selecione...</asp:ListItem>
                                                    <asp:ListItem Value="1">Email</asp:ListItem>
                                                    <asp:ListItem Value="2">Telefone</asp:ListItem>
                                                    <asp:ListItem Value="3">Celular</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>

                                        <td class="auto-style5">
                                            <div id="divEmail" style="display: none;" class="col-md-11">
                                                <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                            </div>
                                            <div id="divTelefone" style="display: none;" class="col-md-11">
                                                <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" ClientIDMode="Static" data-inputmask="'mask': '(99) 9999-99999'"></asp:TextBox>
                                            </div>
                                            <div id="divCelular" style="display: none;" class="col-md-11">
                                                <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" ClientIDMode="Static" data-inputmask="'mask': '(99) 99999-99999'"></asp:TextBox>
                                            </div>
                                        </td>
                                        <td class="auto-style6"><a id="btnContato" class="btn btn-dark col-md-4" style="display: none;" href="javascript:AddContato()"><i class="fa fa-plus"></i>Add</a></td>

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
                                <table>
                                    <tr>

                                        <td class="auto-style6">CEP<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" data-inputmask="'mask': '99999-999'">></asp:TextBox>
                                            </div>
                                        </td>

                                        <td class="auto-style6">Estado<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
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
                                    </tr>

                                    <tr>

                                        <td class="auto-style6">Bairro<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="TextBox12" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </td>

                                        <td class="auto-style6">Rua<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="TextBox13" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="auto-style6">Número<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="TextBox14" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </td>


                                        <td class="auto-style6">Cidade<span>*</span>:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="auto-style6">Complemento:</td>
                                        <td class="auto-style5">
                                            <div class="col-md-11">
                                                <asp:TextBox ID="TextBox15" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>

                                    <br />
                                </table>

                                <div class="form-group">
                                    <div class="col-md-5 col-md-offset-8">
                                        <table>

                                            <td>
                                                <button id="Button3" runat="server" class="btn btn-default" title="Apagar" data-placement="top"><i class="fa fa-trash"></i>Apagar</button></td>
                                            <td>
                                                <button id="Button4" runat="server" class="btn btn-primary" title="Salvar" data-placement="top"><i class="fa fa-save"></i>Salvar</button></td>
                                        </table>

                                    </div>
                                </div>

                                <asp:Label ID="Label1" runat="server"></asp:Label>

                            </div>
                        </div>
                    </div>

                </div>

            </div>

        </div>
    </div>
    <%--FIm Modal--%>

    <script>
        function selecionar(ddl) {
            if (ddl.selectedIndex == '0') {
                $("#view1").css('display', 'none');
                $("#view2").css('display', 'none');
            }
            if (ddl.selectedIndex == '1') {
                $("#view1").css('display', 'block');
                $("#view2").css('display', 'none');
            }
            if (ddl.selectedIndex == '2') {
                $("#view1").css('display', 'none');
                $("#view2").css('display', 'block');
            }
        }
    </script>

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
                text: 'Você esqueceu de preencher algum campo.',
                type: 'warning'
            });
        }
    </script>

</asp:Content>

