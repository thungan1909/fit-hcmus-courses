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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MobilePhones
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Fluent.RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        BindingList<MobilePhone> _list = new BindingList<MobilePhone>();
        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var _phone1 = new MobilePhone()
            {
                PhoneName = "Samsung Galaxy Z Fold3 5G 512GB",
                Manufacture = "Samsung",
                Price = 43990000,
                PhoneImage = "PhoneImages/1.jpg"
            };
            var _phone2 = new MobilePhone()
            {
                PhoneName = "iPhone 12",
                Manufacture = "Apple",
                Price = 19990000,
                PhoneImage = "PhoneImages/2.jpg"
            };
            var _phone3 = new MobilePhone()
            {
                PhoneName = "Xiaomi Redmi Note 10S",
                Manufacture = "Xiaomi",
                Price = 5990000,
                PhoneImage = "PhoneImages/3.jpg"
            };
            var _phone4 = new MobilePhone()
            {
                PhoneName = "Vivo Y12s (4GB/128GB)",
                Manufacture = "Vivo",
                Price = 3790000,
                PhoneImage = "PhoneImages/4.jpg"
            };
            var _phone5 = new MobilePhone()
            {
                PhoneName = "OPPO Reno6 Z 5G",
                Manufacture = "OPPO",
                Price = 9490000,
                PhoneImage = "PhoneImages/5.jpg"
            };
            var _phone6 = new MobilePhone()
            {
                PhoneName = "Samsung Galaxy A52s 5G",
                Manufacture = "Samsung",
                Price = 10290000,
                PhoneImage = "PhoneImages/6.jpg"
            };
            var _phone7 = new MobilePhone()
            {
                PhoneName = "OPPO A74",
                Manufacture = "OPPO",
                Price = 6690000,
                PhoneImage = "PhoneImages/7.jpg"
            };
            var _phone8 = new MobilePhone()
            {
                PhoneName = "Realme C21Y 4GB",
                Manufacture = "Realme",
                Price = 3990000,
                PhoneImage = "PhoneImages/8.jpg"
            };
            var _phone9 = new MobilePhone()
            {
                PhoneName = "Xiaomi Redmi 10 (6GB/128GB)",
                Manufacture = "Xiaomi",
                Price = 4690000,
                PhoneImage = "PhoneImages/9.jpg"
            };
            _list.Add(_phone1);
            _list.Add(_phone2);
            _list.Add(_phone3);
            _list.Add(_phone4);
            _list.Add(_phone5);
            _list.Add(_phone6);
            _list.Add(_phone7);
            _list.Add(_phone8);
            _list.Add(_phone9);
            MobilePhoneList.ItemsSource = _list;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            _list.Add(new MobilePhone()
            {
                PhoneName = "Vivo Y53s",
                Manufacture = "VIVO",
                Price = 6990000,
                PhoneImage = "PhoneImages/10.jpg"
            });
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var index = MobilePhoneList.SelectedIndex;
            _list.RemoveAt(index);
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var index = MobilePhoneList.SelectedIndex;
            _list[index].PhoneName = "Xiaomi Redmi 10 (6GB/128GB)";
            _list[index].Manufacture = "Xiaomi";
            _list[index].Price = 4690000;
            _list[index].PhoneImage = "PhoneImages/9.jpg";

        }

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var index = MobilePhoneList.SelectedIndex;
            _list.RemoveAt(index);
        }
    }
}
