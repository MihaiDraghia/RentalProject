using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Business.Models
{
    public class VeicoloModel
    {
        public int Id { get; set; }
        public int IdMarca { get; set; }
        public string Modello { get; set; }
        public string Targa { get; set; }
        public DateTime? DataImmatricolazione { get; set; }
        public int IdAlimentazione { get; set; }
        public string Note { get; set; }
        public bool IsNoleggiato { get; set; }
        public int IdTipoStatus { get; set; }
    }

    public class VeicoloModelView
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modello { get; set; }
        public string Targa { get; set; }
        public DateTime? DataImmatricolazione { get; set; }
        public bool IsNoleggiato { get; set; }
        public int IdTipoStatus { get; set; }
    }


}
