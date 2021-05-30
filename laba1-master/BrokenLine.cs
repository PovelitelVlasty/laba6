using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace laba1
{
    
    public class BrokenLine : Shape
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
        //Конструктор

        public override Shape overwrite()
        {
            Shape r = new BrokenLine();
            r.setWidth(WidthPen);
            r.setPenColor(PenColor);
            r.setFillColor(FillColor);
            return r;
        }

        //Метод отрисовки ломаной по массиву точек
        public override void Draw(Graphics g)
        {
            g.DrawLines(new Pen(PenColor, WidthPen), pMass.ToArray());
        }
    }
}
