using Contract;
using Project_Paint;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static Project_Paint.CustomBrush;

namespace Circle2D

{
    public class Circle2D : IShape
    {

        private Point2D _leftTop = new Point2D();
        private Point2D _rightBottom = new Point2D();
        private CustomBrush.StyleLines _StrokeStyles { get; set; }

        private int _StokeThickness { get; set; }

        public string Name => "Circle";

        public Brush _Stroke { get; set; }
        public DoubleCollection _StrokeDashArray { get; set; }

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
        private void Handle()
        {
            double newWidth = Math.Abs(_rightBottom.X - _leftTop.X);
            double newHeight = Math.Abs(_rightBottom.Y - _leftTop.Y);
            double _diff = newWidth < newHeight ? newWidth : newHeight;
            if (_rightBottom.X > _leftTop.X && _rightBottom.Y > _leftTop.Y)
            {
                if (newWidth > newHeight)
                {
                    _rightBottom.X = _leftTop.X + _diff;
                }
                else
                {
                    _rightBottom.Y = _leftTop.Y + _diff;
                }
            }
            else if (_rightBottom.X > _leftTop.X && _rightBottom.Y < _leftTop.Y)
            {
                if (newWidth > newHeight)
                {
                    _rightBottom.X = _leftTop.X + _diff;
                }
                else
                {
                    _rightBottom.Y = _leftTop.Y - _diff;
                }
            }
            else if (_rightBottom.X < _leftTop.X && _rightBottom.Y > _leftTop.Y)
            {
                if (newWidth > newHeight)
                {
                    _rightBottom.X = _leftTop.X - _diff;
                }
                else
                {
                    _rightBottom.Y = _leftTop.Y + _diff;
                }
            }
            else
            {
                if (newWidth > newHeight)
                {
                    _rightBottom.X = _leftTop.X - _diff;
                }
                else
                {
                    _rightBottom.Y = _leftTop.Y - _diff;
                }
            }
        }
        public UIElement Draw()
        {
            SetStyle();
            Handle();
            double newWidth = _rightBottom.X - _leftTop.X;
            double newHeight = _rightBottom.Y - _leftTop.Y;

            var cir = new Ellipse()
            {
                Width = Math.Abs(newWidth),
                Height = Math.Abs(newHeight),
                Stroke =_Stroke,
                StrokeThickness = _StokeThickness,
                StrokeDashArray = _StrokeDashArray
            };
            
            if (newWidth > 0)
            {
                Canvas.SetLeft(cir, _leftTop.X);
            }
            else
            {
                Canvas.SetLeft(cir, _rightBottom.X);
            }
            if (newHeight > 0)
            {
                Canvas.SetTop(cir, _leftTop.Y);

            }
            else
            {
                Canvas.SetTop(cir, _rightBottom.Y);
            }
            return cir;
        }

        public IShape Clone(CustomBrush _brush)
        {
            var cir = new Circle2D()
            {
              
                _Stroke = _brush.ColorOutLineBrush,
                _StokeThickness = _brush.currSize,
                _StrokeStyles=_brush.styleLine
            };
          
            return cir;
          
        }
    }

}
