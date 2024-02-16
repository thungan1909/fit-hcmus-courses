using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch_Rename
{
    public class CustomItem : INotifyPropertyChanged
    {
        public string ItemName { get; set; }

        public string Directory { get; set; }

        public string DesDirectory { get; set; }

        public string ItemType { get; set; }

        public string Status { get; set; }

        public string NewName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomItem(string pathFile)
        {
            int filenamePosition = pathFile.LastIndexOf("\\");
            Directory = pathFile.Substring(0, filenamePosition);
            DesDirectory = Directory;
            ItemName = pathFile.Substring(filenamePosition + 1);
            if (System.IO.Path.HasExtension(pathFile))
                ItemType = "File";
            else
                ItemType = "Folder";
            Status = "";
            NewName = ItemName;
        }

        public CustomItem(CustomItem item)
        {
            ItemName = item.ItemName;
            Directory = item.Directory;
            DesDirectory = item.DesDirectory;
            ItemType = item.ItemType;
            Status = item.Status;
            NewName = item.NewName;
        }
    }
}
