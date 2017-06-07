<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Process.aspx.cs" Inherits="paginas_Process" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblCodProcesso" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblNroProcesso" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblDetalheProcesso" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblTramitacao" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblLocalAnterior" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblNumeroRedator" runat="server" Visible="false"></asp:Label>
    <div class="container body">
        <div class="main_container">
            <!-- page content -->
            <div role="main">

                <div class="">
                    <div class="page-title">
                        <div class="title_left">
                            <h3>Exibicao do processo </h3>
                        </div>
                    </div>
                    <div class="clearfix"></div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="x_panel">

                                <asp:Literal ID="lblTitle" runat="server" Text="Label"></asp:Literal>

                                <div class="x_content">

                                    <div class="col-md-9 col-sm-9 col-xs-12">

                                        <asp:Label ID="lblTempo" runat="server" Text=""></asp:Label>

                                        <div class="x_content">

                                            <div class="dashboard-widget-content">

                                                <asp:Label ID="lblFeddBack" runat="server" Text=""></asp:Label>

                                            </div>

                                        </div>

                                        <%--<div>

                                            <h4>Atividade Recente </h4>
                                            <!-- end of user messages -->
                                            <asp:Label ID="lblFeed" runat="server" Text=""></asp:Label>
                                            <!-- end of user messages -->

                                        </div>--%>
                                    </div>

                                    <!-- start project-detail sidebar -->
                                    <div class="col-md-3 col-sm-3 col-xs-12 right">

                                        <section class="panel">
                                            <%--<asp:Label ID="lblNumeroProcesso" runat="server" Visible="false" ClientIDMode="Static"></asp:Label>--%>
                                            <asp:Label ID="lblResumo" runat="server"></asp:Label>

                                            <%--<asp:LinkButton ID="lnkTramitar" runat="server" CssClass="btn btn-warning"><i class="fa fa-send"></i> Tramitar</asp:LinkButton>--%>

                                            <!-- Modal Tramitar -->
                                            <!-- Button trigger modal -->
                                            <button id="compose" class="btn btn-default" type="button" style="display: none;"><i class="fa fa-eye"></i> Parecer</button>

                                            <!-- Modal -->
                                            <div class="modal fade bs-example-modal-sm" id="modalTramitar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                                <div class="modal-dialog" role="document">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" data-toggle="tooltip" data-placement="bottom" title="Fechar">
                                                                <span aria-hidden="true">&times;</span>
                                                            </button>
                                                            <h2 class="modal-title text-center" id="myModalLabel">Selecione o destino para o tramite</h2>
                                                        </div>
                                                        <div class="modal-body" style="min-height: 300px;">

                                                            <table class="col-md-offset-1">
                                                                <tr>
                                                                    <td class="auto-style6">
                                                                        <h5>Digite o local de envio<span>*</span>:</h5>
                                                                    </td>
                                                                    <td class="col-md-8">
                                                                        <div class="item form-group">
                                                                            <div class="col-md-10 col-sm-12 col-xs-12">
                                                                                <asp:DropDownList ID="ddlLocal" data-live-search="true" runat="server" CssClass="form-control selectpicker"></asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                </tr>
                                                            </table>

                                                            <img src="../images/transparente.png" class="profile_info" style="margin-left: 120px; margin-top: 30px;" />

                                                            <%--<asp:TextBox ID="TextBox1" runat="server" AutoCompleteType="FirstName"></asp:TextBox>--%>
                                                        </div>
                                                        <div class="modal-footer">
                                                            <table class="col-md-offset-5">
                                                                <tr>
                                                                    <td>
                                                                        <asp:LinkButton ID="lnkTramitar" runat="server" CssClass="btn btn-default" OnClick="lnkTramitar_Click"><i class="fa fa-send"></i> Tramitar</asp:LinkButton></td>
                                                                </tr>
                                                            </table>


                                                            <%--<button type="button" class="btn btn-primary">Tramitar</button>--%>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <%--  --%>

                                            <%-- finalizar --%>
                                            <asp:LinkButton ID="lnkDevolver" runat="server" CssClass="btn btn-default" Visible="false" OnClick="lnkDevolver_Click"><i class="fa fa-send"></i> Devolver </asp:LinkButton>

                                            <!-- Modal -->
                                            <%--<div class="modal fade" id="modalFinalizar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                                <div class="modal-dialog" role="document">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" data-toggle="tooltip" data-placement="bottom" title="Fechar">
                                                                <span aria-hidden="true">&times;</span>
                                                            </button>
                                                            <h3 class="modal-title red" id="myModalLabel1">Aviso!</h3>
                                                        </div>
                                                        <div class="modal-body">
                                                            <center><h2>Tem certeza que deseja finalizar este processo?</h2></center>
                                                        </div>
                                                        <div class="modal-footer">
                                                            <table class="col-md-offset-9">
                                                                <tr>
                                                                    <td>
                                                                        <button type="button" class="btn btn-default"><i class="fa fa-close"></i>Não </button>
                                                                    </td>
                                                                    <td>
                                                                        <asp:LinkButton ID="lnkSim" runat="server" CssClass="btn btn-danger"><i class="fa fa-check"></i> Sim </asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>--%>

                                            <div class="modal fade" id="modalFinalizar" tabindex="- 1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                                <div class="modal-dialog" role="document">
                                                    <div class="modal-content">
                                                        <div class="modal-header">
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                <span aria-hidden="true">&times;</span>
                                                            </button>
                                                            <h3 class="modal-title red" id="myModalLabel">Aviso!</h3>
                                                        </div>
                                                        <div class="modal-body">
                                                            <h2 class="text-center">Tem certeza que deseja Finalizar?</h2>
                                                        </div>
                                                        <div class="divider"></div>
                                                        <div class="col-xs-12 bottom text-right">
                                                            <button type="button" class="btn btn-default" data-dismiss="modal">Não</button>
                                                            <%--<button type="button" class="btn btn-danger" onclick="">Sim</button>--%>
                                                            <asp:LinkButton ID="lnkSim" runat="server" CssClass="btn btn-danger" OnClick="lnkSim_Click">Sim</asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <asp:LinkButton ID="lnkTramitar1" CssClass="btn btn-default" runat="server" data-toggle="modal" data-target="#modalTramitar" Visible="false"><i class="fa fa-send"></i> Tramitar</asp:LinkButton>
                                            <%--<asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-success"><i class="fa fa-eye"></i> Parecer </asp:LinkButton>--%>
                                            <asp:LinkButton ID="lnkFinalizar" CssClass="btn btn-default" runat="server" data-toggle="modal" data-target="#modalFinalizar" Visible="false"><i class="fa fa-archive"></i> Finalizar</asp:LinkButton>

                                            <br />

                                        </section>



                                    </div>

                                    <table class="col-md-5 col-md-offset-7">
                                        <tr>
                                            <td colspan="3">
                                                <asp:FileUpload ID="flpArquivos" runat="server" Font-Size="8" AllowMultiple="True" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblNomeAnexo" runat="server">Nome do Arquivo*: </asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txbAnexoNome" runat="server" CssClass="form-control"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="lnkUpload" runat="server" CssClass="btn btn-primary" OnClick="lnkUpload_Click"><i class="fa fa-check"></i> Enviar </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <!-- end project-detail sidebar -->

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <!-- /page content -->
        </div>
    </div>


    <!-- compose -->
    <div class="compose col-md-6 col-xs-12">
        <div class="compose-header">
            <h4>Nova Observação 
        <button type="button" class="close compose-close">
            <span>×</span>
        </button>
            </h4>
        </div>

        <div class="compose-body">
            <div id="alerts"></div>

            <%--<div id="editor" class="editor-wrapper col-md-12"></div>--%>
            <br />
            <asp:TextBox ID="editor" CssClass="editor-wrapper col-md-12 form-control" runat="server" ClientIDMode="Static" TextMode="MultiLine" Font-Size="Medium"></asp:TextBox>
        </div>
        <div class="clearfix"></div>
        <div class="compose-footer">
            <%--<button id="enviar" class="btn btn-sm btn-success" type="button" onclick="enviar();">Enviar</button>--%>
            <br />
            <button type="button" id="btn" class="btn btn-sm btn-success" onclick="enviar();">Enviar</button>

        </div>
    </div>
    <!-- /compose -->
    <script src="<%=ResolveUrl("~/js/pnotify.buttons.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/pnotify.core.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/Pnotify.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/pnotify.nonblock.js")%>"></script>

    <script type="text/javascript">
        function sucess() {
            new PNotify({
                title: 'Enviado!',
                text: 'Um arquivo foi anexado ao processo!',
                type: 'success'
            });
        }
    </script>
    <script type="text/javascript">
        function warning() {
            new PNotify({
                title: 'Atenção',
                text: 'Nome do arquivo obrigatório!',
                type: 'warning'
            });
        }
    </script>
    <script type="text/javascript">
        function infoTamanho() {
            new PNotify({
                title: 'Aviso!',
                text: 'Tamanho do arquivo não suportado. Tamanho máximo 400KB!',
                type: 'info'
            });
        }
    </script>
    <script type="text/javascript">
        function infoExtensao() {
            new PNotify({
                title: 'Aviso!',
                text: 'Extensão de arquivo não suportada. Favor enviar um arquivo .doc, .docx ou .pdf!',
                type: 'info'
            });
        }
    </script>
    <script type="text/javascript">
        function error() {
            new PNotify({
                title: 'Erro!',
                text: 'Durante a execução do procedimento aconteceu uma falha. Tente novamente!',
                type: 'error'
            });
        }
    </script>

    <script>
        function AtivarCompose() {
            $("#compose").css("display", "block");
        }
    </script>

    <script type="text/javascript">
        function enviar() {
            var texto = $("#editor").val();
            var numero = $("#lblNumeroProcesso")[0].innerText;
            var jsonText = JSON.stringify({ texto: texto, numero: numero });
            $.ajax({
                type: 'POST',
                url: 'Process.aspx/Enviar',
                data: jsonText,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function () {
                    location.href = "../paginas/Process.aspx?pro=<%= HttpContext.Current.Request.QueryString["pro"] %>";
                    <%--<% HttpContext.Current.Response.Redirect("../paginas/Process.aspx"); %>--%>
                }
            });
        }
    </script>

    <!-- bootstrap-wysiwyg -->
    <script>
        $(document).ready(function () {
            function initToolbarBootstrapBindings() {
                var fonts = ['Serif', 'Sans', 'Arial', 'Arial Black', 'Courier',
                    'Courier New', 'Comic Sans MS', 'Helvetica', 'Impact', 'Lucida Grande', 'Lucida Sans', 'Tahoma', 'Times',
                    'Times New Roman', 'Verdana'
                ],
                  fontTarget = $('[title=Font]').siblings('.dropdown-menu');
                $.each(fonts, function (idx, fontName) {
                    fontTarget.append($('<li><a data-edit="fontName ' + fontName + '" style="font-family:\'' + fontName + '\'">' + fontName + '</a></li>'));
                });
                $('a[title]').tooltip({
                    container: 'body'
                });
                $('.dropdown-menu input').click(function () {
                    return false;
                })
                  .change(function () {
                      $(this).parent('.dropdown-menu').siblings('.dropdown-toggle').dropdown('toggle');
                  })
                  .keydown('esc', function () {
                      this.value = '';
                      $(this).change();
                  });

                $('[data-role=magic-overlay]').each(function () {
                    var overlay = $(this),
                      target = $(overlay.data('target'));
                    overlay.css('opacity', 0).css('position', 'absolute').offset(target.offset()).width(target.outerWidth()).height(target.outerHeight());
                });

                if ("onwebkitspeechchange" in document.createElement("input")) {
                    var editorOffset = $('#editor').offset();

                    $('.voiceBtn').css('position', 'absolute').offset({
                        top: editorOffset.top,
                        left: editorOffset.left + $('#editor').innerWidth() - 35
                    });
                } else {
                    $('.voiceBtn').hide();
                }
            }

            function showErrorAlert(reason, detail) {
                var msg = '';
                if (reason === 'unsupported-file-type') {
                    msg = "Unsupported format " + detail;
                } else {
                    console.log("error uploading file", reason, detail);
                }
                $('<div class="alert"> <button type="button" class="close" data-dismiss="alert">&times;</button>' +
                  '<strong>File upload error</strong> ' + msg + ' </div>').prependTo('#alerts');
            }

            initToolbarBootstrapBindings();

            $('#editor').wysiwyg({
                fileUploadError: showErrorAlert
            });

            prettyPrint();
        });
    </script>
    <!-- /bootstrap-wysiwyg -->

    <!-- compose -->
    <script>
        $('#compose, .compose-close').click(function () {
            $('.compose').slideToggle();
        });
    </script>

    <!-- /compose -->


</asp:Content>

