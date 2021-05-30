using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace laba1
{
   
    public class Polygon : Shape
    {
        public List<Point> pMass = new List<Point>();
        public override int setzn(Graphics g, Point p, int i)
        {
            if (i == -1)
            {
                pMass.Add(p);
                Draw(g);
                return 1;
            }
            else
            {
                pMass.Add(p);
            }
            return 0;
        }
        public override Shape overwrite()
        {
            Shape r = new Polygon();
            r.setWidth(WidthPen);
            r.setPenColor(PenColor);
            r.setFillColor(FillColor);
            return r;
        }
        //Конструктор



        //Метод отрисовки многоугольника по массиву вершин
        public override void Draw(Graphics g)
        {
            g.FillPolygon(new SolidBrush(FillColor), pMass.ToArray());
            g.DrawPolygon(new Pen(PenColor, WidthPen), pMass.ToArray());
        }
    }
}
