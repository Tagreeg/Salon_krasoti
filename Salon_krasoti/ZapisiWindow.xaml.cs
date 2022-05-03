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

namespace Salon_krasoti
{
    /// <summary>
    /// Логика взаимодействия для ZapisiWindow.xaml
    /// </summary>
    public partial class ZapisiWindow : Window
    {
        public ZapisiWindow()
        {
            InitializeComponent();
            ZapisiTablVivoda.ItemsSource = Salon_krasotiEntities.GetContext().ClientServices.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ServiceForClientsAdd w1 = new ServiceForClientsAdd((sender as Button).DataContext as ClientService);
            this.Close();
            w1.Show();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ServiceForClientsAdd w1 = new ServiceForClientsAdd(null);
            this.Close();
            w1.Show();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ServiceForClientForRemoving = ZapisiTablVivoda.SelectedItems.Cast<ClientService>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Salon_krasotiEntities.GetContext().ClientServices.RemoveRange(ServiceForClientForRemoving);
                    Salon_krasotiEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    ZapisiTablVivoda.ItemsSource = Salon_krasotiEntities.GetContext().ClientServices.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w1 = new MainWindow();
            w1.Show();
            this.Close();
        }
    }
}
