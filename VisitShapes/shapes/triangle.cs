using System;
using System.Collections.Generic;
using VisitShapes.visitors;

namespace VisitShapes.shapes
{
    public class triangle : Ishape
    {
        public int a { get; set; }

        public int b { get; set; }

        public int c { get; set; }
        List<Ishape> Ishape.composites { get => this.composite; set => throw new NotImplementedException(); }

        public List<Ishape> composite = null;

        public triangle()
        {
            var rnd = new Random();
            this.a = rnd.Next(0, 150);
            this.b = rnd.Next(0, 150);
            this.c = rnd.Next(0, 150);
        }
       
        public void Accept(IVisitor s)
        {
            s.visit(this);
        }

        public void insertShape(Ishape shape)
        {
            if (this.composite == null)
            {
                this.composite = new List<Ishape>();
            }
            this.composite.Add(shape);
        }
    }
}
