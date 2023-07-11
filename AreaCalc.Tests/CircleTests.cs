using AreaCalc.Lib;
using AreaCalc.Lib.Shapes;
using FluentAssertions;


namespace AreaCalc.Tests
{
    public class CircleTests
    {
        [Fact]
        public void AreaCalculate_Success()
        {
            // Arrange
            Circle circle = new() { Radius = 5.64190 };
            // Act
            var area = Area.Calculate<Circle>(circle);
            // Assert
            Assert.StrictEqual(expected: 100, actual: Math.Round(area, 3));
        }

        [Fact]
        public void AreaCalculateByName_Success()
        {
            // Arrange
            string shapeName = "Circle";
            double radius = 5.64190;
            // Act
            var area = Area.Calculate(shapeName, radius);
            // Assert
            Assert.StrictEqual(expected: 100, actual: Math.Round(area, 3));
        }

        [Fact]
        public void CircleInit_FailOnNegativeParameters()
        {
            // Arrange
            // Act
            // Assert
            Assert.ThrowsAny<AppParameterNegativeException>(() => new Circle() { Radius = -5 }); // -5 is negative parameter
        }

        [Fact]
        public void AreaCalculate_FailOnMissMatchParameters()
        {
            // Arrange
            string shapeName = "Circle";
            double[] measures = { 3.0, 4.0 }; // Must be only One parameter
            // Act
            Action action = () => Area.Calculate(shapeName, measures);
            // Assert
            action.Should().Throw<Exception>().WithInnerException<AppParametersCountMissmatchException>();
        }

        [Fact]
        public void AreaCalculate_FailOnParametersIsNull()
        {
            // Arrange
            string shapeName = "Circle";
            // Act
            // Assert
            Assert.Throws<AppArgumentNullException>(() => Area.Calculate(shapeName, null!)); // Measures for shapes must be present
        }

        [Fact]
        public void AreaCalculate_FailOnShapeDefinition()
        {
            // Arrange
            string shapeName = "Cube"; // Cube is not implemented shape currently
            double[] measures = { 5.0 };
            // Act
            var area = Area.Calculate(shapeName, measures);
            // Assert
            Assert.StrictEqual(expected: 0, actual: area);
        }
    }
}
