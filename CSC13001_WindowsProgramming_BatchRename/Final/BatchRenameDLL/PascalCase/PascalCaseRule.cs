using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PascalCase
{
    public class PascalCaseRule : IContract, INotifyPropertyChanged, ICloneable
    {
        public Dictionary<string, Object> Input { get; set; }

        public string Name => "Pascal Case";
        public string Description => "Convert the first character of each word in the name is capitalized and remove all spaces.";

        public string Type => "File and Folder";

        public event PropertyChangedEventHandler PropertyChanged;

        public PascalCaseRule()
        {
            Input = new Dictionary<string, object>();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string Rename(string original)
        {
            StringBuilder result = new();

            // Tach chuoi original thanh cac chuoi con boi dau " "
            string[] tokens = original.Split(' ', StringSplitOptions.None);
            foreach (string token in tokens)
            {
                if (token == "") continue;
                string firstCharacter = token[0].ToString().ToUpper();
                result.Append(firstCharacter);
                result.Append(token.Substring(1));
            }

            return result.ToString();
        }

        public void Reset() { }

        public bool Show()
        {
            return true;
        }
    }
}
