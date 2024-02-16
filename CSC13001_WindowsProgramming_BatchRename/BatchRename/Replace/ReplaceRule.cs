using IPluginContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Replace
{
    public class ReplaceRule : IRenameRule
    {
        public List<string> Needles { get; set; }
        public string Replacer { get; set; }

        public ReplaceRule(List<string> needles, string replacer)
        {
            Needles = needles;
            Replacer = replacer;
        }

        public string Rename(string original)
        {
            StringBuilder result = new();
            char newChar = Convert.ToChar(Replacer);

            result.Append(original);
            foreach (string character in Needles) 
            {
                char oldChar = Convert.ToChar(character);
                result.Replace(oldChar, newChar);
            }

            return result.ToString();
        }

        public static void ShowWindow()
        {
            ReplaceWindow window = new();
            window.Show();
        }
    }
}
