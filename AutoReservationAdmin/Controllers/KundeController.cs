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
        private AutoReservationServiceClient client = new AutoReservationServiceClient();

        public KundeViewModel GenerateKundeViewModel()
        {
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

        public void CreateKunde(KundeHinzufügenViewModel viewModel)
        {
            if (viewModel.IsNew)
            {
                client.addCustomer(new KundeDto
                {
                    Vorname = viewModel.Vorname,
                    Nachname = viewModel.Nachname,
                    Geburtsdatum = viewModel.Geburtsdatum
                });
            }
            else
            {
                KundeDto selectedCustomer = client.getCustomerById(viewModel.Id);
                selectedCustomer.Vorname = viewModel.Vorname;
                selectedCustomer.Nachname = viewModel.Nachname;
                selectedCustomer.Geburtsdatum = viewModel.Geburtsdatum;
                client.modifyCustomer(selectedCustomer);
            }

        }
    }
}
