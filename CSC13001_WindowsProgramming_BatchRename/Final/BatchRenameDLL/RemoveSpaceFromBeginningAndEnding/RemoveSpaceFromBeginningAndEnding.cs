using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace RemoveSpaceFromBeginningAndEnding
{
    public class RemoveSpaceFromBeginningAndEndingRule : IContract, INotifyPropertyChanged, ICloneable
    {
        public Dictionary<string, Object> Input { get; set; }

        public string Name => "Remove Spaces";
        public string Description => "Remove all space from the beginning and the ending of the name.";

        public string Type => "File and Folder";

        public event PropertyChangedEventHandler PropertyChanged;

        public RemoveSpaceFromBeginningAndEndingRule()
        {
            Input = new Dictionary<string, object>();
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public string Rename(string original)
        {
            string fileName = original;
            string extension = "";
            if (Path.HasExtension(original))
            {
                int lastDocPosition = original.LastIndexOf('.');
                fileName = original.Substring(0, lastDocPosition);
                extension = original.Substring(lastDocPosition);
            }

            while (fileName.IndexOf(' ') == 0)
            {
                fileName = fileName.Remove(0, 1);
            }

            int lastSpacePos = fileName.Length - 1;
            while (fileName.LastIndexOf(' ') == lastSpacePos)
            {
                fileName = fileName.Remove(lastSpacePos);
                lastSpacePos = fileName.Length - 1;
            }

            return String.Concat(fileName, extension);
        }

        public void Reset() { }

        public bool Show()
        {
            return true;
        }

    }
}
