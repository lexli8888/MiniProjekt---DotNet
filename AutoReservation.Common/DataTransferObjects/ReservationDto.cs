using AutoReservation.Dal.Entities;
using System;
using System.Runtime.Serialization;


namespace AutoReservation.Common.DataTransferObjects
{
    public class ReservationDto
    {
        public object RowVersion;

        public int ReservationsNr { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public AutoDto Auto { get; set; }

        public KundeDto Kunde { get; set; }

        public override string ToString()
            => $"{ReservationsNr}; {Von}; {Bis}; {Auto}; {Kunde}";
    }

}
