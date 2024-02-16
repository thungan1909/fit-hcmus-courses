using System;
using IPluginContract;
using System.Text;

namespace ChangeExtension
{
    public class ChangeExtensionRule : IRenameRule
    {

        public string Extension { get; set; }

        public ChangeExtensionRule(string extension)
        {
            Extension = extension;
        }

        public string Rename(string original)
        {
            int lastPosition = original.LastIndexOf('.');
            StringBuilder result = new();
            result.Append(original.Substring(0, lastPosition+1));
            //     result.Append(Suffix);
            result.Append(Extension);
            return result.ToString();
        }

        public static void ShowWindow()
        {
            ChangeExtensionWindow window = new();
            window.Show();
        }
    }
}
