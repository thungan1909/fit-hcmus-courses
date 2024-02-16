using Contract;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace AddSuffix
{
    public class AddSuffixRule : ValidationRule, IContract, INotifyPropertyChanged, ICloneable
    {
        public Dictionary<string, Object> Input { get; set; }

        public string Name => "Add Suffix";
        public string Description => "The string is added to the end of the filename or folder name.";

        public string Type => "File and Folder";

        public event PropertyChangedEventHandler PropertyChanged;

        public AddSuffixRule()
        {
            Input = new Dictionary<string, object>();
            Input.Add("Suffix", "");
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string Rename(string original)
        {
            StringBuilder result = new();
            if (Path.HasExtension(original))
            {
                // Add suffix for file
                int lastPosition = original.LastIndexOf('.');
                result.Append(original.Substring(0, lastPosition));
                result.Append(Input["Suffix"].ToString());
                result.Append(original.Substring(lastPosition));
            }
            else
            {
                // Add suffix for folder
                result.Append(original);
                result.Append(Input["Suffix"].ToString());
            }
            return result.ToString();
        }

        public void Reset() { }

        public bool Show()
        {
            var newRule = new AddSuffixRule() { Input = this.Input };
            var screen = new AddSuffixWindow(newRule);
            if (screen.ShowDialog() == true)
            {
                newRule = screen.GetInput;
                Input["Suffix"] = newRule.Input["Suffix"];
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
                    Input["Suffix"] = (string)value;
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
