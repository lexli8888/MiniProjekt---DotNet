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
using AutoReservationAdmin.AutoReservationService;
using AutoReservationAdmin.ViewModels;
using AutoReservationAdmin.Controllers;

namespace AutoReservationAdmin
{
    /// <summary>
    /// Interaktionslogik für Autos.xaml
    /// </summary>
    public partial class Autos : Window
    {
        private AutoController controller;

        public Autos()
        {
            InitializeComponent();

            controller = new AutoController();
            DataContext = controller.GenerateAutosViewModel();
        }

        private void Button_AddCar(object sender, RoutedEventArgs e)
        {
            Window AddCar = new AutoHinzufügen(null);
            AddCar.Show();
            this.Close();
        }

        private void Button_ModifyCar(object sender, RoutedEventArgs e)
        {
            var viewModel = (AutoViewModel)DataContext;
            Window AddCar = new AutoHinzufügen(viewModel.SelectedAuto);
            AddCar.Show();
            this.Close();
        }

        private void Button_DeleteCar(object sender, RoutedEventArgs e)
        {
            var viewModel = (AutoViewModel)DataContext;
            var client = new AutoReservationServiceClient();
            AutoDto selectedAuto = client.getCarById(viewModel.SelectedAuto.Id);
            client.removeCar(selectedAuto);
        }
    }
}
