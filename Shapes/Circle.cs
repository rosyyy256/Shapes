namespace Shapes;

public class Circle : IShape
{
    private double _radius;
    public double Radius
    {
        get => _radius;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Radius must be positive");
            }

            _radius = value;
        }
    }

    public double Area => _radius * _radius * Math.PI;

    public Circle(double radius)
    {
        Radius = radius;
    }
}
