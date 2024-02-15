using Contract;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Square2D
{
    public class Square2D : IShape
    {
        private Point2D _leftTop = new Point2D();
        private Point2D _rightBottom = new Point2D();

        public string Name => "Square";

        public UIElement Draw()
        {
            var sq = new Rectangle()
            {
                Width = _rightBottom.X - _leftTop.X,
                Height = _rightBottom.X - _leftTop.X,
                Stroke = new SolidColorBrush(Colors.Red),
                StrokeThickness = 1

            };
            Canvas.SetLeft(sq, _leftTop.X);
            Canvas.SetTop(sq, _leftTop.Y);
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

        public IShape Clone()
        {
            return new Square2D();
        }
    }
}
