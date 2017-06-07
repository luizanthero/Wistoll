<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PerfilUsuarios.aspx.cs" Inherits="paginas_PerfilUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentplaceholder1" Runat="Server">

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
                                    <asp:Label ID="lblInfo" runat="server"></asp:Label></h3>

                                <div class="x_content">

                                    <div class="col-md-3 col-sm-3 col-xs-12 profile_left">

                                        <div class="profile_img">

                                            <div id="crop-avatar">

                                                <asp:Label ID="lblImagem" runat="server"></asp:Label>

                                            </div>
                                            <!-- end of image cropping -->

                                        </div>

                                        <asp:Label ID="lblDados" runat="server"></asp:Label>

                                        <br />

                                    </div>

                                    <%-- DIV col-md-9 --%>
                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                        <br />

                                        <%-- DIV da tabs --%>
                                        <div class="" role="tabpanel" data-example-id="togglable-tabs">
                                            <ul id="myTab" class="nav nav-tabs bar_tabs" role="tablist">
                                                <li role="presentation" class="active"><a href="#tab_content1" id="home-tab" role="tab" data-toggle="tab" aria-expanded="true">Últimas ações realizadas no sistema</a></li>
                                            </ul>

                                            <div id="myTabContent" class="tab-content">

                                                <div role="tabpanel" class="tab-pane fade active in col-md-7">

                                                    <!-- start recent activity -->                                                    
                                                            <asp:Label ID="lblTabbFeed" runat="server" Text=""></asp:Label>
                                                    <!-- end recent activity -->

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

