using System;
using System.Linq;
using System.Windows;

namespace ItPartnerPractice
{
    /// <summary>
    /// Interaction logic for WindowOrderAdd.xaml
    /// </summary>
    public partial class WindowOrderAdd : Window
    {
        int clientId = 0;
        int serviceId = 0;
        int orderStatusId = 0;
        int maxOrderId = 0;
        bool isAnotherService = false;
        private Entities.Orders _currentOrder = null;
        public WindowOrderAdd()
        {
            InitializeComponent();           
        }
        public WindowOrderAdd(Entities.Orders orders)
        {
            InitializeComponent();
            _currentOrder = orders;
            Title = "Изменение статуса заказа";
            textOrderAdd.Text = "Изменение статуса заказа";
            gridStatus.Visibility = Visibility.Visible;
            btnOrderAdd.Content = "Сохранить";
            textServiceQuantity.Visibility = Visibility.Hidden;
            tbServiceQuantity.Visibility = Visibility.Hidden;
            cbClients.Visibility = Visibility.Hidden;
            cbServices.Visibility = Visibility.Hidden;
            textService.Visibility = Visibility.Hidden;
            textClient.Visibility = Visibility.Hidden;
            cbStatus.SelectedIndex = _currentOrder.OrderStatusId-1;
        }
        private void btnOrderAdd_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (_currentOrder != null)
                {
                    var findOrderStatusId = App.Context.OrderStatus.ToList();

                    foreach (var item in findOrderStatusId)
                    {
                        if (cbStatus.Text == item.OrderStatusName.ToString())
                        {
                            orderStatusId = item.OrderStatusId;
                        }
                    }
                    _currentOrder.OrderStatusId = orderStatusId;
                    App.Context.SaveChanges();
                    MessageBox.Show("Изменения успешно внесены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else if (string.IsNullOrWhiteSpace(tbServiceQuantity.Text)||cbClients.Text==""||cbServices.Text=="")
                {
                    MessageBox.Show("Заполните все поля!");
                    return;
                }
                
                else
                {
                    var findClientId = App.Context.Clients.ToList();
                    var findServiceId = App.Context.Services.ToList();
                    var findMaxOrderId = App.Context.Orders.ToList();

                    foreach (var item in findServiceId)
                    {
                        if (cbServices.Text==item.ServiceName)
                            serviceId = item.ServiceId;
                    }

                    foreach (var item in findClientId)
                    {
                        if (cbClients.Text==item.ClientName.ToString())
                            clientId = item.ClientId;
                    }

                    var newOrder = new Entities.Orders
                    {
                        OrderStatusId = 1,
                        ClientId = clientId
                    };
                    App.Context.Orders.Add(newOrder);
                    App.Context.SaveChanges();

                    foreach (var item in findMaxOrderId)
                    {
                        if (maxOrderId < item.OrderId)
                            maxOrderId = item.OrderId;
                    }

                    var newServiceInOrder = new Entities.ServicesInOrders
                    {
                        ServiceId = serviceId,
                        OrderId=maxOrderId,
                        Quantity=Convert.ToInt32(tbServiceQuantity.Text)
                    };
                    MessageBox.Show("Новый заказ создан и услуга добавлена!",
                        "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadInfoToComboBox();
        }
        private void LoadInfoToComboBox()
        {
            var cbFillClients = App.Context.Clients.ToList();
            var cbFillServices = App.Context.Services.ToList();
            var cbFillStatuses = App.Context.OrderStatus.ToList();

            foreach (var item in cbFillClients)
                cbClients.Items.Add(item.ClientName);

            foreach (var item in cbFillServices)
                cbServices.Items.Add(item.ServiceName);

            foreach (var item in cbFillStatuses)
                cbStatus.Items.Add(item.OrderStatusName);
        }
    }
}
