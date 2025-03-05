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
    /// Логика взаимодействия для PageChangePassword.xaml
    /// </summary>
    public partial class PageChangePassword : Page
    {
        Users userObj;
        public PageChangePassword(Users objUser)
        {
            InitializeComponent();
            userObj = objUser;
            txbLogin.IsEnabled = false;
            DataContext = userObj;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(psbPassword.Password != userObj.Password)
                {
                    if (psbPassword.Password == psbRepPassword.Password)
                    {
                        userObj.Password = psbPassword.Password;
                        userObj.DateLogin = DateTime.Now;
                        OdbConnectHelper.entObj.SaveChanges();
                        MessageBox.Show("Вы успешно изменили свой пароль, теперь войдите с новыми данными.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        FrameHelper.frmObj.Navigate(new PageLogin());
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают.", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Придумайте новый пароль.", "Ошибка",
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
