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
        public AddSuffixWindow()
        {
            InitializeComponent();
        }

        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (edtString.Text.Length == 0)
            {
                MessageBox.Show("Please enter a string.");
                return;
            }
            AddSuffixRule convert = new(edtSuffix.Text);
            txtResult.Content = convert.Rename(edtString.Text);
        }
    }
}
