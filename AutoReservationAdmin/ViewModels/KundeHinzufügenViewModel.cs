using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservationAdmin.ViewModels
{
    public class KundeHinzufügenViewModel
    {
        public bool IsNew { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }

        public string SaveText => IsNew ? "Kunde hinzufügen" : "Kunde speichern";
    }
}
