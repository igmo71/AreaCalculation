using AreaCalc.Lib.Shapes;
using System.Reflection;

namespace AreaCalc.Lib
{
    public class Area
    {
        /// <summary>
        /// Calculate Shape Area by Shape Type
        /// </summary>
        /// <typeparam name="T">Shape Type</typeparam>
        /// <param name="shape">Shape Instance</param>
        /// <returns></returns>
        public static double Calculate<T>(IShape shape) where T : IShape
        {
            return shape.Calculate();
        }

        /// <summary>
        /// Calculate Shape Area by Name (It can be Triangle or Circle currently)
        /// </summary>
        /// <param name="shapeName">Shape Name</param>
        /// <param name="measures">Length Measurements</param>
        /// <returns>Return Area or 0 if wrong Type. Can be Triangle or Circle currently</returns>
        /// <exception cref="AppArgumentNullException">Measures must be present</exception>
        public static double Calculate(string shapeName, params double[] measures)
        {
            if(measures is null)
                throw new AppArgumentNullException(nameof(measures));

            var assembly = Assembly.GetExecutingAssembly().GetName().Name;
            Type? type = Type.GetType($"{assembly}.Shapes.{shapeName}");
            if (type != null)
            {
                try
                {
                    var shape = (IShape?)Activator.CreateInstance(type, measures);
                    if (shape != null)
                    {
                        return shape.Calculate();
                    }

                }
                catch (Exception ex)
                {
                    if (ex.InnerException is AppException appException)
                        throw appException;
                    throw;
                }
            }
            return 0;
        }
    }
}
