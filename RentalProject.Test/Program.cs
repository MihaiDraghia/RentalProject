using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalProject.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //mettere anche minuti su gvNoleggi
            //campo ultimo ...disponibilita attuale veicolo?

            //btn pulisci ricerca su cercaNoleggi
            //rivere query ...isNoleggioAttivo...?

            //fare cercaNoleggio
            //allow paging=true , size=10, ...selectIndexAllow...? sito web di lorenzo 
            //gvNoleggi selectIndexCheìanged porta a GestioneNoleggiato... redirect passare idCliente...

            //cambiare cerca ..range temporale ..passare a  inizio data immatricolazione e fine data immatricolazione?... cambio query e scritta su html data immatricolazione inizio
            //e levare tryParse...


            //noleggioModelView
            //classe RicercaNoleggio in NoleggioManager , query RicercaNoleggio(ricercaNoleggio)...order by dataInizioNoleggio
            //pagina ricercaNoleggio

            //scegliere anche dataInserimento nella query ricerca e desc order by dataInserimento?
            //togliere try parse query ricerca...
            //cerca noleggio... pagina e query, order by desc dataInizioNoleggio (ordinato dal più recente?)
            //singleton
            //impaginazione
            //veicoloControl con btn avanti indietro?

            //3 parte home... Ricerca Noleggio...
            //4 parte home.. Info Parco Auto? veicoli totali, veicoli attivi, veicoli disattivi, veicoli noleggiati...

            //5 parte home inserisci cliente con btnInsertCliente
            //6 parte home cerca cliente ..gvCliente selectIndexChanged...dat Cliente con btnModifica , elimina se non ha noleggi attivi..?


            //cancello commenti test
        }
    }
}
