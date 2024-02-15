using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LTWindows_DemoWeek03
{
    /// <summary>
    /// Interaction logic for ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public string NewServer { get; set; } = "";
        public ConfigWindow()
        {
            InitializeComponent();
        }
        System.Timers.Timer myTimer;
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(sv.fullName);
            //myTimer = new System.Timers.Timer(1000);
            //myTimer.Elapsed += MyTimer_Elapsed;
            //myTimer.Start();

            //NewServer = dataTextBox.Text;
            //DialogResult = true;
        }
        int current = 0;
        int step = 10;
        //Timer chay 1 thread ngam
        private void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (current<= 100)
            {
                current += step;
                //foreground process
                Dispatcher.Invoke(() =>
               {
                   slider.Value = current;
               });
            }    
            else
            {
                myTimer.Stop();
            }
        }   

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Title = $"Current value is {slider.Value}";
        }
        Student sv = null;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sv = new Student()
            {
                ID = "001",
                fullName = "Nguyen Minh Tam",
                Credits = 80, //tren tong 140
                Avatar ="images/2.jpg"
            };
            DataContext = sv;
        }
    }
}
