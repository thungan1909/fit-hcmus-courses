using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace LTWindows_DemoWeek03
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

        private void TestButton_Click(object sender, RoutedEventArgs e)
        { //  MessageBox.Show("My turn");
            var config = new ConfigWindow();
            if (config.ShowDialog() == true)
            {
                //Có giá trị mới cần xử lý
                // Debug.WriteLine("True");
                 Debug.WriteLine(config.NewServer);
            }
            else
            {
                Debug.WriteLine("False");
            }

        }

        //Initialized
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ////TestButton.Content = "A whole new change";
            //var choice= MessageBox.Show("Main Windows has been initialized","Error",
            //    MessageBoxButton.YesNoCancel,
            //    MessageBoxImage.Error/*icon */);

            //if (choice == MessageBoxResult.Yes)
            //{
            //    Debug.WriteLine("Yes");
            //}
            //else if(choice == MessageBoxResult.No)
            //{
            //    Debug.WriteLine("No");
            //}
            //var myButton = new Button();
            //myButton.Content = "New brother";
            //myButton.Width = 80;
            //myButton.Height = 80;
            //MotherCanvas.Children.Add(myButton);

            //Canvas.SetLeft(myButton, 100);
            //Canvas.SetTop(myButton, 100);

            
        }

        private void TestButton_Loaded(object sender, RoutedEventArgs e)
        {
            //Dung Common Dialog de lay ten 1 tap tin (filename)
            // Can su dung 1 thu vien co ten la WindowsAPICodePack-Shell
            var screen = new CommonOpenFileDialog();
            screen.IsFolderPicker = false;
            if (screen.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Debug.WriteLine(screen.FileName);
            }
        }

        private void userName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
