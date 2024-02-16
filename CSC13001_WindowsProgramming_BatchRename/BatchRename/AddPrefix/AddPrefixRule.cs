using System;
using IPluginContract;
using System.Text;

namespace AddPrefix
{
    public class AddPrefixRule : IRenameRule
    {
        public string Prefix { get; set; }

        public AddPrefixRule(string prefix)
        {
           Prefix = prefix;
        }

        public string Rename(string original)
        {
            //  int lastPosition = original.LastIndexOf('.');
            //  StringBuilder result = new();
            return string.Concat(Prefix, original);
        }

        public static void ShowWindow()
        {
            AddPrefixWindow window = new();
            window.Show();
        }
    }
}
