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
    public partial class DettaglioCliente : System.Web.UI.Page
    {
        protected static int IdCliente { get; set; }
        protected static ClienteManager ClienteManager { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlCliente.BackColor = Color.AliceBlue;

            if (IsPostBack)
            {
                return;
            }

            IdCliente = int.Parse(Request.QueryString["id"]);

            ClienteManager = new ClienteManager(Settings.Default.RENTALCONString);

            var clienteModel = ClienteManager.GetCliente(IdCliente);


            ddlSesso.Items.Insert(0, new ListItem("Seleziona", "-1"));
            ddlSesso.Items.Insert(1, new ListItem("Maschio", "M"));
            ddlSesso.Items.Insert(2, new ListItem("Femmina", "F"));


            if (!clienteModel.Sesso.Equals("M") && !clienteModel.Sesso.Equals("F"))
            {
                ddlSesso.SelectedIndex = 0;
            }

            else
            {
                ddlSesso.SelectedValue = clienteModel.Sesso;
            }

            txtNome.Text = clienteModel.Nome;
            txtCognome.Text = clienteModel.Cognome;
            txtCF.Text = clienteModel.CodiceFiscale;
            txtDataNascita.Text = Convert.ToDateTime(clienteModel.DataNascita).ToShortDateString();
            txtIndirizzo.Text = clienteModel.Indirizzo;
            txtCitta.Text = clienteModel.Citta;
            txtCap.Text = clienteModel.Cap;
            txtEmail.Text = clienteModel.Email;
            txtTelefono.Text = clienteModel.Telefono;

        }

        protected void btnModificaCliente_Click(object sender, EventArgs e)
        {

            if (!isFormUpdateClienteValido())
            {
                infoControl.SetMessage(InfoControl.TipoInfo.Danger, "Si è verificato un errore, verifica la completezza dei campi necessari ");
                return;
            }

            var clienteModel = new ClienteModel();

            clienteModel.Id = IdCliente;
            clienteModel.Nome = txtNome.Text;
            clienteModel.Cognome = txtCognome.Text;
            clienteModel.CodiceFiscale = txtCF.Text;
            clienteModel.Sesso = ddlSesso.SelectedValue;

            if (DateTime.TryParse(txtDataNascita.Text, out DateTime txtDataNascitaDateTime))
            {
                clienteModel.DataNascita = txtDataNascitaDateTime;
            }

            clienteModel.Indirizzo = txtIndirizzo.Text;
            clienteModel.Citta = txtCitta.Text;
            clienteModel.Cap = txtCap.Text;
            clienteModel.Email = txtEmail.Text;
            clienteModel.Telefono = txtTelefono.Text;

            var modificato = ClienteManager.UpdateCliente(clienteModel);

            if (!modificato)
            {
                infoControl.SetMessage(InfoControl.TipoInfo.Danger, "Internal Server Error ");
                return;
            }

            infoControl.SetMessage(InfoControl.TipoInfo.Success, "Modifica dati Cliente effettuata ");

        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            var eliminato = ClienteManager.EliminaCliente(IdCliente);

            if (!eliminato)
            {
                infoControl.SetMessage(InfoControl.TipoInfo.Danger, "Internal Server Error ");
                return;
            }

            infoControl.SetMessage(InfoControl.TipoInfo.Success, "Cliente eliminato ");


            btnElimina.Visible = false;
            btnModificaCliente.Visible = false;

        }

        protected bool isFormUpdateClienteValido()
        {
            bool verificaCorrettezza = true;

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                txtNome.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtNome.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtCognome.Text))
            {
                txtCognome.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtCognome.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtCF.Text))
            {
                txtCF.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtCF.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtDataNascita.Text) || !DateTime.TryParse(txtDataNascita.Text, out DateTime txtDataNascitaDateTime) || txtDataNascitaDateTime > DateTime.Now || txtDataNascitaDateTime < DateTime.Parse("01/01/1900"))
            {
                txtDataNascita.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtDataNascita.BorderColor = Color.LightGray;
            }


            if (ddlSesso.SelectedValue != "M" && ddlSesso.SelectedValue != "F")
            {
                ddlSesso.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                ddlSesso.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtIndirizzo.Text))
            {
                txtIndirizzo.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtIndirizzo.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtCitta.Text))
            {
                txtCitta.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtCitta.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtCap.Text))
            {
                txtCap.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtCap.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtEmail.BorderColor = Color.LightGray;
            }


            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                txtTelefono.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtTelefono.BorderColor = Color.LightGray;
            }

            return verificaCorrettezza;
        }

    }
}


