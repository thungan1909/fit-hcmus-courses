using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace AddCounter
{
    public class AddCounterRule : ValidationRule, IContract, INotifyPropertyChanged, ICloneable
    {
        public Dictionary<string, Object> Input { get; set; }

        public string Name => "Add Counter";
        public string Description => "The counter is added to the end of the filename or folder name.";

        public string Type => "File and Folder";

        public event PropertyChangedEventHandler PropertyChanged;

        public AddCounterRule()
        {
            Input = new Dictionary<string, object>();
            Input.Add("StartValue", 0);
            Input.Add("Step", 0);
            Input.Add("NumberOfDigits", 0);
            Input.Add("Current", 0);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        
        public string Rename(string original)
        {
            string filename = original;
            string extension = "";
            StringBuilder result = new();
            if (Path.HasExtension(original))
            {
                int dotExtension = original.LastIndexOf('.');
                filename = original.Substring(0, dotExtension);
                extension = original.Substring(dotExtension);
            }

            result.Append(filename);
            result.Append((Convert.ToInt32(Input["StartValue"]) + Convert.ToInt32(Input["Current"]) * Convert.ToInt32(Input["Step"])).ToString($"D{Convert.ToInt32(Input["NumberOfDigits"])}"));
            result.Append(extension);

            int temp = Convert.ToInt32(Input["Current"]);
            temp++;
            Input["Current"] = temp;

            return result.ToString();
        }

        public void Reset()
        {
            Input["Current"] = 0;
        }

        public bool Show()
        {
            var newRule = new AddCounterRule() { Input = this.Input };
            var screen = new AddCounterWindow(newRule);
            if (screen.ShowDialog() == true)
            {
                newRule = screen.GetInput;
                Input["StartValue"] = Convert.ToInt32(newRule.Input["StartValue"]);
                Input["Step"] = Convert.ToInt32(newRule.Input["Step"]);
                Input["NumberOfDigits"] = Convert.ToInt32(newRule.Input["NumberOfDigits"]);
                Input["Current"] = 0;
                return true;
            }

            return false;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int number = 0;
            ValidationResult result = ValidationResult.ValidResult;

            try
            {
                if (((string)value).Length > 0)
                    number = Int32.Parse((string)value);
            }
            catch (Exception e)
            {
                result = new ValidationResult(false, "The input value should contain only numbers.");
                return result;
            }

            return result;
        }
    }
}
