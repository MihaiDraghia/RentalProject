<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DettaglioCliente.aspx.cs" Inherits="RentalApplication.Web.DettaglioCliente" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:Info runat="server" ID="infoControl" />

    <asp:Panel class="panel panel-default" runat="server" ID="pnlCliente">

        <asp:Panel class="panel-heading" runat="server" ID="pnlHeadCliente">
            <h3 class="panel-title">Dettagli Cliente</h3>
        </asp:Panel>

        <asp:Panel class="panel-body" runat="server">

            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtNome">Nome</label>
                    <asp:TextBox runat="server" ID="txtNome" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtCognome">Cognome</label>
                    <asp:TextBox runat="server" ID="txtCognome" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtCF">Codice Fiscale</label>
                    <asp:TextBox runat="server" ID="txtCF" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtDataNascita">Data Nascita</label>
                    <asp:TextBox runat="server" ID="txtDataNascita" CssClass="form-control" placeholder="gg/mm/aaaa">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="ddlSesso">Sesso</label>
                    <asp:DropDownList runat="server" ID="ddlSesso" CssClass="form-control">
                    </asp:DropDownList>
                </div>

                <asp:Button runat="server" ID="btnModificaCliente" Text="Modifica" CssClass="btn btn-default " OnClick="btnModificaCliente_Click" />
                <asp:Button runat="server" ID="btnElimina" Text="Elimina" CssClass="btn btn-default" OnClick="btnElimina_Click" />

            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtIndirizzo">Indirizzo</label>
                    <asp:TextBox runat="server" ID="txtIndirizzo" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtCitta">Citta</label>
                    <asp:TextBox runat="server" ID="txtCitta" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtCap">Cap</label>
                    <asp:TextBox runat="server" ID="txtCap" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtEmail">Email</label>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtTelefono">Telefono</label>
                    <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control">
                    </asp:TextBox>
                </div>
            </div>
        </asp:Panel>
    </asp:Panel>




</asp:Content>
