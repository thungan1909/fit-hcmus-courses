using IContract;
using Point;
using Line;
using Rectangle;
using Ellipse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GraphicsParser
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>();
            var lineConverter = new LineToStringDataConverter();
            var rectangleConverter = new RectangleToStringDataConverter();
            var ellipseConverter = new EllipseToStringDataConverter();
            var dataConverterPrototypes = new Dictionary<string, IShapeToStringDataConverter>() {
                { lineConverter.MagicWord, lineConverter },
                { rectangleConverter.MagicWord, rectangleConverter},
                { ellipseConverter.MagicWord, ellipseConverter}
            };

            string filename = "graphics.txt";
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string buffer = reader.ReadLine();
                    int firstSpaceIndex = buffer.IndexOf(" ");
                    string firstWord = buffer.Substring(0, firstSpaceIndex);

                    if (dataConverterPrototypes[firstWord] != null)
                    {
                        IShape shape = dataConverterPrototypes[firstWord].ConvertBack(buffer);
                        shapes.Add(shape);
                    }
                }
            }

            var lineUiConverter = new LineToStringUIConverter();
            var rectangleUiConverter = new RectangleToStringUIConverter();
            var ellipseUiConverter = new EllipseToStringUIConverter();

            var uiConverterPrototypes = new Dictionary<string, IShapeToStringUIConverter>() {
                { lineUiConverter.MagicWord, lineUiConverter },
                { rectangleUiConverter.MagicWord, rectangleUiConverter},
                { ellipseUiConverter.MagicWord, ellipseUiConverter}
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(
                    uiConverterPrototypes[shape.MagicWord].convert(shape));
            }
        }
    }
}
