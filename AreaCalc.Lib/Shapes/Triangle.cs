namespace AreaCalc.Lib.Shapes
{
    public class Triangle : IShape
    {

        public Triangle()
        { }

        public Triangle(params double[] measures)
        {
            InitInstance(measures);
        }

        private void InitInstance(double[] measures)
        {
            if (measures.Length != 3)
                throw new ArgumentException("Maesures parameters for Triangle must be 3");
            SideA = measures[0];
            SideB = measures[1];
            SideC = measures[2];
        }

        public required double SideA { get; set; }
        public required double SideB { get; set; }
        public required double SideC { get; set; }

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
