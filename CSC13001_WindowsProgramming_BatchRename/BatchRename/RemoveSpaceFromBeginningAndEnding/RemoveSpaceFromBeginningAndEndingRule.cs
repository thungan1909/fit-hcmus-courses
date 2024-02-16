using System;
using IPluginContract;
using System.Text;
namespace RemoveSpaceFromBeginningAndEnding
{
    public class RemoveSpaceFromBeginningAndEndingRule : IRenameRule
    {
        public RemoveSpaceFromBeginningAndEndingRule()
        {

        }

        public string Rename(string original)
        {
            int lastDocPosition = original.LastIndexOf('.');
            String fileName = original.Substring(0, lastDocPosition);
            String extension = original.Substring(lastDocPosition);
            while (fileName.IndexOf(' ') == 0)
            {
                fileName = fileName.Remove(0, 1);
            }
            int lastSpacePos =fileName.Length - 1;
            while (fileName.LastIndexOf(' ') == lastSpacePos)
            {
                fileName = fileName.Remove(lastSpacePos);
                lastSpacePos = fileName.Length - 1;
            }
            return String.Concat(fileName, extension);
                
        }

        public static void ShowWindow()
        {
            RemoveSpaceFromBeginningAndEndingWindow window = new();
            window.Show();
        }
    }
}