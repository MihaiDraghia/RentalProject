<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestioneNoleggiato.aspx.cs" Inherits="RentalApplication.Web.GestioneNoleggiato" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:Info runat="server" ID="infoControl" />

    <asp:Panel class="panel panel-default" runat="server" ID="pnlNoleggiato">

        <asp:Panel class="panel-heading" runat="server" ID="pnlHeadNoleggiato">
            <h3 class="panel-title">Dettagli Noleggio </h3>
        </asp:Panel>

        <asp:Panel class="panel-body" runat="server">
            <div class="form-group">
                <label for="txtMarca">Marca </label>
                <asp:TextBox runat="server" ID="txtMarca" CssClass="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtModello">Modello </label>
                <asp:TextBox runat="server" ID="txtModello" CssClass="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtTarga">Targa </label>
                <asp:TextBox runat="server" ID="txtTarga" CssClass="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtNome">Nome </label>
                <asp:TextBox runat="server" ID="txtNome" CssClass="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCognome">Cognome </label>
                <asp:TextBox runat="server" ID="txtCognome" CssClass="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCF">Codice Fiscale </label>
                <asp:TextBox runat="server" ID="txtCF" CssClass="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtEmail">Email </label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtTelefono">Telefono </label>
                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDataInizioNoleggio">Data Inizio Noleggio</label>
                <asp:TextBox runat="server" ID="txtDataInizioNoleggio" CssClass="form-control" ReadOnly="True" placeholder="gg/mm/aaaa">
                </asp:TextBox>
            </div>

            <asp:Button runat="server" ID="btnFineNoleggio" Text="Termina Noleggio" CssClass="btn btn-default" OnClick="btnFineNoleggio_Click" />
        </asp:Panel>
    </asp:Panel>

</asp:Content>
