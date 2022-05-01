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
    public partial class RicercaCliente : System.Web.UI.Page
    {
        protected static ClienteManager ClienteManager { get; set; }
        protected static List<ClienteModel> ClienteModelList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlCercaPersona.BackColor = Color.AliceBlue;
            gvCercaPersona.BackColor = Color.AliceBlue;

            if (IsPostBack)
            {
                return;
            }

            ClienteManager = new ClienteManager(Settings.Default.RENTALCONString);

        }

        protected void btnCercaPersona_Click(object sender, EventArgs e)
        {
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

        protected void gvCercaPersona_PageIdxChanging(object sender, GridViewPageEventArgs e)
        {
            gvCercaPersona.PageIndex = e.NewPageIndex;
            gvCercaPersona.DataSource = ClienteModelList;
            gvCercaPersona.DataBind();
        }


        protected void btnPulisci_Click(object sender, EventArgs e)
        {
            txtCercaNome.Text = String.Empty;
            txtCercaCognome.Text = String.Empty;
            txtCercaCF.Text = String.Empty;
            txtCercaEmail.Text = String.Empty;
            txtCercaTelefono.Text = String.Empty;
            gvCercaPersona.DataSource = null;
            gvCercaPersona.DataBind();

        }


        protected void gvCercaPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idCliente = gvCercaPersona.SelectedDataKey["Id"].ToString();

            Response.Redirect("~/DettaglioCliente.aspx" + $"?id={idCliente}");
        }
    }
}


