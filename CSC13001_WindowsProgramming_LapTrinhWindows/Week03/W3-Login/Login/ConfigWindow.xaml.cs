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
using System.Windows.Shapes;

namespace Login
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



            //myTimer = new System.Timers.Timer(1000);
            //myTimer.Elapsed += MyTimer_Elapsed;
            //myTimer.Start();


            //NewServer = dataTextBox.Text;
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            if (username == "admin" && password == "qwe3@1")
            {
                var main = new MainWindow();
                main.Show();

                this.Close();
            }


            DialogResult = true;
        }

      
    }
}
