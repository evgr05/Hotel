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
    /// Логика взаимодействия для PageReport.xaml
    /// </summary>
    public partial class PageReport : Page
    {
        Users _currentUser;
        public PageReport(Users _selectedUser)
        {
            InitializeComponent();
            _currentUser = _selectedUser;
            repGrid.ItemsSource = OdbConnectHelper.entObj.ReportStatusNumber.ToList();
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
