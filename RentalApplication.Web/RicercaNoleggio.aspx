<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RicercaNoleggio.aspx.cs" Inherits="RentalApplication.Web.RicercaNoleggio" %>

<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:Info runat="server" ID="infoControl" />

    <asp:Panel class="panel panel-default" runat="server" ID="pnlNoleggio">

        <asp:Panel class="panel-heading" runat="server" ID="pnlHeadNoleggio">
            <h3 class="panel-title">Cerca Noleggio</h3>
        </asp:Panel>

        <asp:Panel class="panel-body" runat="server">

            <div class="col-md-6">
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
                    <label for="txtDataInizioNoleggio">Data Inizio Ricerca  </label>
                    <asp:TextBox runat="server" ID="txtDataInizioNoleggio" CssClass="form-control" placeholder="gg/mm/aaaa" Type="datetime-local">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtDataFineNoleggio">Data Fine Ricerca  </label>
                    <asp:TextBox runat="server" ID="txtDataFineNoleggio" CssClass="form-control" placeholder="gg/mm/aaaa" Type="datetime-local">
                    </asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="ddlAttivo">Attivo </label>
                    <asp:DropDownList runat="server" ID="ddlAttivo" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <asp:Button runat="server" ID="btnRicerca" Text="Cerca" CssClass="btn btn-default" OnClick="btnRicerca_Click" />
            </div>
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
                    <label for="txtCF">Codice Fiscale </label>
                    <asp:TextBox runat="server" ID="txtCF" CssClass="form-control">
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



    <asp:GridView runat="server" ID="gvNoleggio" CssClass="table table-bordered table-hover table-striped no-margin" BorderStyle="None" AutoGenerateColumns="false">
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
            <asp:BoundField DataField="Marca" HeaderText="Marca">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Modello" HeaderText="Modello">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Targa" HeaderText="Targa">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="DataInizioNoleggio" HeaderText="DataInizioNoleggio" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="DataFineNoleggio" HeaderText="DataFineNoleggio" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="IsNoleggioAttivo" HeaderText="Noleggio Attivo ">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>


</asp:Content>
