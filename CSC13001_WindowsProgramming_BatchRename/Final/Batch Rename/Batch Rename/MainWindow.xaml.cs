using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Contract;
using Fluent;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Batch_Rename
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {

        BindingList<CustomItem> _items;
        List<IContract> _prototypes;
        BindingList<IContract> _actions;
        BindingList<string> _presets;
        string cbxChose;
        string projectPath;
        bool isPreview, isSelectedDesFolder;

        public MainWindow()
        {
            InitializeComponent();
            _items = new BindingList<CustomItem>();
            _prototypes = new List<IContract>();
            _actions = new BindingList<IContract>();
            _presets = new BindingList<string>();
            cbxChose = "";
            projectPath = "";
            isPreview = false;
            isSelectedDesFolder = false;
        }

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Left = Batch_Rename.Properties.Settings.Default.Left;
            Top = Batch_Rename.Properties.Settings.Default.Top;

            Width = Batch_Rename.Properties.Settings.Default.WindowWidth;
            Height = Batch_Rename.Properties.Settings.Default.WindowHeight;

            projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string dllFolder = projectPath + "\\dll";
            var fis = new DirectoryInfo(dllFolder).GetFiles("*.dll");

            foreach (var f in fis)  //Lan luot duyet qua cac file dll
            {
                var assembly = Assembly.LoadFile(f.FullName);
                var types = assembly.GetTypes();
                foreach (var t in types)
                {
                    if (t.IsClass && typeof(IContract).IsAssignableFrom(t))
                    {
                        _prototypes.Add((IContract)Activator.CreateInstance(t));
                    }
                }
            }

            readPreset();

            ListItems.ItemsSource = _items;
            ListRules.ItemsSource = _actions;
            CbxRules.ItemsSource = _prototypes;
            CbxPresets.ItemsSource = _presets;
        }

        private void RibbonWindow_Closing(object sender, CancelEventArgs e)
        {
            Batch_Rename.Properties.Settings.Default.Left = (int)Left;
            Batch_Rename.Properties.Settings.Default.Top = (int)Top;

            Batch_Rename.Properties.Settings.Default.WindowWidth = (int)Width;
            Batch_Rename.Properties.Settings.Default.WindowHeight = (int)Height;

            Batch_Rename.Properties.Settings.Default.Save();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (ListItems.Items.Count == 0)
            {
                MessageBox.Show("Please add file or folder.");
                return;
            }

            if (ListRules.Items.Count == 0)
            {
                MessageBox.Show("Please add rule.");
                return;
            }

            if (!isSelectedDesFolder)
            {
                string desFolderPath = ChangeDesFolder();
                if (!desFolderPath.Equals(""))
                    foreach (var item in _items)
                        item.DesDirectory = desFolderPath;
            }

            if (isPreview)
            {
                RenameFile();
                isSelectedDesFolder = false;
            }
            else
            {
                var result = MessageBox.Show("Do you want to rename files without preview?", "Batch Rename", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        RenameFile();
                        isSelectedDesFolder = false;
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private string ChangeDesFolder()
        {
            string newFolderPath = "";
            var result = MessageBox.Show("Do you want to move all the files and folders to another folder?", "Batch Rename", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                isPreview = false;
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                dialog.Multiselect = false;
                
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    isSelectedDesFolder = true;
                    newFolderPath = dialog.FileName;
                }
            }

            return newFolderPath;
            
        }

        private void RenameFile()
        {
            foreach (IContract rule in _actions)
            {
                rule.Reset();
                foreach (CustomItem item in _items)
                {
                    item.NewName = rule.Rename(item.NewName);
                    try
                    {
                        if (item.ItemType.Equals("File"))
                        {
                            if (item.DesDirectory != item.Directory)
                                File.Copy(item.Directory + "\\" + item.ItemName, item.DesDirectory + "\\" + item.ItemName);
                            File.Move(item.DesDirectory + "\\" + item.ItemName, item.DesDirectory + "\\" + item.NewName);
                        }
                        else
                        {
                            if (rule.Type.Equals("File"))
                            {
                                item.Status = "No Change";
                                continue;
                            }

                            if (item.DesDirectory != item.Directory)
                            {
                                Directory.CreateDirectory(item.DesDirectory + "\\" + item.ItemName);
                                var files = Directory.GetFiles(item.Directory + "\\" + item.ItemName);
                                foreach (var file in files)
                                {
                                    string name = file.Substring(file.LastIndexOf("\\") + 1);
                                    File.Copy(file, item.DesDirectory + "\\" + item.ItemName + "\\" + name);
                                }
                            }
                            Directory.Move(item.DesDirectory + "\\" + item.ItemName, item.DesDirectory + "\\" + item.NewName);
                        }

                        item.ItemName = item.NewName;
                        item.Directory = item.DesDirectory;
                        item.Status = "Succeed";
                    }
                    catch (Exception e)
                    {
                        item.NewName = item.ItemName;
                        item.DesDirectory = item.Directory;
                        item.Status = "Error";
                    }
                }
            }

            MessageBox.Show("Done to rename files and folders.");
        }

        private void BtnAddFiles_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Multiselect = true;
            
            if (true == RbnDirectlyFile.IsChecked)
            {
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    isPreview = false;
                    isSelectedDesFolder = false;
                    
                    foreach (string filename in dialog.FileNames)
                    {
                        CustomItem customFile = new CustomItem(filename);

                        bool canAdd = true;
                        foreach (var item in _items)
                        {
                            if (filename.Equals(item.Directory + "\\" + item.ItemName))
                            {
                                MessageBox.Show("You added this file.", filename, MessageBoxButton.OK, MessageBoxImage.Information);
                                canAdd = false;
                                break;
                            }

                            if (customFile.Directory.Contains(item.Directory + "\\" + item.ItemName) && item.ItemType.Equals("Folder"))
                            {
                                MessageBox.Show("You can't add the folder/subfolder/file of the selected files and folders.", filename, MessageBoxButton.OK, MessageBoxImage.Information);
                                canAdd = false;
                                break;
                            }
                        }

                        if (canAdd)
                            _items.Add(customFile);
                    }
                }
            }
            
            if (true == RbnFolder.IsChecked)
            {
                dialog.IsFolderPicker = true;
                Stack<string> folders = new Stack<string>();
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    isPreview = false;
                    isSelectedDesFolder = false;
                    foreach (string foldername in dialog.FileNames)
                    {
                        string path = System.IO.Path.GetFullPath(foldername);
                        folders.Push(path);
                        folders = BrowseAllFileFromFolders(folders);
                    }
                }
            }

            UpdateStatusFilesAndFolders();
        }

        private void BtnAddFolders_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Multiselect = true;
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                isPreview = false;
                isSelectedDesFolder = false;
                
                foreach (string foldername in dialog.FileNames)
                {
                    string path = System.IO.Path.GetFullPath(foldername);
                    CustomItem customFolder = new CustomItem(path);

                    bool canAdd = true;
                    foreach (var item in _items)
                    {
                        if (foldername.Equals(item.Directory + "\\" + item.ItemName) && item.ItemType.Equals("Folder"))
                        {
                            MessageBox.Show("You added this folder.", foldername, MessageBoxButton.OK, MessageBoxImage.Information);
                            canAdd = false;
                            break;
                        }

                        if ((item.Directory.Contains(foldername) && item.ItemType.Equals("File"))
                            || ((customFolder.Directory.Equals(item.Directory + "\\" + item.ItemName) || item.Directory.Equals(foldername)) && item.ItemType.Equals("Folder"))) 
                        {
                            MessageBox.Show("You can't add the folder/subfolder/file of the selected files and folders.", foldername, MessageBoxButton.OK, MessageBoxImage.Information);
                            canAdd = false;
                            break;
                        }
                    }

                    if (canAdd)
                        _items.Add(customFolder);
                }

                UpdateStatusFilesAndFolders();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (_items.Count == 0)
            {
                MessageBox.Show("Empty files and folders list!");
                return;
            }

            if (ListItems.SelectedItems.Count == 0)
            {
                MessageBox.Show("No file or folder is selected!");
                return;
            }

            var result = MessageBox.Show("Do you want to delete selected files and folders?", "Batch Rename", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                isPreview = false;
                while (ListItems.SelectedItems.Count != 0)
                {
                    int index = ListItems.Items.IndexOf(ListItems.SelectedItems[0]);
                    _items.RemoveAt(index);
                }
                UpdateStatusFilesAndFolders();
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to clear all files and folders?", "Batch Rename", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                _items.Clear();
        }

        private void BtnSavePreset_Click(object sender, RoutedEventArgs e)
        {
            if (ListRules.Items.Count == 0)
            {
                MessageBox.Show("Please choose a rule to save.");
                return;
            }

            // Gọi window SavePreset cho phép người dùng nhập tên cho preset cần lưu.
            var _fileName = new Preset();
            var screen = new SavePresetConfig(_fileName);

            if (screen.ShowDialog() == true)
            {
                _fileName = screen.GetFileName;

                // Lưu file preset
                string folder = projectPath + "\\Preset";
                string presetFilename = folder + "\\" + _fileName.presetName + ".json";

                var presetJson = JsonConvert.SerializeObject(_actions, Formatting.Indented);

                using (StreamWriter sw = new StreamWriter(presetFilename))
                {
                    sw.Write(presetJson);
                }

                MessageBox.Show("Save successfully.");
                readPreset();
            }
            else
                MessageBox.Show("Save failed.");
        }

        private void BtnDeletePreset_Click(object sender, RoutedEventArgs e)
        {
            if (CbxPresets.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a preset to delete.");
                return;
            }

            var result = MessageBox.Show("Do you want to delete " + _presets[CbxPresets.SelectedIndex] + " preset?", "Batch Rename", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                string presetFilename = projectPath + "\\Preset" + "\\" + _presets[CbxPresets.SelectedIndex] + ".json";
                File.Delete(presetFilename);
                _presets.RemoveAt(CbxPresets.SelectedIndex);
                MessageBox.Show("Delete successfully.");
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to clear all files, folders, and rules?", "Batch Rename", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                _items.Clear();
                _actions.Clear();
                TxtRuleNameDesc.Text = "";
                TxtDesc.Text = "";
                isPreview = false;
                CbxPresets.SelectedIndex = -1;
                CbxRules.SelectedIndex = -1;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if ((CbxPresets.SelectedIndex < 0 && CbxRules.SelectedIndex < 0) || cbxChose.Length == 0)
            {
                MessageBox.Show("Please chose a rule or a preset.");
                return;
            }

            isPreview = false;
            if (cbxChose.Equals("rule"))
            {
                IContract selectedRule = _prototypes[CbxRules.SelectedIndex];
                if (selectedRule.Show())
                    _actions.Add(selectedRule);
                cbxChose = "";
            }

            if (cbxChose.Equals("preset"))
            {
                StringBuilder presetFile = new();
                presetFile.Append(projectPath + "\\Preset");
                presetFile.Append("\\");
                presetFile.Append(_presets[CbxPresets.SelectedIndex]);
                presetFile.Append(".json");

                string content = "";
                using (var reader = new StreamReader(presetFile.ToString()))
                {
                    content = reader.ReadToEnd();
                    reader.Close();
                }

                var _listRuleInPreset = JsonConvert.DeserializeObject<List<JsonRuleFormat>>(content);
                foreach (var rule in _listRuleInPreset)
                {
                    foreach (var r in _prototypes)
                    {
                        if (r.Name == rule.Name)
                        {
                            var action = (IContract)Activator.CreateInstance(r.GetType());
                            action.Input = rule.Input;
                            _actions.Add(action);
                        }
                    }
                }
                cbxChose = "";
            }

            UpdateStatusFilesAndFolders();
        }

        private void BtnDeleteRule_Click(object sender, RoutedEventArgs e)
        {
            if (_actions.Count == 0)
            {
                MessageBox.Show("Empty renaming rules list!");
                return;
            }

            if (ListRules.SelectedItems.Count == 0)
            {
                MessageBox.Show("No renaming rule is selected!");
                return;
            }

            var result = MessageBox.Show("Do you want to delete selected rules?", "Batch Rename", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                isPreview = false;
                while (ListRules.SelectedItems.Count != 0)
                {
                    int index = ListRules.Items.IndexOf(ListRules.SelectedItems[0]);
                    _actions.RemoveAt(index);
                }

                UpdateStatusFilesAndFolders();
            }
        }

        private void ListItems_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                isPreview = false;
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string foldername in filePaths)
                {
                    string path = System.IO.Path.GetFullPath(foldername);

                    if (System.IO.Path.HasExtension(foldername))
                    {
                        CustomItem customFile = new CustomItem(path);
                        _items.Add(customFile);
                    }
                    else
                    {
                        CustomItem customFolder = new CustomItem(path);
                        _items.Add(customFolder);
                    }
                }

                UpdateStatusFilesAndFolders();
            }
        }

        private Stack<string> BrowseAllFileFromFolders(Stack<string> folderPath)
        {
            if (folderPath.Count == 0)
                return folderPath;

            while (folderPath.Count != 0)
            {
                string p = folderPath.Pop();
                // Duyet cac thu muc con
                string[] subFolderPaths = Directory.GetDirectories(p);
                foreach (string subFolderPath in subFolderPaths)
                    folderPath.Push(subFolderPath);

                // Duyet cac tap tin con
                string[] filePaths = Directory.GetFiles(p);
                foreach (string filename in filePaths)
                {
                    bool canAdd = true;
                    CustomItem customFile = new CustomItem(filename);

                    foreach (var item in _items)
                    {
                        if (filename.Equals(item.Directory + "\\" + item.ItemName))
                        {
                            MessageBox.Show("You added this file.", filename, MessageBoxButton.OK, MessageBoxImage.Information);
                            canAdd = false;
                            break;
                        }

                        if (customFile.Directory.Contains(item.Directory + "\\" + item.ItemName) && item.ItemType.Equals("Folder"))
                        {
                            MessageBox.Show("You can't add the folder/subfolder/file of the selected files and folders.", filename, MessageBoxButton.OK, MessageBoxImage.Information);
                            canAdd = false;
                            break;
                        }
                    }

                    if (canAdd)
                        _items.Add(customFile);
                }

                // Goi de quy
                folderPath = BrowseAllFileFromFolders(folderPath);
            }

            return folderPath;
        }

        private void ListRules_MouseUp(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = ListRules.SelectedIndex;
            if (selectedIndex < 0) return;
            TxtRuleNameDesc.Text = _actions[ListRules.SelectedIndex].Name;
            TxtDesc.Text = _actions[ListRules.SelectedIndex].Description;
        }

        private void CbxRules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxChose = "rule";
        }

        private void CbxPresets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxChose = "preset";
        }

        private void readPreset()
        {
            if (_presets.Count > 0)
                _presets.Clear();
            string presetFolder = projectPath + "\\Preset";
            var pre = new DirectoryInfo(presetFolder).GetFiles("*.json");
            foreach (var p in pre)
            {
                _presets.Add(p.Name.Substring(0, p.Name.Length - 5));
            }
        }

        private void ListRules_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = ListRules.SelectedIndex;
            if (selectedIndex < 0) return;
            _actions[selectedIndex].Show();
        }

        private void BtnPreview_Click(object sender, RoutedEventArgs e)
        {
            if (_items.Count == 0 || _actions.Count == 0)
            {
                MessageBox.Show("Choose a file or folder and a rule to preview result.");
                return;
            }

            isPreview = true;
            var items = _items.ToList();
            var actions = _actions.ToList();
            var _preview = new Preview(new Preview() { Items = items, Actions = actions });
            var previewScreen = new PreviewWindow(_preview);
            previewScreen.Show();
        }

        private void UpdateStatusFilesAndFolders()
        {
            foreach (var item in _items)
                item.Status = "";
        }
    }
}
