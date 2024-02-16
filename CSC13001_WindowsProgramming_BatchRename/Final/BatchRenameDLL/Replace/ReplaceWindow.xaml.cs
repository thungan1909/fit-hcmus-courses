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

namespace Replace
{
    /// <summary>
    /// Interaction logic for ReplaceWindow.xaml
    /// </summary>
    public partial class ReplaceWindow : Window
    {
        public ReplaceRule GetInput { get; set; }
        public ReplaceWindow(ReplaceRule oldRule)
        {
            InitializeComponent();
            GetInput = (ReplaceRule)oldRule.Clone();
            DataContext = GetInput;
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

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
