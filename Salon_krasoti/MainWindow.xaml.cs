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

namespace Salon_krasoti
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_to_uslugi_page(object sender, RoutedEventArgs e)
        {
            UslugiWindow w1 = new UslugiWindow();
            this.Close();
            w1.Show();
        }

        private void button_to_klienti_page(object sender, RoutedEventArgs e)
        {
            KlientiWindow w2 = new KlientiWindow();
            this.Close();
            w2.Show();
        }

        private void button_to_zapisi_page(object sender, RoutedEventArgs e)
        {
            ZapisiWindow w3 = new ZapisiWindow();
            this.Close();
            w3.Show();
        }
    }
}
