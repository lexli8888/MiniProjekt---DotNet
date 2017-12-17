
using System;
using System.Windows;



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
