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

namespace RandomEnglish
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
        private void btnChangeImages_Click(object sender, RoutedEventArgs e)
        {

            string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            string[] names =
            {
                "frog","crab","bee","pig","panda","dog","cat","tiger","sheep","bear"

            };
            Random rng = new Random();
            int i = rng.Next() % numbers.Length;
            string number = numbers[i];
            string name = names[i];
            var bitmap = new BitmapImage(new Uri($"/Images/{number}.jpg", UriKind.Relative));
            imgAvatar.Source = bitmap;
            AnimalName.Content = name;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
