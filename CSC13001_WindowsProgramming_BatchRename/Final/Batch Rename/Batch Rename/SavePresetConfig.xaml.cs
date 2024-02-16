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

namespace Batch_Rename
{
    /// <summary>
    /// Interaction logic for SavePresetConfig.xaml
    /// </summary>
    public partial class SavePresetConfig : Window
    {
        public Preset GetFileName { get; set; }
        public SavePresetConfig(Preset oldFileName)
        {
            InitializeComponent();
            GetFileName = (Preset)oldFileName.Clone();
            DataContext = GetFileName;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (TbxFilename.Text.Length == 0)
            {
                MessageBox.Show("Please enter a string");
            }
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
