using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Business.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string CodiceFiscale { get; set; }
        public DateTime? DataNascita { get; set; }
        public string Sesso { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string Cap { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int IdTipoStatus { get; set; }
        public DateTime? DataInserimento { get; set; }
        public DateTime? DataModifica { get; set; }

    }


}
