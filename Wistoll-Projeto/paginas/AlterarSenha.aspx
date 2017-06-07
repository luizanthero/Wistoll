<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlterarSenha.aspx.cs" Inherits="paginas_AlterarSenha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../fonts/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/animate.min.css" rel="stylesheet" />

    <link href="../css/custom.css" rel="stylesheet" />
    <link href="../css/green.css" rel="stylesheet" />

    <link href="../css/Wistoll.css" rel="stylesheet" />

    <title>Wistoll</title>
    <script src="../js/Login/jquery-2.2.2.js"></script>
    <link href="../css/pnotify.custom.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnSalvar" defaultfocus="txbSenha">
        <div class="container body">
            <div class="main_container">
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <div class="row">
                    <div class="col-md-6 col-md-offset-3">
                        <div class="x_panel">
                            <div class="x_title">

                                <h2>Alterar Senha</h2>

                                <div class="clearfix"></div>

                            </div>
                            <div class="x_content">

                                <table class="col-md-6 col-md-offset-3">
                                    <tr>
                                        <td>
                                            <br />
                                            <div>
                                                Senha Nova:
                                                <asp:TextBox ID="txbSenha" runat="server" TextMode="Password" CssClass="form-control" onkeyup="ValidarSenha(this)" ClientIDMode="Static"></asp:TextBox>
                                                <asp:Label ID="lblSenha" runat="server" CssClass="pull-right btn alert-danger" ClientIDMode="Static" style="display: none;"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <div>
                                                Confirme a senha:
                                                <asp:TextBox ID="txbNova" runat="server" TextMode="Password" CssClass="form-control" onkeyup="SenhasIguais(this)"></asp:TextBox>
                                                <%--<h2 class="pull-right"><i class="fa fa-check-circle-o green"></i></h2>--%>
                                                <h2 class="pull-right"><i id="status" class="fa fa-close red" style="display: none;"></i></h2>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <div class="item form-group pull-right">
                                                <div>
                                                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn btn-default" data-toggle="tooltip" data-placement="top" title="Limpar" OnClick="btnLimpar_Click" />
                                                    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success" data-toggle="tooltip" data-placement="top" title="Salvar" OnClick="btnSalvar_Click" />
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <script src="../js/Login/pnotify.custom.min.js"></script>
        <script type="text/javascript">
            function warning() {
                new PNotify({
                    title: 'Atenção',
                    text: 'As senhas digitadas não são iguais! Tente novamente.',
                    type: 'warnning'
                });
            }
        </script>
        <script type="text/javascript">
            function warning1() {
                new PNotify({
                    title: 'Atenção',
                    text: 'A senha digitada não é forte! Tente novamente.',
                    type: 'warnning'
                });
            }
        </script>
        <script type="text/javascript">
            function error() {
                new PNotify({
                    title: 'Me Desculpe',
                    text: 'Ocorreu um erro inesperado! Por favor, tente novamente.',
                    type: 'warnning'
                });
            }
        </script>

        <script type="text/javascript">
            function ValidarSenha(txb) {
                var senha = $("#txbSenha").val();
                if ($("#txbSenha").val() != "") {
                    $("#lblSenha").css("display", "block");
                    if (senha.length > 8 && /[0-9]/gm.test(senha) && /[A-Z]/gm.test(senha) && /[a-z]/gm.test(senha)) {
                        $("#lblSenha").removeClass("alert-danger");
                        $("#lblSenha").addClass("alert-warning");
                        document.getElementById("lblSenha").innerHTML = "Senha Média";
                        if (/[!@#$%&*]/gm.test(senha)) {
                            $("#lblSenha").removeClass("alert-warning");
                            $("#lblSenha").addClass("alert-success");
                            document.getElementById("lblSenha").innerHTML = "Senha Forte";
                        }
                    } else {
                        $("#lblSenha").removeClass("alert-warning");
                        $("#lblSenha").addClass("alert-danger");
                        $("#lblSenha").removeClass("alert-success");
                        document.getElementById("lblSenha").innerHTML = "Senha Fraca";
                    }
                } else {
                    $("#lblSenha").css("display", "none");
                }
            }
        </script>
        <script type="text/javascript">
            function SenhasIguais(txb) {
                if ($("#txbNova").val() != "") {
                    $("#status").css("display", "block");
                    if ($("#txbSenha").val() == $("#txbNova").val()) {
                        $("#status").removeClass("fa-close");
                        $("#status").removeClass("red");
                        $("#status").addClass("fa-check-circle-o");
                        $("#status").addClass("green");
                    } else {
                        $("#status").addClass("fa-close");
                        $("#status").addClass("red");
                        $("#status").removeClass("fa-check-circle-o");
                        $("#status").removeClass("green");
                    }
                } else {
                    $("#status").css("display", "none");
                }
            }
        </script>

    </form>
</body>
</html>
