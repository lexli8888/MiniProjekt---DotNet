using AutoReservation.Common.DataTransferObjects;
using AutoReservationAdmin.Controllers;
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
        private AutoController controller = new AutoController();

        public AutoHinzufügen(AutoDto auto)
        {
            InitializeComponent();

            if (auto == null)
            {
                DataContext = controller.GenerateCreateAutoHinzufügenViewModel();
            }
            else
            {
                DataContext = controller.GenerateModifyAutoHinzufügenViewModel(auto);
            }
            
        }

        

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Window Autos = new Autos();
            Autos.Show();
            this.Close();
        }

        private void Button_AddCar(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
