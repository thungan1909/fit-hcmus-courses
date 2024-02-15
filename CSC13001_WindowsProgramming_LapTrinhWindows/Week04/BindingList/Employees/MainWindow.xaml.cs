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

namespace Employees
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
        BindingList<Employee> _list = new BindingList<Employee>();
        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
          var _Emp1 = new Employee()
           {
              FullName= "Katherine Leon",
              Email= "KatherineLeon@gmail.com",
              TelephoneNumber= "+84 99 320 67 88",
              Address= "5892 Shawn Trail, Suite 147, Lake Dell, Nebraska, United States",
              AvatarImage="EmployeeImages/1.jpg"
          };
         var _Emp2 = new Employee()
           {
              FullName= "Deborah Nielsen",
              Email= "Deborah Nielsen@gmail.com",
              TelephoneNumber= "+84 568 990 301",
              Address= "564 Katheryn Lodge, Apt, Lake Maceychester, Nebraska, United ",
              AvatarImage="EmployeeImages/2.jpg"
          };
         var _Emp3 = new Employee()
            {
                FullName = "Janiyah Mason",
                Email = "Janiyah Mason@gmail.com",
                TelephoneNumber = "+84 771 798 105",
                Address = "10643 Wolff Road, Apt. 476, 22147, Mathiasmouth, Virginia, United States",
                AvatarImage = "EmployeeImages/3.jpg"
            };
            var _Emp4 = new Employee()
            {
                FullName = "Kayden Mccullough",
                Email = "Kayden Mccullough@gmail.com",
                TelephoneNumber = "+ 84 522 841 862",
                Address = "881 Adams Greens, Suite 118, 72833-9156, Schmittshire, Nebraska, United States",
                AvatarImage = "EmployeeImages/4.jpg"
            };
            var _Emp5 = new Employee()
            {
                FullName = "Tristen Barr",
                Email = "Tristen Barr@gmail.com",
                TelephoneNumber = "+ 84 342 268 198",
                Address = "202 Pfeffer Roads, Apt. 061, 43048, New Halle, Virginia, United States",
                AvatarImage = "EmployeeImages/5.jpg"
            };
            var _Emp6 = new Employee()
            {
                FullName = "Frank Odonnell",
                Email = "Frank Odonnell@gmail.com",
                TelephoneNumber = "+ 84 309 719 584",
                Address = "8810 Hane Haven, Suite 362, 44555-9772, New Dock, Minnesota, United States",
                AvatarImage = "EmployeeImages/6.jpg"
            };
            var _Emp7 = new Employee()
            {
                FullName = "Malaki Fischer",
                Email = "Malaki Fischer@gmail.com",
                TelephoneNumber = "+84 591 318 493",
                Address = "9530 Beverly Court, Suite 735, 64180-1938, Port Darleneville, Connecticut, United States",
                AvatarImage = "EmployeeImages/7.jpg"
            };
            var _Emp8 = new Employee()
            {
                FullName = "Ashleigh Holland",
                Email = "Ashleigh Holland@gmail.com",
                TelephoneNumber = "+84 898 823 166",
                Address = "246 Darian Knolls, Apt. 532, 36813, Colefort, South Carolina, United States",
                AvatarImage = "EmployeeImages/8.jpg"
            };
            var _Emp9 = new Employee()
            {
                FullName = "Semaj Christian",
                Email = "Semaj Christian@gmail.com",
                TelephoneNumber = "+ 84 351 719 181",
                Address = "9287 Macy Road, Suite 282, 11617-8378, Wildermanville, Pennsylvania, United States",
                AvatarImage = "EmployeeImages/9.jpg"
            };
            _list.Add(_Emp1);
            _list.Add(_Emp2);
            _list.Add(_Emp3);
            _list.Add(_Emp4);
            _list.Add(_Emp5);
            _list.Add(_Emp6);
            _list.Add(_Emp7);
            _list.Add(_Emp8);
            _list.Add(_Emp9);

            EmployeeList.ItemsSource = _list;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            _list.Add(new Employee()
            {
                FullName = "Memphis Soto",
                Email = "Memphis Soto@gmail.com",
                TelephoneNumber = "+ 84 567 688 855",
                Address = "88795 Eryn Trail, Suite 706, 29541-0210, South Jalenport, North Carolina, United States",
                AvatarImage = "EmployeeImages/10.jpg"
            });
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var index = EmployeeList.SelectedIndex;
            _list.RemoveAt(index);
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var index = EmployeeList.SelectedIndex;
            _list[index].FullName = "Katherine Leon";
            _list[index].Email = "KatherineLeon@gmail.com";
            _list[index].TelephoneNumber = "+84 99 320 67 88";
            _list[index].Address = "5892 Shawn Trail, Suite 147, Lake Dell, Nebraska, United States";
            _list[index].AvatarImage = "EmployeeImages/1.jpg";
           
        }

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var index = EmployeeList.SelectedIndex;
            _list.RemoveAt(index);
        }
    }
}
