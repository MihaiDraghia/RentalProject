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
    public partial class InsertVeicolo : System.Web.UI.Page
    {
        protected static VeicoloManager VeicoloManager { get; set; }
        protected static MarcaManager MarcaManager { get; set; }
        protected static AlimentazioneManager AlimentazioneManager { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlVeicolo.BackColor = Color.AliceBlue;

            if (IsPostBack)
            {
                return;
            }

            VeicoloManager = new VeicoloManager(Settings.Default.RENTALCONString);
            MarcaManager = new MarcaManager(Settings.Default.RENTALCONString);
            AlimentazioneManager = new AlimentazioneManager(Settings.Default.RENTALCONString);

            List<MarcaModel> marcaList = MarcaManager.GetMarcaList();
            ddlMarca.DataSource = marcaList;
            ddlMarca.DataTextField = nameof(MarcaModel.Descrizione);
            ddlMarca.DataValueField = nameof(MarcaModel.Id);
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Seleziona", "-1"));

            List<AlimentazioneModel> alimentazioneList = AlimentazioneManager.GetAlimentazioneList();
            ddlAlimentazione.DataSource = alimentazioneList;
            ddlAlimentazione.DataTextField = nameof(AlimentazioneModel.Descrizione);
            ddlAlimentazione.DataValueField = nameof(AlimentazioneModel.Id);
            ddlAlimentazione.DataBind();
            ddlAlimentazione.Items.Insert(0, new ListItem("Seleziona", "-1"));

        }

        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            var veicoloManager = new VeicoloManager(Settings.Default.RENTALCONString);

            if (!isFormInsertValido())
            {
                infoControl.SetMessage(InfoControl.TipoInfo.Danger, "Si è verificato un errore, assicurati di aver inserito i campi necessari ");
                return;
            }

            var veicoloModel = new VeicoloModel();

            veicoloModel.IdMarca = int.Parse(ddlMarca.SelectedValue);
            veicoloModel.Modello = txtModello.Text;
            veicoloModel.Targa = txtTarga.Text;
            if (DateTime.TryParse(txtDataImmatricolazione.Text, out DateTime txtDataImmatricolazioneDateTime))
            {
                veicoloModel.DataImmatricolazione = txtDataImmatricolazioneDateTime;
            }
            veicoloModel.IdAlimentazione = int.Parse(ddlAlimentazione.SelectedValue);
            veicoloModel.Note = txtNote.Text;

            var inserito = veicoloManager.InsertVeicolo(veicoloModel);

            if (!inserito)
            {
                infoControl.SetMessage(InfoControl.TipoInfo.Danger, "Internal Server Error ");
                return;
            }

            infoControl.SetMessage(InfoControl.TipoInfo.Success, "Veicolo inserito ");
        }

        protected bool isFormInsertValido()
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



    }
}

