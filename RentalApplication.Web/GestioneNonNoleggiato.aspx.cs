using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentalApplication.Web.Controls;
using RentalApplication.Web.Properties;
using RentalProject.Business.Managers;
using RentalProject.Business.Models;

namespace RentalApplication.Web
{
    public partial class GestioneNonNoleggiato : System.Web.UI.Page
    {
        protected static int IdVeicolo { get; set; }
        protected static int IdClienteCercato { get; set; }
        protected static NoleggioManager NoleggioManager { get; set; }
        protected static ClienteManager ClienteManager { get; set; }
        protected static VeicoloManager VeicoloManager { get; set; }
        protected static List<ClienteModel> ClienteModelList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlCercaPersona.BackColor = Color.AliceBlue;
            pnlNonNoleggiato.BackColor = Color.AliceBlue;
            pnlNuovaPersona.BackColor = Color.AliceBlue;
            gvCercaPersona.BackColor = Color.AliceBlue;
            btnInsertNoleggio.BorderColor = Color.CornflowerBlue;

            if (IsPostBack)
            {
                return;
            }

            IdVeicolo = int.Parse(Request.QueryString["id"]);
            NoleggioManager = new NoleggioManager(Settings.Default.RENTALCONString);
            ClienteManager = new ClienteManager(Settings.Default.RENTALCONString);
            VeicoloManager = new VeicoloManager(Settings.Default.RENTALCONString);

            var veicoloModelView = VeicoloManager.GetVeicoloModelView(IdVeicolo);

            txtMarca.Text = veicoloModelView.Marca;
            txtModello.Text = veicoloModelView.Modello;
            txtTarga.Text = veicoloModelView.Targa;

            ddlNewSesso.Items.Insert(0, new ListItem("Seleziona", "-1"));
            ddlNewSesso.Items.Insert(1, new ListItem("Maschio", "M"));
            ddlNewSesso.Items.Insert(2, new ListItem("Femmina", "F"));

            btnModNuovaPersona.Visible = true;
            btnModRicercaPersona.Visible = true;
            btnInsertNoleggio.Visible = false;
            pnlNuovaPersona.Visible = false;
            pnlCercaPersona.Visible = false;
            gvCercaPersona.Visible = false;
        }

        protected void btnModNuovaPersona_Click(object sender, EventArgs e)
        {
            btnInsertNoleggio.Visible = true;
            pnlNuovaPersona.Visible = true;
            pnlCercaPersona.Visible = false;
            gvCercaPersona.Visible = false;

            infoControl.Visible = false;

            txtNewNome.Text = String.Empty;
            txtNewCognome.Text = String.Empty;
            txtNewCF.Text = String.Empty;
            txtNewDataNascita.Text = String.Empty;
            ddlNewSesso.SelectedIndex = 0;
            txtNewIndirizzo.Text = String.Empty;
            txtNewCitta.Text = String.Empty;
            txtNewCap.Text = String.Empty;
            txtNewEmail.Text = String.Empty;
            txtNewTelefono.Text = String.Empty;

            txtNewNome.BorderColor = Color.LightGray;
            txtNewCognome.BorderColor = Color.LightGray;
            txtNewCF.BorderColor = Color.LightGray;
            txtNewDataNascita.BorderColor = Color.LightGray;
            ddlNewSesso.BorderColor = Color.LightGray;
            txtNewIndirizzo.BorderColor = Color.LightGray;
            txtNewCitta.BorderColor = Color.LightGray;
            txtNewCap.BorderColor = Color.LightGray;
            txtNewEmail.BorderColor = Color.LightGray;
            txtNewTelefono.BorderColor = Color.LightGray;

        }

        protected void btnModRicercaPersona_Click(object sender, EventArgs e)
        {
            btnInsertNoleggio.Visible = false;
            pnlNuovaPersona.Visible = false;
            pnlCercaPersona.Visible = true;
            gvCercaPersona.Visible = false;
            btnCercaPersona.Visible = true;

            txtCercaNome.ReadOnly = false;
            txtCercaCognome.ReadOnly = false;
            txtCercaCF.ReadOnly = false;
            txtCercaEmail.ReadOnly = false;
            txtCercaTelefono.ReadOnly = false;

            infoControl.Visible = false;

            txtCercaNome.Text = String.Empty;
            txtCercaCognome.Text = String.Empty;
            txtCercaCF.Text = String.Empty;
            txtCercaEmail.Text = String.Empty;
            txtCercaTelefono.Text = String.Empty;

        }

        protected void btnCercaPersona_Click(object sender, EventArgs e)
        {
            gvCercaPersona.Visible = true;
            btnCercaPersona.Visible = true;

            var ricercaCliente = new ClienteManager.RicercaCliente();

            ricercaCliente.Nome = txtCercaNome.Text;
            ricercaCliente.Cognome = txtCercaCognome.Text;
            ricercaCliente.CodiceFiscale = txtCercaCF.Text;
            ricercaCliente.Email = txtCercaEmail.Text;
            ricercaCliente.Telefono = txtCercaTelefono.Text;

            ClienteModelList = ClienteManager.RicercaClienti(ricercaCliente);
            gvCercaPersona.DataSource = ClienteModelList;
            gvCercaPersona.DataBind();

        }

        protected void btnInsertNoleggio_Click(object sender, EventArgs e)
        {
            infoControl.Visible = true;

            if (pnlNuovaPersona.Visible.Equals(true))
            {
                if (!isFormInsertClienteValido())
                {
                    infoControl.SetMessage(InfoControl.TipoInfo.Danger, "Si è verificato un errore, assicurati di aver inserito i campi necessari ");
                    return;
                }

                var clienteModel = new ClienteModel();

                clienteModel.Nome = txtNewNome.Text;
                clienteModel.Cognome = txtNewCognome.Text;
                clienteModel.CodiceFiscale = txtNewCF.Text;
                if (DateTime.TryParse(txtNewDataNascita.Text, out DateTime txtNewDataNascitaDateTime))
                {
                    clienteModel.DataNascita = txtNewDataNascitaDateTime;
                }
                clienteModel.Sesso = ddlNewSesso.SelectedValue.ToString();
                clienteModel.Indirizzo = txtNewIndirizzo.Text;
                clienteModel.Citta = txtNewCitta.Text;
                clienteModel.Cap = txtNewCap.Text;
                clienteModel.Email = txtNewEmail.Text;
                clienteModel.Telefono = txtNewTelefono.Text;


                bool isRiuscito = NoleggioManager.TransactionNoleggioNewCliente(clienteModel, IdVeicolo);

                if (isRiuscito)
                {
                    infoControl.SetMessage(InfoControl.TipoInfo.Success, "Noleggio effettuato ");
                    btnModNuovaPersona.Visible = false;
                    btnModRicercaPersona.Visible = false;
                    btnInsertNoleggio.Visible = false;
                }

                else
                {
                    infoControl.SetMessage(InfoControl.TipoInfo.Danger, "Internal Server Error ");
                }

            }

            else if (pnlCercaPersona.Visible.Equals(true))
            {


                bool isRiuscito = NoleggioManager.TransactionNoleggioClienteEsistente(IdClienteCercato, IdVeicolo);

                if (isRiuscito)
                {
                    infoControl.SetMessage(InfoControl.TipoInfo.Success, "Noleggio effettuato ");
                    btnModNuovaPersona.Visible = false;
                    btnModRicercaPersona.Visible = false;
                    btnInsertNoleggio.Visible = false;
                }

                else
                {
                    infoControl.SetMessage(InfoControl.TipoInfo.Danger, "Internal Server Error ");
                }

            }
        }

        protected void gvCercaPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnInsertNoleggio.Visible = true;
            gvCercaPersona.Visible = false;
            btnCercaPersona.Visible = false;

            txtCercaNome.ReadOnly = true;
            txtCercaCognome.ReadOnly = true;
            txtCercaCF.ReadOnly = true;
            txtCercaEmail.ReadOnly = true;
            txtCercaTelefono.ReadOnly = true;

            infoControl.Visible = true;

            var idCliente = gvCercaPersona.SelectedDataKey["Id"].ToString();

            var clienteModel = ClienteManager.GetCliente(int.Parse(idCliente));

            txtCercaNome.Text = clienteModel.Nome;
            txtCercaCognome.Text = clienteModel.Cognome;
            txtCercaCF.Text = clienteModel.CodiceFiscale;
            txtCercaEmail.Text = clienteModel.Email;
            txtCercaTelefono.Text = clienteModel.Telefono;

            IdClienteCercato = int.Parse(idCliente);

            infoControl.SetMessage(InfoControl.TipoInfo.Info, "Cliente Selezionato, è possibile procedere al Noleggio ");

        }

        protected bool isFormInsertClienteValido()
        {
            bool verificaCorrettezza = true;

            if (string.IsNullOrWhiteSpace(txtNewNome.Text))
            {
                txtNewNome.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtNewNome.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtNewCognome.Text))
            {
                txtNewCognome.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtNewCognome.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtNewCF.Text))
            {
                txtNewCF.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtNewCF.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtNewDataNascita.Text) || !DateTime.TryParse(txtNewDataNascita.Text, out DateTime txtNewDataNascitaDateTime) || txtNewDataNascitaDateTime > DateTime.Now || txtNewDataNascitaDateTime < DateTime.Parse("01/01/1900"))
            {
                txtNewDataNascita.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtNewDataNascita.BorderColor = Color.LightGray;
            }


            if (ddlNewSesso.SelectedValue != "M" && ddlNewSesso.SelectedValue != "F")
            {
                ddlNewSesso.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                ddlNewSesso.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtNewIndirizzo.Text))
            {
                txtNewIndirizzo.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtNewIndirizzo.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtNewCitta.Text))
            {
                txtNewCitta.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtNewCitta.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtNewCap.Text))
            {
                txtNewCap.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtNewCap.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtNewEmail.Text))
            {
                txtNewEmail.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtNewEmail.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtNewTelefono.Text))
            {
                txtNewTelefono.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtNewTelefono.BorderColor = Color.LightGray;
            }

            return verificaCorrettezza;
        }


        protected void gvCercaPersona_PageIdxChanging(object sender, GridViewPageEventArgs e)
        {
            gvCercaPersona.PageIndex = e.NewPageIndex;
            gvCercaPersona.DataSource = ClienteModelList;
            gvCercaPersona.DataBind();
        }
    }
}

