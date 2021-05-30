using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace laba1
{
    public class addit : Shape
    {
        public Point p1;
        public Point p2;
        public override int setzn(Graphics g, Point p, int i)
        {
            if (i == 1)
            {
                p1 = p;
            }
            else if (i == 2)
            {
                p2 = p;
                Draw(g);
                return 1;
            }
            return 0;
        }
        //Конструктор

        public override Shape overwrite()
        {
            Shape r = new addit();
            r.setWidth(WidthPen);
            r.setPenColor(PenColor);
            r.setFillColor(FillColor);
            return r;
        }

        public override void Draw(Graphics g)
        {
            Point[] p = new Point[4];
            p[0] = p1;
            p[1] = new Point(p2.X, p1.Y);
            p[2] = new Point(p2.X - (p2.X - p1.X) / 4, p2.Y);
            p[3] = new Point(p1.X + (p2.X - p1.X) / 4, p2.Y);
            g.FillPolygon(new SolidBrush(FillColor), p);
            g.DrawPolygon(new Pen(PenColor, WidthPen), p);
        }
    }
}
