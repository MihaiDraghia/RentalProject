using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentalProject.Business.Managers;
using RentalProject.Business.Models;
using RentalProject.Web.Properties;

namespace RentalProject.Web
{
    public partial class InsertVeicolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            var veicoloManager = new VeicoloManager(Settings.Default.RENTALCONString);
            var marcaManager = new MarcaManager(Settings.Default.RENTALCONString);
            var alimentazioneManager = new AlimentazioneManager(Settings.Default.RENTALCONString);

            List<MarcaModel> marcaList = marcaManager.GetMarcaList();
            ddlMarca.DataSource = marcaList;
            ddlMarca.DataTextField = nameof(MarcaModel.Descrizione);
            ddlMarca.DataValueField = nameof(MarcaModel.Id);
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Seleziona", "-1"));

            List<AlimentazioneModel> alimentazioneList = alimentazioneManager.GetAlimentazioneList();
            ddlAlimentazione.DataSource = alimentazioneList;
            ddlAlimentazione.DataTextField = nameof(AlimentazioneModel.Descrizione);
            ddlAlimentazione.DataValueField = nameof(AlimentazioneModel.Id);
            ddlAlimentazione.DataBind();
            ddlAlimentazione.Items.Insert(0, new ListItem("Seleziona", "-1"));

        }

        protected void btnInserisci_Click(object sender, EventArgs e)
        {


        }





    }
}