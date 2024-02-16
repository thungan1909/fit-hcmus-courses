using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for PreviewWindow.xaml
    /// </summary>
    public partial class PreviewWindow : Window
    {
        public Preview GetPreviewRename { get; set; }

        public PreviewWindow(Preview oldPreview)
        {
            InitializeComponent();
            GetPreviewRename = (Preview)oldPreview.Clone();
            GetPreviewRename.PreviewItems();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PreviewList.ItemsSource = GetPreviewRename.Items;
        }
    }
}
