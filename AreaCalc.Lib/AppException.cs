namespace AreaCalc.Lib
{
    public class AppException : Exception
    {
        public AppException(string message) : base(message: message)
        { }
    }

    public class AppParametersCountMissmatchException : AppException
    {
        public AppParametersCountMissmatchException(string shapeName, int parametersCount, int value)
            : base($"Measures parameters count for {shapeName} must be {parametersCount} but there are {value} of them")
        { }
    }

    public class AppParameterNegativeException : AppException
    {
        public AppParameterNegativeException(string shapeName, string parameterName, double value)
            :base($"Measures for {shapeName} must be positive but value={value} ({parameterName})")
        { }
    }

    public class AppArgumentNullException : ArgumentNullException
    {
        public AppArgumentNullException(string? paramName)
            : base(paramName, "Measures for shapes must be present")
        { }
    }
}
