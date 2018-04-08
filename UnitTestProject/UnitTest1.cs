using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresArea;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        Random r = new Random();
        int min = -10000;
        int max = 10000;
        [TestMethod]
        public void TestCircleArea1() => TestCircleArea(r.Next(0, max));
        [TestMethod]
        public void TestCircleArea2() => TestCircleArea(r.Next(min, 0));
        [TestMethod]
        public void TestCircleArea3() => TestCircleArea(0);
        [TestMethod]
        public void TestTriangleArea1() => TestTriangleArea(r.Next(min, max), r.Next(min, max), r.Next(min, max));
        [TestMethod]
        public void TestTriangleArea3() => TestTriangleArea(r.Next(min, max), 0, r.Next(min, max));

        [TestMethod]
        public void TestArea1()
        {
            var a = r.Next(min, max);
            var b = r.Next(min, max);
            var c = r.Next(min, max);
            var triangle = new Triangle(a, b, c);
            Assert.AreEqual(GetArea(triangle), GetTriangleArea(a, b, c));
        }
        [TestMethod]
        public void TestArea2()
        {
            var a = r.Next(min, max);
            var b = 0;
            var c = r.Next(min, max);
            var triangle = new Triangle(a, b, c);
            Assert.AreEqual(GetArea(triangle), GetTriangleArea(a, b, c));
        }
        [TestMethod]
        public void TestArea3()
        {
            var rad = r.Next(min, max);
            var circle = new Circle(rad);
            Assert.AreEqual(GetArea(circle), GetCircleArea(rad));
        }
        [TestMethod]
        public void TestArea4()
        {
            var rad = 0;
            var circle = new Circle(rad);
            Assert.AreEqual(GetArea(circle), GetCircleArea(rad));
        }
        [TestMethod]
        public void TestArea5()
        {
            var rad = 0.000000001;
            var circle = new Circle(rad);
            Assert.AreEqual(GetArea(circle), GetCircleArea(rad));
        }

        [TestMethod]
        public void TestRightTriangle1()
        {
            var triangle = new Triangle(r.Next(min, max), r.Next(min, max), r.Next(min, max));
            Assert.AreEqual(TestRight(triangle), false);
        }
        [TestMethod]
        public void TestRightTriangle2()
        {
            var a = r.Next(min, max);
            var b = r.Next(min, max);
            var c = Math.Sqrt(a * a + b * b);
            var triangle = new Triangle(a, b, c);
            Assert.AreEqual(TestRight(triangle), true);
        }
        [TestMethod]
        public void TestRightTriangle3()
        {
            var circle = new Circle(r.Next(min, max));
            Assert.AreEqual(TestRight(circle), false);
        }

        private void TestCircleArea(double r)
        {
            Circle circle = new Circle(r);
            Assert.AreEqual(circle.GetArea(), GetCircleArea(r));
        }
        private void TestTriangleArea(double a, double b, double c)
        {
            var at = Math.Abs(a);
            var bt = Math.Abs(b);
            var ct = Math.Abs(c);
            var triangle = new Triangle(at, bt, ct);
            Assert.AreEqual(triangle.GetArea(), GetTriangleArea(at, bt, ct));
        }
        private double GetArea(IFigure figure) => figure.GetArea();
        private double GetTriangleArea(double a, double b, double c)
        {
            var p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        private double GetCircleArea(double r) => Math.PI * r * r;
        private bool TestRight(IFigure figure)
        {
            RightTriangleVisitor visitor = new RightTriangleVisitor();
            figure.Accept(visitor);
            return visitor.IsRightTriangle;
        }
    }
}
