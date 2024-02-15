using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    internal class Book: INotifyPropertyChanged
    {
        public string BookName { get; set; }
        public string CoverImage { get; set; }
        public string Author { get; set; }
        public int PublishedYear { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
