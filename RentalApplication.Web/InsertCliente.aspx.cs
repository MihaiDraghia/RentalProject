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
    public partial class InsertCliente : System.Web.UI.Page
    {
        protected static ClienteManager ClienteManager { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlNuovaPersona.BackColor = Color.AliceBlue;

            if (IsPostBack)
            {
                return;
            }

            ClienteManager = new ClienteManager(Settings.Default.RENTALCONString);

            ddlNewSesso.Items.Insert(0, new ListItem("Seleziona", "-1"));
            ddlNewSesso.Items.Insert(1, new ListItem("Maschio", "M"));
            ddlNewSesso.Items.Insert(2, new ListItem("Femmina", "F"));

        }

        protected void btnInsertCliente_Click(object sender, EventArgs e)
        {
            infoControl.Visible = true;

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

            var isRiuscito = ClienteManager.InsertClienteGetId(clienteModel);

            if (isRiuscito.HasValue)
            {
                infoControl.SetMessage(InfoControl.TipoInfo.Success, "Cliente Inserito ");

            }

            else
            {
                infoControl.SetMessage(InfoControl.TipoInfo.Danger, "Internal Server Error ");
            }

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

        protected void btnPulisci_Click(object sender, EventArgs e)
        {
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

            infoControl.Visible = false;
        }


    }
}


