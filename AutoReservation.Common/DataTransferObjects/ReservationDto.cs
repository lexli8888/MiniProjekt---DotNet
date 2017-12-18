using AutoReservation.Dal.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace AutoReservation.Common.DataTransferObjects
{
    public class ReservationDto
    {
        
        [Key]
        public int ReservationsNr { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public AutoDto Auto { get; set; }

        public KundeDto Kunde { get; set; }
        [Timestamp]
        public DateTime RowVersion { get; set; }

        public override string ToString()
            => $"{ReservationsNr}; {Von}; {Bis}; {Auto}; {Kunde}";
    }

}
