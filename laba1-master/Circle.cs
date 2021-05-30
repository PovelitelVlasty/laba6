using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace laba1
{
    
    public class Circle : Shape
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
                int tmp = Math.Abs(p2.X - p1.X) * Math.Abs(p2.X - p1.X) + Math.Abs(p2.Y - p1.Y) * Math.Abs(p2.Y - p1.Y);
                tmp = (int)Math.Round(Math.Sqrt(tmp));
                p2.X = tmp * 2;
                p2.Y = tmp * 2;
                p1.X = p1.X - tmp;
                p1.Y = p1.Y - tmp;
                Draw(g);
                return 1;
            }
            return 0;
        }

        //Конструктор


        public override Shape overwrite()
        {
            Shape r = new Circle();
            r.setWidth(WidthPen);
            r.setPenColor(PenColor);
            r.setFillColor(FillColor);
            return r;
        }

        //Метод отрисовки окружности по точке центра и радиусу
        public override void Draw(Graphics g)
        { 
            
            g.FillEllipse(new SolidBrush(FillColor), p1.X, p1.Y, p2.X, p2.Y);
            g.DrawEllipse(new Pen(PenColor, WidthPen), p1.X, p1.Y, p2.X, p2.Y);
        }
    }
}
