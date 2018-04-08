using System;

namespace FiguresArea
{
    public class RightTriangleVisitor : IVisitor
    {
        public bool IsRightTriangle { get; private set; } = false;

        public void Visit(Circle circle) => IsRightTriangle = false;
        public void Visit(Triangle triangle)
        {
            var sides = new double[] { triangle.SideAB, triangle.SideBC, triangle.SideCA };
            Array.Sort(sides);
            var a = Math.Round(sides[0] * sides[0] + sides[1] * sides[1], 5);
            var b = Math.Round(sides[2] * sides[2], 5);
            IsRightTriangle = 
                Math.Round(sides[0] * sides[0] + sides[1] * sides[1], 5) == Math.Round(sides[2] * sides[2], 5);
        }
    }
}
