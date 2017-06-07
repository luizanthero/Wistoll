<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="paginas_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="../css/EstiloLogin.css" rel="stylesheet" />
    <link href="../css/EstiloHover.css" rel="stylesheet" />
    <link href="../fonts/css/LogoFonte.css" rel="stylesheet" />

    <title>Wistoll</title>
    <script src="../js/Login/jquery-2.2.2.js"></script>
    <link href="../css/pnotify.custom.min.css" rel="stylesheet" />
    <link href="../css/Modal.css" rel="stylesheet" />
</head>
<body>
    <center><form id="form1" runat="server" >
    
    <div>
        <a class="site_title"><i class="wi fa-paw"></i></a>

        <div><asp:TextBox ID="txbMatricula" runat="server" placeholder="Matrícula" required="required"></asp:TextBox></div>
        <div><asp:TextBox ID="txbSenha" runat="server" TextMode="Password" placeholder="Senha" required="required"></asp:TextBox></div>
             
        <table>

            <tr>

                <td><asp:Button ID="btnLogar" runat="server" Text="Logar" CssClass="hvr-glow" OnClick="btnLogar_Click"></asp:Button></td>
                
            </tr>

            <tr>
                
                <td><h5><a href="Esqueceu.aspx" class="dark btn btn-link"><i class="fa fa-lock"></i> Esqueci minha senha</a></h5><br /></td>

            </tr>

        </table>      
         
             
     </div>  


    <script src="../js/Login/pnotify.custom.min.js"></script>
        <script type="text/javascript">
            function warning() {
                new PNotify({
                    title: 'Desculpe',
                    text: 'Acho que você digitou errado sua senha ou matrícula.',
                    type: 'warnning'
                });
            }
            </script>

        <script src="../js/Login/pnotify.custom.min.js"></script>
            <script type="text/javascript">
                function error() {
                    new PNotify({
                        title: 'Atenção',
                        text: 'Você não tem mais permissão para acessar o sistema',
                        type: 'error'
                    });
                }
            </script>
       
    </form></center>
</body>
</html>
