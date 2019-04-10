using VisitShapes.shapes;

namespace VisitShapes.visitors
{
    public class countVisitor : IVisitor
    {
        public CounterResult num = new CounterResult();
        public void visit(circle c)
        {
            num.numCircle += 1;
        }

        public void visit(triangle t)
        {
            num.numTriangle += 1;
        }

        public void visit(rectangle r)
        {
            num.numRectangle += 1; 
        }
    }
}
