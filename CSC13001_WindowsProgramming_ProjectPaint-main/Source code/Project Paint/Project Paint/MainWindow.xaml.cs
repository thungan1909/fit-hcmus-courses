using Contract;
using Microsoft.Win32;
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
using static Project_Paint.CustomBrush;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Project_Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Fluent.RibbonWindow
    {
        public MainWindow()
        {
           
            InitializeComponent();
        }
        bool _isDrawing = false;
        List<IShape> _shapes = new List<IShape>();
        Dictionary<IShape,CustomBrush> _preShapes = new Dictionary<IShape,CustomBrush>();
        IShape _preview;

        string _selectedShapeName = "";
        Dictionary<string, IShape> _prototypes =  new Dictionary<string, IShape>();
        Dictionary<int, List<Image>> images = new Dictionary<int, List<Image>>();
        string projectPath;
        CustomBrush _brush = new CustomBrush();
        Polyline polyLine;
        List<Polyline> _polylines = new List<Polyline>();
        Point polyStart;
        public double x_position;
        public double y_position;
        string cbxChose;
        private List<Canvas> UndoList = new List<Canvas>();
        private List<Canvas> RedoList = new List<Canvas>();
        private bool handleSize = true;
        private bool handleStyle = true;
        Pencil _pencil = new();
  
        public DoubleCollection _StrokeDashArray;
        private void canvas_MouseDown(object sender,
           MouseButtonEventArgs e)
        {

            if (_pencil.Action == "Pencil")
            {
                x_position = Convert.ToDouble(e.GetPosition(canvas).X);
                y_position = Convert.ToDouble(e.GetPosition(canvas).Y);
                polyStart = e.GetPosition(canvas);
                SetStyle();
                polyLine = new Polyline
                {
                    Stroke = _brush.ColorOutLineBrush,
                    StrokeThickness = _brush.currSize,
                     StrokeDashArray = _StrokeDashArray
                };
                if (polyLine != null)
                {
                    _polylines.Add(polyLine);
                }
               
                canvas.Children.Add(polyLine);
            }
            else
            {
                _isDrawing = true;

                Point pos = e.GetPosition(canvas);

                _preview.HandleStart(pos.X, pos.Y);
            }

            
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed && _pencil.Action == "Pencil")
            {
                _pencil.X = Convert.ToString(e.GetPosition(canvas).X);
                _pencil.Y = Convert.ToString(e.GetPosition(canvas).Y);
                Point currentPoint = e.GetPosition(canvas);
                if (polyStart != currentPoint)
                {
                    polyLine.Points.Add(currentPoint);
                }
            }
            else
            {
                if (_isDrawing)
                {
                    Point pos = e.GetPosition(canvas);
                    _preview.HandleEnd(pos.X, pos.Y);

                    // Xoá hết các hình vẽ cũ
                    canvas.Children.Clear();
                    // Vẽ lại các hình trước đó
                    foreach (var shape in _shapes)
                    {

                        UIElement element = shape.Draw();
                        canvas.Children.Add(element);
                    }
                    foreach (var po in _polylines)
                    {
                        canvas.Children.Add(po);
                    }
                    // Vẽ hình preview đè lên
                    canvas.Children.Add(_preview.Draw());
                  
                }
            }
        }

            private void canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (_pencil.Action != "Pencil")
            {
                _isDrawing = false;

                // Thêm đối tượng cuối cùng vào mảng quản lí
                Point pos = e.GetPosition(canvas);
                _preview.HandleEnd(pos.X, pos.Y);               
                _shapes.Add(_preview);

                // Sinh ra đối tượng mẫu kế
                _preview = _prototypes[_selectedShapeName].Clone(_brush);
                // Ve lai Xoa toan bo
                canvas.Children.Clear();

                // Ve lai tat ca cac 
                foreach (var shape in _shapes)
                {
                    var element = shape.Draw();
                    canvas.Children.Add(element);
                }
                foreach (var po in _polylines)
                {
                    canvas.Children.Add(po);
                }

            }

        }

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {

            projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string dllFolder = projectPath + "\\dll";
            var fis = new DirectoryInfo(dllFolder).GetFiles("*.dll");

            foreach (var f in fis)  //Lan luot duyet qua cac file dll
            {
                var assembly = Assembly.LoadFrom(f.FullName);
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.IsClass && typeof(IShape).IsAssignableFrom(type))
                    {
                        var shape = Activator.CreateInstance(type) as IShape;
                        _prototypes.Add(shape.Name, shape);
                    }
                }
            }
            foreach (var item in _prototypes)
            {
                var shape = item.Value as IShape;
                var button = new Button()
                {
                    Content = shape.Name,
                    Width = 80,
                    Height = 35,
                    Margin = new Thickness(5, 0, 5, 0),
                    Tag = shape.Name,
                };
                button.Click += prototypeButton_Click;
                prototypesStackPanel.Children.Add(button);
            }

            _selectedShapeName = _prototypes.First().Value.Name;
            _preview = _prototypes[_selectedShapeName].Clone(_brush);
          
        }


        private void prototypeButton_Click(object sender, RoutedEventArgs e)
        {
            _pencil.Action = null;
            _selectedShapeName = (sender as Button).Tag as string;
            _preview = _prototypes[_selectedShapeName];
        }

        private void CbxShapes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbxChose = "Shape";
        }

        private void RibbonWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        //BackStage: File
        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save change to Untitled?", "Project Paint", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    FileName = "Untitled",
                    Filter = "Images|*.png",
                    Title = "Save as",
                    RestoreDirectory = true
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    String fileName = saveFileDialog.FileName;
                    SaveBitmap(canvas, fileName);
                }
            }
            else if (result == MessageBoxResult.No)
            {

                canvas.Children.Clear();
                
                _shapes = new List<IShape>();
                _polylines = new List<Polyline>();
            }

        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                FileName = "Untitled",
                Filter = "Images|*.png",
                Title = "Save as",
                RestoreDirectory = true
            };
            
            if (saveFileDialog.ShowDialog() == true)
            {
                String fileName = saveFileDialog.FileName;
                SaveBitmap(canvas, fileName);
            }

        }
        private void SetStyle()
        {
            if ( _brush.styleLine == StyleLines.Dash )
            {
                double[] dashes = { 4, 4 };
                _StrokeDashArray = new System.Windows.Media.DoubleCollection(dashes);
            }
            else if (_brush.styleLine == StyleLines.Dot)
            {
                double[] dashes = { 1, 1 };
                _StrokeDashArray = new System.Windows.Media.DoubleCollection(dashes);
            }
            else if (_brush.styleLine == StyleLines.DashDot)
            {
                double[] dashes = { 4, 1, 1, 1 };
                _StrokeDashArray = new System.Windows.Media.DoubleCollection(dashes);
            }
            else if (_brush.styleLine == StyleLines.DashDotDot)
            {
                double[] dashes = { 4, 1, 1, 1, 1, 1 };
                _StrokeDashArray = new System.Windows.Media.DoubleCollection(dashes);
            }
        }
        private void SaveBitmap(Canvas canvas, string filename)
        {

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)canvas.RenderSize.Width, (int)canvas.RenderSize.Height, 96d, 96d, System.Windows.Media.PixelFormats.Default);
            canvas.Measure(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight));
            canvas.Arrange(new Rect(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight)));
           
            rtb.Render(canvas);
            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));

            using (FileStream fs = System.IO.File.OpenWrite(filename))
            {
                pngEncoder.Save(fs);
            }
        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
           
            var openDialog = new OpenFileDialog()
            {
                Title = "Load image",
                Filter = "Images|*.png;*.bmp;*.jpg;*jpge;",
                  RestoreDirectory = true,
            };
            if (openDialog.ShowDialog(this).GetValueOrDefault() && openDialog.CheckFileExists)
            {
                var brush = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri(openDialog.FileName, UriKind.Relative))
                };
                canvas.Background = brush;
                openDialog.Reset();
            }
        }
      
        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to save change to Untitled?", "Project Paint", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    FileName = "Untitled",
                    Filter = "Images|*.png",
                    Title = "Save as",
                    RestoreDirectory = true
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    String fileName = saveFileDialog.FileName;
                    SaveBitmap(canvas, fileName);
                }
            }
            else if (result == MessageBoxResult.No)
            {

                Close();
            }
        }

        private void selectColorBtn_Click(object sender, RoutedEventArgs e)
        {

          
             CurrentColor.Background = (sender as Button).Background;
            _brush.ColorOutLineBrush = CurrentColor.Background;
            _preview = _prototypes[_selectedShapeName].Clone(_brush);

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want to clear all in workspace?", "Project Paint", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)

            { 
                canvas.Children.Clear();
                _shapes = new List<IShape>();
                _polylines = new List<Polyline>();
            }
        }

      
        private void drawButton_Click(object sender, RoutedEventArgs e)
        {
                    _pencil.Action = "Pencil";     
        }

        private void lineSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handleSize = !cmb.IsDropDownOpen;
            HandleSize();
        }

        private void lineSizeComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (handleSize) HandleSize();
            handleSize = true;
            _preview = _prototypes[_selectedShapeName].Clone(_brush);

        }
        private void HandleSize()
        {
            switch (lineWidthComboBox.SelectedIndex)
            {
                case 0:
                    _brush.currSize = 3;
                    break;
                case 1:
                    _brush.currSize = 4;
                    break;
                case 2:
                    _brush.currSize = 5;
                    break;
                case 3:
                    _brush.currSize = 6;
                    break;
                case 4:
                    _brush.currSize = 7;
                    break;
                case 5:
                    _brush.currSize = 9;
                    break;
                case 6:
                    _brush.currSize = 11;
                    break;
            }
        }
        private void HandleStyle()
        {
            switch (lineStyleComboBox.SelectedIndex)
            {
                case 0:
                    _brush.styleLine = CustomBrush.StyleLines.Soild;
                    break;
                case 1:
                    _brush.styleLine = CustomBrush.StyleLines.Dash;
                    break;
                case 2:
                    _brush.styleLine = CustomBrush.StyleLines.Dot;
                    break;
                case 3:
                    _brush.styleLine = CustomBrush.StyleLines.DashDot;
                    break;
                case 4:
                    _brush.styleLine = CustomBrush.StyleLines.DashDotDot;
                    break;
               
            }

        }
        private void lineStyleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handleStyle = !cmb.IsDropDownOpen;
            HandleStyle();
        }
        private void lineStyleComboBox_DropDownClosed(object sender, EventArgs e)
        {

            if (handleStyle) HandleStyle();
            handleStyle = true;
            _preview = _prototypes[_selectedShapeName].Clone(_brush);
        }

    }
}
