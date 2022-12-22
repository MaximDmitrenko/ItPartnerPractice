using System;
using System.Windows;
using System.IO;
using Microsoft.Win32;

namespace ItPartnerPractice
{
    /// <summary>
    /// Interaction logic for WindowServicesAdd.xaml
    /// </summary>
    public partial class WindowServicesAdd : Window
    {
        private Entities.Services _currentService = null;
        public string imageName = "";
        string textFromRtb = "";
        
        public WindowServicesAdd()
        {
            InitializeComponent();
        }
        public WindowServicesAdd(Entities.Services services)
        {
            InitializeComponent();
            _currentService = services;
            Title = "Редактирование услуги";
            textServiceAdd.Text = "Редактирование услуги";
            tbServiceName.Text = _currentService.ServiceName;
            tbServicePrice.Text = _currentService.ServicePrice.ToString();
            rtbServiceDescription.Selection.Text = _currentService.ServiceDescription;
        }


        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog().Value == true)
                {
                    imageName = openFileDialog.FileName;
                    textFilePath.Text = imageName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }

        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Images\\" + System.IO.Path.GetFileName(imageName);
                if (imageName != "")
                {
                    File.Move(imageName, path);
                }
                if (string.IsNullOrWhiteSpace(tbServiceName.Text)||string.IsNullOrWhiteSpace(tbServicePrice.Text))
                {
                    MessageBox.Show("Заполните все поля!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (_currentService!=null)
                {
                    rtbServiceDescription.SelectAll();
                    _currentService.ServiceName = tbServiceName.Text;
                    _currentService.ServiceDescription = rtbServiceDescription.Selection.Text;
                    _currentService.ServicePrice = Convert.ToInt32(tbServicePrice.Text);
                    _currentService.ServicePhoto = "Images\\" + System.IO.Path.GetFileName(imageName);
                    App.Context.SaveChanges();
                    MessageBox.Show("Изменения успешно внесены", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {       
                    rtbServiceDescription.SelectAll();
                    textFromRtb = rtbServiceDescription.Selection.Text;
                    var newService = new Entities.Services
                    {
                        ServiceName = tbServiceName.Text,
                        ServiceDescription = textFromRtb,
                        ServicePrice = Convert.ToInt32(tbServicePrice.Text),
                        ServicePhoto = "Images\\" + System.IO.Path.GetFileName(imageName)
                    };
                    App.Context.Services.Add(newService);
                    App.Context.SaveChanges();
                    MessageBox.Show("Услуга успешно добавлена", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);            
                    this.Close();
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
