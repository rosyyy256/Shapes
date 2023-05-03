namespace Shapes.Exceptions;

public class ShapeException : Exception
{
    public ShapeException() : base() { }
    public ShapeException(string message) : base(message) { }
}
