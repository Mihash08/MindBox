using System;


namespace ShapeLib
{
    public abstract class MyShape
    {
        protected double _area = -1;

        public double Area
        {
            get
            {
                if (_area == -1)
                    _area = CalcArea();
                return _area;
            }
        }

        protected abstract double CalcArea();
    }

    public class Circle : MyShape
    {
        static double _r;

        public double Radius
        {
            get => _r;
        }

        public Circle(double r)
        {
            if (r < 0)
                throw new ArgumentException("The radius cannot be negative");
            _r = r;
        }

        protected override double CalcArea()
        {
            return _r * Math.PI * Math.PI;
        }
    }

    public class Triangle : MyShape
    {
        static double _a;
        static double _b;
        static double _c;
        public readonly bool Right;

        public double A
        {
            get => _a;
        }

        public double B
        {
            get => _b;
        }

        public double C
        {
            get => _c;
        }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c < 0)
                throw new ArgumentException("A side of a tringle cannot be smaller or equal to 0");
            _a = a;
            _b = b;
            _c = c;
            Right = IsRight();
        }

        protected override double CalcArea()
        {
            double p = (_a + _b + _c) / 2;
            return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        }

        private bool IsRight()
        {
            double[] arr = { _a, _b, _c};

            Array.Sort(arr);
            // Creating an array and sorting it is necassary for finding the largest side
            // And selecting the other two sides without writing a lot of ugly ifs
            return arr[2] * arr[2] == arr[1] * arr[1] + arr[0] * arr[0];
        }
    }
}
