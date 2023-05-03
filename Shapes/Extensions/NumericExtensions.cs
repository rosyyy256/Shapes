using System.Numerics;

namespace Shapes.Extensions;

internal static class NumericExtensions
{
    internal static bool IsPositive<T>(this T value) where T : INumber<T> => value.CompareTo(T.Zero) > 0;
}
