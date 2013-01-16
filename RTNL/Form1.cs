using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RTNL
{
         List<Shape> Shapes = new List<Shape>();
         Point ShapeStart;
         bool IsShapeStart = true;
        string curFile;      
         public Form1()
         {
 private void rb_CheckedChanged(object sender, EventArgs e)
         {
             IsShapeStart = !IsShapeStart;
         }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                curFile = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(curFile);
                foreach (Shape p in this.Shapes)
                {
                    p.SaveTo(sw);
                }
                sw.Close();
            }
                    private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            while (Shapes_List.SelectedIndices.Count > 0)
            {
                Shapes.RemoveAt(Shapes_List.SelectedIndices[0]);
                Shapes_List.Items.RemoveAt(Shapes_List.SelectedIndices[0]);
            }

            button1.Enabled = false;
            TempShape = null;
            this.Refresh();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (rb_cross.Checked)
            {
                TempShape = new Cross(e.Location);
                AddShape(TempShape);
            }
            else if (rb_line.Checked)
            {
                if (IsShapeStart)
                {
                    Shape_start = e.Location;
                    IsShapeStart = false;
                }
                else
                {
                    IsShapeStart = true;
                    AddShape(TempShape);
                }
            }
            else if (rb_circle.Checked)
            {
                if (IsShapeStart)
                {
                    Shape_start = e.Location;
                    IsShapeStart = false;
                }
                else
                {
                    IsShapeStart = true;
                    AddShape(TempShape);
                }
            }
            this.Refresh();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if ((!IsShapeStart) && (Shape_start != e.Location))
            {
                AddShape(TempShape);
                pictureBox1.Refresh();
            }
            IsShapeStart = true;
        }
    
        private void rb_cross_CheckedChanged(object sender, EventArgs e)
        {
            IsShapeStart = true;
        }

        private void Shapes_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
        }
