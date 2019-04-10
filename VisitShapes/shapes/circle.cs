using System;
using System.Collections.Generic;
using VisitShapes.visitors;

namespace VisitShapes.shapes
{
    public class circle : Ishape
    {
        public int radius { get; set; }

        public KeyValuePair<int, int> centre { get; set; }
        public List<Ishape> composites { get => this.composite; set => throw new NotImplementedException(); }

        public List<Ishape> composite = null;
    
        public circle()
        {
            var rnd = new Random();
            this.radius = rnd.Next(0,150);
            this.centre = new KeyValuePair<int, int>(rnd.Next(0, 150), rnd.Next(0, 150));
        }

        public void insertShape(Ishape shape)
        {
            if (this.composite == null)
            {
                this.composite = new List<Ishape>();
            }
            this.composite.Add(shape);
        }

        public void Accept(IVisitor v)
        {
            v.visit(this);
        }
    }
}
