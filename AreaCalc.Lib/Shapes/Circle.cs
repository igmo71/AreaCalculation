namespace AreaCalc.Lib.Shapes
{
    public class Circle : IShape
    {
        private double radius;

        public Circle()
        {
            
        }
     
        public Circle(params double[] measures)
        {
            InitInstance(measures);
        }

        private void InitInstance(double[] measures)
        {
            if (measures.Length != 1)
                throw new AppParametersCountMissmatchException(nameof(Circle), 1, measures.Length);
            Radius = measures[0];
        }

        public required double Radius
        {
            get => radius; 
            set
            {
                if (value <= 0)
                    throw new AppParameterNegativeException(nameof(Circle), nameof(Radius), value);
                radius = value;
            }
        }

        public double Calculate()
        {
            double area = Math.PI * Math.Pow(Radius, 2);
            return area;
        }
    }
}
