using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RTNL
{
    public partial class Form1 : Form
    {
      //  List<Cross> Shapes = new List<Cross>();
        List<Shape> Shapes = new List<Shape>();
        Point ShapeStart;
        bool IsShapeStart = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = Convert.ToString(e.X) + " . " + (e.Y);
            this.Text = Convert.ToString(e.Location);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
             foreach (Shape p in this.Shapes)
 
            {
               
                p.DrawWith(e.Graphics);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)

        {
            if (rb_Cross.Checked) Shapes.Add(new Cross(e.X, e.Y));
            if (rb_Line.Checked)
          {
               if (!IsShapeStart) ShapeStart = e.Location;
               else Shapes.Add(new Line(ShapeStart, e.Location));
               IsShapeStart = !IsShapeStart;
   
           }
            {
                 if (!IsShapeStart) ShapeStart = e.Location;
                 else Shapes.Add(new Line(ShapeStart, e.Location));
                    IsShapeStart = !IsShapeStart;
            }
            if (rb_circle.Checked)
            {
                if (IsShapeStart) ShapeStart = e.Location;
                else Shapes.Add(new Circle(ShapeStart, e.Location));
                 IsShapeStart = !IsShapeStart;
             }
            this.Refresh();
        }

       private void rb_CheckedChanged(object sender, EventArgs e)
  
        {
            IsShapeStart = !IsShapeStart;
        }
        public abstract class Shape
        {
           
        }
     

        
            int X, Y;
            Pen p = new Pen(Color.Red);

         /*   public Cross(int _X, int _Y)

            {
               X = _X; Y = _Y;
            }*/

            public override void DrawWith(Graphics g)

            {
                g.DrawLine(p, X - 4, Y - 4, X + 4, Y + 4);

                g.DrawLine(p, X + 4, Y - 4, X - 4, Y + 4);
            }

 
        }
        public class Line : Shape
        {
            Point C, F;            
            Pen p = new Pen(Color.Blue);
            public Line(Point _C, Point _F)
            {
                this.C = _C; this.F = _F;
            }
            public override void DrawWith(Graphics g)
            {
                g.DrawLine(p, C, F);
            }
        }
       
        }
}
}
    
