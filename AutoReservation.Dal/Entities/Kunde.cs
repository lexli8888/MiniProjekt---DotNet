using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Collections.Generic;

namespace AutoReservation.Dal.Entities
{
    public class Kunde
    {
        public DateTime RowVersion;

        public string Nachname { get; set; }
        [Key]
        public int Id { get; set; }
        public string Vorname { get; set; }
        public DateTime Geburtsdatum { get; set; }

        public ICollection<Reservation> Reservationen { get; set; }

    }
}
