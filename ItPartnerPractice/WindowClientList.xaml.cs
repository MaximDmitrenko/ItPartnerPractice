using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ItPartnerPractice
{
    /// <summary>
    /// Interaction logic for WindowClientList.xaml
    /// </summary>
    public partial class WindowClientList : Window
    {
        public WindowClientList()
        {
            InitializeComponent();
            ListClients.ItemsSource = App.Context.Clients.ToList();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
        private void Update()
        {
            var clients = App.Context.Clients.ToList();
            if (tbSearch.Text!=null)
            {
                clients = clients.Where(p => p.ClientName.ToLower().Contains(tbSearch.Text.ToLower()) ||
                p.ClientPhone.Contains(tbSearch.Text)||p.ClientMail.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
            }
            ListClients.ItemsSource = clients;
        }

        private void btnDeleteClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentClient = (sender as Button).DataContext as Entities.Clients;
                if (MessageBox.Show("Вы действительно хотите удалить клиента: "+currentClient.ClientName+"?",
                    "Внимание",MessageBoxButton.YesNoCancel,MessageBoxImage.Question)==MessageBoxResult.Yes)
                {
                    App.Context.Clients.Remove(currentClient);
                    App.Context.SaveChanges();
                    Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void btnChangeClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentClient = (sender as Button).DataContext as Entities.Clients;
                WindowClientAddEdit windowClientAddEdit = new WindowClientAddEdit(currentClient);
                windowClientAddEdit.ShowDialog();
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void btnClientAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowClientAddEdit windowClientAddEdit = new WindowClientAddEdit();
                windowClientAddEdit.ShowDialog();
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void btnClearFilters_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = "";
            Update();
        }
    }
}
