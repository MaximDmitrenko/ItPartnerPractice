using System;
using System.Linq;
using System.Windows;

namespace ItPartnerPractice
{
    /// <summary>
    /// Interaction logic for WindowClientAddEdit.xaml
    /// </summary>
    public partial class WindowClientAddEdit : Window
    {
        private Entities.Clients _currentClient = null;
        public WindowClientAddEdit()
        {
            InitializeComponent();
        }
        public WindowClientAddEdit(Entities.Clients clients)
        {
            InitializeComponent();
            _currentClient = clients;
            Title = "Редактирование клиента";
            textClientAdd.Text = "Редактирование клиента";
            tbClientName.Text = _currentClient.ClientName;
            tbClientPhone.Text = _currentClient.ClientPhone;
            tbClientMail.Text = _currentClient.ClientMail;
        }

        private void btnClientAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var findClient = App.Context.Clients.FirstOrDefault(p => p.ClientName == tbClientName.Text &&
                p.ClientPhone == tbClientPhone.Text);
                if (string.IsNullOrWhiteSpace(tbClientName.Text)||string.IsNullOrWhiteSpace(tbClientPhone.Text)||
                    string.IsNullOrWhiteSpace(tbClientMail.Text))
                {
                    MessageBox.Show("Не все поля заполнены!","Внимание!",MessageBoxButton.OK,MessageBoxImage.Error);
                    return;
                }
                if (findClient!=null && textClientAdd.Text=="Добавление клиента")
                {
                    MessageBox.Show("Данный клиент уже существует!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (_currentClient!=null)
                {
                    _currentClient.ClientName = tbClientName.Text;
                    _currentClient.ClientPhone = tbClientPhone.Text;
                    _currentClient.ClientMail = tbClientMail.Text;
                    App.Context.SaveChanges();
                    MessageBox.Show("Изменения успешно внесены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    var newClient = new Entities.Clients
                    {
                        ClientName = tbClientName.Text,
                        ClientPhone = tbClientPhone.Text,
                        ClientMail = tbClientMail.Text
                    };
                    App.Context.Clients.Add(newClient);
                    App.Context.SaveChanges();
                    MessageBox.Show("Клиент успешно добавлен","Успешно",MessageBoxButton.OK,MessageBoxImage.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Системная ошибка!",MessageBoxButton.OKCancel,MessageBoxImage.Error);
                return;
            }
        }
    }
}
