using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Collections.Generic;

namespace AutoReservation.Dal.Entities
{
    public abstract class Auto
    {
        public DateTime RowVersion;

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Marke { get; set; }
        public int Tagestarif { get; set; }
        public int Basistarif { get; set; }
        public int AutoKlasse { get; set; }
        public ICollection<Reservation> Reservationen { get; set; }

    }
}
