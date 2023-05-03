using Shapes.Exceptions;

namespace Shapes;

public class Triangle : ITriangle
{
    private double[] _sides = new double[3];
    public double[] Sides
    {
        get => _sides;
        set
        {
            ArgumentNullException.ThrowIfNull(value);

            if (value.Length != 3)
            {
                throw new ShapeException("Sides count in triangle must be equal to 3");
            }

            if (!ShapeHelper.CheckAllPositive(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), "All sides in triangle must be positive");
            }

            if (!IsTriangleExist(value))
            {
                throw new ShapeException($"Triangle can not exist with current set of sides - {string.Join(",", value)}");
            }

            _sides = value;
        }
    }

    public double Area
    {
        get
        {
            var halfPerimeter = Perimeter / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - _sides[0]) * (halfPerimeter - _sides[1]) * (halfPerimeter - _sides[2]));
        }
    }

    public bool RightAngled
    {
        get
        {
            var orderedSides = _sides.OrderBy(s => s).ToArray();
            return Math.Abs(orderedSides[2] * orderedSides[2] - orderedSides[0] * orderedSides[0] - orderedSides[1] * orderedSides[1]) < 0.0001;
        }
    }

    private double Perimeter => _sides.Sum();

    public Triangle(double sideA, double sideB, double sideC)
    {
        Sides = new[] { sideA, sideB, sideC };
    }

    public Triangle(params double[] sides)
    {
        Sides = sides;
    }

    // Is sum of two sides less than third side
    private static bool IsTriangleExist(params double[] sides)
    {
        return sides[0] < sides[1] + sides[2] && sides[1] < sides[0] + sides[2] && sides[2] < sides[0] + sides[1];
    }
}