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
        public AddPrefixWindow()
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
            AddPrefixRule convert = new(edtPrefix.Text);
            txtResult.Content = convert.Rename(edtString.Text);
        }
    }
}
