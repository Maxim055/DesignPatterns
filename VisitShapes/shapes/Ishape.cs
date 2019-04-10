using System.Collections.Generic;
using VisitShapes.visitors;

namespace VisitShapes.shapes
{
    public interface Ishape
    {
        List<Ishape> composites { get; set; }
        void Accept(IVisitor s);

        void insertShape(Ishape shape);
    }
}
