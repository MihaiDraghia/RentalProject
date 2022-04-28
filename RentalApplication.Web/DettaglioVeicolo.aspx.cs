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
    public partial class DettaglioVeicolo : System.Web.UI.Page
    {
        public static int Id { get; set; }
        public static bool IsNoleggiato { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlVeicolo.BackColor = Color.AliceBlue;

            if (IsPostBack)
            {
                return;
            }

            Id = int.Parse(Request.QueryString["id"]);

            var veicoloManager = new VeicoloManager(Settings.Default.RENTALCONString);
            var marcaManager = new MarcaManager(Settings.Default.RENTALCONString);
            var alimentazioneManager = new AlimentazioneManager(Settings.Default.RENTALCONString);
            var noleggioManager = new NoleggioManager(Settings.Default.RENTALCONString);


            var veicoloModel = veicoloManager.GetVeicoloById(Id);

            IsNoleggiato = veicoloModel.IsNoleggiato;

            List<MarcaModel> marcaList = marcaManager.GetMarcaList();
            ddlMarca.DataSource = marcaList;
            ddlMarca.DataTextField = nameof(MarcaModel.Descrizione);
            ddlMarca.DataValueField = nameof(MarcaModel.Id);
            ddlMarca.DataBind();

            if (veicoloModel.IdMarca <= 0)
            {
                ddlMarca.Items.Insert(0, new ListItem("Seleziona", "-1"));
            }

            else
            {
                ddlMarca.SelectedValue = veicoloModel.IdMarca.ToString();
            }

            txtModello.Text = veicoloModel.Modello;
            txtTarga.Text = veicoloModel.Targa;
            txtDataImmatricolazione.Text = veicoloModel.DataImmatricolazione.ToString();

            List<AlimentazioneModel> alimentazioneList = alimentazioneManager.GetAlimentazioneList();
            ddlAlimentazione.DataSource = alimentazioneList;
            ddlAlimentazione.DataTextField = nameof(AlimentazioneModel.Descrizione);
            ddlAlimentazione.DataValueField = nameof(AlimentazioneModel.Id);
            ddlAlimentazione.DataBind();

            if (veicoloModel.IdAlimentazione <= 0)
            {
                ddlAlimentazione.Items.Insert(0, new ListItem("Seleziona", "-1"));
            }

            else
            {
                ddlAlimentazione.SelectedValue = veicoloModel.IdAlimentazione.ToString();
            }

            txtNote.Text = veicoloModel.Note;
            txtNoleggiato.Text = veicoloModel.IsNoleggiato.ToString();

            if (veicoloModel.IsNoleggiato.Equals(true))
            {
                lblCliente.Visible = true;
                txtCliente.Visible = true;
                txtCliente.Text = noleggioManager.GetNomeNoleggiatoreByIdVeicolo(Id);
            }
            else
            {
                lblCliente.Visible = false;
                txtCliente.Visible = false;
            }

            if (veicoloModel.IsNoleggiato.Equals(true))
            {
                btnElimina.Enabled = false;
            }
            else
            {
                btnElimina.Enabled = true;
            }

        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            var veicoloManager = new VeicoloManager(Settings.Default.RENTALCONString);

            if (!isFormUpdateValido())
            {
                infoControl.SetMessage(InfoControl.TipoInfo.Danger, "Errore modifica veicolo ");
                return;
            }

            var veicoloModel = new VeicoloModel();

            veicoloModel.Id = Id;
            veicoloModel.IdMarca = int.Parse(ddlMarca.SelectedValue);
            veicoloModel.Modello = txtModello.Text;
            veicoloModel.Targa = txtTarga.Text;
            if (DateTime.TryParse(txtDataImmatricolazione.Text, out DateTime txtDataImmatricolazioneDateTime))
            {
                veicoloModel.DataImmatricolazione = txtDataImmatricolazioneDateTime;
            }
            veicoloModel.IdAlimentazione = int.Parse(ddlAlimentazione.SelectedValue);
            veicoloModel.Note = txtNote.Text;

            var modificato = veicoloManager.UpdateVeicolo(veicoloModel);

            if (!modificato)
            {
                infoControl.SetMessage(InfoControl.TipoInfo.Danger, "Errore modifica veicolo ");
                return;
            }

            infoControl.SetMessage(InfoControl.TipoInfo.Success, "Veicolo modificato ");
        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            var veicoloManager = new VeicoloManager(Settings.Default.RENTALCONString);

            var eliminato = veicoloManager.EliminaVeicolo(Id);

            if (!eliminato)
            {
                infoControl.SetMessage(InfoControl.TipoInfo.Danger, "Errore eliminazione veicolo ");
                return;
            }

            infoControl.SetMessage(InfoControl.TipoInfo.Success, "Veicolo eliminato ");

        }

        protected bool isFormUpdateValido()
        {
            bool verificaCorrettezza = true;

            if (!int.TryParse(ddlMarca.SelectedValue, out int idMarcaInt) || idMarcaInt <= 0)
            {
                ddlMarca.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                ddlMarca.BorderColor = Color.LightGray;
            }

            if (string.IsNullOrWhiteSpace(txtModello.Text))
            {
                txtModello.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtModello.BorderColor = Color.LightGray;
            }

            if (string.IsNullOrWhiteSpace(txtTarga.Text))
            {
                txtTarga.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtTarga.BorderColor = Color.LightGray;
            }

            if (string.IsNullOrWhiteSpace(txtDataImmatricolazione.Text) || !DateTime.TryParse(txtDataImmatricolazione.Text, out DateTime txtDataImmatricolazioneDateTime) || txtDataImmatricolazioneDateTime > DateTime.Now || txtDataImmatricolazioneDateTime < DateTime.Parse("01/01/1900"))
            {
                txtDataImmatricolazione.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtDataImmatricolazione.BorderColor = Color.LightGray;
            }

            if (!int.TryParse(ddlAlimentazione.SelectedValue, out int idAlimentazioneInt) || idAlimentazioneInt <= 0)
            {
                ddlAlimentazione.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                ddlAlimentazione.BorderColor = Color.LightGray;
            }

            if (string.IsNullOrWhiteSpace(txtNote.Text))
            {
                txtNote.BorderColor = Color.Crimson;
                verificaCorrettezza = false;
            }
            else
            {
                txtNote.BorderColor = Color.LightGray;
            }

            return verificaCorrettezza;
        }

        protected void btnGestisciNoleggio_Click(object sender, EventArgs e)
        {
            if (IsNoleggiato.Equals(true))
            {
                Response.Redirect("~/GestioneNoleggiato.aspx" + $"?id={Id}");

            }
            else
            {
                Response.Redirect("~/GestioneNonNoleggiato.aspx" + $"?id={Id}");

            }
        }

    }
}

