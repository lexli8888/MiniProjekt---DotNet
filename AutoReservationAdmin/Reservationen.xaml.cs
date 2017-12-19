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
using AutoReservation.Common.DataTransferObjects;
using System.Collections.ObjectModel;
using AutoReservationAdmin.Controllers;
using AutoReservationAdmin.ViewModels;
using AutoReservationAdmin.AutoReservationService;

namespace AutoReservationAdmin
{
    /// <summary>
    /// Interaktionslogik für Reservationen.xaml
    /// </summary>
    public partial class Reservationen : Window
    {
        private ReservationController controller;
        public Reservationen()
        {
            InitializeComponent();

            controller = new ReservationController();
            DataContext = controller.GenerateReservationViewModel();

        }



        private void Button_AddReservation(object sender, RoutedEventArgs e)
        {
            Window AddReservation = new ReservationHinzufügen(null);
            AddReservation.Show();
            this.Close();
        }

        private void Button_ModifyReservation(object sender, RoutedEventArgs e)
        {
            var viewModel = (ReservationViewModel)DataContext;
            Window AddReservation = new ReservationHinzufügen(viewModel.SelectedReservation);
            AddReservation.Show();
            this.Close();
        }

        private void Button_DeleteReservation(object sender, RoutedEventArgs e)
        {
            var viewModel = (ReservationViewModel)DataContext;
            var client = new AutoReservationServiceClient();
            ReservationDto selectedReservation = client.getReservationByNr(viewModel.SelectedReservation.ReservationsNr);
            client.removeRerservation(selectedReservation);
        }
    }
}
