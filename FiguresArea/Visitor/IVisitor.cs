namespace FiguresArea
{
    public interface IVisitor
    {
        void Visit(Circle circle);
        void Visit(Triangle triangle);
    }
}
