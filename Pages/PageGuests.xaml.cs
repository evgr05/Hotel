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
    /// Логика взаимодействия для PageGuests.xaml
    /// </summary>
    public partial class PageGuests : Page
    {
        Users _currentUser;
        public PageGuests(Users _selectedUser)
        {
            InitializeComponent();
            guestGrid.ItemsSource = OdbConnectHelper.entObj.Guests.ToList();
            _currentUser = _selectedUser;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.Navigate(new PageMain(_currentUser));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
