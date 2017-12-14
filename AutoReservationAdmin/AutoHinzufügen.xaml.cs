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
    /// Interaktionslogik für AutoHinzufügen.xaml
    /// </summary>
    public partial class AutoHinzufügen : Window
    {
        public AutoHinzufügen()
        {
            InitializeComponent();
        }

        

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Window Autos = new Autos();
            Autos.Show();
            this.Close();
        }
    }
}
