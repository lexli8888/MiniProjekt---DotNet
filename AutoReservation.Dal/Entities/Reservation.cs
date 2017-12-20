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
        [ForeignKey(nameof(AutoId))]
        public Auto Auto { get; set; }
        [ForeignKey(nameof(KundeId))]
        public Kunde Kunde { get; set; }
    }
}
