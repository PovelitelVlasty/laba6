using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Reflection;


namespace laba1
{
    public partial class frmMain : Form
    {
        private Graphics g;
        Shape currShape;
        Undo ctrl = new Undo();
        public int countTap = 0;
        private Color col = Color.Black;
        private Color colF = Color.White;
        private int wid = 1;
        
        public frmMain()
        {
            InitializeComponent();
            //Привязываем переменную типа Graphics к компоненту Panel
            var picture = new Bitmap(FieldDraw.Width, FieldDraw.Height);
            FieldDraw.Image = picture;
            g = Graphics.FromImage(FieldDraw.Image);
            g.Clear(Color.White);
            currShape = new Line();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel) 
            {
                return;
            }
            col = colorDialog1.Color;
            button4.BackColor = col;
            currShape.setPenColor(col);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            colF = colorDialog2.Color;
            button5.BackColor = colF;
            currShape.setFillColor(colF);
        }

        private void FieldDraw_Click(object sender, MouseEventArgs e)
        {
            countTap++;          
            if (e.Button == MouseButtons.Left)
            {
                if (currShape.setzn(g,new Point(e.X, e.Y), countTap) == 1)
                {
                    countTap = 0;
                    ctrl.add(currShape);
                    currShape = currShape.overwrite();
                }    
            } 
            else
            {
                if (currShape.setzn(g, new Point(e.X, e.Y), -1) == 1)
                {
                    countTap = 0;
                    ctrl.add(currShape);
                    currShape = currShape.overwrite();
                }

            }            
            FieldDraw.Refresh();
        }

        private void lineclc(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.Lime;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            currShape = new Line();
            currShape.setWidth(wid);
            currShape.setFillColor(colF);
            currShape.setPenColor(col);
            countTap = 0;
        }

        private void rectclc(object sender, EventArgs e)
        {
            button1.BackColor = Color.Lime;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            currShape = new Rectangle();
            currShape.setWidth(wid);
            currShape.setFillColor(colF);
            currShape.setPenColor(col);
            countTap = 0;
        }

        private void circleclc(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button6.BackColor = Color.Lime;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            currShape = new Circle();
            currShape.setWidth(wid);
            currShape.setFillColor(colF);
            currShape.setPenColor(col);
            countTap = 0;
        }

        private void Ellclc(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.Lime;
            button3.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            currShape = new Ellipse();
            currShape.setWidth(wid);
            currShape.setFillColor(colF);
            currShape.setPenColor(col);
            countTap = 0;
        }
        
        private void lomanclc(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.Lime;
            button9.BackColor = Color.White;
            currShape = new BrokenLine();
            currShape.setWidth(wid);
            currShape.setFillColor(colF);
            currShape.setPenColor(col);
            countTap = 0;
        }

        private void polyclc(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.Lime;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            currShape = new Polygon();
            currShape.setWidth(wid);
            currShape.setFillColor(colF);
            currShape.setPenColor(col);
            countTap = 0;
        }

        private void widclmn(object sender, EventArgs e)
        {
            wid = (int) numericUpDown1.Value;
            currShape.setWidth(wid);
        }

        private void undoredo(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name.Equals(toolStripMenuItem11)) {
                ctrl.ctrlZ(g);
            }
        }

        private void undo(object sender, EventArgs e)
        {
            ctrl.ctrlZ(g);
            FieldDraw.Refresh();
        }

        private void redo(object sender, EventArgs e)
        {
            ctrl.ctrlY(g);
            FieldDraw.Refresh();
        }

        private void clearing(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            ctrl.restart();
            FieldDraw.Refresh();
        }

        private void close(object sender, EventArgs e)
        {
            frmMain.ActiveForm.Close();
        }
        
        private void des(object sender, EventArgs e)
        {
            ctrl.deserialise();
            ctrl.redraw(g);
           
            FieldDraw.Refresh();
        }

        private void Seri(object sender, EventArgs e)
        {
            ctrl.serialise();
        }

        private void addclc(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.Lime;
            currShape = (Shape)Activator.CreateInstance(plugin);
            currShape.setWidth(wid);
            currShape.setFillColor(colF);
            currShape.setPenColor(col);
            countTap = 0;
        }
        Type plugin;
        private void addPlag(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = @"File dll (*.dll)|*.dll";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Assembly asm = Assembly.LoadFrom(openFileDialog1.FileName);
                Type[] pluginTypes = asm.GetTypes();
                foreach (Type pluginType in pluginTypes)
                {
                    if (typeof(Shape).IsAssignableFrom(pluginType))
                    {
                        plugin = pluginType;
                        button9.Enabled = true;
                        return;
                    }
                }
                
            }
        }
    }
}

