using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoReservation.Dal.Entities
{
    public class Reservation
    {
        public DateTime RowVersion;
        
        public int AutoId { get; set; }
        public int KundeId { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }

        [Key]
        public int ReservationsNr { get; set; }

        public Auto Auto { get; set; }
        public Kunde Kunde { get; set; }
    }
}
