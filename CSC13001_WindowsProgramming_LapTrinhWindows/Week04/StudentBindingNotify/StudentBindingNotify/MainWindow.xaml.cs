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

namespace StudentBindingNotify
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

        //Model
        Student _sv = null;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            _sv = new Student()
            {
                MSSV = "19120302",
                HoTen = "Doan Thu Ngan",
                DiaChi = "Ben Tre",
                Email = "nganthudoan2001@gmail.com",
                SDT="0123456789",
                Avatar = "Images/1.jpg"
            };
            svStackPanel.DataContext = _sv;
        }
        
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (_sv.MSSV != "19120302" && _sv.HoTen != "Doan Thu Ngan" && _sv.DiaChi != "Ben Tre")
            {
                _sv.Avatar = "Images/2.jpg";
            }

        }

    }
}
  
