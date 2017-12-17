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

namespace AutoReservationAdmin
{
    /// <summary>
    /// Interaktionslogik für Kunden.xaml
    /// </summary>
    public partial class Kunden : Window
    {
        public ObservableCollection<KundeDto> KundeCollection { get; set; }
        
        public Kunden()
        {
            InitializeComponent();
        }

        private void Button_AddCustomer(object sender, RoutedEventArgs e)
        {
            Window AddCustomer = new KundeHinzufügen();
            AddCustomer.Show();
            this.Close();
        }

        private void Button_ModifyCustomer(object sender, RoutedEventArgs e)
        {

        }

        private void Button_DeleteCustomer(object sender, RoutedEventArgs e)
        {

        }
    }
}
