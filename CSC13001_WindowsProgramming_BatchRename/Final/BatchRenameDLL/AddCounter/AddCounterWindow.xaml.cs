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

namespace AddCounter
{
    /// <summary>
    /// Interaction logic for AddCounterWindow.xaml
    /// </summary>
    public partial class AddCounterWindow : Window
    {
        public AddCounterRule GetInput { get; set; }
        public AddCounterWindow(AddCounterRule oldRule)
        {
            InitializeComponent();
            GetInput = (AddCounterRule)oldRule.Clone();
            DataContext = GetInput;
        }
        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (startValue.Text.Length == 0)
            {
                MessageBox.Show("Please enter a start value!!!");
                return;
            }

            if (step.Text.Length == 0)
            {
                MessageBox.Show("Please enter a step!!!");
                return;
            }

            if (numberOfDigits.Text.Length == 0)
            {
                MessageBox.Show("Please enter a number of digits!!!");
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
