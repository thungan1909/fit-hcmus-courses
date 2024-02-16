using Contract;
using System;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Globalization;

namespace Replace
{
    public class ReplaceRule : ValidationRule, IContract, INotifyPropertyChanged, ICloneable
    {
        public string Name => "Replace";

        public string Description => "Replace input characters divided by a comma into one character.";

        public Dictionary<string, Object> Input { get; set; }

        public string Type => "File and Folder";

        public event PropertyChangedEventHandler PropertyChanged;

        public ReplaceRule()
        {
            Input = new Dictionary<string, object>();
            Input.Add("OldCharacter", "");
            Input.Add("NewCharacter", "");
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string Rename(string original)
        {
            StringBuilder result = new();
            string filename = original;
            string extension = "";
            if (Path.HasExtension(original))
            {
                int lastDotPostion = original.LastIndexOf(".");
                filename = original.Substring(0, lastDotPostion);
                extension = original.Substring(lastDotPostion);
            }

            if (Input["OldCharacter"].ToString().StartsWith("/") && Input["OldCharacter"].ToString().EndsWith("/g"))
            {
                string inputOldCharacter = Input["OldCharacter"].ToString();
                string oldCharacter = inputOldCharacter.Substring(1, inputOldCharacter.Length - 3);
                Regex regex = new Regex(oldCharacter);
                string newFilename = regex.Replace(filename, Input["NewCharacter"].ToString());
                result.Append(newFilename);
            }
            else
            {
                string[] tokens = Input["OldCharacter"].ToString().Split(",");
                result.Append(filename);
                foreach (string token in tokens)
                    result.Replace(token, Input["NewCharacter"].ToString());
            }
            result.Append(extension);
            return result.ToString();
        }

        public void Reset() { }

        public bool Show()
        {
            var ip = new ReplaceRule() { Input = this.Input };
            var screen = new ReplaceWindow(ip);

            if (screen.ShowDialog() == true)
            {
                ip = screen.GetInput;
                Input["OldCharacter"] = ip.Input["OldCharacter"];
                Input["NewCharacter"] = ip.Input["NewCharacter"];
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
                    Input["NewCharacter"] = (string)value;
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
