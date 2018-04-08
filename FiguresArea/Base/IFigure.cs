namespace FiguresArea
{
    public interface IFigure
    {
        double GetArea();
        void Accept(IVisitor visitor);
    }
}
