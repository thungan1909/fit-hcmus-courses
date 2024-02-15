using Contract;
using System;
using System.Collections.Generic;
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

namespace AbstractFactoryDemo
{
    /// <summary>
    /// Interaction logic for ConfigWindows.xaml
    /// </summary>
    public partial class ConfigWindows : Window
    {
        public ConfigWindows()
        {
            InitializeComponent();
        }
        List<IUI> _uiPrototypes = new List<IUI>();
        List<IBus> _busPrototypes = new List<IBus>();
        List<IData> _dataPrototypes = new List<IData>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //Nap danh sach cac tap tin dll

            string folder = AppDomain.CurrentDomain.BaseDirectory;
            var fis = new DirectoryInfo(folder).GetFiles("*.dll");
            foreach (var f in fis)  //Lan luot duyet qua cac file dll
            {
                //var domain = AppDomain.CurrentDomain;
                var assembly = Assembly.LoadFile(f.FullName);
                var types = assembly.GetTypes();
                foreach
                    (var t in types)
                {
                    if (t.IsClass)
                    {
                        if (typeof(IUI).IsAssignableFrom(t))
                        {
                            _uiPrototypes.Add((IUI)Activator.CreateInstance(t));
                        }
                        else if (typeof(IBus).IsAssignableFrom(t))
                        {
                            _busPrototypes.Add((IBus)Activator.CreateInstance(t));
                        }
                        else if (typeof(IData).IsAssignableFrom(t))
                        {
                            _dataPrototypes.Add((IData)Activator.CreateInstance(t));
                        }
                    }
                }
            }
            //Data binding len giao dien
            uiComboBox.ItemsSource = _uiPrototypes;
            busComboBox.ItemsSource = _busPrototypes;
            dataComboBox.ItemsSource = _dataPrototypes;

        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            var ui = uiComboBox.SelectedItem as IUI;
            var bus = busComboBox.SelectedItem as IBus;
            var data = dataComboBox.SelectedItem as IData;

            bus.DependsOn(data);
            ui.DependsOn(bus);

            var screen = new MainWindow(ui);
            screen.Show();

        }
    }
}
