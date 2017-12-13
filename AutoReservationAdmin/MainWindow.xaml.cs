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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoReservationAdmin
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Autos(object sender, RoutedEventArgs e)
        {
            Window Autos = new Autos();
            Autos.Show();
            this.Close();
        }

        private void Button_Kunden(object sender, RoutedEventArgs e)
        {
            Window Kunden = new Kunden();
            Kunden.Show();
            this.Close();
        }

        private void Button_Reservationen(object sender, RoutedEventArgs e)
        {
            Window Reservationen = new Reservationen();
            Reservationen.Show();
            this.Close();
        }
    }
}
