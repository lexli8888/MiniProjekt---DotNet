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
    /// Interaktionslogik für KundeHinzufügen.xaml
    /// </summary>
    public partial class KundeHinzufügen : Window
    {
        private KundeController controller = new KundeController();
        public KundeHinzufügen(KundeDto kunde)
        {
            InitializeComponent();

            if (kunde == null)
            {
                DataContext = controller.GenerateCreateKundeHinzufügenViewModel();
            }
            else
            {
                DataContext = controller.GenerateModifyKundeHinzufügenViewModel(kunde);
            }
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Window Kunden = new Kunden();
            Kunden.Show();
            this.Close();
        }

        private void Button_AddCustomer(object sender, RoutedEventArgs e)
        {
            var client = new AutoReservationServiceClient();
            var myCustomer = (KundeHinzufügenViewModel)DataContext;
            if (myCustomer.IsNew)
            {

                client.addCar(new KundeDto
                {
                    Vorname = Vorname.Text,
                    Nachname = Nachname.Text,
                    Geburtsdatum = Geburtsdatum.Text


                });
            }
            else
            {

                KundeDto selectedCustomer = client.getCustomerById(myCustomer.Id);
                selectedCustomer.Vorname = Vorname.Text;
                selectedCustomer.Nachname = Nachname.Text;
                selectedCustomer.Geburtsdatum = Geburtsdatum.Text;
                client.modifyCustomer(selectedCustomer);

            }

            Window Kunden = new Kunden();
            Kunden.Show();
            this.Close();
        }
    }
}
