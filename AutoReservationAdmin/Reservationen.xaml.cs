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
    /// Interaktionslogik für Reservationen.xaml
    /// </summary>
    public partial class Reservationen : Window
    {
        public Reservationen()
        {
            InitializeComponent();
        }

        private void Button_AddReservation(object sender, RoutedEventArgs e)
        {
            Window AddReservation = new ReservationHinzufügen();
            AddReservation.Show();
            this.Close();
        }

        private void Button_ModifyReservation(object sender, RoutedEventArgs e)
        {

        }

        private void Button_DeleteReservation(object sender, RoutedEventArgs e)
        {

        }
    }
}
