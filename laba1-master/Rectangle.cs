﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace laba1
{
    
    public class Rectangle : Shape
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
        public override Shape overwrite()
        {
            Shape r = new Rectangle();
            r.setWidth(WidthPen);
            r.setPenColor(PenColor);
            r.setFillColor(FillColor);
            return r;
        }

        //Метод отрисовки прямоугольника по левой верхней точке и значениям ширины и высоты
        public override void Draw(Graphics g)
        {
            Point point1 = p1;
            Point point2 = p2;
            p1.X = point1.X < point2.X ? point1.X : point2.X;
            p2.X = point1.X > point2.X ? point1.X : point2.X;
            p1.Y = point1.Y < point2.Y ? point1.Y : point2.Y;
            p2.Y = point1.Y > point2.Y ? point1.Y : point2.Y;
            g.FillRectangle(new SolidBrush(FillColor), p1.X, p1.Y, p2.X-p1.X, p2.Y-p1.Y);
            g.DrawRectangle(new Pen(PenColor, WidthPen), p1.X, p1.Y, p2.X-p1.X, p2.Y-p1.Y);
        }
    }
}
