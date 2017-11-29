using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace AutoReservation.Dal.Entities
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
