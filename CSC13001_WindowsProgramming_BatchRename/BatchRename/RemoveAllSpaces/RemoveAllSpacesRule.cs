using System;
using IPluginContract;
using System.Text;

namespace RemoveAllSpaces
{
    public class RemoveAllSpacesRule : IRenameRule
    {
        public RemoveAllSpacesRule()
        {
        }

        public string Rename(string original)
        {
            while (original.IndexOf(' ') != -1)
            {
                int pos = original.IndexOf(' ');
                original = original.Remove(pos, 1);
            }
           
            return original;
        }

        public static void ShowWindow()
        {
            RemoveAllSpacesWindow window = new();
            window.Show();
        }
    }
}
