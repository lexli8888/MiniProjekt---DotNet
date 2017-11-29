using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.Dal
{
    public class Reservation
    {
        public int AutoId { get; set; }
        public int KundeId { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }

        public int ReservationsNr { get; set; }

        public Auto Auto { get; set; }
        public Kunde Kunde { get; set; }
    }
}
