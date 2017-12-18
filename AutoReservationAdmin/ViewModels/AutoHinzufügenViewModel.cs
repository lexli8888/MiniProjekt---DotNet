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
        public string Marke { get; set; }

        public string SaveText => IsNew ? "Auto hinzufügen" : "Auto speichern";
    }
}
