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
    public class AutoController
    {
        private AutoReservationServiceClient client = new AutoReservationServiceClient();


        public AutoViewModel GenerateAutosViewModel()
        {
            var cars = client.getAllCars();

            return new AutoViewModel
            {
                AutoCollection = new ObservableCollection<AutoDto>(cars)
            };
        }
        public AutoHinzufügenViewModel GenerateCreateAutoHinzufügenViewModel()
        {
            return new AutoHinzufügenViewModel
            {
                IsNew = true,
                Marke = "",
                AvailableAutoKlasses = new List<AutoKlasse> { AutoKlasse.Standard, AutoKlasse.Mittelklasse, AutoKlasse.Luxusklasse },
            };
        }
        public AutoHinzufügenViewModel GenerateModifyAutoHinzufügenViewModel(AutoDto auto)
        {
            return new AutoHinzufügenViewModel
            {
                IsNew = false,
                Id = auto.Id,
                Marke = auto.Marke,
                Basistarif = auto.Basistarif,
                Tagestarif = auto.Tagestarif,
                AutoKlasse = auto.AutoKlasse,
                AvailableAutoKlasses = new List<AutoKlasse> { AutoKlasse.Standard, AutoKlasse.Mittelklasse, AutoKlasse.Luxusklasse },
            };
        }

        public void CreateAuto(AutoHinzufügenViewModel viewModel)
        {
            if (viewModel.IsNew)
            {
                client.addCar(new AutoDto
                {
                    Marke = viewModel.Marke,
                    Basistarif = viewModel.Basistarif,
                    Tagestarif = viewModel.Tagestarif,
                });
            }
            else
            {
                AutoDto selectedCar = client.getCarById(viewModel.Id);
                selectedCar.Marke = viewModel.Marke;
                selectedCar.Basistarif = viewModel.Basistarif;
                selectedCar.Tagestarif = viewModel.Tagestarif;
                client.modifyCar(selectedCar);
            }
        }
    }
}
