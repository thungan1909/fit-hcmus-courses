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

namespace StudentBinding
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
        Student sv = null;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sv = new Student()
            {
                MSSV ="19120302",
                HoTen ="Doan Thu Ngan",
                DiaChi="Ben Tre",
                Email="nganthudoan@gmail.com",
                SDT= "0123456789"
            };
            DataContext = sv;
        }
    }
}
