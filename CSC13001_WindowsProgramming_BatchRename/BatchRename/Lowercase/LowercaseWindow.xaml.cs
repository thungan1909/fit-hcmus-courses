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

namespace Lowercase
{
    /// <summary>
    /// Interaction logic for LowercaseWindow.xaml
    /// </summary>
    public partial class LowercaseWindow : Window
    {
        public LowercaseWindow()
        {
            InitializeComponent();
        }
    
        readonly LowercaseRule convert = new();
        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (edtString.Text.Length == 0)
            {
                MessageBox.Show("Please enter a string.");
                return;
            }
            txtResult.Content = convert.Rename(edtString.Text);
        }
    }
}
