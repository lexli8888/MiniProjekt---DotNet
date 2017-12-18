using AutoReservation.Common.DataTransferObjects;
using AutoReservationAdmin.AutoReservationService;
using AutoReservationAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservationAdmin.Controllers
{
    public class KundeController
    {
        public KundeViewModel GenerateKundeViewModel()
        {
            var client = new AutoReservationServiceClient();
            var customers = client.getAllCustomers();

            return new KundeViewModel
            {
                KundeCollection = new ObservableCollection<KundeDto>(customers)
            };
        }
        public KundeHinzufügenViewModel GenerateCreateKundeHinzufügenViewModel()
        {
            return new KundeHinzufügenViewModel
            {
                IsNew = true,
                Vorname = "",
                Nachname = ""
            };
        }
        public KundeHinzufügenViewModel GenerateModifyKundeHinzufügenViewModel(KundeDto kunde)
        {
            return new KundeHinzufügenViewModel
            {
                IsNew = false,
                Vorname = kunde.Vorname,
                Nachname = kunde.Nachname,
                Geburtsdatum = kunde.Geburtsdatum
                
            };
        }
    }
}
