using AutoReservation.Common.DataTransferObjects;
using AutoReservationAdmin.AutoReservationService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservationAdmin.ViewModels
{
    public class AutoViewModel
    {
        public ObservableCollection<AutoDto> AutoCollection { get; set; }
        public AutoDto SelectedAuto { get; set; }
    }
}
