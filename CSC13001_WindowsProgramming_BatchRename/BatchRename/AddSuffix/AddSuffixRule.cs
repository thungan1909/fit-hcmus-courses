using System;
using IPluginContract;
using System.Text;

namespace AddSuffix
{
    public class AddSuffixRule : IRenameRule
    {
        public string Suffix { get; set; }

        public AddSuffixRule(string suffix)
        {
            Suffix = suffix;
        }

        public string Rename(string original)
        {
            int lastPosition = original.LastIndexOf('.');
            StringBuilder result = new();
            result.Append(original.Substring(0, lastPosition));
            result.Append(Suffix);
            result.Append(original.Substring(lastPosition));
            return result.ToString();
        }

        public static void ShowWindow()
        {
            AddSuffixWindow window = new();
            window.Show();
        }
    }
}
