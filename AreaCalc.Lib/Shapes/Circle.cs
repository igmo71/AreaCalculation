namespace AreaCalc.Lib.Shapes
{
    public class Circle : IShape
    {
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
                throw new ArgumentException("Maesures parameters for Triangle must be 3");
            Radius = measures[0];
        }

        public required double Radius { get; set; }

        public double Calculate()
        {
            double area = Math.PI * Math.Pow(Radius, 2);
            return area;
        }
    }
}
