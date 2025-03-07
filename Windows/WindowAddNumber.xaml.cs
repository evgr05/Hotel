using Hotel.DataFiles;
using Hotel.Pages;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
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
using System.Windows.Shapes;

namespace Hotel.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowAddNumber.xaml
    /// </summary>
    public partial class WindowAddNumber : Window
    {
        Numbers _currentNumber = new Numbers();
        Users _selectedUser;
        public WindowAddNumber(Numbers _selectedNumber, Users _currentUser)
        {
            InitializeComponent();
            cmbCat.ItemsSource = OdbConnectHelper.entObj.Categorys.ToList();
            cmbFloor.ItemsSource = OdbConnectHelper.entObj.Floors.ToList();
            _selectedUser = _currentUser;
            if(_selectedNumber != null)
            {
                _currentNumber = _selectedNumber;
            }
            DataContext = _currentNumber;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_currentNumber.Id == 0)
                {
                    OdbConnectHelper.entObj.Numbers.Add(_currentNumber);
                }
                OdbConnectHelper.entObj.SaveChanges();
                FrameHelper.frmObj.Navigate(new PageNubmers(_selectedUser));
                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
