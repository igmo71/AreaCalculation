namespace AreaCalc.Lib.Shapes
{
    public class Triangle : IShape
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle()
        { }

        public Triangle(params double[] measures)
        {
            InitInstance(measures);
        }

        private void InitInstance(double[] measures)
        {
            if (measures.Length != 3)
                throw new AppParametersCountMissmatchException(nameof(Triangle), 3, measures.Length);
            SideA = measures[0];
            SideB = measures[1];
            SideC = measures[2];
        }

        public required double SideA
        {
            get => sideA;
            set
            {
                if (value <= 0)
                    throw new AppParameterNegativeException(nameof(Triangle), nameof(SideA), value);
                sideA = value;
            }
        }
        public required double SideB
        {
            get => sideB;
            set
            {
                if (value <= 0)
                    throw new AppParameterNegativeException(nameof(Triangle), nameof(SideB), value);
                sideB = value;
            }
        }

        public required double SideC
        {
            get => sideC;
            set
            {
                if (value <= 0)
                    throw new AppParameterNegativeException(nameof(Triangle), nameof(SideC), value);
                sideC = value;
            }
        }

        public double Calculate()
        {
            double halfRerimeter = (SideA + SideB + SideC) / 2;
            double area = Math.Sqrt(halfRerimeter * (halfRerimeter - SideA) * (halfRerimeter - SideB) * (halfRerimeter - SideC));
            return area;
        }

        public bool IsRightTriangle()
        {
            double maxSide = Math.Max(Math.Max(SideA, SideB), SideC);
            double maxSideSquared = maxSide * maxSide;

            double sumOfSquares = 0;
            if (SideA == maxSideSquared)
            {
                sumOfSquares = (SideB * SideB) + (SideC * SideC);
            }
            else if (SideB == maxSideSquared)
            {
                sumOfSquares = (SideA * SideA) + (SideC * SideC);
            }
            else
            {
                sumOfSquares = (SideA * SideA) + (SideB * SideB);
            }

            return maxSideSquared == sumOfSquares;
        }
    }
}
