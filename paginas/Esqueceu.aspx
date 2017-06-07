<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Esqueceu.aspx.cs" Inherits="paginas_Escqueceu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
            <link href="../css/bootstrap.min.css" rel="stylesheet" />
            <link href="../fonts/css/font-awesome.min.css" rel="stylesheet" />
            <link href="../css/animate.min.css" rel="stylesheet" />

            <link href="../css/custom.css" rel="stylesheet" />
            <link href="../css/green.css" rel="stylesheet" />

            <link href="../css/Wistoll.css" rel="stylesheet" />

            <title>Wistoll</title>
            <script src="../js/Login/jquery-2.2.2.js"></script>
            <link href="../css/pnotify.custom.min.css" rel="stylesheet" />
<body>
    <form id="form1" runat="server" defaultbutton="btnEnviar" defaultfocus="txtEmail">

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

                                <center><h1>Esqueceu a senha</h1></center>

                                <div class="clearfix"></div>

                            </div>
                            <div class="x_content">

                                <table class="col-md-6 col-md-offset-3">

                                    <tr>
                                        <td>
                                            <br />
                                            <div>
                                                <h4>Digite seu email para o envio da senha:</h4>
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Digite seu email" required="required"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <div class="item form-group col-md-offset-2">
                                                <div>
                                                    <asp:LinkButton ID="btnLimpar" runat="server" CssClass="btn btn-info" data-toggle="tooltip" data-placement="top" title="Voltar" OnClick="btnLimpar_Click"><i class="fa fa-reply"></i> Voltar</asp:LinkButton>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:LinkButton ID="btnEnviar" runat="server" CssClass="btn btn-dark" data-toggle="tooltip" data-placement="top" title="Enviar" OnClick="btnEnviar_Click">Enviar <i class="fa fa-arrow-right"></i></asp:LinkButton>
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
            function error() {
                new PNotify({
                    title: 'Email Inválido',
                    text: 'Só é possivel enviar para um email cadastrado no sistema!',
                    type: 'error'
                });
            }
        </script>

        <script type="text/javascript">
            function info() {
                new PNotify({
                    title: 'Email Enviado!',
                    text: 'Foi enviado ao seu email a sua nova senha!',
                    type: 'info'
                });
            }
        </script>

    </form>

</body>
</html>
