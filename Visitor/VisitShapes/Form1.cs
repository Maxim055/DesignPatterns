using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using VisitShapes.shapes;
using VisitShapes.visitors;

namespace VisitShapes
{
    public partial class Form1 : Form
    {
        public List<Ishape> shapes = new List<Ishape>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            var rec1 = new rectangle();
            this.shps.Text += rec1.heigth.ToString() + " " + rec1.width.ToString() + "\r\n";
            var rec2 = new rectangle();
            this.shps.Text += rec2.heigth.ToString() + " " + rec2.width.ToString() + "\r\n";
            var tr1 = new triangle();
            this.shps.Text += tr1.a + " " + tr1.b + " " + tr1.c + "\r\n";
            var tr2 = new triangle();
            this.shps.Text += tr2.a + " " + tr2.b + " " + tr2.c + "\r\n";
            var ccl1 = new circle();
            var ccl2 = new circle();
            rec1.insertShape(tr1);
            rec1.insertShape(ccl1);
            tr1.insertShape(tr2);
            //rec1 - composition, rec2- composition chi, ccl2- composition chi
            shapes.Add(rec1);
            shapes.Add(rec2);
            shapes.Add(ccl2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Counter
            var cntrVisitor = new countVisitor();
            counter(cntrVisitor, shapes);

            this.textBoxCir.Text = cntrVisitor.num.numCircle.ToString();
            this.textBoxRect.Text = cntrVisitor.num.numRectangle.ToString();
            this.textBoxTr.Text = cntrVisitor.num.numTriangle.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var vstr = new shrinkVisitor();
            // Shirnker
            shrinker(vstr, shapes);
        }

        private void shrinker(IVisitor visitor, List<Ishape> shps)
        {
            if (shps == null)
            {
                return;
            }
            foreach (var s in shps)
            {
                s.Accept(visitor);
                shrinker(visitor, s.composites);
            }
        }
        private void counter(IVisitor visitor, List<Ishape> shps)
        {
            if (shps == null)
            {
                return;
            }
            foreach (var s in shps)
            {
                s.Accept(visitor);
                counter(visitor, s.composites);
            }
        }
    }
}
