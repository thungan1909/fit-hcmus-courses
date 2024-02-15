using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GraphicsParser
{
    class Program
    {
        interface IShape
        {
            string MagicWord { get; }
        }
        class Point2D : IShape
        {
            public string MagicWord { get => "Point"; }
            public int X { get; set; }
            public int Y { get; set; }
        }
        class Line : IShape
        {
            public string MagicWord { get => "Line"; }
            public Point2D Start { get; set; }
            public Point2D End { get; set; }
        }
        class Rectangle : IShape
        {
            public string MagicWord { get => "Rectangle"; }
            public Point2D TopLeft { get; set; }
            public Point2D BottomRight { get; set; }
        }
        class Ellipse : IShape
        {
            public string MagicWord { get => "Ellipse"; }
            public Point2D TopLeft { get; set; }
            public Point2D BottomRight { get; set; }
        }

        interface IShapeToStringDataConverter
        {
            string MagicWord { get; }
            string Convert(IShape shape);
            IShape ConvertBack(string buffer);
        }
        class LineToStringDataConverter : IShapeToStringDataConverter
        {
            public string MagicWord { get => "Line"; }
            public string Convert(IShape shape)
            {
                throw new NotImplementedException();
            }
            //Line ((2, 2) ,(1, 1))
            public IShape ConvertBack(string buffer)
            {

                int firstSpaceIndex = buffer.IndexOf(" ");
                // lay ra 2, 2), (1, 1
                string temp = buffer.Substring(firstSpaceIndex + 3, buffer.Length - firstSpaceIndex - 5);
                // tach loại bỏ phần dấu ), (
                //2, 2
                //1, 1
                string[] parts = temp.Split(new string[] { "), (" }, StringSplitOptions.None);
                string[] tokens1 = parts[0].Split(new string[] { ", " }, StringSplitOptions.None);
                string[] tokens2 = parts[1].Split(new string[] { ", " }, StringSplitOptions.None);

                //điểm thứ nhất
                var p1 = new Point2D()
                {
                    X = int.Parse(tokens1[0]),
                    Y = int.Parse(tokens1[1])
                };

                //điểm thứ 2
                var p2 = new Point2D()
                {
                    X = int.Parse(tokens2[0]),
                    Y = int.Parse(tokens2[1])
                };

                IShape result = new Line()
                {
                    Start = p1,
                    End = p2
                };
                return result;
            }
        }

        class RectangleToStringDataConverter : IShapeToStringDataConverter
        {
            public string MagicWord { get => "Rectangle"; }
            public string Convert(IShape shape)
            {
                throw new NotImplementedException();
            }
            //Line ((2, 2) ,(1, 1))
            public IShape ConvertBack(string buffer)
            {

                int firstSpaceIndex = buffer.IndexOf(" ");
                // lay ra 2, 2), (1, 1
                string temp = buffer.Substring(firstSpaceIndex + 3, buffer.Length - firstSpaceIndex - 5);
                // tach loại bỏ phần dấu ), (
                //2, 2
                //1, 1
                string[] parts = temp.Split(new string[] { "), (" }, StringSplitOptions.None);
                string[] tokens1 = parts[0].Split(new string[] { ", " }, StringSplitOptions.None);
                string[] tokens2 = parts[1].Split(new string[] { ", " }, StringSplitOptions.None);

                //điểm thứ nhất
                var p1 = new Point2D()
                {
                    X = int.Parse(tokens1[0]),
                    Y = int.Parse(tokens1[1])
                };

                //điểm thứ 2
                var p2 = new Point2D()
                {
                    X = int.Parse(tokens2[0]),
                    Y = int.Parse(tokens2[1])
                };

                IShape result = new Rectangle()
                {
                    TopLeft = p1,
                    BottomRight = p2
                };
                return result;
            }
        }

        class EllipseToStringDataConverter : IShapeToStringDataConverter
        {
            public string MagicWord { get => "Ellipse"; }
            public string Convert(IShape shape)
            {
                throw new NotImplementedException();
            }
            //Line ((2, 2) ,(1, 1))
            public IShape ConvertBack(string buffer)
            {

                int firstSpaceIndex = buffer.IndexOf(" ");
                // lay ra 2, 2), (1, 1
                string temp = buffer.Substring(firstSpaceIndex + 3, buffer.Length - firstSpaceIndex - 5);
                // tach loại bỏ phần dấu ), (
                //2, 2
                //1, 1
                string[] parts = temp.Split(new string[] { "), (" }, StringSplitOptions.None);
                string[] tokens1 = parts[0].Split(new string[] { ", " }, StringSplitOptions.None);
                string[] tokens2 = parts[1].Split(new string[] { ", " }, StringSplitOptions.None);

                //điểm thứ nhất
                var p1 = new Point2D()
                {
                    X = int.Parse(tokens1[0]),
                    Y = int.Parse(tokens1[1])
                };

                //điểm thứ 2
                var p2 = new Point2D()
                {
                    X = int.Parse(tokens2[0]),
                    Y = int.Parse(tokens2[1])
                };

                IShape result = new Ellipse()
                {
                    TopLeft = p1,
                    BottomRight = p2
                };
                return result;
            }
        }


        interface IShapeToStringUIConverter
        {
            string MagicWord { get; }
            string convert(IShape shape);
            IShape ConvertBack(string buffer);
        }

        class PointToStringUIConverter : IShapeToStringUIConverter
        {
            public string MagicWord { get => "Point"; }
            public string convert(IShape shape)
            {
                Point2D line = (Point2D)shape;
                var builder = new StringBuilder();
                builder.Append("(");
                builder.Append(line.X);
                builder.Append(",");
                builder.Append(line.Y);
                builder.Append(")");

                string result = builder.ToString();
                return result;
            }

            public IShape ConvertBack(string buffer)
            {
                throw new NotImplementedException();
            }
        }

        class LineToStringUIConverter : IShapeToStringUIConverter
        {
            public string MagicWord { get => "Line"; }
            public string convert(IShape shape)
            {
                Line line = (Line)shape;
                var builder = new StringBuilder();

                var pointConverter = new PointToStringUIConverter();
                builder.Append(shape.MagicWord).Append(": ");
                builder
                .Append("(").Append(pointConverter.convert(line.Start))
                .Append("), (").Append(pointConverter.convert(line.End))
                .Append(")");

                string result = builder.ToString();
                return result;
            }
            public IShape ConvertBack(string buffer)
            {
                throw new NotImplementedException();
            }
        }

        class RectangleToStringUIConverter : IShapeToStringUIConverter
        {
            public string MagicWord { get => "Rectangle"; }
            public string convert(IShape shape)
            {
                Rectangle rectangle = (Rectangle)shape;
                var builder = new StringBuilder();

                var pointConverter = new PointToStringUIConverter();
                builder.Append(shape.MagicWord).Append(": ");
                builder
                .Append("(").Append(pointConverter.convert(rectangle.TopLeft))
                .Append("), (").Append(pointConverter.convert(rectangle.BottomRight))
                .Append(")");

                string result = builder.ToString();
                return result;
            }
            public IShape ConvertBack(string buffer)
            {
                throw new NotImplementedException();
            }
        }

        class EllipseToStringUIConverter : IShapeToStringUIConverter
        {
            public string MagicWord { get => "Ellipse"; }
            public string convert(IShape shape)
            {
                Ellipse ellipse = (Ellipse)shape;
                var builder = new StringBuilder();

                var pointConverter = new PointToStringUIConverter();
                builder.Append(shape.MagicWord).Append(": ");
                builder
                .Append("(").Append(pointConverter.convert(ellipse.TopLeft))
                .Append("), (").Append(pointConverter.convert(ellipse.BottomRight))
                .Append(")");

                string result = builder.ToString();
                return result;
            }
            public IShape ConvertBack(string buffer)
            {
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {

            List<IShape> shapes = new List<IShape>();


            var lineConverter = new LineToStringDataConverter();
            var rectangleConverter = new RectangleToStringDataConverter();
            var ellipseConverter = new EllipseToStringDataConverter();

            var dataConverterPrototypes = new Dictionary<string, IShapeToStringDataConverter>()
            {
                { lineConverter.MagicWord, lineConverter} ,
                { rectangleConverter.MagicWord, rectangleConverter},
                { ellipseConverter.MagicWord, ellipseConverter }
            };



            string filename = "mypaint.txt";
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string buffer = reader.ReadLine();
                    //Lấy ra từ đầu tiên
                    int firstSpaceIndex = buffer.IndexOf(" ");
                    string firstWord = buffer.Substring(0, firstSpaceIndex);

                    // IShape shape = null;

                    //switch (firstWord)
                    //{
                    //    case"Line":
                    //        shape = lineConverter.ConvertBack(buffer);
                    //        break;
                    //    case "Rectangle":
                    //        shape = rectangleConverter.ConvertBack(buffer);
                    //        break;
                    //    case "Ellipse":
                    //        shape = ellipseConverter.ConvertBack(buffer);
                    //        break;
                    //}

                    if (dataConverterPrototypes[firstWord] != null)
                    {
                        IShape shape = dataConverterPrototypes[firstWord].ConvertBack(buffer);
                        shapes.Add(shape);
                    }

                }
            }

            var lineUIConverter = new LineToStringUIConverter();
            var rectangleUIConverter = new RectangleToStringUIConverter();
            var ellipseUIConverter = new EllipseToStringUIConverter();

            var uiConverterPrototypes = new Dictionary<string, IShapeToStringUIConverter>() {
                { lineUIConverter.MagicWord, lineUIConverter },
                { rectangleUIConverter.MagicWord, rectangleUIConverter},
                { ellipseUIConverter.MagicWord, ellipseUIConverter}
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(uiConverterPrototypes[shape.MagicWord].convert(shape));


            }
        }
    }
}
