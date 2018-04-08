using System;

namespace FiguresArea
{
    public class Circle : IFigure
    {
        private double radius;
        public double Radius
        {
            get { return radius; }
            set
            {
                //CheckLength(value);
                //radius = value;
                radius = Math.Abs(value);
            }
        }
        public Circle(double radius) => Radius = radius;

        public double GetArea() => Math.PI * Radius * Radius;

        private void CheckLength(double lenght)
        {
            if (lenght < 0)
                throw new ArgumentException("Длина не может быть отрицательной!");
        }

        public void Accept(IVisitor visitor) => visitor.Visit(this);
    }
}
