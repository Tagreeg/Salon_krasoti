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
    /// Логика взаимодействия для ClientsAdd.xaml
    /// </summary>
    public partial class ServiceForClientsAdd : Window
    {

        private ClientService _currentServiceForClient = new ClientService();

        public ServiceForClientsAdd(ClientService selectedTitle)
        {
            InitializeComponent();

            if (selectedTitle != null)
            {
                _currentServiceForClient = selectedTitle;
            }
            
            DataContext = _currentServiceForClient;
            /* ComboServiceTitle.ItemsSource = Salon_krasotiEntities.GetContext().Services.ToList();
             ComboClientSurname.ItemsSource = Salon_krasotiEntities.GetContext().Clients.ToList();*/
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();



            _currentServiceForClient.ClientID = ComboClientSurname.SelectedIndex + 1;
            _currentServiceForClient.ServiceID = ComboServiceTitle.SelectedIndex + 1;
            _currentServiceForClient.StartTime = (System.DateTime)dp1.SelectedDate;



            if (_currentServiceForClient.ClientID == null)
            {
                errors.AppendLine("Укажите Клиента");
            }
            if (_currentServiceForClient.ServiceID == null)
            {
                errors.AppendLine("Укажите название процедуры");
            }

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentServiceForClient.ID == 0)
            {
                Salon_krasotiEntities.GetContext().ClientServices.Add(_currentServiceForClient);
            }
            
            try
            {
                Salon_krasotiEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные занесены");
                MainWindow w1 = new MainWindow();
                this.Close();
                w1.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                Salon_krasotiEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ComboServiceTitle.ItemsSource = Salon_krasotiEntities.GetContext().Services.ToList();
                ComboClientSurname.ItemsSource = Salon_krasotiEntities.GetContext().Clients.ToList();
            }
        }

        private void CanselBtn_Click(object sender, RoutedEventArgs e)
        {
            ZapisiWindow w3 = new ZapisiWindow();
            this.Close();
            w3.Show();
        }
    }
}
