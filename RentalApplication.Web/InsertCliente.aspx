<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertCliente.aspx.cs" Inherits="RentalApplication.Web.InsertCliente" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:Info runat="server" ID="infoControl" />

    <asp:Panel class="panel panel-default" runat="server" ID="pnlNuovaPersona">

        <asp:Panel class="panel-heading" runat="server" ID="pnlHeadNuovaPersona">
            <h3 class="panel-title">Nuovo Cliente</h3>
        </asp:Panel>

        <asp:Panel class="panel-body" runat="server">

            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtNewNome">Nome</label>
                    <asp:TextBox runat="server" ID="txtNewNome" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtNewCognome">Cognome</label>
                    <asp:TextBox runat="server" ID="txtNewCognome" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtNewCF">Codice Fiscale</label>
                    <asp:TextBox runat="server" ID="txtNewCF" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtNewDataNascita">Data Nascita</label>
                    <asp:TextBox runat="server" ID="txtNewDataNascita" CssClass="form-control" placeholder="gg/mm/aaaa" Type="datetime-local">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="ddlNewSesso">Sesso</label>
                    <asp:DropDownList runat="server" ID="ddlNewSesso" CssClass="form-control">
                    </asp:DropDownList>
                </div>

                <asp:Button runat="server" ID="btnInsertCliente" Text="Inserisci" CssClass="btn btn-default " OnClick="btnInsertCliente_Click" />
                <asp:Button runat="server" ID="btnPulisci" Text="Nuovo Inserimento" CssClass="btn btn-default" OnClick="btnPulisci_Click" />

            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtNewIndirizzo">Indirizzo</label>
                    <asp:TextBox runat="server" ID="txtNewIndirizzo" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtNewCitta">Citta</label>
                    <asp:TextBox runat="server" ID="txtNewCitta" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtNewCap">Cap</label>
                    <asp:TextBox runat="server" ID="txtNewCap" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtNewEmail">Email</label>
                    <asp:TextBox runat="server" ID="txtNewEmail" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtNewTelefono">Telefono</label>
                    <asp:TextBox runat="server" ID="txtNewTelefono" CssClass="form-control">
                    </asp:TextBox>
                </div>
            </div>
        </asp:Panel>
    </asp:Panel>



</asp:Content>
