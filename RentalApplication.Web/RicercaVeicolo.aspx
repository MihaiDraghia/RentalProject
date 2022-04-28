<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RicercaVeicolo.aspx.cs" Inherits="RentalApplication.Web.RicercaVeicolo" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:Info runat="server" ID="infoControl" />

    <asp:Panel class="panel panel-default" runat="server" ID="pnlVeicolo">

        <asp:Panel class="panel-heading" runat="server" ID="pnlHeadVeicolo">
            <h3 class="panel-title">Cerca Veicolo</h3>
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
                <label for="txtDataImmatricolazioneInizio">Data Immatricolazione (o inizio range temporale se viene impostata anche una fine) </label>
                <asp:TextBox runat="server" ID="txtDataImmatricolazioneInizio" CssClass="form-control" placeholder="gg/mm/aaaa" Type="datetime-local">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDataImmatricolazioneFine">Data Immatricolazione fine</label>
                <asp:TextBox runat="server" ID="txtDataImmatricolazioneFine" CssClass="form-control" placeholder="gg/mm/aaaa" Type="datetime-local">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="ddlNoleggiato">Noleggiato</label>
                <asp:DropDownList runat="server" ID="ddlNoleggiato" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <asp:Button runat="server" ID="btnRicerca" Text="Cerca" CssClass="btn btn-default" OnClick="btnRicerca_Click" />
            <asp:Button runat="server" ID="btnPulisci" Text="Nuova Ricerca" CssClass="btn btn-default" OnClick="btnPulisci_Click" />
        </asp:Panel>
    </asp:Panel>

    <asp:GridView runat="server" ID="gvVeicolo" CssClass="table table-bordered table-hover table-striped no-margin" BorderStyle="None" AutoGenerateColumns="false" OnSelectedIndexChanged="gvVeicolo_SelectedIndexChanged" DataKeyNames="Id" AutoGenerateSelectButton="true">
        <Columns>
            <asp:BoundField DataField="Marca" HeaderText="Marca">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Modello" HeaderText="Modello">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <%--            <asp:BoundField DataField="Targa" HeaderText="Targa">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>--%>
            <asp:BoundField DataField="DataImmatricolazione" HeaderText="DataImmatricolazione" DataFormatString="{0:dd/MM/yyyy}">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="IsNoleggiato" HeaderText="Noleggiato">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>

</asp:Content>

