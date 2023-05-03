using Shapes.Exceptions;

namespace Shapes.Tests;

internal class TriangleTests
{
    [Test]
    public void When_CreateTriangleWithNullSidesArr_Expect_ExceptionThrown()
    {
        Assert.Throws<ArgumentNullException>(() => { new Triangle(null); });
    }

    [Test]
    public void When_CreateTriangleWithEmptySidesArr_Expect_ExceptionThrown()
    {
        Assert.Throws<ShapeException>(() => { new Triangle(); });
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(4)]
    public void When_CreateTriangleWithIncorrectSidesCount_Expect_ExceptionThrown(int sidesCount)
    {
        var sides = new double[sidesCount];
        for (var i = 0; i < sidesCount; i++)
        {
            sides[i] = 1;
        }

        Assert.Throws<ShapeException>(() => { new Triangle(sides); });
    }

    [Test]
    public void When_CreateTriangleThatNotExist_Expect_ExceptionThrown()
    {
        Assert.Throws<ShapeException>(() => { new Triangle(10, 10, 1000); });
    }

    [Test]
    public void When_CreateTriangleWithNotPositiveSide_Expect_ExceptionThrown()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => { new Triangle(1, 1, 0); });
    }

    [Test]
    public void When_CreateTriangleWithPositiveSides_Expect_ExceptionDoesNotThrow()
    {
        Assert.DoesNotThrow(() => { new Triangle(1, 1, 1); });
    }

    [Test]
    public void When_UpdateTriangleSidesWithNotPositiveSide_Expect_ExceptionThrown()
    {
        var triangle = new Triangle(1, 1, 1);

        Assert.Throws<ArgumentOutOfRangeException>(() => { triangle.Sides = new double[] { 1, 1, 0 }; });
    }

    [Test]
    public void When_UpdateTriangleSidesWithPositiveSide_Expect_ExceptionDoesNotThrow()
    {
        var triangle = new Triangle(1, 1, 1);

        Assert.DoesNotThrow(() => { triangle.Sides = new double[] { 1, 2, 2 }; });
    }

    [TestCase(new double[] { 1, 1, 1 }, 0.43301270189222)]
    [TestCase(new double[] { 2, 2, 2 }, 1.7320508075689)]
    [TestCase(new double[] { 0.2, 0.2, 0.2 }, 0.01732050807568878)]
    [TestCase(new double[] { 5.12, 5.7, 4.43 }, 10.83863489948688)]
    [TestCase(new double[] { 29.37, 23.06, 28.16 }, 303.4323195975248)]
    [TestCase(new double[] { 44.48, 33.89, 10.62 }, 15.484465666741551)]
    [TestCase(new double[] { 20, 20, 28.28 }, 199.9999908795998)]
    [TestCase(new double[] { 1500, 5000, 5220.15 }, 3749999.9999903794)]
    [TestCase(new double[] { 31622.78, 44721.36, 31622.78 }, 500000107.4641905)]
    public void Area_ReturnsCorrectValue_When_SidesArePositive(double[] sides, double expectedArea)
    {
        var triangle = new Triangle(sides);

        var actualArea = triangle.Area;

        Assert.That(actualArea, Is.EqualTo(expectedArea).Within(TestConstants.ACCURACY));
    }

    [TestCase(new double[] { 1, 1, 1 }, 0.43301270189222)]
    [TestCase(new double[] { 2, 2, 2 }, 1.7320508075689)]
    [TestCase(new double[] { 0.2, 0.2, 0.2 }, 0.01732050807568878)]
    [TestCase(new double[] { 5.12, 5.7, 4.43 }, 10.83863489948688)]
    [TestCase(new double[] { 29.37, 23.06, 28.16 }, 303.4323195975248)]
    [TestCase(new double[] { 44.48, 33.89, 10.62 }, 15.484465666741551)]
    [TestCase(new double[] { 20, 20, 28.28 }, 199.9999908795998)]
    [TestCase(new double[] { 1500, 5000, 5220.15 }, 3749999.9999903794)]
    [TestCase(new double[] { 31622.78, 44721.36, 31622.78 }, 500000107.4641905)]
    public void Area_ReturnsCorrectValue_When_TriangleCastedToIShape(double[] sides, double expectedArea)
    {
        var shape = (IShape)new Triangle(sides);

        var actualArea = shape.Area;

        Assert.That(actualArea, Is.EqualTo(expectedArea).Within(TestConstants.ACCURACY));
    }

    [TestCase(new double[] { 0.3, 0.7, 0.761577 })]
    [TestCase(new double[] { 1, 1, 1.41421 })]
    [TestCase(new double[] { 1, 4, 4.12310 })]
    [TestCase(new double[] { 2.828427124746, 2.828427124746, 4 })]
    [TestCase(new double[] { 50, 140, 148.66068747 })]
    public void RightAngled_ReturnsTrue_When_TriangleRightAngled(double[] sides)
    {
        var triangle = new Triangle(sides);

        var actualIsRightAngled = triangle.RightAngled;

        Assert.That(actualIsRightAngled, Is.True);
    }

    [TestCase(new double[] { 0.03, 0.06, 0.08 })]
    [TestCase(new double[] { 2.24, 2.24, 2 })]
    [TestCase(new double[] { 223.61, 360.56, 400 })]
    public void RightAngled_ReturnsFalse_When_TriangleNotRightAngled(double[] sides)
    {
        var triangle = new Triangle(sides);

        var actualIsRightAngled = triangle.RightAngled;

        Assert.That(actualIsRightAngled, Is.False);
    }
}
