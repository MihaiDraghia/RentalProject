<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DettaglioVeicolo.aspx.cs" Inherits="RentalApplication.Web.DettaglioVeicolo" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:Info runat="server" ID="infoControl" />

    <asp:Panel class="panel panel-default" runat="server" ID="pnlVeicolo">

        <asp:Panel class="panel-heading" runat="server" ID="pnlHeadVeicolo">
            <h3 class="panel-title">Dettagli Veicolo</h3>
        </asp:Panel>

        <asp:Panel class="panel-body" runat="server">
            <div class="form-group">
                <label for="ddlMarca">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtModello">Modello</label>
                <asp:TextBox runat="server" ID="txtModello" CssClass="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtTarga">Targa</label>
                <asp:TextBox runat="server" ID="txtTarga" CssClass="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDataImmatricolazione">Data Immatricolazione</label>
                <asp:TextBox runat="server" ID="txtDataImmatricolazione" CssClass="form-control" placeholder="gg/mm/aaaa">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ddlAlimentazione">Alimentazione</label>
                <asp:DropDownList runat="server" ID="ddlAlimentazione" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtNote">Note</label>
                <asp:TextBox runat="server" ID="txtNote" CssClass="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtNoleggiato">Noleggiato</label>
                <asp:TextBox runat="server" ID="txtNoleggiato" CssClass="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label for="txtCliente" ID="lblCliente" Text="Nome Cliente" runat="server" Visible="False"></asp:Label>
                <asp:TextBox runat="server" ID="txtCliente" CssClass="form-control" ReadOnly="True" Visible="False">
                </asp:TextBox>
            </div>
            <asp:Button runat="server" ID="btnModifica" Text="Salva Modifiche" CssClass="btn btn-default" OnClick="btnModifica_Click" />
            <asp:Button runat="server" ID="btnElimina" Text="Elimina" CssClass="btn btn-default" OnClick="btnElimina_Click" />
            <asp:Button runat="server" ID="btnGestioneNoleggio" Text="Gestisci Noleggio" CssClass="btn btn-default" OnClick="btnGestisciNoleggio_Click" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
