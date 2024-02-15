using Contract;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Circle2D
{
    public class Circle2D : IShape
    {

        private Point2D _leftTop = new Point2D();
        private Point2D _rightBottom = new Point2D();

        public string Name => "Circle";

        public UIElement Draw()
        {
            var cir = new Ellipse()
            {
                Width = _rightBottom.X - _leftTop.X,
                Height = _rightBottom.X - _leftTop.X,
                Stroke = new SolidColorBrush(Colors.Red),
                StrokeThickness = 1
            };
            Canvas.SetLeft(cir, _leftTop.X);
            Canvas.SetTop(cir, _leftTop.Y);
            return cir;
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

        public IShape Clone()
        {
            return new Circle2D();
        }
    }

}
