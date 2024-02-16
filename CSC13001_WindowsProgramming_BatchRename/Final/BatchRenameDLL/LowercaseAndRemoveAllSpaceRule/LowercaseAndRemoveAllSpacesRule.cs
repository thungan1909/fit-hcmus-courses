using Contract;
using System;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;

namespace LowercaseAndRemoveAllSpacesRule
{
    public class LowercaseAndRemoveAllSpacesRule : IContract, INotifyPropertyChanged, ICloneable
    {
        public Dictionary<string, Object> Input { get; set; }

        public string Name => "Lowercase And Remove Spaces";
        public string Description => "Convert all characters to lowercase, and remove all spaces.";

        public string Type => "File and Folder";

        public event PropertyChangedEventHandler PropertyChanged;

        public LowercaseAndRemoveAllSpacesRule()
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
            //Lowercase
            if (Path.HasExtension(original))
            {
                int lastPosition = original.LastIndexOf('.');
                fileName = original.Substring(0, lastPosition + 1);
                extension = original.Substring(lastPosition + 1);         
            }
            fileName = fileName.ToLower();
            if (Path.HasExtension(original))
                fileName = String.Concat(fileName, extension);

            //Remove All Spaces
            while (fileName.IndexOf(' ') != -1)
            {
                int pos = fileName.IndexOf(' ');
                fileName = fileName.Remove(pos, 1);
            }

            return fileName;
        }

        public void Reset() { }

        public bool Show()
        {
            return true;
        }
    }
}
