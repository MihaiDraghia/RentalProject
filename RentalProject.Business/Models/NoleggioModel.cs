using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Business.Models
{
    public class NoleggioModel
    {
        public int Id { get; set; }
        public int IdVeicolo { get; set; }
        public int IdCliente { get; set; }
        public string Note { get; set; }
        public DateTime? DataInizioNoleggio { get; set; }
        public DateTime? DataFineNoleggio { get; set; }
        public bool IsAttivo { get; set; }
    }

    public class DatiNonNoleggiato
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modello { get; set; }
        public string Targa { get; set; }

    }


}
