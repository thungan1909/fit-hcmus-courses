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

namespace AddSuffix
{
    /// <summary>
    /// Interaction logic for AddSuffixWindow.xaml
    /// </summary>
    public partial class AddSuffixWindow : Window
    {
        public AddSuffixRule GetInput { get; set; }

        public AddSuffixWindow(AddSuffixRule old)
        {

            InitializeComponent();
            GetInput = (AddSuffixRule)old.Clone();
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
