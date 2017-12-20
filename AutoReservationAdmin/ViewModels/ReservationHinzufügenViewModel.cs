using AutoReservation.Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservationAdmin.ViewModels
{
    public class ReservationHinzufügenViewModel
    {
        public bool IsNew { get; set; }
        public int ReservationsNr { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }

        public AutoDto Auto { get; set; }
        public KundeDto Kunde { get; set; }

        public KundeDto[] AvailableCustomers { get; set; }
        public AutoDto[] AvailableCars { get; set; }

        public string SaveText => IsNew ? "Reservation hinzufügen" : "Reservation speichern";

    }
}
