using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ItPartnerPractice
{
    /// <summary>
    /// Interaction logic for WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window
    {
        public WindowRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userLogin = App.Context.Users.FirstOrDefault(p=>p.UserLogin==tbLogin.Text);
                if (string.IsNullOrWhiteSpace(tbLogin.Text) || string.IsNullOrWhiteSpace(tbName.Text)
                    || string.IsNullOrWhiteSpace(tbSurname.Text) || string.IsNullOrWhiteSpace(pbPassword.Password)
                    || string.IsNullOrWhiteSpace(pbRepeatPassword.Password))
                {
                    MessageBox.Show("Заполните все поля!","Внимание!",MessageBoxButton.OKCancel,MessageBoxImage.Warning);
                    return;
                }
                if (pbPassword.Password!=pbRepeatPassword.Password)
                {
                    MessageBox.Show("Пароли не совпадают!", "Внимание!", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    return;
                }
                if (pbPassword.Password.Length<6)
                {
                    MessageBox.Show("Длина пароля должна быть больше 5 символов!", "Внимание!", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    return;
                }
                if (tbLogin.Text.Length<6)
                {
                    MessageBox.Show("Длина логина должна быть больше 5 символов!", "Внимание!", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    return;
                }
                if (userLogin!=null)
                {
                    MessageBox.Show("Данный логин уже занят!", "Внимание!", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    var newUser = new Entities.Users
                    {
                        UserLogin = tbLogin.Text.ToString(),
                        UserPassword=pbPassword.Password.ToString(),
                        UserName=tbName.Text.ToString(),
                        UserSurname=tbSurname.Text.ToString(),
                        RoleId=1
                    };
                    App.Context.Users.Add(newUser);
                    App.Context.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен","Успешно!",MessageBoxButton.OK,MessageBoxImage.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message,"Системная ошибка!",MessageBoxButton.OKCancel,MessageBoxImage.Error);
               return;
            }
        }

        private void textBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void textBack_MouseEnter(object sender, MouseEventArgs e)
        {
            textBack.TextDecorations = TextDecorations.Underline;
        }

        private void textBack_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            textBlock.TextDecorations = null;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
    }
}
