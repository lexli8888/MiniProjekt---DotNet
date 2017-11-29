using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.Dal
{
    public class Kunde
    {
        public string Nachname { get; set; }
        public int Id { get; set; }
        public string Vorname { get; set; }
        public DateTime Geburtstag { get; set; }

        public ICollection<Reservation> Reservationen { get; set; }

    }
}
