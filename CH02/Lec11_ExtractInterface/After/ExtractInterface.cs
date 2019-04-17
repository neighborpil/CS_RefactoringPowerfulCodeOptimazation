using System;

namespace Refactoring
{
    public interface IShape
    {
        double GetArea();
        double GetPerimeter();
    }

    public class Rectangle : IShape
    {
        double width;
        double length;

        public Rectangle() : this(1, 1)
        {
        }
        public Rectangle(double width, double length)
        {
            this.width = width;
            this.length = length;
        }

        public double GetArea()
        {
            return width * length;
        }

        public double GetPerimeter()
        {
            return 2 * (width + length);
        }
    }

    public class Circle : IShape
    {
        double radius;

        public Circle() : this(1)
        {
        }
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }
    }

    public class Triangle : IShape
    {
        double a;
        double b;
        double c;

        public Triangle() : this(1, 1, 1)
        {
        }
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double GetArea()
        {
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public double GetPerimeter()
        {
            return a + b + c;
        }
    }

    public class ShapePainter
    {
        public bool ShouldPaint(IShape shape)
        {
            return Math.Abs(shape.GetArea()) < 0.001;
        }
    }
}