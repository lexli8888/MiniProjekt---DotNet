using AutoReservation.Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservationAdmin.ViewModels
{
    public class AutoHinzufügenViewModel
    {
        
        public bool IsNew { get; set; }
        public int Id { get; set; }
        public string Marke { get; set; }
        public int Tagestarif { get; set; }
        public int Basistarif { get; set; }
        public AutoKlasse AutoKlasse { get; set; }

        public string SaveText => IsNew ? "Auto hinzufügen" : "Auto speichern";

        
    }
}
