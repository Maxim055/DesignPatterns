using VisitShapes.shapes;

namespace VisitShapes.visitors
{
    public interface IVisitor
    {
        void visit(circle c);

        void visit(triangle t);

        void visit(rectangle r);
    }
}
