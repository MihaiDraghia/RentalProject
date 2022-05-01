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
    public partial class GestioneNoleggiato : System.Web.UI.Page
    {

        protected static int IdVeicolo { get; set; }
        protected static int IdNoleggio { get; set; }
        protected static NoleggioManager NoleggioManager { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlNoleggiato.BackColor = Color.AliceBlue;

            if (IsPostBack)
            {
                return;
            }

            IdVeicolo = int.Parse(Request.QueryString["id"]);

            NoleggioManager = new NoleggioManager(Settings.Default.RENTALCONString);

            var datiNoleggiato = new NoleggioModelView();

            datiNoleggiato = NoleggioManager.GetNoleggioModelView(IdVeicolo);

            txtMarca.Text = datiNoleggiato.Marca;
            txtModello.Text = datiNoleggiato.Modello;
            txtTarga.Text = datiNoleggiato.Targa;
            txtNome.Text = datiNoleggiato.Nome;
            txtCognome.Text = datiNoleggiato.Cognome;
            txtCF.Text = datiNoleggiato.CodiceFiscale;
            txtEmail.Text = datiNoleggiato.Email;
            txtTelefono.Text = datiNoleggiato.Telefono;
            txtDataInizioNoleggio.Text = datiNoleggiato.DataInizioNoleggio.ToString();

            IdNoleggio = datiNoleggiato.IdNoleggio;

        }

        protected void btnFineNoleggio_Click(object sender, EventArgs e)
        {
            bool isRiuscito = NoleggioManager.TransactionFineNoleggio(IdNoleggio, IdVeicolo);

            if (isRiuscito)
            {
                infoControl.SetMessage(InfoControl.TipoInfo.Success, "Noleggio terminato ");

                btnFineNoleggio.Visible = false;
            }

            else
            {
                infoControl.SetMessage(InfoControl.TipoInfo.Danger, "Internal Server Error ");
            }



        }

    }
}

