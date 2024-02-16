using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch_Rename
{
    public class Preview : ICloneable
    {
        public List<CustomItem> Items { get; set; }
        public List<IContract> Actions { get; set; }

        public Preview() { }

        public Preview(Preview preview)
        {
            Items = new List<CustomItem>(preview.Items.Count);
            foreach (var item in preview.Items)
                Items.Add(new CustomItem(item));
            Actions = new List<IContract>(preview.Actions.Count);
            foreach (var action in preview.Actions)
                Actions.Add(action);
        }

        public void PreviewItems()
        {
            foreach (var item in Items)
            {
                if (item.ItemType.Equals("File"))
                {
                    if (item.DesDirectory != item.Directory)
                        File.Copy(item.Directory + "\\" + item.NewName, item.DesDirectory + "\\" + item.NewName);
                }
                else
                {
                    if (item.DesDirectory != item.Directory)
                        Directory.CreateDirectory(item.DesDirectory + "\\" + item.NewName);
                }
            }

            foreach (var rule in Actions)
            {
                rule.Reset();
                foreach (var item in Items)
                {
                    string newName = rule.Rename(item.NewName);
                    try
                    {
                        if (item.ItemType.Equals("File"))
                        {
                            File.Move(item.DesDirectory + "\\" + item.NewName, item.DesDirectory + "\\" + newName);
                        }
                        else
                        {
                            if (rule.Type.Equals("File"))
                            {
                                item.Status = "No Change";
                                continue;
                            }

                            Directory.Move(item.DesDirectory + "\\" + item.NewName, item.DesDirectory + "\\" + newName);
                        }

                        item.Status = "Succeed";
                        item.NewName = newName;
                    }
                    catch (Exception e)
                    {
                        item.Status = "Error";
                        if (item.DesDirectory != item.Directory)
                        {
                            if (item.ItemType.Equals("File"))
                                File.Delete(item.DesDirectory + "\\" + item.NewName);
                            else
                                Directory.Delete(item.DesDirectory + "\\" + item.NewName);
                        }
                    }
                }
            }

            foreach (var item in Items)
            {
                if (item.NewName.Equals(item.ItemName) && item.Status.Equals("Error"))
                    item.Status = "Error";
                else
                    item.Status = "Succeed";

                try
                {
                    if (item.ItemType.Equals("File"))
                    {
                        if (item.DesDirectory != item.Directory)
                            File.Delete(item.DesDirectory + "\\" + item.NewName);
                        else
                            File.Move(item.DesDirectory + "\\" + item.NewName, item.DesDirectory + "\\" + item.ItemName);
                    }
                    else
                    {
                        if (item.DesDirectory != item.Directory)
                            Directory.Delete(item.DesDirectory + "\\" + item.NewName);
                        else
                            Directory.Move(item.DesDirectory + "\\" + item.NewName, item.DesDirectory + "\\" + item.ItemName);
                    }
                }
                catch (Exception e)
                {

                }
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
