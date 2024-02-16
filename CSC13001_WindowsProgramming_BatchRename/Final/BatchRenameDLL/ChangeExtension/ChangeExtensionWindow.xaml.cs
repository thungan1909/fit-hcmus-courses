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

namespace ChangeExtension
{
    /// <summary>
    /// Interaction logic for ChangeExtensionWindow.xaml
    /// </summary>
    public partial class ChangeExtensionWindow : Window
    {
        public ChangeExtensionRule GetInput { get; set; }

        public ChangeExtensionWindow(ChangeExtensionRule old)
        {

            InitializeComponent();
            GetInput = (ChangeExtensionRule)old.Clone();
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
