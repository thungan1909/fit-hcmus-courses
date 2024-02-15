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

namespace Books
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
        BindingList<Book> _list = new BindingList<Book>();
        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var _book1 = new Book()
            {
                BookName = "A Splendid Exchange: How Trade Shaped the World ",
                Author = "William J Bernstein",
                PublishedYear = 2008,
                CoverImage = "BookImages/1.jpg"
            };

            var _book2 = new Book()
            {
                BookName = "The Arabs: A History",
                Author = "Eugene Rogan",
                PublishedYear = 2009,
                CoverImage = "BookImages/2.jpg"
            };

            var _book3 = new Book()
            {
                BookName = "Citizenship Between Empire and Nation: Remaking France and French Africa, 1945-1960",
                Author = "Frederick Cooper",
                PublishedYear = 2014,
                CoverImage = "BookImages/3.jpg"
            };

            var _book4 = new Book()
            {
                BookName = "The Comanche Empire ",
                Author = "Pekka Hamalainen",
                PublishedYear = 2008,
                CoverImage = "BookImages/4.jpg"
            };

            var _book5 = new Book()
            {
                BookName = "The Ottoman Scramble for Africa: Empire and Diplomacy in the Sahara and the Hijaz ",
                Author = "Mostafa Minawi",
                PublishedYear = 2016,
                CoverImage = "BookImages/5.jpg"
            };

            var _book6 = new Book()
            {
                BookName = "Empires, Nations, and Families: A New History of the North American West 1800 - 1860",
                Author = "Anne F Hyde",
                PublishedYear = 2011,
                CoverImage = "BookImages/6.jpg"
            };

            var _book7 = new Book()
            {
                BookName = "1493: Uncovering the New World Columbus Created",
                Author = "Charles C Mann",
                PublishedYear = 2011,
                CoverImage = "BookImages/7.jpg"
            };

            var _book8 = new Book()
            {
                BookName = "Debt: The First 5,000 Years",
                Author = "David Graeber",
                PublishedYear = 2011,
                CoverImage = "BookImages/8.jpg"
            };

            var _book9 = new Book()
            {
                BookName = "Orderly and Humane: The Expulsion of the Germans After the Second World War ",
                Author = "RM Douglas",
                PublishedYear = 2012,
                CoverImage = "BookImages/9.jpg"
            };

            _list.Add(_book1);
            _list.Add(_book2);
            _list.Add(_book3);
            _list.Add(_book4);
            _list.Add(_book5);
            _list.Add(_book6);
            _list.Add(_book7);
            _list.Add(_book8);
            _list.Add(_book9);
            BookList.ItemsSource = _list;
        }
            private void addButton_Click(object sender, RoutedEventArgs e)
        {
            _list.Add(new Book()
            {
                BookName = "The Transformation of the World: A Global History of the Nineteenth Century  ",
                Author = "Jurgen Osterhammel",
                PublishedYear = 2014,
                CoverImage = "BookImages/10.jpg"
            });
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            var index = BookList.SelectedIndex;
            _list.RemoveAt(index);
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var index = BookList.SelectedIndex;
            _list[index].BookName = "Orderly and Humane: The Expulsion of the Germans After the Second World War ";
            _list[index].PublishedYear = 2012;
            _list[index].Author = "RM Douglas";
            _list[index].CoverImage = "BookImages/9.jpg";
        }

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var index = BookList.SelectedIndex;
            _list.RemoveAt(index);
        }
    }
}
