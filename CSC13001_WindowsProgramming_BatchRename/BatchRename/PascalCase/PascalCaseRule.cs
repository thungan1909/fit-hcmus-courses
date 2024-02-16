using IPluginContract;
using System;
using System.Text;

namespace PascalCase
{
    public class PascalCaseRule : IRenameRule
    {
        public string Rename(string original)
        {
            StringBuilder result = new();

            // Tach chuoi original thanh cac chuoi con boi dau " "
            string[] tokens = original.Split(' ', StringSplitOptions.None);
            foreach (string token in tokens) {
                if (token == "") continue;
                String firstCharacter = token[0].ToString().ToUpper();
                result.Append(firstCharacter);
                result.Append(token.Substring(1));
            }

            return result.ToString();
        }

        public static void ShowWindow()
        {
            PascalCaseWindow window = new();
            window.Show();
        }
    }
}
