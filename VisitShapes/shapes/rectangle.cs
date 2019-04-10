using System;
using System.Collections.Generic;
using VisitShapes.visitors;

namespace VisitShapes.shapes
{
    public class rectangle : Ishape
    {
        public int heigth { get; set; }

        public int width { get; set; }

        public List<Ishape> composite = null;

        public List<Ishape> composites { get => this.composite; set => throw new NotImplementedException(); }

        public rectangle()
        {
            var rnd = new Random();
            this.heigth = rnd.Next(0, 150);
            this.width = rnd.Next(0, 150);
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
