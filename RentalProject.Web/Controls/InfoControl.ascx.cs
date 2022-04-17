using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentalProject.Web.Controls
{
    public partial class InfoControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetMessage(TipoInfo tipoInfo, string testo)
        {
            this.panelInfo.Visible = true;
            var cssClass = "alert alert-primary";
            switch (tipoInfo)
            {
                case TipoInfo.Danger:
                    cssClass = "alert alert-danger";
                    break;
                case TipoInfo.Info:
                    cssClass = "alert alert-info";
                    break;
                case TipoInfo.Success:
                    cssClass = "alert alert-success";
                    break;
                case TipoInfo.Warning:
                    cssClass = "alert alert-warning";
                    break;
            }
            this.DescrizioneMessaggio.Text = testo;
            paragrafoInfo.Attributes["class"] = cssClass;
        }
        public enum TipoInfo
        {
            Info, Danger, Success, Warning
        }


    }
}