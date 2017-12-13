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
    /// Interaktionslogik für Autos.xaml
    /// </summary>
    public partial class Autos : Window
    {
        public Autos()
        {
            InitializeComponent();
        }

        private void Button_AddCar(object sender, RoutedEventArgs e)
        {
            Window AddCar = new AutoHinzufügen();
            AddCar.Show();
            this.Close();
        }

        private void Button_ModifyCar(object sender, RoutedEventArgs e)
        {

        }

        private void Button_DeleteCar(object sender, RoutedEventArgs e)
        {

        }
    }
}
