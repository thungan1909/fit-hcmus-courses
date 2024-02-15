using Contract;
using Project_Paint;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static Project_Paint.CustomBrush;

namespace Rectangle2D
{
    public class Rectangle2D : IShape
    {
        private Point2D _leftTop = new Point2D();
        private Point2D _rightBottom = new Point2D();
        private CustomBrush.StyleLines _StrokeStyles { get; set; }
        public Brush _Stroke { get; set; }
        public DoubleCollection _StrokeDashArray { get; set; }
        private int _StokeThickness { get; set; }
        public string Name => "Rectangle";
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
            var rect = new Rectangle()
            {
                Width = Math.Abs(newWidth),
                Height = Math.Abs(newHeight),
                Stroke = _Stroke,
                StrokeThickness = _StokeThickness,
                StrokeDashArray = _StrokeDashArray
            };


            if (newWidth > 0)
            {
                Canvas.SetLeft(rect, _leftTop.X);
            }
            else
            {
                Canvas.SetLeft(rect, _rightBottom.X);
            }
            if (newHeight > 0)
            {
                Canvas.SetTop(rect, _leftTop.Y);

            }
            else
            {
                Canvas.SetTop(rect, _rightBottom.Y);
            }
            return rect;
        }

        public void HandleStart(double x, double y)
        {
            _leftTop = new Point2D() { X = x, Y = y };
        }

        public void HandleEnd(double x, double y)
        {
            _rightBottom = new Point2D() { X = x, Y = y };
        }


        public IShape Clone(CustomBrush _brush)
        {
            var rec = new Rectangle2D()
            {

                _Stroke = _brush.ColorOutLineBrush,
                _StokeThickness = _brush.currSize,
                _StrokeStyles = _brush.styleLine
            };

            return rec;
        }
    }
}
