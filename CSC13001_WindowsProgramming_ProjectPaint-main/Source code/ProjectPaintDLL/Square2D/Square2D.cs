using Contract;
using Project_Paint;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static Project_Paint.CustomBrush;

namespace Square2D

{
    public class Square2D : IShape
    {
        private Point2D _leftTop = new Point2D();
        private Point2D _rightBottom = new Point2D();
        private CustomBrush.StyleLines _StrokeStyles { get; set; }
        private int _StokeThickness { get; set; }
        public Brush _Stroke { get; set; }
        public DoubleCollection _StrokeDashArray { get; set; }
        public string Name => "Square";
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
            var sq = new Rectangle()
            {
                Width = Math.Abs(newWidth),
                Height = Math.Abs(newHeight),
                Stroke = _Stroke,
                StrokeThickness = _StokeThickness,
                StrokeDashArray = _StrokeDashArray

            };
            if (newWidth > 0)
            {
                Canvas.SetLeft(sq, _leftTop.X);
            }
            else
            {
                Canvas.SetLeft(sq, _rightBottom.X);
            }
            if (newHeight > 0)
            {
                Canvas.SetTop(sq, _leftTop.Y);

            }
            else
            {
                Canvas.SetTop(sq, _rightBottom.Y);
            }
            return sq;

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
            var sq = new Square2D()
            {

                _Stroke = _brush.ColorOutLineBrush,
                _StokeThickness = _brush.currSize,
                _StrokeStyles = _brush.styleLine
            };

            return sq;
        }
    }
}
