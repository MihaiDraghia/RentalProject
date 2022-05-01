<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RentalApplication.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="jumbotron " style="background-color: aliceblue">
            <h1 class="active text-center">Gestione Noleggi</h1>
            <p class="lead"></p>
        </div>

        <br />
        <br />
        <br />

        <div class="row">

            <div class="col-md-4">
                <h2 class="text-center ">Ricerca Veicolo</h2>

                <a href="RicercaVeicolo.aspx">
                    <img src="img/RicercaVeicolo.jpg" width="370" height="200" class="img-rounded " /></a>
                <p>
                </p>
            </div>



            <div class="col-md-4">
                <h2 class="text-center ">Inserisci Veicolo</h2>

                <a href="InsertVeicolo.aspx">
                    <img src="img/InserisciVeicolo.jpg" width="370" height="200" class="img-rounded" /></a>
                <p>
                </p>
            </div>



            <div class="col-md-4">
                <h2 class="text-center ">Ricerca Noleggio</h2>

                <a href="RicercaNoleggio.aspx">
                    <img src="img/RicercaNoleggio.jpg" width="370" height="200" class="img-rounded" /></a>
                <p>
                </p>
            </div>


        </div>

        <div class="row">

            <div class="col-md-4">
                <h2 class="text-center ">Inserisci Cliente</h2>

                <a href="InsertCliente.aspx">
                    <img src="img/InsertCliente.jpg" width="370" height="200" class="img-rounded " /></a>
                <p>
                </p>
            </div>



            <div class="col-md-4">
                <h2 class="text-center ">Ricerca Cliente</h2>

                <a href="RicercaCliente.aspx">
                    <img src="img/RicercaCliente.jpg" width="370" height="200" class="img-rounded" /></a>
                <p>
                </p>
            </div>

        </div>

        <br />
        <br />
        <br />

    </div>

</asp:Content>
