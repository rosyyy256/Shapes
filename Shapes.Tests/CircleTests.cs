namespace Shapes.Tests;

internal class CircleTests
{
    [Test]
    public void When_CreateCircleWithNotPositiveRadius_Expect_ExceptionThrown()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { new Circle(0); });
    }

    [Test]
    public void When_CreateCircleWithPositiveRaduis_Expect_ExceptionDoesNotThrow()
    {
        Assert.DoesNotThrow(() => { new Circle(1); });
    }

    [Test]
    public void When_UpdateCircleRaduisToNotPositiveValue_Expect_ExceptionThrown()
    {
        var circle = new Circle(1);

        Assert.Throws<ArgumentOutOfRangeException>(() => { circle.Radius = 0; });
    }

    [Test]
    public void When_UpdateCircleRaduisToPositiveValue_Expect_ExceptionDoesNotThrow()
    {
        var circle = new Circle(1);

        Assert.DoesNotThrow(() => { circle.Radius = 2; });
    }

    [TestCase(1, 3.141592653589793)]
    [TestCase(2, 12.566370614359172)]
    [TestCase(8, 201.06192982974676)]
    [TestCase(999999, 3141586370407.6274)]
    [TestCase(0.2345, 0.1727569654190661)]
    [TestCase(56439.56726395, 10007307002.405468)]
    public void Area_ReturnsCorrectValue_When_RaduisIsPositive(double radius, double expectedArea)
    {
        var circle = new Circle(radius);

        var actualArea = circle.Area;

        Assert.That(actualArea, Is.EqualTo(expectedArea).Within(TestConstants.ACCURACY));
    }

    [TestCase(1, 3.141592653589793)]
    [TestCase(2, 12.566370614359172)]
    [TestCase(8, 201.06192982974676)]
    [TestCase(999999, 3141586370407.6274)]
    [TestCase(0.2345, 0.1727569654190661)]
    [TestCase(56439.56726395, 10007307002.405468)]
    public void Area_ReturnsCorrectValue_When_CircleCastedToIShape(double radius, double expectedArea)
    {
        var shape = (IShape) new Circle(radius);

        var actualArea = shape.Area;

        Assert.That(actualArea, Is.EqualTo(expectedArea).Within(TestConstants.ACCURACY));
    }
}