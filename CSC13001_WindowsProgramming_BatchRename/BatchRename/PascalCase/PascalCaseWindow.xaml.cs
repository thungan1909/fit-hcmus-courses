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

namespace PascalCase
{
    /// <summary>
    /// Interaction logic for PascalCaseWindow.xaml
    /// </summary>
    public partial class PascalCaseWindow : Window
    {
        public PascalCaseWindow()
        {
            InitializeComponent();
        }

        readonly PascalCaseRule rename = new();

        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (edtOriginal.Text.Length == 0)
            {
                MessageBox.Show("Please to enter a string.");
                return;
            }
            txtResult.Content = rename.Rename(edtOriginal.Text);
        }
    }
}
