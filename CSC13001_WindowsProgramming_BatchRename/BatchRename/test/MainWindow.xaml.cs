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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PascalCase;
using Replace;
using AddSuffix;
using ChangeExtension;
using RemoveSpace;
using AddPrefix;
using Lowercase;
using RemoveSpaceFromBeginningAndEnding;
using RemoveAllSpaces;

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // AddSuffixRule.ShowWindow();
            //  ChangeExtensionRule.ShowWindow();
            //RemoveSpaceFromBeginningAndEndingRule.ShowWindow();
            // AddPrefixRule.ShowWindow();
            // LowercaseRule.ShowWindow();
           // RemoveAllSpacesRule.ShowWindow();
          
        }
    }
}
