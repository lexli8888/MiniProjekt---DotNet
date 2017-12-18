using AutoReservation.Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservationAdmin.ViewModels
{
    public class ReservationViewModel
    {
        public ObservableCollection<ReservationDto> ReservationCollection { get; set; }
        public ReservationDto SelectedReservation { get; set; }

    }
}
