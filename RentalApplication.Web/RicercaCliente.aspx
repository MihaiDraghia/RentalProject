<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RicercaCliente.aspx.cs" Inherits="RentalApplication.Web.RicercaCliente" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:Info runat="server" ID="infoControl" />

    <asp:Panel class="panel panel-default" runat="server" ID="pnlCercaPersona">

        <asp:Panel class="panel-heading" runat="server" ID="pnlHeadCercaPersona">
            <h3 class="panel-title">Cerca Cliente</h3>
        </asp:Panel>

        <asp:Panel class="panel-body" runat="server">

            <div class="form-group">
                <label for="txtCercaNome">Nome</label>
                <asp:TextBox runat="server" ID="txtCercaNome" CssClass="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCercaCognome">Cognome</label>
                <asp:TextBox runat="server" ID="txtCercaCognome" CssClass="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCercaCF">Codice Fiscale</label>
                <asp:TextBox runat="server" ID="txtCercaCF" CssClass="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCercaEmail">Email</label>
                <asp:TextBox runat="server" ID="txtCercaEmail" CssClass="form-control">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCercaTelefono">Telefono</label>
                <asp:TextBox runat="server" ID="txtCercaTelefono" CssClass="form-control">
                </asp:TextBox>
            </div>

            <asp:Button runat="server" ID="btnCercaPersona" Text="Cerca" CssClass="btn btn-default" OnClick="btnCercaPersona_Click" />
            <asp:Button runat="server" ID="btnPulisci" Text="Nuova Ricerca" CssClass="btn btn-default" OnClick="btnPulisci_Click" />

        </asp:Panel>
    </asp:Panel>


    <asp:GridView runat="server" ID="gvCercaPersona" CssClass="table table-bordered table-hover table-striped no-margin" OnSelectedIndexChanged="gvCercaPersona_SelectedIndexChanged" AutoGenerateSelectButton="true" BorderStyle="None" AutoGenerateColumns="false" DataKeyNames="Id" AllowPaging="True" PageSize="15" OnPageIndexChanging="gvCercaPersona_PageIdxChanging">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="Nome">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Cognome" HeaderText="Cognome">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="CodiceFiscale" HeaderText="Codice Fiscale">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="DataNascita" HeaderText="Data Nascita" DataFormatString="{0:dd/MM/yyyy}">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Telefono" HeaderText="Telefono">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>

</asp:Content>
