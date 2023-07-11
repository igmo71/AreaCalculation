using AreaCalc.Lib;
using AreaCalc.Lib.Shapes;
using FluentAssertions;

namespace AreaCalc.Tests
{
    public class TriangleTests
    {
        [Fact]
        public void AreaCalculate_Success()
        {
            // Arrange
            Triangle triangle = new() { SideA = 3, SideB = 4, SideC = 5 };
            // Act
            var area = Area.Calculate<Triangle>(triangle);
            // Assert
            Assert.StrictEqual(expected: 6, actual: area);
        }

        [Fact]
        public void AreaCalculateByName_Success()
        {
            // Arrange
            string shapeName = "Triangle";
            double[] measures = { 3.0,  4.0,  5.0};
            // Act
            var area = Area.Calculate(shapeName, measures);
            // Assert
            Assert.StrictEqual(expected: 6, actual: area);
        }

        [Fact]
        public void TriangleInit_FailOnNegativeParameters()
        {
            // Arrange
            // Act

            // Assert
            Assert.ThrowsAny<AppParameterNegativeException>(() => new Triangle() { SideA = 3, SideB = 4, SideC = -5 }); // -5 is negative parameter
        }

        [Fact]
        public void AreaCalculate_FailOnMissmatchParameters()
        {
            // Arrange
            string shapeName = "Triangle";
            double[] measures = { 3.0, 4.0 }; // Must be Three parameters
            // Act
            Action action = () => Area.Calculate(shapeName, measures);
            // Assert
            action.Should().Throw<Exception>().WithInnerException<AppParametersCountMissmatchException>();
        }

        [Fact]
        public void AreaCalculate_FailOnParametersIsNull()
        {
            // Arrange
            string shapeName = "Triangle";
            // Act
            // Assert
            Assert.Throws<AppArgumentNullException>(() => Area.Calculate(shapeName, null!)); // Measures for shapes must be present
        }

        [Fact]
        public void AreaCalculate_FailOnShapeDefinition()
        {
            // Arrange
            string shapeName = "TTTriangle"; // TTTriangle is not correct shape name
            double[] measures = { 3.0, 4.0, 5.0 };
            // Act
            var area = Area.Calculate(shapeName, measures);
            // Assert
            Assert.StrictEqual(expected: 0, actual: area);
        }
    }
}