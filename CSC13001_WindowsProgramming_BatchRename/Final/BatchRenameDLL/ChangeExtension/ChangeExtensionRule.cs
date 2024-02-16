using Contract;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ChangeExtension
{
    public class ChangeExtensionRule : ValidationRule, IContract, INotifyPropertyChanged, ICloneable
    {
        public Dictionary<string, Object> Input { get; set; }

        public string Name => "Change Extension";
        public string Description => "Change the extension to another extension (no conversion).";

        public string Type => "File";

        public event PropertyChangedEventHandler PropertyChanged;

        public ChangeExtensionRule()
        {
            Input = new Dictionary<string, object>();
            Input.Add("NewExtension", "");
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
                // Change extension for file
                int lastPosition = original.LastIndexOf('.');
                result.Append(original.Substring(0, lastPosition + 1));
                result.Append(Input["NewExtension"].ToString());
            }
            else
                result.Append(original);
            return result.ToString();
        }

        public void Reset() { }

        public bool Show()
        {
            var newRule = new ChangeExtensionRule() { Input = this.Input };
            var screen = new ChangeExtensionWindow(newRule);
            if (screen.ShowDialog() == true)
            {
                newRule = screen.GetInput;
                Input["NewExtension"] = newRule.Input["NewExtension"];
                return true;
            }

            return false;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex(@"([a-zA-Z0-9])+$");
            ValidationResult result = ValidationResult.ValidResult;

            try
            {
                if (((string)value).Length > 0)
                    Input["NewExtension"] = (string)value;
            }
            catch (Exception e)
            {
                result = new ValidationResult(false, "Illegal character or " + e.Message);
                return result;
            }

            if (!regex.IsMatch((string)value))
                result = new ValidationResult(false, "An extension file name just contain any of the following characters: a-z, A-Z, 0-9");

            return result;
        }
    }
}
