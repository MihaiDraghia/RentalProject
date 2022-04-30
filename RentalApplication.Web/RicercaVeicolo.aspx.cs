using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentalApplication.Web.Properties;
using RentalProject.Business.Managers;
using RentalProject.Business.Models;

namespace RentalApplication.Web
{
    public partial class RicercaVeicolo : System.Web.UI.Page
    {
        protected static VeicoloManager VeicoloManager { get; set; }
        protected static MarcaManager MarcaManager { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlVeicolo.BackColor = Color.AliceBlue;
            gvVeicolo.BackColor = Color.AliceBlue;

            if (IsPostBack)
            {
                return;
            }

            MarcaManager = new MarcaManager(Settings.Default.RENTALCONString);
            VeicoloManager = new VeicoloManager(Properties.Settings.Default.RENTALCONString);

            List<MarcaModel> marcaList = MarcaManager.GetMarcaList();
            ddlMarca.DataSource = marcaList;
            ddlMarca.DataTextField = nameof(MarcaModel.Descrizione);
            ddlMarca.DataValueField = nameof(MarcaModel.Id);
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Seleziona", "-1"));

            ddlNoleggiato.Items.Insert(0, new ListItem("Seleziona", "-1"));
            ddlNoleggiato.Items.Insert(1, new ListItem("Si", "1"));
            ddlNoleggiato.Items.Insert(2, new ListItem("No", "0"));

        }

        protected void btnRicerca_Click(object sender, EventArgs e)
        {

            var ricercaVeicolo = new VeicoloManager.RicercaVeicolo();

            if (int.TryParse(ddlMarca.SelectedValue.ToString(), out int ddlMarcaInt) && ddlMarcaInt > 0)
            {
                ricercaVeicolo.IdMarca = ddlMarcaInt;
            }

            if (!string.IsNullOrEmpty(txtModello.Text))
            {
                ricercaVeicolo.Modello = txtModello.Text;
            }

            if (!string.IsNullOrEmpty(txtTarga.Text))
            {
                ricercaVeicolo.Targa = txtTarga.Text;
            }

            if (!string.IsNullOrEmpty(txtDataImmatricolazioneInizio.Text) && DateTime.TryParse(txtDataImmatricolazioneInizio.Text, out DateTime dataImmInizioDateTime))
            {
                ricercaVeicolo.DataImmatricolazioneInizio = dataImmInizioDateTime;
            }

            if (!string.IsNullOrEmpty(txtDataImmatricolazioneFine.Text) && DateTime.TryParse(txtDataImmatricolazioneFine.Text, out DateTime dataImmFineDateTime))
            {
                ricercaVeicolo.DataImmatricolazioneFine = dataImmFineDateTime;
            }

            if (int.TryParse(ddlNoleggiato.SelectedValue.ToString(), out int ddlNoleggiatoInt) && (ddlNoleggiatoInt.Equals(0) || ddlNoleggiatoInt.Equals(1)))
            {
                ricercaVeicolo.IsNoleggiato = Convert.ToBoolean(ddlNoleggiatoInt);
            }

            List<VeicoloModelView> veicoloList = VeicoloManager.RicercaVeicoli(ricercaVeicolo);
            gvVeicolo.DataSource = veicoloList;
            gvVeicolo.DataBind();

        }

        protected void gvVeicolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idVeicolo = gvVeicolo.SelectedDataKey["Id"].ToString();

            Response.Redirect("~/DettaglioVeicolo.aspx" + $"?id={idVeicolo}");
        }

        protected void btnPulisci_Click(object sender, EventArgs e)
        {
            ddlMarca.SelectedIndex = 0;
            txtModello.Text = String.Empty;
            txtTarga.Text = String.Empty;
            txtDataImmatricolazioneInizio.Text = String.Empty;
            txtDataImmatricolazioneFine.Text = String.Empty;
            ddlNoleggiato.SelectedIndex = 0;
            gvVeicolo.DataSource = null;
            gvVeicolo.DataBind();

        }


    }
}

