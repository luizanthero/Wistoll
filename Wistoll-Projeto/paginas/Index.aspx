<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="paginas_Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--/** ********  Busca Div  ********** **/--%>
    <script>
        var str;
        $(document).ready(function () {
            $(".busca").keyup(function (event) {
                str = $(".busca").val();
                var er = new RegExp(str, "im");
                $(".x_panel").stop().hide(1000);
                $(".x_panel").each(function () {
                    val = $(this).html();
                    if (er.test(val)) {
                        $(this).stop().show(1000);
                    }
                });
            });
        });
    </script>
    <%--/** ********  Busca Div  ********** **/--%>
    <script>
        $(function () {
            $('.chart').easyPieChart({
                easing: 'easeOutElastic',
                delay: 3000,
                barColor: '#26B99A',
                trackColor: '#fff',
                scaleColor: false,
                lineWidth: 20,
                trackWidth: 16,
                lineCap: 'butt',
                onStep: function (from, to, percent) {
                    $(this.el).find('.percent').text(Math.round(percent));
                }
            });
            var chart = window.chart = $('.chart').data('easyPieChart');
            $('.js_update').on('click', function () {
                chart.update(Math.random() * 200 - 100);
            });
        });
    </script>

    <script>
        var lineChartData = {
            labels: ["", "", "", "", "", "", ""],
            datasets: [
                {
                    label: "My First dataset",
                    fillColor: "rgba(38, 185, 154, 0.11)", //rgba(220,220,220,0.2)
                    strokeColor: "rgba(38, 185, 154, 0.7)", //rgba(220,220,220,1)
                    pointColor: "rgba(38, 185, 154, 0.7)", //rgba(220,220,220,1)
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [10, 30, 42, 23, 35, 55, 77]
                }
            ]

        }

        $(document).ready(function () {
            new Chart(document.getElementById("canvas_line").getContext("2d")).Line(lineChartData, {
                responsive: true,
                scaleShowLabels: false,
                tooltipFillColor: "rgba(51, 51, 51, 0.55)"
            });
        });
        $(document).ready(function () {
            new Chart(document.getElementById("canvas_line1").getContext("2d")).Line(lineChartData, {
                responsive: true,
                scaleShowLabels: false,
                tooltipFillColor: "rgba(51, 51, 51, 0.55)"
            });
        });
        $(document).ready(function () {
            new Chart(document.getElementById("canvas_line2").getContext("2d")).Line(lineChartData, {
                responsive: true,
                scaleShowLabels: false,
                tooltipFillColor: "rgba(51, 51, 51, 0.55)"
            });
        });
        $(document).ready(function () {
            new Chart(document.getElementById("canvas_line3").getContext("2d")).Line(lineChartData, {
                responsive: true,
                scaleShowLabels: false,
                tooltipFillColor: "rgba(51, 51, 51, 0.55)"
            });
        });
        $(document).ready(function () {
            new Chart(document.getElementById("canvas_line4").getContext("2d")).Line(lineChartData, {
                responsive: true,
                scaleShowLabels: false,
                tooltipFillColor: "rgba(51, 51, 51, 0.55)"
            });
        });

        var sharePiePolorDoughnutData = [
            {
                value: 125,
                color: "rgba(38, 185, 154, 0.7)",
                highlight: "rgba(38, 185, 154, 0.7)",
                label: ""
            },
            {
                value: 25,
                color: "rgba(38, 185, 154, 0.01)",
                highlight: "rgba(38, 185, 154, 0.01)",
                label: ""
            }
        ];
        $(document).ready(function () {
            window.myDoughnut = new Chart(document.getElementById("canvas_doughnut").getContext("2d")).Doughnut(sharePiePolorDoughnutData, {
                responsive: true,
                scaleShowLabels: false,
                segmentStrokeWidth: 2,
                tooltipFillColor: "rgba(51, 51, 51, 0.55)"
            });
        });
        $(document).ready(function () {
            window.myDoughnut = new Chart(document.getElementById("canvas_doughnut2").getContext("2d")).Doughnut(sharePiePolorDoughnutData, {
                responsive: true,
                scaleShowLabels: false,
                segmentStrokeWidth: 2,
                tooltipFillColor: "rgba(51, 51, 51, 0.55)"
            });
        });
        $(document).ready(function () {
            window.myDoughnut = new Chart(document.getElementById("canvas_doughnut3").getContext("2d")).Doughnut(sharePiePolorDoughnutData, {
                responsive: true,
                scaleShowLabels: false,
                segmentStrokeWidth: 2,
                tooltipFillColor: "rgba(51, 51, 51, 0.55)"
            });
        });
        $(document).ready(function () {
            window.myDoughnut = new Chart(document.getElementById("canvas_doughnut4").getContext("2d")).Doughnut(sharePiePolorDoughnutData, {
                responsive: true,
                scaleShowLabels: false,
                segmentStrokeWidth: 2,
                tooltipFillColor: "rgba(51, 51, 51, 0.55)"
            });
        });
    </script>
    <script>
        $('document').ready(function () {
            $(".sparkline_one").sparkline([2, 4, 3, 4, 5, 4, 5, 4, 3, 4, 5, 6, 7, 5, 4, 3, 5, 6], {
                type: 'bar',
                height: '40',
                barWidth: 9,
                colorMap: {
                    '7': '#a1a1a1'
                },
                barSpacing: 2,
                barColor: '#26B99A'
            });

            $(".sparkline_two").sparkline([2, 4, 3, 4, 5, 4, 5, 4, 3, 4, 5, 6, 7, 5, 4, 3, 5, 6], {
                type: 'line',
                width: '200',
                height: '40',
                lineColor: '#26B99A',
                fillColor: 'rgba(223, 223, 223, 0.57)',
                lineWidth: 2,
                spotColor: '#26B99A',
                minSpotColor: '#26B99A'
            });
        })
    </script>


    <!-- dashbord linegraph -->
    <script>
        var doughnutData = [
            {
                value: 30,
                color: "#455C73"
            },
            {
                value: 30,
                color: "#9B59B6"
            },
            {
                value: 60,
                color: "#BDC3C7"
            },
            {
                value: 100,
                color: "#26B99A"
            },
            {
                value: 120,
                color: "#3498DB"
            }
        ];
        var myDoughnut = new Chart(document.getElementById("canvas1").getContext("2d")).Doughnut(doughnutData);
    </script>
    <!-- /dashbord linegraph -->

    <script>
        NProgress.done();
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="telas">

        <%--Status dos Processos--%>
        <div class="row">
            <div class="col-md-12">
                <div class="divider">
                    <h2>Status dos Processos</h2>
                </div>
                <div class="x_content">
                    <div class="row" data-step="1" data-intro='Todos Processos e seus Status: Deferido►Processo Aprovado Indeferido►Processo em avaliação Pendente►Processo em haver Finalizado►Processo finalizado'>

                        <asp:Label ID="lblProcessos" runat="server"></asp:Label>

                    </div>
                </div>

            </div>
        </div>
        <%--/Status dos Processos--%>

        <%--Processos Recentes--%>
        <div class="row">

            <div class="col-md-12">

                <br />
                <br />
                <div class="divider">
                    <h2>Processos</h2>
                </div>

                <%--Buscar Processos--%>
                <div class="title_right">

                    <div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">

                        <div class="input-group">

                            <asp:TextBox ID="txbFeed" runat="server" CssClass="form-control busca" placeholder="Buscar Processo..." data-step="2" data-intro="Local de busca dos Processos"></asp:TextBox>

                            <span class="input-group-btn">

                                <a class="btn btn btn-round btn-default " ><i class="fa fa-search"></i></a>

                            </span>

                        </div>

                    </div>

                </div>
                <%--/Buscar Processos--%>

                <div class="clearfix" ></div>
                                
                <asp:Label ID="lblStatus" runat="server" data-step="3" data-intro="Todos os processos criados pelo seu Usuário"></asp:Label>

            </div>
        </div>
    </div>

    <script src="<%=ResolveUrl("~/js/pnotify.buttons.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/pnotify.core.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/Pnotify.js")%>"></script>
    <script src="<%=ResolveUrl("~/js/pnotify.nonblock.js")%>"></script>

    <script type="text/javascript">
        function dark(nome) {
            new PNotify({
                title: 'Bem Vindo, ' + nome + '!',
                text: 'Separei algumas coisas importantes para você!',
                type: 'dark'
            });
        }
    </script>

</asp:Content>

