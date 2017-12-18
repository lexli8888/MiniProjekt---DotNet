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
        public ReservationViewModel GenerateReservationViewModel()
        {
            var client = new AutoReservationServiceClient();
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
                Auto = reservation.Auto

            };
        }

    }
}
