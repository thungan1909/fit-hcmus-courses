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
        public ReplaceWindow()
        {
            InitializeComponent();
        }

        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (edtString.Text.Length == 0 || edtCharReplace.Text.Length == 0 || edtReplacer.Text.Length == 0)
            {
                MessageBox.Show("Please enter a string.");
                return;
            }

            List<string> needles = new List<string>();
            string[] tokens = edtCharReplace.Text.Split(',');
            foreach (string token in tokens)
                needles.Add(token);
            string replacer = edtReplacer.Text;
            ReplaceRule replace = new(needles, replacer);
            txtResult.Content = replace.Rename(edtString.Text);
        }
    }
}
