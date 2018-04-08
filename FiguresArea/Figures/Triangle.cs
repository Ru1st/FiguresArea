using System;

namespace FiguresArea
{
    public class Triangle : IFigure
    {
        private double sideAB;
        private double sideBC;
        private double sideCA;

        #region Свойства
        /* 2 Варианта:
         * 1-й выкидывать ошибку в случае отрицательной длины 
         * 2-й находить модуль*/
        public double SideAB
        {
            get { return sideAB; }
            set
            {
                //CheckLength(value);
                //sideAB = value;
                sideAB = Math.Abs(value);
            }
        }
        public double SideBC
        {
            get { return sideBC; }
            set
            {
                //CheckLength(value);
                //sideAB = value;
                sideBC = Math.Abs(value);
            }
        }
        public double SideCA
        {
            get { return sideCA; }
            set
            {
                //CheckLength(value);
                //sideAB = value;
                sideCA = Math.Abs(value);
            }
        }
        #endregion

        public Triangle(double sideAB, double sideBC, double sideCA)
        {
            SideAB = sideAB;
            SideBC = sideBC;
            SideCA = sideCA;
        }

        public double GetArea()
        {
            var p = (SideAB + SideBC + SideCA) / 2;
            return Math.Sqrt(p * (p - SideAB) * (p - SideBC) * (p - SideCA));
        }

        public void Accept(IVisitor visitor) => visitor.Visit(this);

        private void CheckLength(double lenght)
        {
            if (lenght < 0)
                throw new ArgumentException("Длина не может быть отрицательной!");
        }
    }
}
