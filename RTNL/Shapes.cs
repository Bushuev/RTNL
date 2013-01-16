using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace RTNL
{
    public abstract class Shape
    {
        public abstract void DrawWith(Graphics g, Pen p);
        public abstract void SaveTo(StreamWriter sw);
        public abstract string ConfString { get; }
    }
    public class Cross : Shape
    {
        int X, Y;

        public Cross(int _X, int _Y)
        {
            X = _X;
            Y = _Y;
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Крест");
            sw.Write(Convert.ToString(X));
            sw.Write(' ');
            sw.WriteLine(Convert.ToString(Y));
        }
        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawLine(p, X - 4, Y - 4, X + 4, Y + 4);
            g.DrawLine(p, X + 4, Y - 4, X - 4, Y + 4);
        }
        public Cross(StreamReader _sr)
        {
            string line = _sr.ReadLine();
            string[] str = line.Split(' ');
            X = Convert.ToInt32(str[0]);
            Y = Convert.ToInt32(str[1]);
        }
        public override string ConfString
        {
            get
            {
                return "Крест " + Convert.ToString(X) + " ; " + Convert.ToString(Y);
            }
        }
    }
    public class Line : Shape
    {
        Point C, F;

        public Line(Point _C, Point _F)
        {
            this.C = _C;
            this.F = _F;
        }
        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawLine(p, C, F);
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Линия");
            sw.Write(Convert.ToString(C.X));
            sw.Write(' ');
            sw.Write(Convert.ToString(C.Y));
            sw.Write(' ');
            sw.Write(Convert.ToString(F.X));
            sw.Write(' ');
            sw.WriteLine(Convert.ToString(F.Y));
        }
        public Line(StreamReader _sr)
        {
            string line = _sr.ReadLine();
            string[] str = line.Split(' ');
            C.X = Convert.ToInt32(str[0]);
            C.Y = Convert.ToInt32(str[1]);
            F.X = Convert.ToInt32(str[2]);
            F.Y = Convert.ToInt32(str[3]);
        }
        public override string ConfString
        {
            get
            {
                return "Линия " + Convert.ToString(C) + " ; " + Convert.ToString(F);
            }
        }
    }
    public class Circle : Shape
    {
        Point C, P;

        int r;
        public Circle(Point _C, Point _P)
        {
            C = _C;
            P = _P;
            r = Convert.ToInt32(Math.Sqrt(Math.Pow(C.X - P.X, 2) + Math.Pow(C.Y - P.Y, 2)));
        }

        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawEllipse(p, C.X - r, C.Y - r, 2 * r, 2 * r);
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Круг");
            sw.Write(Convert.ToString(C.X));
            sw.Write(' ');
            sw.Write(Convert.ToString(C.Y));
            sw.Write(' ');
            sw.WriteLine(Convert.ToString(r));
        }
        public Circle(StreamReader _sr)
        {
            string line = _sr.ReadLine();
            string[] str = line.Split(' ');
            C.X = Convert.ToInt32(str[0]);
            C.Y = Convert.ToInt32(str[1]);
            r = Convert.ToInt32(str[2]);
        }
        public override string ConfString
        {
            get
            {
                return "Круг " + Convert.ToString(C) + " " + Convert.ToString(P);
            }
        }
    }
    public class Rectangle : Shape
    {
        Point a, b;
        public Rectangle(Point _a, Point _b)
        {
            this.a = new Point(Math.Min(_a.X, _b.X), Math.Min(_a.Y, _b.Y));
            this.b = new Point(Math.Max(_a.X, _b.X), Math.Max(_a.Y, _b.Y));
        }
        public Rectangle(StreamReader sr)
        {
            string line = sr.ReadLine();
            string line1 = sr.ReadLine();
            string[] foo = line.Split(' ');
            string[] foo1 = line1.Split(' ');
            a.X = Convert.ToInt32(foo[0]);
            a.Y = Convert.ToInt32(foo[1]);
            b.X = Convert.ToInt32(foo1[0]);
            b.Y = Convert.ToInt32(foo1[1]);
        }
        public override void DrawWith(Graphics g, Pen p)
        {
            g.DrawRectangle(p, a.X, a.Y, width, height);
        }
        public override void SaveTo(StreamWriter sw)
        {
            sw.WriteLine("Прямоугольнег");
            sw.WriteLine(Convert.ToString(a.X) + " " + Convert.ToString(a.Y));
            sw.WriteLine(Convert.ToString(b.X) + " " + Convert.ToString(b.Y));
        }
        public override string ConfString
        {
            get { return ("Прямоугольнег(" + Convert.ToString(a.X) + ";" + Convert.ToString(a.Y) + ";ш=" + Convert.ToString(Math.Abs(width)) + ";в=" + Convert.ToString(Math.Abs(height)) + ")"); }
        }
        public float width
        {
            get
            {
                return (b.X - a.X);
            }
        }
        public float height
        {
            get
            {
                return (b.Y - a.Y);
            }
        }

    }
}

