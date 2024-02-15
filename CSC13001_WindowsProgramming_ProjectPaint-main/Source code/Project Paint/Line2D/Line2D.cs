using Contract;
using Project_Paint;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using static Project_Paint.CustomBrush;

namespace Line2D
{
    public class Line2D : IShape
    {
        private Point2D _start = new Point2D();
        private Point2D _end = new Point2D();
        private CustomBrush.StyleLines _StrokeStyles { get; set; }
        public string Name => "Line";

        public Brush _Stroke { get; set; }
        public DoubleCollection _StrokeDashArray { get; set; }

        private int _StokeThickness { get; set; }

        public void HandleStart(double x, double y)
        {
            _start = new Point2D() { X = x, Y = y };
        }

        public void HandleEnd(double x, double y)
        {
            _end = new Point2D() { X = x, Y = y };
        }


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
            Line l = new Line()
            {
                X1 = _start.X,
                Y1 = _start.Y,
                X2 = _end.X,
                Y2 = _end.Y,
                Stroke = _Stroke,
                StrokeThickness = _StokeThickness,
                StrokeDashArray = _StrokeDashArray
            };

            return l;
        }

        public IShape Clone(CustomBrush _brush)
        {
            Line2D l = new Line2D()
            {

                _Stroke = _brush.ColorOutLineBrush,
                _StokeThickness = _brush.currSize,
                _StrokeStyles = _brush.styleLine
            };

            return l;
        }
    }
}
