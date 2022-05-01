using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentalApplication.Web.Properties;
using RentalProject.Business.Managers;
using RentalProject.Business.Models;

namespace RentalApplication.Web
{
    public partial class RicercaNoleggio : System.Web.UI.Page
    {
        protected static NoleggioManager NoleggioManager { get; set; }
        protected static MarcaManager MarcaManager { get; set; }
        protected static List<NoleggioModelView> NoleggioViewList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlNoleggio.BackColor = Color.AliceBlue;
            gvNoleggio.BackColor = Color.AliceBlue;

            if (IsPostBack)
            {
                return;
            }

            MarcaManager = new MarcaManager(Settings.Default.RENTALCONString);
            NoleggioManager = new NoleggioManager(Properties.Settings.Default.RENTALCONString);

            List<MarcaModel> marcaList = MarcaManager.GetMarcaList();
            ddlMarca.DataSource = marcaList;
            ddlMarca.DataTextField = nameof(MarcaModel.Descrizione);
            ddlMarca.DataValueField = nameof(MarcaModel.Id);
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Seleziona", "-1"));


            ddlAttivo.Items.Insert(0, new ListItem("Seleziona", "-1"));
            ddlAttivo.Items.Insert(1, new ListItem("Si", "1"));
            ddlAttivo.Items.Insert(2, new ListItem("No", "0"));

        }


        protected void btnRicerca_Click(object sender, EventArgs e)
        {
            var ricercaNoleggio = new NoleggioManager.RicercaNoleggio();

            if (int.TryParse(ddlMarca.SelectedValue, out int ddlMarcaInt) && ddlMarcaInt > 0)
            {
                ricercaNoleggio.IdMarca = ddlMarcaInt;
            }

            if (!string.IsNullOrEmpty(txtModello.Text))
            {
                ricercaNoleggio.Modello = txtModello.Text;
            }

            if (!string.IsNullOrEmpty(txtTarga.Text))
            {
                ricercaNoleggio.Targa = txtTarga.Text;
            }

            if (!string.IsNullOrEmpty(txtDataInizioNoleggio.Text) && DateTime.TryParse(txtDataInizioNoleggio.Text, out DateTime txtDataInizioNoleggioDateTime))
            {
                ricercaNoleggio.DataInizioNoleggio = txtDataInizioNoleggioDateTime;
            }

            if (!string.IsNullOrEmpty(txtDataFineNoleggio.Text) && DateTime.TryParse(txtDataFineNoleggio.Text, out DateTime txtDataFineNoleggioDateTime))
            {
                ricercaNoleggio.DataFineNoleggio = txtDataFineNoleggioDateTime;
            }

            if (int.TryParse(ddlAttivo.SelectedValue, out int ddlAttivoInt) && (ddlAttivoInt.Equals(0) || ddlAttivoInt.Equals(1)))
            {
                ricercaNoleggio.IsAttivo = Convert.ToBoolean(ddlAttivoInt);
            }

            if (!string.IsNullOrEmpty(txtNome.Text))
            {
                ricercaNoleggio.Nome = txtNome.Text;
            }

            if (!string.IsNullOrEmpty(txtCognome.Text))
            {
                ricercaNoleggio.Cognome = txtCognome.Text;
            }

            if (!string.IsNullOrEmpty(txtCF.Text))
            {
                ricercaNoleggio.CodiceFiscale = txtCF.Text;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                ricercaNoleggio.Email = txtEmail.Text;
            }

            if (!string.IsNullOrEmpty(txtTelefono.Text))
            {
                ricercaNoleggio.Telefono = txtTelefono.Text;
            }


            NoleggioViewList = NoleggioManager.RicercaNoleggi(ricercaNoleggio);
            gvNoleggio.DataSource = NoleggioViewList;
            gvNoleggio.DataBind();

        }

        protected void gvNoleggio_PageIdxChanging(object sender, GridViewPageEventArgs e)
        {
            gvNoleggio.PageIndex = e.NewPageIndex;
            gvNoleggio.DataSource = NoleggioViewList;
            gvNoleggio.DataBind();

        }


        protected void btnPulisci_Click(object sender, EventArgs e)
        {
            ddlMarca.SelectedIndex = 0;
            txtModello.Text = String.Empty;
            txtTarga.Text = String.Empty;
            txtDataInizioNoleggio.Text = String.Empty;
            txtDataFineNoleggio.Text = String.Empty;
            ddlAttivo.SelectedIndex = 0;
            txtNome.Text = String.Empty;
            txtCognome.Text = String.Empty;
            txtCF.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            gvNoleggio.DataSource = null;
            gvNoleggio.DataBind();

        }


    }
}


