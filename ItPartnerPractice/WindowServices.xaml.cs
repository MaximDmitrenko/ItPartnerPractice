using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ItPartnerPractice
{
    /// <summary>
    /// Interaction logic for WindowServices.xaml
    /// </summary>
    public partial class WindowServices : Window
    {
        public WindowServices()
        {
            
            InitializeComponent();
            ListServices.ItemsSource = App.Context.Services.ToList();
        }

        private void btnServiceAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowServicesAdd windowServicesAdd = new WindowServicesAdd();
            windowServicesAdd.ShowDialog();
            Update();
        }

        private void btnOrderList_Click(object sender, RoutedEventArgs e)
        {
            WindowOrders windowOrders = new WindowOrders();
            windowOrders.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
        private void btnClearFilters_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = "";
            cbSort.SelectedIndex = -1;
        }

        private void Update()
        {
            var services = App.Context.Services.ToList();
            if (cbSort.Text == "По возрастанию")
                services = services.OrderBy(p => p.PriceService).ToList();
            if (cbSort.Text == "По убыванию")
                services = services.OrderByDescending(p => p.PriceService).ToList();
            if (tbSearch.Text != null)
                services = services.Where(p => p.ServiceName.ToLower().Contains(tbSearch.Text.ToLower()) || p.ServiceDescription.ToLower().Contains(tbSearch.Text.ToLower())|| p.PriceService.Contains(tbSearch.Text)).ToList();
            ListServices.ItemsSource = services;
        }

        private void btnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            var currentService = (sender as Button).DataContext as Entities.Services;
            if (MessageBox.Show("Вы уверены, что хотите удалить "+currentService.ServiceName+"?","Внимание!",MessageBoxButton.YesNoCancel,MessageBoxImage.Question)==MessageBoxResult.Yes)
            {
                App.Context.Services.Remove(currentService);
                App.Context.SaveChanges();
                Update();
            }    
        }

        private void btnChangeService_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                var currentService = (sender as Button).DataContext as Entities.Services;
                WindowServicesAdd windowServices = new WindowServicesAdd(currentService);
                windowServices.ShowDialog();
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void btnClientList_Click(object sender, RoutedEventArgs e)
        {
            WindowClientList windowClientList = new WindowClientList();
            windowClientList.ShowDialog();
        }
    }
}
