using Contract;
using Entity;
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

namespace Gui01
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        IBus _bus = null;

        public UserControl1(IBus bus)
        {
            InitializeComponent();
            _bus = bus;
        }

        private void calButton_Click(object sender, RoutedEventArgs e)
        {
            int num1 = int.Parse((num1TextBox.Text));
            int den1 = int.Parse((num1TextBox.Text));
            int num2 = int.Parse((num2TextBox.Text));
            int den2 = int.Parse((num2TextBox.Text));
            Fraction a = new Fraction()
            {
                Num = num1,
                Den = den1
            };
            Fraction b = new Fraction()
            {
                Num = num2,
                Den = den2
            };
            Fraction result = _bus.Add(a, b);

            num3TextBox.Text = result.Num.ToString();
            den3TextBox.Text = result.Den.ToString();

        }
    }
}
