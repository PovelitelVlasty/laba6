using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace laba1
{ 
    public class Line : Shape
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
        
        public override Shape overwrite() {
            Shape r = new Line();
            r.setWidth(WidthPen);
            r.setPenColor(PenColor);
            r.setFillColor(FillColor);
            return r;
        }


        //Метод отрисовки линии
        public override void Draw(Graphics g)
        {
            g.DrawLine(new Pen(PenColor, WidthPen), p1.X, p1.Y, p2.X, p2.Y);
        }

        
    }
}
