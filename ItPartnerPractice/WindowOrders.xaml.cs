using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ItPartnerPractice
{
    /// <summary>
    /// Interaction logic for WindowOrders.xaml
    /// </summary>
    public partial class WindowOrders : Window
    {
        public WindowOrders()
        {
            InitializeComponent();
            OrderList.ItemsSource = App.Context.Orders.ToList();
        }
        private void btnOrderAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowOrderAdd windowOrderAdd = new WindowOrderAdd();
            windowOrderAdd.ShowDialog();
        }

        private void btnClearFilters_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = "";
            cbFilter.SelectedIndex = -1;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadInfoToComboBox();
        }
        private void LoadInfoToComboBox()
        {
            var comboBoxFill = App.Context.OrderStatus.ToList();
            foreach (var item in comboBoxFill)
            {
                cbFilter.Items.Add(item.OrderStatusName);
            }
        }

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
        private void Update()
        {
            try
            {
                var orders = App.Context.Orders.ToList();
                if (tbSearch.Text != null)
                    orders = orders.Where(p => p.OrderStatus.OrderStatusName.ToLower().Contains(tbSearch.Text.ToLower())
                    || p.Clients.ClientName.ToLower().Contains(tbSearch.Text.ToLower()) || p.OrderId.ToString().Contains(tbSearch.Text)
                    || p.OrderStatus.OrderStatusName.ToLower().Contains(tbSearch.Text.ToLower())).ToList();
                if (cbFilter.SelectedIndex != -1)
                    orders = orders.Where(p => p.OrderStatus.OrderStatusName == cbFilter.SelectedItem.ToString()).ToList();
                OrderList.ItemsSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void btnOrderEdit_Click(object sender, RoutedEventArgs e)
        {
            var currentOrder = (sender as Button).DataContext as Entities.Orders;
            WindowOrderAdd windowOrderAdd = new WindowOrderAdd(currentOrder);
            windowOrderAdd.ShowDialog();
            Update();
        }

        private void btnOrderDelete_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                var currentOrder = (sender as Button).DataContext as Entities.Orders;
                if (MessageBox.Show("Вы действительно хотите удалить заказ с номером: "+currentOrder.NumberOfOrder+"?",
                    "Внимание",MessageBoxButton.YesNoCancel,MessageBoxImage.Question)==MessageBoxResult.Yes)
                {
                    App.Context.Orders.Remove(currentOrder);
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
    }
}
