using System;
using IPluginContract;
using System.Text;

namespace Lowercase
{
    public class LowercaseRule : IRenameRule
    {
        public LowercaseRule()
        {

        }

        public string Rename(string original)
        {

            int lastPosition = original.LastIndexOf('.');
            String fileName = original.Substring(0, lastPosition + 1);
            String extension = original.Substring(lastPosition + 1);

            fileName = fileName.ToLower();
            return String.Concat(fileName, extension);
        }

        public static void ShowWindow()
        {
            LowercaseWindow window = new();
            window.Show();
        }
    }
}
