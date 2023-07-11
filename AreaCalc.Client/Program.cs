
using AreaCalc.Lib;
using AreaCalc.Lib.Shapes;

Console.WriteLine("Hello, Mindbox!");

IShape shape = new Circle() { Radius = 6.789 };
var circleArea = Area.Calculate<Circle>(shape);
Console.WriteLine($"Circle Area: {circleArea}");

shape = new Triangle() { SideA =12.23, SideB = 23.34, SideC=34.45};
var triangleArea = Area.Calculate<Triangle>(shape);
Console.WriteLine($"Triangle Area: {triangleArea} - is Right Triangle: {((Triangle)shape).IsRightTriangle()}");

Triangle rightTriangle = new() { SideA = 3, SideB = 4, SideC = 5 };
var rightTriangleArea = Area.Calculate<Triangle>(rightTriangle);
Console.WriteLine($"Right Triangle Area: {rightTriangleArea} - is Right Triangle: {rightTriangle.IsRightTriangle()}");

var circleAreaByName = Area.Calculate("Circle", 6.789);
Console.WriteLine($"Circle Area By Name: {circleAreaByName}");

var triangleAreaByName = Area.Calculate("Triangle", 3, 4, 5);
Console.WriteLine($"Triangle Area By Name: {triangleAreaByName}");
