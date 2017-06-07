<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TesteTexto.aspx.cs" Inherits="TesteTexto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="telas">

        <div class="row">

            <div class="col-md-12">

                <div class="x_panel">

                    <div class="x_title">

                        <h2>Texto</h2>

                        <ul class="nav navbar-right panel_toolbox">

                            <li>
                                <a class="atalho" href="javascript: index=9;zoom(mais)" onfocus="javascript: index=9;zoom(mais)" accesskey="N" title="Tamanho Normal">
                                    <i class="fa fa-reply"></i>
                                </a>
                            </li>
                            <li>
                                <a class="atalho" href="javascript: zoom(mais)" onfocus="javascript: zoom(mais)" accesskey="A" title="Aumenta 10%">
                                    <i class="fa fa-search-plus"></i>
                                </a>
                            </li>
                            <li>
                                <a class="atalho" href="javascript: zoom(menos)" onfocus="javascript: zoom(menos)" accesskey="D" title="Diminui 10%">
                                    <i class="fa fa-search-minus"></i>
                                </a>
                            </li>

                            <li><a><i></i></a></li>
                            <li><a><i></i></a></li>

                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a></li>

                        </ul>

                        <div class="clearfix"></div>

                    </div>

                    <div class="x_content">

                        <ul class="nav navbar-right panel_toolbox">
                            <input type="hidden" value="100%" id="percent" size="2" class="form-control" />
                        </ul>

                        <h3>Texto</h3>

                        <div id="texto">
                            <p>
                                Lorem ipsum dolor sit amet, pri et utinam utamur, eos ei porro laboramus, nam dicit mandamus ea. 
                            Putent fastidii detracto est no. Sit ei timeam albucius, quo ex saperet vulputate voluptaria. 
                            His principes efficiantur at, modus nostro quo ei. Ius an alia sonet luptatum.
                            </p>

                            <p>
                                Eos nonumy eripuit at, id qui everti adversarium. Mazim perpetua ne has, adhuc erroribus eum ne. 
                            Id nec epicuri accumsan liberavisse, est munere impetus ex, per id ludus utinam volumus. 
                            Et has enim congue, eu timeam inimicus has, vis purto inermis alienum eu. 
                            At has fierent conceptam sadipscing, modus laoreet pri cu.
                            </p>
                        </div>

                    </div>

                </div>

            </div>

        </div>

    </div>
</asp:Content>

