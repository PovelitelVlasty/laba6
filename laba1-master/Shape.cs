using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace laba1
{
    
    public abstract class Shape
    {
        public Color PenColor = Color.Black;
        public Color FillColor = Color.White;
        public int WidthPen = 1;

        /*protected Pen MainPen = new Pen(Color.Black, 1);
        protected SolidBrush MainFill = new SolidBrush(Color.White);*/
        public void setWidth(int i) {
            WidthPen = i;
            //MainPen = new Pen(PenColor, WidthPen);
        }
        public void setPenColor(Color c) {
            PenColor = c;
            //MainPen = new Pen(PenColor,WidthPen);
        }
        public abstract Shape overwrite();
        public abstract void Draw(Graphics g);
        public abstract int setzn(Graphics g, Point p, int i);
       
        public void setFillColor(Color c)
        {
            FillColor = c;
            //MainFill = new SolidBrush(FillColor);
        }
    }
}
