<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertVeicolo.aspx.cs" Inherits="RentalApplication.Web.InsertVeicolo" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:Info runat="server" ID="infoControl" />

    <asp:Panel class="panel panel-default" runat="server" ID="pnlVeicolo">

        <asp:Panel class="panel-heading" runat="server" ID="pnlHeadVeicolo">
            <h3 class="panel-title">Inserisci Veicolo</h3>
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
                <asp:TextBox runat="server" ID="txtDataImmatricolazione" CssClass="form-control" placeholder="gg/mm/aaaa" Type="datetime-local">
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
            <asp:Button runat="server" ID="btnInserisci" Text="Inserisci" CssClass="btn btn-default" OnClick="btnInserisci_Click" />
            <asp:Button runat="server" ID="btnPulisci" Text="Nuovo Inserimento" CssClass="btn btn-default" OnClick="btnPulisci_Click" />

        </asp:Panel>
    </asp:Panel>
</asp:Content>
