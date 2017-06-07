<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Erro404.aspx.cs" Inherits="paginas_Erro_Erro404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Erro 404</title>
    <link href="../../css/bootstrap.min.css" rel="stylesheet" />

    <link href="../../fonts/css/font-awesome.min.css" rel="stylesheet" />

    <link href="../../css/custom.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
     <div class="container body">

            <div class="main_container">

                <!-- page content -->
                <div class="col-md-12">
                    <div class="col-middle">
                        <div class="text-center">
                            <h1 class="error-number">404</h1>
                            <h2>Página não encontrada!</h2>
                            <p>
                                Durante sua ação ocorreu um erro! Se possivel retorne a  etapa anterior e realize novamente o procedimento, 
                          ocorrendo o mesmo erro. Se o problema persistir provavelmente você não possui permissões para fazer esse procedimento.
                            </p>
                            <div class="mid_center">

                                <asp:LinkButton ID="btnVoltar" runat="server" CssClass="btn btn-default" OnClick="btnVoltar_Click" >Voltar</asp:LinkButton>

                            </div>
                        </div>
                    </div>
                </div>
                <!-- /page content -->

            </div>
           
        </div>
    </form>
</body>
</html>
