using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhones
{
    internal class MobilePhone : INotifyPropertyChanged
    {
        public string PhoneName { get; set; }
        public string PhoneImage { get; set; }
        public string Manufacture { get; set; }
        public double Price { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
