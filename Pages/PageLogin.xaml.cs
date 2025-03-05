using Hotel.DataFiles;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Users userObj = new Users();
                userObj = OdbConnectHelper.entObj.Users.FirstOrDefault(x => x.Login == txbLogin.Text);
                if(userObj != null)
                {
                    if (userObj.Blocked == false)
                    {
                                            
                        if (userObj.Password == psbPassword.Password)
                        {
                            //Если пользователь не заходил более 2 месяцев
                            if (userObj.DateLogin.HasValue && (DateTime.Now - userObj.DateLogin.Value).TotalDays > 60)
                            {
                                MessageBox.Show($"Вы не заходили более 2 месяцев, необходимо поменять пароль", "Смените пароль",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                                FrameHelper.frmObj.Navigate(new PageChangePassword(userObj));
                                //MessageBox.Show(userObj.DateLogin.Value.ToString());
                            }
                            else
                            {
                                MessageBox.Show($"Здравствуйте, {userObj.Name}!");
                                userObj.DateLogin = DateTime.Now;
                                userObj.Attemp = 1;
                                OdbConnectHelper.entObj.SaveChanges();
                                FrameHelper.frmObj.Navigate(new PageMain());
                            }

                        }
                        else
                        {
                            MessageBox.Show($"Неверный пароль! Осталось попыток: {3 - userObj.Attemp}", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
                            userObj.Attemp += 1;
                            if (userObj.Attemp > 3)
                            {
                                userObj.Blocked = true;
                            }
                            OdbConnectHelper.entObj.SaveChanges();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ваш аккаунт заблокирован. Обратитесь к системному администратору.", "Ошибка", 
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }                    
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует.", "Ошибка", 
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
