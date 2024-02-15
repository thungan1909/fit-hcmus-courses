using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Project_Paint
{
    public class CustomBrush
    {
       // public DoubleCollection OutLineType = new DoubleCollection() { 1, 0 };
        public int currSize = 3;
        public enum StyleLines
        {
            Soild,
            Dash,
            Dot,
            DashDot,
            DashDotDot
        };
        public Brush ColorOutLineBrush = System.Windows.Media.Brushes.Black;
        public StyleLines styleLine = StyleLines.Soild;


        public Brush getFillBrush()
        {
            Color cl1 = ((SolidColorBrush)(ColorOutLineBrush)).Color;
            return new SolidColorBrush(cl1);
        }
    }
}
