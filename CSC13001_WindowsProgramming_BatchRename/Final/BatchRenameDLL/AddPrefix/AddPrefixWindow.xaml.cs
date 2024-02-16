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

namespace AddPrefix
{
    /// <summary>
    /// Interaction logic for AddPrefixWindow.xaml
    /// </summary>
    public partial class AddPrefixWindow : Window
    {
        public AddPrefixRule GetInput { get; set; }

        public AddPrefixWindow(AddPrefixRule old)
        {

            InitializeComponent();
            GetInput = (AddPrefixRule)old.Clone();
            DataContext = GetInput;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (inputString.Text.Length == 0)
            {
                MessageBox.Show("Please enter a string.");
                return;
            }
            DialogResult = true;
        }
    }
}
