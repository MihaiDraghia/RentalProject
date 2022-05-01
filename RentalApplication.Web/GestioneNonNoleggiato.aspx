<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestioneNonNoleggiato.aspx.cs" Inherits="RentalApplication.Web.GestioneNonNoleggiato" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:Info runat="server" ID="infoControl" />

    <asp:Panel class="panel panel-default" runat="server" ID="pnlNonNoleggiato">

        <asp:Panel class="panel-heading" runat="server" ID="pnlHeadNonNoleggiato">
            <h3 class="panel-title">Nuovo Noleggio</h3>
        </asp:Panel>

        <asp:Panel class="panel-body" runat="server">
            <div class="form-group">
                <label for="txtMarca">Marca</label>
                <asp:TextBox runat="server" ID="txtMarca" CssClass="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtModello">Modello</label>
                <asp:TextBox runat="server" ID="txtModello" CssClass="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtTarga">Targa</label>
                <asp:TextBox runat="server" ID="txtTarga" CssClass="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>

            <asp:Button runat="server" ID="btnModNuovaPersona" Text="Nuovo Cliente" CssClass="btn btn-default" OnClick="btnModNuovaPersona_Click" />
            <asp:Button runat="server" ID="btnModRicercaPersona" Text="Cerca Cliente" CssClass="btn btn-default" OnClick="btnModRicercaPersona_Click" />
            <asp:Button runat="server" ID="btnInsertNoleggio" Text="Noleggia" CssClass="btn btn-default " OnClick="btnInsertNoleggio_Click" />
        </asp:Panel>
    </asp:Panel>

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
        </asp:Panel>
    </asp:Panel>


    <asp:GridView runat="server" ID="gvCercaPersona" CssClass="table table-bordered table-hover table-striped no-margin" BorderStyle="None" AutoGenerateColumns="false" OnSelectedIndexChanged="gvCercaPersona_SelectedIndexChanged" DataKeyNames="Id" AutoGenerateSelectButton="true" AllowPaging="True" PageSize="10" OnPageIndexChanging="gvCercaPersona_PageIdxChanging">
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
