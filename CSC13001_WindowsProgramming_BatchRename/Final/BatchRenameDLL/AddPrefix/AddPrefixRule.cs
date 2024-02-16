using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace AddPrefix
{
    public class AddPrefixRule : ValidationRule, IContract, INotifyPropertyChanged, ICloneable
    {
        public Dictionary<string, Object> Input { get; set; }

        public string Name => "Add Prefix";
        public string Description => "The string is added to the beginning of the filename or folder name.";

        public string Type => "File and Folder";

        public event PropertyChangedEventHandler PropertyChanged;

        public AddPrefixRule()
        {
            Input = new Dictionary<string, object>();
            Input.Add("Prefix", "");
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string Rename(string original)
        {
            return string.Concat(Input["Prefix"].ToString(), original);
        }

        public void Reset() { }

        public bool Show()
        {
            var newRule = new AddPrefixRule() { Input = this.Input };
            var screen = new AddPrefixWindow(newRule);
            if (screen.ShowDialog() == true)
            {
                newRule = screen.GetInput;
                Input["Prefix"] = newRule.Input["Prefix"];
                return true;
            }

            return false;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            StringBuilder specialCharacters = new();
            specialCharacters.Append(@"\\|\/|\||:|\*|\?|\");
            specialCharacters.Append("\"");
            specialCharacters.Append("|<|>");
            Regex regex = new Regex(specialCharacters.ToString());
            ValidationResult result = ValidationResult.ValidResult;

            try
            {
                if (((string)value).Length > 0)
                    Input["Prefix"] = (string)value;
            }
            catch (Exception e)
            {
                result = new ValidationResult(false, "Illegal character or " + e.Message);
                return result;
            }

            if (regex.IsMatch((string)value))
                result = new ValidationResult(false, "A file name can't contain any of the following characters: \\ / : * ? \" < > |");

            return result;
        }
    }
}
