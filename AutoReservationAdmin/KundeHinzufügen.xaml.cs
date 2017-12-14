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
        public KundeHinzufügen()
        {
            InitializeComponent();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Window Kunden = new Kunden();
            Kunden.Show();
            this.Close();
        }
    }
}
