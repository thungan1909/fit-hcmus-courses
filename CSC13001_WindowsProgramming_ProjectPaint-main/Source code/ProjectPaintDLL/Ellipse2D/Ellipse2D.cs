using Contract;
using Project_Paint;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static Project_Paint.CustomBrush;

namespace Ellipse2D
{
    public class Ellipse2D : IShape
    {
        private Point2D _leftTop = new Point2D();
        private Point2D _rightBottom = new Point2D();
        private CustomBrush.StyleLines _StrokeStyles { get; set; }
        private int _StokeThickness { get; set; }
        public string Name => "Ellipse";
        public Brush _Stroke { get; set; }
        public DoubleCollection _StrokeDashArray { get; set; }
        private void SetStyle()
        {
            if (_StrokeStyles == StyleLines.Dash)
            {
                double[] dashes = { 4, 4 };
                _StrokeDashArray = new System.Windows.Media.DoubleCollection(dashes);
            }
            else if (_StrokeStyles == StyleLines.Dot)
            {
                double[] dashes = { 1, 1 };
                _StrokeDashArray = new System.Windows.Media.DoubleCollection(dashes);
            }
            else if (_StrokeStyles == StyleLines.DashDot)
            {
                double[] dashes = { 4, 1, 1, 1 };
                _StrokeDashArray = new System.Windows.Media.DoubleCollection(dashes);
            }
            else if (_StrokeStyles == StyleLines.DashDotDot)
            {
                double[] dashes = { 4, 1, 1, 1, 1, 1 };
                _StrokeDashArray = new System.Windows.Media.DoubleCollection(dashes);
            }
        }
        public UIElement Draw()
        {
            SetStyle();
            double newWidth = _rightBottom.X - _leftTop.X;
            double newHeight = _rightBottom.Y - _leftTop.Y;
            var ellipse = new Ellipse()
            {
                Width = Math.Abs(newWidth),
                Height = Math.Abs(newHeight),
                Stroke = _Stroke,
                StrokeThickness = _StokeThickness,
                StrokeDashArray = _StrokeDashArray
            };
            Canvas.SetLeft(ellipse, _leftTop.X);
            Canvas.SetTop(ellipse, _leftTop.Y);

            if (newWidth > 0)
            {
                Canvas.SetLeft(ellipse, _leftTop.X);
            }
            else
            {
                Canvas.SetLeft(ellipse, _rightBottom.X);
            }
            if (newHeight > 0)
            {
                Canvas.SetTop(ellipse, _leftTop.Y);

            }
            else
            {
                Canvas.SetTop(ellipse, _rightBottom.Y);
            }
            return ellipse;
        }

        public void HandleStart(double x, double y)
        {
            _leftTop.X = x;
            _leftTop.Y = y;
        }

        public void HandleEnd(double x, double y)
        {
            _rightBottom.X = x;
            _rightBottom.Y = y;
        }

        public IShape Clone(CustomBrush _brush)
        {
            var ellipse = new Ellipse2D()
            {

                _Stroke = _brush.ColorOutLineBrush,
                _StokeThickness = _brush.currSize,
                _StrokeStyles = _brush.styleLine
            };

            return ellipse;
        }
    }
}
