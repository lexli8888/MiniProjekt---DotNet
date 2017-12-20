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
    public class ReservationController
    {
        private AutoReservationServiceClient client = new AutoReservationServiceClient();
        public ReservationViewModel GenerateReservationViewModel()
        {
            var reservations = client.getAllReservations();

            return new ReservationViewModel
            {
                ReservationCollection = new ObservableCollection<ReservationDto>(reservations)
            };
        }
        public ReservationHinzufügenViewModel GenerateCreateReservationHinzufügenViewModel()
        {
            return new ReservationHinzufügenViewModel
            {
                IsNew = true,
                
            };
        }
        public ReservationHinzufügenViewModel GenerateModifyReservationHinzufügenViewModel(ReservationDto reservation)
        {
            return new ReservationHinzufügenViewModel
            {
                IsNew = false,
                Von = reservation.Von,
                Bis = reservation.Bis,
                Kunde = reservation.Kunde,
                Auto = reservation.Auto,
                AvailableCars = client.getAllCars(),
                AvailableCustomers = client.getAllCustomers()
            };
        }

        public void CreateReservation(ReservationHinzufügenViewModel viewModel)
        {
            if (viewModel.IsNew)
            {
                client.addRerservation(new ReservationDto
                {
                    Von = viewModel.Von,
                    Bis = viewModel.Bis,
                    Kunde = viewModel.Kunde,
                    Auto = viewModel.Auto,
                });
            }
            else
            {
                ReservationDto selectedReservation = client.getReservationByNr(viewModel.ReservationsNr);
                selectedReservation.Von = selectedReservation.Von;
                selectedReservation.Bis = selectedReservation.Bis;
                selectedReservation.Kunde = selectedReservation.Kunde;
                selectedReservation.Auto = selectedReservation.Auto;
                client.modifyRerservation(selectedReservation);
            }
        }
    }
}
