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
        public AutoViewModel GenerateAutosViewModel()
        {
            var client = new AutoReservationServiceClient();
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
                Marke = ""
            };
        }
        public AutoHinzufügenViewModel GenerateModifyAutoHinzufügenViewModel(AutoDto auto)
        {
            return new AutoHinzufügenViewModel
            {
                IsNew = false,
                Marke = auto.Marke
            };
        }
    }
}
