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
    /// Interaktionslogik für Kunden.xaml
    /// </summary>
    public partial class Kunden : Window
    {
        private KundeController controller;
        
        public Kunden()
        {
            InitializeComponent();

            controller = new KundeController();
            DataContext = controller.GenerateKundeViewModel();
        }

        private void Button_AddCustomer(object sender, RoutedEventArgs e)
        {
            Window AddCustomer = new KundeHinzufügen(null);
            AddCustomer.Show();
            this.Close();
        }

        private void Button_ModifyCustomer(object sender, RoutedEventArgs e)
        {
            var viewModel = (KundeViewModel)DataContext;
            Window AddCustomer = new KundeHinzufügen(viewModel.SelectedKunde);
            AddCustomer.Show();
            this.Close();
        }

        private void Button_DeleteCustomer(object sender, RoutedEventArgs e)
        {
            var viewModel = (KundeViewModel)DataContext;
            var client = new AutoReservationServiceClient();
            KundeDto selectedCustomer = client.getCustomerById(viewModel.SelectedKunde.Id);
            client.removeCustomer(selectedCustomer);
        }
    }
}
