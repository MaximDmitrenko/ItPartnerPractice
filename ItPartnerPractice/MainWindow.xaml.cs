using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ItPartnerPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textRegister_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                WindowRegister windowRegister = new WindowRegister();
                windowRegister.ShowDialog();
            }
           
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void textRegister_MouseEnter(object sender, MouseEventArgs e)
        {
            try 
            {
                textRegister.TextDecorations = TextDecorations.Underline;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void textRegister_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                TextBlock textBlock = (TextBlock)sender;
                textBlock.TextDecorations = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void textClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try 
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void textClose_MouseEnter(object sender, MouseEventArgs e)
        {
            try 
            {
                textClose.TextDecorations = TextDecorations.Underline;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void textClose_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                TextBlock textBlock = (TextBlock)sender;
                textBlock.TextDecorations = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    this.DragMove();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Системная ошибка!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                return;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WindowServices windowServices = new WindowServices();

                var adminUser = App.Context.Users.FirstOrDefault(p => p.UserLogin == tbLogin.Text &&
                p.UserPassword == pbPassword.Password && p.RoleId == 1);
                var managerUser = App.Context.Users.FirstOrDefault(p => p.UserLogin == tbLogin.Text &&
                p.UserPassword == pbPassword.Password && p.RoleId == 2);

                if (adminUser != null)
                {
                    windowServices.Show();
                    this.Hide();
                }

                else if (managerUser != null)
                {
                    windowServices.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Логин или пароль были введены неверно. Попробуйте снова.", "Внимание!",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
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
