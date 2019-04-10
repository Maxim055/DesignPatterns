using VisitShapes.shapes;

namespace VisitShapes.visitors
{
    public class shrinkVisitor : IVisitor
    {
        public void visit(circle c)
        {
            c.radius /= 2;
        }

        public void visit(triangle t)
        {
            t.a /= 2;
            t.b /= 2;
            t.c /= 2;
        }

        public void visit(rectangle r)
        {
            r.heigth /= 2;
            r.width /= 2;
        }
    }
}
