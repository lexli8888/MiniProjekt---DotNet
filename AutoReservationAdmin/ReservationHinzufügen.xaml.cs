using AutoReservation.Common.DataTransferObjects;
using AutoReservationAdmin.AutoReservationService;
using AutoReservationAdmin.Controllers;
using AutoReservationAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoReservationAdmin
{
    /// <summary>
    /// Interaktionslogik für ReservationHinzufügen.xaml
    /// </summary>
    public partial class ReservationHinzufügen : Window
    {
        private ReservationController controller = new ReservationController();
        public ReservationHinzufügen(ReservationDto reservation)
        {
            InitializeComponent();

            if (reservation == null)
            {
                DataContext = controller.GenerateCreateReservationHinzufügenViewModel();
            }
            else
            {
                DataContext = controller.GenerateModifyReservationHinzufügenViewModel(reservation);
            }
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Window Reservationen = new Reservationen();
            Reservationen.Show();
            this.Close();
        }

        private void Button_AddReservation(object sender, RoutedEventArgs e)
        {
            var client = new AutoReservationServiceClient();
            var myReservation = (ReservationHinzufügenViewModel)DataContext;
            if (myReservation.IsNew)
            {

                client.addRerservation(new ReservationDto
                {
                    Von = Von.Text,
                    Bis = Bis.Text,
                    Kunde = Kunde.SelectedItem,
                    Auto = Auto.SelectedItem

                    

                });
            }
            else
            {

                ReservationDto selectedReservation = client.getReservationByNr(myReservation.ReservationsNr);
                selectedReservation.Von = Von.Text;
                selectedReservation.Bis = Bis.Text;
                selectedReservation.Kunde = Kunde.SelectedItem;
                selectedReservation.Auto = Auto.SelectedItem;
                client.modifyRerservation(selectedReservation);

            }

            Window Reservation = new Reservationen();
            Reservation.Show();
            this.Close();
        }
    }
}
