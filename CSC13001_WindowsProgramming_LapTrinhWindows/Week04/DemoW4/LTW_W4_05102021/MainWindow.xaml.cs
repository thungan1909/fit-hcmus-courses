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

namespace LTW_W4_05102021
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
        //Model
        //Student _sv1 = null;
        //Student _sv2 = null;
        //Student _sv = null;
        BindingList<Student> _list = new BindingList<Student>();
        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
           
           var _sv1 = new Student()
            {
                ID=1,
                Name="Tran Duy Quang",
                Credits=100,
                MaxCredits=260,
                Program="Standard 2005",
                  Avatar = "Images/1.jpg"
            };

           var _sv2 = new Student()
            {
                ID = 2,
                Name = "Nguyen Duc Minh",
                Credits = 77,
                MaxCredits = 138,
                Program = "Standard 2019",
                Avatar="Images/2.jpg"
            };
        
            _list.Add(_sv1);
            _list.Add(_sv2);
            sv1StackPanel.DataContext = _list[0];
            sv2StackPanel.DataContext = _list[1];
            studentList.ItemsSource = _list;
        }

       
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var index = studentList.SelectedIndex;
            _list.RemoveAt(index);
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            //_sv1.Name = "Chau Kha Vu";
            //_sv1.Avatar = "Images/3.jpg";

            //_sv2.Credits = 999;
            //_sv2.Avatar = "Images/4.jpg";

            _list.Add(new Student()
            {
                ID = 3,
                Name = "Vuong Nguyen",
                Credits = 11,
                MaxCredits = 190,
                Program = "APCS",
                Avatar = "Images/5.jpg"
            });

        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var index = studentList.SelectedIndex;
            _list[index].Name = "Duy Manh";
            _list[index].Avatar = "Images/7.jpg";
        }

  

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var index = studentList.SelectedIndex;
            _list.RemoveAt(index);
        }

        private void updateMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cut button is clicked");
        }
    }
}
