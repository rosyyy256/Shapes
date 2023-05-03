namespace Shapes.Tests;

internal static class TestConstants
{
    public const double ACCURACY = 0.0000000001;
}

internal class ShapesTests
{
    [Test]
    public void Area_ReturnsCorrectValue_When_ShapeIsUnknown()
    {
        var testCases = new (IShape shape, double expectedArea)[]
        {
            (new Triangle(1,1,1), 0.43301270189222),
            (new Triangle(29.37, 23.06, 28.16),303.4323195975248),
            (new Triangle(2,2,2),1.7320508075689),
            (new Circle(2),12.566370614359172),
            (new Circle(8),201.06192982974676),
            (new Circle(0.2345), 0.1727569654190661)
        };

        foreach (var testCase in testCases)
        {
            var actualArea = testCase.shape.Area;

            Assert.That(actualArea, Is.EqualTo(testCase.expectedArea).Within(TestConstants.ACCURACY));
        }
    }
}
