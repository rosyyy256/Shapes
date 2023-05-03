using Shapes.Extensions;
using System.Numerics;

namespace Shapes;

internal static class ShapeHelper
{
    public static bool CheckAllPositive<T>(params T[] array) where T : INumber<T>
    {
        var collectionLength = array.Length;
        for (var i = 0; i < collectionLength; i++)
        {
            if (!array[i].IsPositive())
            {
                return false;
            }
        }

        return true;
    }
}
