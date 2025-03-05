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
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.Navigate(new PageLogin());
        }

        private void btnNumbers_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.Navigate(new PageNubmers());
        }

        private void btnGuests_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.Navigate(new PageGuests());
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.frmObj.Navigate(new PageReport());            
        }
    }
}
