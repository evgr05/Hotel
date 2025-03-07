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
using Hotel.Windows;

namespace Hotel.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageNubmers.xaml
    /// </summary>
    public partial class PageNubmers : Page
    {
        Users _currentUser;
        public PageNubmers(Users _selectedUser)
        {
            InitializeComponent();
            numGrid.ItemsSource = OdbConnectHelper.entObj.Numbers.ToList();
            _currentUser = _selectedUser;
            if (_currentUser.RoleId == 3)
            {
                btnAdd.Visibility = Visibility.Hidden;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.Navigate(new PageMain(_currentUser));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddNumber windowAddNumber = new WindowAddNumber(null, _currentUser);
            windowAddNumber.Show();
        }
    }
}
